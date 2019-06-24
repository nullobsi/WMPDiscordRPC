using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;

namespace WMPDiscordRPC
{
    static class Program
    {
        static MainForm form;
        static DiscordRpcClient client;
        static bool ready = false;
        private static System.Timers.Timer loopTimer;
        private static int playerPosition;
        private static MediaItem currentTrack;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            client = new DiscordRpcClient("369641897377136641");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.OnReady += Client_OnReady;
            client.Initialize();
            form = new MainForm();
            InitWmp();
            Application.Run(form);
        }

        private static void Client_OnReady(object sender, ReadyMessage args)
        {
            ready = true;
        }

        [STAThread]
        private static async Task<MediaItem> GetMediaDetail()
        {
            MediaItem playerMedia = null;

            try
            {
                var currentMedia = form?.MediaPlayer?.Ctlcontrols?.currentItem;

                if (currentMedia != null)
                {
                    playerMedia = new MediaItem() { TrackName = currentMedia?.getItemInfo("Title"), AlbumName = currentMedia?.getItemInfo("Album"), ArtistName = currentMedia?.getItemInfo("Artist"), TrackLength = Convert.ToDouble(currentMedia?.duration) };

                    if (playerMedia.TrackName != null)
                    {
                        playerPosition = Convert.ToInt32(form?.MediaPlayer?.Ctlcontrols?.currentPosition);
                    }
                }
                else
                {
                    playerPosition = 0;
                }
            }
            catch (Exception ex)
            {
            }

            return playerMedia;
        }
        static void InitWmp()
        {
            try
            {
                loopTimer = new System.Timers.Timer();
                loopTimer.Interval = 1000;

                loopTimer.Elapsed += async (o, e) =>
                {
                    loopTimer.Stop();
                    if (form != null)
                    {
                        Console.WriteLine("Windows Media Player Plugin checking media state...");
                            MediaItem mediaDetail = await GetMediaDetail();

                            if (mediaDetail != null && currentTrack?.TrackName != mediaDetail?.TrackName)
                            {
                                currentTrack = mediaDetail;

                                Console.WriteLine("Raising Track Change Method.");

                                DoPresenceChange(mediaDetail);
                            }

                            if (currentTrack != null)
                            {
                                Console.WriteLine($"Player position {playerPosition} of {currentTrack.TrackLength}.");
                            }

                        //Console.WriteLine("Windows Media Plugin checking media state complete.");
                    }

                    loopTimer.Start();
                };
                loopTimer.Start();
            }
            catch (Exception ex)
            {
                loopTimer.Start();
            }
        }

        private static void DoPresenceChange(MediaItem mediaItem)
        {
            if (!ready) return;
            Console.WriteLine("trackLength " + mediaItem.TrackLength);
            Console.WriteLine("ends at " + mediaItem.StartedPlaying.AddSeconds(mediaItem.TrackLength));
            Console.WriteLine("started at " + mediaItem.StartedPlaying.ToString());
            client.SetPresence(new RichPresence
            {
                Details = $"🎵 {mediaItem.TrackName}",
                State = $"👤 {mediaItem.ArtistName}",
                Assets = new Assets
                {
                    SmallImageText = $"💿 {mediaItem.AlbumName}",
                    SmallImageKey = "play",
                    LargeImageKey = "wmp",
                    LargeImageText = "Windows Media Player",
                },
                Timestamps = new Timestamps
                {
                    EndUnixMilliseconds = (ulong)new DateTimeOffset(mediaItem.StartedPlaying.AddSeconds(mediaItem.TrackLength).ToUniversalTime()).ToUnixTimeMilliseconds()
                }
            });
        }
    }
}

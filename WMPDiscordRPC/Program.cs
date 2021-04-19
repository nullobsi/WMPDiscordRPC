using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;

namespace WMPDiscordRPC
{
    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Control ctrl, string text);
        delegate void SetValueCallback(ProgressBar ctrl, int value);
        delegate void SetMaxCallback(ProgressBar ctrl, int value);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(this Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                ctrl.FindForm().Invoke(d, new object[] { ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }

        public static void SetValue(this ProgressBar ctrl, int value)
        {
            if (ctrl.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                ctrl.FindForm().Invoke(d, new object[] { ctrl, value });
            }
            else
            {
                ctrl.Value = value;
            }
        }

        public static void SetMax(this ProgressBar ctrl, int value)
        {
            if (ctrl.InvokeRequired)
            {
                SetMaxCallback d = new SetMaxCallback(SetMax);
                ctrl.FindForm().Invoke(d, new object[] { ctrl, value });
            }
            else
            {
                ctrl.Maximum = value;
            }
        }
    }
    static class Program
    {
        static MainForm form;
        static DiscordRpcClient client;
        static bool ready = false;
        private static System.Timers.Timer loopTimer;
        private static int playerPosition;
        private static MediaItem currentTrack;

        static bool isPlaying = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            client = new DiscordRpcClient("833743269169987604");
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
                        if (playerPosition != Convert.ToInt32(form?.MediaPlayer?.Ctlcontrols?.currentPosition))
                        {
                            isPlaying = true;
                        }
                        else isPlaying = false;
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

                            if (isPlaying)
                                DoPresenceChange(mediaDetail);
                        }
                        if (currentTrack != null)
                        {
                            form.albumName = currentTrack.AlbumName;
                            form.artistName = currentTrack.ArtistName;
                            form.trackName = currentTrack.TrackName;
                            form.endTime = (int)currentTrack.TrackLength;
                            form.currTime = playerPosition;
                        }
                        if (!isPlaying)
                            client.ClearPresence();
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
            catch (Exception)
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

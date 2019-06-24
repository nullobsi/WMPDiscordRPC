using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPDiscordRPC.WMP;

namespace WMPDiscordRPC
{
    public partial class MainForm : Form
    {
        public RemotedWindowsMediaPlayer MediaPlayer { get; private set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
                ShowInTaskbar = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MediaPlayer = new RemotedWindowsMediaPlayer();
            MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            MediaPlayer.Size = new Size(0, 0);
            Controls.Add(MediaPlayer);
        }
    }
}

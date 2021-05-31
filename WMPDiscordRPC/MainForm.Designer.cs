namespace WMPDiscordRPC
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackName = new System.Windows.Forms.Label();
            this.AlbumName = new System.Windows.Forms.Label();
            this.ArtistName = new System.Windows.Forms.Label();
            this.MediaProgress = new System.Windows.Forms.ProgressBar();
            this.CurrentTime = new System.Windows.Forms.Label();
            this.MaxTime = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "WMP Discord RPC";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItem1.Text = "Exit";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label1.Location = new System.Drawing.Point(117, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "WMP Discord RPC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minimizes to tray, double click to pop up again";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current Track:";
            // 
            // TrackName
            // 
            this.TrackName.AutoEllipsis = true;
            this.TrackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TrackName.Location = new System.Drawing.Point(9, 85);
            this.TrackName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TrackName.Name = "TrackName";
            this.TrackName.Size = new System.Drawing.Size(276, 18);
            this.TrackName.TabIndex = 5;
            this.TrackName.Text = "Track";
            // 
            // AlbumName
            // 
            this.AlbumName.AutoSize = true;
            this.AlbumName.Location = new System.Drawing.Point(10, 114);
            this.AlbumName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AlbumName.Name = "AlbumName";
            this.AlbumName.Size = new System.Drawing.Size(36, 13);
            this.AlbumName.TabIndex = 6;
            this.AlbumName.Text = "Album";
            // 
            // ArtistName
            // 
            this.ArtistName.AutoSize = true;
            this.ArtistName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistName.Location = new System.Drawing.Point(10, 126);
            this.ArtistName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ArtistName.Name = "ArtistName";
            this.ArtistName.Size = new System.Drawing.Size(30, 13);
            this.ArtistName.TabIndex = 7;
            this.ArtistName.Text = "Artist";
            // 
            // MediaProgress
            // 
            this.MediaProgress.BackColor = System.Drawing.SystemColors.Control;
            this.MediaProgress.Location = new System.Drawing.Point(42, 150);
            this.MediaProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MediaProgress.Name = "MediaProgress";
            this.MediaProgress.Size = new System.Drawing.Size(429, 12);
            this.MediaProgress.Step = 1;
            this.MediaProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.MediaProgress.TabIndex = 8;
            // 
            // CurrentTime
            // 
            this.CurrentTime.AutoSize = true;
            this.CurrentTime.Location = new System.Drawing.Point(4, 148);
            this.CurrentTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(34, 13);
            this.CurrentTime.TabIndex = 9;
            this.CurrentTime.Text = "00:00";
            // 
            // MaxTime
            // 
            this.MaxTime.AutoSize = true;
            this.MaxTime.Location = new System.Drawing.Point(475, 150);
            this.MaxTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MaxTime.Name = "MaxTime";
            this.MaxTime.Size = new System.Drawing.Size(34, 13);
            this.MaxTime.TabIndex = 9;
            this.MaxTime.Text = "03:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(520, 172);
            this.Controls.Add(this.MaxTime);
            this.Controls.Add(this.CurrentTime);
            this.Controls.Add(this.MediaProgress);
            this.Controls.Add(this.ArtistName);
            this.Controls.Add(this.AlbumName);
            this.Controls.Add(this.TrackName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WMP Discord RPC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TrackName;
        private System.Windows.Forms.Label AlbumName;
        private System.Windows.Forms.Label ArtistName;
        private System.Windows.Forms.ProgressBar MediaProgress;
        private System.Windows.Forms.Label CurrentTime;
        private System.Windows.Forms.Label MaxTime;
    }
}
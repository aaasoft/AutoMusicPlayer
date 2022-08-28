using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoMusicPlayer
{
    public partial class MainForm : Form
    {
        private MediaPlayer mediaPlayer;
        private LibVLC libvlc;
        private DriveInfo currentDriverInfo;
        private int currentMediaIndex = 0;
        private List<string> mediaList = new List<string>();
        private System.Speech.Synthesis.SpeechSynthesizer speechSynthesizer;
        private string[] musicFileSearchPatterns = new[] { "*.mp3", "*.flac", "*.wma" };

        public MainForm()
        {
            InitializeComponent();
            speechSynthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
            libvlc = new LibVLC(enableDebugLogs: true);
            mediaPlayer = new MediaPlayer(libvlc);
            mediaPlayer.Playing += MediaPlayer_Playing;
            mediaPlayer.Paused += MediaPlayer_Paused;
            mediaPlayer.TimeChanged += Mediaplayer_TimeChanged;
            mediaPlayer.EndReached += MediaPlayer_EndReached;
            mediaPlayer.EncounteredError += MediaPlayer_EncounteredError;
            speechSynthesizer.Speak("自动音乐播放器启动完成。");
        }

        private bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        private void MediaPlayer_Playing(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                btnPause.Text = "暂停";
                lblArtist.Text = mediaPlayer.Media.Meta(MetadataType.Artist);
                lblAlbum.Text = mediaPlayer.Media.Meta(MetadataType.Album);
                lblTitle.Text = mediaPlayer.Media.Meta(MetadataType.Title);
                var title = mediaPlayer.Media.Meta(MetadataType.Title);
                if (HasChinese(title))
                    speechSynthesizer.Speak("正在播放：" + lblTitle.Text);
            }));
        }

        private void MediaPlayer_Paused(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                btnPause.Text = "播放";
            }));
        }

        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            playNext();
        }

        private void MediaPlayer_EndReached(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                playNext();
            }));
        }

        private void onError()
        {
            BeginInvoke(new Action(() =>
            {
                currentDriverInfo = null;
                currentMediaIndex = 0;
                mediaList.Clear();

                pbMain.Value = 0;
                lblProgress.Text = string.Empty;
                lblUDisk.Text = null;
                lblArtist.Text = null;
                lblAlbum.Text = null;                
                lblTitle.Text = null;
                btnPause.Enabled = false;
                btnPre.Enabled = false;
                btnNext.Enabled = false;
            }));
        }

        private void Mediaplayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            var totalTime = mediaPlayer.Media.Duration;
            if (totalTime == 0)
            {
                onError();
                return;
            }

            var progress = Convert.ToInt32(e.Time * 100 / totalTime);
            var timeFormat = @"hh\:mm\:ss";
            var progressText = $"{TimeSpan.FromMilliseconds(e.Time).ToString(timeFormat)} / {TimeSpan.FromMilliseconds(totalTime).ToString(timeFormat)}";
            BeginInvoke(new Action(() =>
            {
                pbMain.Value = progress;
                lblProgress.Text = progressText;
            }));
        }

        private void UpdateDriveInfo(DriveInfo driveInfo)
        {
            if (driveInfo == null && currentDriverInfo == null)
                return;
            if (driveInfo == null)
            {
                onError();
                return;
            }

            if (currentDriverInfo == null || currentDriverInfo.Name != driveInfo.Name)
            {
                currentDriverInfo = driveInfo;
                lblUDisk.Text = $"{driveInfo.VolumeLabel} ({driveInfo.Name})";
                mediaList.Clear();
                foreach (var musicFileSearchPattern in musicFileSearchPatterns)
                    foreach (var file in Directory
                        .GetFiles(driveInfo.Name, musicFileSearchPattern, SearchOption.AllDirectories)
                        .OrderBy(t => t))
                        mediaList.Add(file);

                btnPause.Enabled = true;
                btnPre.Enabled = true;
                btnNext.Enabled = true;

                playNext();
            }
        }

        private void playPre()
        {
            BeginInvoke(new Action(() =>
            {
                if (mediaList.Count == 0)
                    return;

                currentMediaIndex--;
                if (currentMediaIndex < 0)
                    currentMediaIndex = mediaList.Count - 1;

                play(mediaList[currentMediaIndex]);
            }));
        }

        private void play(string file = null)
        {
            if (!string.IsNullOrEmpty(file))
                mediaPlayer.Play(new Media(libvlc, file));
        }

        private void playNext()
        {
            BeginInvoke(new Action(() =>
                {
                    if (mediaList.Count == 0)
                        return;

                    currentMediaIndex++;
                    if (currentMediaIndex >= mediaList.Count)
                        currentMediaIndex = 0;

                    play(mediaList[currentMediaIndex]);
                }));
        }

        private void timerUDiskCheck_Tick(object sender, EventArgs e)
        {
            var driveInfo = DriveInfo.GetDrives().Where(t => t.IsReady && t.DriveType == DriveType.Removable).LastOrDefault();
            UpdateDriveInfo(driveInfo);
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            playPre();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            playNext();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 101:
                            btnPause.PerformClick();
                            break;
                        case 102:
                            btnPre.PerformClick();
                            break;
                        case 103:
                            btnNext.PerformClick();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.Tab);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.None, Keys.Up);
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.None, Keys.Down);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
            HotKey.UnregisterHotKey(Handle, 103);
        }
    }
}

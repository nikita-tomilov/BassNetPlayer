using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.InteropServices;

namespace HMI_Exam
{
    using Un4seen.Bass;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public string[] args;

        private string currentPlayingTrackFile = "";

        private int stream = -1;

        private Region GetRegion(Bitmap _img)
        {
            var rgn = new Region();
            rgn.MakeEmpty();
            var rc = new Rectangle(0, 0, 0, 0);
            bool inimage = false;
            for (int y = 0; y < _img.Height; y++)
            {
                for (int x = 0; x < _img.Width; x++)
                {
                    if (!inimage)
                    {
                        // if pixel is not transparent
                        if (_img.GetPixel(x, y).A != 0)
                        {
                            inimage = true;
                            rc.X = x;
                            rc.Y = y;
                            rc.Height = 1;
                        }
                    }
                    else
                    {
                        // if pixel is transparent
                        if (_img.GetPixel(x, y).A == 0)
                        {
                            inimage = false;
                            rc.Width = x - rc.X;
                            rgn.Union(rc);
                        }
                    }
                }
                if (inimage)
                {
                    inimage = false;
                    rc.Width = _img.Width - rc.X;
                    rgn.Union(rc);
                }
            }
            return rgn;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            Bass.BASS_Init(1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

            foreach (string s in args)
            {
                lbFiles.Items.Add(s);
            }

            if (lbFiles.Items.Count != 0)
            {
                BassPlayerLoad(lbFiles.Items[0].ToString());
            }
            
            this.Region = GetRegion(new Bitmap(this.BackgroundImage));
            this.BackgroundImage = null;
            foreach (Button b in this.Controls.OfType<Button>())
            {
                b.Region = GetRegion(new Bitmap(b.BackgroundImage));
            }
        }

        private void BassPlayerLoad(string url)
        {
            Un4seen.Bass.BASSActive isActive = default(Un4seen.Bass.BASSActive);
            
            isActive = Bass.BASS_ChannelIsActive(stream);
            if (isActive == Un4seen.Bass.BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelStop(stream);
            }

            // If ofd.FileName = "" Then Exit Sub
            stream = Bass.BASS_StreamCreateFile(url, 0, 0, BASSFlag.BASS_STREAM_AUTOFREE | BASSFlag.BASS_STREAM_PRESCAN);
            //stream = Bass.BASS_StreamCreateURL(url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

            //  stream = Bass.BASS_Stream
            Bass.BASS_ChannelPlay(stream, false);
            Un4seen.Bass.BASS_CHANNELINFO CI = new Un4seen.Bass.BASS_CHANNELINFO();
            Un4seen.Bass.AddOn.Tags.TAG_INFO TI = new Un4seen.Bass.AddOn.Tags.TAG_INFO();

            // WF = New Un4seen.Bass.Misc.WaveForm(ofd.FileName, New Un4seen.Bass.Misc.WAVEFORMPROC(AddressOf MyWaveFormCallback), Me)
            // WF.RenderStart(True, BASSFlag.BASS_DEFAULT)

            tmrUpdateControls.Start();
            tmrVisuals.Start();

            TagLib.File f = TagLib.File.Create(url);
            lblTrackInfo.Text = f.Tag.Artists[0] + " - " + f.Tag.Title;
            cmdPlay.BackgroundImage = pbPausePick.BackgroundImage;

            currentPlayingTrackFile = url;
            tmrUpdateControls_Tick(null, null);
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {
            Un4seen.Bass.BASSActive isActive = default(Un4seen.Bass.BASSActive);

            isActive = Bass.BASS_ChannelIsActive(stream);
            if (isActive == Un4seen.Bass.BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(stream);
                cmdPlay.BackgroundImage = pbPlayPic.BackgroundImage; 
            }
            else if (isActive == Un4seen.Bass.BASSActive.BASS_ACTIVE_PAUSED)
            {
                Bass.BASS_ChannelPlay(stream, false);
                cmdPlay.BackgroundImage = pbPausePick.BackgroundImage;
            }

        }

        private void tmrUpdateControls_Tick(object sender, EventArgs e)
        {
            if (stream == -1) return;
            try
            {
                long pos = 0;
                long len = 0;
                len = Bass.BASS_ChannelGetLength(stream);
                pos = Bass.BASS_ChannelGetPosition(stream);

                double tElapsed = 0;
                double tRemain = 0;
                double tLength = 0;
                tLength = Bass.BASS_ChannelBytes2Seconds(stream, len);
                tElapsed = Bass.BASS_ChannelBytes2Seconds(stream, pos);
                tRemain = tLength - tElapsed;
                lblTime2.Text = Un4seen.Bass.Utils.FixTimespan(tLength, "MMSS");
                lblTime1.Text = Un4seen.Bass.Utils.FixTimespan(tElapsed, "MMSS");

                trbPosition.MaxValue = (int)(Bass.BASS_ChannelGetLength(stream) / 1000);
                if (!shouldChangePosition)
                {
                    trbPosition.Value = (int)(Bass.BASS_ChannelGetPosition(stream) / 1000);
                    if (tRemain == 0)
                    {
                        if (lbFiles.Items.Count > 1)
                        {
                            cmdNext.PerformClick();
                        }
                    }
                }
                
            }
            catch (Exception ex) { }
        }

        float[] dd = new float[1024];
        float[] freq = new float[7];
        Graphics g;
        Bitmap bmp = new Bitmap(440,290);
        Pen p = new Pen(Color.Blue /*trb.SliderColorLow.ColorA*/, 4);
        Pen p2 = new Pen(Color.Green);
        Un4seen.Bass.Misc.Visuals spektrum = new Un4seen.Bass.Misc.Visuals();
        private void tmrVisuals_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            /*freq[1] = (spektrum.DetectFrequency(stream, 1, 100, true) * 55);
            freq[2] = (spektrum.DetectFrequency(stream, 100, 300, true) * 110);
            freq[3] = (spektrum.DetectFrequency(stream, 300, 1000, true) * 385);
            freq[4] = (spektrum.DetectFrequency(stream, 1000, 3000, true) * 550);
            freq[5] = (spektrum.DetectFrequency(stream, 3000, 6000, true) * 825);
            freq[6] = (spektrum.DetectFrequency(stream, 6000, 20000, true) * 2475);
            freq[1] = Math.Min(freq[1], 100);
            freq[2] = Math.Min(freq[2], 100);
            freq[3] = Math.Min(freq[3], 100);
            freq[4] = Math.Min(freq[4], 100);
            freq[5] = Math.Min(freq[5], 100);
            freq[6] = Math.Min(freq[6], 100);*/
            // Debug.Print("===")
            float[] d = new float[1024];
            int k;
            int x;
            int y;
            Brush b = default(Brush);
            g.Clear(Color.White);
            Un4seen.Bass.BASSActive isActive = default(Un4seen.Bass.BASSActive);
            isActive = Bass.BASS_ChannelIsActive(stream);

            
            if (isActive == Un4seen.Bass.BASSActive.BASS_ACTIVE_PLAYING) {
                
	            Bass.BASS_ChannelGetData(stream, d, (int)Un4seen.Bass.BASSData.BASS_DATA_FFT1024);
            } else if (isActive == Un4seen.Bass.BASSActive.BASS_ACTIVE_PAUSED) {
	            for (int i = 0; i <= 1023; i++) {
		            d[i] = d[i] - 0.002F;
		            d[i] = Math.Max(d[i], 0);
	            }
            }

            for (int i = 0; i <= 511; i += 2) {
	            k = (int)(255 * d[i] * 10);
	            k = Math.Min(k, 255);

	            
	            x = (i + 1) / 1024 * bmp.Width;
	            y = (i + 1) / 1024 * bmp.Height;
	            x = bmp.Width;
	            y = bmp.Height - 3;
	            g.DrawLine(p, i * 2 + 10, y, i * 2 + 10, y * (1 - d[i] * 5));
                /*if (i > 0)
                {
                    g.DrawLine(p, i * 2 + 10, y * (1 - d[i] * 5), (i - 1) * 2 + 10, y * (1 - d[i - 1] * 5));
                }*/
                //p = new Pen(Color.Red, 1);
	            //g.DrawLine(p, i * 2 + 10, y, i * 2 + 10, y * (1 - d[i] * 5));
	            dd[i] = dd[i] - 0.002F;
	            if (dd[i] < d[i])
		            dd[i] = d[i];
                b = new SolidBrush(Color.Red);
	            g.FillRectangle(b, i * 2 + 8, y * (1 - dd[i] * 5) - 2, 4, 2);
            }
            pbVisuals.Image = bmp;
        }

        private void pbVisuals_Click(object sender, EventArgs e)
        {

        }

        //beautifying

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private struct DWMCOLORIZATIONPARAMS
        {
            public UInt32 ColorizationColor;
            public UInt32 ColorizationAfterglow;
            public UInt32 ColorizationColorBalance;
            public UInt32 ColorizationAfterglowBalance;
            public UInt32 ColorizationBlurBalance;
            public UInt32 ColorizationGlassReflectionIntensity;
            public UInt32 ColorizationOpaqueBlend;
        }

        [DllImport("dwmapi.dll", EntryPoint = "#127")]
        private static extern DWMCOLORIZATIONPARAMS DwmGetColorizationParameters();

        private void tmrColor_Tick(object sender, EventArgs e)
        {
            try
            {
                DWMCOLORIZATIONPARAMS c = DwmGetColorizationParameters();
                int r;
                int g;
                int b;

                byte[] bb = BitConverter.GetBytes(c.ColorizationColor);

                Color cc = Color.FromArgb(bb[3], bb[2], bb[1], bb[0]);
                cc = Color.FromArgb(255, cc.R, cc.G, cc.B);

                double h;
                double s;
                double v;

                ColorToHSV(cc, out h, out s, out v);
                v = Math.Min(1, v + 0.1);
                cc = ColorFromHSV(h, s, v);
                v = Math.Min(1, v + 0.3);
                Color cc2 = cc = ColorFromHSV(h, s, v);
                updateAllColors(cc, cc2);
            }
            catch (Exception ex)
            {

            }
        }

        private void updateAllColors(Color backColor, Color lighterForeColor)
        {
            this.BackColor = backColor;
            trbPosition.SliderColorLow.ColorA = lighterForeColor;
            trbPosition.SliderColorLow.ColorB = lighterForeColor;
            trbVolume.SliderColorLow.ColorA = lighterForeColor;
            trbVolume.SliderColorLow.ColorB = lighterForeColor;
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void trbPosition_ValueChanged(object sender, EventArgs e)
        {
            if (shouldChangePosition)
            {
                Bass.BASS_ChannelSetPosition(stream, trbPosition.Value * 1000);
                tmrUpdateControls_Tick(sender, e);
            }
        }

        bool shouldChangePosition = false;

        private void trbPosition_Scroll(object sender, ScrollEventArgs e)
        {
            }

        private void trbPosition_MouseDown(object sender, MouseEventArgs e)
        {
            shouldChangePosition = true;
        }

        private void trbPosition_MouseUp(object sender, MouseEventArgs e)
        {
            shouldChangePosition = false;
        }

        private void cmdMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trbVolume_ValueChanged(object sender, EventArgs e)
        {
            Bass.BASS_ChannelSetAttribute(stream, Un4seen.Bass.BASSAttribute.BASS_ATTRIB_VOL, trbVolume.Value / 100F);
            //Bass.BASS_SetVolume(trbVolume.Value / 100F);
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lbFiles.SelectedIndex >= 0)
            {
                BassPlayerLoad(lbFiles.SelectedItem.ToString());
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                if (lbFiles.Items[i].Equals(currentPlayingTrackFile))
                {
                    index = i;
                    break;
                }
            }
            index++;
            if (index >= lbFiles.Items.Count) index = 0;
            if (lbFiles.Items.Count > 0) { 
                lbFiles.SelectedIndex = index;
                lbFiles_DoubleClick(sender, e);
            }
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            int index = 0;
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                if (lbFiles.Items[i].Equals(currentPlayingTrackFile))
                {
                    index = i;
                    break;
                }
            }
            index--;
            if (index < 0) index = lbFiles.Items.Count - 1;
            if (lbFiles.Items.Count > 0)
            {
                lbFiles.SelectedIndex = index;
                lbFiles_DoubleClick(sender, e);
            }
        }

        private void lbFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) && (lbFiles.SelectedIndex >= 0))
            {
                lbFiles.Items.RemoveAt(lbFiles.SelectedIndex);
            }
        }

        private void lbFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lbFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string s in files)
            {
                if (s.EndsWith(".mp3"))
                {
                    lbFiles.Items.Add(s);
                }
            }
        }
    }
}

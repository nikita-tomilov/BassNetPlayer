namespace HMI_Exam
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdPlay = new System.Windows.Forms.Button();
            this.tmrUpdateControls = new System.Windows.Forms.Timer(this.components);
            this.tmrVisuals = new System.Windows.Forms.Timer(this.components);
            this.pbVisuals = new System.Windows.Forms.PictureBox();
            this.tmrColor = new System.Windows.Forms.Timer(this.components);
            this.cmdPrev = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.trbPosition = new gTrackBar.gTrackBar();
            this.cmdMinimize = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.lblTime1 = new System.Windows.Forms.Label();
            this.lblTime2 = new System.Windows.Forms.Label();
            this.lblTrackInfo = new System.Windows.Forms.Label();
            this.trbVolume = new gTrackBar.gTrackBar();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.pbPlayPic = new System.Windows.Forms.PictureBox();
            this.pbPausePick = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisuals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPausePick)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdPlay
            // 
            this.cmdPlay.BackColor = System.Drawing.Color.White;
            this.cmdPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdPlay.BackgroundImage")));
            this.cmdPlay.FlatAppearance.BorderSize = 0;
            this.cmdPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPlay.Location = new System.Drawing.Point(13, 68);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(48, 48);
            this.cmdPlay.TabIndex = 0;
            this.cmdPlay.UseVisualStyleBackColor = false;
            this.cmdPlay.Click += new System.EventHandler(this.cmdPlay_Click);
            // 
            // tmrUpdateControls
            // 
            this.tmrUpdateControls.Interval = 1000;
            this.tmrUpdateControls.Tick += new System.EventHandler(this.tmrUpdateControls_Tick);
            // 
            // tmrVisuals
            // 
            this.tmrVisuals.Interval = 33;
            this.tmrVisuals.Tick += new System.EventHandler(this.tmrVisuals_Tick);
            // 
            // pbVisuals
            // 
            this.pbVisuals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVisuals.BackColor = System.Drawing.Color.White;
            this.pbVisuals.Location = new System.Drawing.Point(186, 179);
            this.pbVisuals.Name = "pbVisuals";
            this.pbVisuals.Size = new System.Drawing.Size(440, 290);
            this.pbVisuals.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVisuals.TabIndex = 3;
            this.pbVisuals.TabStop = false;
            this.pbVisuals.Click += new System.EventHandler(this.pbVisuals_Click);
            // 
            // tmrColor
            // 
            this.tmrColor.Enabled = true;
            this.tmrColor.Tick += new System.EventHandler(this.tmrColor_Tick);
            // 
            // cmdPrev
            // 
            this.cmdPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdPrev.BackgroundImage")));
            this.cmdPrev.FlatAppearance.BorderSize = 0;
            this.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrev.Location = new System.Drawing.Point(13, 119);
            this.cmdPrev.Name = "cmdPrev";
            this.cmdPrev.Size = new System.Drawing.Size(24, 24);
            this.cmdPrev.TabIndex = 4;
            this.cmdPrev.UseVisualStyleBackColor = true;
            this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdNext.BackgroundImage")));
            this.cmdNext.FlatAppearance.BorderSize = 0;
            this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNext.Location = new System.Drawing.Point(37, 119);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(24, 24);
            this.cmdNext.TabIndex = 5;
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // trbPosition
            // 
            this.trbPosition.BackColor = System.Drawing.Color.White;
            this.trbPosition.FloatValue = false;
            this.trbPosition.Label = null;
            this.trbPosition.Location = new System.Drawing.Point(140, 119);
            this.trbPosition.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.trbPosition.Name = "trbPosition";
            this.trbPosition.ShowFocus = false;
            this.trbPosition.Size = new System.Drawing.Size(406, 23);
            this.trbPosition.SliderSize = new System.Drawing.Size(10, 10);
            this.trbPosition.SliderWidthHigh = 1F;
            this.trbPosition.SliderWidthLow = 1F;
            this.trbPosition.TabIndex = 6;
            this.trbPosition.TickColor = System.Drawing.Color.White;
            this.trbPosition.TickThickness = 1F;
            this.trbPosition.UpDownShow = false;
            this.trbPosition.Value = 0;
            this.trbPosition.ValueAdjusted = 0F;
            this.trbPosition.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
            this.trbPosition.ValueStrFormat = null;
            this.trbPosition.ValueChanged += new gTrackBar.gTrackBar.ValueChangedEventHandler(this.trbPosition_ValueChanged);
            this.trbPosition.Scroll += new System.Windows.Forms.ScrollEventHandler(this.trbPosition_Scroll);
            this.trbPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trbPosition_MouseDown);
            this.trbPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trbPosition_MouseUp);
            // 
            // cmdMinimize
            // 
            this.cmdMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdMinimize.BackgroundImage")));
            this.cmdMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdMinimize.FlatAppearance.BorderSize = 0;
            this.cmdMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMinimize.Location = new System.Drawing.Point(526, 36);
            this.cmdMinimize.Name = "cmdMinimize";
            this.cmdMinimize.Size = new System.Drawing.Size(48, 24);
            this.cmdMinimize.TabIndex = 7;
            this.cmdMinimize.UseVisualStyleBackColor = true;
            this.cmdMinimize.Click += new System.EventHandler(this.cmdMinimize_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdClose.BackgroundImage")));
            this.cmdClose.FlatAppearance.BorderSize = 0;
            this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdClose.Location = new System.Drawing.Point(580, 36);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(48, 24);
            this.cmdClose.TabIndex = 8;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // lblTime1
            // 
            this.lblTime1.BackColor = System.Drawing.Color.White;
            this.lblTime1.Location = new System.Drawing.Point(86, 119);
            this.lblTime1.Name = "lblTime1";
            this.lblTime1.Size = new System.Drawing.Size(49, 23);
            this.lblTime1.TabIndex = 9;
            this.lblTime1.Text = "00:00";
            this.lblTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime2
            // 
            this.lblTime2.BackColor = System.Drawing.Color.White;
            this.lblTime2.Location = new System.Drawing.Point(551, 119);
            this.lblTime2.Name = "lblTime2";
            this.lblTime2.Size = new System.Drawing.Size(49, 23);
            this.lblTime2.TabIndex = 10;
            this.lblTime2.Text = "00:00";
            this.lblTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrackInfo
            // 
            this.lblTrackInfo.BackColor = System.Drawing.Color.White;
            this.lblTrackInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrackInfo.Location = new System.Drawing.Point(86, 68);
            this.lblTrackInfo.Name = "lblTrackInfo";
            this.lblTrackInfo.Size = new System.Drawing.Size(542, 75);
            this.lblTrackInfo.TabIndex = 11;
            this.lblTrackInfo.Text = "Some Track Here";
            // 
            // trbVolume
            // 
            this.trbVolume.BackColor = System.Drawing.Color.White;
            this.trbVolume.FloatValue = false;
            this.trbVolume.Label = null;
            this.trbVolume.Location = new System.Drawing.Point(601, 83);
            this.trbVolume.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.trbVolume.MaxValue = 100;
            this.trbVolume.Name = "trbVolume";
            this.trbVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbVolume.ShowFocus = false;
            this.trbVolume.Size = new System.Drawing.Size(23, 59);
            this.trbVolume.SliderSize = new System.Drawing.Size(10, 10);
            this.trbVolume.SliderWidthHigh = 1F;
            this.trbVolume.SliderWidthLow = 1F;
            this.trbVolume.TabIndex = 12;
            this.trbVolume.TickColor = System.Drawing.Color.White;
            this.trbVolume.TickThickness = 1F;
            this.trbVolume.UpDownShow = false;
            this.trbVolume.Value = 100;
            this.trbVolume.ValueAdjusted = 100F;
            this.trbVolume.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
            this.trbVolume.ValueStrFormat = null;
            this.trbVolume.ValueChanged += new gTrackBar.gTrackBar.ValueChangedEventHandler(this.trbVolume_ValueChanged);
            // 
            // lbFiles
            // 
            this.lbFiles.AllowDrop = true;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.HorizontalScrollbar = true;
            this.lbFiles.Location = new System.Drawing.Point(13, 179);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(167, 290);
            this.lbFiles.TabIndex = 13;
            this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_SelectedIndexChanged);
            this.lbFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragDrop);
            this.lbFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbFiles_DragEnter);
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            this.lbFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbFiles_KeyUp);
            // 
            // pbPlayPic
            // 
            this.pbPlayPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPlayPic.BackgroundImage")));
            this.pbPlayPic.Location = new System.Drawing.Point(1, 0);
            this.pbPlayPic.Name = "pbPlayPic";
            this.pbPlayPic.Size = new System.Drawing.Size(100, 50);
            this.pbPlayPic.TabIndex = 14;
            this.pbPlayPic.TabStop = false;
            // 
            // pbPausePick
            // 
            this.pbPausePick.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbPausePick.BackgroundImage")));
            this.pbPausePick.Location = new System.Drawing.Point(107, 0);
            this.pbPausePick.Name = "pbPausePick";
            this.pbPausePick.Size = new System.Drawing.Size(100, 50);
            this.pbPausePick.TabIndex = 15;
            this.pbPausePick.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.pbPausePick);
            this.Controls.Add(this.pbPlayPic);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.trbVolume);
            this.Controls.Add(this.lblTime2);
            this.Controls.Add(this.trbPosition);
            this.Controls.Add(this.lblTime1);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdMinimize);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdPrev);
            this.Controls.Add(this.pbVisuals);
            this.Controls.Add(this.cmdPlay);
            this.Controls.Add(this.lblTrackInfo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbVisuals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPausePick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.Timer tmrUpdateControls;
        private System.Windows.Forms.Timer tmrVisuals;
        private System.Windows.Forms.PictureBox pbVisuals;
        private System.Windows.Forms.Timer tmrColor;
        private System.Windows.Forms.Button cmdPrev;
        private System.Windows.Forms.Button cmdNext;
        private gTrackBar.gTrackBar trbPosition;
        private System.Windows.Forms.Button cmdMinimize;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Label lblTime1;
        private System.Windows.Forms.Label lblTime2;
        private System.Windows.Forms.Label lblTrackInfo;
        private gTrackBar.gTrackBar trbVolume;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.PictureBox pbPlayPic;
        private System.Windows.Forms.PictureBox pbPausePick;
    }
}


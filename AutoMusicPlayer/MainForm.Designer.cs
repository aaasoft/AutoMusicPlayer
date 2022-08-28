namespace AutoMusicPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerUDiskCheck = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblUDisk = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMain.Location = new System.Drawing.Point(35, 255);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(827, 31);
            this.pbMain.TabIndex = 4;
            // 
            // lblProgress
            // 
            this.lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProgress.Location = new System.Drawing.Point(143, 211);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(719, 32);
            this.lblProgress.TabIndex = 5;
            this.lblProgress.Text = "00:00 / 00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "时间：";
            // 
            // timerUDiskCheck
            // 
            this.timerUDiskCheck.Enabled = true;
            this.timerUDiskCheck.Interval = 1000;
            this.timerUDiskCheck.Tick += new System.EventHandler(this.timerUDiskCheck_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "U盘：";
            // 
            // lblUDisk
            // 
            this.lblUDisk.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUDisk.Location = new System.Drawing.Point(143, 9);
            this.lblUDisk.Name = "lblUDisk";
            this.lblUDisk.Size = new System.Drawing.Size(719, 32);
            this.lblUDisk.TabIndex = 5;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(35, 301);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(114, 59);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(155, 301);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(114, 59);
            this.btnPre.TabIndex = 6;
            this.btnPre.Text = "上一曲";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(275, 301);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(114, 59);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "下一曲";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "艺术家：";
            // 
            // lblArtist
            // 
            this.lblArtist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblArtist.Location = new System.Drawing.Point(143, 51);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(719, 32);
            this.lblArtist.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "专辑：";
            // 
            // lblAlbum
            // 
            this.lblAlbum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAlbum.Location = new System.Drawing.Point(143, 94);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(719, 32);
            this.lblAlbum.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "标题：";
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Location = new System.Drawing.Point(143, 136);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(719, 32);
            this.lblTitle.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 398);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUDisk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动音乐播放器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbMain;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerUDiskCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUDisk;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTitle;
    }
}


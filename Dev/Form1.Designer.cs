namespace BiLiCrack
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbVideo = new System.Windows.Forms.TextBox();
            this.btnVideoChoose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAudio = new System.Windows.Forms.TextBox();
            this.btnAudioChoose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVideoInfo = new System.Windows.Forms.TextBox();
            this.btnCrack = new System.Windows.Forms.Button();
            this.ofdVideo = new System.Windows.Forms.OpenFileDialog();
            this.ofdAudio = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnAudioCrack = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnVideoInfo = new System.Windows.Forms.Button();
            this.ofdVideoInfo = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "视频";
            // 
            // tbVideo
            // 
            this.tbVideo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbVideo.Location = new System.Drawing.Point(86, 38);
            this.tbVideo.Name = "tbVideo";
            this.tbVideo.Size = new System.Drawing.Size(204, 25);
            this.tbVideo.TabIndex = 1;
            // 
            // btnVideoChoose
            // 
            this.btnVideoChoose.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideoChoose.Location = new System.Drawing.Point(320, 38);
            this.btnVideoChoose.Name = "btnVideoChoose";
            this.btnVideoChoose.Size = new System.Drawing.Size(93, 27);
            this.btnVideoChoose.TabIndex = 2;
            this.btnVideoChoose.Text = "选择视频";
            this.btnVideoChoose.UseVisualStyleBackColor = true;
            this.btnVideoChoose.Click += new System.EventHandler(this.btnVideoChoose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "音频";
            // 
            // tbAudio
            // 
            this.tbAudio.Location = new System.Drawing.Point(86, 95);
            this.tbAudio.Name = "tbAudio";
            this.tbAudio.Size = new System.Drawing.Size(204, 28);
            this.tbAudio.TabIndex = 4;
            // 
            // btnAudioChoose
            // 
            this.btnAudioChoose.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAudioChoose.Location = new System.Drawing.Point(320, 95);
            this.btnAudioChoose.Name = "btnAudioChoose";
            this.btnAudioChoose.Size = new System.Drawing.Size(93, 28);
            this.btnAudioChoose.TabIndex = 5;
            this.btnAudioChoose.Text = "选择音频";
            this.btnAudioChoose.UseVisualStyleBackColor = true;
            this.btnAudioChoose.Click += new System.EventHandler(this.btnAudioChoose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(83, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "选文件大小较大的那个";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "选文件大小较小的那个";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(15, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "视频名";
            // 
            // tbVideoInfo
            // 
            this.tbVideoInfo.Location = new System.Drawing.Point(87, 163);
            this.tbVideoInfo.Name = "tbVideoInfo";
            this.tbVideoInfo.Size = new System.Drawing.Size(202, 28);
            this.tbVideoInfo.TabIndex = 9;
            // 
            // btnCrack
            // 
            this.btnCrack.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCrack.Location = new System.Drawing.Point(320, 231);
            this.btnCrack.Name = "btnCrack";
            this.btnCrack.Size = new System.Drawing.Size(120, 45);
            this.btnCrack.TabIndex = 10;
            this.btnCrack.Text = "破解视频";
            this.btnCrack.UseVisualStyleBackColor = true;
            this.btnCrack.Click += new System.EventHandler(this.btnCrack_Click);
            // 
            // ofdVideo
            // 
            this.ofdVideo.FileName = "openFileDialog1";
            this.ofdVideo.Title = "请选择视频";
            // 
            // ofdAudio
            // 
            this.ofdAudio.FileName = "openFileDialog1";
            this.ofdAudio.Title = "请选择音频";
            // 
            // btnAudioCrack
            // 
            this.btnAudioCrack.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAudioCrack.Location = new System.Drawing.Point(179, 241);
            this.btnAudioCrack.Name = "btnAudioCrack";
            this.btnAudioCrack.Size = new System.Drawing.Size(111, 30);
            this.btnAudioCrack.TabIndex = 13;
            this.btnAudioCrack.Text = "只破解音频";
            this.btnAudioCrack.UseVisualStyleBackColor = true;
            this.btnAudioCrack.Click += new System.EventHandler(this.btnAudioCrack_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(47, 241);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 30);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnVideoInfo
            // 
            this.btnVideoInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnVideoInfo.Location = new System.Drawing.Point(295, 163);
            this.btnVideoInfo.Name = "btnVideoInfo";
            this.btnVideoInfo.Size = new System.Drawing.Size(152, 28);
            this.btnVideoInfo.TabIndex = 15;
            this.btnVideoInfo.Text = "选择视频信息";
            this.btnVideoInfo.UseVisualStyleBackColor = true;
            this.btnVideoInfo.Click += new System.EventHandler(this.btnVideoInfo_Click);
            // 
            // ofdVideoInfo
            // 
            this.ofdVideoInfo.FileName = "ofdVideoInfo";
            this.ofdVideoInfo.Filter = "JSON (*.json)|*.json";
            this.ofdVideoInfo.Title = "选择视频信息文件";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "选择json文件";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 311);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnVideoInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAudioCrack);
            this.Controls.Add(this.btnCrack);
            this.Controls.Add(this.tbVideoInfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAudioChoose);
            this.Controls.Add(this.tbAudio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVideoChoose);
            this.Controls.Add(this.tbVideo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Bilibili破解";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVideo;
        private System.Windows.Forms.Button btnVideoChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAudio;
        private System.Windows.Forms.Button btnAudioChoose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVideoInfo;
        private System.Windows.Forms.Button btnCrack;
        private System.Windows.Forms.OpenFileDialog ofdVideo;
        private System.Windows.Forms.OpenFileDialog ofdAudio;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnAudioCrack;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnVideoInfo;
        private System.Windows.Forms.OpenFileDialog ofdVideoInfo;
        private System.Windows.Forms.Label label6;
    }
}


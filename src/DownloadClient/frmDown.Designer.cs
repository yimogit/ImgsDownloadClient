namespace DownloadClient
{
    partial class frmDown
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
            this.btnUploadImgs = new System.Windows.Forms.Button();
            this.txtSaveDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.txtLogMsg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtImageUrls = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetHtml = new System.Windows.Forms.Button();
            this.txtPageUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUploadImgs
            // 
            this.btnUploadImgs.Location = new System.Drawing.Point(135, 425);
            this.btnUploadImgs.Name = "btnUploadImgs";
            this.btnUploadImgs.Size = new System.Drawing.Size(106, 23);
            this.btnUploadImgs.TabIndex = 10;
            this.btnUploadImgs.Text = "下载图片";
            this.btnUploadImgs.UseVisualStyleBackColor = true;
            this.btnUploadImgs.Click += new System.EventHandler(this.btnUploadImgs_Click);
            // 
            // txtSaveDir
            // 
            this.txtSaveDir.Location = new System.Drawing.Point(135, 24);
            this.txtSaveDir.Name = "txtSaveDir";
            this.txtSaveDir.Size = new System.Drawing.Size(266, 21);
            this.txtSaveDir.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "保存目录：";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(328, 425);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 14;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // txtLogMsg
            // 
            this.txtLogMsg.Location = new System.Drawing.Point(440, 50);
            this.txtLogMsg.Multiline = true;
            this.txtLogMsg.Name = "txtLogMsg";
            this.txtLogMsg.Size = new System.Drawing.Size(501, 398);
            this.txtLogMsg.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(438, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "日志输出：";
            // 
            // txtImageUrls
            // 
            this.txtImageUrls.Location = new System.Drawing.Point(135, 105);
            this.txtImageUrls.Multiline = true;
            this.txtImageUrls.Name = "txtImageUrls";
            this.txtImageUrls.Size = new System.Drawing.Size(266, 308);
            this.txtImageUrls.TabIndex = 17;
            this.txtImageUrls.TextChanged += new System.EventHandler(this.txtImageUrls_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "远程图片：";
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Location = new System.Drawing.Point(248, 425);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDir.TabIndex = 19;
            this.btnOpenDir.Text = "打开目录";
            this.btnOpenDir.UseVisualStyleBackColor = true;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(134, 51);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(267, 21);
            this.txtDomain.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "域名前缀：";
            // 
            // btnGetHtml
            // 
            this.btnGetHtml.Location = new System.Drawing.Point(326, 76);
            this.btnGetHtml.Name = "btnGetHtml";
            this.btnGetHtml.Size = new System.Drawing.Size(75, 23);
            this.btnGetHtml.TabIndex = 25;
            this.btnGetHtml.Text = "获取页面";
            this.btnGetHtml.UseVisualStyleBackColor = true;
            this.btnGetHtml.Click += new System.EventHandler(this.btnGetHtml_Click);
            // 
            // txtPageUrl
            // 
            this.txtPageUrl.Location = new System.Drawing.Point(134, 78);
            this.txtPageUrl.Name = "txtPageUrl";
            this.txtPageUrl.Size = new System.Drawing.Size(186, 21);
            this.txtPageUrl.TabIndex = 24;
            this.txtPageUrl.TextChanged += new System.EventHandler(this.txtPageUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "页面地址：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 460);
            this.Controls.Add(this.btnGetHtml);
            this.Controls.Add(this.txtPageUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtImageUrls);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLogMsg);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSaveDir);
            this.Controls.Add(this.btnUploadImgs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片下载客户端_by 易墨";
            this.Load += new System.EventHandler(this.frmDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnUploadImgs;
        private System.Windows.Forms.TextBox txtSaveDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.TextBox txtLogMsg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImageUrls;
        private System.Windows.Forms.Label label8;
        #endregion

        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetHtml;
        private System.Windows.Forms.TextBox txtPageUrl;
        private System.Windows.Forms.Label label1;
    }
}
namespace DeGuangTicketsHelper
{
    partial class frmTicketsHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTicketsHelper));
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picValidImg = new System.Windows.Forms.PictureBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radTickerWebBrowser = new System.Windows.Forms.RadioButton();
            this.radIE = new System.Windows.Forms.RadioButton();
            this.radDefaultWebBrowser = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssAuthor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssVersion = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picValidImg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVerificationCode.Location = new System.Drawing.Point(74, 76);
            this.txtVerificationCode.MaxLength = 4;
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.Size = new System.Drawing.Size(43, 26);
            this.txtVerificationCode.TabIndex = 30;
            this.toolTip1.SetToolTip(this.txtVerificationCode, "输入右图中的验证码");
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(15, 117);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(159, 33);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录 ";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picValidImg
            // 
            this.picValidImg.Location = new System.Drawing.Point(122, 76);
            this.picValidImg.Name = "picValidImg";
            this.picValidImg.Size = new System.Drawing.Size(78, 26);
            this.picValidImg.TabIndex = 4;
            this.picValidImg.TabStop = false;
            this.toolTip1.SetToolTip(this.picValidImg, "看不清?点击更换一个验证码");
            this.picValidImg.Click += new System.EventHandler(this.picValidImg_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(74, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(126, 26);
            this.txtUserName.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtUserName, "输入您在12306的登录名");
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(74, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 26);
            this.txtPassword.TabIndex = 20;
            this.toolTip1.SetToolTip(this.txtPassword, "输入您在12306的密码");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "登录名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "验证码";
            // 
            // lstMsg
            // 
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.HorizontalScrollbar = true;
            this.lstMsg.ItemHeight = 12;
            this.lstMsg.Location = new System.Drawing.Point(15, 156);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.Size = new System.Drawing.Size(324, 124);
            this.lstMsg.TabIndex = 9;
            this.toolTip1.SetToolTip(this.lstMsg, "执行结果");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDefaultWebBrowser);
            this.groupBox1.Controls.Add(this.radIE);
            this.groupBox1.Controls.Add(this.radTickerWebBrowser);
            this.groupBox1.Location = new System.Drawing.Point(206, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 86);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "设置登录成功后打开12306的浏览器";
            this.groupBox1.Text = "登录后使用的浏览器";
            // 
            // radTickerWebBrowser
            // 
            this.radTickerWebBrowser.AutoSize = true;
            this.radTickerWebBrowser.Checked = true;
            this.radTickerWebBrowser.Location = new System.Drawing.Point(6, 17);
            this.radTickerWebBrowser.Name = "radTickerWebBrowser";
            this.radTickerWebBrowser.Size = new System.Drawing.Size(119, 16);
            this.radTickerWebBrowser.TabIndex = 0;
            this.radTickerWebBrowser.TabStop = true;
            this.radTickerWebBrowser.Tag = "";
            this.radTickerWebBrowser.Text = "内置浏览器(推荐)";
            this.toolTip1.SetToolTip(this.radTickerWebBrowser, "德广火车票助手内置的浏览器");
            this.radTickerWebBrowser.UseVisualStyleBackColor = true;
            // 
            // radIE
            // 
            this.radIE.AutoSize = true;
            this.radIE.Location = new System.Drawing.Point(6, 39);
            this.radIE.Name = "radIE";
            this.radIE.Size = new System.Drawing.Size(71, 16);
            this.radIE.TabIndex = 0;
            this.radIE.Tag = "";
            this.radIE.Text = "IE浏览器";
            this.toolTip1.SetToolTip(this.radIE, "微软Internet Explorer浏览器");
            this.radIE.UseVisualStyleBackColor = true;
            // 
            // radDefaultWebBrowser
            // 
            this.radDefaultWebBrowser.AutoSize = true;
            this.radDefaultWebBrowser.Enabled = false;
            this.radDefaultWebBrowser.Location = new System.Drawing.Point(6, 61);
            this.radDefaultWebBrowser.Name = "radDefaultWebBrowser";
            this.radDefaultWebBrowser.Size = new System.Drawing.Size(107, 16);
            this.radDefaultWebBrowser.TabIndex = 0;
            this.radDefaultWebBrowser.Tag = "";
            this.radDefaultWebBrowser.Text = "系统默认浏览器";
            this.toolTip1.SetToolTip(this.radDefaultWebBrowser, "[暂不支持]您设定的系统默认Web浏览器");
            this.radDefaultWebBrowser.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(180, 117);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(159, 33);
            this.btnExit.TabIndex = 34;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssVersion,
            this.tssAuthor});
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(348, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssAuthor
            // 
            this.tssAuthor.ForeColor = System.Drawing.Color.Blue;
            this.tssAuthor.Name = "tssAuthor";
            this.tssAuthor.Size = new System.Drawing.Size(267, 17);
            this.tssAuthor.Spring = true;
            this.tssAuthor.Text = "深圳市德广信息技术有限公司";
            this.tssAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssAuthor.Click += new System.EventHandler(this.tssAuthor_Click);
            // 
            // tssVersion
            // 
            this.tssVersion.Name = "tssVersion";
            this.tssVersion.Size = new System.Drawing.Size(35, 17);
            this.tssVersion.Text = "版本:";
            // 
            // frmTicketsHelper
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(348, 313);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstMsg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.picValidImg);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtVerificationCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTicketsHelper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "德广火车票助手";
            this.Load += new System.EventHandler(this.frmTicketsHelper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picValidImg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVerificationCode;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox picValidImg;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radDefaultWebBrowser;
        private System.Windows.Forms.RadioButton radIE;
        private System.Windows.Forms.RadioButton radTickerWebBrowser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssAuthor;
        private System.Windows.Forms.ToolStripStatusLabel tssVersion;
    }
}
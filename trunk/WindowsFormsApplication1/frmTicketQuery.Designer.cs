namespace DeGuangTicketsHelper
{
    partial class frmTicketQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTicketQuery));
            this.flpOptions1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labDepartureStation = new System.Windows.Forms.Label();
            this.cboDepartureStation = new System.Windows.Forms.ComboBox();
            this.labDestinationStation = new System.Windows.Forms.Label();
            this.cboDestinationStation = new System.Windows.Forms.ComboBox();
            this.labDepartureDate = new System.Windows.Forms.Label();
            this.dtpDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.labDepartureTime = new System.Windows.Forms.Label();
            this.cboDepartureTime = new System.Windows.Forms.ComboBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.flpTrainType = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSeatTypies = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTrainPassType = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labTicketInfo = new System.Windows.Forms.Label();
            this.labMem = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssAuthor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoreOption = new System.Windows.Forms.Button();
            this.flpTrainNumber = new System.Windows.Forms.FlowLayoutPanel();
            this.labTrainNumber = new System.Windows.Forms.Label();
            this.cboTrainNumber = new System.Windows.Forms.ComboBox();
            this.dgvTiketInfo = new DeGuangTicketsHelper.DGDataGridView();
            this.flpOptions1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flpTrainNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiketInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // flpOptions1
            // 
            this.flpOptions1.Controls.Add(this.labDepartureStation);
            this.flpOptions1.Controls.Add(this.cboDepartureStation);
            this.flpOptions1.Controls.Add(this.labDestinationStation);
            this.flpOptions1.Controls.Add(this.cboDestinationStation);
            this.flpOptions1.Controls.Add(this.labDepartureDate);
            this.flpOptions1.Controls.Add(this.dtpDepartureDate);
            this.flpOptions1.Controls.Add(this.labDepartureTime);
            this.flpOptions1.Controls.Add(this.cboDepartureTime);
            this.flpOptions1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOptions1.Location = new System.Drawing.Point(0, 0);
            this.flpOptions1.Margin = new System.Windows.Forms.Padding(0);
            this.flpOptions1.Name = "flpOptions1";
            this.flpOptions1.Size = new System.Drawing.Size(752, 33);
            this.flpOptions1.TabIndex = 0;
            // 
            // labDepartureStation
            // 
            this.labDepartureStation.AutoSize = true;
            this.labDepartureStation.Location = new System.Drawing.Point(3, 0);
            this.labDepartureStation.Name = "labDepartureStation";
            this.labDepartureStation.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labDepartureStation.Size = new System.Drawing.Size(50, 23);
            this.labDepartureStation.TabIndex = 0;
            this.labDepartureStation.Text = "出发站:";
            // 
            // cboDepartureStation
            // 
            this.cboDepartureStation.FormattingEnabled = true;
            this.cboDepartureStation.Location = new System.Drawing.Point(59, 3);
            this.cboDepartureStation.Name = "cboDepartureStation";
            this.cboDepartureStation.Size = new System.Drawing.Size(86, 20);
            this.cboDepartureStation.TabIndex = 9;
            this.cboDepartureStation.SelectedValueChanged += new System.EventHandler(this.cboDepartureStation_SelectedValueChanged);
            // 
            // labDestinationStation
            // 
            this.labDestinationStation.AutoSize = true;
            this.labDestinationStation.Location = new System.Drawing.Point(151, 0);
            this.labDestinationStation.Name = "labDestinationStation";
            this.labDestinationStation.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labDestinationStation.Size = new System.Drawing.Size(50, 23);
            this.labDestinationStation.TabIndex = 2;
            this.labDestinationStation.Text = "目的站:";
            // 
            // cboDestinationStation
            // 
            this.cboDestinationStation.FormattingEnabled = true;
            this.cboDestinationStation.Location = new System.Drawing.Point(207, 3);
            this.cboDestinationStation.Name = "cboDestinationStation";
            this.cboDestinationStation.Size = new System.Drawing.Size(86, 20);
            this.cboDestinationStation.TabIndex = 10;
            this.cboDestinationStation.SelectedValueChanged += new System.EventHandler(this.cboDestinationStation_SelectedValueChanged);
            // 
            // labDepartureDate
            // 
            this.labDepartureDate.AutoSize = true;
            this.labDepartureDate.Location = new System.Drawing.Point(299, 0);
            this.labDepartureDate.Name = "labDepartureDate";
            this.labDepartureDate.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labDepartureDate.Size = new System.Drawing.Size(62, 23);
            this.labDepartureDate.TabIndex = 2;
            this.labDepartureDate.Text = "出发日期:";
            // 
            // dtpDepartureDate
            // 
            this.dtpDepartureDate.Location = new System.Drawing.Point(367, 3);
            this.dtpDepartureDate.Name = "dtpDepartureDate";
            this.dtpDepartureDate.Size = new System.Drawing.Size(111, 21);
            this.dtpDepartureDate.TabIndex = 4;
            // 
            // labDepartureTime
            // 
            this.labDepartureTime.AutoSize = true;
            this.labDepartureTime.Location = new System.Drawing.Point(484, 0);
            this.labDepartureTime.Name = "labDepartureTime";
            this.labDepartureTime.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labDepartureTime.Size = new System.Drawing.Size(62, 23);
            this.labDepartureTime.TabIndex = 5;
            this.labDepartureTime.Text = "出发时间:";
            // 
            // cboDepartureTime
            // 
            this.cboDepartureTime.FormattingEnabled = true;
            this.cboDepartureTime.Location = new System.Drawing.Point(552, 3);
            this.cboDepartureTime.Name = "cboDepartureTime";
            this.cboDepartureTime.Size = new System.Drawing.Size(121, 20);
            this.cboDepartureTime.TabIndex = 6;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(755, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(74, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // flpTrainType
            // 
            this.flpTrainType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrainType.Location = new System.Drawing.Point(0, 0);
            this.flpTrainType.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrainType.Name = "flpTrainType";
            this.flpTrainType.Size = new System.Drawing.Size(646, 30);
            this.flpTrainType.TabIndex = 2;
            // 
            // flpSeatTypies
            // 
            this.flpSeatTypies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSeatTypies.Location = new System.Drawing.Point(3, 111);
            this.flpSeatTypies.Margin = new System.Windows.Forms.Padding(0);
            this.flpSeatTypies.Name = "flpSeatTypies";
            this.flpSeatTypies.Size = new System.Drawing.Size(832, 30);
            this.flpSeatTypies.TabIndex = 3;
            // 
            // flpTrainPassType
            // 
            this.flpTrainPassType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrainPassType.Location = new System.Drawing.Point(646, 0);
            this.flpTrainPassType.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrainPassType.Name = "flpTrainPassType";
            this.flpTrainPassType.Size = new System.Drawing.Size(186, 30);
            this.flpTrainPassType.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labTicketInfo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(479, 30);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // labTicketInfo
            // 
            this.labTicketInfo.AutoSize = true;
            this.labTicketInfo.Location = new System.Drawing.Point(3, 0);
            this.labTicketInfo.Name = "labTicketInfo";
            this.labTicketInfo.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.labTicketInfo.Size = new System.Drawing.Size(6, 23);
            this.labTicketInfo.TabIndex = 0;
            // 
            // labMem
            // 
            this.labMem.AutoSize = true;
            this.labMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMem.Location = new System.Drawing.Point(482, 0);
            this.labMem.Name = "labMem";
            this.labMem.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.labMem.Size = new System.Drawing.Size(347, 30);
            this.labMem.TabIndex = 0;
            this.labMem.Text = "“--”代表无此席别 “无”代表票已售完 “有”代表票源充足 ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssVersion,
            this.tssAuthor});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(838, 22);
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssVersion
            // 
            this.tssVersion.Name = "tssVersion";
            this.tssVersion.Size = new System.Drawing.Size(35, 17);
            this.tssVersion.Text = "版本:";
            // 
            // tssAuthor
            // 
            this.tssAuthor.ForeColor = System.Drawing.Color.Blue;
            this.tssAuthor.Name = "tssAuthor";
            this.tssAuthor.Size = new System.Drawing.Size(757, 17);
            this.tssAuthor.Spring = true;
            this.tssAuthor.Text = "深圳市德广信息技术有限公司";
            this.tssAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssAuthor.Click += new System.EventHandler(this.tssAuthor_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tlpMain.Controls.Add(this.dgvTiketInfo, 0, 4);
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tlpMain.Controls.Add(this.flpSeatTypies, 0, 2);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(838, 500);
            this.tlpMain.TabIndex = 37;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.btnQuery, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpOptions1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMoreOption, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flpTrainNumber, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 66);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel2.Controls.Add(this.flpTrainType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flpTrainPassType, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 75);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(832, 30);
            this.tableLayoutPanel2.TabIndex = 39;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 353F));
            this.tableLayoutPanel3.Controls.Add(this.labMem, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 147);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(832, 30);
            this.tableLayoutPanel3.TabIndex = 40;
            // 
            // btnMoreOption
            // 
            this.btnMoreOption.Location = new System.Drawing.Point(755, 36);
            this.btnMoreOption.Name = "btnMoreOption";
            this.btnMoreOption.Size = new System.Drawing.Size(74, 24);
            this.btnMoreOption.TabIndex = 2;
            this.btnMoreOption.Text = "简单查询";
            this.btnMoreOption.UseVisualStyleBackColor = true;
            this.btnMoreOption.Click += new System.EventHandler(this.btnMoreOption_Click);
            // 
            // flpTrainNumber
            // 
            this.flpTrainNumber.Controls.Add(this.labTrainNumber);
            this.flpTrainNumber.Controls.Add(this.cboTrainNumber);
            this.flpTrainNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrainNumber.Location = new System.Drawing.Point(0, 33);
            this.flpTrainNumber.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrainNumber.Name = "flpTrainNumber";
            this.flpTrainNumber.Size = new System.Drawing.Size(752, 33);
            this.flpTrainNumber.TabIndex = 3;
            // 
            // labTrainNumber
            // 
            this.labTrainNumber.AutoSize = true;
            this.labTrainNumber.Location = new System.Drawing.Point(3, 0);
            this.labTrainNumber.Name = "labTrainNumber";
            this.labTrainNumber.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labTrainNumber.Size = new System.Drawing.Size(62, 23);
            this.labTrainNumber.TabIndex = 12;
            this.labTrainNumber.Text = "出发车次:";
            // 
            // cboTrainNumber
            // 
            this.cboTrainNumber.FormattingEnabled = true;
            this.cboTrainNumber.Location = new System.Drawing.Point(71, 3);
            this.cboTrainNumber.Name = "cboTrainNumber";
            this.cboTrainNumber.Size = new System.Drawing.Size(296, 20);
            this.cboTrainNumber.TabIndex = 13;
            this.cboTrainNumber.Enter += new System.EventHandler(this.cboTrainNumber_Enter);
            // 
            // dgvTiketInfo
            // 
            this.dgvTiketInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTiketInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiketInfo.Location = new System.Drawing.Point(3, 183);
            this.dgvTiketInfo.Name = "dgvTiketInfo";
            this.dgvTiketInfo.RowTemplate.Height = 23;
            this.dgvTiketInfo.Size = new System.Drawing.Size(832, 314);
            this.dgvTiketInfo.TabIndex = 11;
            // 
            // frmTicketQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 522);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTicketQuery";
            this.Text = "德广火车票助手-火车票查询";
            this.flpOptions1.ResumeLayout(false);
            this.flpOptions1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flpTrainNumber.ResumeLayout(false);
            this.flpTrainNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiketInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpOptions1;
        private System.Windows.Forms.Label labDepartureStation;
        private System.Windows.Forms.Label labDestinationStation;
        private System.Windows.Forms.Label labDepartureDate;
        private System.Windows.Forms.DateTimePicker dtpDepartureDate;
        private System.Windows.Forms.Label labDepartureTime;
        private System.Windows.Forms.ComboBox cboDepartureTime;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.FlowLayoutPanel flpTrainType;
        private System.Windows.Forms.ComboBox cboDepartureStation;
        private System.Windows.Forms.ComboBox cboDestinationStation;
        private DGDataGridView dgvTiketInfo;
        private System.Windows.Forms.FlowLayoutPanel flpSeatTypies;
        private System.Windows.Forms.FlowLayoutPanel flpTrainPassType;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labMem;
        private System.Windows.Forms.Label labTicketInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssVersion;
        private System.Windows.Forms.ToolStripStatusLabel tssAuthor;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnMoreOption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flpTrainNumber;
        private System.Windows.Forms.Label labTrainNumber;
        private System.Windows.Forms.ComboBox cboTrainNumber;
    }
}
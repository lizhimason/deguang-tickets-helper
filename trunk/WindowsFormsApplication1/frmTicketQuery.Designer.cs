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
            this.labTrainType = new System.Windows.Forms.Label();
            this.flpSeatTypies = new System.Windows.Forms.FlowLayoutPanel();
            this.labSeatTypies = new System.Windows.Forms.Label();
            this.flpTrainPassType = new System.Windows.Forms.FlowLayoutPanel();
            this.labTrainPassType = new System.Windows.Forms.Label();
            this.flpQueryResult = new System.Windows.Forms.FlowLayoutPanel();
            this.labTicketInfo = new System.Windows.Forms.Label();
            this.labMem = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssAuthor = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQueryResult = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTrainType = new System.Windows.Forms.TableLayoutPanel();
            this.tlpQueryOption = new System.Windows.Forms.TableLayoutPanel();
            this.btnMoreOption = new System.Windows.Forms.Button();
            this.flpTrainNumber = new System.Windows.Forms.FlowLayoutPanel();
            this.labTrainNumber = new System.Windows.Forms.Label();
            this.cboTrainNumber = new System.Windows.Forms.ComboBox();
            this.dgvTiketInfo = new DeGuangTicketsHelper.DGDataGridView();
            this.tlpPassenger = new System.Windows.Forms.TableLayoutPanel();
            this.flpPassenger = new System.Windows.Forms.FlowLayoutPanel();
            this.labPassenger = new System.Windows.Forms.Label();
            this.btnSubmitOrder = new System.Windows.Forms.Button();
            this.picVerificationCode = new System.Windows.Forms.PictureBox();
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.dgvOrder = new DeGuangTicketsHelper.DGDataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labTrainInfoLab = new System.Windows.Forms.Label();
            this.rtbTrainInfo = new System.Windows.Forms.RichTextBox();
            this.flpOptions1.SuspendLayout();
            this.flpTrainType.SuspendLayout();
            this.flpSeatTypies.SuspendLayout();
            this.flpTrainPassType.SuspendLayout();
            this.flpQueryResult.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpQueryResult.SuspendLayout();
            this.tlpTrainType.SuspendLayout();
            this.tlpQueryOption.SuspendLayout();
            this.flpTrainNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiketInfo)).BeginInit();
            this.tlpPassenger.SuspendLayout();
            this.flpPassenger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerificationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.flpOptions1.Size = new System.Drawing.Size(758, 28);
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
            this.btnQuery.Location = new System.Drawing.Point(761, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(74, 22);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // flpTrainType
            // 
            this.flpTrainType.Controls.Add(this.labTrainType);
            this.flpTrainType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrainType.Location = new System.Drawing.Point(0, 0);
            this.flpTrainType.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrainType.Name = "flpTrainType";
            this.flpTrainType.Size = new System.Drawing.Size(584, 28);
            this.flpTrainType.TabIndex = 2;
            // 
            // labTrainType
            // 
            this.labTrainType.AutoSize = true;
            this.labTrainType.Location = new System.Drawing.Point(3, 0);
            this.labTrainType.Name = "labTrainType";
            this.labTrainType.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labTrainType.Size = new System.Drawing.Size(62, 23);
            this.labTrainType.TabIndex = 5;
            this.labTrainType.Text = "火车类型:";
            // 
            // flpSeatTypies
            // 
            this.flpSeatTypies.Controls.Add(this.labSeatTypies);
            this.flpSeatTypies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSeatTypies.Location = new System.Drawing.Point(0, 84);
            this.flpSeatTypies.Margin = new System.Windows.Forms.Padding(0);
            this.flpSeatTypies.Name = "flpSeatTypies";
            this.flpSeatTypies.Size = new System.Drawing.Size(838, 28);
            this.flpSeatTypies.TabIndex = 3;
            // 
            // labSeatTypies
            // 
            this.labSeatTypies.AutoSize = true;
            this.labSeatTypies.Location = new System.Drawing.Point(3, 0);
            this.labSeatTypies.Name = "labSeatTypies";
            this.labSeatTypies.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labSeatTypies.Size = new System.Drawing.Size(62, 23);
            this.labSeatTypies.TabIndex = 5;
            this.labSeatTypies.Text = "座位类型:";
            // 
            // flpTrainPassType
            // 
            this.flpTrainPassType.Controls.Add(this.labTrainPassType);
            this.flpTrainPassType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTrainPassType.Location = new System.Drawing.Point(584, 0);
            this.flpTrainPassType.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrainPassType.Name = "flpTrainPassType";
            this.flpTrainPassType.Size = new System.Drawing.Size(254, 28);
            this.flpTrainPassType.TabIndex = 12;
            // 
            // labTrainPassType
            // 
            this.labTrainPassType.AutoSize = true;
            this.labTrainPassType.Location = new System.Drawing.Point(3, 0);
            this.labTrainPassType.Name = "labTrainPassType";
            this.labTrainPassType.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labTrainPassType.Size = new System.Drawing.Size(68, 23);
            this.labTrainPassType.TabIndex = 5;
            this.labTrainPassType.Text = "始发/经过:";
            // 
            // flpQueryResult
            // 
            this.flpQueryResult.Controls.Add(this.labTicketInfo);
            this.flpQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpQueryResult.Location = new System.Drawing.Point(0, 0);
            this.flpQueryResult.Margin = new System.Windows.Forms.Padding(0);
            this.flpQueryResult.Name = "flpQueryResult";
            this.flpQueryResult.Size = new System.Drawing.Size(485, 28);
            this.flpQueryResult.TabIndex = 13;
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
            this.labMem.Location = new System.Drawing.Point(488, 0);
            this.labMem.Name = "labMem";
            this.labMem.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.labMem.Size = new System.Drawing.Size(347, 28);
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
            this.tssAuthor.Size = new System.Drawing.Size(788, 17);
            this.tssAuthor.Spring = true;
            this.tssAuthor.Text = "深圳市德广信息技术有限公司";
            this.tssAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssAuthor.Click += new System.EventHandler(this.tssAuthor_Click);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpQueryResult, 0, 6);
            this.tlpMain.Controls.Add(this.tlpTrainType, 0, 1);
            this.tlpMain.Controls.Add(this.flpSeatTypies, 0, 2);
            this.tlpMain.Controls.Add(this.tlpQueryOption, 0, 0);
            this.tlpMain.Controls.Add(this.dgvTiketInfo, 0, 7);
            this.tlpMain.Controls.Add(this.tlpPassenger, 0, 4);
            this.tlpMain.Controls.Add(this.dgvOrder, 0, 5);
            this.tlpMain.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 8;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(838, 500);
            this.tlpMain.TabIndex = 37;
            // 
            // tlpQueryResult
            // 
            this.tlpQueryResult.ColumnCount = 2;
            this.tlpQueryResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueryResult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 353F));
            this.tlpQueryResult.Controls.Add(this.labMem, 1, 0);
            this.tlpQueryResult.Controls.Add(this.flpQueryResult, 0, 0);
            this.tlpQueryResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQueryResult.Location = new System.Drawing.Point(0, 228);
            this.tlpQueryResult.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQueryResult.Name = "tlpQueryResult";
            this.tlpQueryResult.RowCount = 1;
            this.tlpQueryResult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueryResult.Size = new System.Drawing.Size(838, 28);
            this.tlpQueryResult.TabIndex = 40;
            // 
            // tlpTrainType
            // 
            this.tlpTrainType.ColumnCount = 2;
            this.tlpTrainType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrainType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 254F));
            this.tlpTrainType.Controls.Add(this.flpTrainType, 0, 0);
            this.tlpTrainType.Controls.Add(this.flpTrainPassType, 1, 0);
            this.tlpTrainType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrainType.Location = new System.Drawing.Point(0, 56);
            this.tlpTrainType.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTrainType.Name = "tlpTrainType";
            this.tlpTrainType.RowCount = 1;
            this.tlpTrainType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrainType.Size = new System.Drawing.Size(838, 28);
            this.tlpTrainType.TabIndex = 39;
            // 
            // tlpQueryOption
            // 
            this.tlpQueryOption.ColumnCount = 2;
            this.tlpQueryOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpQueryOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpQueryOption.Controls.Add(this.btnQuery, 1, 0);
            this.tlpQueryOption.Controls.Add(this.flpOptions1, 0, 0);
            this.tlpQueryOption.Controls.Add(this.btnMoreOption, 1, 1);
            this.tlpQueryOption.Controls.Add(this.flpTrainNumber, 0, 1);
            this.tlpQueryOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpQueryOption.Location = new System.Drawing.Point(0, 0);
            this.tlpQueryOption.Margin = new System.Windows.Forms.Padding(0);
            this.tlpQueryOption.Name = "tlpQueryOption";
            this.tlpQueryOption.RowCount = 2;
            this.tlpQueryOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQueryOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpQueryOption.Size = new System.Drawing.Size(838, 56);
            this.tlpQueryOption.TabIndex = 38;
            // 
            // btnMoreOption
            // 
            this.btnMoreOption.Location = new System.Drawing.Point(761, 31);
            this.btnMoreOption.Name = "btnMoreOption";
            this.btnMoreOption.Size = new System.Drawing.Size(74, 22);
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
            this.flpTrainNumber.Location = new System.Drawing.Point(0, 28);
            this.flpTrainNumber.Margin = new System.Windows.Forms.Padding(0);
            this.flpTrainNumber.Name = "flpTrainNumber";
            this.flpTrainNumber.Size = new System.Drawing.Size(758, 28);
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
            this.dgvTiketInfo.Location = new System.Drawing.Point(3, 259);
            this.dgvTiketInfo.Name = "dgvTiketInfo";
            this.dgvTiketInfo.RowTemplate.Height = 23;
            this.dgvTiketInfo.Size = new System.Drawing.Size(832, 238);
            this.dgvTiketInfo.TabIndex = 11;
            this.dgvTiketInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiketInfo_CellDoubleClick);
            // 
            // tlpPassenger
            // 
            this.tlpPassenger.ColumnCount = 4;
            this.tlpPassenger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPassenger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpPassenger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpPassenger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpPassenger.Controls.Add(this.flpPassenger, 0, 0);
            this.tlpPassenger.Controls.Add(this.btnSubmitOrder, 3, 0);
            this.tlpPassenger.Controls.Add(this.picVerificationCode, 1, 0);
            this.tlpPassenger.Controls.Add(this.txtVerificationCode, 2, 0);
            this.tlpPassenger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPassenger.Location = new System.Drawing.Point(0, 140);
            this.tlpPassenger.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPassenger.Name = "tlpPassenger";
            this.tlpPassenger.RowCount = 1;
            this.tlpPassenger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPassenger.Size = new System.Drawing.Size(838, 28);
            this.tlpPassenger.TabIndex = 41;
            // 
            // flpPassenger
            // 
            this.flpPassenger.Controls.Add(this.labPassenger);
            this.flpPassenger.Location = new System.Drawing.Point(0, 0);
            this.flpPassenger.Margin = new System.Windows.Forms.Padding(0);
            this.flpPassenger.Name = "flpPassenger";
            this.flpPassenger.Size = new System.Drawing.Size(598, 28);
            this.flpPassenger.TabIndex = 42;
            // 
            // labPassenger
            // 
            this.labPassenger.AutoSize = true;
            this.labPassenger.Location = new System.Drawing.Point(3, 0);
            this.labPassenger.Name = "labPassenger";
            this.labPassenger.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labPassenger.Size = new System.Drawing.Size(38, 23);
            this.labPassenger.TabIndex = 5;
            this.labPassenger.Text = "乘客:";
            // 
            // btnSubmitOrder
            // 
            this.btnSubmitOrder.Location = new System.Drawing.Point(761, 3);
            this.btnSubmitOrder.Name = "btnSubmitOrder";
            this.btnSubmitOrder.Size = new System.Drawing.Size(74, 22);
            this.btnSubmitOrder.TabIndex = 43;
            this.btnSubmitOrder.Text = "提交订单";
            this.btnSubmitOrder.UseVisualStyleBackColor = true;
            this.btnSubmitOrder.Click += new System.EventHandler(this.btnSubmitOrder_Click);
            // 
            // picVerificationCode
            // 
            this.picVerificationCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVerificationCode.Location = new System.Drawing.Point(598, 0);
            this.picVerificationCode.Margin = new System.Windows.Forms.Padding(0);
            this.picVerificationCode.Name = "picVerificationCode";
            this.picVerificationCode.Size = new System.Drawing.Size(80, 28);
            this.picVerificationCode.TabIndex = 44;
            this.picVerificationCode.TabStop = false;
            this.picVerificationCode.Click += new System.EventHandler(this.picVerificationCode_Click);
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVerificationCode.Location = new System.Drawing.Point(678, 3);
            this.txtVerificationCode.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.Size = new System.Drawing.Size(80, 21);
            this.txtVerificationCode.TabIndex = 45;
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.Location = new System.Drawing.Point(3, 171);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.Size = new System.Drawing.Size(832, 54);
            this.dgvOrder.TabIndex = 42;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labTrainInfoLab);
            this.flowLayoutPanel1.Controls.Add(this.rtbTrainInfo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 112);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(838, 28);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // labTrainInfoLab
            // 
            this.labTrainInfoLab.AutoSize = true;
            this.labTrainInfoLab.Location = new System.Drawing.Point(3, 0);
            this.labTrainInfoLab.Name = "labTrainInfoLab";
            this.labTrainInfoLab.Padding = new System.Windows.Forms.Padding(0, 8, 3, 3);
            this.labTrainInfoLab.Size = new System.Drawing.Size(62, 23);
            this.labTrainInfoLab.TabIndex = 5;
            this.labTrainInfoLab.Text = "列车信息:";
            // 
            // rtbTrainInfo
            // 
            this.rtbTrainInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTrainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTrainInfo.Location = new System.Drawing.Point(71, 3);
            this.rtbTrainInfo.Name = "rtbTrainInfo";
            this.rtbTrainInfo.ReadOnly = true;
            this.rtbTrainInfo.Size = new System.Drawing.Size(764, 17);
            this.rtbTrainInfo.TabIndex = 6;
            this.rtbTrainInfo.Text = "";
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
            this.flpTrainType.ResumeLayout(false);
            this.flpTrainType.PerformLayout();
            this.flpSeatTypies.ResumeLayout(false);
            this.flpSeatTypies.PerformLayout();
            this.flpTrainPassType.ResumeLayout(false);
            this.flpTrainPassType.PerformLayout();
            this.flpQueryResult.ResumeLayout(false);
            this.flpQueryResult.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpQueryResult.ResumeLayout(false);
            this.tlpQueryResult.PerformLayout();
            this.tlpTrainType.ResumeLayout(false);
            this.tlpQueryOption.ResumeLayout(false);
            this.flpTrainNumber.ResumeLayout(false);
            this.flpTrainNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiketInfo)).EndInit();
            this.tlpPassenger.ResumeLayout(false);
            this.tlpPassenger.PerformLayout();
            this.flpPassenger.ResumeLayout(false);
            this.flpPassenger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVerificationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flpQueryResult;
        private System.Windows.Forms.Label labMem;
        private System.Windows.Forms.Label labTicketInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssVersion;
        private System.Windows.Forms.ToolStripStatusLabel tssAuthor;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpQueryOption;
        private System.Windows.Forms.TableLayoutPanel tlpTrainType;
        private System.Windows.Forms.Button btnMoreOption;
        private System.Windows.Forms.TableLayoutPanel tlpQueryResult;
        private System.Windows.Forms.FlowLayoutPanel flpTrainNumber;
        private System.Windows.Forms.Label labTrainNumber;
        private System.Windows.Forms.ComboBox cboTrainNumber;
        private System.Windows.Forms.Label labTrainType;
        private System.Windows.Forms.Label labSeatTypies;
        private System.Windows.Forms.Label labTrainPassType;
        private System.Windows.Forms.TableLayoutPanel tlpPassenger;
        private System.Windows.Forms.FlowLayoutPanel flpPassenger;
        private System.Windows.Forms.Label labPassenger;
        private System.Windows.Forms.Button btnSubmitOrder;
        private System.Windows.Forms.PictureBox picVerificationCode;
        private System.Windows.Forms.TextBox txtVerificationCode;
        private DGDataGridView dgvOrder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labTrainInfoLab;
        private System.Windows.Forms.RichTextBox rtbTrainInfo;
    }
}
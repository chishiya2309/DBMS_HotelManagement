namespace QLKS
{
    partial class FormQuanLyPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.searchPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.cbStatusSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblStatusSearch = new System.Windows.Forms.Label();
            this.roomInfoPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoomInfo = new System.Windows.Forms.Label();
            this.txtMaPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTenPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblRoomStatus = new System.Windows.Forms.Label();
            this.cbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.roomTypePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoomTypeInfo = new System.Windows.Forms.Label();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLimit = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.functionsPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnInsert = new Guna.UI2.WinForms.Guna2Button();
            this.dataPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRoom = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMaLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGiuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiGiuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhuVuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SucChua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewImageColumn();
            this.headerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.roomInfoPanel.SuspendLayout();
            this.roomTypePanel.SuspendLayout();
            this.functionsPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.ShadowDecoration.Parent = this.headerPanel;
            this.headerPanel.Size = new System.Drawing.Size(861, 60);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "QUẢN LÝ PHÒNG";
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.searchPanel.BorderRadius = 10;
            this.searchPanel.BorderThickness = 1;
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.cbStatusSearch);
            this.searchPanel.Controls.Add(this.lblStatusSearch);
            this.searchPanel.Location = new System.Drawing.Point(12, 70);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.ShadowDecoration.Parent = this.searchPanel;
            this.searchPanel.Size = new System.Drawing.Size(408, 80);
            this.searchPanel.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 10;
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Location = new System.Drawing.Point(261, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(130, 40);
            this.btnSearch.TabIndex = 49;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbStatusSearch
            // 
            this.cbStatusSearch.BackColor = System.Drawing.Color.Transparent;
            this.cbStatusSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.cbStatusSearch.BorderRadius = 5;
            this.cbStatusSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbStatusSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbStatusSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbStatusSearch.FocusedState.Parent = this.cbStatusSearch;
            this.cbStatusSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStatusSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.cbStatusSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbStatusSearch.HoverState.Parent = this.cbStatusSearch;
            this.cbStatusSearch.ItemHeight = 30;
            this.cbStatusSearch.Items.AddRange(new object[] {
            "Trống",
            "Đang cho thuê",
            "Đang sửa",
            "Tất cả"});
            this.cbStatusSearch.ItemsAppearance.Parent = this.cbStatusSearch;
            this.cbStatusSearch.Location = new System.Drawing.Point(16, 30);
            this.cbStatusSearch.Name = "cbStatusSearch";
            this.cbStatusSearch.ShadowDecoration.Parent = this.cbStatusSearch;
            this.cbStatusSearch.Size = new System.Drawing.Size(220, 36);
            this.cbStatusSearch.TabIndex = 48;
            this.cbStatusSearch.SelectedIndexChanged += new System.EventHandler(this.cbStatusSearch_SelectedIndexChanged);
            // 
            // lblStatusSearch
            // 
            this.lblStatusSearch.AutoSize = true;
            this.lblStatusSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblStatusSearch.Location = new System.Drawing.Point(12, 10);
            this.lblStatusSearch.Name = "lblStatusSearch";
            this.lblStatusSearch.Size = new System.Drawing.Size(80, 19);
            this.lblStatusSearch.TabIndex = 47;
            this.lblStatusSearch.Text = "Trạng thái:";
            // 
            // roomInfoPanel
            // 
            this.roomInfoPanel.BackColor = System.Drawing.Color.White;
            this.roomInfoPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.roomInfoPanel.BorderRadius = 10;
            this.roomInfoPanel.BorderThickness = 1;
            this.roomInfoPanel.Controls.Add(this.lblRoomInfo);
            this.roomInfoPanel.Controls.Add(this.txtMaPhong);
            this.roomInfoPanel.Controls.Add(this.txtTenPhong);
            this.roomInfoPanel.Controls.Add(this.lblRoomName);
            this.roomInfoPanel.Controls.Add(this.lblRoomStatus);
            this.roomInfoPanel.Controls.Add(this.cbStatus);
            this.roomInfoPanel.Controls.Add(this.lblRoomCode);
            this.roomInfoPanel.Location = new System.Drawing.Point(12, 160);
            this.roomInfoPanel.Name = "roomInfoPanel";
            this.roomInfoPanel.ShadowDecoration.Parent = this.roomInfoPanel;
            this.roomInfoPanel.Size = new System.Drawing.Size(200, 240);
            this.roomInfoPanel.TabIndex = 2;
            // 
            // lblRoomInfo
            // 
            this.lblRoomInfo.AutoSize = true;
            this.lblRoomInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblRoomInfo.Location = new System.Drawing.Point(12, 10);
            this.lblRoomInfo.Name = "lblRoomInfo";
            this.lblRoomInfo.Size = new System.Drawing.Size(160, 21);
            this.lblRoomInfo.TabIndex = 58;
            this.lblRoomInfo.Text = "THÔNG TIN PHÒNG";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtMaPhong.BorderRadius = 5;
            this.txtMaPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaPhong.DefaultText = "";
            this.txtMaPhong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaPhong.DisabledState.Parent = this.txtMaPhong;
            this.txtMaPhong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtMaPhong.FocusedState.Parent = this.txtMaPhong;
            this.txtMaPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMaPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtMaPhong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtMaPhong.HoverState.Parent = this.txtMaPhong;
            this.txtMaPhong.Location = new System.Drawing.Point(16, 60);
            this.txtMaPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.PasswordChar = '\0';
            this.txtMaPhong.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtMaPhong.PlaceholderText = "Nhập mã phòng";
            this.txtMaPhong.SelectedText = "";
            this.txtMaPhong.ShadowDecoration.Parent = this.txtMaPhong;
            this.txtMaPhong.Size = new System.Drawing.Size(170, 36);
            this.txtMaPhong.TabIndex = 57;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtTenPhong.BorderRadius = 5;
            this.txtTenPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenPhong.DefaultText = "";
            this.txtTenPhong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenPhong.DisabledState.Parent = this.txtTenPhong;
            this.txtTenPhong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtTenPhong.FocusedState.Parent = this.txtTenPhong;
            this.txtTenPhong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtTenPhong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtTenPhong.HoverState.Parent = this.txtTenPhong;
            this.txtTenPhong.Location = new System.Drawing.Point(16, 120);
            this.txtTenPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.PasswordChar = '\0';
            this.txtTenPhong.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtTenPhong.PlaceholderText = "Nhập tên phòng";
            this.txtTenPhong.SelectedText = "";
            this.txtTenPhong.ShadowDecoration.Parent = this.txtTenPhong;
            this.txtTenPhong.Size = new System.Drawing.Size(170, 36);
            this.txtTenPhong.TabIndex = 56;
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblRoomName.Location = new System.Drawing.Point(12, 100);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(83, 19);
            this.lblRoomName.TabIndex = 55;
            this.lblRoomName.Text = "Tên phòng:";
            // 
            // lblRoomStatus
            // 
            this.lblRoomStatus.AutoSize = true;
            this.lblRoomStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblRoomStatus.Location = new System.Drawing.Point(12, 160);
            this.lblRoomStatus.Name = "lblRoomStatus";
            this.lblRoomStatus.Size = new System.Drawing.Size(80, 19);
            this.lblRoomStatus.TabIndex = 53;
            this.lblRoomStatus.Text = "Trạng thái:";
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.cbStatus.BorderRadius = 5;
            this.cbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbStatus.FocusedState.Parent = this.cbStatus;
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.cbStatus.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbStatus.HoverState.Parent = this.cbStatus;
            this.cbStatus.ItemHeight = 30;
            this.cbStatus.Items.AddRange(new object[] {
            "Trống",
            "Đang cho thuê",
            "Đang sửa"});
            this.cbStatus.ItemsAppearance.Parent = this.cbStatus;
            this.cbStatus.Location = new System.Drawing.Point(16, 180);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.ShadowDecoration.Parent = this.cbStatus;
            this.cbStatus.Size = new System.Drawing.Size(170, 36);
            this.cbStatus.TabIndex = 54;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblRoomCode.Location = new System.Drawing.Point(12, 40);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(81, 19);
            this.lblRoomCode.TabIndex = 51;
            this.lblRoomCode.Text = "Mã phòng:";
            // 
            // roomTypePanel
            // 
            this.roomTypePanel.BackColor = System.Drawing.Color.White;
            this.roomTypePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.roomTypePanel.BorderRadius = 10;
            this.roomTypePanel.BorderThickness = 1;
            this.roomTypePanel.Controls.Add(this.lblRoomTypeInfo);
            this.roomTypePanel.Controls.Add(this.txtPrice);
            this.roomTypePanel.Controls.Add(this.txtLimit);
            this.roomTypePanel.Controls.Add(this.lblCapacity);
            this.roomTypePanel.Controls.Add(this.lblPrice);
            this.roomTypePanel.Controls.Add(this.cbType);
            this.roomTypePanel.Controls.Add(this.lblRoomType);
            this.roomTypePanel.Location = new System.Drawing.Point(220, 160);
            this.roomTypePanel.Name = "roomTypePanel";
            this.roomTypePanel.ShadowDecoration.Parent = this.roomTypePanel;
            this.roomTypePanel.Size = new System.Drawing.Size(200, 240);
            this.roomTypePanel.TabIndex = 3;
            // 
            // lblRoomTypeInfo
            // 
            this.lblRoomTypeInfo.AutoSize = true;
            this.lblRoomTypeInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomTypeInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblRoomTypeInfo.Location = new System.Drawing.Point(0, 10);
            this.lblRoomTypeInfo.Name = "lblRoomTypeInfo";
            this.lblRoomTypeInfo.Size = new System.Drawing.Size(200, 21);
            this.lblRoomTypeInfo.TabIndex = 59;
            this.lblRoomTypeInfo.Text = "THÔNG TIN LOẠI PHÒNG";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtPrice.BorderRadius = 5;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.DisabledState.Parent = this.txtPrice;
            this.txtPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtPrice.FocusedState.Parent = this.txtPrice;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtPrice.HoverState.Parent = this.txtPrice;
            this.txtPrice.Location = new System.Drawing.Point(16, 180);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPrice.PlaceholderText = "Nhập giá phòng";
            this.txtPrice.SelectedText = "";
            this.txtPrice.ShadowDecoration.Parent = this.txtPrice;
            this.txtPrice.Size = new System.Drawing.Size(170, 36);
            this.txtPrice.TabIndex = 57;
            // 
            // txtLimit
            // 
            this.txtLimit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtLimit.BorderRadius = 5;
            this.txtLimit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLimit.DefaultText = "";
            this.txtLimit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLimit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLimit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLimit.DisabledState.Parent = this.txtLimit;
            this.txtLimit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLimit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtLimit.FocusedState.Parent = this.txtLimit;
            this.txtLimit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtLimit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.txtLimit.HoverState.Parent = this.txtLimit;
            this.txtLimit.Location = new System.Drawing.Point(16, 120);
            this.txtLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.PasswordChar = '\0';
            this.txtLimit.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtLimit.PlaceholderText = "Nhập sức chứa";
            this.txtLimit.SelectedText = "";
            this.txtLimit.ShadowDecoration.Parent = this.txtLimit;
            this.txtLimit.Size = new System.Drawing.Size(170, 36);
            this.txtLimit.TabIndex = 56;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblCapacity.Location = new System.Drawing.Point(12, 100);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(73, 19);
            this.lblCapacity.TabIndex = 55;
            this.lblCapacity.Text = "Sức chứa:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblPrice.Location = new System.Drawing.Point(12, 160);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 19);
            this.lblPrice.TabIndex = 53;
            this.lblPrice.Text = "Giá:";
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Transparent;
            this.cbType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.cbType.BorderRadius = 5;
            this.cbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbType.FocusedState.Parent = this.cbType;
            this.cbType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.cbType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.cbType.HoverState.Parent = this.cbType;
            this.cbType.ItemHeight = 30;
            this.cbType.ItemsAppearance.Parent = this.cbType;
            this.cbType.Location = new System.Drawing.Point(16, 60);
            this.cbType.Name = "cbType";
            this.cbType.ShadowDecoration.Parent = this.cbType;
            this.cbType.Size = new System.Drawing.Size(170, 36);
            this.cbType.TabIndex = 54;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lblRoomType.Location = new System.Drawing.Point(12, 40);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(88, 19);
            this.lblRoomType.TabIndex = 51;
            this.lblRoomType.Text = "Loại phòng:";
            // 
            // functionsPanel
            // 
            this.functionsPanel.BackColor = System.Drawing.Color.White;
            this.functionsPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.functionsPanel.BorderRadius = 10;
            this.functionsPanel.BorderThickness = 1;
            this.functionsPanel.Controls.Add(this.btnClose);
            this.functionsPanel.Controls.Add(this.btnDelete);
            this.functionsPanel.Controls.Add(this.btnUpdate);
            this.functionsPanel.Controls.Add(this.btnInsert);
            this.functionsPanel.Location = new System.Drawing.Point(12, 410);
            this.functionsPanel.Name = "functionsPanel";
            this.functionsPanel.ShadowDecoration.Parent = this.functionsPanel;
            this.functionsPanel.Size = new System.Drawing.Size(408, 90);
            this.functionsPanel.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 10;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Gray;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(308, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(90, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.guna2CircleButton3_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Location = new System.Drawing.Point(208, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.guna2CircleButton5_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BorderRadius = 10;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Location = new System.Drawing.Point(108, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(90, 40);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BorderRadius = 10;
            this.btnInsert.CheckedState.Parent = this.btnInsert;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.CustomImages.Parent = this.btnInsert;
            this.btnInsert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInsert.ForeColor = System.Drawing.Color.White;
            this.btnInsert.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            this.btnInsert.HoverState.Parent = this.btnInsert;
            this.btnInsert.Location = new System.Drawing.Point(8, 25);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.ShadowDecoration.Parent = this.btnInsert;
            this.btnInsert.Size = new System.Drawing.Size(90, 40);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Thêm";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.White;
            this.dataPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.dataPanel.BorderRadius = 10;
            this.dataPanel.BorderThickness = 1;
            this.dataPanel.Controls.Add(this.dgvRoom);
            this.dataPanel.Location = new System.Drawing.Point(430, 70);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.ShadowDecoration.Parent = this.dataPanel;
            this.dataPanel.Size = new System.Drawing.Size(422, 430);
            this.dataPanel.TabIndex = 5;
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.AllowUserToResizeColumns = false;
            this.dgvRoom.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRoom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(90)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRoom.ColumnHeadersHeight = 30;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.dgvMaLoaiPhong,
            this.TenPhong,
            this.SoGiuong,
            this.LoaiGiuong,
            this.KhuVuc,
            this.TrangThai,
            this.TenLoaiPhong,
            this.SucChua,
            this.DonGia,
            this.HinhAnh});
            this.dgvRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoom.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRoom.EnableHeadersVisualStyles = false;
            this.dgvRoom.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvRoom.Location = new System.Drawing.Point(10, 10);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.RowHeadersVisible = false;
            this.dgvRoom.RowHeadersWidth = 123;
            this.dgvRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRoom.RowTemplate.Height = 25;
            this.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoom.Size = new System.Drawing.Size(402, 410);
            this.dgvRoom.TabIndex = 31;
            this.dgvRoom.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvRoom.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRoom.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRoom.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRoom.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.dgvRoom.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRoom.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRoom.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvRoom.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.dgvRoom.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRoom.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvRoom.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRoom.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoom.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvRoom.ThemeStyle.ReadOnly = true;
            this.dgvRoom.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRoom.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRoom.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvRoom.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvRoom.ThemeStyle.RowsStyle.Height = 25;
            this.dgvRoom.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.dgvRoom.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoom_CellContentClick);
            this.dgvRoom.SelectionChanged += new System.EventHandler(this.dgvRoom_SelectionChanged);
            // 
            // MaPhong
            // 
            this.MaPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.FillWeight = 123F;
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.MinimumWidth = 45;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            // 
            // dgvMaLoaiPhong
            // 
            this.dgvMaLoaiPhong.DataPropertyName = "MaLoaiPhong";
            this.dgvMaLoaiPhong.HeaderText = "Mã loại phòng";
            this.dgvMaLoaiPhong.Name = "dgvMaLoaiPhong";
            this.dgvMaLoaiPhong.ReadOnly = true;
            this.dgvMaLoaiPhong.Visible = false;
            // 
            // TenPhong
            // 
            this.TenPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên phòng";
            this.TenPhong.MinimumWidth = 6;
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.ReadOnly = true;
            this.TenPhong.Width = 102;
            // 
            // SoGiuong
            // 
            this.SoGiuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoGiuong.DataPropertyName = "SoGiuong";
            this.SoGiuong.HeaderText = "Số giường";
            this.SoGiuong.MinimumWidth = 10;
            this.SoGiuong.Name = "SoGiuong";
            this.SoGiuong.ReadOnly = true;
            this.SoGiuong.Width = 101;
            // 
            // LoaiGiuong
            // 
            this.LoaiGiuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LoaiGiuong.DataPropertyName = "LoaiGiuong";
            this.LoaiGiuong.HeaderText = "Loại giường";
            this.LoaiGiuong.MinimumWidth = 10;
            this.LoaiGiuong.Name = "LoaiGiuong";
            this.LoaiGiuong.ReadOnly = true;
            this.LoaiGiuong.Width = 112;
            // 
            // KhuVuc
            // 
            this.KhuVuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KhuVuc.DataPropertyName = "KhuVuc";
            this.KhuVuc.HeaderText = "Khu vực";
            this.KhuVuc.Name = "KhuVuc";
            this.KhuVuc.ReadOnly = true;
            this.KhuVuc.Width = 85;
            // 
            // TrangThai
            // 
            this.TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 10;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 99;
            // 
            // TenLoaiPhong
            // 
            this.TenLoaiPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenLoaiPhong.DataPropertyName = "TenLoaiPhong";
            this.TenLoaiPhong.HeaderText = "Loại phòng";
            this.TenLoaiPhong.Name = "TenLoaiPhong";
            this.TenLoaiPhong.ReadOnly = true;
            this.TenLoaiPhong.Width = 107;
            // 
            // SucChua
            // 
            this.SucChua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SucChua.DataPropertyName = "SucChua";
            this.SucChua.HeaderText = "Sức chứa";
            this.SucChua.Name = "SucChua";
            this.SucChua.ReadOnly = true;
            this.SucChua.Width = 92;
            // 
            // DonGia
            // 
            this.DonGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DonGia.DataPropertyName = "DonGia";
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            this.DonGia.Width = 84;
            // 
            // HinhAnh
            // 
            this.HinhAnh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HinhAnh.DataPropertyName = "HinhAnh";
            this.HinhAnh.HeaderText = "Hình ảnh";
            this.HinhAnh.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.ReadOnly = true;
            this.HinhAnh.Width = 72;
            // 
            // FormQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(861, 519);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.functionsPanel);
            this.Controls.Add(this.roomTypePanel);
            this.Controls.Add(this.roomInfoPanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.headerPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(877, 558);
            this.Name = "FormQuanLyPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng khách sạn";
            this.Load += new System.EventHandler(this.FormQuanLyPhong_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.roomInfoPanel.ResumeLayout(false);
            this.roomInfoPanel.PerformLayout();
            this.roomTypePanel.ResumeLayout(false);
            this.roomTypePanel.PerformLayout();
            this.functionsPanel.ResumeLayout(false);
            this.dataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel searchPanel;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatusSearch;
        private System.Windows.Forms.Label lblStatusSearch;
        private Guna.UI2.WinForms.Guna2Panel roomInfoPanel;
        private System.Windows.Forms.Label lblRoomInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtMaPhong;
        private Guna.UI2.WinForms.Guna2TextBox txtTenPhong;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblRoomStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatus;
        private System.Windows.Forms.Label lblRoomCode;
        private Guna.UI2.WinForms.Guna2Panel roomTypePanel;
        private System.Windows.Forms.Label lblRoomTypeInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtLimit;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblPrice;
        private Guna.UI2.WinForms.Guna2ComboBox cbType;
        private System.Windows.Forms.Label lblRoomType;
        private Guna.UI2.WinForms.Guna2Panel functionsPanel;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnInsert;
        private Guna.UI2.WinForms.Guna2Panel dataPanel;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMaLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGiuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiGiuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhuVuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SucChua;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewImageColumn HinhAnh;
    }
}
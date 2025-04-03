namespace QLKS
{
    partial class FormQuanLyHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLyHoaDon));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2CircleButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpCreate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdBill = new System.Windows.Forms.TextBox();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnDetail = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.dgvBill = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvMaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgayLapHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTinhTrangThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPhuongThucThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNoiDungPhuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMaHoSoDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 31);
            this.label1.TabIndex = 35;
            this.label1.Text = "Quản lý hóa đơn";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Controls.Add(this.btnSearch);
            this.guna2GroupBox1.Controls.Add(this.txtSearch);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox1.Location = new System.Drawing.Point(10, 42);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(361, 99);
            this.guna2GroupBox1.TabIndex = 36;
            this.guna2GroupBox1.Text = "Tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderColor = System.Drawing.Color.Silver;
            this.btnSearch.BorderThickness = 1;
            this.btnSearch.CheckedState.Parent = this.btnSearch;
            this.btnSearch.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnSearch.CustomImages.Parent = this.btnSearch;
            this.btnSearch.FillColor = System.Drawing.Color.Transparent;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSearch.HoverState.Parent = this.btnSearch;
            this.btnSearch.Location = new System.Drawing.Point(212, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(100, 39);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSearch.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSearch.Location = new System.Drawing.Point(7, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(127, 29);
            this.txtSearch.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã đặt phòng:";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox2.Controls.Add(this.txtTotal);
            this.guna2GroupBox2.Controls.Add(this.label2);
            this.guna2GroupBox2.Controls.Add(this.cbStatus);
            this.guna2GroupBox2.Controls.Add(this.label13);
            this.guna2GroupBox2.Controls.Add(this.dtpCreate);
            this.guna2GroupBox2.Controls.Add(this.label12);
            this.guna2GroupBox2.Controls.Add(this.txtStaffName);
            this.guna2GroupBox2.Controls.Add(this.label11);
            this.guna2GroupBox2.Controls.Add(this.txtRoomName);
            this.guna2GroupBox2.Controls.Add(this.label10);
            this.guna2GroupBox2.Controls.Add(this.label9);
            this.guna2GroupBox2.Controls.Add(this.txtIdBill);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox2.Location = new System.Drawing.Point(10, 148);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(361, 218);
            this.guna2GroupBox2.TabIndex = 37;
            this.guna2GroupBox2.Text = "Thông tin hóa đơn";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTotal.Location = new System.Drawing.Point(186, 176);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(142, 29);
            this.txtTotal.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(186, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Trạng thái:";
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Chưa Thanh Toán",
            "Đã Thanh Toán"});
            this.cbStatus.Location = new System.Drawing.Point(186, 66);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(142, 29);
            this.cbStatus.TabIndex = 38;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            this.cbStatus.SelectionChangeCommitted += new System.EventHandler(this.cbStatus_SelectionChangeCommitted);
            this.cbStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbStatus_MouseDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(5, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "Ngày tạo";
            // 
            // dtpCreate
            // 
            this.dtpCreate.CheckedState.Parent = this.dtpCreate;
            this.dtpCreate.FillColor = System.Drawing.Color.Gainsboro;
            this.dtpCreate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCreate.HoverState.Parent = this.dtpCreate;
            this.dtpCreate.Location = new System.Drawing.Point(7, 179);
            this.dtpCreate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCreate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCreate.Name = "dtpCreate";
            this.dtpCreate.ShadowDecoration.Parent = this.dtpCreate;
            this.dtpCreate.Size = new System.Drawing.Size(141, 21);
            this.dtpCreate.TabIndex = 36;
            this.dtpCreate.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(183, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Thành tiền:";
            // 
            // txtStaffName
            // 
            this.txtStaffName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtStaffName.ForeColor = System.Drawing.Color.DarkRed;
            this.txtStaffName.Location = new System.Drawing.Point(186, 121);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(142, 29);
            this.txtStaffName.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(183, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Nhân viên tạo:";
            // 
            // txtRoomName
            // 
            this.txtRoomName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtRoomName.ForeColor = System.Drawing.Color.DarkRed;
            this.txtRoomName.Location = new System.Drawing.Point(7, 121);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(141, 29);
            this.txtRoomName.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(3, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Tên phòng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(4, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Mã hóa đơn";
            // 
            // txtIdBill
            // 
            this.txtIdBill.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdBill.ForeColor = System.Drawing.Color.DarkRed;
            this.txtIdBill.Location = new System.Drawing.Point(7, 66);
            this.txtIdBill.Name = "txtIdBill";
            this.txtIdBill.Size = new System.Drawing.Size(141, 29);
            this.txtIdBill.TabIndex = 8;
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox3.Controls.Add(this.btnDetail);
            this.guna2GroupBox3.Controls.Add(this.btnClose);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox3.Location = new System.Drawing.Point(10, 372);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.ShadowDecoration.Parent = this.guna2GroupBox3;
            this.guna2GroupBox3.Size = new System.Drawing.Size(361, 81);
            this.guna2GroupBox3.TabIndex = 38;
            this.guna2GroupBox3.Text = "Chức năng";
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnDetail.CheckedState.Parent = this.btnDetail;
            this.btnDetail.CustomImages.Parent = this.btnDetail;
            this.btnDetail.FillColor = System.Drawing.Color.Transparent;
            this.btnDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDetail.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDetail.HoverState.Parent = this.btnDetail;
            this.btnDetail.Location = new System.Drawing.Point(9, 39);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnDetail.ShadowDecoration.Parent = this.btnDetail;
            this.btnDetail.Size = new System.Drawing.Size(153, 33);
            this.btnDetail.TabIndex = 26;
            this.btnDetail.Text = "Chi tiết hóa đơn";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.DarkRed;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.Location = new System.Drawing.Point(186, 39);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(153, 33);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            this.dgvBill.AllowUserToResizeColumns = false;
            this.dgvBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBill.BackgroundColor = System.Drawing.Color.White;
            this.dgvBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBill.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBill.ColumnHeadersHeight = 20;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMaHoaDon,
            this.dgvTenKhachHang,
            this.dgvTenNhanVien,
            this.dgvNgayLapHoaDon,
            this.dgvTinhTrangThanhToan,
            this.dgvThanhTien,
            this.dgvPhuThu,
            this.dgvPhuongThucThanhToan,
            this.dgvNoiDungPhuThu,
            this.dgvGiamGia,
            this.dgvMaHoSoDatPhong,
            this.dgvMaNhanVien});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBill.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBill.EnableHeadersVisualStyles = false;
            this.dgvBill.GridColor = System.Drawing.Color.DarkRed;
            this.dgvBill.Location = new System.Drawing.Point(0, 0);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.ReadOnly = true;
            this.dgvBill.RowHeadersVisible = false;
            this.dgvBill.RowHeadersWidth = 51;
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBill.Size = new System.Drawing.Size(475, 415);
            this.dgvBill.TabIndex = 39;
            this.dgvBill.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBill.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBill.ThemeStyle.GridColor = System.Drawing.Color.DarkRed;
            this.dgvBill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.dgvBill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvBill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvBill.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvBill.ThemeStyle.ReadOnly = true;
            this.dgvBill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvBill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBill.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvBill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBill.SelectionChanged += new System.EventHandler(this.dgvBill_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvBill);
            this.panel1.Location = new System.Drawing.Point(377, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 415);
            this.panel1.TabIndex = 40;
            // 
            // dgvMaHoaDon
            // 
            this.dgvMaHoaDon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvMaHoaDon.DataPropertyName = "MaHoaDon";
            this.dgvMaHoaDon.FillWeight = 7.211308F;
            this.dgvMaHoaDon.HeaderText = "Mã hoá đơn";
            this.dgvMaHoaDon.MinimumWidth = 6;
            this.dgvMaHoaDon.Name = "dgvMaHoaDon";
            this.dgvMaHoaDon.ReadOnly = true;
            // 
            // dgvTenKhachHang
            // 
            this.dgvTenKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvTenKhachHang.DataPropertyName = "TenKhachHang";
            this.dgvTenKhachHang.FillWeight = 152.5464F;
            this.dgvTenKhachHang.HeaderText = "Khách hàng";
            this.dgvTenKhachHang.MinimumWidth = 6;
            this.dgvTenKhachHang.Name = "dgvTenKhachHang";
            this.dgvTenKhachHang.ReadOnly = true;
            this.dgvTenKhachHang.Width = 104;
            // 
            // dgvTenNhanVien
            // 
            this.dgvTenNhanVien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvTenNhanVien.DataPropertyName = "TenNhanVien";
            this.dgvTenNhanVien.FillWeight = 374.6193F;
            this.dgvTenNhanVien.HeaderText = "Nhân viên";
            this.dgvTenNhanVien.Name = "dgvTenNhanVien";
            this.dgvTenNhanVien.ReadOnly = true;
            this.dgvTenNhanVien.Width = 94;
            // 
            // dgvNgayLapHoaDon
            // 
            this.dgvNgayLapHoaDon.DataPropertyName = "NgayLapHoaDon";
            this.dgvNgayLapHoaDon.FillWeight = 21.8743F;
            this.dgvNgayLapHoaDon.HeaderText = "Ngày tạo";
            this.dgvNgayLapHoaDon.MinimumWidth = 6;
            this.dgvNgayLapHoaDon.Name = "dgvNgayLapHoaDon";
            this.dgvNgayLapHoaDon.ReadOnly = true;
            this.dgvNgayLapHoaDon.Visible = false;
            // 
            // dgvTinhTrangThanhToan
            // 
            this.dgvTinhTrangThanhToan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvTinhTrangThanhToan.DataPropertyName = "TinhTrangThanhToan";
            this.dgvTinhTrangThanhToan.FillWeight = 21.8743F;
            this.dgvTinhTrangThanhToan.HeaderText = "Trạng thái";
            this.dgvTinhTrangThanhToan.MinimumWidth = 6;
            this.dgvTinhTrangThanhToan.Name = "dgvTinhTrangThanhToan";
            this.dgvTinhTrangThanhToan.ReadOnly = true;
            this.dgvTinhTrangThanhToan.Width = 93;
            // 
            // dgvThanhTien
            // 
            this.dgvThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvThanhTien.DataPropertyName = "ThanhTien";
            this.dgvThanhTien.FillWeight = 21.8743F;
            this.dgvThanhTien.HeaderText = "Thành tiền";
            this.dgvThanhTien.MinimumWidth = 6;
            this.dgvThanhTien.Name = "dgvThanhTien";
            this.dgvThanhTien.ReadOnly = true;
            this.dgvThanhTien.Width = 97;
            // 
            // dgvPhuThu
            // 
            this.dgvPhuThu.DataPropertyName = "PhuThu";
            this.dgvPhuThu.HeaderText = "Phụ thu";
            this.dgvPhuThu.Name = "dgvPhuThu";
            this.dgvPhuThu.ReadOnly = true;
            this.dgvPhuThu.Visible = false;
            // 
            // dgvPhuongThucThanhToan
            // 
            this.dgvPhuongThucThanhToan.DataPropertyName = "PhuongThucThanhToan";
            this.dgvPhuongThucThanhToan.HeaderText = "Phương thức thanh toán";
            this.dgvPhuongThucThanhToan.Name = "dgvPhuongThucThanhToan";
            this.dgvPhuongThucThanhToan.ReadOnly = true;
            this.dgvPhuongThucThanhToan.Visible = false;
            // 
            // dgvNoiDungPhuThu
            // 
            this.dgvNoiDungPhuThu.DataPropertyName = "NoiDungPhuThu";
            this.dgvNoiDungPhuThu.HeaderText = "Nội dung phụ thu";
            this.dgvNoiDungPhuThu.Name = "dgvNoiDungPhuThu";
            this.dgvNoiDungPhuThu.ReadOnly = true;
            this.dgvNoiDungPhuThu.Visible = false;
            // 
            // dgvGiamGia
            // 
            this.dgvGiamGia.DataPropertyName = "GiamGia";
            this.dgvGiamGia.HeaderText = "giảm giá";
            this.dgvGiamGia.Name = "dgvGiamGia";
            this.dgvGiamGia.ReadOnly = true;
            this.dgvGiamGia.Visible = false;
            // 
            // dgvMaHoSoDatPhong
            // 
            this.dgvMaHoSoDatPhong.DataPropertyName = "MaHoSoDatPhong";
            this.dgvMaHoSoDatPhong.HeaderText = "Mã đặt phòng";
            this.dgvMaHoSoDatPhong.Name = "dgvMaHoSoDatPhong";
            this.dgvMaHoSoDatPhong.ReadOnly = true;
            this.dgvMaHoSoDatPhong.Visible = false;
            // 
            // dgvMaNhanVien
            // 
            this.dgvMaNhanVien.DataPropertyName = "MaNhanVien";
            this.dgvMaNhanVien.HeaderText = "Mã nhân viên";
            this.dgvMaNhanVien.Name = "dgvMaNhanVien";
            this.dgvMaNhanVien.ReadOnly = true;
            this.dgvMaNhanVien.Visible = false;
            // 
            // FormQuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(864, 465);
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuanLyHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQuanLyHoaDon";
            this.Load += new System.EventHandler(this.FormQuanLyHoaDon_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCreate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdBill;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private Guna.UI2.WinForms.Guna2CircleButton btnDetail;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBill;
        private Guna.UI2.WinForms.Guna2CircleButton btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgayLapHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTinhTrangThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPhuongThucThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNoiDungPhuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMaHoSoDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMaNhanVien;
    }
}
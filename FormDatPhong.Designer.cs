﻿namespace QLKS
{
    partial class FormDatPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatPhong));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dtpCheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.dtpCheckIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRoomType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2CircleButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpDoB = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.guna2GroupBox4 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtIdBookRoom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.guna2GroupBox5 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnBook = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBookRoom = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaHoSoDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianCheckinDuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianCheckoutDuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienDatCoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiDatPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTheTinDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            this.guna2GroupBox4.SuspendLayout();
            this.guna2GroupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đặt phòng";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Controls.Add(this.dtpCheckOut);
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.txtDays);
            this.guna2GroupBox1.Controls.Add(this.dtpCheckIn);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.cbRoomType);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox1.Location = new System.Drawing.Point(14, 33);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(359, 141);
            this.guna2GroupBox1.TabIndex = 27;
            this.guna2GroupBox1.Text = "Đăng kí phòng";
            this.guna2GroupBox1.Click += new System.EventHandler(this.guna2GroupBox1_Click);
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.CheckedState.Parent = this.dtpCheckOut;
            this.dtpCheckOut.FillColor = System.Drawing.Color.Gainsboro;
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.HoverState.Parent = this.dtpCheckOut;
            this.dtpCheckOut.Location = new System.Drawing.Point(191, 110);
            this.dtpCheckOut.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckOut.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.ShadowDecoration.Parent = this.dtpCheckOut;
            this.dtpCheckOut.Size = new System.Drawing.Size(144, 21);
            this.dtpCheckOut.TabIndex = 45;
            this.dtpCheckOut.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckOut_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(191, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 44;
            this.label5.Text = "Ngày trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(191, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Ngày nhận";
            // 
            // txtDays
            // 
            this.txtDays.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDays.ForeColor = System.Drawing.Color.DarkRed;
            this.txtDays.Location = new System.Drawing.Point(6, 107);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(152, 29);
            this.txtDays.TabIndex = 42;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.CheckedState.Parent = this.dtpCheckIn;
            this.dtpCheckIn.FillColor = System.Drawing.Color.Gainsboro;
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.HoverState.Parent = this.dtpCheckIn;
            this.dtpCheckIn.Location = new System.Drawing.Point(191, 57);
            this.dtpCheckIn.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckIn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.ShadowDecoration.Parent = this.dtpCheckIn;
            this.dtpCheckIn.Size = new System.Drawing.Size(144, 21);
            this.dtpCheckIn.TabIndex = 41;
            this.dtpCheckIn.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Số đêm";
            // 
            // cbRoomType
            // 
            this.cbRoomType.BackColor = System.Drawing.Color.Gainsboro;
            this.cbRoomType.FormattingEnabled = true;
            this.cbRoomType.Location = new System.Drawing.Point(6, 57);
            this.cbRoomType.Name = "cbRoomType";
            this.cbRoomType.Size = new System.Drawing.Size(152, 29);
            this.cbRoomType.TabIndex = 39;
            this.cbRoomType.SelectedIndexChanged += new System.EventHandler(this.cbRoomType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loại phòng:";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox2.Controls.Add(this.btnSearch);
            this.guna2GroupBox2.Controls.Add(this.txtSearch);
            this.guna2GroupBox2.Controls.Add(this.label6);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox2.Location = new System.Drawing.Point(15, 191);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(358, 92);
            this.guna2GroupBox2.TabIndex = 28;
            this.guna2GroupBox2.Text = "Tìm kiếm khách hàng";
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
            this.btnSearch.Location = new System.Drawing.Point(220, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSearch.ShadowDecoration.Parent = this.btnSearch;
            this.btnSearch.Size = new System.Drawing.Size(100, 39);
            this.btnSearch.TabIndex = 50;
            this.btnSearch.Text = "Tìm kiếm";
//            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSearch.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSearch.Location = new System.Drawing.Point(7, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(164, 29);
            this.txtSearch.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Số điện thoại:";
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox3.Controls.Add(this.cbType);
            this.guna2GroupBox3.Controls.Add(this.label7);
            this.guna2GroupBox3.Controls.Add(this.cbSex);
            this.guna2GroupBox3.Controls.Add(this.label13);
            this.guna2GroupBox3.Controls.Add(this.dtpDoB);
            this.guna2GroupBox3.Controls.Add(this.label12);
            this.guna2GroupBox3.Controls.Add(this.txtPhone);
            this.guna2GroupBox3.Controls.Add(this.label11);
            this.guna2GroupBox3.Controls.Add(this.txtAddress);
            this.guna2GroupBox3.Controls.Add(this.label10);
            this.guna2GroupBox3.Controls.Add(this.label9);
            this.guna2GroupBox3.Controls.Add(this.txtCustomerName);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox3.Location = new System.Drawing.Point(15, 290);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.ShadowDecoration.Parent = this.guna2GroupBox3;
            this.guna2GroupBox3.Size = new System.Drawing.Size(358, 199);
            this.guna2GroupBox3.TabIndex = 29;
            this.guna2GroupBox3.Text = "Thông tin khách hàng";
            // 
            // cbType
            // 
            this.cbType.BackColor = System.Drawing.Color.Gainsboro;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(190, 163);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(149, 29);
            this.cbType.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(191, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Loại khách hàng:";
            // 
            // cbSex
            // 
            this.cbSex.BackColor = System.Drawing.Color.Gainsboro;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbSex.Location = new System.Drawing.Point(190, 112);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(149, 29);
            this.cbSex.TabIndex = 38;
            this.cbSex.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(191, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "Giới tính:";
            // 
            // dtpDoB
            // 
            this.dtpDoB.CheckedState.Parent = this.dtpDoB;
            this.dtpDoB.FillColor = System.Drawing.Color.Gainsboro;
            this.dtpDoB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDoB.HoverState.Parent = this.dtpDoB;
            this.dtpDoB.Location = new System.Drawing.Point(190, 63);
            this.dtpDoB.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDoB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDoB.Name = "dtpDoB";
            this.dtpDoB.ShadowDecoration.Parent = this.dtpDoB;
            this.dtpDoB.Size = new System.Drawing.Size(149, 21);
            this.dtpDoB.TabIndex = 36;
            this.dtpDoB.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(189, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ngày sinh:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhone.ForeColor = System.Drawing.Color.DarkRed;
            this.txtPhone.Location = new System.Drawing.Point(7, 163);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(166, 29);
            this.txtPhone.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(5, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Số điện thoại:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAddress.ForeColor = System.Drawing.Color.DarkRed;
            this.txtAddress.Location = new System.Drawing.Point(6, 112);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(165, 29);
            this.txtAddress.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(4, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Địa chỉ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(4, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Tên khách hàng";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtCustomerName.ForeColor = System.Drawing.Color.DarkRed;
            this.txtCustomerName.Location = new System.Drawing.Point(7, 60);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(164, 29);
            this.txtCustomerName.TabIndex = 8;
            // 
            // guna2GroupBox4
            // 
            this.guna2GroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox4.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox4.Controls.Add(this.cbRoom);
            this.guna2GroupBox4.Controls.Add(this.label14);
            this.guna2GroupBox4.Controls.Add(this.cbStatus);
            this.guna2GroupBox4.Controls.Add(this.txtIdBookRoom);
            this.guna2GroupBox4.Controls.Add(this.label8);
            this.guna2GroupBox4.Controls.Add(this.txtDeposit);
            this.guna2GroupBox4.Controls.Add(this.label15);
            this.guna2GroupBox4.Controls.Add(this.label16);
            this.guna2GroupBox4.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox4.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox4.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox4.Location = new System.Drawing.Point(379, 33);
            this.guna2GroupBox4.Name = "guna2GroupBox4";
            this.guna2GroupBox4.ShadowDecoration.Parent = this.guna2GroupBox4;
            this.guna2GroupBox4.Size = new System.Drawing.Size(171, 251);
            this.guna2GroupBox4.TabIndex = 30;
            this.guna2GroupBox4.Text = "Hồ sơ đặt phòng";
            // 
            // cbRoom
            // 
            this.cbRoom.BackColor = System.Drawing.Color.Gainsboro;
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(7, 108);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(154, 29);
            this.cbRoom.TabIndex = 47;
            this.cbRoom.SelectedIndexChanged += new System.EventHandler(this.cbRoom_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(6, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 17);
            this.label14.TabIndex = 46;
            this.label14.Text = "Phòng:";
            // 
            // cbStatus
            // 
            this.cbStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Chờ xác nhận",
            "Đã xác nhận",
            "Đã huỷ",
            "Đã hoàn tất"});
            this.cbStatus.Location = new System.Drawing.Point(7, 215);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(155, 29);
            this.cbStatus.TabIndex = 41;
            // 
            // txtIdBookRoom
            // 
            this.txtIdBookRoom.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIdBookRoom.ForeColor = System.Drawing.Color.DarkRed;
            this.txtIdBookRoom.Location = new System.Drawing.Point(8, 57);
            this.txtIdBookRoom.Name = "txtIdBookRoom";
            this.txtIdBookRoom.Size = new System.Drawing.Size(155, 29);
            this.txtIdBookRoom.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(4, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 17);
            this.label8.TabIndex = 43;
            this.label8.Text = "Trạng thái đặt phòng:";
            // 
            // txtDeposit
            // 
            this.txtDeposit.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDeposit.ForeColor = System.Drawing.Color.DarkRed;
            this.txtDeposit.Location = new System.Drawing.Point(7, 160);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(154, 29);
            this.txtDeposit.TabIndex = 42;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkRed;
            this.label15.Location = new System.Drawing.Point(3, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 17);
            this.label15.TabIndex = 40;
            this.label15.Text = "Tiền cọc đặt phòng:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(3, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 17);
            this.label16.TabIndex = 3;
            this.label16.Text = "Mã hồ sơ:";
            // 
            // guna2GroupBox5
            // 
            this.guna2GroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox5.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox5.Controls.Add(this.btnUpdate);
            this.guna2GroupBox5.Controls.Add(this.btnClose);
            this.guna2GroupBox5.Controls.Add(this.btnCancel);
            this.guna2GroupBox5.Controls.Add(this.btnBook);
            this.guna2GroupBox5.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox5.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox5.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox5.Location = new System.Drawing.Point(379, 290);
            this.guna2GroupBox5.Name = "guna2GroupBox5";
            this.guna2GroupBox5.ShadowDecoration.Parent = this.guna2GroupBox5;
            this.guna2GroupBox5.Size = new System.Drawing.Size(171, 199);
            this.guna2GroupBox5.TabIndex = 31;
            this.guna2GroupBox5.Text = "Chức năng";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.CheckedState.Parent = this.btnUpdate;
            this.btnUpdate.CustomImages.Parent = this.btnUpdate;
            this.btnUpdate.FillColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.DarkRed;
            this.btnUpdate.HoverState.Parent = this.btnUpdate;
            this.btnUpdate.Location = new System.Drawing.Point(9, 83);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnUpdate.ShadowDecoration.Parent = this.btnUpdate;
            this.btnUpdate.Size = new System.Drawing.Size(153, 33);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Cập nhật";
//            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.btnClose.Location = new System.Drawing.Point(9, 164);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(153, 33);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.guna2CircleButton3_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.CheckedState.Parent = this.btnCancel;
            this.btnCancel.CustomImages.Parent = this.btnCancel;
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancel.HoverState.Parent = this.btnCancel;
            this.btnCancel.Location = new System.Drawing.Point(8, 123);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnCancel.ShadowDecoration.Parent = this.btnCancel;
            this.btnCancel.Size = new System.Drawing.Size(153, 33);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.Transparent;
            this.btnBook.CheckedState.Parent = this.btnBook;
            this.btnBook.CustomImages.Parent = this.btnBook;
            this.btnBook.FillColor = System.Drawing.Color.Transparent;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.DarkRed;
            this.btnBook.HoverState.Parent = this.btnBook;
            this.btnBook.Location = new System.Drawing.Point(10, 42);
            this.btnBook.Name = "btnBook";
            this.btnBook.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnBook.ShadowDecoration.Parent = this.btnBook;
            this.btnBook.Size = new System.Drawing.Size(153, 33);
            this.btnBook.TabIndex = 26;
            this.btnBook.Text = "Đặt phòng";
//            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvBookRoom);
            this.panel1.Location = new System.Drawing.Point(558, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 453);
            this.panel1.TabIndex = 32;
            // 
            // dgvBookRoom
            // 
            this.dgvBookRoom.AllowUserToAddRows = false;
            this.dgvBookRoom.AllowUserToDeleteRows = false;
            this.dgvBookRoom.AllowUserToResizeColumns = false;
            this.dgvBookRoom.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvBookRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookRoom.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBookRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBookRoom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookRoom.ColumnHeadersHeight = 29;
            this.dgvBookRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBookRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoSoDatPhong,
            this.ThoiGianDatPhong,
            this.Hoten,
            this.MaKhachHang,
            this.MaPhong,
            this.TenPhong,
            this.SoDem,
            this.ThoiGianCheckinDuKien,
            this.ThoiGianCheckoutDuKien,
            this.TienDatCoc,
            this.TrangThaiDatPhong,
            this.SoTheTinDung,
            this.GhiChu});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookRoom.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookRoom.EnableHeadersVisualStyles = false;
            this.dgvBookRoom.GridColor = System.Drawing.Color.DarkRed;
            this.dgvBookRoom.Location = new System.Drawing.Point(0, 0);
            this.dgvBookRoom.Name = "dgvBookRoom";
            this.dgvBookRoom.ReadOnly = true;
            this.dgvBookRoom.RowHeadersVisible = false;
            this.dgvBookRoom.RowHeadersWidth = 123;
            this.dgvBookRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBookRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookRoom.Size = new System.Drawing.Size(468, 453);
            this.dgvBookRoom.TabIndex = 30;
            this.dgvBookRoom.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.dgvBookRoom.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBookRoom.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvBookRoom.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvBookRoom.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvBookRoom.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvBookRoom.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBookRoom.ThemeStyle.GridColor = System.Drawing.Color.DarkRed;
            this.dgvBookRoom.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.dgvBookRoom.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBookRoom.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvBookRoom.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBookRoom.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBookRoom.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvBookRoom.ThemeStyle.ReadOnly = true;
            this.dgvBookRoom.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBookRoom.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBookRoom.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvBookRoom.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvBookRoom.ThemeStyle.RowsStyle.Height = 22;
            this.dgvBookRoom.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvBookRoom.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBookRoom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookRoom_CellContentClick);
            // 
            // MaHoSoDatPhong
            // 
            this.MaHoSoDatPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaHoSoDatPhong.DataPropertyName = "MaHoSoDatPhong";
            this.MaHoSoDatPhong.FillWeight = 123F;
            this.MaHoSoDatPhong.HeaderText = "Mã";
            this.MaHoSoDatPhong.MinimumWidth = 45;
            this.MaHoSoDatPhong.Name = "MaHoSoDatPhong";
            this.MaHoSoDatPhong.ReadOnly = true;
            this.MaHoSoDatPhong.Width = 52;
            // 
            // ThoiGianDatPhong
            // 
            this.ThoiGianDatPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThoiGianDatPhong.DataPropertyName = "ThoiGianDatPhong";
            this.ThoiGianDatPhong.HeaderText = "Ngày đặt phòng";
            this.ThoiGianDatPhong.Name = "ThoiGianDatPhong";
            this.ThoiGianDatPhong.ReadOnly = true;
            this.ThoiGianDatPhong.Visible = false;
            this.ThoiGianDatPhong.Width = 132;
            // 
            // Hoten
            // 
            this.Hoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Hoten.DataPropertyName = "Hoten";
            this.Hoten.HeaderText = "Tên khách hàng";
            this.Hoten.MinimumWidth = 6;
            this.Hoten.Name = "Hoten";
            this.Hoten.ReadOnly = true;
            this.Hoten.Width = 128;
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaKhachHang.DataPropertyName = "MaKhachHang";
            this.MaKhachHang.HeaderText = "Mã khách hàng";
            this.MaKhachHang.MinimumWidth = 10;
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.ReadOnly = true;
            this.MaKhachHang.Visible = false;
            this.MaKhachHang.Width = 127;
            // 
            // MaPhong
            // 
            this.MaPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.MinimumWidth = 10;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            this.MaPhong.Visible = false;
            this.MaPhong.Width = 96;
            // 
            // TenPhong
            // 
            this.TenPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên phòng";
            this.TenPhong.MinimumWidth = 10;
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.ReadOnly = true;
            this.TenPhong.Width = 97;
            // 
            // SoDem
            // 
            this.SoDem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoDem.DataPropertyName = "SoDem";
            this.SoDem.HeaderText = "Số ngày";
            this.SoDem.MinimumWidth = 10;
            this.SoDem.Name = "SoDem";
            this.SoDem.ReadOnly = true;
            this.SoDem.Visible = false;
            this.SoDem.Width = 81;
            // 
            // ThoiGianCheckinDuKien
            // 
            this.ThoiGianCheckinDuKien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThoiGianCheckinDuKien.DataPropertyName = "ThoiGianCheckinDuKien";
            this.ThoiGianCheckinDuKien.HeaderText = "Ngày nhận";
            this.ThoiGianCheckinDuKien.MinimumWidth = 10;
            this.ThoiGianCheckinDuKien.Name = "ThoiGianCheckinDuKien";
            this.ThoiGianCheckinDuKien.ReadOnly = true;
            this.ThoiGianCheckinDuKien.Width = 99;
            // 
            // ThoiGianCheckoutDuKien
            // 
            this.ThoiGianCheckoutDuKien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ThoiGianCheckoutDuKien.DataPropertyName = "ThoiGianCheckoutDuKien";
            this.ThoiGianCheckoutDuKien.HeaderText = "Ngày trả";
            this.ThoiGianCheckoutDuKien.MinimumWidth = 10;
            this.ThoiGianCheckoutDuKien.Name = "ThoiGianCheckoutDuKien";
            this.ThoiGianCheckoutDuKien.ReadOnly = true;
            this.ThoiGianCheckoutDuKien.Width = 85;
            // 
            // TienDatCoc
            // 
            this.TienDatCoc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TienDatCoc.DataPropertyName = "TienDatCoc";
            this.TienDatCoc.HeaderText = "Tiền cọc";
            this.TienDatCoc.MinimumWidth = 10;
            this.TienDatCoc.Name = "TienDatCoc";
            this.TienDatCoc.ReadOnly = true;
            this.TienDatCoc.Width = 81;
            // 
            // TrangThaiDatPhong
            // 
            this.TrangThaiDatPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrangThaiDatPhong.DataPropertyName = "TrangThaiDatPhong";
            this.TrangThaiDatPhong.HeaderText = "Tình trạng";
            this.TrangThaiDatPhong.MinimumWidth = 10;
            this.TrangThaiDatPhong.Name = "TrangThaiDatPhong";
            this.TrangThaiDatPhong.ReadOnly = true;
            this.TrangThaiDatPhong.Width = 95;
            // 
            // SoTheTinDung
            // 
            this.SoTheTinDung.DataPropertyName = "SoTheTinDung";
            this.SoTheTinDung.HeaderText = "Số thẻ tín dụng";
            this.SoTheTinDung.Name = "SoTheTinDung";
            this.SoTheTinDung.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // FormDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1038, 501);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2GroupBox5);
            this.Controls.Add(this.guna2GroupBox4);
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDatPhong";
            this.Load += new System.EventHandler(this.FormDatPhong_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            this.guna2GroupBox4.ResumeLayout(false);
            this.guna2GroupBox4.PerformLayout();
            this.guna2GroupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRoomType;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckIn;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDays;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDoB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox5;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2CircleButton btnCancel;
        private Guna.UI2.WinForms.Guna2CircleButton btnBook;
        private System.Windows.Forms.TextBox txtIdBookRoom;
        private System.Windows.Forms.ComboBox cbStatus;
        private Guna.UI2.WinForms.Guna2CircleButton btnUpdate;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBookRoom;
        private Guna.UI2.WinForms.Guna2CircleButton btnSearch;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoSoDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianCheckinDuKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianCheckoutDuKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienDatCoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiDatPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTheTinDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}
namespace QLKS
{
    partial class FormNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeach = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpDOB = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIDNum = new System.Windows.Forms.TextBox();
            this.guna2GroupBox3 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dtpStartday = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datagridviewStaff = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIDnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colidStaff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Updatebtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton5 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewStaff)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý nhân viên";
            // 
            // btnSeach
            // 
            this.btnSeach.BackColor = System.Drawing.Color.Transparent;
            this.btnSeach.CheckedState.Parent = this.btnSeach;
            this.btnSeach.CustomImages.Parent = this.btnSeach;
            this.btnSeach.FillColor = System.Drawing.Color.Transparent;
            this.btnSeach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSeach.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSeach.HoverState.Parent = this.btnSeach;
            this.btnSeach.Location = new System.Drawing.Point(0, 93);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnSeach.ShadowDecoration.Parent = this.btnSeach;
            this.btnSeach.Size = new System.Drawing.Size(153, 33);
            this.btnSeach.TabIndex = 25;
            this.btnSeach.Text = "Tìm kiếm";
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSearch.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSearch.Location = new System.Drawing.Point(7, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(159, 29);
            this.txtSearch.TabIndex = 8;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox1.Controls.Add(this.txtSearch);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.btnSeach);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox1.Location = new System.Drawing.Point(18, 50);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(180, 129);
            this.guna2GroupBox1.TabIndex = 26;
            this.guna2GroupBox1.Text = "Tìm kiếm tài khoản";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox2.Controls.Add(this.label6);
            this.guna2GroupBox2.Controls.Add(this.txtName);
            this.guna2GroupBox2.Controls.Add(this.cbSex);
            this.guna2GroupBox2.Controls.Add(this.label13);
            this.guna2GroupBox2.Controls.Add(this.dtpDOB);
            this.guna2GroupBox2.Controls.Add(this.label12);
            this.guna2GroupBox2.Controls.Add(this.txtPhone);
            this.guna2GroupBox2.Controls.Add(this.label11);
            this.guna2GroupBox2.Controls.Add(this.txtAddress);
            this.guna2GroupBox2.Controls.Add(this.label10);
            this.guna2GroupBox2.Controls.Add(this.label9);
            this.guna2GroupBox2.Controls.Add(this.txtIDNum);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox2.Location = new System.Drawing.Point(204, 46);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(179, 370);
            this.guna2GroupBox2.TabIndex = 27;
            this.guna2GroupBox2.Text = "Thông tin nhân viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(6, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 40;
            this.label6.Text = "Họ tên:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtName.ForeColor = System.Drawing.Color.DarkRed;
            this.txtName.Location = new System.Drawing.Point(9, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 29);
            this.txtName.TabIndex = 39;
            // 
            // cbSex
            // 
            this.cbSex.BackColor = System.Drawing.Color.Gainsboro;
            this.cbSex.FormattingEnabled = true;
            this.cbSex.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbSex.Location = new System.Drawing.Point(9, 281);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(154, 29);
            this.cbSex.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(6, 261);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "Giới tính:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // dtpDOB
            // 
            this.dtpDOB.CheckedState.Parent = this.dtpDOB;
            this.dtpDOB.FillColor = System.Drawing.Color.Gainsboro;
            this.dtpDOB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.HoverState.Parent = this.dtpDOB;
            this.dtpDOB.Location = new System.Drawing.Point(8, 338);
            this.dtpDOB.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDOB.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.ShadowDecoration.Parent = this.dtpDOB;
            this.dtpDOB.Size = new System.Drawing.Size(155, 21);
            this.dtpDOB.TabIndex = 36;
            this.dtpDOB.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(5, 317);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 17);
            this.label12.TabIndex = 35;
            this.label12.Text = "Ngày sinh:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPhone.ForeColor = System.Drawing.Color.DarkRed;
            this.txtPhone.Location = new System.Drawing.Point(8, 225);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(155, 29);
            this.txtPhone.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(5, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Số điện thoại:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAddress.ForeColor = System.Drawing.Color.DarkRed;
            this.txtAddress.Location = new System.Drawing.Point(8, 173);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(155, 29);
            this.txtAddress.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(5, 153);
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
            this.label9.Location = new System.Drawing.Point(5, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "CCCD/CMND:";
            // 
            // txtIDNum
            // 
            this.txtIDNum.BackColor = System.Drawing.Color.Gainsboro;
            this.txtIDNum.ForeColor = System.Drawing.Color.DarkRed;
            this.txtIDNum.Location = new System.Drawing.Point(8, 118);
            this.txtIDNum.Name = "txtIDNum";
            this.txtIDNum.Size = new System.Drawing.Size(155, 29);
            this.txtIDNum.TabIndex = 8;
            // 
            // guna2GroupBox3
            // 
            this.guna2GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.BorderColor = System.Drawing.Color.Silver;
            this.guna2GroupBox3.Controls.Add(this.dtpStartday);
            this.guna2GroupBox3.Controls.Add(this.label7);
            this.guna2GroupBox3.Controls.Add(this.txtEmail);
            this.guna2GroupBox3.Controls.Add(this.cbRole);
            this.guna2GroupBox3.Controls.Add(this.label4);
            this.guna2GroupBox3.Controls.Add(this.label5);
            this.guna2GroupBox3.Controls.Add(this.txtUser);
            this.guna2GroupBox3.Controls.Add(this.label2);
            this.guna2GroupBox3.CustomBorderColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2GroupBox3.Location = new System.Drawing.Point(18, 184);
            this.guna2GroupBox3.Name = "guna2GroupBox3";
            this.guna2GroupBox3.ShadowDecoration.Parent = this.guna2GroupBox3;
            this.guna2GroupBox3.Size = new System.Drawing.Size(180, 231);
            this.guna2GroupBox3.TabIndex = 28;
            this.guna2GroupBox3.Text = "Tài khoản";
            // 
            // dtpStartday
            // 
            this.dtpStartday.CheckedState.Parent = this.dtpStartday;
            this.dtpStartday.FillColor = System.Drawing.Color.Gainsboro;
            this.dtpStartday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtpStartday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartday.HoverState.Parent = this.dtpStartday;
            this.dtpStartday.Location = new System.Drawing.Point(8, 202);
            this.dtpStartday.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartday.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartday.Name = "dtpStartday";
            this.dtpStartday.ShadowDecoration.Parent = this.dtpStartday;
            this.dtpStartday.Size = new System.Drawing.Size(158, 21);
            this.dtpStartday.TabIndex = 42;
            this.dtpStartday.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(5, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 41;
            this.label7.Text = "Ngày vào làm:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEmail.ForeColor = System.Drawing.Color.DarkRed;
            this.txtEmail.Location = new System.Drawing.Point(7, 151);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(159, 29);
            this.txtEmail.TabIndex = 43;
            // 
            // cbRole
            // 
            this.cbRole.BackColor = System.Drawing.Color.Gainsboro;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(7, 103);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(159, 29);
            this.cbRole.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(4, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Chức vụ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(4, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Email:";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Gainsboro;
            this.txtUser.ForeColor = System.Drawing.Color.DarkRed;
            this.txtUser.Location = new System.Drawing.Point(6, 56);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(160, 29);
            this.txtUser.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // datagridviewStaff
            // 
            this.datagridviewStaff.AllowUserToAddRows = false;
            this.datagridviewStaff.AllowUserToDeleteRows = false;
            this.datagridviewStaff.AllowUserToResizeColumns = false;
            this.datagridviewStaff.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.datagridviewStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridviewStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridviewStaff.BackgroundColor = System.Drawing.Color.White;
            this.datagridviewStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridviewStaff.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.datagridviewStaff.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridviewStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridviewStaff.ColumnHeadersHeight = 29;
            this.datagridviewStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagridviewStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colPhone,
            this.colIDnum,
            this.colSex,
            this.colDoB,
            this.colStart,
            this.colidStaff,
            this.colEmail,
            this.colRole,
            this.colAddress,
            this.colRoleName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridviewStaff.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridviewStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridviewStaff.EnableHeadersVisualStyles = false;
            this.datagridviewStaff.GridColor = System.Drawing.Color.DarkRed;
            this.datagridviewStaff.Location = new System.Drawing.Point(0, 0);
            this.datagridviewStaff.Name = "datagridviewStaff";
            this.datagridviewStaff.ReadOnly = true;
            this.datagridviewStaff.RowHeadersVisible = false;
            this.datagridviewStaff.RowHeadersWidth = 123;
            this.datagridviewStaff.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.datagridviewStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewStaff.Size = new System.Drawing.Size(427, 366);
            this.datagridviewStaff.TabIndex = 29;
            this.datagridviewStaff.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.datagridviewStaff.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.datagridviewStaff.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.datagridviewStaff.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.datagridviewStaff.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.datagridviewStaff.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.datagridviewStaff.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.datagridviewStaff.ThemeStyle.GridColor = System.Drawing.Color.DarkRed;
            this.datagridviewStaff.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(237)))));
            this.datagridviewStaff.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datagridviewStaff.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.datagridviewStaff.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridviewStaff.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagridviewStaff.ThemeStyle.HeaderStyle.Height = 29;
            this.datagridviewStaff.ThemeStyle.ReadOnly = true;
            this.datagridviewStaff.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.datagridviewStaff.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.datagridviewStaff.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.datagridviewStaff.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridviewStaff.ThemeStyle.RowsStyle.Height = 22;
            this.datagridviewStaff.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.datagridviewStaff.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datagridviewStaff.SelectionChanged += new System.EventHandler(this.datagridviewStaff_SelectionChanged);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "Fullname";
            this.colName.FillWeight = 123F;
            this.colName.HeaderText = "Tên";
            this.colName.MinimumWidth = 45;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 53;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPhone.DataPropertyName = "Phonenumber";
            this.colPhone.HeaderText = "SĐT";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 56;
            // 
            // colIDnum
            // 
            this.colIDnum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIDnum.DataPropertyName = "CCCD";
            this.colIDnum.HeaderText = "CCCD";
            this.colIDnum.MinimumWidth = 10;
            this.colIDnum.Name = "colIDnum";
            this.colIDnum.ReadOnly = true;
            this.colIDnum.Width = 69;
            // 
            // colSex
            // 
            this.colSex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSex.DataPropertyName = "sex";
            this.colSex.HeaderText = "Giới tính";
            this.colSex.MinimumWidth = 10;
            this.colSex.Name = "colSex";
            this.colSex.ReadOnly = true;
            this.colSex.Visible = false;
            this.colSex.Width = 84;
            // 
            // colDoB
            // 
            this.colDoB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDoB.DataPropertyName = "dateofBirth";
            this.colDoB.HeaderText = "Ngày sinh";
            this.colDoB.MinimumWidth = 10;
            this.colDoB.Name = "colDoB";
            this.colDoB.ReadOnly = true;
            this.colDoB.Visible = false;
            this.colDoB.Width = 93;
            // 
            // colStart
            // 
            this.colStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStart.DataPropertyName = "startDay";
            this.colStart.HeaderText = "Ngày vào làm";
            this.colStart.MinimumWidth = 10;
            this.colStart.Name = "colStart";
            this.colStart.ReadOnly = true;
            this.colStart.Visible = false;
            this.colStart.Width = 116;
            // 
            // colidStaff
            // 
            this.colidStaff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colidStaff.DataPropertyName = "idStaff";
            this.colidStaff.HeaderText = "mã nhân viên";
            this.colidStaff.MinimumWidth = 10;
            this.colidStaff.Name = "colidStaff";
            this.colidStaff.ReadOnly = true;
            this.colidStaff.Visible = false;
            this.colidStaff.Width = 115;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEmail.DataPropertyName = "email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 10;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Visible = false;
            this.colEmail.Width = 64;
            // 
            // colRole
            // 
            this.colRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRole.DataPropertyName = "idRole";
            this.colRole.HeaderText = "Vai trò";
            this.colRole.MinimumWidth = 10;
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Visible = false;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddress.DataPropertyName = "address";
            this.colAddress.HeaderText = "Địa chỉ";
            this.colAddress.MinimumWidth = 10;
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            this.colAddress.Width = 73;
            // 
            // colRoleName
            // 
            this.colRoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRoleName.DataPropertyName = "name";
            this.colRoleName.HeaderText = "Vị trí";
            this.colRoleName.MinimumWidth = 10;
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            this.colRoleName.Width = 61;
            // 
            // Updatebtn
            // 
            this.Updatebtn.BackColor = System.Drawing.Color.Transparent;
            this.Updatebtn.CheckedState.Parent = this.Updatebtn;
            this.Updatebtn.CustomImages.Parent = this.Updatebtn;
            this.Updatebtn.FillColor = System.Drawing.Color.Transparent;
            this.Updatebtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Updatebtn.ForeColor = System.Drawing.Color.DarkRed;
            this.Updatebtn.HoverState.Parent = this.Updatebtn;
            this.Updatebtn.Location = new System.Drawing.Point(10, 434);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Updatebtn.ShadowDecoration.Parent = this.Updatebtn;
            this.Updatebtn.Size = new System.Drawing.Size(153, 33);
            this.Updatebtn.TabIndex = 30;
            this.Updatebtn.Text = "Cập nhật";
            this.Updatebtn.Click += new System.EventHandler(this.guna2CircleButton3_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Location = new System.Drawing.Point(237, 434);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Size = new System.Drawing.Size(153, 33);
            this.guna2CircleButton1.TabIndex = 31;
            this.guna2CircleButton1.Text = "Thêm";
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.CheckedState.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.CustomImages.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2CircleButton2.HoverState.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Location = new System.Drawing.Point(448, 434);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.ShadowDecoration.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Size = new System.Drawing.Size(153, 33);
            this.guna2CircleButton2.TabIndex = 32;
            this.guna2CircleButton2.Text = "Xoá";
            this.guna2CircleButton2.Click += new System.EventHandler(this.guna2CircleButton2_Click);
            // 
            // guna2CircleButton5
            // 
            this.guna2CircleButton5.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton5.CheckedState.Parent = this.guna2CircleButton5;
            this.guna2CircleButton5.CustomImages.Parent = this.guna2CircleButton5;
            this.guna2CircleButton5.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.guna2CircleButton5.ForeColor = System.Drawing.Color.DarkRed;
            this.guna2CircleButton5.HoverState.Parent = this.guna2CircleButton5;
            this.guna2CircleButton5.Location = new System.Drawing.Point(655, 434);
            this.guna2CircleButton5.Name = "guna2CircleButton5";
            this.guna2CircleButton5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton5.ShadowDecoration.Parent = this.guna2CircleButton5;
            this.guna2CircleButton5.Size = new System.Drawing.Size(153, 33);
            this.guna2CircleButton5.TabIndex = 33;
            this.guna2CircleButton5.Text = "Đóng";
            this.guna2CircleButton5.Click += new System.EventHandler(this.guna2CircleButton5_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.datagridviewStaff);
            this.guna2Panel1.Location = new System.Drawing.Point(389, 50);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(427, 366);
            this.guna2Panel1.TabIndex = 34;
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(827, 474);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2CircleButton5);
            this.Controls.Add(this.guna2CircleButton2);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.Updatebtn);
            this.Controls.Add(this.guna2GroupBox3);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2GroupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNhanVien";
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2GroupBox3.ResumeLayout(false);
            this.guna2GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewStaff)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnSeach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.TextBox txtIDNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2DataGridView datagridviewStaff;
        private Guna.UI2.WinForms.Guna2CircleButton Updatebtn;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton2;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartday;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIDnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colidStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
    }
}
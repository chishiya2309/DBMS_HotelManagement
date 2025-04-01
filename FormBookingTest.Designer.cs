using System.Windows.Forms;

namespace QLKS
{
    partial class FormBookingTest
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvBookRoom, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.dgvBookRoom.Location = new System.Drawing.Point(403, 3);
            this.dgvBookRoom.Name = "dgvBookRoom";
            this.dgvBookRoom.ReadOnly = true;
            this.dgvBookRoom.RowHeadersVisible = false;
            this.dgvBookRoom.RowHeadersWidth = 123;
            this.dgvBookRoom.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBookRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookRoom.Size = new System.Drawing.Size(394, 444);
            this.dgvBookRoom.TabIndex = 31;
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
            // FormBookingTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormBookingTest";
            this.Text = "FormBookingTest";
            this.Load += new System.EventHandler(this.FormBookingTest_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvBookRoom;
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
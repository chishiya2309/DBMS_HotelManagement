using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormChinh : Form
    {
        //private bool isPanelCollapsed = false;

        public static int idStaff;

        public FormChinh(int id)
        {
            InitializeComponent();
            idStaff = id;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnThuNho_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap form1 = new FormDangNhap();
            form1.Show();
        }

        private void btnGioiThieu_Click(object sender, EventArgs e)
        {
            FormGioiThieu formGioiThieu = new FormGioiThieu();
            formGioiThieu.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FormThongTin formThongTin = new FormThongTin(idStaff);
            formThongTin.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            FormDatPhong formDatPhong = new FormDatPhong();
            formDatPhong.Show();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            FormQuanLyPhong formQuanLyPhong = new FormQuanLyPhong();
            formQuanLyPhong.Show();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            FormThongKe formThongKe = new FormThongKe();
            formThongKe.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            FormQuanLyKhachHang formQuanLyKhachHang = new FormQuanLyKhachHang();
            formQuanLyKhachHang.Show();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            FormQuanLyHoaDon formQuanLyHoaDon = new FormQuanLyHoaDon();
            formQuanLyHoaDon.Show();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            FormQuanLyDichVu formQuanLyDichVu = new FormQuanLyDichVu();
            formQuanLyDichVu.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            FormDichVuVaThanhToan formDichVuVaThanhToan = new FormDichVuVaThanhToan();
            formDichVuVaThanhToan.Show();
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {

        }

        private void FormChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}


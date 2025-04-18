using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using System.Data.SqlClient;

namespace QLKS
{
    public partial class FormDangNhap : Form
    {
        string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc chắn muốn thoát?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu người dùng chưa nhập tài khoản hoặc mật khẩu
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            //string query = "SELECT MaNhanVien FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
            string query = "SELECT * FROM dbo.DangNhap(@username, @password)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtTaiKhoan.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtMatKhau.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value) // Nếu tìm thấy tài khoản
                        {
                            string connStr = dt.Rows[0][0].ToString();
                            DBConnection.ConnectionString = connStr;

                            int maNhanVien = int.Parse(dt.Rows[0][1].ToString());
                            FormChinh form2 = new FormChinh(maNhanVien); // Truyền id vào FormChinh
                            form2.Show();
                            this.Hide();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng! Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTaiKhoan.Focus();
                        }
                        //SqlDataReader reader = cmd.ExecuteReader();
                        //if (reader.Read()) // Nếu tìm thấy tài khoản
                        //{
                        //    int maNhanVien = reader.GetInt32(0); // Lấy giá trị cột id
                        //    reader.Close(); // Đóng reader trước khi mở form mới

                            //    FormChinh form2 = new FormChinh(maNhanVien); // Truyền id vào FormChinh
                            //    form2.Show();
                            //    this.Hide();
                            //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến hệ thống! Vui lòng thử lại sau.\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void lbForgotPass_Click(object sender, EventArgs e)
        {
            FormQuenMatKhau frm = new FormQuenMatKhau();
            frm.Show();
            this.Hide();
        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

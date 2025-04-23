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
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SỬA LẠI DÒNG NÀY
            string query = "sp_DangNhap";

            using (SqlConnection conn = DBConnection.GetConnection())
            {   
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@username", txtTaiKhoan.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtMatKhau.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                        {
                            DBConnection.ConnectionString = dt.Rows[0]["connectionString"].ToString();
                            UserSession.Id = int.Parse(dt.Rows[0]["maNhanVien"].ToString());
                            UserSession.Role = dt.Rows[0]["VaiTro"].ToString();

                            FormChinh form2 = new FormChinh(UserSession.Id);
                            form2.Show();
                            this.Hide();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng! Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTaiKhoan.Focus();
                        }
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

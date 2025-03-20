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

namespace QLKS
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        public int id;
        
        public bool Login()
        {
            return AccountDAO.Instance.Login(txtTaiKhoan.Text, txtMatKhau.Text);
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

        private void txtDangNhap_Click(object sender, EventArgs e)
        {
            if (Login())
            {

                string query = "SELECT idStaff FROM Account WHERE userName = '" + txtTaiKhoan.Text + "'";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                
                int id = Convert.ToInt32(data.Rows[0]["idStaff"]);
                Console.WriteLine("Số dòng trả về: " + id.ToString());

                FormChinh form2 = new FormChinh(id);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!!!", "Thông báo");
                this.txtTaiKhoan.Focus();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                txtDangNhap_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

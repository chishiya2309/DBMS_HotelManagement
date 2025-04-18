using BLL;
using BLL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLKS
{
    public partial class AddCustomer: Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;DataBase=Hotel2025;Integrated Security=True";
        public AddCustomer()
        {
            InitializeComponent();
            cbSex.SelectedIndex = 0;
            cbType.SelectedIndex = 1;
            cmbTinhTrang.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Now.AddYears(-20);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void InsertCustomer()
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                string hoTen = txtHoten.Text.Trim();
                string gioiTinh = cbSex.Text;
                string diaChi = txtAddress.Text.Trim();
                string cccd = txtIDNum.Text.Trim();
                if (DateTime.TryParse(dtpDOB.Text.Trim(), out DateTime ngaySinh))
                {
                    // Thành công: ngaySinh đã được gán giá trị hợp lệ
                }
                else
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string email = txtEmail.Text.Trim();
                string soDienThoai = txtPhone.Text.Trim();
                string loaiKhachHang = cbType.Text;
                string trangThai = cmbTinhTrang.Text;

                CustomerDAO.Instance.InsertCustomer(hoTen, gioiTinh, ngaySinh, cccd, diaChi, soDienThoai, email, loaiKhachHang, trangThai);
                ClearForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtHoten.ResetText();
            txtAddress.ResetText();
            txtIDNum.ResetText();
            txtEmail.ResetText();
            txtPhone.ResetText();
        }

        private bool ValidateInputs()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoten.Focus();
                return false;
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Kiểm tra định dạng số điện thoại
            string phonePattern = @"^0\d{9,10}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Số điện thoại phải bắt đầu bằng số 0 và có tối đa 10 chữ số.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra định dạng email
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
           

            //Kiểm tra địa chỉ
            if(string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                InsertCustomer();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

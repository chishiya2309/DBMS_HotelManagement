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

namespace QLKS
{
    public partial class FormThongTin: Form
    {
        
        public FormThongTin(int id)
        {
            InitializeComponent();
            LoadProfile(id);
            idStaff = id;
        }

        public int idStaff;
        private DataTable acc;

        public void LoadProfile(int id)
        {

            Staff staff = StaffDAO.Instance.LoadStaffInforById(id);
            acc = AccountDAO.Instance.GetAccountById(id);

            label1.Text = staff.Fullname;
            txtUser.Text = acc.Rows[0]["userName"].ToString();
            txtName.Text = staff.Fullname;
            txtIDNum.Text = staff.IdNumber;
            txtAddress.Text = staff.Address;
            txtPhone.Text = staff.Phone;
            dobDP.Value = staff.DoB;
            txtEmail.Text = staff.Email;
            cbSex.Text = staff.Sex;
            txtStartDay.Text = staff.StartDay.ToShortDateString();

            txtUser.Enabled = false;
            txtStartDay.Enabled = false;
            
        }

        public void UpdateInfo(int idStaff, string fullName, string sex, DateTime dateofBirth, string address, string CCCD, string email, string phonenumber)
        {
            StaffDAO.Instance.UpdateInfo(idStaff,fullName, sex, dateofBirth, CCCD, address, email, phonenumber);
        }

        public void UpdatePassword(string username, string password)
        {
            AccountDAO.Instance.UpdatePassword(username, password);
        }

        private void FormThongTin_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void SaveInfobtn_Click(object sender, EventArgs e)
        {
            if (txtPasspre.Text == acc.Rows[0]["password"].ToString())
            {
                try
                {
                    UpdateInfo(idStaff, txtName.Text, cbSex.Text, dobDP.Value, txtIDNum.Text, txtAddress.Text,txtEmail.Text, txtPhone.Text);
                    MessageBox.Show("Cập nhật thông tin cơ bản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPasspre.Text = String.Empty;
                    LoadProfile(idStaff);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Thông tin không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đúng mật khẩu hiện tại để xác minh!", "Thông báo");
                this.txtPasspre.Focus();
            }
            
        }

        private void SavePassbtn_Click(object sender, EventArgs e)
        {
            if (txtPasspre.Text == acc.Rows[0]["password"].ToString())
            {
                try
                {
                    if (txtPassnew.Text == txtPasscon.Text)
                    {
                        UpdatePassword(txtUser.Text,txtPassnew.Text);
                        MessageBox.Show("Cập nhật mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPasspre.Text = txtPassnew.Text = txtPasscon.Text = String.Empty;
                        LoadProfile(idStaff);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới phải khớp mật khẩu xác nhận lại!", "Thông báo");
                        this.txtPasscon.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Cần nhập mật khẩu mới trên 6 ký tự!: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else{
                MessageBox.Show("Bạn cần nhập đúng mật khẩu hiện tại để xác minh!", "Thông báo");
                this.txtPasspre.Focus();
            }
        }
    }
}

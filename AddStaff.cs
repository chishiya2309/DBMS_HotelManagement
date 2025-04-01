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
    public partial class AddStaff: Form
    {
        public AddStaff()
        {
            InitializeComponent();
            LoadFullRole();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        public DataTable GetFullRole()
        {
            return RolesDAO.Instance.LoadAllRole();
        }

        private void LoadFullRole()
        {
            cbSex.SelectedIndex = 0;
            DataTable table = GetFullRole();
            cbRole.DataSource = table;
            cbRole.DisplayMember = "name";
            if (table.Rows.Count > 0) cbRole.SelectedIndex = 0;
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            cbSex.SelectedIndex = 0;
        }

        private Staff GetStaffNow()
        {
            Staff account = new Staff();

            // Xoá các khoảng trắng thừa
            //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



            int index = cbRole.SelectedIndex;
            account.IdRole = (int)((DataTable)cbRole.DataSource).Rows[index]["idRole"];
            account.Fullname = txtName.Text;
            account.IdNumber = txtIDNum.Text;
            account.Sex = cbSex.Text;
            account.DoB = dtpDOB.Value;
            account.Phone = txtPhone.Text;
            account.Address = txtAddress.Text;
            account.StartDay = DateTime.Now;
            account.Email = txtEmail.Text;
            return account;
        }

        private void InsertStaff()
        {
            bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtName, txtAddress, txtEmail, txtIDNum, txtPhone, txtUser, cbSex, txtPass });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //int idStaff = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);
                    bool check1 = StaffDAO.Instance.InsertStaff(GetStaffNow());

                    bool check2 = AccountDAO.Instance.InsertAccount(txtUser.Text, txtPass.Text);
                    if (check1 && check2)
                    {
                        MessageBox.Show("Thêm tk thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Không thể Thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm nhân viên mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                InsertStaff();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class AddCustomer: Form
    {
        public AddCustomer()
        {
            InitializeComponent();
            LoadFullCustomerType();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }

        private void LoadFullCustomerType()
        {
            cbSex.SelectedIndex = 0;
            DataTable table = GetFullCustomerType();
            cbType.DataSource = table;
            cbType.DisplayMember = "typeName";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            cbSex.SelectedIndex = 1;
        }

        private Customer GetCustomerNow()
        {
            Customer account = new Customer();

            // Xoá các khoảng trắng thừa
            //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



            int index = cbType.SelectedIndex;
            
            account.IdCustomerType = (int)((DataTable)cbType.DataSource).Rows[index]["idCustomerType"];
            account.Name = txtName.Text;
            account.IdCard = txtIDNum.Text;
            account.Sex = cbSex.Text;
            account.DateOfBirth = dtpDOB.Value;
            account.PhoneNumber = txtPhone.Text;
            account.Address = txtAddress.Text;
            account.Email = txtEmail.Text;
            return account;
        }

        private void InsertCustomer()
        {
            bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtName, txtPhone, cbSex });
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
                    bool check1 = CustomerDAO.Instance.InsertCustomer(GetCustomerNow());

                    
                    if (check1)
                    {
                        MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            DialogResult result = MessageBox.Show("Bạn có muốn thêm khách hàng mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                InsertCustomer();
            }
        }
    }
}

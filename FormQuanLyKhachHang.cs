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
    public partial class FormQuanLyKhachHang: Form
    {
        public FormQuanLyKhachHang()
        {
            InitializeComponent();
            LoadFullCustomerType();
            LoadFullCustomer(GetFullCustomer());
            
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        public DataTable GetFullCustomer()
        {
            return CustomerDAO.Instance.LoadFullCustomer();
        }



        public DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }

        private void LoadFullCustomer(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dgvCustomer.DataSource = source;
        }

        private void LoadFullCustomerType()
        {
            cbSex.SelectedIndex = 0;
            DataTable table = GetFullCustomerType();
            cbType.DataSource = table;
            cbType.DisplayMember = "typeName";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }


        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtIDnum.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                lbEmail.Text = string.Empty;

            }
            else
            {

                txtAddress.Text = row.Cells["dgvAddress"].Value as string;
                txtEmail.Text = row.Cells["dgvEmail"].Value as string;
                txtIDnum.Text = row.Cells["dgvIDcard"].Value as string;
                txtPhone.Text = row.Cells["dgvPhone"].Value as string;
                txtName.Text = row.Cells["dgvName"].Value as string;
                if (DateTime.TryParse(row.Cells["dgvDob"].Value?.ToString(), out DateTime dob))
                {
                    dtpDoB.Value = dob;
                }
                else
                {
                    dtpDoB.Value = DateTime.Now; // Gán giá trị mặc định nếu không hợp lệ
                }

                
                cbSex.Text = row.Cells["dgvSex"].Value as string;
                cbType.SelectedIndex = (int)row.Cells["dgvType"].Value - 1;


            }
        }

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomer.SelectedRows[0];
                ChangeText(row);
            }
        }

        private Customer GetCustomerNow(int id)
        {
            Customer account = new Customer();

            // Xoá các khoảng trắng thừa
            //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



            int index = cbType.SelectedIndex;
            account.Id = id;
            account.IdCustomerType = (int)((DataTable)cbType.DataSource).Rows[index]["idCustomerType"];
            account.Name = txtName.Text;
            account.IdCard = txtIDnum.Text;
            account.Sex = cbSex.Text;
            account.DateOfBirth = dtpDoB.Value;
            account.PhoneNumber = txtPhone.Text;
            account.Address = txtAddress.Text;
            account.Email = txtEmail.Text;
            return account;
        }

        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }

        private void UpdateCustomer()
        {
            bool isFill = CheckFillInText(new Control[] { txtName, txtPhone,  cbSex });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    int idCustomer = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["dgvIdcustomer"].Value);
                    bool check1 = CustomerDAO.Instance.UpdateCustomer(GetCustomerNow(idCustomer));

                    
                    if (check1)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int index = dgvCustomer.SelectedRows[0].Index;
                        LoadFullCustomer(GetFullCustomer());
                        dgvCustomer.SelectedRows[0].Selected = false;
                        dgvCustomer.Rows[index].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                UpdateCustomer();

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            LoadFullCustomer(GetFullCustomer());
        }

        public bool DeleteCustomer(int id)
        {
            return CustomerDAO.Instance.DeleteCustomer(id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá khách hàng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                try
                {
                    int id = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["dgvIdcustomer"].Value);
                    if (DeleteCustomer(id))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFullCustomer(GetFullCustomer());
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá khách hàng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFullCustomer(CustomerDAO.Instance.Search(txtSearch.Text, cbSearchType.SelectedIndex));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex);
            }
        }
    }
}

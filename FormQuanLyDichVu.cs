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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormQuanLyDichVu: Form
    {
        public FormQuanLyDichVu()
        {
            InitializeComponent();
            LoadFullServiceType();
            LoadFullService(GetFullService());
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable GetFullService()
        {
            return ServiceDAO.Instance.LoadFullService();
        }



        public DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }

        private void LoadFullService(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dgvService.DataSource = source;
        }

        private void LoadFullServiceType()
        {
            cbStatus.SelectedIndex = 0;
            DataTable table = GetFullServiceType();
            cbType.DataSource = table;
            cbType.DisplayMember = "name";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                

            }
            else
            {
                
                txtId.Text = row.Cells["dgvIdservice"].Value.ToString();
                txtName.Text = row.Cells["dgvName"].Value as string;
                txtPrice.Text = row.Cells["dgvPrice"].Value.ToString();
                
                cbStatus.Text = row.Cells["dgvStatus"].Value as string;
                cbType.SelectedIndex = (int)row.Cells["dgvIdType"].Value - 1;


            }
        }

        private void dgvService_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvService.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvService.SelectedRows[0];
                ChangeText(row);
            }
        }

        //private Service GetServiceNow()
        //{
        //    Service account = new Service();

        //    // Xoá các khoảng trắng thừa
        //    //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



        //    int index = cbType.SelectedIndex;
        //    account.Id = Convert.ToInt32(txtId.Text);
        //    account.IdServiceType = (int)((DataTable)cbType.DataSource).Rows[index]["id"];
        //    account.Name = txtName.Text;
        //    account.Price = Convert.ToDouble(txtPrice.Text);
        //    account.Status = cbStatus.Text;
            
        //    return account;
        //}

        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }

        private void UpdateStaff()
        {
            bool isFill = CheckFillInText(new Control[] { txtName, txtId, txtPrice  });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //int idStaff = Convert.ToInt32(dgvService.SelectedRows[0].Cells["dgvIdservice"].Value);
                    int index = cbType.SelectedIndex;
                    bool check1 = ServiceDAO.Instance.UpdateService(int.Parse(txtId.Text),txtName.Text, (int)((DataTable)cbType.DataSource).Rows[index]["id"],
                                    double.Parse(txtPrice.Text),cbStatus.Text);

                    
                    if (check1 )
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int index2 = dgvService.SelectedRows[0].Index;
                        LoadFullService(GetFullService());
                        dgvService.SelectedRows[0].Selected = false;
                        dgvService.Rows[index2].Selected = true;
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
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật dịch vụ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                UpdateStaff();

            }
        }

        private void FormQuanLyDichVu_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddService().ShowDialog();
            LoadFullService(GetFullService());
        }

        public bool DeleteService(int id)
        {
            return ServiceDAO.Instance.DeleteService(id);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá dịch vụ này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                try
                {
                    int id = Convert.ToInt32(dgvService.CurrentRow.Cells["dgvIdservice"].Value);
                    if (DeleteService(id))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadFullService(GetFullService());
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá dịch vụ này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                LoadFullService(ServiceDAO.Instance.Search(txtSearch.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex);
            }
        }
    }
}

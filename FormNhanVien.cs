using BLL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace QLKS
{
    public partial class FormNhanVien: Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        public FormNhanVien()
        {
            InitializeComponent();
            LoadData();
            //LoadFullRole();
            //LoadFullStaff(GetFullStaff());
        }

        private void LoadData()
        {
            string query = @"SELECT * FROM NhanVien";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvStaff.DataSource = dt; // Gán dữ liệu vào DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Refresh the DataGridView
            dgvStaff.Refresh();
        }     

        //private void LoadFullStaff(DataTable table)
        //{
        //    BindingSource source = new BindingSource();
        //    source.DataSource = table;
        //    dgvStaff.DataSource = source;
        //}

        //private void LoadFullRole()
        //{
        //    cbSex.SelectedIndex = 0;
        //    DataTable table = GetFullRole();
        //    cbRole.DataSource = table;
        //    cbRole.DisplayMember = "name";
        //    if (table.Rows.Count > 0) cbRole.SelectedIndex = 0;
        //}

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ChangeText(DataGridViewRow row)
        {
            //if (row.IsNewRow)
            //{
            //    txtUser.Text = string.Empty;
            //    txtName.Text = string.Empty;
            //    txtIDNum.Text = string.Empty;
            //    txtPhone.Text = string.Empty;
            //    txtAddress.Text = string.Empty;
            //    txtEmail.Text = string.Empty;

            //}
            //else
            //{
            //    int idStaff = Convert.ToInt32(row.Cells["colidStaff"].Value);
            //    DataTable acc = AccountDAO.Instance.GetAccountById(idStaff);
                 
                
            //    txtUser.Text = acc.Rows[0]["username"].ToString();
            //    txtAddress.Text = row.Cells["colAddress"].Value as string;
            //    txtEmail.Text = row.Cells["colEmail"].Value as string;
            //    txtIDNum.Text = row.Cells["colIDnum"].Value as string;
            //    txtPhone.Text = row.Cells["colPhone"].Value as string;
            //    txtName.Text = row.Cells["colName"].Value as string;
            //    if (DateTime.TryParse(row.Cells["colDoB"].Value?.ToString(), out DateTime dob))
            //    {
            //        dtpDOB.Value = dob;
            //    }
            //    else
            //    {
            //        dtpDOB.Value = DateTime.Now; // Gán giá trị mặc định nếu không hợp lệ
            //    }

            //    if (DateTime.TryParse(row.Cells["colStart"].Value?.ToString(), out DateTime startDay))
            //    {
            //        dtpStartday.Value = startDay;
            //    }
            //    else
            //    {
            //        dtpStartday.Value = DateTime.Now; // Gán giá trị mặc định nếu không hợp lệ
            //    }
            //    cbSex.Text = row.Cells["colSex"].Value as string;
            //    cbRole.SelectedIndex = (int)row.Cells["colRole"].Value - 1;
                

            //}
        }

        //public bool DeleteStaff(int id)
        //{
        //    return StaffDAO.Instance.DeleteStaff(id);
        //}

        // Delete
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn chắc chắn xoá nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (result == DialogResult.OK)
            //{

            //    try
            //    {
            //        int id = Convert.ToInt32(dgvStaff.CurrentRow.Cells["colidStaff"].Value);
            //        if (DeleteStaff(id))
            //        {
            //            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            LoadFullStaff(GetFullStaff());
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không thể xoá nhân viên này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        }

            //    }
            //    catch (SqlException ex)
            //    {
            //        MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
        }

        //internal static void Trim(System.Windows.Forms.TextBox[] textboxes)
        //{
        //    for (int i = 0; i < textboxes.Length; i++)
        //    {
        //        textboxes[i].Text = textboxes[i].Text.Trim();
        //    }
        //}

        //private Staff GetStaffNow(int id)
        //{
        //    Staff account = new Staff();

        //    // Xoá các khoảng trắng thừa
        //    //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



        //    int index = cbRole.SelectedIndex;
        //    account.IdStaff = id;
        //    account.IdRole = (int)((DataTable)cbRole.DataSource).Rows[index]["idRole"];
        //    account.Fullname = txtName.Text;
        //    account.IdNumber = txtIDNum.Text;
        //    account.Sex = cbSex.Text;
        //    account.DoB = dtpDOB.Value;
        //    account.Phone = txtPhone.Text;
        //    account.Address = txtAddress.Text;
        //    account.StartDay = dtpStartday.Value;
        //    account.Email = txtEmail.Text;
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

        //private void UpdateStaff()
        //{
        //    bool isFill = CheckFillInText(new Control[] { txtName, txtAddress, txtEmail , txtIDNum , txtPhone , txtUser, cbSex});
        //    if (!isFill)
        //    {
        //        MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            int idStaff = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["colidStaff"].Value);
        //            bool check1 = StaffDAO.Instance.UpdateStaff(GetStaffNow(idStaff));

        //            bool check2 = AccountDAO.Instance.UpdateUsername(txtUser.Text, idStaff);
        //            if (check1 && check2)
        //            {
        //                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                int index = dgvStaff.SelectedRows[0].Index;
        //                LoadFullStaff(GetFullStaff());
        //                dgvStaff.SelectedRows[0].Selected = false;
        //                dgvStaff.Rows[index].Selected = true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        private void datagridviewStaff_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvStaff.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = dgvStaff.SelectedRows[0];
            //    ChangeText(row);
            //}
        }

        // Update
        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có muốn cập nhật nhân viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (result == DialogResult.OK)
            //{
                
            //    UpdateStaff();
                
            //}
        }

        // Insert
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            AddStaff addStaff = new AddStaff();
            addStaff.ShowDialog();
            // Luôn tải lại dữ liệu khi form AddStaff đóng
            LoadData();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadFullStaff(StaffDAO.Instance.Search(txtSearch.Text));
            //}
            //catch(SqlException ex)
            //{
            //    MessageBox.Show("Lỗi xảy ra: " + ex);
            //}
        }
    }
}

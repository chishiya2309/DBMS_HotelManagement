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
        private string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        public FormQuanLyKhachHang()
        {
            InitializeComponent();
            LoadCusData();
        }

        private void LoadCusData()
        {
            string query = @"SELECT * FROM KhachHang";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvCustomer.DataSource = dt; // Gán dữ liệu vào DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Refresh the DataGridView
            dgvCustomer.Refresh();
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

        

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvCustomer.SelectedRows[0];

                    // Hiển thị thông tin phòng được chọn trực tiếp lên form
                    txtTenKhachHang.Text = row.Cells["Hoten"].Value?.ToString() ?? "";
                    txtDiaChi.Text = row.Cells["Diachi"].Value?.ToString() ?? "";
                    cbSex.Text = row.Cells["Gioitinh"].Value?.ToString() ?? "";
                    txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                    txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
                    txtPhone.Text = row.Cells["Sodienthoai"].Value?.ToString() ?? "";
                    if (row.Cells["Ngaysinh"].Value != null && DateTime.TryParse(row.Cells["Ngaysinh"].Value.ToString(), out DateTime ngaySinh))
                    {
                        dtpDoB.Value = ngaySinh;
                    }
                    else
                    {
                        dtpDoB.Value = DateTime.Now; // Giá trị mặc định nếu không hợp lệ
                    }
                    cbType.Text = row.Cells["LoaiKhachHang"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void UpdateCustomer()
        //{
        //    bool isFill = CheckFillInText(new Control[] { txtName, txtPhone,  cbSex });
        //    if (!isFill)
        //    {
        //        MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            int idCustomer = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["dgvIdcustomer"].Value);
        //            bool check1 = CustomerDAO.Instance.UpdateCustomer(GetCustomerNow(idCustomer));

                    
        //            if (check1)
        //            {
        //                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                int index = dgvCustomer.SelectedRows[0].Index;
        //                LoadFullCustomer(GetFullCustomer());
        //                dgvCustomer.SelectedRows[0].Selected = false;
        //                dgvCustomer.Rows[index].Selected = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có muốn cập nhật khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (result == DialogResult.OK)
            //{

            //    UpdateCustomer();

            //}
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            LoadCusData();
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn chắc chắn xoá khách hàng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (result == DialogResult.OK)
            //{

            //    try
            //    {
            //        int id = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["dgvIdcustomer"].Value);
            //        if (DeleteCustomer(id))
            //        {
            //            MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            LoadFullCustomer(GetFullCustomer());
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không thể xoá khách hàng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        }

            //    }
            //    catch (SqlException ex)
            //    {
            //        MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    LoadFullCustomer(CustomerDAO.Instance.Search(txtSearch.Text, cbSearchType.SelectedIndex));
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Lỗi xảy ra: " + ex);
            //}
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}

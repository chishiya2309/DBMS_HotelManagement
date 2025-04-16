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
    public partial class FormQuanLyKhachHang: Form
    {
        private string connectionString = "Data Source=(local);Initial Catalog=Hotel2025;Integrated Security=True";
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
                    cmbTrangThai.Text = row.Cells["TinhTrangDatPhong"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCustomer()
        {
            
                try
                {
                    // Lấy mã khách hàng của khách hàng được chọn
                    if (dgvCustomer.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int maKhachHang = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["MaKhachHang"].Value);

                    // Cập nhật thông tin khách hàng bằng stored procedure
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                            cmd.Parameters.AddWithValue("@Hoten", txtTenKhachHang.Text.Trim());
                            cmd.Parameters.AddWithValue("@Gioitinh", cbSex.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@Ngaysinh", dtpDoB.Value);
                            cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text.Trim());
                            cmd.Parameters.AddWithValue("@Sodienthoai", txtPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("@Diachi", txtDiaChi.Text.Trim());
                            cmd.Parameters.AddWithValue("@LoaiKhachHang", cbType.Text);
                            cmd.Parameters.AddWithValue("@TinhTrangDatPhong", cmbTrangThai.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Cập nhật thành công
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu
                    LoadCusData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin nhân viên này?",
               "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                UpdateCustomer();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            LoadCusData();
        }

       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá khách hàng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    int maKhachHang = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["MaKhachHang"].Value);
                    if (DeleteCus(maKhachHang))
                    {
                        MessageBox.Show($"Xoá khách hàng {maKhachHang} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCusData();
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

        public bool DeleteCus(int maKhachHang)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteCustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchString = txtSearch.Text.Trim();
                int searchMode = cbSearchType.SelectedIndex;

                if (string.IsNullOrEmpty(searchString))
                {
                    MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SearchCustomer", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@string", searchString);
                        cmd.Parameters.AddWithValue("@mode", searchMode);

                        try
                        {
                            DataTable dt = new DataTable();
                            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                                dgvCustomer.DataSource = dt;
                            }

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Tìm thấy {dt.Rows.Count} khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

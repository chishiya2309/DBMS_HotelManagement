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
        private string connectionString = "Data Source=(local);Initial Catalog=Hotel2025;Integrated Security=True";
        public FormNhanVien()
        {
            InitializeComponent();
            LoadData();
            txtUser.Enabled = false;
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool DeleteStaff(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNhanVien", id);
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
        // Delete
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    int id = Convert.ToInt32(dgvStaff.CurrentRow.Cells["MaNhanVien"].Value);
                    if (DeleteStaff(id))
                    {
                        MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá nhân viên này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void UpdateStaff()
        {
            bool isFill = CheckFillInText(new Control[] { txtName, txtAddress, txtEmail, txtIDNum, txtPhone, txtUser, cbSex });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    // Lấy ID của nhân viên được chọn
                    if (dgvStaff.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idStaff = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["MaNhanVien"].Value);

                    // Cập nhật thông tin nhân viên bằng stored procedure
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_UpdateStaff", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@MaNhanVien", idStaff);
                            cmd.Parameters.AddWithValue("@Hoten", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Gioitinh", cbSex.Text);
                            cmd.Parameters.AddWithValue("@Ngaysinh", dtpDOB.Value);
                            cmd.Parameters.AddWithValue("@CCCD", txtIDNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@Diachi", txtAddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@Sodienthoai", txtPhone.Text.Trim());
                            cmd.Parameters.AddWithValue("@Ngayvaolam", dtpStartday.Value);
                            cmd.Parameters.AddWithValue("@Vaitro", cbRole.Text);
                            cmd.Parameters.Add("@Chandung", SqlDbType.VarBinary).Value = DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Cập nhật thành công
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu
                    LoadData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void datagridviewStaff_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvStaff.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvStaff.SelectedRows[0];

                    // Hiển thị thông tin nhân viên được chọn trực tiếp lên form
                    txtName.Text = row.Cells["Hoten"].Value?.ToString() ?? "";
                    txtAddress.Text = row.Cells["Diachi"].Value?.ToString() ?? "";
                    txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                    txtIDNum.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
                    txtPhone.Text = row.Cells["Sodienthoai"].Value?.ToString() ?? "";

                    if (DateTime.TryParse(row.Cells["Ngaysinh"].Value?.ToString(), out DateTime dob))
                    {
                        dtpDOB.Value = dob;
                    }
                    else
                    {
                        dtpDOB.Value = DateTime.Now;
                    }

                    if (DateTime.TryParse(row.Cells["Ngayvaolam"].Value?.ToString(), out DateTime startDay))
                    {
                        dtpStartday.Value = startDay;
                    }
                    else
                    {
                        dtpStartday.Value = DateTime.Now;
                    }

                    cbSex.Text = row.Cells["Gioitinh"].Value?.ToString() ?? "";
                    cbRole.Text = row.Cells["Vaitro"].Value?.ToString() ?? "";

                    // Lấy tên đăng nhập của nhân viên
                    if (int.TryParse(row.Cells["MaNhanVien"].Value?.ToString(), out int idStaff))
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "SELECT TenDangNhap FROM TaiKhoan WHERE MaNhanVien = @MaNV";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaNV", idStaff);
                                object result = cmd.ExecuteScalar();
                                txtUser.Text = result != null ? result.ToString() : "";
                            }
                        }
                    }
                    else
                    {
                        txtUser.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Update
        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin nhân viên này?",
                "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                UpdateStaff();
            }
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
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_SearchStaffByName", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Hoten", txtSearch.Text.Trim());

                        DataTable dt = new DataTable();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                            dgvStaff.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSeach.PerformClick();
            }
        }
    }
}

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
        private string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        public AddStaff()
        {
            InitializeComponent();
            cbSex.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;
            dtpDOB.Value = DateTime.Now.AddYears(-20);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            
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
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Bắt đầu transaction
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Thêm nhân viên sử dụng stored procedure sp_InsertStaff
                            SqlCommand cmdStaff = new SqlCommand("sp_InsertStaff", connection, transaction);
                            cmdStaff.CommandType = CommandType.StoredProcedure;

                            cmdStaff.Parameters.AddWithValue("@Hoten", txtName.Text.Trim());
                            cmdStaff.Parameters.AddWithValue("@Gioitinh", cbSex.Text);
                            cmdStaff.Parameters.AddWithValue("@Ngaysinh", dtpDOB.Value);
                            cmdStaff.Parameters.AddWithValue("@CCCD", txtIDNum.Text.Trim());
                            cmdStaff.Parameters.AddWithValue("@Diachi", txtAddress.Text.Trim());
                            cmdStaff.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            cmdStaff.Parameters.AddWithValue("@Sodienthoai", txtPhone.Text.Trim());
                            cmdStaff.Parameters.AddWithValue("@Ngayvaolam", dtpNgayVaoLam.Value);
                            cmdStaff.Parameters.AddWithValue("@Vaitro", cbRole.Text);

                            cmdStaff.ExecuteNonQuery();

                            // Lấy MaNhanVien vừa thêm để tạo tài khoản
                            SqlCommand getStaffIdCmd = new SqlCommand("SELECT IDENT_CURRENT('NhanVien')", connection, transaction);
                            int staffId = Convert.ToInt32(getStaffIdCmd.ExecuteScalar());

                            // Thêm tài khoản sử dụng stored procedure sp_InsertAccount
                            SqlCommand cmdAccount = new SqlCommand("sp_InsertAccount", connection, transaction);
                            cmdAccount.CommandType = CommandType.StoredProcedure;

                            cmdAccount.Parameters.AddWithValue("@MaNhanVien", staffId);
                            cmdAccount.Parameters.AddWithValue("@TenDangNhap", txtUser.Text.Trim());
                            cmdAccount.Parameters.AddWithValue("@MatKhau", txtPass.Text.Trim());

                            cmdAccount.ExecuteNonQuery();

                            // Commit transaction nếu cả hai thao tác thành công
                            transaction.Commit();
                            MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                        catch (SqlException ex)
                        {
                            // Rollback transaction nếu có lỗi
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtIDNum.Clear();
            txtPhone.Clear();
            txtUser.Clear();
            txtPass.Clear();
            cbSex.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;
            dtpDOB.Value = DateTime.Now.AddYears(-20);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Đặt DialogResult.OK để form cha biết cần refresh dữ liệu
            this.Close();
        }
    }
}

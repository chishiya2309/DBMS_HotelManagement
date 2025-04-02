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
    public partial class UpdateRoom: Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;Database=Hotel2025;Integrated Security=True";
        private string maPhong;
        private DataRow phongData;
        public UpdateRoom(string maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
            LoadRoomType();
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy tất cả phòng
                    string query = "SELECT * FROM Phong";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Phong");

                    DataTable dtPhong = ds.Tables["Phong"];

                    // Tìm phòng cần chỉnh sửa
                    foreach (DataRow r in dtPhong.Rows)
                    {
                        if (r["MaPhong"].ToString() == maPhong)
                        {
                            phongData = r;
                            break;
                        }
                    }

                    if (phongData == null)
                    {
                        MessageBox.Show("Không tìm thấy phòng cần chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }

                    // Điền dữ liệu vào các control
                    txtMaPhong.Text = phongData["MaPhong"].ToString();
                    txtMaPhong.ReadOnly = true; // Không cho phép sửa mã phòng
                    txtTenPhong.Text = phongData["TenPhong"].ToString();
                    nudSoGiuong.Value = Convert.ToDecimal(phongData["SoGiuong"]);
                    cmbLoaiGiuong.Text = phongData["LoaiGiuong"].ToString();
                    txtKhuVuc.Text = phongData["KhuVuc"].ToString();
                    cmbTrangThai.Text = phongData["TrangThai"].ToString();
                    cmbLoaiPhong.SelectedValue = phongData["MaLoaiPhong"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void LoadRoomType()
        {
            string query = @"SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cmbLoaiPhong.DisplayMember = "TenLoaiPhong";
                        cmbLoaiPhong.ValueMember = "MaLoaiPhong";
                        cmbLoaiPhong.DataSource = dt; // Gán dữ liệu vào DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateRoom_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ValidateInputs())
            {
                return;
            }

            try
            {
                int maPhong = Convert.ToInt32(txtMaPhong.Text);
                string tenPhong = txtTenPhong.Text.Trim();
                int soGiuong = Convert.ToInt32(nudSoGiuong.Value);
                string loaiGiuong = cmbLoaiGiuong.Text;
                int khuVuc = Convert.ToInt32(txtKhuVuc.Text);
                string trangThai = cmbTrangThai.Text;
                string maLoaiPhong = (string)cmbLoaiPhong.SelectedValue;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    SqlCommand cmdRoom = new SqlCommand("sp_UpdateRoom", connection);
                    cmdRoom.CommandType = CommandType.StoredProcedure;
                    cmdRoom.Parameters.AddWithValue("@idRoom", maPhong);
                    cmdRoom.Parameters.AddWithValue("@name", tenPhong);
                    cmdRoom.Parameters.AddWithValue("@Beds", soGiuong);
                    cmdRoom.Parameters.AddWithValue("@BedType", loaiGiuong);
                    cmdRoom.Parameters.AddWithValue("@Floor", khuVuc);
                    cmdRoom.Parameters.AddWithValue("@Status", trangThai);
                    cmdRoom.Parameters.AddWithValue("@idRoomType", maLoaiPhong);
                    cmdRoom.ExecuteNonQuery();

                    MessageBox.Show($"Chỉnh sửa phòng {maPhong} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return false;
            }

            if (!int.TryParse(txtKhuVuc.Text, out _))
            {
                MessageBox.Show("Khu vực phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuVuc.Focus();
                return false;
            }
            return true;
        }

        private void cmbLoaiGiuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuongSach_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

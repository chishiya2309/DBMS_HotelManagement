using BLL;
using BLL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class UpdateRoomType: Form
    {
        private byte[] _currentImageBytes = null;
        private string _currentImagePath = null;
        public UpdateRoomType()
        {
            InitializeComponent();
            LoadMaPhong();
            if (cmbMaLoaiPhong.Items.Count > 0)
            {
                cmbMaLoaiPhong.SelectedIndex = 0;
                LoadFullRoomDetail();
            }
        }

        private void UpdateRoomType_Load(object sender, EventArgs e)
        {

        }

        private void LoadMaPhong()
        {
            try
            {
                DataTable table = RoomTypeDAO.Instance.GetAllRoomTypes();
                if (table.Rows.Count > 0)
                {
                    cmbMaLoaiPhong.DataSource = table;
                    cmbMaLoaiPhong.ValueMember = "MaLoaiPhong";
                    cmbMaLoaiPhong.DisplayMember = "MaLoaiPhong";
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu loại phòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFullRoomDetail()
        {
            if (cmbMaLoaiPhong.SelectedValue == null)
                return;

            try
            {
                string maLoaiPhong = cmbMaLoaiPhong.SelectedValue.ToString();
                RoomType roomType = RoomTypeDAO.Instance.GetRoomTypeById(maLoaiPhong);
                if (roomType != null)
                {
                    txtTenLoaiPhong.Text = roomType.TenLoaiPhong;
                    txtDonGia.Text = roomType.DonGia.ToString();
                    txtTienNghi.Text = roomType.TienNghi;
                    nudSucChua.Value = Convert.ToDecimal(roomType.SucChua);
                    ckbKhaNang.Checked = Convert.ToInt32(roomType.KhaNangKeThemGiuong) == 1;
                    txtMoTa.Text = roomType.MoTa;

                    // Xử lý hình ảnh từ VARBINARY
                    if (roomType.HinhAnh != null && roomType.HinhAnh.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(roomType.HinhAnh))
                        {
                            pictureBoxRoomType.Image = Image.FromStream(ms);
                            pictureBoxRoomType.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        pictureBoxRoomType.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void cmbMaLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFullRoomDetail();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                string maLoaiPhong = cmbMaLoaiPhong.SelectedValue.ToString();
                string tenLoaiPhong = txtTenLoaiPhong.Text;
                decimal donGia = decimal.Parse(txtDonGia.Text);
                string tienNghi = txtTienNghi.Text;
                int sucChua = (int)nudSucChua.Value;
                bool khaNangKeThemGiuong = ckbKhaNang.Checked;
                string moTa = txtMoTa.Text;
                byte[] hinhAnh = _currentImageBytes;

                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();


                    SqlCommand cmdRoomType = new SqlCommand("sp_UpdateRoomType", connection);
                    cmdRoomType.CommandType = CommandType.StoredProcedure;
                    cmdRoomType.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);
                    cmdRoomType.Parameters.AddWithValue("@TenLoaiPhong", tenLoaiPhong);
                    cmdRoomType.Parameters.AddWithValue("@DonGia", donGia);
                    cmdRoomType.Parameters.AddWithValue("@TienNghi", tienNghi);
                    cmdRoomType.Parameters.AddWithValue("@SucChua", sucChua);
                    cmdRoomType.Parameters.AddWithValue("@KhaNangKeThemGiuong", khaNangKeThemGiuong);
                    cmdRoomType.Parameters.AddWithValue("@MoTa", moTa);
                    cmdRoomType.Parameters.AddWithValue("@HinhAnh", hinhAnh);

                    cmdRoomType.ExecuteNonQuery();

                    MessageBox.Show($"Chỉnh sửa loại phòng {maLoaiPhong} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidateInputs()
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(txtTenLoaiPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiPhong.Focus();
                return false;
            }

            // Kiểm tra định dạng tiền
            if (!decimal.TryParse(txtDonGia.Text, out decimal DonGia))
            {
                MessageBox.Show("Vui lòng nhập đơn giá đúng định dạng tiền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            if (DonGia < 0)
            {
                MessageBox.Show("Đơn giá không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }
            return true;
        }

        private void btnEditPicrueRoomType_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình ảnh loại phòng";
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lưu đường dẫn hình ảnh
                        _currentImagePath = openFileDialog.FileName;
                        // Hiển thị hình ảnh được chọn trên PictureBox
                        pictureBoxRoomType.Image = Image.FromFile(openFileDialog.FileName);
                        pictureBoxRoomType.SizeMode = PictureBoxSizeMode.Zoom;

                        // Chuyển đổi hình ảnh thành byte array để lưu vào database
                        _currentImageBytes = File.ReadAllBytes(_currentImagePath);
                        
                         MessageBox.Show("Hình ảnh đã được chọn thành công! Nhấn Lưu để cập nhật vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi mở file hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

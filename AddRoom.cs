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
    public partial class AddRoom: Form
    {
        public AddRoom()
        {
            InitializeComponent();
            LoadRoomType();
            cmbLoaiGiuong.SelectedIndex = 0;
            txtKhuVuc.Text = "1";
            cmbTrangThai.SelectedIndex = 0;
            cmbLoaiPhong.SelectedIndex = 0;
        }

        private void InsertRoom()
        {
            if (!ValidateInputs())
            {
                return;
            }

            string tenPhong = txtName.Text.Trim();
            int soGiuong = Convert.ToInt32(nudSoGiuong.Value);
            string loaiGiuong = cmbLoaiGiuong.Text;
            int khuVuc = Convert.ToInt32(txtKhuVuc.Text);
            string trangThai = cmbTrangThai.Text;
            string maLoaiPhong = (string)cmbLoaiPhong.SelectedValue;

            bool result = RoomDAO.Instance.InsertRoom(tenPhong, soGiuong, loaiGiuong, khuVuc, trangThai, maLoaiPhong);

            if (result)
            {
                MessageBox.Show("Thêm phòng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
        }

        private bool ValidateInputs()
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm phòng mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                InsertRoom();
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            nudSoGiuong.Value = 1;
            cmbLoaiGiuong.SelectedIndex = 0;
            txtKhuVuc.Text = "1";
            cmbTrangThai.SelectedIndex = 0;
            cmbLoaiPhong.SelectedIndex = 0;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            new AddRoomType().ShowDialog();
            LoadRoomType();
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {

        }

        private void LoadRoomType()
        {
            try
            {
                DataTable dt = RoomTypeDAO.Instance.LoadFullRoomType();
                cmbLoaiPhong.DataSource = dt;
                cmbLoaiPhong.DisplayMember = "TenLoaiPhong";
                cmbLoaiPhong.ValueMember = "MaLoaiPhong";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

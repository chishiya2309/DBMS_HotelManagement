﻿using BLL;
using BLL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DAL;

namespace QLKS
{
    public partial class FormDatPhong : Form
    {
        private bool isInitializing = true;
        private bool isLoadingFromGrid = true;
        private bool isSelectingFromGrid = true;
        // Thêm biến để lưu trữ giá trị check-in ban đầu
        private DateTime originalCheckInDate;

        public FormDatPhong()
        {
            InitializeComponent();
            isLoadingFromGrid = true;  // Đánh dấu đang load từ grid
            isSelectingFromGrid = true; // Đánh dấu đang chọn từ grid

            LoadData();
            LoadFullRoomType();

            // Đăng ký sự kiện CellValueChanged cho DataGridView
            guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
            // Đăng ký sự kiện ValueChanged cho DateTimePicker
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;

            // Đăng ký sự kiện CellClick để xử lý khi click vào ô checkbox
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;

            // Vô hiệu hóa nút đặt phòng cho đến khi tìm thấy khách hàng
            btnBook.Enabled = false;

            // Thiết lập DropDownStyle cho các ComboBox
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            // Tự động chọn dòng đầu tiên trong dgvBookRoom nếu có dữ liệu
            if (dgvBookRoom.Rows.Count > 0)
            {
                dgvBookRoom.ClearSelection();
                dgvBookRoom.Rows[0].Selected = true;
                ChangeText(dgvBookRoom.Rows[0]);

                // Sau khi chọn hàng đầu tiên, đảm bảo LoadAvailableRooms được gọi để hiển thị đúng phòng
                LoadAvailableRooms();

                if (cbStatus.Text == "Đã xác nhận")
                {
                    dtpCheckIn.Enabled = false;
                }
                else
                {
                    btnCheckIn.Enabled = true;
                }
            }
            else
            {
                // Nếu không có dữ liệu đặt phòng, vẫn load danh sách phòng trống
                LoadAvailableRooms();

                // Chọn phòng đầu tiên nếu có
                if (cbRoom.Items.Count > 0)
                {
                    cbRoom.SelectedIndex = 0;
                }
            }

            // Đánh dấu quá trình khởi tạo đã hoàn tất
            isInitializing = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadFullRoomType()
        {
            try
            {
                DataTable dt = RoomTypeDAO.Instance.LoadFullRoomType();
                cbRoomType.DataSource = dt;
                cbRoomType.DisplayMember = "TenLoaiPhong";
                cbRoomType.ValueMember = "MaLoaiPhong";
                if (dt.Rows.Count > 0)
                    cbRoomType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBookingInputs(out int maKhachHangDaiDien, out List<int> danhSachThanhVien)
        {
            maKhachHangDaiDien = 0;
            danhSachThanhVien = new List<int>();
            if (string.IsNullOrEmpty(txtCustomerName.Text) || cbRoom.SelectedIndex < 0 || cbStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            bool hasRepresentative = false;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["dgvMaKH"].Value != null)
                {
                    int maKH = Convert.ToInt32(row.Cells["dgvMaKH"].Value);
                    danhSachThanhVien.Add(maKH);
                    if (row.Cells["dgvDaiDien"].Value != null && Convert.ToBoolean(row.Cells["dgvDaiDien"].Value))
                    {
                        hasRepresentative = true;
                        maKhachHangDaiDien = maKH;
                    }
                }
            }
            if (!hasRepresentative)
            {
                MessageBox.Show("Vui lòng chọn khách hàng đại diện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (danhSachThanhVien.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một khách hàng tham gia!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateRoomCapacity(int maPhong, int soThanhVien)
        {
            string maLoaiPhong = ((DataTable)cbRoom.DataSource).Rows[cbRoom.SelectedIndex]["MaLoaiPhong"].ToString();
            var roomType = BLL.DAO.RoomTypeDAO.Instance.GetRoomTypeById(maLoaiPhong);
            if (roomType == null)
            {
                MessageBox.Show("Không tìm thấy thông tin loại phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int tongSucChua = roomType.SucChua + (roomType.KhaNangKeThemGiuong ? 1 : 0);
            if (soThanhVien > tongSucChua)
            {
                MessageBox.Show($"Số lượng thành viên vượt quá sức chứa cho phép của loại phòng này! (Tối đa: {tongSucChua})", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void SelectNewBookingRow(int maHoSoDatPhong)
        {
            foreach (DataGridViewRow row in dgvBookRoom.Rows)
            {
                if (row.Cells["MaHoSoDatPhong"].Value.ToString() == maHoSoDatPhong.ToString())
                {
                    dgvBookRoom.ClearSelection();
                    row.Selected = true;
                    ChangeText(row);
                    LoadParticipantsForBooking(maHoSoDatPhong);
                    break;
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result != DialogResult.OK) return;

            int maKhachHangDaiDien;
            List<int> danhSachThanhVien;

            //Kiểm tra danh sách thành viên đã được chọn chưa
            if (!ValidateBookingInputs(out maKhachHangDaiDien, out danhSachThanhVien)) return;

            int maPhong = Convert.ToInt32(((DataTable)cbRoom.DataSource).Rows[cbRoom.SelectedIndex]["MaPhong"]);
            int soDem;
            if (!int.TryParse(txtDays.Text, out soDem) || soDem <= 0)
            {
                MessageBox.Show("Số đêm phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal tienDatCoc;
            if (!decimal.TryParse(txtDeposit.Text, out tienDatCoc) || tienDatCoc < 0)
            {
                MessageBox.Show("Tiền đặt cọc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string soTheTinDung = txtCreditCard.Text;
            string ghiChu = txtNotes.Text;
            string trangThaiDatPhong = cbStatus.Text;
            DateTime thoiGianCheckinDuKien = dtpCheckIn.Value;
            DateTime thoiGianCheckoutDuKien = dtpCheckOut.Value;

            //Kiểm tra sức chứa của loại phòng có đáp ứng được số lượng thành viên không
            if (!ValidateRoomCapacity(maPhong, danhSachThanhVien.Count)) return;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Đặt phòng
                    int maHoSoDatPhong = BookRoomDAO.Instance.InsertBooking(conn, transaction, maPhong, maKhachHangDaiDien, soTheTinDung, ghiChu, soDem, tienDatCoc, trangThaiDatPhong, thoiGianCheckinDuKien, thoiGianCheckoutDuKien);
                    // Thêm thành viên tham gia
                    BookRoomDAO.Instance.InsertParticipants(conn, transaction, maHoSoDatPhong, danhSachThanhVien);
                    transaction.Commit();
                    MessageBox.Show("Đặt phòng và thêm thành viên tham gia thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tải lại dữ liệu
                    LoadData();
                    // Chọn hồ sơ đặt phòng mới và load data cần thiết lên các dgv
                    SelectNewBookingRow(maHoSoDatPhong);
                    btnBook.Enabled = false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadAvailableRooms()
        {
            if (cbRoomType.SelectedIndex < 0)
            {
                return;
            }
            string maLoaiPhong = cbRoomType.SelectedValue.ToString();
            string tenPhongHienTai = cbRoom.Text;
            DataTable dt;

            // Lấy thông tin phòng hiện tại của hồ sơ đặt phòng (nếu có)
            string tenPhongHoSo = string.Empty;
            string maLoaiPhongHoSo = string.Empty;
            int maPhongHoSo = -1;

            if (!btnBook.Enabled && !string.IsNullOrEmpty(txtIdBookRoom.Text) && dgvBookRoom.SelectedRows.Count > 0)
            {
                tenPhongHoSo = dgvBookRoom.SelectedRows[0].Cells["TenPhong"].Value.ToString();
                maLoaiPhongHoSo = dgvBookRoom.SelectedRows[0].Cells["MaLoaiPhong"].Value.ToString();

                if (dgvBookRoom.SelectedRows[0].Cells["MaPhong"].Value != null)
                {
                    int.TryParse(dgvBookRoom.SelectedRows[0].Cells["MaPhong"].Value.ToString(), out maPhongHoSo);
                }
            }

            // Nếu đang xem hồ sơ đặt phòng và loại phòng không thay đổi
            if (!btnBook.Enabled && !string.IsNullOrEmpty(txtIdBookRoom.Text) &&
                maLoaiPhong == maLoaiPhongHoSo && isSelectingFromGrid)
            {
                // Lấy cả phòng của hồ sơ và các phòng trống cùng loại
                dt = RoomDAO.Instance.MergeRoomTables(maLoaiPhong, maPhongHoSo);
            }
            else
            {
                // Trường hợp thay đổi loại phòng hoặc đặt phòng mới, chỉ lấy phòng trống
                dt = RoomDAO.Instance.GetAvailableRoomsByType(maLoaiPhong);
            }

            // Lưu lại tên phòng hiện tại
            string currentRoom = tenPhongHienTai;

            // Cập nhật DataSource cho ComboBox
            cbRoom.DataSource = dt;
            cbRoom.DisplayMember = "TenPhong";
            cbRoom.ValueMember = "MaPhong";
            cbRoom.Enabled = dt.Rows.Count > 0;

            // Chỉ hiển thị thông báo khi không phải đang khởi tạo form
            if (dt.Rows.Count == 0 && !isInitializing)
            {
                MessageBox.Show("Không có phòng trống thuộc loại phòng này! Vui lòng chọn loại phòng khác.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (!btnBook.Enabled && isSelectingFromGrid)
            {
                // Nếu đang xem hồ sơ đặt phòng và loại phòng không thay đổi
                // thì cố gắng chọn lại phòng của hồ sơ
                if (!string.IsNullOrEmpty(tenPhongHoSo) && maLoaiPhong == maLoaiPhongHoSo)
                {
                    // Tìm và chọn phòng hiện tại của hồ sơ
                    for (int i = 0; i < cbRoom.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cbRoom.Items[i];
                        if (drv["TenPhong"].ToString() == tenPhongHoSo)
                        {
                            cbRoom.SelectedIndex = i;
                            break;
                        }
                    }

                    // Nếu không tìm thấy phòng của hồ sơ trong danh sách
                    if (cbRoom.SelectedIndex < 0 || cbRoom.Text != tenPhongHoSo)
                    {
                        // Nếu đang khởi tạo, chọn phòng đầu tiên
                        if (isInitializing && dt.Rows.Count > 0)
                        {
                            cbRoom.SelectedIndex = 0;
                        }
                        else
                        {
                            cbRoom.SelectedIndex = -1;
                            cbRoom.Text = "";
                        }
                    }
                }
                else
                {
                    // Nếu loại phòng thay đổi
                    if (isInitializing && dt.Rows.Count > 0)
                    {
                        // Khi khởi tạo, chọn phòng đầu tiên
                        cbRoom.SelectedIndex = 0;
                    }
                    else
                    {
                        // Không tự chọn phòng
                        cbRoom.SelectedIndex = -1;
                        cbRoom.Text = "";
                    }
                }
            }
            else
            {
                // Nếu đang đặt phòng mới
                if (dt.Rows.Count > 0 && isInitializing)
                {
                    // Khi khởi tạo, chọn phòng đầu tiên
                    cbRoom.SelectedIndex = 0;
                }
                else
                {
                    // Không tự chọn phòng đầu tiên
                    cbRoom.SelectedIndex = -1;
                    cbRoom.Text = "";
                }
            }
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Nếu thay đổi được kích hoạt bởi người dùng, đánh dấu không phải đang chọn từ grid
            if (sender != null && e != null && !isLoadingFromGrid)
            {
                isSelectingFromGrid = false;
            }

            // Khi đang chọn từ grid, LoadAvailableRooms sẽ dùng logic khác
            LoadAvailableRooms();
        }

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            txtCustomerName.Enabled = false;
            txtDays.Enabled = false;

            txtIdBookRoom.Enabled = false;
            isEditing = false;

            btnBook.Enabled = false;
        }

        // Tải danh sách thành viên tham gia đặt phòng
        private void LoadParticipantsForBooking(int maHoSoDatPhong)
        {
            try
            {
                DataTable dt = BookRoomDAO.Instance.GetParticipantsByBookingId(maHoSoDatPhong);
                // Tạm thởi tắt sự kiện CellValueChanged để tránh xung đột
                guna2DataGridView1.CellValueChanged -= guna2DataGridView1_CellValueChanged;

                // Xóa dữ liệu hiện tại và tạo dữ liệu mới
                guna2DataGridView1.Rows.Clear();

                foreach (DataRow dataRow in dt.Rows)
                {
                    int rowIndex = guna2DataGridView1.Rows.Add();
                    DataGridViewRow row = guna2DataGridView1.Rows[rowIndex];

                    row.Cells["dgvMaKH"].Value = dataRow["dgvMaKH"];
                    row.Cells["dgvTenKhachHang"].Value = dataRow["dgvTenKhachHang"];
                    row.Cells["dgvDaiDien"].Value = Convert.ToBoolean(dataRow["dgvDaiDien"]);
                }

                // Đăng ký lại sự kiện
                guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng tham gia: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = BookRoomDAO.Instance.GetBookRoomList();
                dgvBookRoom.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Sau khi tải dữ liệu xong, tự động chọn dòng đầu tiên
            if (dgvBookRoom.Rows.Count > 0 && !isInitializing)
            {
                dgvBookRoom.ClearSelection();
                dgvBookRoom.Rows[0].Selected = true;
                ChangeText(dgvBookRoom.Rows[0]);
                if (cbStatus.Text == "Đã xác nhận")
                {
                    dtpCheckIn.Enabled = false;
                }
                else
                {
                    btnCheckIn.Enabled = true;
                }
            }
        }

        private bool isUpdatingDates = false;

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadingFromGrid || isUpdatingDates) return; // Tránh xử lý đệ quy

            isUpdatingDates = true;
            try
            {
                // Đảm bảo ngày check-in không thể là ngày trong quá khứ
                if (dtpCheckIn.Value.Date < DateTime.Now.Date)
                {
                    dtpCheckIn.Value = DateTime.Now.Date;
                    MessageBox.Show("Ngày check-in không thể là ngày trong quá khứ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Nếu ngày check-in sau hoặc bằng ngày check-out, tự động điều chỉnh ngày check-out
                if (dtpCheckIn.Value.Date >= dtpCheckOut.Value.Date)
                {
                    // Tự động đặt check-out là ngày sau check-in
                    dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
                }

                // Cập nhật số đêm
                int days = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                txtDays.Text = days.ToString();
            }
            finally
            {
                isUpdatingDates = false;
            }
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (isLoadingFromGrid || isUpdatingDates) return;

            isUpdatingDates = true;
            try
            {
                // Đảm bảo ngày check-out sau ngày check-in ít nhất 1 ngày
                if (dtpCheckOut.Value.Date <= dtpCheckIn.Value.Date)
                {
                    dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
                    MessageBox.Show("Ngày check-out phải sau ngày check-in ít nhất 1 ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cập nhật số đêm
                int days = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days;
                txtDays.Text = days.ToString();
            }
            finally
            {
                isUpdatingDates = false;
            }
        }

        bool isEditing;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu hồ sơ đã ở trạng thái "Đã hoàn tất", không cho phép sửa
            if (cbStatus.Text == "Đã hoàn tất")
            {
                MessageBox.Show("Không thể sửa hồ sơ đặt phòng đã hoàn tất!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isEditing)
            {
                cbRoomType_SelectedIndexChanged(null, EventArgs.Empty);
                if (dgvBookRoom.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvBookRoom.SelectedRows[0];
                    ChangeText(row);
                }
                btnBook.Enabled = false;
                btnClose.Enabled = false;
                dtpCheckIn.Enabled = false;
                dtpCheckOut.Enabled = false;
                txtDeposit.Enabled = false;
                txtSearch.Enabled = false;
                isEditing = true;
                dgvBookRoom.Enabled = false;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật hồ sơ đặt phòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    originalCheckInDate = dtpCheckIn.Value;
                    UpdateBookRoom();
                    isEditing = false;
                    btnClose.Enabled = true;
                    dtpCheckIn.Enabled = true;
                    dtpCheckOut.Enabled = true;
                    txtDeposit.Enabled = true;
                    txtSearch.Enabled = true;
                    dgvBookRoom.Enabled = true;
                }
            }
        }

        private void UpdateBookRoom()
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(txtIdBookRoom.Text) || cbRoom.SelectedIndex == -1 ||
                string.IsNullOrEmpty(txtDeposit.Text) || string.IsNullOrEmpty(txtDays.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Lấy mã hồ sơ đặt phòng
                int maHoSoDatPhong = int.Parse(txtIdBookRoom.Text);

                // Lấy thông tin gốc từ cơ sở dữ liệu của hồ sơ đặt phòng
                DataTable originalData = GetOriginalBookingData(maHoSoDatPhong);
                if (originalData == null || originalData.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hồ sơ đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy trạng thái hiện rừ database
                string trangThaiHienTai = originalData.Rows[0]["TrangThaiDatPhong"].ToString();
                string trangThaiMoi = cbStatus.Text;

                // Kiểm tra nếu đang cố gắng cập nhật từ "Đã xác nhận" sang "Đã hủy"
                if (trangThaiHienTai == "Đã xác nhận" && trangThaiMoi == "Đã huỷ")
                {
                    MessageBox.Show("Không thể cập nhật hồ sơ từ trạng thái \"Đã xác nhận\" sang \"Đã huỷ\"!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã phòng từ ComboBox
                int maPhong = Convert.ToInt32(((DataTable)cbRoom.DataSource).Rows[cbRoom.SelectedIndex]["MaPhong"]);

                // Lấy mã khách hàng đại diện và danh sách thành viên
                string maKhachHangDaiDienStr = string.Empty;
                List<int> danhSachThanhVien = new List<int>();

                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (row.Cells["dgvMaKH"].Value != null)
                    {
                        int maKH = Convert.ToInt32(row.Cells["dgvMaKH"].Value);
                        danhSachThanhVien.Add(maKH);

                        if (row.Cells["dgvDaiDien"].Value != null && Convert.ToBoolean(row.Cells["dgvDaiDien"].Value))
                        {
                            maKhachHangDaiDienStr = maKH.ToString();
                        }
                    }
                }

                if (string.IsNullOrEmpty(maKhachHangDaiDienStr))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng đại diện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int maKhachHangDaiDien = int.Parse(maKhachHangDaiDienStr);

                if (danhSachThanhVien.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một khách hàng tham gia!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy các thông tin khác
                string soTheTinDung = txtCreditCard.Text;
                string ghiChu = txtNotes.Text;
                int soDem = int.Parse(txtDays.Text);
                decimal tienDatCoc = decimal.Parse(txtDeposit.Text);
                string trangThaiDatPhong = cbStatus.Text;

                // Lấy ngày check-in từ DB nếu control bị vô hiệu hóa
                DateTime thoiGianCheckinDuKien;
                DateTime thoiGianCheckoutDuKien;

                if (!dtpCheckIn.Enabled)
                {
                    // Sử dụng giá trị từ database
                    thoiGianCheckinDuKien = Convert.ToDateTime(originalData.Rows[0]["ThoiGianCheckinDuKien"]);
                    thoiGianCheckoutDuKien = Convert.ToDateTime(originalData.Rows[0]["ThoiGianCheckoutDuKien"]);
                }
                else
                {
                    // Sử dụng giá trị hiện tại từ DateTimePicker
                    thoiGianCheckinDuKien = dtpCheckIn.Value;
                    thoiGianCheckoutDuKien = dtpCheckOut.Value;
                }

                // Lấy giá trị thời gian check-in và check-out thực tế nếu có
                DateTime? thoiGianCheckinThucTe = originalData.Rows[0]["ThoiGianCheckinThucTe"] != DBNull.Value ?
                    (DateTime?)originalData.Rows[0]["ThoiGianCheckinThucTe"] : null;

                DateTime? thoiGianCheckoutThucTe = originalData.Rows[0]["ThoiGianCheckoutThucTe"] != DBNull.Value ?
                    (DateTime?)originalData.Rows[0]["ThoiGianCheckoutThucTe"] : null;

                // Sử dụng transaction để cập nhật cả hồ sơ đặt phòng và danh sách thành viên
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        BookRoomDAO bookRoomDAO = BookRoomDAO.Instance;

                        // 1. Cập nhật hồ sơ đặt phòng
                        bookRoomDAO.UpdateBooking(conn, transaction, maHoSoDatPhong, maPhong, maKhachHangDaiDien, soTheTinDung, ghiChu, soDem, tienDatCoc, trangThaiDatPhong, thoiGianCheckinDuKien, thoiGianCheckoutDuKien, thoiGianCheckinThucTe, thoiGianCheckoutThucTe);

                        // 2. Xóa tất cả các thành viên tham gia cũ
                        bookRoomDAO.DeleteParticipantsByBookingId(conn, transaction, maHoSoDatPhong);

                        // 3. Thêm lại các thành viên tham gia mới
                        bookRoomDAO.InsertParticipants(conn, transaction, maHoSoDatPhong, danhSachThanhVien);

                        // Commit transaction nếu tất cả các thao tác thành công
                        transaction.Commit();
                        MessageBox.Show("Cập nhật hồ sơ đặt phòng và danh sách thành viên thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật danh sách hồ sơ đặt phòng
                        LoadData();

                        // Chọn lại hồ sơ vừa cập nhật
                        foreach (DataGridViewRow row in dgvBookRoom.Rows)
                        {
                            if (row.Cells["MaHoSoDatPhong"].Value.ToString() == maHoSoDatPhong.ToString())
                            {
                                dgvBookRoom.ClearSelection();
                                row.Selected = true;
                                ChangeText(row);

                                // Tải lại danh sách thành viên cho hồ sơ đặt phòng vừa cập nhật
                                LoadParticipantsForBooking(maHoSoDatPhong);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật hồ sơ đặt phòng và danh sách thành viên: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức mới để lấy thông tin gốc của hồ sơ đặt phòng từ cơ sở dữ liệu
        private DataTable GetOriginalBookingData(int maHoSoDatPhong)
        {
            try
            {
                DataTable dt = BookRoomDAO.Instance.Search(maHoSoDatPhong);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hồ sơ đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin hồ sơ đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isEditing = false;
            btnBook.Enabled = false;
            btnClose.Enabled = true;
            dtpCheckIn.Enabled = true;
            dtpCheckOut.Enabled = true;
            txtDeposit.Enabled = true;
            txtSearch.Enabled = true;
            dgvBookRoom.Enabled = true;
            txtAddress.Text = "";
            txtCustomerName.Text = "";
            txtDeposit.Text = "";
            txtIdBookRoom.Text = "";
            txtSearch.Text = "";
            txtPhone.Text = "";
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            isSelectingFromGrid = false;
            cbRoomType.SelectedIndex = 0;
            btnUpdate.Enabled = false;
            LoadAvailableRooms();
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            txtCustomerName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtIdBookRoom.Clear();
            txtIdBookRoom.Enabled = false;
            txtDeposit.Clear();
            cbStatus.SelectedIndex = 0;
            cbRoom.SelectedIndex = 0;
            txtCreditCard.Clear();
            txtNotes.Clear();

            // Gọi trực tiếp sự kiện cbRoomType_SelectedIndexChanged
            cbRoomType_SelectedIndexChanged(this, EventArgs.Empty);

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                DataTable dt = SearchCustomer();
                if (dt != null && dt.Rows.Count > 0)
                {
                    LoadCustomerInfo(dt);
                    btnBook.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBook.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBook.Enabled = false;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
            }
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Hiển thị form để tìm kiếm và thêm khách hàng
            using (FormTimKhachHang form = new FormTimKhachHang())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Lấy thông tin các khách hàng đã chọn từ form tìm kiếm
                    DataTable selectedCustomers = form.SelectedCustomers;

                    if (selectedCustomers != null && selectedCustomers.Rows.Count > 0)
                    {
                        int addedCount = 0;

                        foreach (DataRow customerRow in selectedCustomers.Rows)
                        {
                            string maKH = customerRow["MaKhachHang"].ToString();
                            bool exists = guna2DataGridView1.Rows
                                .Cast<DataGridViewRow>()
                                .Any(row => row.Cells["dgvMaKH"].Value?.ToString() == maKH);

                            if (!exists)
                            {
                                int rowIndex = guna2DataGridView1.Rows.Add();
                                guna2DataGridView1.Rows[rowIndex].Cells["dgvMaKH"].Value = maKH;
                                guna2DataGridView1.Rows[rowIndex].Cells["dgvTenKhachHang"].Value = customerRow["HoTen"].ToString();

                                // Xác định có người đại diện chưa
                                bool hasRepresentative = guna2DataGridView1.Rows
                                    .Cast<DataGridViewRow>()
                                    .Any(row => row.Cells["dgvDaiDien"].Value != null && Convert.ToBoolean(row.Cells["dgvDaiDien"].Value));

                                guna2DataGridView1.Rows[rowIndex].Cells["dgvDaiDien"].Value = !hasRepresentative;
                                addedCount++;
                            }
                        }

                        // Thông báo kết quả
                        if (addedCount > 0)
                        {
                            MessageBox.Show($"Đã thêm {addedCount} khách hàng vào danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tất cả khách hàng đã chọn đều đã có trong danh sách!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        // Kiểm tra xem đã có người đại diện chưa
        private bool CheckHasRepresentative()
        {
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["dgvDaiDien"].Value != null &&
                    (bool)row.Cells["dgvDaiDien"].Value == true)
                {
                    return true;
                }
            }
            return false;
        }

        // Xử lý sự kiện khi người dùng thay đổi ô checkbox đại diện
        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isEditing = true; // Đánh dấu là đang chỉnh sửa
            // Tạm thởi tắt sự kiện để tránh đệ quy khi cập nhật các ô khác
            guna2DataGridView1.CellValueChanged -= guna2DataGridView1_CellValueChanged;

            try
            {
                // Kiểm tra xem có phải thay đổi ở cột đại diện không
                if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvDaiDien"].Index)
                {
                    // Nếu đang đặt giá trị thành true (đánh dấu làm đại diện)
                    if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                        (bool)guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == true)
                    {
                        // Bỏ chọn tất cả các ô đại diện khác
                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            if (row.Index != e.RowIndex && row.Cells["dgvDaiDien"].Value != null)
                            {
                                row.Cells["dgvDaiDien"].Value = false;
                            }
                        }
                    }
                    else
                    {
                        // Nếu người dùng bỏ chọn người đại diện hiện tại, kiểm tra xem còn người nào khác không
                        // Nếu còn khách hàng khác, chọn người đầu tiên làm đại diện
                        if (!CheckHasRepresentative() && guna2DataGridView1.Rows.Count > 0)
                        {
                            // Tìm dòng đầu tiên có dữ liệu hợp lệ để đặt làm đại diện
                            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                            {
                                if (row.Cells["dgvMaKH"].Value != null)
                                {
                                    row.Cells["dgvDaiDien"].Value = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                // Đăng ký lại sự kiện
                guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
            }
        }

        // Xử lý sự kiện khi người dùng click vào ô trong DataGridView
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải click vào cột đại diện không
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["dgvDaiDien"].Index)
            {
                // Lấy giá trị hiện tại của ô checkbox
                bool currentValue = false;
                if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    currentValue = (bool)guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }

                // Đảo ngược giá trị của ô checkbox
                guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !currentValue;
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hồ sơ đặt phòng nào được chọn không
            if (string.IsNullOrEmpty(txtIdBookRoom.Text))
            {
                MessageBox.Show("Vui lòng chọn hồ sơ đặt phòng để thực hiện check-in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã hồ sơ đặt phòng
            int maHoSoDatPhong;
            if (!int.TryParse(txtIdBookRoom.Text, out maHoSoDatPhong))
            {
                MessageBox.Show("Mã hồ sơ đặt phòng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trạng thái hiện tại của hồ sơ đặt phòng
            string trangThaiHienTai = cbStatus.Text;
            if (trangThaiHienTai != "Chờ xác nhận")
            {
                MessageBox.Show("Chỉ có thể check-in cho hồ sơ đặt phòng có trạng thái 'Chờ xác nhận'!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn check-in cho hồ sơ đặt phòng này?\n" +
                "Thời gian check-in sẽ được ghi nhận là thởi điểm hiện tại.",
                "Xác nhận check-in",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Gọi DAO thực hiện check-in
                bool success = BookRoomDAO.Instance.CheckInBooking(maHoSoDatPhong, DateTime.Now);
                if (success)
                {
                    MessageBox.Show("Check-in thành công!\nThời gian check-in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbStatus.Text = "Đã xác nhận";
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể check-in. Vui lòng kiểm tra lại thông tin!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvBookRoom_SelectionChanged(object sender, EventArgs e)
        {
            isSelectingFromGrid = true;
            btnBook.Enabled = false;
            btnUpdate.Enabled = true;
            // Gọi phương thức ChangeText để cập nhật thông tin từ hàng được chọn
            if (dgvBookRoom.Focused && dgvBookRoom.Rows.Count > 0)
            {
                ChangeText();
                if (cbStatus.Text == "Đã xác nhận")
                {
                    dtpCheckIn.Enabled = false;
                }
                else
                {
                    dtpCheckIn.Enabled = true;
                }


                // Hiển thị thông tin chi tiết về đặt phòng
                if (dgvBookRoom.SelectedRows.Count > 0)
                {
                    // Lấy mã hồ sơ đặt phòng từ hàng được chọn
                    if (dgvBookRoom.SelectedRows[0].Cells["MaHoSoDatPhong"].Value != null)
                    {
                        int maHoSoDatPhong = Convert.ToInt32(dgvBookRoom.SelectedRows[0].Cells["MaHoSoDatPhong"].Value);

                        // Sử dụng DAO để lấy danh sách khách hàng tham gia
                        DataTable dt = BookRoomDAO.Instance.GetParticipantsByBookingId(maHoSoDatPhong);
                        // Tạm thởi tắt sự kiện CellValueChanged để tránh xung đột
                        guna2DataGridView1.CellValueChanged -= guna2DataGridView1_CellValueChanged;

                        // Xóa dữ liệu hiện tại và tạo dữ liệu mới
                        guna2DataGridView1.Rows.Clear();

                        // Thêm dữ liệu từ DataTable vào DataGridView theo cách thủ công
                        foreach (DataRow dataRow in dt.Rows)
                        {
                            int rowIndex = guna2DataGridView1.Rows.Add();
                            DataGridViewRow row = guna2DataGridView1.Rows[rowIndex];

                            row.Cells["dgvMaKH"].Value = dataRow["dgvMaKH"];
                            row.Cells["dgvTenKhachHang"].Value = dataRow["dgvTenKhachHang"];
                            row.Cells["dgvDaiDien"].Value = Convert.ToBoolean(dataRow["dgvDaiDien"]);
                        }

                        // Đăng ký lại sự kiện
                        guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
                    }
                }
            }
        }

        private void ChangeText(DataGridViewRow row)
        {

            try
            {
                isLoadingFromGrid = true;
                // Tạm thởi tắt sự kiện ValueChanged của DateTimePicker để tránh xung đột
                dtpCheckIn.ValueChanged -= dtpCheckIn_ValueChanged;
                dtpCheckOut.ValueChanged -= dtpCheckOut_ValueChanged;

                txtIdBookRoom.Text = row.Cells["MaHoSoDatPhong"].Value.ToString();
                txtDeposit.Text = row.Cells["TienDatCoc"].Value.ToString();

                // Cập nhật loại phòng trước, điều này sẽ trigger sự kiện cbRoomType_SelectedIndexChanged
                cbRoomType.SelectedValue = row.Cells["MaLoaiPhong"].Value;

                // Sau khi cập nhật loại phòng, LoadAvailableRooms đã được gọi, và cbRoom đã được cập nhật
                // Bây giờ cần chọn đúng phòng trong danh sách
                string tenPhong = row.Cells["TenPhong"].Value.ToString();
                for (int i = 0; i < cbRoom.Items.Count; i++)
                {
                    DataRowView drv = (DataRowView)cbRoom.Items[i];
                    if (drv["TenPhong"].ToString() == tenPhong)
                    {
                        cbRoom.SelectedIndex = i;
                        break;
                    }
                }

                cbStatus.Text = row.Cells["TrangThaiDatPhong"].Value.ToString();
                txtCreditCard.Text = row.Cells["SoTheTinDung"].Value.ToString();
                txtNotes.Text = row.Cells["GhiChu"].Value.ToString();

                // Xử lý cập nhật dtpCheckIn
                if (row.Cells["ThoiGianCheckinDuKien"].Value != null && row.Cells["ThoiGianCheckinDuKien"].Value != DBNull.Value)
                {
                    DateTime checkinDate;
                    if (DateTime.TryParse(row.Cells["ThoiGianCheckinDuKien"].Value.ToString(), out checkinDate))
                    {
                        dtpCheckIn.Value = checkinDate;
                    }
                }

                // Xử lý cập nhật dtpCheckOut
                if (row.Cells["ThoiGianCheckoutDuKien"].Value != null && row.Cells["ThoiGianCheckoutDuKien"].Value != DBNull.Value)
                {
                    DateTime checkoutDate;
                    if (DateTime.TryParse(row.Cells["ThoiGianCheckoutDuKien"].Value.ToString(), out checkoutDate))
                    {
                        dtpCheckOut.Value = checkoutDate;
                    }
                }

                // Cập nhật số đêm dựa trên ngày check-in và check-out
                txtDays.Text = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days.ToString();

                string maKH = row.Cells["MaKhachHang"].Value?.ToString();

                if (!string.IsNullOrEmpty(maKH))
                {
                    LoadCustomerById(maKH);
                }

                // Đăng ký lại sự kiện ValueChanged của DateTimePicker
                dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
                dtpCheckOut.ValueChanged += dtpCheckOut_ValueChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingFromGrid = false;
            }
        }

        public void LoadCustomerById(string customerId)
        {
            try
            {
                // Sử dụng phương thức GetCustomerById từ CustomerDAO thay vì truy vấn trực tiếp
                DataTable dt = CustomerDAO.Instance.GetCustomerById(customerId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    LoadCustomerInfo(dt);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ChangeText()
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dgvBookRoom.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow row = dgvBookRoom.SelectedRows[0];
                // Gọi phương thức ChangeText có tham số để cập nhật thông tin
                ChangeText(row);
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem có khách hàng đại diện nào được chọn không
            bool hasRepresentative = false;
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                if (row.Cells["dgvDaiDien"].Value != null && (bool)row.Cells["dgvDaiDien"].Value)
                {
                    hasRepresentative = true;
                    break;
                }
            }

            if (hasRepresentative)
            {
                MessageBox.Show("Không thể xóa khách hàng đại diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            string message = guna2DataGridView1.SelectedRows.Count == 1
                ? "Bạn có chắc chắn muốn xóa khách hàng này khỏi danh sách tham gia?"
                : $"Bạn có chắc chắn muốn xóa {guna2DataGridView1.SelectedRows.Count} khách hàng khỏi danh sách tham gia?";

            DialogResult result = MessageBox.Show(
                message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Tạo danh sách các hàng cần xóa (để tránh lỗi khi xóa trực tiếp trong vòng lặp)
                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    rowsToRemove.Add(row);
                }

                // Xóa các hàng khỏi DataGridView
                foreach (DataGridViewRow row in rowsToRemove)
                {
                    guna2DataGridView1.Rows.Remove(row);
                }

                MessageBox.Show($"Đã xóa {rowsToRemove.Count} khách hàng khỏi danh sách tham gia! Nhấn nút Cập nhật để lưu thay đổi.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public DataTable SearchCustomer()
        {
            return CustomerDAO.Instance.Search(txtSearch.Text.Trim(), 2);
        }

        private void LoadCustomerInfo(DataTable customerData)
        {
            if (customerData != null && customerData.Rows.Count > 0)
            {
                txtCustomerName.Text = customerData.Rows[0]["HoTen"].ToString();
                txtAddress.Text = customerData.Rows[0]["DiaChi"].ToString();
                txtPhone.Text = customerData.Rows[0]["SoDienThoai"].ToString();

                // Thêm khách hàng này vào DataGridView như là khách hàng đại diện
                guna2DataGridView1.Rows.Clear();
                int rowIndex = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[rowIndex].Cells["dgvMaKH"].Value = customerData.Rows[0]["MaKhachHang"].ToString();
                guna2DataGridView1.Rows[rowIndex].Cells["dgvTenKhachHang"].Value = customerData.Rows[0]["HoTen"].ToString();
                guna2DataGridView1.Rows[rowIndex].Cells["dgvDaiDien"].Value = true; // Đánh dấu là khách hàng đại diện
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin khách hàng với số điện thoại này!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa thông tin hiện tại
                txtCustomerName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhone.Text = string.Empty;
                guna2DataGridView1.Rows.Clear();
            }
        }

        // Exit
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbSearchBookRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = BookRoomDAO.Instance.FindBookRoomByStatus(cbSearchBookRoom.Text);
                dgvBookRoom.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Sau khi tải dữ liệu xong, tự động chọn dòng đầu tiên
            if (dgvBookRoom.Rows.Count > 0 && !isInitializing)
            {
                dgvBookRoom.ClearSelection();
                dgvBookRoom.Rows[0].Selected = true;
                ChangeText(dgvBookRoom.Rows[0]);
                if (cbStatus.Text == "Đã xác nhận")
                {
                    dtpCheckIn.Enabled = false;
                }
                else
                {
                    btnCheckIn.Enabled = true;
                }
            }
        }
    }
}

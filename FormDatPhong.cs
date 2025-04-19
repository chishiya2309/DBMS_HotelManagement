using BLL;
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

namespace QLKS
{
    public partial class FormDatPhong : Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        private bool isInitializing = true;
        private bool isLoadingFromGrid = false;
        public FormDatPhong()
        {
            InitializeComponent();
            LoadData();
            //LoadFullCustomerType();
            LoadFullRoomType();
            LoadAvailableRooms();
            cbRoom.SelectedIndex = 0;
            // Thiết lập giá trị mặc định
            //LoadDate();

            // Đăng ký sự kiện CellValueChanged cho DataGridView
            guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;
            // Đăng ký sự kiện ValueChanged cho DateTimePicker
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;

            // Đăng ký sự kiện CellClick để xử lý khi click vào ô checkbox
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;

            // Vô hiệu hóa nút đặt phòng cho đến khi tìm thấy khách hàng
            btnBook.Enabled = false;

            // Tự động chọn dòng đầu tiên trong dgvBookRoom nếu có dữ liệu
            if (dgvBookRoom.Rows.Count > 0)
            {
                dgvBookRoom.ClearSelection();
                dgvBookRoom.Rows[0].Selected = true;
                ChangeText(dgvBookRoom.Rows[0]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
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



        public DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }

        private void LoadFullCustomerType()
        {
            //cbSex.SelectedIndex = 0;
            //DataTable table = GetFullCustomerType();
            //cbType.DataSource = table;
            //cbType.DisplayMember = "typeName";
            //if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        public void LoadFullCustomer(DataTable data)
        {
            try
            {
                DataTable dt = SearchCustomer();
                LoadCustomerInfo(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetBookRoom()
        {
            return BookRoomDAO.Instance.LoadBookRoom();
        }

        private void LoadBookRoom(DataTable dt)
        {

            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvBookRoom.DataSource = source;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.OK)
            {
                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrEmpty(txtCustomerName.Text) ||
                    cbRoom.SelectedIndex < 0 ||
                    cbStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem có người đại diện không
                bool hasRepresentative = false;
                int maKhachHangDaiDien = 0;
                List<int> danhSachThanhVien = new List<int>();

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
                    return;
                }

                if (danhSachThanhVien.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một khách hàng tham gia!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Lấy mã phòng từ ComboBox
                    int maPhong = Convert.ToInt32(((DataTable)cbRoom.DataSource).Rows[cbRoom.SelectedIndex]["MaPhong"]);

                    // Lấy số đêm
                    int soDem;
                    if (!int.TryParse(txtDays.Text, out soDem) || soDem <= 0)
                    {
                        MessageBox.Show("Số đêm phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy tiền đặt cọc
                    decimal tienDatCoc;
                    if (!decimal.TryParse(txtDeposit.Text, out tienDatCoc) || tienDatCoc < 0)
                    {
                        MessageBox.Show("Tiền đặt cọc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy các thông tin khác
                    string soTheTinDung = txtCreditCard.Text; //
                    string ghiChu = txtNotes.Text;
                    string trangThaiDatPhong = cbStatus.Text;
                    DateTime thoiGianCheckinDuKien = dtpCheckIn.Value;
                    DateTime thoiGianCheckoutDuKien = dtpCheckOut.Value;

                    // Sử dụng transaction để thêm cả hồ sơ đặt phòng và danh sách thành viên
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // 1. Thêm hồ sơ đặt phòng bằng stored procedure
                            int maHoSoDatPhong;
                            using (SqlCommand cmd = new SqlCommand("sp_ThemHoSoDatPhong", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                // Thêm các tham số
                                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHangDaiDien);
                                cmd.Parameters.AddWithValue("@SoTheTinDung", soTheTinDung);
                                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                                cmd.Parameters.AddWithValue("@SoDem", soDem);
                                cmd.Parameters.AddWithValue("@TienDatCoc", tienDatCoc);
                                cmd.Parameters.AddWithValue("@TrangThaiDatPhong", trangThaiDatPhong);
                                cmd.Parameters.AddWithValue("@ThoiGianCheckinDuKien", thoiGianCheckinDuKien);
                                cmd.Parameters.AddWithValue("@ThoiGianCheckoutDuKien", thoiGianCheckoutDuKien);

                                cmd.ExecuteNonQuery();
                            }

                            // Lấy mã hồ sơ đặt phòng vừa tạo sử dụng IDENT_CURRENT
                            using (SqlCommand cmdGetId = new SqlCommand("SELECT IDENT_CURRENT('HoSoDatPhong')", conn, transaction))
                            {
                                object queryResult = cmdGetId.ExecuteScalar();
                                maHoSoDatPhong = Convert.ToInt32(queryResult);

                                if (maHoSoDatPhong == 0)
                                {
                                    throw new Exception("Không thể lấy mã hồ sơ đặt phòng!");
                                }
                            }

                            // 2. Thêm các thành viên tham gia vào bảng ThamGia
                            foreach (int maKH in danhSachThanhVien)
                            {
                                using (SqlCommand cmdInsert = new SqlCommand(
                                    "INSERT INTO ThamGia (MaKhachHang, MaHoSoDatPhong) VALUES (@MaKhachHang, @MaHoSoDatPhong)",
                                    conn, transaction))
                                {
                                    cmdInsert.Parameters.AddWithValue("@MaKhachHang", maKH);
                                    cmdInsert.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }

                            // Commit transaction nếu tất cả các thao tác thành công
                            transaction.Commit();
                            MessageBox.Show("Đặt phòng và thêm thành viên tham gia thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật danh sách đặt phòng
                            LoadData();

                            // Chọn hồ sơ đặt phòng vừa tạo
                            foreach (DataGridViewRow row in dgvBookRoom.Rows)
                            {
                                if (row.Cells["MaHoSoDatPhong"].Value.ToString() == maHoSoDatPhong.ToString())
                                {
                                    dgvBookRoom.ClearSelection();
                                    row.Selected = true;
                                    ChangeText(row);

                                    // Tải danh sách thành viên cho hồ sơ đặt phòng vừa tạo
                                    LoadParticipantsForBooking(maHoSoDatPhong);
                                    break;
                                }
                            }

                            // Khóa nút đặt phòng sau khi đặt phòng thành công
                            btnBook.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction nếu có lỗi
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int GetLastBookingId()
        {
            string query = "SELECT MAX(MaHoSoDatPhong) FROM HoSoDatPhong";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy ID đặt phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }
        }

        private bool SaveParticipants(int maHoSoDatPhong)
        {
            // Nếu không có khách hàng tham gia, không cần xử lý
            if (guna2DataGridView1.Rows.Count == 0)
            {
                return true;
            }


            string query = @"
                INSERT INTO ThamGia (MaKhachHang, MaHoSoDatPhong)
                VALUES (@MaKhachHang, @MaHoSoDatPhong)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Int);
                                cmd.Parameters.Add("@MaHoSoDatPhong", SqlDbType.Int);

                                // Thêm từng khách hàng tham gia vào bảng ThamGia
                                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                                {
                                    if (row.Cells["dgvMaKH"].Value != null)
                                    {
                                        cmd.Parameters["@MaKhachHang"].Value = Convert.ToInt32(row.Cells["dgvMaKH"].Value);
                                        cmd.Parameters["@MaHoSoDatPhong"].Value = maHoSoDatPhong;
                                        cmd.ExecuteNonQuery();
                                    }
                                }

                                transaction.Commit();
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi lưu thông tin khách hàng tham gia: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void ClearForm()
        {
            // Xóa thông tin khách hàng
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtSearch.Text = string.Empty;

            // Xóa thông tin đặt phòng
            txtIdBookRoom.Text = string.Empty;
            txtDeposit.Text = "0";
            txtDays.Text = "1";

            // Reset date pickers
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);

            // Reset combobox
            cbStatus.SelectedIndex = 0; // "Chờ xác nhận"

            // Reset room selection if needed
            if (cbRoomType.Items.Count > 0)
            {
                cbRoomType.SelectedIndex = 0;
            }

            // Làm mới danh sách phòng có sẵn
            if (cbRoomType.SelectedIndex >= 0)
            {
                LoadAvailableRooms();
            }

            // Xóa danh sách khách hàng tham gia
            guna2DataGridView1.Rows.Clear();
        }

        private void LoadAvailableRooms()
        {
            if (cbRoomType.SelectedIndex < 0)
            {
                return;
            }

            string maLoaiPhong = cbRoomType.SelectedValue.ToString();
            string query;
            string tenPhongHienTai = cbRoom.Text;

            // Nếu đang xem thông tin đặt phòng hiện có (btnBook không được kích hoạt)
            if (!btnBook.Enabled && !string.IsNullOrEmpty(txtIdBookRoom.Text))
            {
                // Lấy tất cả phòng thuộc loại phòng đã chọn, bao gồm cả phòng đã đặt
                query = @"
                    SELECT p.MaPhong, p.TenPhong, p.MaLoaiPhong, lp.TenLoaiPhong, p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaLoaiPhong = @maLoaiPhong";
            }
            else
            {
                // Chỉ lấy các phòng trống thuộc loại phòng đã chọn
                query = @"
                    SELECT p.MaPhong, p.TenPhong, p.MaLoaiPhong, lp.TenLoaiPhong, p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.TrangThai = N'Trống' AND p.MaLoaiPhong = @maLoaiPhong";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maLoaiPhong", maLoaiPhong);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Lưu lại tên phòng hiện tại
                            string currentRoom = tenPhongHienTai;

                            cbRoom.DataSource = dt;
                            cbRoom.DisplayMember = "TenPhong";
                            cbRoom.ValueMember = "MaPhong";

                            // Enable/disable cbRoom based on available rooms
                            cbRoom.Enabled = dt.Rows.Count > 0;

                            // Chỉ hiển thị thông báo khi không phải đang khởi tạo form
                            if (dt.Rows.Count == 0 && !isInitializing)
                            {
                                MessageBox.Show("Không có phòng trống thuộc loại phòng này! Vui lòng chọn loại phòng khác.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            // Nếu đang xem thông tin đặt phòng, cố gắng chọn lại phòng hiện tại
                            else if (!btnBook.Enabled && !string.IsNullOrEmpty(currentRoom))
                            {
                                // Tìm và chọn phòng hiện tại trong danh sách
                                for (int i = 0; i < cbRoom.Items.Count; i++)
                                {
                                    DataRowView drv = (DataRowView)cbRoom.Items[i];
                                    if (drv["TenPhong"].ToString() == currentRoom)
                                    {
                                        cbRoom.SelectedIndex = i;
                                        break;
                                    }
                                }

                                // Nếu không tìm thấy phòng hiện tại trong danh sách, nhưng đang xem thông tin đặt phòng
                                // thì vẫn hiển thị tên phòng hiện tại (có thể phòng đã được đặt)
                                if (cbRoom.SelectedIndex < 0 || cbRoom.Text != currentRoom)
                                {
                                    // Thêm phòng hiện tại vào DataTable
                                    using (SqlCommand cmdGetRoom = new SqlCommand(
                                        "SELECT p.MaPhong, p.TenPhong, p.MaLoaiPhong, lp.TenLoaiPhong, p.TrangThai " +
                                        "FROM Phong p " +
                                        "INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong " +
                                        "WHERE p.TenPhong = @TenPhong", conn))
                                    {
                                        cmdGetRoom.Parameters.AddWithValue("@TenPhong", currentRoom);
                                        using (SqlDataAdapter adapterRoom = new SqlDataAdapter(cmdGetRoom))
                                        {
                                            DataTable dtRoom = new DataTable();
                                            adapterRoom.Fill(dtRoom);

                                            if (dtRoom.Rows.Count > 0)
                                            {
                                                // Thêm phòng hiện tại vào DataTable
                                                dt.ImportRow(dtRoom.Rows[0]);

                                                // Cập nhật lại DataSource
                                                cbRoom.DataSource = dt;

                                                // Chọn phòng hiện tại
                                                for (int i = 0; i < cbRoom.Items.Count; i++)
                                                {
                                                    DataRowView drv = (DataRowView)cbRoom.Items[i];
                                                    if (drv["TenPhong"].ToString() == currentRoom)
                                                    {
                                                        cbRoom.SelectedIndex = i;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách phòng: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            txtAddress.Enabled = false;
            txtPhone.Enabled = false;
            txtCustomerName.Enabled = false;
            txtDays.Enabled = false;
            //cbSex.Enabled = false;
            //cbType.Enabled = false;
            //dtpDoB.Enabled = false;
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            txtIdBookRoom.Enabled = false;
            txtDeposit.Text = "0";
            txtDays.Text = "1";
            isEditing = false;

            // Đánh dấu quá trình khởi tạo đã hoàn tất
            isInitializing = false;

            LoadData();
            LoadFullRoomType();
            LoadAvailableRooms();

            // Tự động chọn dòng đầu tiên trong dgvBookRoom nếu có dữ liệu
            if (dgvBookRoom.Rows.Count > 0)
            {
                dgvBookRoom.ClearSelection();
                dgvBookRoom.Rows[0].Selected = true;

                // Gọi ChangeText để cập nhật thông tin từ dòng được chọn
                ChangeText(dgvBookRoom.Rows[0]);

                // Tải danh sách thành viên cho hồ sơ đặt phòng đầu tiên
                LoadParticipantsForBooking(Convert.ToInt32(dgvBookRoom.Rows[0].Cells["MaHoSoDatPhong"].Value));
            }

            // Vô hiệu hóa nút đặt phòng cho đến khi tìm thấy khách hàng
            btnBook.Enabled = false;
        }

        // Thêm phương thức mới để tải danh sách thành viên tham gia đặt phòng
        private void LoadParticipantsForBooking(int maHoSoDatPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        kh.MaKhachHang AS dgvMaKH, 
                        kh.HoTen AS dgvTenKhachHang, 
                        CASE 
                            WHEN kh.MaKhachHang = hs.MaKhachHang THEN 1 
                            ELSE 0 
                        END AS dgvDaiDien
                    FROM ThamGia tg
                    JOIN KhachHang kh ON kh.MaKhachHang = tg.MaKhachHang
                    JOIN HoSoDatPhong hs ON hs.MaHoSoDatPhong = tg.MaHoSoDatPhong
                    WHERE tg.MaHoSoDatPhong = @MaHoSoDatPhong";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

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
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách khách hàng tham gia: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            }
        }

        public void LoadDate()
        {

            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            txtDays.Text = "1";
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

        // Thêm phương thức mới để cập nhật ngày check-out dựa trên số đêm
        private void txtDays_TextChanged(object sender, EventArgs e)
        {
            if (isLoadingFromGrid || isUpdatingDates) return;

            isUpdatingDates = true;
            try
            {
                // Kiểm tra xem giá trị nhập vào có phải là số nguyên hợp lệ không
                if (int.TryParse(txtDays.Text, out int days) && days > 0)
                {
                    // Cập nhật ngày check-out dựa trên số đêm
                    dtpCheckOut.Value = dtpCheckIn.Value.AddDays(days);
                }
                else if (!string.IsNullOrEmpty(txtDays.Text))
                {
                    // Nếu giá trị không hợp lệ, đặt lại thành 1
                    txtDays.Text = "1";
                    MessageBox.Show("Số đêm phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                isUpdatingDates = false;
            }
        }

        bool isEditing;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
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

                // Lấy mã phòng từ ComboBox
                int maPhong = Convert.ToInt32(((DataTable)cbRoom.DataSource).Rows[cbRoom.SelectedIndex]["MaPhong"]);

                // Lấy mã khách hàng đại diện
                string maKhachHang = string.Empty;
                List<int> danhSachThanhVien = new List<int>();

                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (row.Cells["dgvMaKH"].Value != null)
                    {
                        int maKH = Convert.ToInt32(row.Cells["dgvMaKH"].Value);
                        danhSachThanhVien.Add(maKH);

                        if (row.Cells["dgvDaiDien"].Value != null && Convert.ToBoolean(row.Cells["dgvDaiDien"].Value))
                        {
                            maKhachHang = maKH.ToString();
                        }
                    }
                }

                if (string.IsNullOrEmpty(maKhachHang))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng đại diện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (danhSachThanhVien.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một khách hàng tham gia!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy các thông tin khác
                string soTheTinDung = txtCreditCard.Text; // Giá trị mặc định nếu không có
                string ghiChu = txtNotes.Text;
                int soDem = int.Parse(txtDays.Text);
                decimal tienDatCoc = decimal.Parse(txtDeposit.Text);
                string trangThaiDatPhong = cbStatus.Text;
                DateTime thoiGianCheckinDuKien = dtpCheckIn.Value;
                DateTime thoiGianCheckoutDuKien = dtpCheckOut.Value;

                // Sử dụng transaction để cập nhật cả hồ sơ đặt phòng và danh sách thành viên
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Cập nhật hồ sơ đặt phòng
                        using (SqlCommand cmd = new SqlCommand("sp_SuaHoSoDatPhong", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số
                            cmd.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                            cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                            cmd.Parameters.AddWithValue("@MaKhachHang", int.Parse(maKhachHang));
                            cmd.Parameters.AddWithValue("@SoTheTinDung", soTheTinDung);
                            cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                            cmd.Parameters.AddWithValue("@SoDem", soDem);
                            cmd.Parameters.AddWithValue("@TienDatCoc", tienDatCoc);
                            cmd.Parameters.AddWithValue("@TrangThaiDatPhong", trangThaiDatPhong);
                            cmd.Parameters.AddWithValue("@ThoiGianCheckinDuKien", thoiGianCheckinDuKien);
                            cmd.Parameters.AddWithValue("@ThoiGianCheckoutDuKien", thoiGianCheckoutDuKien);

                            // Tham số tùy chọn - có thể là null
                            SqlParameter paramCheckinThucTe = new SqlParameter("@ThoiGianCheckinThucTe", SqlDbType.DateTime);
                            paramCheckinThucTe.IsNullable = true;
                            paramCheckinThucTe.Value = DBNull.Value;
                            cmd.Parameters.Add(paramCheckinThucTe);

                            SqlParameter paramCheckoutThucTe = new SqlParameter("@ThoiGianCheckoutThucTe", SqlDbType.DateTime);
                            paramCheckoutThucTe.IsNullable = true;
                            paramCheckoutThucTe.Value = DBNull.Value;
                            cmd.Parameters.Add(paramCheckoutThucTe);

                            cmd.ExecuteNonQuery();
                        }

                        // 2. Xóa tất cả các thành viên tham gia cũ
                        using (SqlCommand cmdDelete = new SqlCommand(
                            "DELETE FROM ThamGia WHERE MaHoSoDatPhong = @MaHoSoDatPhong", conn, transaction))
                        {
                            cmdDelete.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                            cmdDelete.ExecuteNonQuery();
                        }

                        // 3. Thêm lại các thành viên tham gia mới
                        foreach (int maKH in danhSachThanhVien)
                        {
                            using (SqlCommand cmdInsert = new SqlCommand(
                                "INSERT INTO ThamGia (MaHoSoDatPhong, MaKhachHang) VALUES (@MaHoSoDatPhong, @MaKhachHang)",
                                conn, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                                cmdInsert.Parameters.AddWithValue("@MaKhachHang", maKH);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }

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
            cbRoomType.SelectedIndex = 0;
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
                // Thực hiện check-in
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        // Cập nhật trạng thái và thởi gian check-in thực tế
                        string query = @"
                            UPDATE HoSoDatPhong 
                            SET TrangThaiDatPhong = N'Đã xác nhận', 
                                ThoiGianCheckinThucTe = @ThoiGianCheckinThucTe
                            WHERE MaHoSoDatPhong = @MaHoSoDatPhong";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);
                            cmd.Parameters.AddWithValue("@ThoiGianCheckinThucTe", DateTime.Now);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Check-in thành công!\nThời gian check-in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Cập nhật trạng thái hiển thị
                                cbStatus.Text = "Đã xác nhận";

                                // Tải lại dữ liệu
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Không thể check-in. Vui lòng kiểm tra lại thông tin!",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thực hiện check-in: " + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvBookRoom_SelectionChanged(object sender, EventArgs e)
        {
            btnBook.Enabled = false;
            // Gọi phương thức ChangeText để cập nhật thông tin từ hàng được chọn
            if (dgvBookRoom.Focused && dgvBookRoom.Rows.Count > 0)
            {
                ChangeText();

                // Hiển thị thông tin chi tiết về đặt phòng
                if (dgvBookRoom.SelectedRows.Count > 0)
                {
                    // Lấy mã hồ sơ đặt phòng từ hàng được chọn
                    if (dgvBookRoom.SelectedRows[0].Cells["MaHoSoDatPhong"].Value != null)
                    {
                        int maHoSoDatPhong = Convert.ToInt32(dgvBookRoom.SelectedRows[0].Cells["MaHoSoDatPhong"].Value);

                        // Tải danh sách khách hàng tham gia đặt phòng này
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            try
                            {
                                conn.Open();
                                string query = @"
                                SELECT 
                                    kh.MaKhachHang AS dgvMaKH, 
                                    kh.HoTen AS dgvTenKhachHang, 
                                    CASE 
                                        WHEN kh.MaKhachHang = hs.MaKhachHang THEN 1 
                                        ELSE 0 
                                    END AS dgvDaiDien
                                FROM ThamGia tg
                                JOIN KhachHang kh ON kh.MaKhachHang = tg.MaKhachHang
                                JOIN HoSoDatPhong hs ON hs.MaHoSoDatPhong = tg.MaHoSoDatPhong
                                WHERE tg.MaHoSoDatPhong = @MaHoSoDatPhong";

                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@MaHoSoDatPhong", maHoSoDatPhong);

                                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    adapter.Fill(dt);

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
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải danh sách khách hàng tham gia: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
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
                cbRoomType.SelectedValue = row.Cells["MaLoaiPhong"].Value;
                cbRoom.Text = row.Cells["TenPhong"].Value.ToString();
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

                // Tạm thởi tắt sự kiện ValueChanged của DateTimePicker để tránh xung đột
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
            string query = "SELECT * FROM KhachHang WHERE MaKhachHang = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            LoadCustomerInfo(dt);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}

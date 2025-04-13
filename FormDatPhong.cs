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
        public FormDatPhong()
        {
            InitializeComponent();
            //LoadFullCustomerType();
            LoadFullRoomType();
            // Thiết lập giá trị mặc định
            LoadDate();

            // Đăng ký sự kiện CellValueChanged cho DataGridView
            guna2DataGridView1.CellValueChanged += guna2DataGridView1_CellValueChanged;

            // Ngăn chặn việc tự động thêm dòng mới khi click vào dòng cuối
            guna2DataGridView1.AllowUserToAddRows = false;

            // Đăng ký sự kiện CellClick để xử lý khi click vào ô checkbox
            guna2DataGridView1.CellClick += guna2DataGridView1_CellClick;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //public void LoadFullCustomer(DataTable dt)
        //{
        //    txtCustomerName.Text = dt.Rows[0]["fullname"].ToString();
        //    txtAddress.Text = dt.Rows[0]["address"].ToString();
        //    txtPhone.Text = dt.Rows[0]["phoneNumber"].ToString();
        //    cbSex.Text = dt.Rows[0]["sex"].ToString();
        //    cbType.Text = dt.Rows[0]["typeName"].ToString();
        //    dtpDoB.Text = dt.Rows[0]["dateofBirth"].ToString();
        //}

        private BookingRecord GetBookRoomNow()
        {
            BookingRecord bookingRecord = new BookingRecord();
            // Kiểm tra và lấy thông tin khách hàng
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                throw new Exception("Vui lòng nhập thông tin khách hàng!");
            }

            // Lấy mã khách hàng từ kết quả tìm kiếm
            int idCustomer;
            try
            {
                DataTable customerData = SearchCustomer();
                if (customerData != null && customerData.Rows.Count > 0)
                {
                    idCustomer = Convert.ToInt32(customerData.Rows[0]["MaKhachHang"]);
                }
                else
                {
                    throw new Exception("Không tìm thấy thông tin khách hàng!");
                }
            }
            catch
            {
                throw new Exception("Lỗi khi lấy thông tin khách hàng. Vui lòng kiểm tra lại!");
            }

            // Lấy mã phòng
            int idRoom;
            try
            {
                int roomIndex = cbRoom.SelectedIndex;
                if (roomIndex < 0)
                {
                    throw new Exception("Vui lòng chọn phòng!");
                }

                DataTable roomData = (DataTable)cbRoom.DataSource;
                idRoom = Convert.ToInt32(roomData.Rows[roomIndex]["MaPhong"]);
            }
            catch
            {
                throw new Exception("Lỗi khi lấy thông tin phòng. Vui lòng kiểm tra lại!");
            }

            // Lấy số đêm
            int nights;
            if (!int.TryParse(txtDays.Text, out nights) || nights <= 0)
            {
                throw new Exception("Số đêm phải là số nguyên dương!");
            }

            // Lấy tiền đặt cọc
            double deposit;
            if (!double.TryParse(txtDeposit.Text, out deposit) || deposit < 0)
            {
                throw new Exception("Tiền đặt cọc không hợp lệ!");
            }

            // Thiết lập các giá trị cho booking record
            bookingRecord.IdCustomer = idCustomer;
            bookingRecord.IdRoom = idRoom;
            bookingRecord.DateCheckIn = dtpCheckIn.Value;
            bookingRecord.DateCheckOut = dtpCheckOut.Value;
            bookingRecord.Status = cbStatus.Text;
            bookingRecord.Deposit = deposit;
            bookingRecord.Days = nights;
            // Các thông tin bổ sung có thể được thêm vào đây

            return bookingRecord;
        }
        public DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }

        private void LoadFullRoomType()
        {
            string query = @"
            SELECT l.MaLoaiPhong, l.TenLoaiPhong
             FROM LoaiPhong l";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        cbRoomType.DataSource = dt;
                        cbRoomType.DisplayMember = "TenLoaiPhong";
                        cbRoomType.ValueMember = "MaLoaiPhong";
                        cbRoomType.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    string.IsNullOrEmpty(txtSearch.Text) ||
                    cbRoom.SelectedIndex < 0 ||
                    cbStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Lấy thông tin từ form
                    BookingRecord bookingRecord = GetBookRoomNow();

                    // Thiết lập các thông tin bổ sung
                    bookingRecord.DateBookRoom = DateTime.Now; // Ngày đặt phòng là ngày hiện tại

                    // Thực hiện đặt phòng
                    bool success = BookRoomDAO.Instance.InsertBookRoom(bookingRecord);

                    if (success)
                    {
                        // Lấy mã hồ sơ đặt phòng vừa tạo
                        int maHoSoDatPhong = GetLastBookingId();
                        if (SaveParticipants(maHoSoDatPhong))
                        {
                            MessageBox.Show("Đặt phòng thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật danh sách đặt phòng
                            LoadData();

                            // Reset form
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Đặt phòng thành công nhưng có lỗi khi lưu thông tin khách hàng tham gia!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Cập nhật danh sách đặt phòng
                        LoadData();

                        // Reset form
                        ClearForm();

                        // Lưu thông tin các khách hàng tham gia
                        if (!SaveParticipants(Convert.ToInt32(txtIdBookRoom.Text)))
                        {
                            MessageBox.Show("Lỗi khi lưu thông tin khách hàng tham gia!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể đặt phòng. Vui lòng thử lại!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int maLoaiPhong = Convert.ToInt32(cbRoomType.SelectedValue);

            string query = @"
                SELECT p.MaPhong, p.TenPhong, p.MaLoaiPhong, lp.TenLoaiPhong, p.TrangThai
                FROM Phong p
                INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                WHERE p.TrangThai = N'Trống' AND p.MaLoaiPhong = @maLoaiPhong";

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

                            cbRoom.DataSource = dt;
                            cbRoom.DisplayMember = "TenPhong";
                            cbRoom.ValueMember = "MaPhong";

                            // Enable/disable cbRoom based on available rooms
                            cbRoom.Enabled = dt.Rows.Count > 0;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Không có phòng trống thuộc loại phòng này!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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






        //private void LoadFullRoomType()
        //{

        //    DataTable table = GetFullRoomType();
        //    cbRoom.DataSource = table;
        //    cbRoom.DisplayMember = "typename";
        //    if (table.Rows.Count > 0) cbRoom.SelectedIndex = 0;
        //}

        public DataTable SearchAvailableRoom()
        {
            int index = cbRoom.SelectedIndex;
            int id = (int)((DataTable)cbRoom.DataSource).Rows[index]["MaLoaiPhong"];
            return RoomDAO.Instance.LoadAllEmptyRoom(id);
        }



        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAvailableRooms();
        }

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            LoadData();

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
        }

        private void LoadData()
        {


            string query = @"
                SELECT h.MaHoSoDatPhong, h.ThoiGianDatPhong, k.HoTen, h.MaKhachHang,
                       h.MaPhong, p.TenPhong, h.SoDem, h.ThoiGianCheckinDuKien, 
                       h.ThoiGianCheckoutDuKien, h.TienDatCoc, h.TrangThaiDatPhong,
                       h.SoTheTinDung, h.GhiChu
                FROM HoSoDatPhong h
                INNER JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                INNER JOIN Phong p ON h.MaPhong = p.MaPhong
                ORDER BY h.ThoiGianDatPhong DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvBookRoom.DataSource = dt; // Gán dữ liệu vào DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void LoadDate()
        {

            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value < DateTime.Now)
                LoadDate();
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
                LoadDate();
            txtDays.Text = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days.ToString();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= DateTime.Now)
                LoadDate();
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
                LoadDate();
            txtDays.Text = (dtpCheckOut.Value.Date - dtpCheckIn.Value.Date).Days.ToString();
        }

        bool isEditing;
        //private void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    if (!isEditing)
        //    {
        //        cbRoomType_SelectedIndexChanged(null, EventArgs.Empty);
        //        if (dgvBookRoom.SelectedRows.Count > 0)
        //        {
        //            DataGridViewRow row = dgvBookRoom.SelectedRows[0];
        //            ChangeText(row);
        //        }
        //        btnBook.Enabled = false;
        //        btnClose.Enabled = false;
        //        dtpCheckIn.Enabled = false;
        //        dtpCheckOut.Enabled = false;
        //        txtDeposit.Enabled = false;
        //        txtSearch.Enabled = false;
        //        isEditing = true;
        //        dgvBookRoom.Enabled = false;
        //    }
        //    else
        //    {
        //        DialogResult result = MessageBox.Show("Bạn có muốn cập nhật hồ sơ đặt phòng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //        if (result == DialogResult.OK)
        //        {

        //            UpdateBookRoom();
        //            isEditing = false;
        //            btnBook.Enabled = true;
        //            btnClose.Enabled = true;
        //            dtpCheckIn.Enabled = true;
        //            dtpCheckOut.Enabled = true;
        //            txtDeposit.Enabled = true;
        //            txtSearch.Enabled = true;
        //            dgvBookRoom.Enabled = true;
        //        }
        //    }
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

        private void UpdateBookRoom()
        {
            bool isFill = CheckFillInText(new Control[] { cbRoom });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //int idStaff = Convert.ToInt32(dgvService.SelectedRows[0].Cells["dgvIdservice"].Value);
                    int index = cbRoom.SelectedIndex;
                    bool check1 = BookRoomDAO.Instance.UpdateBookRoom(int.Parse(txtIdBookRoom.Text), cbStatus.Text, (int)((DataTable)cbRoom.DataSource).Rows[index]["idRoom"]);


                    if (check1)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int index2 = dgvBookRoom.SelectedRows[0].Index;
                        //LoadBookRoom(GetBookRoom());
                        dgvBookRoom.SelectedRows[0].Selected = false;
                        dgvBookRoom.Rows[index2].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void ChangeText(DataGridViewRow row)
        //{
        //    if (row.IsNewRow)
        //    {
        //        txtIdBookRoom.Text = string.Empty;
        //        txtSearch.Text = string.Empty;


        //    }
        //    else
        //    {

        //        txtIdBookRoom.Text = row.Cells["dgvIdBookRoom"].Value.ToString();
        //        txtDeposit.Text = row.Cells["dgvDeposit"].Value as string;
        //        cbRoom.Text = row.Cells["dgvRoomName"].Value.ToString();

        //        cbStatus.Text = row.Cells["dgvStatus"].Value as string;
        //        //cbStatus.SelectedIndex = (int)row.Cells["dgvStatus"].Value - 1;

        //        if (DateTime.TryParse(row.Cells["dgvDateCheckIn"].Value?.ToString(), out DateTime checkin))
        //        {
        //            dtpCheckIn.Value = checkin;
        //        }
        //        if (DateTime.TryParse(row.Cells["dgvDateCheckOut"].Value?.ToString(), out DateTime checkout))
        //        {
        //            dtpCheckOut.Value = checkout;
        //        }

        //        string idCustomer = dgvBookRoom.SelectedRows[0].Cells["dgvIdCustomer"].Value.ToString();
        //        LoadFullCustomer(CustomerDAO.Instance.Search(idCustomer, 0));
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isEditing = false;
            btnBook.Enabled = true;
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
            dtpCheckOut.Value = DateTime.Now;
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)


        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem số điện thoại có rỗng không
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Regex kiểm tra số điện thoại hợp lệ (bao gồm quốc tế)
            string phonePattern = @"^(\+?\d{1,4}[\s\-]?)?\(?\d{3,4}\)?[\s\-]?\d{3,4}[\s\-]?\d{3,4}$";

            if (!Regex.IsMatch(txtSearch.Text, phonePattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable dt = SearchCustomer();
                if (dt != null && dt.Rows.Count > 0)
                {
                    LoadFullCustomer(dt);
                    LoadCustomerInfo(dt);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        //public void LoadFullCustomer(DataTable dt)
        //{
        //    txtCustomerName.Text = dt.Rows[0]["Hoten"].ToString();
        //    txtAddress.Text = dt.Rows[0]["Diachi"].ToString();
        //    txtPhone.Text = dt.Rows[0]["Sodienthoai"].ToString();
        //    cbSex.Text = dt.Rows[0]["Gioitinh"].ToString();
        //    cbType.Text = dt.Rows[0]["LoaiKhachHang"].ToString();
        //    dtpDoB.Text = dt.Rows[0]["Ngaysinh"].ToString();
        //}


        public DataTable SearchCustomer()
        {
            string query = @"
                SELECT kh.*
                FROM KhachHang kh
                WHERE kh.SoDienThoai = @phoneNumber";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@phoneNumber", txtSearch.Text.Trim());

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }



        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchPhone.PerformClick();
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
            }
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
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

                        // Duyệt qua từng khách hàng đã chọn
                        foreach (DataRow customerRow in selectedCustomers.Rows)
                        {
                            // Kiểm tra xem khách hàng đã tồn tại trong danh sách chưa
                            string maKH = customerRow["MaKhachHang"].ToString();
                            bool exists = false;

                            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                            {
                                if (row.Cells["dgvMaKH"].Value != null &&
                                    row.Cells["dgvMaKH"].Value.ToString() == maKH)
                                {
                                    exists = true;
                                    break;
                                }
                            }

                            if (!exists)
                            {
                                // Thêm khách hàng vào danh sách
                                int rowIndex = guna2DataGridView1.Rows.Add();
                                guna2DataGridView1.Rows[rowIndex].Cells["dgvMaKH"].Value = maKH;
                                guna2DataGridView1.Rows[rowIndex].Cells["dgvTenKhachHang"].Value = customerRow["HoTen"].ToString();

                                // Nếu chưa có người đại diện nào và đây là người đầu tiên được thêm vào, đặt làm đại diện
                                bool hasRepresentative = CheckHasRepresentative();
                                if (!hasRepresentative && guna2DataGridView1.Rows.Count == 1)
                                {
                                    guna2DataGridView1.Rows[rowIndex].Cells["dgvDaiDien"].Value = true;
                                }
                                else
                                {
                                    guna2DataGridView1.Rows[rowIndex].Cells["dgvDaiDien"].Value = false;
                                }
                                addedCount++;
                            }
                        }

                        // Hiển thị thông báo kết quả
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
                // Đăng ký lại sự kiện sau khi hoàn thành
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

                int successCount = 0;
                int failCount = 0;

                // Nếu đang chỉnh sửa hồ sơ đặt phòng hiện có
                if (isEditing && !string.IsNullOrEmpty(txtIdBookRoom.Text))
                {
                    int bookingId = Convert.ToInt32(txtIdBookRoom.Text);

                    foreach (DataGridViewRow row in rowsToRemove)
                    {
                        int customerId = Convert.ToInt32(row.Cells["dgvMaKH"].Value);

                        // Xóa khách hàng khỏi bảng ThamGia trong cơ sở dữ liệu
                        if (DeleteParticipant(bookingId, customerId))
                        {
                            // Xóa hàng khỏi DataGridView
                            guna2DataGridView1.Rows.Remove(row);
                            successCount++;
                        }
                        else
                        {
                            failCount++;
                        }
                    }
                }
                else
                {
                    // Nếu đang tạo hồ sơ đặt phòng mới, chỉ cần xóa khỏi DataGridView
                    foreach (DataGridViewRow row in rowsToRemove)
                    {
                        guna2DataGridView1.Rows.Remove(row);
                        successCount++;
                    }
                }

                // Hiển thị thông báo kết quả
                if (failCount == 0)
                {
                    MessageBox.Show($"Đã xóa {successCount} khách hàng khỏi danh sách tham gia!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Đã xóa {successCount} khách hàng, {failCount} khách hàng không thể xóa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Phương thức để xóa khách hàng khỏi bảng ThamGia
        private bool DeleteParticipant(int bookingId, int customerId)
        {
            string query = @"
                DELETE FROM ThamGia 
                WHERE MaHoSoDatPhong = @MaHoSoDatPhong AND MaKhachHang = @MaKhachHang";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoSoDatPhong", bookingId);
                        cmd.Parameters.AddWithValue("@MaKhachHang", customerId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng tham gia: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}

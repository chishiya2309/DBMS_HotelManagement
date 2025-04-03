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
    public partial class FormDatPhong: Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        public FormDatPhong()
        {
            InitializeComponent();
            //LoadFullCustomerType();
            LoadFullRoomType();
            // Thiết lập giá trị mặc định
            LoadDate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            
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

        //private BookingRecord GetBookRoomNow()
        //{
        //    BookingRecord account = new BookingRecord();

        //    // Xoá các khoảng trắng thừa
        //    //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



        //    int index = cbType.SelectedIndex;
        //    int idCustomer = int.Parse(SearchCustomer().Rows[0]["idCustomer"].ToString());

        //    account.DateCheckIn = dtpCheckIn.Value;
        //    account.DateCheckOut = dtpCheckOut.Value;
        //    account.Status = cbStatus.Text;
        //    account.Deposit = double.Parse(txtDeposit.Text);
        //    account.IdCustomer = idCustomer;
        //    account.IdRoom = (int)((DataTable)cbRoom.DataSource).Rows[index]["idRoom"];
        //    account.Days = int.Parse(txtDays.Text);
        //    return account;
        //}

        //private void btnBook_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //    if (result == DialogResult.OK)
        //    {

        //        bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtCustomerName, txtSearch, cbRoom });
        //        if (!isFill)
        //        {
        //            MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                //int idStaff = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);
        //                bool check1 = BookRoomDAO.Instance.InsertBookRoom(GetBookRoomNow());


        //                if (check1)
        //                {
        //                    MessageBox.Show("Đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    //LoadBookRoom(GetBookRoom());
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Không thể đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                }
        //            }
        //            catch (SqlException ex)
        //            {
        //                MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

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
                        cbRoom.DataSource = dt;
                        cbRoom.DisplayMember = "TenLoaiPhong";
                        cbRoom.ValueMember = "MaLoaiPhong";
                        cbRoom.SelectedIndex = 0;
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

        public DataTable SearchCustomer()
        {

            return CustomerDAO.Instance.Search(txtSearchPhone.Text, 2);

        }

        public void LoadFullCustomer(DataTable dt)
        {
            //txtCustomerName.Text = dt.Rows[0]["fullname"].ToString();
            //txtAddress.Text = dt.Rows[0]["address"].ToString();
            //txtPhone.Text = dt.Rows[0]["phoneNumber"].ToString();
            //cbSex.Text = dt.Rows[0]["sex"].ToString();
            //cbType.Text = dt.Rows[0]["typeName"].ToString();
            //dtpDoB.Text = dt.Rows[0]["dateofBirth"].ToString();
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

        private BookingRecord GetBookRoomNow()
        {
            BookingRecord account = new BookingRecord();

            // Xoá các khoảng trắng thừa
            //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



            //int index = cbType.SelectedIndex;
            //int idCustomer = int.Parse(SearchCustomer().Rows[0]["idCustomer"].ToString());

            //account.DateCheckIn = dtpCheckIn.Value;
            //account.DateCheckOut = dtpCheckOut.Value;
            //account.Status = cbStatus.Text;
            //account.Deposit = double.Parse(txtDeposit.Text);
            //account.IdCustomer = idCustomer;
            //account.IdRoom = (int)((DataTable)cbRoom.DataSource).Rows[index]["idRoom"];
            //account.Days = int.Parse(txtDays.Text);
            return account;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtCustomerName, txtSearchPhone, cbRoom });

                if (!isFill)
                {
                    MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        //int idStaff = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);
                        bool check1 = BookRoomDAO.Instance.InsertBookRoom(GetBookRoomNow());


                        if (check1)
                        {
                            MessageBox.Show("Đặt phòng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookRoom(GetBookRoom());
                        }
                        else
                        {
                            MessageBox.Show("Không thể đặt phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            int id = (int)((DataTable)cbRoom.DataSource).Rows[index]["idRoomType"];
            return RoomDAO.Instance.LoadAllEmptyRoom(id);
        }



        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable table = SearchAvailableRoom();
            cbRoom.DataSource = table;
            cbRoom.DisplayMember = "roomname";
            if (table.Rows.Count > 0) cbRoom.SelectedIndex = 0;
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
                SELECT h.*, k.HoTen, p.TenPhong
                FROM HoSoDatPhong h
                INNER JOIN KhachHang k ON h.MaKhachHang = k.MaKhachHang
                INNER JOIN Phong p ON h.MaPhong = p.MaPhong";

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


        //public void LoadFullCustomer(DataTable dt)
        //{
        //    txtCustomerName.Text = dt.Rows[0]["Hoten"].ToString();
        //    txtAddress.Text = dt.Rows[0]["Diachi"].ToString();
        //    txtPhone.Text = dt.Rows[0]["Sodienthoai"].ToString();
        //    cbSex.Text = dt.Rows[0]["Gioitinh"].ToString();
        //    cbType.Text = dt.Rows[0]["LoaiKhachHang"].ToString();
        //    dtpDoB.Text = dt.Rows[0]["Ngaysinh"].ToString();
        //}


        //public DataTable SearchCustomer()
        //{
        //    string query = @"
        //        SELECT kh.*
        //        FROM KhachHang kh
        //        WHERE kh.Sodienthoai = @phoneNumber;";

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(query, conn))
        //            {
        //                cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = txtSearchPhone.Text.Trim();

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //                {
        //                    DataTable dt = new DataTable();
        //                    adapter.Fill(dt);
        //                    return dt;
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }
        //    }
        //}



        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true; // Ngăn chặn âm thanh "ding" khi nhấn Enter
            }
        }


    }
}

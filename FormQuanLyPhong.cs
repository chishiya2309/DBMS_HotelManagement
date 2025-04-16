using BLL;
using BLL.DAO;
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
    public partial class FormQuanLyPhong: Form
    {
        string connectionString = "Data Source=(local);Initial Catalog=Hotel2025;Integrated Security=True";
        public FormQuanLyPhong()
        {
            InitializeComponent();
            //LoadFullRoomStatus();
            // LoadFullRoomType();
            ConfigureDataGridView();
            LoadRoomData();
            LoadRoomType();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Delete
        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá phòng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    int maPhong = Convert.ToInt32(dgvRoom.CurrentRow.Cells["MaPhong"].Value);
                    if (DeleteRoom(maPhong))
                    {
                        MessageBox.Show($"Xoá phòng {maPhong} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoomData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá phòng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public bool DeleteRoom(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteRoom", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idRoom", id);
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

        private void label3_Click(object sender, EventArgs e)
        {

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
                        cbType.DisplayMember = "TenLoaiPhong";
                        cbType.ValueMember = "MaLoaiPhong";
                        cbType.DataSource = dt; // Gán dữ liệu vào DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRoom_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvRoom.SelectedRows[0];

                    // Hiển thị thông tin phòng được chọn trực tiếp lên form
                    txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString() ?? "";
                    txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";
                    cbStatus.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    cbType.Text = row.Cells["TenLoaiPhong"].Value?.ToString() ?? "";
                    txtLimit.Text = row.Cells["SucChua"].Value?.ToString() ?? "";
                    txtPrice.Text = row.Cells["DonGia"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //private Room GetRoomNow()
        //{
        //    Room account = new Room();

        //    // Xoá các khoảng trắng thừa
        //    //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });

        //    int index1 = cbType.SelectedIndex;
        //    int index2 = cbStatus.SelectedIndex;
        //    account.Id = int.Parse(txtIDroom.Text);
        //    account.IdRoomType = (int)((DataTable)cbType.DataSource).Rows[index1]["idRoomType"];
        //    account.IdStatusRoom = (int)((DataTable)cbStatus.DataSource).Rows[index2]["id"];
        //    account.Name = txtName.Text;

        //    return account;
        //}

        //private RoomType GetRoomTypeNow()
        //{
        //    RoomType account = new RoomType();

        //    // Xoá các khoảng trắng thừa
        //    //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });

        //    int index = cbType.SelectedIndex;

        //    account.Id = (int)((DataTable)cbType.DataSource).Rows[index]["idRoomType"];
        //    account.Name = ((DataTable)cbType.DataSource).Rows[index]["typename"].ToString();
        //    account.Limit = int.Parse(txtLimit.Text);
        //    account.Price = double.Parse(txtPrice.Text);

        //    return account;
        //}

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count > 0)
            {
                EditSelectedRoom();
                LoadRoomData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditSelectedRoom()
        {
            if (dgvRoom.SelectedRows.Count == 0) return;

            // Lấy dòng đang chọn
            DataGridViewRow selectedRow = dgvRoom.SelectedRows[0];
            string maPhong = selectedRow.Cells["MaPhong"].Value.ToString();

            UpdateRoom fupdateRoom = new UpdateRoom(maPhong);
            if (fupdateRoom.ShowDialog() == DialogResult.OK)
            {
                LoadRoomData(); // Tải lại dữ liệu sau khi cập nhật thành công
            }
        }



        //private void FormQuanLyPhong_Load(object sender, EventArgs e)
        //{
        //    txtIDroom.Enabled = false;
        //    cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        //    cbType.DropDownStyle = ComboBoxStyle.DropDownList;
        //}

        private void btnInsert_Click(object sender, EventArgs e)
        {
            AddRoom ad = new AddRoom();
            ad.ShowDialog();
            LoadRoomData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //LoadFullRoomType();
                //LoadFullRoomStatus();
                //LoadFullRoom(RoomDAO.Instance.Search(cbStatusSearch.Text));

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex);
            }
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormQuanLyPhong_Load(object sender, EventArgs e)
        {

        }

        private void ConfigureDataGridView()
        {
            // Make sure all columns are visible
            dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ensure all columns from your data source are displayed
            dgvRoom.AutoGenerateColumns = true; // If you want to automatically generate columns from data source

           

            // Make sure all columns are visible
            foreach (DataGridViewColumn col in dgvRoom.Columns)
            {
                col.Visible = true;
            }
        }

        // When binding data to the DataGridView, make sure all properties are included
        private void LoadRoomData()
        {
            string query = @"SELECT p.*, lp.TenLoaiPhong, lp.SucChua, lp.DonGia, lp.HinhAnh
                                FROM Phong p INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvRoom.DataSource = dt; // Gán dữ liệu vào DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Refresh the DataGridView
            dgvRoom.Refresh();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

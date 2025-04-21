using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormTimKhachHang : Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        private DataTable searchResults;

        // Thay đổi từ DataTable sang List<DataRow> để lưu nhiều khách hàng đã chọn
        public DataTable SelectedCustomers { get; private set; }

        public FormTimKhachHang()
        {
            InitializeComponent();
            // Khởi tạo DataTable để lưu danh sách khách hàng đã chọn
            SelectedCustomers = new DataTable();
            SelectedCustomers.Columns.Add("MaKhachHang", typeof(int));
            SelectedCustomers.Columns.Add("HoTen", typeof(string));
            SelectedCustomers.Columns.Add("CCCD", typeof(string));
            SelectedCustomers.Columns.Add("DiaChi", typeof(string));
            SelectedCustomers.Columns.Add("SoDienThoai", typeof(string));
        }

        private void FormTimKhachHang_Load(object sender, EventArgs e)
        {
            if (cbSearchType.Items.Count > 0)
            {
                cbSearchType.SelectedIndex = 0;
            }

            ConfigureDataGridView();
            LoadAllCustomers();
            txtSearch.Focus();
            btnSelect.Text = "Thêm đã chọn";
        }

        private void ConfigureDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;

            if (dgvCustomers.Columns["MaKhachHang"] != null)
                dgvCustomers.Columns["MaKhachHang"].DataPropertyName = "MaKhachHang";

            if (dgvCustomers.Columns["HoTen"] != null)
                dgvCustomers.Columns["HoTen"].DataPropertyName = "HoTen";

            if (dgvCustomers.Columns["CCCD"] != null)
                dgvCustomers.Columns["CCCD"].DataPropertyName = "CCCD";

            if (dgvCustomers.Columns["DiaChi"] != null)
                dgvCustomers.Columns["DiaChi"].DataPropertyName = "DiaChi";

            if (dgvCustomers.Columns["SoDienThoai"] != null)
                dgvCustomers.Columns["SoDienThoai"].DataPropertyName = "SoDienThoai";
        }

        private void LoadAllCustomers()
        {
            this.Cursor = Cursors.WaitCursor;

            string query = @"
                SELECT MaKhachHang, HoTen, CCCD, DiaChi, SoDienThoai
                FROM KhachHang
                ORDER BY HoTen";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        searchResults = dt;
                        dgvCustomers.DataSource = dt;

                        btnSelect.Enabled = dt.Rows.Count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa nhập từ khóa tìm kiếm
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SearchCustomers();
        }

        private void SearchCustomers()
        {
            string searchType = cbSearchType.SelectedItem.ToString();
            string searchColumn;
            string searchValue = txtSearch.Text.Trim();

            switch (searchType)
            {
                case "Tên khách hàng":
                    searchColumn = "HoTen";
                    break;
                case "Số điện thoại":
                    searchColumn = "SoDienThoai";
                    string phonePattern = @"^(\+?\d{1,4}[\s\-]?)?\(?\d{3,4}\)?[\s\-]?\d{3,4}[\s\-]?\d{3,4}$";
                    if (!string.IsNullOrEmpty(searchValue) && !Regex.IsMatch(searchValue, phonePattern))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập lại.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "CMND/CCCD":
                    searchColumn = "CCCD";
                    break;
                default:
                    searchColumn = "HoTen";
                    break;
            }

            string query;

            if (searchColumn == "HoTen")
            {
                query = $@"
                    SELECT MaKhachHang, HoTen, CCCD, DiaChi, SoDienThoai
                    FROM KhachHang
                    WHERE {searchColumn} LIKE @searchValue
                    ORDER BY HoTen";
                searchValue = "%" + searchValue + "%";
            }
            else
            {
                query = $@"
                    SELECT MaKhachHang, HoTen, CCCD, DiaChi, SoDienThoai
                    FROM KhachHang
                    WHERE {searchColumn} = @searchValue
                    ORDER BY HoTen";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@searchValue", searchValue);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            searchResults = dt;
                            dgvCustomers.DataSource = dt;

                            // Cập nhật UI dựa trên kết quả tìm kiếm
                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Không tìm thấy khách hàng nào!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnSelect.Enabled = false;
                            }
                            else
                            {
                                btnSelect.Enabled = true;
                            }

                            UpdateCheckboxStatus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCheckboxStatus()
        {
            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                int maKH = Convert.ToInt32(row.Cells["MaKhachHang"].Value);

                bool isSelected = false;
                foreach (DataRow selectedRow in SelectedCustomers.Rows)
                {
                    if (Convert.ToInt32(selectedRow["MaKhachHang"]) == maKH)
                    {
                        isSelected = true;
                        break;
                    }
                }

                row.Cells["Select"].Value = isSelected;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true; 
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
           
            if (SelectedCustomers.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một khách hàng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != 0)
            {
                
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                bool currentValue = row.Cells["Select"].Value != null && (bool)row.Cells["Select"].Value;
                row.Cells["Select"].Value = !currentValue;

               
                UpdateSelectedCustomers(e.RowIndex, !currentValue);
            }
        }

        
        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) 
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                bool currentValue = row.Cells["Select"].Value != null && (bool)row.Cells["Select"].Value;
                row.Cells["Select"].Value = !currentValue;

                UpdateSelectedCustomers(e.RowIndex, !currentValue);
            }
        }

        private void UpdateSelectedCustomers(int rowIndex, bool isSelected)
        {
            if (rowIndex < 0 || rowIndex >= searchResults.Rows.Count)
                return;

            int maKH = Convert.ToInt32(searchResults.Rows[rowIndex]["MaKhachHang"]);

            if (isSelected)
            {
                bool exists = false;
                foreach (DataRow row in SelectedCustomers.Rows)
                {
                    if (Convert.ToInt32(row["MaKhachHang"]) == maKH)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    // Thêm khách hàng vào danh sách đã chọn
                    DataRow newRow = SelectedCustomers.NewRow();
                    newRow["MaKhachHang"] = searchResults.Rows[rowIndex]["MaKhachHang"];
                    newRow["HoTen"] = searchResults.Rows[rowIndex]["HoTen"];
                    newRow["CCCD"] = searchResults.Rows[rowIndex]["CCCD"];
                    newRow["DiaChi"] = searchResults.Rows[rowIndex]["DiaChi"];
                    newRow["SoDienThoai"] = searchResults.Rows[rowIndex]["SoDienThoai"];
                    SelectedCustomers.Rows.Add(newRow);
                }
            }
            else
            {
                // Xóa khách hàng khỏi danh sách đã chọn
                for (int i = SelectedCustomers.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(SelectedCustomers.Rows[i]["MaKhachHang"]) == maKH)
                    {
                        SelectedCustomers.Rows.RemoveAt(i);
                        break;
                    }
                }
            }

            // Cập nhật trạng thái nút Chọn
            btnSelect.Text = $"Thêm đã chọn ({SelectedCustomers.Rows.Count})";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
using BLL;
using BLL.DAO;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormThongKe : Form
    {
        string connectionString = "Data Source=(local);Initial Catalog=Hotel2025;Integrated Security=True";

        public FormThongKe()
        {
            InitializeComponent();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            dateStart.Value = DateTime.Today.AddDays(-1);
            dateEnd.Value = DateTime.Today;
            TongThuNhap(dateStart.Value, dateEnd.Value);
            DoanhThuNgay(dateStart.Value, dateEnd.Value);
            top3(dateStart.Value, dateEnd.Value);
            TiLeLap(dateStart.Value, dateEnd.Value);
            TongKhach(dateStart.Value, dateEnd.Value);
            TongPhongDat(dateStart.Value, dateEnd.Value);
            TongDichVu(dateStart.Value, dateEnd.Value);
            UpdateDataGridView(dateStart.Value, dateEnd.Value);
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("DateTimePicker_ValueChanged triggered");

            DateTime startDate = dateStart.Value;
            DateTime endDate = dateEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateDataGridView(startDate, endDate);
        }

        private async void GenerateCharts()
        {
            DateTime startDate = dateStart.Value;
            DateTime endDate = dateEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool hasDataRevenue = false;
            bool hasDataRoomType = false;
            await Task.WhenAll(
                Task.Run(() => hasDataRevenue = DoanhThuNgay(startDate, endDate)),
                Task.Run(() => hasDataRoomType = top3(startDate, endDate))
            );

            // Tính tổng thu nhập
            decimal totalRevenue = TongThuNhap(startDate, endDate);

            // Hiển thị tổng thu nhập lên txtTongThuNhap
            txtTongThuNhap.Invoke((MethodInvoker)(() =>
            {
                txtTongThuNhap.Text = $"{totalRevenue:N0}"; // Hiển thị với định dạng số nguyên
            }));

            // Tính tỷ lệ lấp đầy phòng
            decimal occupancyRate = TiLeLap(startDate, endDate);

            // Ghi log giá trị tỷ lệ lấp đầy
            Console.WriteLine($"Tỷ lệ lấp đầy được tính: {occupancyRate}%");

            // Hiển thị tỷ lệ lấp đầy lên txtTiLe
            txtTiLe.Invoke((MethodInvoker)(() =>
            {
                txtTiLe.Text = $"{occupancyRate:F2}%"; // Hiển thị tỷ lệ với 2 chữ số thập phân
            }));
            // Tính tổng số khách
            int totalGuests = TongKhach(startDate, endDate);

            // Hiển thị tổng số khách lên txtTongSoKhach
            txtTongSoKhach.Invoke((MethodInvoker)(() =>
            {
                txtTongSoKhach.Text = totalGuests.ToString();
            }));
            // Tính tổng số phòng đã đặt
            int totalBookedRooms = TongPhongDat(startDate, endDate);

            // Hiển thị tổng số phòng đã đặt lên txtSoPhongDaDat
            txtSoPhongDaDat.Invoke((MethodInvoker)(() =>
            {
                txtSoPhongDaDat.Text = totalBookedRooms.ToString();
            }));
            // Tính tổng số dịch vụ đã sử dụng
            int totalServicesUsed = TongDichVu(startDate, endDate);

            // Hiển thị tổng số dịch vụ đã sử dụng lên txtSoDichVuDaDung
            txtSoDichVuDaDung.Invoke((MethodInvoker)(() =>
            {
                txtSoDichVuDaDung.Text = totalServicesUsed.ToString();
            }));

            // Hiển thị thông báo nếu không có dữ liệu
            if (!hasDataRevenue && !hasDataRoomType)
            {
                MessageBox.Show("Không có dữ liệu trong khoảng thời gian được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool DoanhThuNgay(DateTime startDate, DateTime endDate)
        {
            bool hasData = false; // Initialize to false
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_DoanhThuNgay", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh Thu Ngày")
                            {
                                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column
                            };

                            while (reader.Read())
                            {
                                hasData = true;
                                DateTime date = reader.GetDateTime(0);
                                decimal revenue = reader.GetDecimal(1);
                                series.Points.AddXY(date.ToString("dd/MM/yyyy"), revenue);
                            }

                            chartDoanhThu.Invoke((MethodInvoker)(() =>
                            {
                                chartDoanhThu.Series.Clear();
                                if (hasData)
                                {
                                    chartDoanhThu.Series.Add(series);
                                }
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biểu đồ doanh thu ngày: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasData;
        }

        private bool top3(DateTime startDate, DateTime endDate)
        {
            bool hasData = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_top3", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Doanh Thu Loại Phòng")
                            {
                                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
                            };

                            while (reader.Read())
                            {
                                hasData = true; // Data exists
                                string roomType = reader.GetString(0);
                                decimal revenue = reader.GetDecimal(1);
                                series.Points.AddXY(roomType, revenue);
                            }

                            chartLoaiPhong.Invoke((MethodInvoker)(() =>
                            {
                                chartLoaiPhong.Series.Clear();
                                if (hasData)
                                {
                                    chartLoaiPhong.Series.Add(series);
                                }
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo biểu đồ loại phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return hasData;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void chartLoaiPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnHomnay_Click(object sender, EventArgs e)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);

            dateStart.ValueChanged -= DateTimePicker_ValueChanged;
            dateEnd.ValueChanged -= DateTimePicker_ValueChanged;

            dateStart.Value = yesterday;
            dateEnd.Value = yesterday;

            dateStart.ValueChanged += DateTimePicker_ValueChanged;
            dateEnd.ValueChanged += DateTimePicker_ValueChanged;

            GenerateCharts();
        }
        private void btn7ngay_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime sevenDaysAgo = today.AddDays(-7);

            dateStart.ValueChanged -= DateTimePicker_ValueChanged;
            dateEnd.ValueChanged -= DateTimePicker_ValueChanged;

            dateStart.Value = sevenDaysAgo;
            dateEnd.Value = today;

            dateStart.ValueChanged += DateTimePicker_ValueChanged;
            dateEnd.ValueChanged += DateTimePicker_ValueChanged;

            GenerateCharts();
        }

        private void btn30ngay_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime thirtyDaysAgo = today.AddDays(-30);

            dateStart.ValueChanged -= DateTimePicker_ValueChanged;
            dateEnd.ValueChanged -= DateTimePicker_ValueChanged;

            dateStart.Value = thirtyDaysAgo;
            dateEnd.Value = today;

            dateStart.ValueChanged += DateTimePicker_ValueChanged;
            dateEnd.ValueChanged += DateTimePicker_ValueChanged;

            GenerateCharts();
        }

        private void btn1nam_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime oneYearAgo = today.AddDays(-365);

            dateStart.ValueChanged -= DateTimePicker_ValueChanged;
            dateEnd.ValueChanged -= DateTimePicker_ValueChanged;

            dateStart.Value = oneYearAgo;
            dateEnd.Value = today;

            dateStart.ValueChanged += DateTimePicker_ValueChanged;
            dateEnd.ValueChanged += DateTimePicker_ValueChanged;

            GenerateCharts();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTongThuNhap_TextChanged(object sender, EventArgs e)
        {

        }
        private decimal TongThuNhap(DateTime startDate, DateTime endDate)
        {
            decimal totalRevenue = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_TongThuNhap", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Kiểm tra nếu giá trị có tồn tại trong cột "TongDoanhThu"
                                if (!reader.IsDBNull(reader.GetOrdinal("TongDoanhThu")))
                                {
                                    totalRevenue = reader.GetDecimal(reader.GetOrdinal("TongDoanhThu"));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng thu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalRevenue;
        }
        private decimal TiLeLap(DateTime startDate, DateTime endDate)
        {
            decimal occupancyRate = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_TiLeLap", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.Date) { Value = startDate.Date });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.Date) { Value = endDate.Date });
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                occupancyRate = reader.GetDecimal(reader.GetOrdinal("TiLeLapPhanTram"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tỷ lệ lấp đầy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return occupancyRate;
        }
        private int TongKhach(DateTime startDate, DateTime endDate)
        {
            int totalGuests = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_TongKhach", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalGuests = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số khách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalGuests;
        }
        private int TongPhongDat(DateTime startDate, DateTime endDate)
        {
            int totalBookedRooms = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_TongPhongDat", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate });
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalBookedRooms = Convert.ToInt32(result);
                        }
                    }
                }
                this.dateStart.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
                this.dateEnd.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số phòng đã đặt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalBookedRooms;
        }
        private int TongDichVu(DateTime startDate, DateTime endDate)
        {
            int totalServicesUsed = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_TongDichVu", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate });

                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalServicesUsed = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính tổng số dịch vụ đã sử dụng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalServicesUsed;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateStart.Value;
            DateTime endDate = dateEnd.Value;

            if (startDate > endDate)
            {
                MessageBox.Show("Thời gian bắt đầu không được lớn hơn thời gian kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalRevenue = TongThuNhap(startDate, endDate);
            txtTongThuNhap.Text = $"{totalRevenue:N0}";

            decimal occupancyRate = TiLeLap(startDate, endDate);
            txtTiLe.Text = $"{occupancyRate:F2}%";

            int totalGuests = TongKhach(startDate, endDate);
            txtTongSoKhach.Text = totalGuests.ToString();

            int totalBookedRooms = TongPhongDat(startDate, endDate);
            txtSoPhongDaDat.Text = totalBookedRooms.ToString();

            int totalServicesUsed = TongDichVu(startDate, endDate);
            txtSoDichVuDaDung.Text = totalServicesUsed.ToString();
            GenerateCharts();
            UpdateDataGridView(startDate, endDate);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UpdateDataGridView(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            MaLoaiPhong, 
                            TenLoaiPhong, 
                            TongSoPhongHoatDong, 
                            SoPhongDaDatTrongKy, 
                            SoPhongTrongDuKien, 
                            TrangThaiDuDoan
                        FROM dbo.ufn_DuDoanTinhTrangPhong(@NgayBatDau, @NgayKetThuc)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@NgayBatDau", SqlDbType.DateTime) { Value = startDate });
                        command.Parameters.Add(new SqlParameter("@NgayKetThuc", SqlDbType.DateTime) { Value = endDate });
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            guna2DataGridView1.AutoGenerateColumns = false;
                            guna2DataGridView1.Columns["Column1"].DataPropertyName = "MaLoaiPhong";
                            guna2DataGridView1.Columns["Column2"].DataPropertyName = "TenLoaiPhong";
                            guna2DataGridView1.Columns["Column3"].DataPropertyName = "TongSoPhongHoatDong";
                            guna2DataGridView1.Columns["Column4"].DataPropertyName = "SoPhongDaDatTrongKy";
                            guna2DataGridView1.Columns["Column5"].DataPropertyName = "SoPhongTrongDuKien";
                            guna2DataGridView1.Columns["Column6"].DataPropertyName = "TrangThaiDuDoan";

                            guna2DataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

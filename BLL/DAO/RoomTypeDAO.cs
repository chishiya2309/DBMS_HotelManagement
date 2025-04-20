using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;

        public DataTable LoadFullRoomType()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LoadFullRoomType", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Lỗi khi hiển thị đầy đủ các loại phòng đang có: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dt;
        }

        public RoomType GetRoomTypeById(string maLoaiPhong)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM LoaiPhong WHERE MaLoaiPhong = @MaLoaiPhong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLoaiPhong", maLoaiPhong);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Load(reader);
                    if (data.Rows.Count > 0)
                        return new RoomType(data.Rows[0]);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy loại phòng theo mã: {ex.Message}");
                }
            }
            return null;
        }

        public DataTable GetAllRoomTypes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM LoaiPhong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi lấy danh sách loại phòng: {ex.Message}");
                }
            }
            return dt;
        }

        public static RoomTypeDAO Instance
        {
            get { if (instance == null) instance = new RoomTypeDAO(); return instance; }
            private set => instance = value;
        }
        public RoomTypeDAO() { }
    }
}

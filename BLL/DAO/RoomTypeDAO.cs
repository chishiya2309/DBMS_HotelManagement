using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance;

        public DataTable LoadFullRoomType()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadFullRoomType");
        }

        public bool InsertRoomType(RoomType roomType)
        {
            string query = "sp_InsertRoomType @MaLoaiPhong, @TenLoaiPhong, @DonGia, @TienNghi, @SucChua, @KhaNangKeThemGiuong, @MoTa, @HinhAnh";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] {
                roomType.MaLoaiPhong,
                roomType.TenLoaiPhong,
                roomType.DonGia,
                roomType.TienNghi,
                roomType.SucChua,
                roomType.KhaNangKeThemGiuong,
                (object)roomType.MoTa ?? DBNull.Value,
                (object)roomType.HinhAnh ?? DBNull.Value
            }) > 0;
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

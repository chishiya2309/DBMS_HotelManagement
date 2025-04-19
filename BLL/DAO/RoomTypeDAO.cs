using DAL;
using System;
using System.Collections.Generic;
using System.Data;
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

        public bool UpdateRoomType(RoomType roomType)
        {
            string query = "sp_UpdateRoomType @MaLoaiPhong, @TenLoaiPhong, @DonGia, @TienNghi, @SucChua, @KhaNangKeThemGiuong, @MoTa, @HinhAnh";
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

        public List<RoomType> LoadListRoomType()
        {
            string query = "SELECT * FROM LoaiPhong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<RoomType> listRoomType = new List<RoomType>();
            foreach (DataRow item in data.Rows)
            {
                RoomType roomType = new RoomType(item);
                listRoomType.Add(roomType);
            }
            return listRoomType;
        }

        public RoomType GetRoomTypeById(string maLoaiPhong)
        {
            string query = "SELECT * FROM LoaiPhong WHERE MaLoaiPhong = @MaLoaiPhong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { maLoaiPhong });
            if (data.Rows.Count > 0)
                return new RoomType(data.Rows[0]);
            return null;
        }

        public RoomType GetRoomTypeByIdRoom(int idRoom)
        {
            string query = "USP_GetRoomTypeByIdRoom @idRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom });
            if (data.Rows.Count > 0)
                return new RoomType(data.Rows[0]);
            return null;
        }

        public RoomType GetRoomTypeByIdBookRoom(int idBookRoom)
        {
            string query = "USP_GetRoomTypeByIdBookRoom @idBookRoom";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
            if (data.Rows.Count > 0)
                return new RoomType(data.Rows[0]);
            return null;
        }

        public static RoomTypeDAO Instance
        {
            get { if (instance == null) instance = new RoomTypeDAO(); return instance; }
            private set => instance = value;
        }
        public RoomTypeDAO() { }
    }
}

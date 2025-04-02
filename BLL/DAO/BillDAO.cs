using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public DataTable LoadBill()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadBill");
        }

        public DataTable FindBillbyBookRoom(int id)
        {
            string query = "sp_FindBillbyBookRoom @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public DataTable FindRoomByBill(int id)
        {
            string query = "sp_FindRoomByBill @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public bool UpdateStatusBill(int id, string status)
        {
            string query = "sp_UpdateStatusBill @id , @status";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, status }) > 0;
        }

        public bool InsertBill(Bill b)
        {
            string query = "sp_InsertBill @PhuThu , @NoiDungPhuThu , @GiamGia , @ThanhTien , @TinhTrangThanhToan , @MaHoSoDatPhong , @MaNhanVien";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { b.Surchange, b.SurchangeInfo, b.Discount, b.TotalPrice, b.Status, b.IdBookRoom, b.StaffSetUp }) > 0;
        }

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }
    }
}

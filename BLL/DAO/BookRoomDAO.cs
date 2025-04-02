using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAO
{
    public class BookRoomDAO
    {
        private BookRoomDAO() { }

        private static BookRoomDAO instance;

        public DataTable LoadBookRoom()
        {
            return DataProvider.Instance.ExecuteQuery("sp_LoadBookRoom");
        }

        public bool InsertBookRoom(BookingRecord bk)
        {
            string query = "sp_InsertBookRoom @deposit , @status , @dateCheckIn , @dateCheckOut , @days , @idRoom , @idCustomer";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { bk.Deposit, bk.Status, bk.DateCheckIn, bk.DateCheckOut, bk.Days , bk.IdRoom , bk.IdCustomer }) > 0;
        }

        public bool UpdateBookRoom(int idBookRoom, string status, int idRoom)
        {
            string query = "sp_UpdateBookRoom @id , @status , @idRoom";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idBookRoom, status, idRoom }) > 0;
        }

        public DataTable Search(int id)
        {
            string query = "sp_SearchBookRoom @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public DataTable FindRoomTypeByBookRoom(int id)
        {
            string query = "sp_FindRoomTypeByBookRoom @id";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        public static BookRoomDAO Instance
        {
            get { if (instance == null) instance = new BookRoomDAO(); return instance; }
            private set => instance = value;
        }

    }
}

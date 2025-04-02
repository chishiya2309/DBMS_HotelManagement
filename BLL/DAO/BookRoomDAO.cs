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

        public void ConfirmBookRoomBonus(int MaHoSoDatPhong, DateTime checkin, DateTime checkout, string note)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "sp_ConfirmBookRoomBonus";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHoSoDatPhong", MaHoSoDatPhong);
                cmd.Parameters.AddWithValue("@Checkin", checkin);
                cmd.Parameters.AddWithValue("@Checkout", checkout);
                cmd.Parameters.AddWithValue("@Note", note);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Ghi nhận thành công");
                    }
                    else
                    {
                        MessageBox.Show("Ghi nhận thất bại");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi ghi nhận hồ sơ đặt phòng: " + ex.Message);
                }
            }
        }

        //public DataTable Search(int id)
        //{
        //    string query = "sp_SearchBookRoom @id";
        //    return DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        //}

        public DataTable Search(int idBookRoom)
        {
            //string query = "sp_SearchUsedServiceInfo @id";
            //return DataProvider.Instance.ExecuteQuery(query, new object[] { idBookRoom });
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "sp_SearchBookRoom";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MaHoSoDatPhong", idBookRoom);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi tìm kiếm hồ sơ đặt phòng: {ex.Message}");
                }
            }

            return dt;

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

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
    public class UsedServiceInfoDAO
    {
        public UsedServiceInfoDAO() { }

        private static UsedServiceInfoDAO instance;

        public DataTable Search(int idBookRoom)
        {
            
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "sp_SearchUsedServiceInfo";
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
                    Console.WriteLine($"Lỗi khi tìm kiếm hồ sơ đặt dịch vụ: {ex.Message}");
                }
            }

            return dt;

        }

        public void DatDichVu(string maDichVu, int maHoSoDatPhong, int soluong)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "sp_BookService";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idService", maDichVu);
                cmd.Parameters.AddWithValue("@idBookRoom", maHoSoDatPhong);
                cmd.Parameters.AddWithValue("@count", soluong);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đặt dịch vụ thành công");
                    }
                    else
                    {
                        MessageBox.Show("Đặt dịch vụ thất bại");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi đặt dịch vụ: " + ex.Message);
                }
            }
        }

        public bool InsertUsedService(int idService, int count, double totalPrice, int idBookRoom)
        {
            string query = "sp_InsertUsedService @idService , @count , @totalPrice , @idBookRoom";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idService, count, totalPrice, idBookRoom }) > 0;
        }

        public bool UpdateUsedService(int idService, int count, double totalPrice, int idBookRoom)
        {
            string query = "sp_UpdateUsedService @idService , @count , @totalPrice , @idBookRoom";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idService, count, totalPrice, idBookRoom }) > 0;
        }

        public static UsedServiceInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UsedServiceInfoDAO();
                return instance;
            }
            private set => instance = value;
        }
    }
}

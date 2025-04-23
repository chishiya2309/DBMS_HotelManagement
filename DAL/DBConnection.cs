using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {

        private  static string connectionString = "Data Source=(local)\\SQLExpress;Initial Catalog=Hotel2025;Integrated Security=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        private static DBConnection instance;

        public DBConnection()
        {
            
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            return data;
        }

        public static string GetSqlServerName()
        {
            string query = "SELECT @@SERVERNAME;";
            string serverName = null;

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            serverName = result.ToString();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL khi lấy tên server: {ex.Message}");
            }

            return serverName;
        }


            public static DBConnection Instance
        {
            get { if (instance == null) instance = new DBConnection(); return instance; }
            private set => instance = value;
        }
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
    }

}

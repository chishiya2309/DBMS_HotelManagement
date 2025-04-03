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

        private static readonly string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Hotel2025;Integrated Security=True";
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
        public static DBConnection Instance
        {
            get { if (instance == null) instance = new DBConnection(); return instance; }
            private set => instance = value;
        }
    }

}

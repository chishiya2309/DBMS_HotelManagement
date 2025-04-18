﻿using DAL;
using QLKS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.DAO
{
    public class CustomerDAO
    {
        public CustomerDAO() { }

        private static CustomerDAO instance;


        public void InsertCustomer(string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi,
            string sdt, string email, string loaikhachhang, string tinhtrang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_InsertCustomer";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Hoten", Hoten);
                cmd.Parameters.AddWithValue("@Gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Sodienthoai", sdt);
                cmd.Parameters.AddWithValue("@LoaiKhachHang", loaikhachhang);
                cmd.Parameters.AddWithValue("@TinhTrangDatPhong", tinhtrang);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm khách hàng. Hãy kiểm tra lại thông tin");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateCustomer(int id, string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi, 
            string sdt, string email, string loaikhachhang, string tinhtrang)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "sp_UpdateCustomer";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKhachHang", id);
                cmd.Parameters.AddWithValue("@Hoten", Hoten);
                cmd.Parameters.AddWithValue("@Gioitinh", gioitinh);
                cmd.Parameters.AddWithValue("@Ngaysinh", ngaysinh);
                cmd.Parameters.AddWithValue("@CCCD", CCCD);
                cmd.Parameters.AddWithValue("@Diachi", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@Sodienthoai", sdt);
                cmd.Parameters.AddWithValue("@LoaiKhachHang", loaikhachhang);
                cmd.Parameters.AddWithValue("@TinhTrangDatPhong", tinhtrang);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin cơ bản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin thất bại");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
        }


        public DataTable LoadFullCustomer()
        {
            string query = "sp_LoadFullCustomer";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool DeleteCustomer(int idCustomer)
        {
            string query = "sp_DeteleCustomer @id";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { idCustomer }) > 0;
        }


        public DataTable Search(string searchString, int searchMode)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * from dbo.fn_SearchCustomer(@string,@mode)";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@string", searchString);
                cmd.Parameters.AddWithValue("@mode", searchMode);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Tìm thấy {dt.Rows.Count} khách hàng phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return dt;
        }
        public int GetIDCustomerFromBookRoom(int idBookRoom)
        {
            string query = "sp_GetIdCustomerFromBookRoom @idBookRoom";
            return (int)DataProvider.Instance.ExecuteScalar(query, new object[] { idBookRoom });
        }



        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }
    }
}

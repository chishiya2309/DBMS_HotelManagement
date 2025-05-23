﻿using DAL;
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
    public class ServiceDAO
    {
        private static ServiceDAO instance;
        public void InsertDichVu(string maDichVu, string tenDichVu, string loaiDichVu, string trangThai, double donGia, string moTa)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "sp_InsertService";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);
                cmd.Parameters.AddWithValue("@TenDichVu", tenDichVu);
                cmd.Parameters.AddWithValue("@LoaiDichVu", loaiDichVu);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi thêm dịch vụ: " + ex.Message);
                }
            }
        }

        public void UpdateDichVu(string maDichVu, string tenDichVu, string loaiDichVu, string trangThai, double donGia, string moTa)
        {
            using (SqlConnection conn = DBConnection.GetConnection()) {

                string query = "sp_UpdateService";

                SqlCommand cmd = new SqlCommand(query, conn);
            
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);
                cmd.Parameters.AddWithValue("@TenDichVu", tenDichVu);
                cmd.Parameters.AddWithValue("@LoaiDichVu", loaiDichVu);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@DonGia", donGia);
                cmd.Parameters.AddWithValue("@MoTa", moTa);

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi cập nhật dịch vụ: " + ex.Message);
                }
            }
        }


        public void DeleteDichVu(string MaDichVu)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {

                string query = "sp_DeleteService";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDichVu", MaDichVu);
                

                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xoá thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại, kiểm tra lại id dịch vụ!");
                    }

                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi khi xoá dịch vụ: " + ex.Message);
                }
            }
        }

        public DataTable Search(string name)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM dbo.fn_SearchService(@TenDichVu)";
                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@TenDichVu", name);

                try
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi khi tìm kiếm dịch vụ: {ex.Message}");
                }

            }

            return dt;
        }


        public static ServiceDAO Instance
        {
            get { if (instance == null) instance = new ServiceDAO(); return instance; }
            private set => instance = value;
        }
    }
}

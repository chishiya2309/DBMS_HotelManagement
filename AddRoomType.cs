using BLL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class AddRoomType: Form
    {
        private string connectionString = "Data Source=(local)\\SQLExpress;Database=Hotel2025;Integrated Security=True";
        private string imagePath;
        private byte[] imageData;
        public AddRoomType()
        {
            InitializeComponent();
        }

        private void InsertRoomType()
        {
            try
            {
                // Đọc file ảnh và chuyển đổi thành byte array
                if (!string.IsNullOrEmpty(imagePath))
                {
                    imageData = File.ReadAllBytes(imagePath);
                }

                // Kết nối database và thêm dữ liệu thông qua stored procedure
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertRoomType", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm các tham số theo đúng thứ tự của stored procedure
                        cmd.Parameters.AddWithValue("@MaLoaiPhong", txtMaLoaiPhong.Text);
                        cmd.Parameters.AddWithValue("@TenLoaiPhong", txtTenLoaiPhong.Text);
                        cmd.Parameters.AddWithValue("@DonGia", decimal.Parse(txtDonGia.Text));
                        cmd.Parameters.AddWithValue("@TienNghi", textBox1.Text);
                        cmd.Parameters.AddWithValue("@SucChua", (int)nudSucChua.Value);
                        cmd.Parameters.AddWithValue("@KhaNangKeThemGiuong", checkBox1.Checked);
                        cmd.Parameters.AddWithValue("@MoTa", textBox2.Text);

                        if (imageData != null)
                        {
                            cmd.Parameters.AddWithValue("@HinhAnh", (object)imageData);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm loại phòng mới thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm loại phòng mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                InsertRoomType();
            }
        }

        private void AddRoomType_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(imagePath);
                    lblImageName.Text = "Hình ảnh: " + Path.GetFileName(imagePath);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

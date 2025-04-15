using BLL;
using BLL.DAO;
using DAL;
using QLKS.Properties;
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
    public partial class FormThongTin: Form
    {
        
        public FormThongTin(int id)
        {
            InitializeComponent();
            LoadProfile(id);
            idStaff = id;
        }

        public int idStaff;
        DataTable dt;

        public void LoadProfile(int id)
        {

            dt = StaffDAO.Instance.SearchProfileStaffByID(id);
            

            lblUserName.Text = dt.Rows[0]["Hoten"].ToString();
            txtUser.Text = dt.Rows[0]["TenDangNhap"].ToString();
            txtName.Text = dt.Rows[0]["Hoten"].ToString();
            txtIDNum.Text = dt.Rows[0]["CCCD"].ToString();
            txtAddress.Text = dt.Rows[0]["Diachi"].ToString();
            txtPhone.Text = dt.Rows[0]["Sodienthoai"].ToString();
            dobDP.Value = dt.Rows[0]["Ngaysinh"] == DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[0]["Ngaysinh"];
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            cbSex.Text =dt.Rows[0]["Gioitinh"].ToString();
            txtStartDay.Text = dt.Rows[0]["Ngayvaolam"] == DBNull.Value ? DateTime.Now.ToString("dd/MM/yyyy") : ((DateTime)dt.Rows[0]["Ngayvaolam"]).ToString("dd/MM/yyyy");

            // Xử lý hình ảnh từ VARBINARY
            DataRow dataRow = dt.Rows[0];
            if (dataRow["Chandung"] != DBNull.Value)
            {
                
                byte[] imageData = (byte[])dataRow["Chandung"];
                if (imageData.Length > 0)
                {
                    picturebox.Image = null; // Đặt hình ảnh về null trước khi gán hình mới
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        picturebox.Image = Image.FromStream(ms);
                        picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    
                }
                else
                {
                    picturebox.Image = null;
                }
            }
            //else
            //{
            //    picturebox.Image = Resources.clipart4371249;
            //}

            txtUser.Enabled = false;
            txtStartDay.Enabled = false;
            
        }

        public void UpdateInfo(int id, string Hoten, string gioitinh, DateTime ngaysinh, string CCCD, string diachi, string email, string sdt,
            string ngayvaolam, string vaitro, byte[] chandung)
        {
            StaffDAO.Instance.UpdateStaff(id, Hoten, gioitinh, ngaysinh, CCCD, diachi, email, sdt, ngayvaolam, vaitro, chandung);
        }

        public void UpdatePassword(string username, string password)
        {
            AccountDAO.Instance.UpdatePassword(username, password);
        }

        private void FormThongTin_Load(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private byte[] _currentImageBytes = null;
        private string _currentImagePath = null;

        private void SaveInfobtn_Click(object sender, EventArgs e)
        {
            if (txtPasspre.Text == dt.Rows[0]["MatKhau"].ToString())
            {
                try
                {
                    Image temp = new Bitmap(picturebox.Image);
                    MemoryStream ms = new MemoryStream();
                    temp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    _currentImageBytes = ms.ToArray();

                    

                    UpdateInfo(idStaff, txtName.Text, cbSex.Text, dobDP.Value, txtIDNum.Text, txtAddress.Text,txtEmail.Text, txtPhone.Text,
                        txtStartDay.Text, dt.Rows[0]["Vaitro"].ToString(), _currentImageBytes);
                    
                    txtPasspre.Text = String.Empty;
                    LoadProfile(idStaff);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Thông tin không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập đúng mật khẩu hiện tại để xác minh!", "Thông báo");
                this.txtPasspre.Focus();
            }
            
        }

        private void SavePassbtn_Click(object sender, EventArgs e)
        {
            if (txtPasspre.Text == dt.Rows[0]["MatKhau"].ToString())
            {
                try
                {
                    if (txtPassnew.Text == txtPasscon.Text)
                    {
                        UpdatePassword(txtUser.Text,txtPassnew.Text);
                        
                        txtPasspre.Text = txtPassnew.Text = txtPasscon.Text = String.Empty;
                        LoadProfile(idStaff);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới phải khớp mật khẩu xác nhận lại!", "Thông báo");
                        this.txtPasscon.Focus();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Cần nhập mật khẩu mới trên 6 ký tự!: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else{
                MessageBox.Show("Bạn cần nhập đúng mật khẩu hiện tại để xác minh!", "Thông báo");
                this.txtPasspre.Focus();
            }
        }

        private void picturebox_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _currentImagePath = openFileDialog.FileName;
                    picturebox.Image = Image.FromFile(_currentImagePath);
                    picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}

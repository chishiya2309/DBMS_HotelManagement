using BLL;
using BLL.DAO;
using DAL;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using QLKS.Properties;

namespace QLKS
{
    public partial class AddStaff: Form
    {
        
        public AddStaff()
        {
            InitializeComponent();
            cbSex.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;
            dtpDOB.Value = DateTime.Now.AddYears(-20);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            
        }

        private void InsertStaff()
        {
            bool isFill = FormNhanVien.CheckFillInText(new string[] { txtName.Text, txtAddress.Text, txtEmail.Text,
                txtIDNum.Text, txtPhone.Text, txtUser.Text, cbSex.Text });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    using (SqlConnection connection = DBConnection.GetConnection())
                    {
                        connection.Open();

                        // Bắt đầu transaction
                        //SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {

                            if (!string.IsNullOrEmpty(imagePath))
                            {
                                imageData = File.ReadAllBytes(imagePath);
                            }
                            if (imageData == null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    Resources.clipart4371249.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    imageData = ms.ToArray();
                                }
                            }

                            // lấy id của nhân viên cũ để xem có tạo được nhân viên chưa
                            FormNhanVien formNhanVien = new FormNhanVien();
                            int OldStaffId = int.Parse(formNhanVien.dgvStaff.Rows[formNhanVien.dgvStaff.Rows.Count - 1].Cells[0].Value.ToString());

                            // Thêm nhân viên và lấy MaNhanVien vừa thêm
                            StaffDAO.Instance.InsertStaff(txtName.Text.Trim(), cbSex.Text, dtpDOB.Value, txtIDNum.Text.Trim(),
                                    txtAddress.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), dtpNgayVaoLam.Value, cbRole.Text, imageData);

                            formNhanVien.LoadData(); // nếu chưa tạo được nhân viên thì không thể tạo tài khoản
                            int NewstaffId = int.Parse(formNhanVien.dgvStaff.Rows[formNhanVien.dgvStaff.Rows.Count - 1].Cells[0].Value.ToString());

                            if (OldStaffId != NewstaffId)
                            {
                                InsertAccount(NewstaffId, txtUser.Text.Trim(), "123456");
                            }
                            

                            
                            ClearForm();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void InsertAccount(int id, string user, string pass)
        {
            AccountDAO.Instance.InsertAccount(id, user, pass);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm nhân viên mới không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                InsertStaff();
            }


        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtIDNum.Clear();
            txtPhone.Clear();
            txtUser.Clear();
            cbSex.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
            dtpNgayVaoLam.Value = DateTime.Now;
            dtpDOB.Value = DateTime.Now.AddYears(-20);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Đặt DialogResult.OK để form cha biết cần refresh dữ liệu
            this.Close();
        }

        private string imagePath;
        private byte[] imageData;
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
                    picturebox.Image = Image.FromFile(imagePath);
                    picturebox.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}

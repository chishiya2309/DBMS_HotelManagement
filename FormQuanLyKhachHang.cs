﻿using BLL;
using BLL.DAO;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLKS
{
    public partial class FormQuanLyKhachHang: Form
    {
        public FormQuanLyKhachHang()
        {
            InitializeComponent();
            LoadCusData();
        }

        private void LoadCusData()
        {
            try
            {
                DataTable dt = CustomerDAO.Instance.GetAllCustomers();
                dgvCustomer.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvCustomer.Refresh();
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        
        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvCustomer.SelectedRows[0];

                    // Hiển thị thông tin phòng được chọn trực tiếp lên form
                    txtTenKhachHang.Text = row.Cells["Hoten"].Value?.ToString() ?? "";
                    txtDiaChi.Text = row.Cells["Diachi"].Value?.ToString() ?? "";
                    cbSex.Text = row.Cells["Gioitinh"].Value?.ToString() ?? "";
                    txtEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                    txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";
                    txtPhone.Text = row.Cells["Sodienthoai"].Value?.ToString() ?? "";
                    if (row.Cells["Ngaysinh"].Value != null && DateTime.TryParse(row.Cells["Ngaysinh"].Value.ToString(), out DateTime ngaySinh))
                    {
                        dtpDoB.Value = ngaySinh;
                    }
                    else
                    {
                        dtpDoB.Value = DateTime.Now; 
                    }
                    cbType.Text = row.Cells["LoaiKhachHang"].Value?.ToString() ?? "";
                    cmbTrangThai.Text = row.Cells["TinhTrangDatPhong"].Value?.ToString() ?? "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCustomer()
        {
            try
            {
                // Lấy mã khách hàng của khách hàng được chọn
                if (dgvCustomer.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maKhachHang = Convert.ToInt32(dgvCustomer.SelectedRows[0].Cells["MaKhachHang"].Value);
                CustomerDAO.Instance.UpdateCustomer(maKhachHang, txtTenKhachHang.Text.Trim(), cbSex.Text, dtpDoB.Value, txtCCCD.Text.Trim(), txtDiaChi.Text.Trim(),
                        txtPhone.Text.Trim(), txtEmail.Text.Trim(), cbType.Text, cmbTrangThai.Text);

                // Tải lại dữ liệu
                LoadCusData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin khách hàng này?",
               "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                UpdateCustomer();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            LoadCusData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá khách hàng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    int maKhachHang = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["MaKhachHang"].Value);
                    if (DeleteCus(maKhachHang))
                    {
                        MessageBox.Show($"Xoá khách hàng {maKhachHang} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCusData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá khách hàng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public bool DeleteCus(int maKhachHang)
        {
            return CustomerDAO.Instance.DeleteCustomer(maKhachHang);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text.Trim();
            int searchMode = cbSearchType.SelectedIndex;

            if (string.IsNullOrEmpty(searchString))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvCustomer.DataSource = CustomerDAO.Instance.Search(searchString, searchMode);
        }

        private void FormQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            cbSearchType.SelectedIndex = 0; 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

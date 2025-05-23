﻿using BLL;
using BLL.DAO;
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
using DAL;
using System.Xml.Linq;

namespace QLKS
{
    public partial class FormQuanLyPhong: Form
    {
        public FormQuanLyPhong()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadRoomType();
            LoadRoomData();
            
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Delete
        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá phòng này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                try
                {
                    int maPhong = Convert.ToInt32(dgvRoom.CurrentRow.Cells["MaPhong"].Value);
                    if (DeleteRoom(maPhong))
                    {
                        MessageBox.Show($"Xoá phòng {maPhong} thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRoomData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xoá phòng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public bool DeleteRoom(int id)
        {
            return RoomDAO.Instance.DeleteRoom(id);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoadRoomType()
        {
            try
            {
                DataTable dt = RoomTypeDAO.Instance.LoadFullRoomType();
                cbType.DisplayMember = "TenLoaiPhong";
                cbType.ValueMember = "MaLoaiPhong";
                cbType.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRoom_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvRoom.SelectedRows[0];
                    if (row.IsNewRow)
                    {
                        txtMaPhong.Text = string.Empty;
                        txtLimit.Text = string.Empty;
                        txtTenPhong.Text = string.Empty;
                        txtPrice.Text = string.Empty;
                    }
                    else
                    {
                        // Hiển thị thông tin phòng được chọn trực tiếp lên form
                        txtMaPhong.Text = row.Cells["MaPhong"].Value?.ToString() ?? "";
                        txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";
                        cbStatus.Text = row.Cells["TrangThai"].Value?.ToString() ?? "";
                        cbType.Text = row.Cells["TenLoaiPhong"].Value?.ToString() ?? "";
                       
                        txtLimit.Text = row.Cells["SucChua"].Value?.ToString() ?? "";
                        txtPrice.Text = row.Cells["DonGia"].Value?.ToString() ?? "";
                    }   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows.Count > 0)
            {
                EditSelectedRoom();
                LoadRoomData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phòng để chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditSelectedRoom()
        {
            if (dgvRoom.SelectedRows.Count == 0) return;

            // Lấy dòng đang chọn
            DataGridViewRow selectedRow = dgvRoom.SelectedRows[0];
            string maPhong = selectedRow.Cells["MaPhong"].Value.ToString();

            UpdateRoom fupdateRoom = new UpdateRoom(maPhong);
            if (fupdateRoom.ShowDialog() == DialogResult.OK)
            {
                LoadRoomData(); // Tải lại dữ liệu sau khi cập nhật thành công
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (UserSession.Role == "Lễ tân")
            {
                MessageBox.Show("Lễ tân không có quyền thêm phòng mới!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AddRoom ad = new AddRoom();
            ad.ShowDialog();
            LoadRoomData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRoom.DataSource = RoomDAO.Instance.SearchRoom(cbStatusSearch.Text);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex);
            }
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormQuanLyPhong_Load(object sender, EventArgs e)
        {

        }

        private void ConfigureDataGridView()
        {
            dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoom.AutoGenerateColumns = true; 

            foreach (DataGridViewColumn col in dgvRoom.Columns)
            {
                //col.Visible = true;
            }
        }
        private void LoadRoomData()
        {
            try
            {
                DataTable dt = RoomDAO.Instance.LoadRoomWithType();
                dgvRoom.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvRoom.Refresh();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

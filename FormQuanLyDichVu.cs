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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormQuanLyDichVu: Form
    {
        public FormQuanLyDichVu()
        {
            InitializeComponent();
            LoadFullServiceType();
            LoadFullService(GetFullService());
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable GetFullService()
        {
            string query = "SELECT * FROM DichVu";
            return DBConnection.Instance.ExecuteQuery(query);
        }


        public DataTable GetFullServiceType()
        {
            //return ServiceTypeDAO.Instance.LoadFullServiceType();
            string query = "SELECT LoaiDichVu FROM DichVu GROUP BY LoaiDichVu";
            return DBConnection.Instance.ExecuteQuery(query);
        }

        private void LoadFullService(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dgvService.DataSource = source;
        }

        private void LoadFullServiceType()
        {
            cbStatus.SelectedIndex = 0;
            DataTable table = GetFullServiceType();
            cbType.DataSource = table;
            cbType.DisplayMember = "LoaiDichVu";
            if (table.Rows.Count > 0) cbType.SelectedIndex = 0;
        }

        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtDescription.Text = string.Empty;

            }
            else
            {
                
                txtId.Text = row.Cells["dgvMaDichVu"].Value.ToString();
                txtName.Text = row.Cells["dgvTenDichVu"].Value as string;
                txtPrice.Text = row.Cells["dgvDonGia"].Value.ToString();
                
                cbStatus.Text = row.Cells["dgvTrangThai"].Value as string;
                cbType.Text = row.Cells["dgvLoaiDichVu"].Value.ToString();
                txtDescription.Text = row.Cells["dgvMoTa"].Value.ToString();

            }
        }

        private void dgvService_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvService.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvService.SelectedRows[0];
                ChangeText(row);
            }
        }

        //private Service GetServiceNow()
        //{
        //    Service account = new Service();

        //    // Xoá các khoảng trắng thừa
        //    //Trim(new System.Windows.Forms.TextBox[] { txtName, txtAddress });



        //    int index = cbType.SelectedIndex;
        //    account.Id = Convert.ToInt32(txtId.Text);
        //    account.IdServiceType = (int)((DataTable)cbType.DataSource).Rows[index]["id"];
        //    account.Name = txtName.Text;
        //    account.Price = Convert.ToDouble(txtPrice.Text);
        //    account.Status = cbStatus.Text;
            
        //    return account;
        //}

        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }

        private void UpdateService()
        {
            bool isFill = CheckFillInText(new Control[] { txtName, txtId, txtPrice ,cbType });
            if (!isFill)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    //int idStaff = Convert.ToInt32(dgvService.SelectedRows[0].Cells["dgvIdservice"].Value);
                    //int index = cbType.SelectedIndex;
                    //bool check1 = ServiceDAO.Instance.UpdateService(int.Parse(txtId.Text),txtName.Text, (int)((DataTable)cbType.DataSource).Rows[index]["id"],
                    //double.Parse(txtPrice.Text),cbStatus.Text);

                    ServiceDAO.Instance.UpdateDichVu(
                        txtId.Text, txtName.Text, cbType.Text, cbStatus.Text, double.Parse(txtPrice.Text),txtDescription.Text);

                    int index2 = dgvService.SelectedRows[0].Index;
                    LoadFullService(GetFullService());
                    dgvService.SelectedRows[0].Selected = false;
                    dgvService.Rows[index2].Selected = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật dịch vụ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                UpdateService();

            }
        }

        private void FormQuanLyDichVu_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            new AddService().ShowDialog();
            LoadFullService(GetFullService());
        }

        public void DeleteService(string id)
        {
            ServiceDAO.Instance.DeleteDichVu(id);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn xoá dịch vụ này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {

                try
                {
                    string id = dgvService.CurrentRow.Cells["dgvMaDichVu"].Value.ToString();
                    DeleteService(id);
                    
                    LoadFullService(GetFullService());

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFullService(ServiceDAO.Instance.Search(txtSearch.Text));
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex);
            }
        }
    }
}

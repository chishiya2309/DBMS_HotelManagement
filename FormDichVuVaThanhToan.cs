using BLL;
using BLL.DAO;
using DAL;
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
using System.Xml.Linq;

namespace QLKS
{
    public partial class FormDichVuVaThanhToan: Form
    {
        public FormDichVuVaThanhToan()
        {
            InitializeComponent();
            LoadFullAvailableService();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormDichVuVaThanhToan_Load(object sender, EventArgs e)
        {
            //txtTotal.Text = "0";
            
            txtDiscount.Text = "0";
            txtSurchange.Text = "0";
            txtTotal.Enabled = false;
            dtpRealCheckIn.Enabled = false;

        }

        // Thêm dịch vụ
        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận đặt dịch vụ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                

                bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtSearch });
                if (!isFill || nudCount.Value == 0 || dgvBookRoom.Rows.Count == 0)
                {
                    MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        //int idService = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);

                        DataRowView selectedRow = cbService.SelectedItem as DataRowView;
                        string idService = selectedRow["MaDichVu"].ToString();
                        int idBookRoom = Convert.ToInt32(dgvBookRoom.Rows[0].Cells["dgvHSDP"].Value);
                        UsedServiceInfoDAO.Instance.DatDichVu(idService, idBookRoom, (int)nudCount.Value);
                        LoadFullUsedService(SearchUsedService());

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        public DataTable SearchBookRoom()
        {
            return BookRoomDAO.Instance.Search(int.Parse(txtSearch.Text));
        }

        public void LoadFullBookRoom(DataTable dt)
        {
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvBookRoom.DataSource = source;
            txtTotal.Text = LoadTotal().ToString();

            txtDescription.Text = dt.Rows[0]["GhiChu"].ToString();
            dtpRealCheckIn.Value = dt.Rows[0]["ThoiGianCheckinThucTe"] == DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[0]["ThoiGianCheckinThucTe"];
        }

        public DataTable SearchUsedService()
        {
            return UsedServiceInfoDAO.Instance.Search(int.Parse(txtSearch.Text));
        }

        public void LoadFullUsedService(DataTable dt)
        {
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvUsedService.DataSource = source;
            txtTotal.Text = LoadTotal().ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                        LoadFullBookRoom(SearchBookRoom()); 
                        if (SearchBookRoom().Rows.Count > 0)
                            LoadFullUsedService(SearchUsedService());
                        txtTotal.Text = LoadTotal().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public DataTable GetFullAvailableService()
        {
            string query = "SELECT MaDichVu,TenDichVu,DonGia FROM DichVu WHERE DichVu.TrangThai = N'Sẵn sàng'";
            return DBConnection.Instance.ExecuteQuery(query);
        }

        public void LoadFullAvailableService()
        {
            DataTable table = GetFullAvailableService();
            cbService.DataSource = table;
            cbService.DisplayMember = "TenDichVu";
            if (table.Rows.Count > 0) cbService.SelectedIndex = 0;

        }

        

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbService.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                txtPrice.Text = selectedRow["DonGia"].ToString();
            }
        }

        public DataTable FindRoomTypeNow()
        {
            int id = int.Parse(dgvBookRoom.Rows[0].Cells["dgvIdBookRoom"].Value.ToString());
            return BookRoomDAO.Instance.FindRoomTypeByBookRoom(id);
        }

        public double LoadTotal()
        {
            if (dgvBookRoom.Rows.Count > 0)
            {
                int idBookRoom = (int)dgvBookRoom.Rows[0].Cells["dgvHSDP"].Value;
                return BillDAO.Instance.GetTotalBill(idBookRoom, double.Parse(txtSurchange.Text), double.Parse(txtDiscount.Text));
            }
            return 0;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(txtDiscount.Text, out double value1) && double.Parse(txtDiscount.Text) <= 100 && double.Parse(txtDiscount.Text) >= 0)
            {
                txtDiscount.Text = value1.ToString();
                txtTotal.Text = LoadTotal().ToString();
            }
            else
            {
                // Nếu người dùng nhập sai, hiển thị thông báo lỗi và reset giá trị
                txtDiscount.Text = "0";

            }
        }

        private void txtSurchange_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(txtSurchange.Text, out double value1) && double.Parse(txtSurchange.Text) >= 0)
            {
                txtSurchange.Text = value1.ToString();
                txtTotal.Text = LoadTotal().ToString();
            }
            else
            {
                // Nếu người dùng nhập sai, hiển thị thông báo lỗi và reset giá trị
                txtSurchange.Text = "0";

            }
        }

        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            
            
        }

        private void txtSurchange_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtSurchange_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtSurchange_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void txtSurchange_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        //public static bool CheckFillInText(Control[] controls)
        //{
        //    foreach (var control in controls)
        //    {
        //        if (control.Text == string.Empty)
        //            return false;
        //    }
        //    return true;
        //}

        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn thanh toán không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                InsertBill();
            }
        }

        private Bill GetBillNow()
        {
            Bill account = new Bill();

            

            account.Surchange = double.Parse(txtSurchange.Text);
            account.SurchangeInfo = txtSurchangeInfo.Text;
            account.DateOfCreate = DateTime.Now;
            account.Status = "Chưa thanh toán";

            account.TotalPrice = LoadTotal();
            account.Discount = double.Parse(txtDiscount.Text);
            account.IdBookRoom = int.Parse(dgvBookRoom.Rows[0].Cells["dgvHSDP"].Value.ToString());
            account.StaffSetUp = FormChinh.idStaff;

            account.Method = cbPayMethod.Text;
            
            
            return account;
        }


        public void InsertBill()
        {
            bool isFill = (dgvBookRoom.Rows.Count > 0 && cbPayMethod.Text != string.Empty);
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
                    //int index = cbRoom.SelectedIndex;
                    Bill b = GetBillNow();
                    BillDAO.Instance.InsertBill(b.Surchange,b.SurchangeInfo,b.Discount,b.TotalPrice,b.Status,b.Method, b.IdBookRoom,b.StaffSetUp);
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "0";
            txtSurchangeInfo.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtDiscount.Text = "0";
            txtSurchange.Text = "0";
            LoadFullBookRoom(SearchBookRoom());
            LoadFullUsedService(SearchUsedService());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Ghi nhận
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận thông tin chưa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                BookRoomDAO.Instance.ConfirmBookRoomBonus((int)dgvBookRoom.Rows[0].Cells["dgvHSDP"].Value,txtDescription.Text);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

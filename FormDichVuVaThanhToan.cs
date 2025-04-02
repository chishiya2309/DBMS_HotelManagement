using BLL;
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


        }

        // Thêm dịch vụ
        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận đặt dịch vụ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                

                //bool isFill = FormNhanVien.CheckFillInText(new Control[] { txtSearch });
                //if (!isFill || nudCount.Value == 0 || dgvBookRoom.RowCount == 0)
                //{
                //    MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //else
                //{
                //    try
                //    {
                //        //int idService = Convert.ToInt32(datagridviewStaff.SelectedRows[0].Cells["colidStaff"].Value);

                //        DataRowView selectedRow = cbService.SelectedItem as DataRowView;
                //        int idService = int.Parse(selectedRow["idService"].ToString());
                //        int idBookRoom = Convert.ToInt32(dgvBookRoom.Rows[0].Cells["dgvIdBookRoom"].Value);



                //        foreach (DataGridViewRow item in dgvUsedService.Rows)
                //        {
                //            if (Convert.ToInt32(item.Cells["dgvIdUsedService"].Value) == idService)
                //            {
                //                int count1 = int.Parse(item.Cells["dgvCount"].Value.ToString()) + (int)nudCount.Value;
                //                double totalPrice1 = (double)count1 * double.Parse(item.Cells["dgvServicePrice"].Value.ToString());
                //                bool check2 = UsedServiceInfoDAO.Instance.UpdateUsedService(idService, count1, totalPrice1, idBookRoom);
                //                if (check2)
                //                {
                //                    MessageBox.Show("Đặt dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                    LoadFullUsedService(SearchUsedService());
                //                }
                //                else
                //                {
                //                    MessageBox.Show("Không thể đặt dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //                }
                //                return;
                //            }
                //        }

                //        double TotalPrice = double.Parse(txtPrice.Text) * (double)nudCount.Value;
                        
                //        int count = (int)nudCount.Value;
                //        bool check1 = UsedServiceInfoDAO.Instance.InsertUsedService(idService, count, TotalPrice, idBookRoom);

                //        if (check1)
                //        {
                //            MessageBox.Show("Đặt dịch vụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            LoadFullUsedService(SearchUsedService());
                //        }
                //        else
                //        {
                //            MessageBox.Show("Không thể đặt dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //        }
                //    }
                //    catch (SqlException ex)
                //    {
                //        MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
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
            return ServiceDAO.Instance.LoadFullAvailableService();
        }

        public void LoadFullAvailableService()
        {
            DataTable table = GetFullAvailableService();
            cbService.DataSource = table;
            cbService.DisplayMember = "nameService";
            if (table.Rows.Count > 0) cbService.SelectedIndex = 0;



        }

        

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbService.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                txtPrice.Text = selectedRow["price"].ToString();
            }
        }

        public DataTable FindRoomTypeNow()
        {
            int id = int.Parse(dgvBookRoom.Rows[0].Cells["dgvIdBookRoom"].Value.ToString());
            return BookRoomDAO.Instance.FindRoomTypeByBookRoom(id);
        }

        public double LoadTotal()
        {

            DataTable dt = new DataTable();
            if (txtSearch.Text != string.Empty) dt = FindRoomTypeNow();
            
            
            double total = 0;

            if (dt.Rows.Count > 0)
            {
                total += double.Parse(dt.Rows[0]["price"].ToString());

                total -= double.Parse(dgvBookRoom.Rows[0].Cells["dgvDeposit"].Value.ToString());
            }
            total += double.Parse(txtSurchange.Text);
            

            foreach(DataGridViewRow row in dgvUsedService.Rows)
            {
                total += double.Parse(row.Cells["dgvTotalPrice"].Value.ToString());
            }

            total -= (total * double.Parse(txtDiscount.Text)) / 100;

            total = (double)Math.Ceiling(total / 1000) * 1000;

            return total;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSurchange_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            if (double.TryParse(txtDiscount.Text, out double value1) && double.Parse(txtDiscount.Text) <= 100 && double.Parse(txtDiscount.Text) >= 0)
            {
                txtDiscount.Text = value1.ToString();
            }
            else
            {
                // Nếu người dùng nhập sai, hiển thị thông báo lỗi và reset giá trị
                txtDiscount.Text = "0";

            }
            txtTotal.Text = LoadTotal().ToString();
        }

        private void txtSurchange_MouseClick(object sender, MouseEventArgs e)
        {
            if (double.TryParse(txtSurchange.Text, out double value1) && double.Parse(txtSurchange.Text) >= 0)
            {
                txtSurchange.Text = value1.ToString();
            }
            else
            {
                // Nếu người dùng nhập sai, hiển thị thông báo lỗi và reset giá trị
                txtSurchange.Text = "0";

            }
            txtTotal.Text =  LoadTotal().ToString();
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
            account.Discount = int.Parse(txtDiscount.Text);
            account.IdBookRoom = int.Parse(dgvBookRoom.Rows[0].Cells["dgvIdBookRoom"].Value.ToString());
            account.StaffSetUp = FormChinh.idStaff;

            
            return account;
        }


        public void InsertBill()
        {
            bool isFill = (dgvBookRoom.Rows.Count > 0 && dgvUsedService.Rows.Count > 0);
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
                    bool check1 = BillDAO.Instance.InsertBill(GetBillNow());


                    if (check1)
                    {
                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormDichVuVaThanhToan_Load(null, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show("Không thể thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

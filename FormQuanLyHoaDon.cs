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
    public partial class FormQuanLyHoaDon: Form
    {
        public FormQuanLyHoaDon()
        {
            InitializeComponent();
            LoadFullBill(GetFullBill());
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable GetFullBill()
        {
            return BillDAO.Instance.LoadBill();
        }

        private void LoadFullBill(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dgvBill.DataSource = source;
        }

        private void ChangeText(DataGridViewRow row)
        {
            
            if (row.IsNewRow)
            {
                txtIdBill.Text = string.Empty;
                txtRoomName.Text = string.Empty;
                txtStaffName.Text = string.Empty;
                txtTotal.Text = string.Empty;
                dtpCreate.Value = DateTime.Now;
            }
            else
            {

                txtIdBill.Text = row.Cells["dgvIdBill"].Value.ToString();
                txtStaffName.Text = row.Cells["dgvStaffName"].Value as string;
                txtTotal.Text = row.Cells["dgvTotal"].Value.ToString();

                cbStatus.Text = row.Cells["dgvStatus"].Value as string;
                if (DateTime.TryParse(row.Cells["dgvDateCreate"].Value?.ToString(), out DateTime dateCreate))
                {
                    dtpCreate.Value = dateCreate;
                }

                DataTable dt = BillDAO.Instance.FindRoomByBill(int.Parse(txtIdBill.Text));
                txtRoomName.Text = dt.Rows[0]["roomname"].ToString();

            }
        }

        private void dgvBill_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvBill.SelectedRows[0];
                ChangeText(row);
            }
        }

        private void FormQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            txtIdBill.Enabled = false;
            txtRoomName.Enabled = false;
            txtStaffName.Enabled = false;
            txtTotal.Enabled = false;
            dtpCreate.Enabled = false;
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isMouseDown)
            {
                try
                {
                    bool check = BillDAO.Instance.UpdateStatusBill(int.Parse(txtIdBill.Text), cbStatus.Text);
                    if (check)
                    {
                        MessageBox.Show("Cập nhật thành công");

                        //dgvBill.Rows[index2].Selected = true;
                        LoadFullBill(GetFullBill());
                        isMouseDown = false;

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi xảy ra: " + ex);
                }
            }
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
                    DataTable dt = BillDAO.Instance.FindBillbyBookRoom(int.Parse(txtSearch.Text));
                    if (dt.Rows.Count > 0)
                    {
                        txtIdBill.Text = dt.Rows[0]["idBill"].ToString();
                        txtRoomName.Text = dt.Rows[0]["roomname"].ToString();
                        txtStaffName.Text = dt.Rows[0]["TenNhanVien"].ToString();
                        txtTotal.Text = dt.Rows[0]["totalPrice"].ToString();
                        cbStatus.Text = dt.Rows[0]["status"].ToString();
                        dtpCreate.Text = dt.Rows[0]["dateofCreate"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Tìm không ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private bool isMouseDown;
        private void cbStatus_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

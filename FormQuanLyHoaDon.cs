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
            string query = "SELECT * FROM dbo.vw_HoaDon";
            return DBConnection.Instance.ExecuteQuery(query);
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
                txtPayMethod.Text = string.Empty;
                txtTotal.Text = string.Empty;
                dtpCreate.Value = DateTime.Now;
            }
            else
            {

                txtIdBill.Text = row.Cells["dgvMaHoaDon"].Value.ToString();
                txtPayMethod.Text = row.Cells["dgvPhuongThucThanhToan"].Value as string;
                txtTotal.Text = row.Cells["dgvThanhTien"].Value.ToString();

                cbStatus.Text = row.Cells["dgvTinhTrangThanhToan"].Value as string;
                if (DateTime.TryParse(row.Cells["dgvNgayLapHoaDon"].Value?.ToString(), out DateTime dateCreate))
                {
                    dtpCreate.Value = dateCreate;
                }

                //DataTable dt = BillDAO.Instance.SearchRoomByBill(int.Parse(txtIdBill.Text));
                txtRoomName.Text = row.Cells["dgvTenPhong"].Value as string;

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
            txtPayMethod.Enabled = false;
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
                    BillDAO.Instance.UpdateStatusBill(int.Parse(txtIdBill.Text), cbStatus.Text);
                    LoadFullBill(GetFullBill());
                    isMouseDown = false;
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
                    DataTable dt = BillDAO.Instance.FindBill(txtSearch.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txtIdBill.Text = dt.Rows[0]["MaHoaDon"].ToString();
                        txtRoomName.Text = dt.Rows[0]["TenPhong"].ToString();
                        txtPayMethod.Text = dt.Rows[0]["PhuongThucThanhToan"].ToString();
                        txtTotal.Text = dt.Rows[0]["ThanhTien"].ToString();
                        cbStatus.Text = dt.Rows[0]["TinhTrangThanhToan"].ToString();
                        dtpCreate.Text = dt.Rows[0]["NgayLapHoaDon"].ToString();

                        // Select the row in dgvBill with the corresponding MaHoaDon
                        foreach (DataGridViewRow row in dgvBill.Rows)
                        {
                            if (row.Cells["dgvMaHoaDon"].Value != null &&
                                row.Cells["dgvMaHoaDon"].Value.ToString() == txtIdBill.Text)
                            {
                                dgvBill.ClearSelection(); // Clear any previous selection
                                row.Selected = true;
                                
                                break;
                            }
                        }
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
            new FormChiTietHoaDon(int.Parse(txtIdBill.Text)).ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

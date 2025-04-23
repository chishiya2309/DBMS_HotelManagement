using BLL.DAO;
using DAL;
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
            
            if (cbStatus.Text == "Đã Thanh Toán")
            {
                cbStatus.Enabled = false;
            }
            else
            {
                cbStatus.Enabled = true;
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
                    bool check = BillDAO.Instance.UpdateStatusBill(int.Parse(txtIdBill.Text), cbStatus.Text);
                    if (check)
                    {
                        int index = dgvBill.CurrentCell.RowIndex;
                        int idBookRoom = int.Parse(dgvBill.Rows[index].Cells["dgvMaHoSoDatPhong"].Value.ToString());
                        string emailCustomer = BillDAO.Instance.SearchEmailByIdBookRoom(DBConnection.GetConnection(),idBookRoom);
                        BillDAO.Instance.SendBillToEmail(emailCustomer,
                            $"✅ Xác nhận thanh toán thành công tại khách sạn BHDV - Mã đặt phòng: {idBookRoom}", EmailBody(index),"HTML");
                    }
                    LoadFullBill(GetFullBill());
                    isMouseDown = false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi xảy ra: " + ex);
                }
            }
        }

        string EmailBody(int index)
        {
            string res = @"<div style=""font-family: Arial, Helvetica, sans-serif; line-height: 1.6; color: #333333; background-color: #f4f4f4; padding: 20px;"">
    <div style=""max-width: 650px; margin: 0 auto; background-color: #ffffff; border: 1px solid #dddddd; border-radius: 8px; overflow: hidden;"">
        <div style=""background-color: #005a87; color: #ffffff; padding: 20px; text-align: center;"">
            <h2 style=""margin: 0; font-size: 24px;"">Xác Nhận Thanh Toán Thành Công</h2>
        </div>
        <div style=""padding: 25px 30px;"">
            <p style=""font-size: 16px;"">Kính gửi Quý khách <strong>[Tên Khách Hàng]</strong>,</p>
            <p><strong>Hotel2025</strong> xin trân trọng thông báo: Chúng tôi đã nhận được khoản thanh toán của Quý khách thành công vào hệ thống.</p>
            <p>Xin chân thành cảm ơn Quý khách đã hoàn tất giao dịch. Dưới đây là thông tin chi tiết:</p>

            <div style=""background-color: #f0fff0; padding: 15px 20px; border-radius: 5px; margin: 20px 0; border-left: 5px solid #28a745;"">
                <h3 style=""margin-top: 0; margin-bottom: 15px; color: #155724; font-size: 18px;"">Chi Tiết Giao Dịch Thanh Toán</h3> <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""font-size: 14px;"">
                    <tr>
                        <td style=""padding: 6px 0; width: 180px; vertical-align: top;""><strong>Mã giao dịch:</strong></td>
                        <td style=""padding: 6px 0;""><strong>[Mã Giao Dịch]</strong></td>
                    </tr>
                    <tr>
                        <td style=""padding: 6px 0; vertical-align: top;""><strong>Ngày giờ thanh toán:</strong></td>
                        <td style=""padding: 6px 0;"">[Ngày Giờ Thanh Toán] </td>
                    </tr>
                    <tr>
                        <td style=""padding: 6px 0; vertical-align: top;""><strong>Số tiền thanh toán:</strong></td>
                        <td style=""padding: 6px 0; font-weight: bold; color: #155724;"">[Số Tiền Thanh Toán] [Đơn vị tiền tệ]</td>
                    </tr>
                    <tr>
                        <td style=""padding: 6px 0; vertical-align: top;""><strong>Phương thức thanh toán:</strong></td>
                        <td style=""padding: 6px 0;"">[Phương Thức Thanh Toán] </td>
                    </tr>
                    <tr>
                        <td style=""padding: 6px 0; vertical-align: top;""><strong>Nội dung thanh toán:</strong></td>
                        <td style=""padding: 6px 0;"">[Nội Dung Thanh Toán] </td>
                    </tr>
                    <tr>
                        <td style=""padding: 6px 0; vertical-align: top;""><strong>Mã đặt phòng liên quan:</strong></td>
                        <td style=""padding: 6px 0;"">[Mã Đặt Phòng Liên Quan] </td>
                    </tr>
                </table>
            </div>

            <p>Quý khách có thể kiểm tra lại lịch sử đặt phòng và thanh toán của mình bằng cách đăng nhập vào tài khoản trên website của chúng tôi tại [Liên kết đến trang đăng nhập/quản lý tài khoản] (nếu có).</p>
            <p>Một lần nữa, cảm ơn Quý khách đã tin tưởng và lựa chọn Hotel2025. Nếu có bất kỳ câu hỏi nào liên quan đến giao dịch này, xin vui lòng liên hệ với chúng tôi:</p>
            <ul style=""list-style: none; padding-left: 0;"">
                <li style=""margin-bottom: 5px;"">📞 Bộ phận Kế toán/CSKH: [Số điện thoại liên hệ]</li>
                <li style=""margin-bottom: 5px;"">📧 Email hỗ trợ: [Địa chỉ email hỗ trợ]</li>
            </ul>
            <p style=""margin-top: 25px;"">Chúc Quý khách một ngày tốt lành!</p>
            <p>Trân trọng,<br><strong>Phòng Kế Toán - Khách sạn Hotel2025</strong></p>
        </div>
        <div style=""background-color: #f8f8f8; color: #888888; font-size: 12px; text-align: center; padding: 15px; border-top: 1px solid #eeeeee;"">
            Đây là email được gửi tự động từ hệ thống của Hotel2025. Vui lòng không trả lời email này.
            <br>&copy; 2025 Hotel2025. Bảo lưu mọi quyền.
            <br>[Địa chỉ khách sạn]
        </div>
    </div>
</div>";

            res = res.Replace("[Tên Khách Hàng]", dgvBill.Rows[index].Cells["dgvTenKhachHang"].Value.ToString());
            res = res.Replace("[Mã Giao Dịch]", txtIdBill.Text);
            res = res.Replace("[Ngày Giờ Thanh Toán]", dtpCreate.Value.ToString());
            res = res.Replace("[Số Tiền Thanh Toán]", txtTotal.Text);
            res = res.Replace("[Đơn vị tiền tệ]", "VND");
            res = res.Replace("[Phương Thức Thanh Toán]", txtPayMethod.Text);
            res = res.Replace("[Nội Dung Thanh Toán]", "Đặt phòng và sử dụng dịch vụ");
            res = res.Replace("[Mã Đặt Phòng Liên Quan]", dgvBill.Rows[index].Cells["dgvMaHoSoDatPhong"].Value.ToString());
            res = res.Replace("[Liên kết đến trang đăng nhập/quản lý tài khoản]", "https://dreamvacationinbluehorizon.com");
            res = res.Replace("[Số điện thoại liên hệ]", "0773764793");
            res = res.Replace("[Địa chỉ email hỗ trợ]", "bhdv.hotel25@gmail.com");
            res = res.Replace("[Địa chỉ khách sạn]", "Số 1 Võ Văn Ngân, Phường Linh Chiểu, Quận Thủ Đức, Thành Phố Hồ Chí Minh");

            return res;
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

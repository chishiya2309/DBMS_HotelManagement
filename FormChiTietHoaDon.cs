using BLL.DAO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace QLKS
{
    public partial class FormChiTietHoaDon: Form
    {
        public FormChiTietHoaDon(int id)
        {
            InitializeComponent();
            this.btnClose.Visible = false;
            LoadFullBillDetail(id);
            this.Shown += (s, e) => {
                InHoaDon(this);
            };
            

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public DataTable SearchUsedService(int idBookRoom)
        {
            return UsedServiceInfoDAO.Instance.Search(idBookRoom);
        }

        public void LoadFullUsedService(DataTable dt)
        {
            BindingSource source = new BindingSource();
            source.DataSource = dt;
            dgvUsedService.DataSource = source;
            
        }

        public void LoadFullBillDetail(int id)
        {
            DataTable dt = BillDAO.Instance.PrintBill(id);

            lbIDBill.Text = dt.Rows[0]["MaHoaDon"].ToString();
            lbStaffName.Text = dt.Rows[0]["TenNhanVien"].ToString();
            lbDateofCreate.Text = dt.Rows[0]["NgayLapHoaDon"].ToString();
            lbCustomerName.Text = dt.Rows[0]["TenKhachHang"].ToString();
            lbPhone.Text = dt.Rows[0]["Sodienthoai"].ToString();
            lbEmail.Text = dt.Rows[0]["email"].ToString();
            lbChecin.Text = dt.Rows[0]["ThoiGianCheckinThucTe"].ToString();
            lbCheckout.Text = dt.Rows[0]["ThoiGianCheckoutThucTe"].ToString();
            lbRoomname.Text = dt.Rows[0]["TenPhong"].ToString();
            lbRoomType.Text = dt.Rows[0]["TenLoaiPhong"].ToString();
            lbPriceRoom.Text = dt.Rows[0]["TienPhong"].ToString() + " VND";
            lbDays.Text = dt.Rows[0]["SoDem"].ToString();
            lbCount.Text = dt.Rows[0]["Songuoi"].ToString();

            int idBookRoom = int.Parse(dt.Rows[0]["MaHoSoDatPhong"].ToString());
            LoadFullUsedService(SearchUsedService(idBookRoom));

            lbSurchange.Text = dt.Rows[0]["PhuThu"].ToString() + " VND";
            lbDiscount.Text = dt.Rows[0]["GiamGia"].ToString() + " %";
            double TongtienPhong = double.Parse(dt.Rows[0]["TienPhong"].ToString()) * double.Parse(dt.Rows[0]["SoDem"].ToString()) + double.Parse(dt.Rows[0]["PhuThu"].ToString()) - (double.Parse(dt.Rows[0]["PhuThu"].ToString()));
            lbTotalPriceRoom.Text = TongtienPhong.ToString() + " VND";
            double TongtienDichVu = 0;
            foreach (DataGridViewRow row in dgvUsedService.Rows)
            {
                TongtienDichVu += double.Parse(row.Cells["dgvThanhTien"].Value.ToString()) * double.Parse(row.Cells["dgvSoLuong"].Value.ToString());
            }
            lbServicePrice.Text = TongtienDichVu.ToString() + " VND";
            lbTotal.Text = dt.Rows[0]["ThanhTien"].ToString() + " VND";


            
            

            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            
        }


        public void InHoaDon(Form form)
        {
            try
            {
                // 1. Đảm bảo form hiển thị đầy đủ
                form.Show();
                form.Refresh();
                Application.DoEvents();

                // 2. Tạo bitmap với kích thước form
                Bitmap formImage = new Bitmap(form.Width, form.Height);
                formImage.SetResolution(600, 600);

                // 3. Chụp toàn bộ form
                form.DrawToBitmap(formImage, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));

                // 4. Thiết lập in với lề = 0 (khớp hoàn toàn với trang in)
                PrintDocument printDoc = new PrintDocument();
                printDoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                printDoc.PrintPage += (sender, e) =>
                {
                    // Tính tỷ lệ scale để khớp hoàn toàn với vùng in
                    float widthScale = e.PageBounds.Width / (float)formImage.Width;
                    float heightScale = e.PageBounds.Height / (float)formImage.Height;
                    float scale = Math.Min(widthScale, heightScale);

                    // Tính kích thước mới
                    int newWidth = (int)(formImage.Width * scale);
                    int newHeight = (int)(formImage.Height * scale + 150);

                    // Căn giữa trang in
                    int x = (e.PageBounds.Width - newWidth) / 2;
                    int y = (e.PageBounds.Height - newHeight) / 8;

                    // Vẽ ảnh khớp hoàn toàn với trang in
                    e.Graphics.DrawImage(formImage, x, y, newWidth, newHeight);
                };

                // 5. Hiển thị xem trước
                PrintPreviewDialog previewDialog = new PrintPreviewDialog()
                {
                    Document = printDoc,
                    WindowState = FormWindowState.Maximized,
                    PrintPreviewControl = { Zoom = 1.0 }
                };

                previewDialog.ShowDialog();
                formImage.Dispose();
                btnClose.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in: {ex.Message}", "Lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

    }
}

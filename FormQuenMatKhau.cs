using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Linq.Expressions;
using BLL.DAO;

namespace QLKS
{
    public partial class FormQuenMatKhau: Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Close();
        }

        private string maXacNhanDuocTao = "";
        private string gmailNguoiDung = "";
        private DateTime? hanXacNhan;

        private void FormQuenMatKhau_Load(object sender, EventArgs e)
        {
            txtConfirm.Enabled = false;
            btnConfirm.Enabled = false;
            lbCountdown.Visible = false;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (hanXacNhan == null || DateTime.Now >= hanXacNhan)
            {
                countdownTimer.Stop();
                lbCountdown.Text = "Mã xác nhận đã hết hạn!";
                txtConfirm.Enabled = false;
                btnConfirm.Enabled = false;
                return;
            }

            TimeSpan timeRemaining = hanXacNhan.Value - DateTime.Now;
            lbCountdown.Text = $"Mã xác nhận còn hiệu lực trong: {timeRemaining.Minutes:D2}:{timeRemaining.Seconds:D2}";
        }

        private async void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đầu vào
                if (string.IsNullOrWhiteSpace(txtCCCD.Text))
                {
                    MessageBox.Show("Vui lòng nhập số CCCD.");
                    return;
                }
                if (!Regex.IsMatch(txtCCCD.Text, @"^\d{12}$"))
                {
                    MessageBox.Show("CCCD phải là 12 chữ số.");
                    return;
                }

                // Truy vấn cơ sở dữ liệu
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Confirm", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CMND", txtCCCD.Text);

                        SqlParameter gmailParam = new SqlParameter("@Email", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter maParam = new SqlParameter("@MaXThuc", SqlDbType.VarChar, 6)
                        {
                            Direction = ParameterDirection.Output
                        };
                        SqlParameter hanParam = new SqlParameter("@HanXTh", SqlDbType.DateTime)
                        {
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(gmailParam);
                        cmd.Parameters.Add(maParam);
                        cmd.Parameters.Add(hanParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        gmailNguoiDung = gmailParam.Value?.ToString();
                        maXacNhanDuocTao = maParam.Value?.ToString();
                        hanXacNhan = hanParam.Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(hanParam.Value);
                    }
                }

                if (string.IsNullOrEmpty(gmailNguoiDung))
                {
                    MessageBox.Show("Không tìm thấy email cho CCCD này.");
                    return;
                }

                // Gửi mail
                var fromAddress = new MailAddress("duongminhduy1592005@gmail.com", "BHDV Hotel");
                var toAddress = new MailAddress(gmailNguoiDung, "User");
                const string subject = "Mã xác nhận lấy lại mật khẩu";
                string body = $"Mã xác nhận của bạn là: {maXacNhanDuocTao}";

                const string fromPassword = "zgsj fcsj dshe afmc"; // Lưu ý: Nên lưu trong app.config

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000,
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    await smtp.SendMailAsync(message);
                    MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn!");

                    // Kích hoạt các control và bắt đầu đếm ngược
                    txtConfirm.Enabled = true;
                    btnConfirm.Enabled = true;
                    lbCountdown.Visible = true;
                    countdownTimer.Start();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận.");
                return;
            }
            if (hanXacNhan == null || DateTime.Now > hanXacNhan)
            {
                MessageBox.Show("Mã xác nhận đã hết hạn. Vui lòng yêu cầu mã mới.");
                countdownTimer.Stop();
                lbCountdown.Text = "Mã xác nhận đã hết hạn!";
                txtConfirm.Enabled = false;
                btnConfirm.Enabled = false;
                return;
            }
            if (txtConfirm.Text == maXacNhanDuocTao)
            {
                DataTable dt = StaffDAO.Instance.SearchStaffByCCCD(txtCCCD.Text);

                AccountDAO.Instance.UpdatePassword(dt.Rows[0]["TenDangNhap"].ToString(), "123456");
                MessageBox.Show("Mã xác nhận đúng. Mật khẩu mặc định của bạn là 123456");
                countdownTimer.Stop();
                lbCountdown.Visible = false;
                txtConfirm.Enabled = false;
                btnConfirm.Enabled = false;
                
            }
            else
            {
                MessageBox.Show("Sai mã xác nhận. Vui lòng thử lại.");
            }
        }
    }
}

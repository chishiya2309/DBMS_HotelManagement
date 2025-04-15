namespace QLKS
{
    partial class FormQuenMatKhau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lbCountdown = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEmail = new Guna.UI2.WinForms.Guna2Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCCCD = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GroupBox2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.guna2GroupBox2.BorderRadius = 10;
            this.guna2GroupBox2.Controls.Add(this.lbCountdown);
            this.guna2GroupBox2.Controls.Add(this.label2);
            this.guna2GroupBox2.Controls.Add(this.btnConfirm);
            this.guna2GroupBox2.Controls.Add(this.label1);
            this.guna2GroupBox2.Controls.Add(this.txtConfirm);
            this.guna2GroupBox2.Controls.Add(this.btnEmail);
            this.guna2GroupBox2.Controls.Add(this.label6);
            this.guna2GroupBox2.Controls.Add(this.txtCCCD);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(25, 100);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(350, 350);
            this.guna2GroupBox2.TabIndex = 31;
            this.guna2GroupBox2.Text = "Khôi phục mật khẩu";
            this.guna2GroupBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCountdown
            // 
            this.lbCountdown.AutoSize = true;
            this.lbCountdown.BackColor = System.Drawing.Color.Transparent;
            this.lbCountdown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.lbCountdown.Location = new System.Drawing.Point(20, 225);
            this.lbCountdown.Name = "lbCountdown";
            this.lbCountdown.Size = new System.Drawing.Size(186, 15);
            this.lbCountdown.TabIndex = 45;
            this.lbCountdown.Text = "Mã xác nhận còn hiệu lực trong: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(20, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 45);
            this.label2.TabIndex = 44;
            this.label2.Text = "Lưu ý:\r\n* Nếu không thấy email trong hộp thư đến,\r\nvui lòng kiểm tra trong thư rá" +
    "c.";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderRadius = 5;
            this.btnConfirm.CheckedState.Parent = this.btnConfirm;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.CustomImages.Parent = this.btnConfirm;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.Parent = this.btnConfirm;
            this.btnConfirm.Location = new System.Drawing.Point(230, 170);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.ShadowDecoration.Parent = this.btnConfirm;
            this.btnConfirm.Size = new System.Drawing.Size(100, 40);
            this.btnConfirm.TabIndex = 43;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 19);
            this.label1.TabIndex = 42;
            this.label1.Text = "Nhập mã xác nhận đã gửi qua email:";
            // 
            // txtConfirm
            // 
            this.txtConfirm.BackColor = System.Drawing.Color.Transparent;
            this.txtConfirm.BorderRadius = 5;
            this.txtConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirm.DefaultText = "";
            this.txtConfirm.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirm.DisabledState.Parent = this.txtConfirm;
            this.txtConfirm.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtConfirm.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtConfirm.FocusedState.Parent = this.txtConfirm;
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtConfirm.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtConfirm.HoverState.Parent = this.txtConfirm;
            this.txtConfirm.Location = new System.Drawing.Point(20, 170);
            this.txtConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '\0';
            this.txtConfirm.PlaceholderText = "Nhập mã xác nhận";
            this.txtConfirm.SelectedText = "";
            this.txtConfirm.ShadowDecoration.Parent = this.txtConfirm;
            this.txtConfirm.Size = new System.Drawing.Size(200, 40);
            this.txtConfirm.TabIndex = 41;
            // 
            // btnEmail
            // 
            this.btnEmail.BorderRadius = 5;
            this.btnEmail.CheckedState.Parent = this.btnEmail;
            this.btnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmail.CustomImages.Parent = this.btnEmail;
            this.btnEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.btnEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.ForeColor = System.Drawing.Color.White;
            this.btnEmail.HoverState.Parent = this.btnEmail;
            this.btnEmail.Location = new System.Drawing.Point(230, 85);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.ShadowDecoration.Parent = this.btnEmail;
            this.btnEmail.Size = new System.Drawing.Size(100, 40);
            this.btnEmail.TabIndex = 32;
            this.btnEmail.Text = "Gửi email";
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(20, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "Vui lòng nhập CCCD:";
            // 
            // txtCCCD
            // 
            this.txtCCCD.BackColor = System.Drawing.Color.Transparent;
            this.txtCCCD.BorderRadius = 5;
            this.txtCCCD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCCCD.DefaultText = "";
            this.txtCCCD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCCCD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCCCD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCCCD.DisabledState.Parent = this.txtCCCD;
            this.txtCCCD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCCCD.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtCCCD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtCCCD.FocusedState.Parent = this.txtCCCD;
            this.txtCCCD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCCCD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCCCD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.txtCCCD.HoverState.Parent = this.txtCCCD;
            this.txtCCCD.Location = new System.Drawing.Point(20, 85);
            this.txtCCCD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.PasswordChar = '\0';
            this.txtCCCD.PlaceholderText = "Nhập số CCCD";
            this.txtCCCD.SelectedText = "";
            this.txtCCCD.ShadowDecoration.Parent = this.txtCCCD;
            this.txtCCCD.Size = new System.Drawing.Size(200, 40);
            this.txtCCCD.TabIndex = 39;
            // 
            // btnClose
            // 
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.ImageSize = new System.Drawing.Size(12, 12);
            this.btnClose.Location = new System.Drawing.Point(360, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 56;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // countdownTimer
            // 
            this.countdownTimer.Interval = 1000;
            this.countdownTimer.Tick += new System.EventHandler(this.CountdownTimer_Tick);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(400, 80);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Location = new System.Drawing.Point(20, 15);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(50, 50);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FormQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(400, 470);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khôi phục mật khẩu";
            this.Load += new System.EventHandler(this.FormQuenMatKhau_Load);
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtCCCD;
        private Guna.UI2.WinForms.Guna2Button btnEmail;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirm;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Label lbCountdown;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
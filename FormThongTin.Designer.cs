namespace QLKS
{
    partial class FormThongTin
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
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongTin));
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2MouseStateHandler1 = new Guna.UI2.WinForms.Guna2MouseStateHandler(this.components);
            this.guna2Transition1 = new Guna.UI2.WinForms.Guna2Transition();
            this.panelProfile = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picturebox = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblPictureHint = new System.Windows.Forms.Label();
            this.panelAccount = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAccountInfo = new System.Windows.Forms.Label();
            this.lblUsernameField = new System.Windows.Forms.Label();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelSecurity = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSecurity = new System.Windows.Forms.Label();
            this.lblCurrentPass = new System.Windows.Forms.Label();
            this.txtPasspre = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtPassnew = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.txtPasscon = new Guna.UI2.WinForms.Guna2TextBox();
            this.SavePassbtn = new Guna.UI2.WinForms.Guna2Button();
            this.panelPersonal = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPersonalInfo = new System.Windows.Forms.Label();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.txtIDNum = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cbSex = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.dobDP = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtStartDay = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelButtons = new Guna.UI2.WinForms.Guna2Panel();
            this.SaveInfobtn = new Guna.UI2.WinForms.Guna2Button();
            this.Closebtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.panelProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.panelAccount.SuspendLayout();
            this.panelSecurity.SuspendLayout();
            this.panelPersonal.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // guna2Transition1
            // 
            this.guna2Transition1.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.guna2Transition1.DefaultAnimation = animation1;
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelProfile.BorderRadius = 15;
            this.panelProfile.Controls.Add(this.lblUserName);
            this.panelProfile.Controls.Add(this.picturebox);
            this.panelProfile.Controls.Add(this.lblPictureHint);
            this.guna2Transition1.SetDecoration(this.panelProfile, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelProfile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelProfile.Location = new System.Drawing.Point(20, 20);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.ShadowDecoration.Parent = this.panelProfile;
            this.panelProfile.Size = new System.Drawing.Size(220, 280);
            this.panelProfile.TabIndex = 40;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblUserName, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(40, 210);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(140, 25);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Văn A";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picturebox
            // 
            this.picturebox.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.picturebox, Guna.UI2.AnimatorNS.DecorationType.None);
            this.picturebox.Image = global::QLKS.Properties.Resources.clipart4371249;
            this.picturebox.Location = new System.Drawing.Point(35, 20);
            this.picturebox.Name = "picturebox";
            this.picturebox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picturebox.ShadowDecoration.Parent = this.picturebox;
            this.picturebox.Size = new System.Drawing.Size(150, 150);
            this.picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturebox.TabIndex = 39;
            this.picturebox.TabStop = false;
            this.picturebox.UseTransparentBackground = true;
            this.picturebox.DoubleClick += new System.EventHandler(this.picturebox_DoubleClick);
            // 
            // lblPictureHint
            // 
            this.lblPictureHint.AutoSize = true;
            this.guna2Transition1.SetDecoration(this.lblPictureHint, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblPictureHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPictureHint.ForeColor = System.Drawing.Color.Gold;
            this.lblPictureHint.Location = new System.Drawing.Point(40, 245);
            this.lblPictureHint.Name = "lblPictureHint";
            this.lblPictureHint.Size = new System.Drawing.Size(148, 13);
            this.lblPictureHint.TabIndex = 2;
            this.lblPictureHint.Text = "Nhấp đúp để đổi ảnh đại diện";
            this.lblPictureHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAccount
            // 
            this.panelAccount.BackColor = System.Drawing.Color.Transparent;
            this.panelAccount.BorderRadius = 15;
            this.panelAccount.Controls.Add(this.lblAccountInfo);
            this.panelAccount.Controls.Add(this.lblUsernameField);
            this.panelAccount.Controls.Add(this.txtUser);
            this.panelAccount.Controls.Add(this.lblDisplayName);
            this.panelAccount.Controls.Add(this.txtName);
            this.panelAccount.Controls.Add(this.lblEmail);
            this.panelAccount.Controls.Add(this.txtEmail);
            this.guna2Transition1.SetDecoration(this.panelAccount, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelAccount.FillColor = System.Drawing.Color.White;
            this.panelAccount.Location = new System.Drawing.Point(250, 20);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.ShadowDecoration.BorderRadius = 15;
            this.panelAccount.ShadowDecoration.Depth = 10;
            this.panelAccount.ShadowDecoration.Enabled = true;
            this.panelAccount.ShadowDecoration.Parent = this.panelAccount;
            this.panelAccount.Size = new System.Drawing.Size(280, 280);
            this.panelAccount.TabIndex = 41;
            // 
            // lblAccountInfo
            // 
            this.lblAccountInfo.AutoSize = true;
            this.lblAccountInfo.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblAccountInfo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblAccountInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAccountInfo.Location = new System.Drawing.Point(15, 15);
            this.lblAccountInfo.Name = "lblAccountInfo";
            this.lblAccountInfo.Size = new System.Drawing.Size(160, 21);
            this.lblAccountInfo.TabIndex = 2;
            this.lblAccountInfo.Text = "Thông tin tài khoản";
            // 
            // lblUsernameField
            // 
            this.lblUsernameField.AutoSize = true;
            this.lblUsernameField.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblUsernameField, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblUsernameField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsernameField.Location = new System.Drawing.Point(15, 60);
            this.lblUsernameField.Name = "lblUsernameField";
            this.lblUsernameField.Size = new System.Drawing.Size(98, 17);
            this.lblUsernameField.TabIndex = 6;
            this.lblUsernameField.Text = "Tên đăng nhập:";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.BorderRadius = 5;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtUser, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtUser.DefaultText = "";
            this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.DisabledState.Parent = this.txtUser;
            this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.FocusedState.Parent = this.txtUser;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUser.HoverState.Parent = this.txtUser;
            this.txtUser.Location = new System.Drawing.Point(15, 85);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUser.PlaceholderText = "Tên đăng nhập";
            this.txtUser.SelectedText = "";
            this.txtUser.ShadowDecoration.Parent = this.txtUser;
            this.txtUser.Size = new System.Drawing.Size(250, 40);
            this.txtUser.TabIndex = 7;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblDisplayName, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDisplayName.Location = new System.Drawing.Point(15, 135);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(77, 17);
            this.lblDisplayName.TabIndex = 8;
            this.lblDisplayName.Text = "Tên hiển thị:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtName.BorderRadius = 5;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtName, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.Parent = this.txtName;
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtName.FocusedState.Parent = this.txtName;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtName.HoverState.Parent = this.txtName;
            this.txtName.Location = new System.Drawing.Point(15, 160);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtName.PlaceholderText = "Tên hiển thị";
            this.txtName.SelectedText = "";
            this.txtName.ShadowDecoration.Parent = this.txtName;
            this.txtName.Size = new System.Drawing.Size(250, 40);
            this.txtName.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblEmail, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmail.Location = new System.Drawing.Point(15, 210);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 37;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtEmail, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.Parent = this.txtEmail;
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmail.FocusedState.Parent = this.txtEmail;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtEmail.HoverState.Parent = this.txtEmail;
            this.txtEmail.Location = new System.Drawing.Point(15, 235);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.ShadowDecoration.Parent = this.txtEmail;
            this.txtEmail.Size = new System.Drawing.Size(250, 40);
            this.txtEmail.TabIndex = 38;
            // 
            // panelSecurity
            // 
            this.panelSecurity.BackColor = System.Drawing.Color.Transparent;
            this.panelSecurity.BorderRadius = 15;
            this.panelSecurity.Controls.Add(this.lblSecurity);
            this.panelSecurity.Controls.Add(this.lblCurrentPass);
            this.panelSecurity.Controls.Add(this.txtPasspre);
            this.panelSecurity.Controls.Add(this.lblNewPass);
            this.panelSecurity.Controls.Add(this.txtPassnew);
            this.panelSecurity.Controls.Add(this.lblConfirmPass);
            this.panelSecurity.Controls.Add(this.txtPasscon);
            this.panelSecurity.Controls.Add(this.SavePassbtn);
            this.guna2Transition1.SetDecoration(this.panelSecurity, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelSecurity.FillColor = System.Drawing.Color.White;
            this.panelSecurity.Location = new System.Drawing.Point(540, 20);
            this.panelSecurity.Name = "panelSecurity";
            this.panelSecurity.ShadowDecoration.BorderRadius = 15;
            this.panelSecurity.ShadowDecoration.Depth = 10;
            this.panelSecurity.ShadowDecoration.Enabled = true;
            this.panelSecurity.ShadowDecoration.Parent = this.panelSecurity;
            this.panelSecurity.Size = new System.Drawing.Size(280, 280);
            this.panelSecurity.TabIndex = 42;
            // 
            // lblSecurity
            // 
            this.lblSecurity.AutoSize = true;
            this.lblSecurity.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblSecurity, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblSecurity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSecurity.Location = new System.Drawing.Point(15, 15);
            this.lblSecurity.Name = "lblSecurity";
            this.lblSecurity.Size = new System.Drawing.Size(73, 21);
            this.lblSecurity.TabIndex = 5;
            this.lblSecurity.Text = "Bảo mật";
            // 
            // lblCurrentPass
            // 
            this.lblCurrentPass.AutoSize = true;
            this.lblCurrentPass.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblCurrentPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblCurrentPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurrentPass.Location = new System.Drawing.Point(15, 60);
            this.lblCurrentPass.Name = "lblCurrentPass";
            this.lblCurrentPass.Size = new System.Drawing.Size(111, 17);
            this.lblCurrentPass.TabIndex = 12;
            this.lblCurrentPass.Text = "Mật khẩu hiện tại:";
            // 
            // txtPasspre
            // 
            this.txtPasspre.BackColor = System.Drawing.Color.Transparent;
            this.txtPasspre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasspre.BorderRadius = 5;
            this.txtPasspre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtPasspre, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtPasspre.DefaultText = "";
            this.txtPasspre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPasspre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPasspre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasspre.DisabledState.Parent = this.txtPasspre;
            this.txtPasspre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasspre.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPasspre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasspre.FocusedState.Parent = this.txtPasspre;
            this.txtPasspre.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPasspre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasspre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasspre.HoverState.Parent = this.txtPasspre;
            this.txtPasspre.Location = new System.Drawing.Point(15, 85);
            this.txtPasspre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPasspre.Name = "txtPasspre";
            this.txtPasspre.PasswordChar = '●';
            this.txtPasspre.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPasspre.PlaceholderText = "Mật khẩu hiện tại";
            this.txtPasspre.SelectedText = "";
            this.txtPasspre.ShadowDecoration.Parent = this.txtPasspre;
            this.txtPasspre.Size = new System.Drawing.Size(250, 40);
            this.txtPasspre.TabIndex = 15;
            this.txtPasspre.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblNewPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewPass.Location = new System.Drawing.Point(15, 135);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(91, 17);
            this.lblNewPass.TabIndex = 13;
            this.lblNewPass.Text = "Mật khẩu mới:";
            // 
            // txtPassnew
            // 
            this.txtPassnew.BackColor = System.Drawing.Color.Transparent;
            this.txtPassnew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassnew.BorderRadius = 5;
            this.txtPassnew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtPassnew, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtPassnew.DefaultText = "";
            this.txtPassnew.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassnew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassnew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassnew.DisabledState.Parent = this.txtPassnew;
            this.txtPassnew.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassnew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPassnew.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassnew.FocusedState.Parent = this.txtPassnew;
            this.txtPassnew.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPassnew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassnew.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassnew.HoverState.Parent = this.txtPassnew;
            this.txtPassnew.Location = new System.Drawing.Point(15, 160);
            this.txtPassnew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassnew.Name = "txtPassnew";
            this.txtPassnew.PasswordChar = '●';
            this.txtPassnew.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPassnew.PlaceholderText = "Mật khẩu mới";
            this.txtPassnew.SelectedText = "";
            this.txtPassnew.ShadowDecoration.Parent = this.txtPassnew;
            this.txtPassnew.Size = new System.Drawing.Size(250, 40);
            this.txtPassnew.TabIndex = 16;
            this.txtPassnew.UseSystemPasswordChar = true;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblConfirmPass, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblConfirmPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblConfirmPass.Location = new System.Drawing.Point(15, 210);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(147, 17);
            this.lblConfirmPass.TabIndex = 14;
            this.lblConfirmPass.Text = "Xác nhận mật khẩu mới:";
            // 
            // txtPasscon
            // 
            this.txtPasscon.BackColor = System.Drawing.Color.Transparent;
            this.txtPasscon.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasscon.BorderRadius = 5;
            this.txtPasscon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtPasscon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtPasscon.DefaultText = "";
            this.txtPasscon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPasscon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPasscon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasscon.DisabledState.Parent = this.txtPasscon;
            this.txtPasscon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasscon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPasscon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasscon.FocusedState.Parent = this.txtPasscon;
            this.txtPasscon.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPasscon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasscon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPasscon.HoverState.Parent = this.txtPasscon;
            this.txtPasscon.Location = new System.Drawing.Point(15, 235);
            this.txtPasscon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPasscon.Name = "txtPasscon";
            this.txtPasscon.PasswordChar = '●';
            this.txtPasscon.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPasscon.PlaceholderText = "Xác nhận mật khẩu mới";
            this.txtPasscon.SelectedText = "";
            this.txtPasscon.ShadowDecoration.Parent = this.txtPasscon;
            this.txtPasscon.Size = new System.Drawing.Size(250, 40);
            this.txtPasscon.TabIndex = 17;
            this.txtPasscon.UseSystemPasswordChar = true;
            // 
            // SavePassbtn
            // 
            this.SavePassbtn.BackColor = System.Drawing.Color.Transparent;
            this.SavePassbtn.BorderRadius = 20;
            this.SavePassbtn.CheckedState.Parent = this.SavePassbtn;
            this.SavePassbtn.CustomImages.Parent = this.SavePassbtn;
            this.guna2Transition1.SetDecoration(this.SavePassbtn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.SavePassbtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SavePassbtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SavePassbtn.ForeColor = System.Drawing.Color.White;
            this.SavePassbtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SavePassbtn.HoverState.Parent = this.SavePassbtn;
            this.SavePassbtn.Location = new System.Drawing.Point(150, 235);
            this.SavePassbtn.Name = "SavePassbtn";
            this.SavePassbtn.ShadowDecoration.Parent = this.SavePassbtn;
            this.SavePassbtn.Size = new System.Drawing.Size(115, 40);
            this.SavePassbtn.TabIndex = 36;
            this.SavePassbtn.Text = "Thay đổi";
            this.SavePassbtn.Click += new System.EventHandler(this.SavePassbtn_Click);
            // 
            // panelPersonal
            // 
            this.panelPersonal.BackColor = System.Drawing.Color.Transparent;
            this.panelPersonal.BorderRadius = 15;
            this.panelPersonal.Controls.Add(this.lblPersonalInfo);
            this.panelPersonal.Controls.Add(this.lblIDNumber);
            this.panelPersonal.Controls.Add(this.txtIDNum);
            this.panelPersonal.Controls.Add(this.lblAddress);
            this.panelPersonal.Controls.Add(this.txtAddress);
            this.panelPersonal.Controls.Add(this.lblPhone);
            this.panelPersonal.Controls.Add(this.txtPhone);
            this.panelPersonal.Controls.Add(this.lblGender);
            this.panelPersonal.Controls.Add(this.cbSex);
            this.panelPersonal.Controls.Add(this.lblDOB);
            this.panelPersonal.Controls.Add(this.dobDP);
            this.panelPersonal.Controls.Add(this.lblStartDate);
            this.panelPersonal.Controls.Add(this.txtStartDay);
            this.guna2Transition1.SetDecoration(this.panelPersonal, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelPersonal.FillColor = System.Drawing.Color.White;
            this.panelPersonal.Location = new System.Drawing.Point(20, 310);
            this.panelPersonal.Name = "panelPersonal";
            this.panelPersonal.ShadowDecoration.BorderRadius = 15;
            this.panelPersonal.ShadowDecoration.Depth = 10;
            this.panelPersonal.ShadowDecoration.Enabled = true;
            this.panelPersonal.ShadowDecoration.Parent = this.panelPersonal;
            this.panelPersonal.Size = new System.Drawing.Size(680, 220);
            this.panelPersonal.TabIndex = 43;
            // 
            // lblPersonalInfo
            // 
            this.lblPersonalInfo.AutoSize = true;
            this.lblPersonalInfo.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblPersonalInfo, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPersonalInfo.Location = new System.Drawing.Point(15, 15);
            this.lblPersonalInfo.Name = "lblPersonalInfo";
            this.lblPersonalInfo.Size = new System.Drawing.Size(148, 21);
            this.lblPersonalInfo.TabIndex = 3;
            this.lblPersonalInfo.Text = "Thông tin cá nhân";
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.AutoSize = true;
            this.lblIDNumber.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblIDNumber, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblIDNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIDNumber.Location = new System.Drawing.Point(15, 50);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(88, 17);
            this.lblIDNumber.TabIndex = 20;
            this.lblIDNumber.Text = "CCCD/CMND:";
            // 
            // txtIDNum
            // 
            this.txtIDNum.BackColor = System.Drawing.Color.Transparent;
            this.txtIDNum.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtIDNum.BorderRadius = 5;
            this.txtIDNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtIDNum, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtIDNum.DefaultText = "";
            this.txtIDNum.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIDNum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIDNum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDNum.DisabledState.Parent = this.txtIDNum;
            this.txtIDNum.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDNum.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtIDNum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtIDNum.FocusedState.Parent = this.txtIDNum;
            this.txtIDNum.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtIDNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtIDNum.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtIDNum.HoverState.Parent = this.txtIDNum;
            this.txtIDNum.Location = new System.Drawing.Point(15, 75);
            this.txtIDNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIDNum.Name = "txtIDNum";
            this.txtIDNum.PasswordChar = '\0';
            this.txtIDNum.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtIDNum.PlaceholderText = "Số CCCD/CMND";
            this.txtIDNum.SelectedText = "";
            this.txtIDNum.ShadowDecoration.Parent = this.txtIDNum;
            this.txtIDNum.Size = new System.Drawing.Size(200, 40);
            this.txtIDNum.TabIndex = 21;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblAddress, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddress.Location = new System.Drawing.Point(15, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(50, 17);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtAddress, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.Parent = this.txtAddress;
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress.FocusedState.Parent = this.txtAddress;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAddress.HoverState.Parent = this.txtAddress;
            this.txtAddress.Location = new System.Drawing.Point(15, 155);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtAddress.PlaceholderText = "Địa chỉ";
            this.txtAddress.SelectedText = "";
            this.txtAddress.ShadowDecoration.Parent = this.txtAddress;
            this.txtAddress.Size = new System.Drawing.Size(200, 40);
            this.txtAddress.TabIndex = 23;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblPhone, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPhone.Location = new System.Drawing.Point(240, 50);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(88, 17);
            this.lblPhone.TabIndex = 25;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtPhone, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.Parent = this.txtPhone;
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.FocusedState.Parent = this.txtPhone;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPhone.HoverState.Parent = this.txtPhone;
            this.txtPhone.Location = new System.Drawing.Point(240, 75);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPhone.PlaceholderText = "Số điện thoại";
            this.txtPhone.SelectedText = "";
            this.txtPhone.ShadowDecoration.Parent = this.txtPhone;
            this.txtPhone.Size = new System.Drawing.Size(200, 40);
            this.txtPhone.TabIndex = 27;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblGender, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGender.Location = new System.Drawing.Point(465, 50);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(59, 17);
            this.lblGender.TabIndex = 29;
            this.lblGender.Text = "Giới tính:";
            // 
            // cbSex
            // 
            this.cbSex.BackColor = System.Drawing.Color.Transparent;
            this.cbSex.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSex.BorderRadius = 5;
            this.guna2Transition1.SetDecoration(this.cbSex, Guna.UI2.AnimatorNS.DecorationType.None);
            this.cbSex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cbSex.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSex.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSex.FocusedState.Parent = this.cbSex;
            this.cbSex.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cbSex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSex.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbSex.HoverState.Parent = this.cbSex;
            this.cbSex.ItemHeight = 30;
            this.cbSex.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbSex.ItemsAppearance.Parent = this.cbSex;
            this.cbSex.Location = new System.Drawing.Point(465, 75);
            this.cbSex.Name = "cbSex";
            this.cbSex.ShadowDecoration.Parent = this.cbSex;
            this.cbSex.Size = new System.Drawing.Size(200, 36);
            this.cbSex.TabIndex = 33;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblDOB, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblDOB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDOB.Location = new System.Drawing.Point(240, 130);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(69, 17);
            this.lblDOB.TabIndex = 26;
            this.lblDOB.Text = "Ngày sinh:";
            // 
            // dobDP
            // 
            this.dobDP.BackColor = System.Drawing.Color.Transparent;
            this.dobDP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dobDP.BorderRadius = 5;
            this.dobDP.BorderThickness = 1;
            this.dobDP.CheckedState.Parent = this.dobDP;
            this.guna2Transition1.SetDecoration(this.dobDP, Guna.UI2.AnimatorNS.DecorationType.None);
            this.dobDP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dobDP.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dobDP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dobDP.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dobDP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dobDP.HoverState.Parent = this.dobDP;
            this.dobDP.Location = new System.Drawing.Point(240, 155);
            this.dobDP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dobDP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dobDP.Name = "dobDP";
            this.dobDP.ShadowDecoration.Parent = this.dobDP;
            this.dobDP.Size = new System.Drawing.Size(200, 40);
            this.dobDP.TabIndex = 34;
            this.dobDP.Value = new System.DateTime(2025, 3, 19, 22, 51, 46, 21);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.Transparent;
            this.guna2Transition1.SetDecoration(this.lblStartDate, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStartDate.Location = new System.Drawing.Point(465, 130);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(92, 17);
            this.lblStartDate.TabIndex = 31;
            this.lblStartDate.Text = "Ngày vào làm:";
            // 
            // txtStartDay
            // 
            this.txtStartDay.BackColor = System.Drawing.Color.Transparent;
            this.txtStartDay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStartDay.BorderRadius = 5;
            this.txtStartDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2Transition1.SetDecoration(this.txtStartDay, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtStartDay.DefaultText = "";
            this.txtStartDay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStartDay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStartDay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStartDay.DisabledState.Parent = this.txtStartDay;
            this.txtStartDay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStartDay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtStartDay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStartDay.FocusedState.Parent = this.txtStartDay;
            this.txtStartDay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtStartDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStartDay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStartDay.HoverState.Parent = this.txtStartDay;
            this.txtStartDay.Location = new System.Drawing.Point(465, 155);
            this.txtStartDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStartDay.Name = "txtStartDay";
            this.txtStartDay.PasswordChar = '\0';
            this.txtStartDay.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtStartDay.PlaceholderText = "Ngày vào làm";
            this.txtStartDay.SelectedText = "";
            this.txtStartDay.ShadowDecoration.Parent = this.txtStartDay;
            this.txtStartDay.Size = new System.Drawing.Size(200, 40);
            this.txtStartDay.TabIndex = 35;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Transparent;
            this.panelButtons.Controls.Add(this.SaveInfobtn);
            this.panelButtons.Controls.Add(this.Closebtn);
            this.guna2Transition1.SetDecoration(this.panelButtons, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panelButtons.Location = new System.Drawing.Point(710, 310);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.ShadowDecoration.Parent = this.panelButtons;
            this.panelButtons.Size = new System.Drawing.Size(110, 220);
            this.panelButtons.TabIndex = 44;
            // 
            // SaveInfobtn
            // 
            this.SaveInfobtn.BackColor = System.Drawing.Color.Transparent;
            this.SaveInfobtn.BorderRadius = 20;
            this.SaveInfobtn.CheckedState.Parent = this.SaveInfobtn;
            this.SaveInfobtn.CustomImages.Parent = this.SaveInfobtn;
            this.guna2Transition1.SetDecoration(this.SaveInfobtn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.SaveInfobtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SaveInfobtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveInfobtn.ForeColor = System.Drawing.Color.White;
            this.SaveInfobtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SaveInfobtn.HoverState.Parent = this.SaveInfobtn;
            this.SaveInfobtn.Location = new System.Drawing.Point(5, 75);
            this.SaveInfobtn.Name = "SaveInfobtn";
            this.SaveInfobtn.ShadowDecoration.Parent = this.SaveInfobtn;
            this.SaveInfobtn.Size = new System.Drawing.Size(100, 40);
            this.SaveInfobtn.TabIndex = 24;
            this.SaveInfobtn.Text = "Lưu thông tin";
            this.SaveInfobtn.Click += new System.EventHandler(this.SaveInfobtn_Click);
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.Transparent;
            this.Closebtn.BorderRadius = 20;
            this.Closebtn.CheckedState.Parent = this.Closebtn;
            this.Closebtn.CustomImages.Parent = this.Closebtn;
            this.guna2Transition1.SetDecoration(this.Closebtn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Closebtn.FillColor = System.Drawing.Color.Gray;
            this.Closebtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Closebtn.ForeColor = System.Drawing.Color.White;
            this.Closebtn.HoverState.FillColor = System.Drawing.Color.Silver;
            this.Closebtn.HoverState.Parent = this.Closebtn;
            this.Closebtn.Location = new System.Drawing.Point(5, 130);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.ShadowDecoration.Parent = this.Closebtn;
            this.Closebtn.Size = new System.Drawing.Size(100, 40);
            this.Closebtn.TabIndex = 19;
            this.Closebtn.Text = "Đóng";
            this.Closebtn.Click += new System.EventHandler(this.guna2CircleButton3_Click);
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // FormThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(840, 550);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelPersonal);
            this.Controls.Add(this.panelSecurity);
            this.Controls.Add(this.panelAccount);
            this.Controls.Add(this.panelProfile);
            this.guna2Transition1.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormThongTin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.Load += new System.EventHandler(this.FormThongTin_Load);
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.panelAccount.ResumeLayout(false);
            this.panelAccount.PerformLayout();
            this.panelSecurity.ResumeLayout(false);
            this.panelSecurity.PerformLayout();
            this.panelPersonal.ResumeLayout(false);
            this.panelPersonal.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2MouseStateHandler guna2MouseStateHandler1;
        private Guna.UI2.WinForms.Guna2Transition guna2Transition1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;

        private Guna.UI2.WinForms.Guna2Panel panelProfile;
        private System.Windows.Forms.Label lblUserName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picturebox;
        private System.Windows.Forms.Label lblPictureHint;

        private Guna.UI2.WinForms.Guna2Panel panelAccount;
        private System.Windows.Forms.Label lblAccountInfo;
        private System.Windows.Forms.Label lblUsernameField;
        private Guna.UI2.WinForms.Guna2TextBox txtUser;
        private System.Windows.Forms.Label lblDisplayName;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;

        private Guna.UI2.WinForms.Guna2Panel panelSecurity;
        private System.Windows.Forms.Label lblSecurity;
        private System.Windows.Forms.Label lblCurrentPass;
        private Guna.UI2.WinForms.Guna2TextBox txtPasspre;
        private System.Windows.Forms.Label lblNewPass;
        private Guna.UI2.WinForms.Guna2TextBox txtPassnew;
        private System.Windows.Forms.Label lblConfirmPass;
        private Guna.UI2.WinForms.Guna2TextBox txtPasscon;
        private Guna.UI2.WinForms.Guna2Button SavePassbtn;

        private Guna.UI2.WinForms.Guna2Panel panelPersonal;
        private System.Windows.Forms.Label lblPersonalInfo;
        private System.Windows.Forms.Label lblIDNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtIDNum;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label lblGender;
        private Guna.UI2.WinForms.Guna2ComboBox cbSex;
        private System.Windows.Forms.Label lblDOB;
        private Guna.UI2.WinForms.Guna2DateTimePicker dobDP;
        private System.Windows.Forms.Label lblStartDate;
        private Guna.UI2.WinForms.Guna2TextBox txtStartDay;

        private Guna.UI2.WinForms.Guna2Panel panelButtons;
        private Guna.UI2.WinForms.Guna2Button SaveInfobtn;
        private Guna.UI2.WinForms.Guna2Button Closebtn;
    }
}
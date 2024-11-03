namespace GUI_Form
{
    partial class frmMain2
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
            this.metroSetTabControl1 = new MetroSet_UI.Controls.MetroSetTabControl();
            this.tabHoatDong = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.pnlButtonHD = new MetroSet_UI.Controls.MetroSetPanel();
            this.btnThanhToan = new MetroSet_UI.Controls.MetroSetButton();
            this.btnBaoCao = new MetroSet_UI.Controls.MetroSetButton();
            this.btnBanVe = new MetroSet_UI.Controls.MetroSetButton();
            this.pnlFormHD = new MetroSet_UI.Controls.MetroSetPanel();
            this.styleManager1 = new MetroSet_UI.Components.StyleManager();
            this.tabQuanLy = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.pnlButtonQL = new MetroSet_UI.Controls.MetroSetPanel();
            this.btnKhuyenMai = new MetroSet_UI.Controls.MetroSetButton();
            this.btnThucPham = new MetroSet_UI.Controls.MetroSetButton();
            this.btnHoaDon = new MetroSet_UI.Controls.MetroSetButton();
            this.btnLich = new MetroSet_UI.Controls.MetroSetButton();
            this.btnTaiKhoan = new MetroSet_UI.Controls.MetroSetButton();
            this.btnTroChoi = new MetroSet_UI.Controls.MetroSetButton();
            this.btnNVKH = new MetroSet_UI.Controls.MetroSetButton();
            this.btnVe = new MetroSet_UI.Controls.MetroSetButton();
            this.btnDanhMuc = new MetroSet_UI.Controls.MetroSetButton();
            this.pnlFormQL = new MetroSet_UI.Controls.MetroSetPanel();
            this.tabThongTin = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.tabChucNang = new MetroSet_UI.Child.MetroSetSetTabPage();
            this.btnSetting = new MetroSet_UI.Controls.MetroSetButton();
            this.btnThoat = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetTabControl1.SuspendLayout();
            this.tabHoatDong.SuspendLayout();
            this.pnlButtonHD.SuspendLayout();
            this.tabQuanLy.SuspendLayout();
            this.pnlButtonQL.SuspendLayout();
            this.tabChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroSetTabControl1
            // 
            this.metroSetTabControl1.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.metroSetTabControl1.AnimateTime = 200;
            this.metroSetTabControl1.BackgroundColor = System.Drawing.Color.White;
            this.metroSetTabControl1.Controls.Add(this.tabHoatDong);
            this.metroSetTabControl1.Controls.Add(this.tabQuanLy);
            this.metroSetTabControl1.Controls.Add(this.tabThongTin);
            this.metroSetTabControl1.Controls.Add(this.tabChucNang);
            this.metroSetTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroSetTabControl1.IsDerivedStyle = true;
            this.metroSetTabControl1.ItemSize = new System.Drawing.Size(100, 38);
            this.metroSetTabControl1.Location = new System.Drawing.Point(17, 89);
            this.metroSetTabControl1.Name = "metroSetTabControl1";
            this.metroSetTabControl1.SelectedIndex = 1;
            this.metroSetTabControl1.SelectedTextColor = System.Drawing.Color.White;
            this.metroSetTabControl1.Size = new System.Drawing.Size(1184, 723);
            this.metroSetTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroSetTabControl1.Speed = 100;
            this.metroSetTabControl1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetTabControl1.StyleManager = this.styleManager1;
            this.metroSetTabControl1.TabIndex = 1;
            this.metroSetTabControl1.ThemeAuthor = "Narwin";
            this.metroSetTabControl1.ThemeName = "MetroLight";
            this.metroSetTabControl1.UnselectedTextColor = System.Drawing.Color.Gray;
            this.metroSetTabControl1.UseAnimation = false;
            // 
            // tabHoatDong
            // 
            this.tabHoatDong.BaseColor = System.Drawing.Color.White;
            this.tabHoatDong.Controls.Add(this.pnlButtonHD);
            this.tabHoatDong.Controls.Add(this.pnlFormHD);
            this.tabHoatDong.Font = null;
            this.tabHoatDong.ImageIndex = 0;
            this.tabHoatDong.ImageKey = null;
            this.tabHoatDong.IsDerivedStyle = true;
            this.tabHoatDong.Location = new System.Drawing.Point(4, 42);
            this.tabHoatDong.Name = "tabHoatDong";
            this.tabHoatDong.Size = new System.Drawing.Size(1074, 581);
            this.tabHoatDong.Style = MetroSet_UI.Enums.Style.Light;
            this.tabHoatDong.StyleManager = this.styleManager1;
            this.tabHoatDong.TabIndex = 0;
            this.tabHoatDong.Text = "Hoạt động";
            this.tabHoatDong.ThemeAuthor = "Narwin";
            this.tabHoatDong.ThemeName = "MetroLite";
            this.tabHoatDong.ToolTipText = null;
            // 
            // pnlButtonHD
            // 
            this.pnlButtonHD.BackgroundColor = System.Drawing.Color.White;
            this.pnlButtonHD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlButtonHD.BorderThickness = 0;
            this.pnlButtonHD.Controls.Add(this.btnThanhToan);
            this.pnlButtonHD.Controls.Add(this.btnBaoCao);
            this.pnlButtonHD.Controls.Add(this.btnBanVe);
            this.pnlButtonHD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlButtonHD.IsDerivedStyle = true;
            this.pnlButtonHD.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonHD.Name = "pnlButtonHD";
            this.pnlButtonHD.Size = new System.Drawing.Size(200, 575);
            this.pnlButtonHD.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlButtonHD.StyleManager = null;
            this.pnlButtonHD.TabIndex = 1;
            this.pnlButtonHD.ThemeAuthor = "Narwin";
            this.pnlButtonHD.ThemeName = "MetroLite";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThanhToan.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThanhToan.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThanhToan.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThanhToan.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThanhToan.HoverTextColor = System.Drawing.Color.White;
            this.btnThanhToan.IsDerivedStyle = true;
            this.btnThanhToan.Location = new System.Drawing.Point(0, 62);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThanhToan.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThanhToan.NormalTextColor = System.Drawing.Color.White;
            this.btnThanhToan.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThanhToan.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThanhToan.PressTextColor = System.Drawing.Color.White;
            this.btnThanhToan.Size = new System.Drawing.Size(200, 57);
            this.btnThanhToan.Style = MetroSet_UI.Enums.Style.Light;
            this.btnThanhToan.StyleManager = null;
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.ThemeAuthor = "Narwin";
            this.btnThanhToan.ThemeName = "MetroLite";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBaoCao.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBaoCao.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBaoCao.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnBaoCao.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnBaoCao.HoverTextColor = System.Drawing.Color.White;
            this.btnBaoCao.IsDerivedStyle = true;
            this.btnBaoCao.Location = new System.Drawing.Point(0, 124);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBaoCao.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBaoCao.NormalTextColor = System.Drawing.Color.White;
            this.btnBaoCao.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnBaoCao.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnBaoCao.PressTextColor = System.Drawing.Color.White;
            this.btnBaoCao.Size = new System.Drawing.Size(200, 57);
            this.btnBaoCao.Style = MetroSet_UI.Enums.Style.Light;
            this.btnBaoCao.StyleManager = null;
            this.btnBaoCao.TabIndex = 1;
            this.btnBaoCao.Text = "Thống kê - Báo cáo";
            this.btnBaoCao.ThemeAuthor = "Narwin";
            this.btnBaoCao.ThemeName = "MetroLite";
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnBanVe
            // 
            this.btnBanVe.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBanVe.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBanVe.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnBanVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnBanVe.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnBanVe.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnBanVe.HoverTextColor = System.Drawing.Color.White;
            this.btnBanVe.IsDerivedStyle = true;
            this.btnBanVe.Location = new System.Drawing.Point(0, 3);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBanVe.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBanVe.NormalTextColor = System.Drawing.Color.White;
            this.btnBanVe.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnBanVe.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnBanVe.PressTextColor = System.Drawing.Color.White;
            this.btnBanVe.Size = new System.Drawing.Size(200, 57);
            this.btnBanVe.Style = MetroSet_UI.Enums.Style.Light;
            this.btnBanVe.StyleManager = null;
            this.btnBanVe.TabIndex = 0;
            this.btnBanVe.Text = "Bán vé";
            this.btnBanVe.ThemeAuthor = "Narwin";
            this.btnBanVe.ThemeName = "MetroLite";
            this.btnBanVe.Click += new System.EventHandler(this.btnBanVe_Click);
            // 
            // pnlFormHD
            // 
            this.pnlFormHD.BackgroundColor = System.Drawing.Color.White;
            this.pnlFormHD.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlFormHD.BorderThickness = 1;
            this.pnlFormHD.IsDerivedStyle = true;
            this.pnlFormHD.Location = new System.Drawing.Point(209, 3);
            this.pnlFormHD.Name = "pnlFormHD";
            this.pnlFormHD.Size = new System.Drawing.Size(862, 575);
            this.pnlFormHD.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlFormHD.StyleManager = null;
            this.pnlFormHD.TabIndex = 0;
            this.pnlFormHD.ThemeAuthor = "Narwin";
            this.pnlFormHD.ThemeName = "MetroLite";
            // 
            // styleManager1
            // 
            this.styleManager1.CustomTheme = "C:\\Users\\Thanh Vi\\AppData\\Roaming\\Microsoft\\Windows\\Templates\\ThemeFile.xml";
            this.styleManager1.MetroForm = this;
            this.styleManager1.Style = MetroSet_UI.Enums.Style.Light;
            this.styleManager1.ThemeAuthor = "Narwin";
            this.styleManager1.ThemeName = "MetroLight";
            // 
            // tabQuanLy
            // 
            this.tabQuanLy.BaseColor = System.Drawing.Color.White;
            this.tabQuanLy.Controls.Add(this.pnlButtonQL);
            this.tabQuanLy.Controls.Add(this.pnlFormQL);
            this.tabQuanLy.Font = null;
            this.tabQuanLy.ImageIndex = 0;
            this.tabQuanLy.ImageKey = null;
            this.tabQuanLy.IsDerivedStyle = true;
            this.tabQuanLy.Location = new System.Drawing.Point(4, 42);
            this.tabQuanLy.Name = "tabQuanLy";
            this.tabQuanLy.Size = new System.Drawing.Size(1176, 677);
            this.tabQuanLy.Style = MetroSet_UI.Enums.Style.Light;
            this.tabQuanLy.StyleManager = this.styleManager1;
            this.tabQuanLy.TabIndex = 1;
            this.tabQuanLy.Text = "Quản lý";
            this.tabQuanLy.ThemeAuthor = "Narwin";
            this.tabQuanLy.ThemeName = "MetroLite";
            this.tabQuanLy.ToolTipText = null;
            // 
            // pnlButtonQL
            // 
            this.pnlButtonQL.BackgroundColor = System.Drawing.Color.White;
            this.pnlButtonQL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlButtonQL.BorderThickness = 0;
            this.pnlButtonQL.Controls.Add(this.btnKhuyenMai);
            this.pnlButtonQL.Controls.Add(this.btnThucPham);
            this.pnlButtonQL.Controls.Add(this.btnHoaDon);
            this.pnlButtonQL.Controls.Add(this.btnLich);
            this.pnlButtonQL.Controls.Add(this.btnTaiKhoan);
            this.pnlButtonQL.Controls.Add(this.btnTroChoi);
            this.pnlButtonQL.Controls.Add(this.btnNVKH);
            this.pnlButtonQL.Controls.Add(this.btnVe);
            this.pnlButtonQL.Controls.Add(this.btnDanhMuc);
            this.pnlButtonQL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlButtonQL.IsDerivedStyle = true;
            this.pnlButtonQL.Location = new System.Drawing.Point(3, 3);
            this.pnlButtonQL.Name = "pnlButtonQL";
            this.pnlButtonQL.Size = new System.Drawing.Size(200, 668);
            this.pnlButtonQL.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlButtonQL.StyleManager = null;
            this.pnlButtonQL.TabIndex = 3;
            this.pnlButtonQL.ThemeAuthor = "Narwin";
            this.pnlButtonQL.ThemeName = "MetroLite";
            // 
            // btnKhuyenMai
            // 
            this.btnKhuyenMai.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhuyenMai.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhuyenMai.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnKhuyenMai.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnKhuyenMai.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnKhuyenMai.HoverTextColor = System.Drawing.Color.White;
            this.btnKhuyenMai.IsDerivedStyle = true;
            this.btnKhuyenMai.Location = new System.Drawing.Point(0, 496);
            this.btnKhuyenMai.Name = "btnKhuyenMai";
            this.btnKhuyenMai.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhuyenMai.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnKhuyenMai.NormalTextColor = System.Drawing.Color.White;
            this.btnKhuyenMai.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnKhuyenMai.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnKhuyenMai.PressTextColor = System.Drawing.Color.White;
            this.btnKhuyenMai.Size = new System.Drawing.Size(200, 57);
            this.btnKhuyenMai.Style = MetroSet_UI.Enums.Style.Light;
            this.btnKhuyenMai.StyleManager = null;
            this.btnKhuyenMai.TabIndex = 10;
            this.btnKhuyenMai.Text = "Khuyến mãi";
            this.btnKhuyenMai.ThemeAuthor = "Narwin";
            this.btnKhuyenMai.ThemeName = "MetroLite";
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
            // 
            // btnThucPham
            // 
            this.btnThucPham.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThucPham.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThucPham.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnThucPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThucPham.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThucPham.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThucPham.HoverTextColor = System.Drawing.Color.White;
            this.btnThucPham.IsDerivedStyle = true;
            this.btnThucPham.Location = new System.Drawing.Point(0, 434);
            this.btnThucPham.Name = "btnThucPham";
            this.btnThucPham.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThucPham.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThucPham.NormalTextColor = System.Drawing.Color.White;
            this.btnThucPham.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThucPham.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThucPham.PressTextColor = System.Drawing.Color.White;
            this.btnThucPham.Size = new System.Drawing.Size(200, 57);
            this.btnThucPham.Style = MetroSet_UI.Enums.Style.Light;
            this.btnThucPham.StyleManager = null;
            this.btnThucPham.TabIndex = 8;
            this.btnThucPham.Text = "Thực phẩm";
            this.btnThucPham.ThemeAuthor = "Narwin";
            this.btnThucPham.ThemeName = "MetroLite";
            this.btnThucPham.Click += new System.EventHandler(this.btnThucPham_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHoaDon.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHoaDon.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnHoaDon.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnHoaDon.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnHoaDon.HoverTextColor = System.Drawing.Color.White;
            this.btnHoaDon.IsDerivedStyle = true;
            this.btnHoaDon.Location = new System.Drawing.Point(0, 372);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHoaDon.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnHoaDon.NormalTextColor = System.Drawing.Color.White;
            this.btnHoaDon.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnHoaDon.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnHoaDon.PressTextColor = System.Drawing.Color.White;
            this.btnHoaDon.Size = new System.Drawing.Size(200, 57);
            this.btnHoaDon.Style = MetroSet_UI.Enums.Style.Light;
            this.btnHoaDon.StyleManager = null;
            this.btnHoaDon.TabIndex = 7;
            this.btnHoaDon.Text = "Hóa đơn";
            this.btnHoaDon.ThemeAuthor = "Narwin";
            this.btnHoaDon.ThemeName = "MetroLite";
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnLich
            // 
            this.btnLich.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLich.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLich.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnLich.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLich.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnLich.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnLich.HoverTextColor = System.Drawing.Color.White;
            this.btnLich.IsDerivedStyle = true;
            this.btnLich.Location = new System.Drawing.Point(0, 310);
            this.btnLich.Name = "btnLich";
            this.btnLich.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLich.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnLich.NormalTextColor = System.Drawing.Color.White;
            this.btnLich.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnLich.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnLich.PressTextColor = System.Drawing.Color.White;
            this.btnLich.Size = new System.Drawing.Size(200, 57);
            this.btnLich.Style = MetroSet_UI.Enums.Style.Light;
            this.btnLich.StyleManager = null;
            this.btnLich.TabIndex = 6;
            this.btnLich.Text = "Thời khóa biểu - Lịch";
            this.btnLich.ThemeAuthor = "Narwin";
            this.btnLich.ThemeName = "MetroLite";
            this.btnLich.Click += new System.EventHandler(this.btnLich_Click);
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTaiKhoan.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTaiKhoan.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTaiKhoan.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnTaiKhoan.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnTaiKhoan.HoverTextColor = System.Drawing.Color.White;
            this.btnTaiKhoan.IsDerivedStyle = true;
            this.btnTaiKhoan.Location = new System.Drawing.Point(0, 186);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTaiKhoan.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTaiKhoan.NormalTextColor = System.Drawing.Color.White;
            this.btnTaiKhoan.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnTaiKhoan.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnTaiKhoan.PressTextColor = System.Drawing.Color.White;
            this.btnTaiKhoan.Size = new System.Drawing.Size(200, 57);
            this.btnTaiKhoan.Style = MetroSet_UI.Enums.Style.Light;
            this.btnTaiKhoan.StyleManager = null;
            this.btnTaiKhoan.TabIndex = 5;
            this.btnTaiKhoan.Text = "Tài khoản";
            this.btnTaiKhoan.ThemeAuthor = "Narwin";
            this.btnTaiKhoan.ThemeName = "MetroLite";
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            // 
            // btnTroChoi
            // 
            this.btnTroChoi.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTroChoi.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTroChoi.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnTroChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTroChoi.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnTroChoi.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnTroChoi.HoverTextColor = System.Drawing.Color.White;
            this.btnTroChoi.IsDerivedStyle = true;
            this.btnTroChoi.Location = new System.Drawing.Point(0, 248);
            this.btnTroChoi.Name = "btnTroChoi";
            this.btnTroChoi.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTroChoi.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnTroChoi.NormalTextColor = System.Drawing.Color.White;
            this.btnTroChoi.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnTroChoi.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnTroChoi.PressTextColor = System.Drawing.Color.White;
            this.btnTroChoi.Size = new System.Drawing.Size(200, 57);
            this.btnTroChoi.Style = MetroSet_UI.Enums.Style.Light;
            this.btnTroChoi.StyleManager = null;
            this.btnTroChoi.TabIndex = 4;
            this.btnTroChoi.Text = "Trò chơi";
            this.btnTroChoi.ThemeAuthor = "Narwin";
            this.btnTroChoi.ThemeName = "MetroLite";
            this.btnTroChoi.Click += new System.EventHandler(this.btnTroChoi_Click);
            // 
            // btnNVKH
            // 
            this.btnNVKH.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNVKH.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNVKH.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnNVKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNVKH.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNVKH.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnNVKH.HoverTextColor = System.Drawing.Color.White;
            this.btnNVKH.IsDerivedStyle = true;
            this.btnNVKH.Location = new System.Drawing.Point(0, 124);
            this.btnNVKH.Name = "btnNVKH";
            this.btnNVKH.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNVKH.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnNVKH.NormalTextColor = System.Drawing.Color.White;
            this.btnNVKH.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNVKH.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnNVKH.PressTextColor = System.Drawing.Color.White;
            this.btnNVKH.Size = new System.Drawing.Size(200, 57);
            this.btnNVKH.Style = MetroSet_UI.Enums.Style.Light;
            this.btnNVKH.StyleManager = null;
            this.btnNVKH.TabIndex = 3;
            this.btnNVKH.Text = "Nhân viên - Khách hàng";
            this.btnNVKH.ThemeAuthor = "Narwin";
            this.btnNVKH.ThemeName = "MetroLite";
            this.btnNVKH.Click += new System.EventHandler(this.btnNVKH_Click);
            // 
            // btnVe
            // 
            this.btnVe.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnVe.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnVe.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVe.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnVe.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnVe.HoverTextColor = System.Drawing.Color.White;
            this.btnVe.IsDerivedStyle = true;
            this.btnVe.Location = new System.Drawing.Point(0, 62);
            this.btnVe.Name = "btnVe";
            this.btnVe.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnVe.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnVe.NormalTextColor = System.Drawing.Color.White;
            this.btnVe.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnVe.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnVe.PressTextColor = System.Drawing.Color.White;
            this.btnVe.Size = new System.Drawing.Size(200, 57);
            this.btnVe.Style = MetroSet_UI.Enums.Style.Light;
            this.btnVe.StyleManager = null;
            this.btnVe.TabIndex = 2;
            this.btnVe.Text = "Vé";
            this.btnVe.ThemeAuthor = "Narwin";
            this.btnVe.ThemeName = "MetroLite";
            this.btnVe.Click += new System.EventHandler(this.btnVe_Click);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDanhMuc.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDanhMuc.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDanhMuc.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnDanhMuc.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnDanhMuc.HoverTextColor = System.Drawing.Color.White;
            this.btnDanhMuc.IsDerivedStyle = true;
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDanhMuc.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnDanhMuc.NormalTextColor = System.Drawing.Color.White;
            this.btnDanhMuc.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnDanhMuc.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnDanhMuc.PressTextColor = System.Drawing.Color.White;
            this.btnDanhMuc.Size = new System.Drawing.Size(200, 57);
            this.btnDanhMuc.Style = MetroSet_UI.Enums.Style.Light;
            this.btnDanhMuc.StyleManager = null;
            this.btnDanhMuc.TabIndex = 0;
            this.btnDanhMuc.Text = "Danh mục loại";
            this.btnDanhMuc.ThemeAuthor = "Narwin";
            this.btnDanhMuc.ThemeName = "MetroLite";
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // pnlFormQL
            // 
            this.pnlFormQL.BackgroundColor = System.Drawing.Color.White;
            this.pnlFormQL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.pnlFormQL.BorderThickness = 1;
            this.pnlFormQL.IsDerivedStyle = true;
            this.pnlFormQL.Location = new System.Drawing.Point(209, 3);
            this.pnlFormQL.Name = "pnlFormQL";
            this.pnlFormQL.Size = new System.Drawing.Size(967, 668);
            this.pnlFormQL.Style = MetroSet_UI.Enums.Style.Light;
            this.pnlFormQL.StyleManager = null;
            this.pnlFormQL.TabIndex = 2;
            this.pnlFormQL.ThemeAuthor = "Narwin";
            this.pnlFormQL.ThemeName = "MetroLite";
            // 
            // tabThongTin
            // 
            this.tabThongTin.BaseColor = System.Drawing.Color.White;
            this.tabThongTin.Font = null;
            this.tabThongTin.ImageIndex = 0;
            this.tabThongTin.ImageKey = null;
            this.tabThongTin.IsDerivedStyle = true;
            this.tabThongTin.Location = new System.Drawing.Point(4, 42);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Size = new System.Drawing.Size(1074, 581);
            this.tabThongTin.Style = MetroSet_UI.Enums.Style.Light;
            this.tabThongTin.StyleManager = this.styleManager1;
            this.tabThongTin.TabIndex = 2;
            this.tabThongTin.Text = "Thông tin cá nhân";
            this.tabThongTin.ThemeAuthor = "Narwin";
            this.tabThongTin.ThemeName = "MetroLite";
            this.tabThongTin.ToolTipText = null;
            // 
            // tabChucNang
            // 
            this.tabChucNang.BaseColor = System.Drawing.Color.White;
            this.tabChucNang.Controls.Add(this.btnSetting);
            this.tabChucNang.Controls.Add(this.btnThoat);
            this.tabChucNang.Font = null;
            this.tabChucNang.ImageIndex = 0;
            this.tabChucNang.ImageKey = null;
            this.tabChucNang.IsDerivedStyle = true;
            this.tabChucNang.Location = new System.Drawing.Point(4, 42);
            this.tabChucNang.Name = "tabChucNang";
            this.tabChucNang.Size = new System.Drawing.Size(1074, 581);
            this.tabChucNang.Style = MetroSet_UI.Enums.Style.Light;
            this.tabChucNang.StyleManager = this.styleManager1;
            this.tabChucNang.TabIndex = 3;
            this.tabChucNang.Text = "Chức năng";
            this.tabChucNang.ThemeAuthor = "Narwin";
            this.tabChucNang.ThemeName = "MetroLite";
            this.tabChucNang.ToolTipText = null;
            // 
            // btnSetting
            // 
            this.btnSetting.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSetting.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSetting.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSetting.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnSetting.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnSetting.HoverTextColor = System.Drawing.Color.White;
            this.btnSetting.IsDerivedStyle = true;
            this.btnSetting.Location = new System.Drawing.Point(432, 151);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSetting.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnSetting.NormalTextColor = System.Drawing.Color.White;
            this.btnSetting.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnSetting.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnSetting.PressTextColor = System.Drawing.Color.White;
            this.btnSetting.Size = new System.Drawing.Size(129, 57);
            this.btnSetting.Style = MetroSet_UI.Enums.Style.Light;
            this.btnSetting.StyleManager = null;
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "Cài đặt cơ sở dữ liệu";
            this.btnSetting.ThemeAuthor = "Narwin";
            this.btnSetting.ThemeName = "MetroLite";
            // 
            // btnThoat
            // 
            this.btnThoat.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnThoat.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThoat.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnThoat.HoverTextColor = System.Drawing.Color.White;
            this.btnThoat.IsDerivedStyle = true;
            this.btnThoat.Location = new System.Drawing.Point(432, 224);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnThoat.NormalTextColor = System.Drawing.Color.White;
            this.btnThoat.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThoat.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnThoat.PressTextColor = System.Drawing.Color.White;
            this.btnThoat.Size = new System.Drawing.Size(129, 56);
            this.btnThoat.Style = MetroSet_UI.Enums.Style.Light;
            this.btnThoat.StyleManager = this.styleManager1;
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.ThemeAuthor = "Narwin";
            this.btnThoat.ThemeName = "MetroLight";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 818);
            this.Controls.Add(this.metroSetTabControl1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmMain2";
            this.Padding = new System.Windows.Forms.Padding(14, 77, 14, 13);
            this.StyleManager = this.styleManager1;
            this.Text = "Phần mềm quản lý khu vui chơi trẻ em";
            this.ThemeName = "MetroLight";
            this.metroSetTabControl1.ResumeLayout(false);
            this.tabHoatDong.ResumeLayout(false);
            this.pnlButtonHD.ResumeLayout(false);
            this.tabQuanLy.ResumeLayout(false);
            this.pnlButtonQL.ResumeLayout(false);
            this.tabChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetTabControl metroSetTabControl1;
        private MetroSet_UI.Child.MetroSetSetTabPage tabHoatDong;
        private MetroSet_UI.Child.MetroSetSetTabPage tabQuanLy;
        private MetroSet_UI.Child.MetroSetSetTabPage tabThongTin;
        private MetroSet_UI.Child.MetroSetSetTabPage tabChucNang;
        private MetroSet_UI.Controls.MetroSetButton btnThoat;
        private MetroSet_UI.Components.StyleManager styleManager1;
        private MetroSet_UI.Controls.MetroSetPanel pnlButtonHD;
        private MetroSet_UI.Controls.MetroSetButton btnBaoCao;
        private MetroSet_UI.Controls.MetroSetButton btnBanVe;
        private MetroSet_UI.Controls.MetroSetPanel pnlFormHD;
        private MetroSet_UI.Controls.MetroSetButton btnThanhToan;
        private MetroSet_UI.Controls.MetroSetPanel pnlButtonQL;
        private MetroSet_UI.Controls.MetroSetButton btnTaiKhoan;
        private MetroSet_UI.Controls.MetroSetButton btnTroChoi;
        private MetroSet_UI.Controls.MetroSetButton btnNVKH;
        private MetroSet_UI.Controls.MetroSetButton btnVe;
        private MetroSet_UI.Controls.MetroSetButton btnDanhMuc;
        private MetroSet_UI.Controls.MetroSetPanel pnlFormQL;
        private MetroSet_UI.Controls.MetroSetButton btnKhuyenMai;
        private MetroSet_UI.Controls.MetroSetButton btnThucPham;
        private MetroSet_UI.Controls.MetroSetButton btnHoaDon;
        private MetroSet_UI.Controls.MetroSetButton btnLich;
        private MetroSet_UI.Controls.MetroSetButton btnSetting;
    }
}
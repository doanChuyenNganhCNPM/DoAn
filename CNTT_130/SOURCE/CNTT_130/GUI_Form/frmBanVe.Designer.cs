namespace GUI_Form
{
    partial class frmBanVe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboLoaiVe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.btnTaoVe = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvHoaDonVe = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvBanVe = new System.Windows.Forms.DataGridView();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.btnLienKet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.btnLuuBanVe = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonVe)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanVe)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTaoVe);
            this.groupBox1.Controls.Add(this.dgvVe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboLoaiVe);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 592);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vé và loại vé";
            // 
            // cboLoaiVe
            // 
            this.cboLoaiVe.FormattingEnabled = true;
            this.cboLoaiVe.Location = new System.Drawing.Point(66, 25);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size = new System.Drawing.Size(179, 25);
            this.cboLoaiVe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại vé";
            // 
            // dgvVe
            // 
            this.dgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVe.Location = new System.Drawing.Point(9, 56);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.Size = new System.Drawing.Size(240, 488);
            this.dgvVe.TabIndex = 2;
            // 
            // btnTaoVe
            // 
            this.btnTaoVe.Location = new System.Drawing.Point(9, 550);
            this.btnTaoVe.Name = "btnTaoVe";
            this.btnTaoVe.Size = new System.Drawing.Size(86, 36);
            this.btnTaoVe.TabIndex = 3;
            this.btnTaoVe.Text = "Tạo vé";
            this.btnTaoVe.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLuuHoaDon);
            this.groupBox2.Controls.Add(this.btnTaoHoaDon);
            this.groupBox2.Controls.Add(this.dgvHoaDon);
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.dtpEnd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpStart);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(279, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(794, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(48, 24);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 25);
            this.dtpStart.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(318, 24);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 25);
            this.dtpEnd.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(554, 26);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(116, 24);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm hóa đơn";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(18, 56);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(770, 131);
            this.dgvHoaDon.TabIndex = 5;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Location = new System.Drawing.Point(566, 193);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(104, 34);
            this.btnTaoHoaDon.TabIndex = 6;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.Location = new System.Drawing.Point(684, 193);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(104, 34);
            this.btnLuuHoaDon.TabIndex = 7;
            this.btnLuuHoaDon.Text = "Lưu hóa đơn";
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvHoaDonVe);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(279, 251);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(794, 150);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hóa đơn - Bán vé";
            // 
            // dgvHoaDonVe
            // 
            this.dgvHoaDonVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonVe.Location = new System.Drawing.Point(8, 24);
            this.dgvHoaDonVe.Name = "dgvHoaDonVe";
            this.dgvHoaDonVe.Size = new System.Drawing.Size(780, 120);
            this.dgvHoaDonVe.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLuuBanVe);
            this.groupBox4.Controls.Add(this.txtTinhTrang);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtSoLuong);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.dtpNgayKetThuc);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.dtpNgayBatDau);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.btnLienKet);
            this.groupBox4.Controls.Add(this.btnBanVe);
            this.groupBox4.Controls.Add(this.dgvBanVe);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox4.Location = new System.Drawing.Point(279, 407);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(794, 197);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bán vé";
            // 
            // dgvBanVe
            // 
            this.dgvBanVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanVe.Location = new System.Drawing.Point(6, 70);
            this.dgvBanVe.Name = "dgvBanVe";
            this.dgvBanVe.Size = new System.Drawing.Size(780, 79);
            this.dgvBanVe.TabIndex = 0;
            // 
            // btnBanVe
            // 
            this.btnBanVe.Location = new System.Drawing.Point(464, 155);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(104, 30);
            this.btnBanVe.TabIndex = 1;
            this.btnBanVe.Text = "Tạo bán vé";
            this.btnBanVe.UseVisualStyleBackColor = true;
            // 
            // btnLienKet
            // 
            this.btnLienKet.Location = new System.Drawing.Point(684, 155);
            this.btnLienKet.Name = "btnLienKet";
            this.btnLienKet.Size = new System.Drawing.Size(104, 30);
            this.btnLienKet.TabIndex = 2;
            this.btnLienKet.Text = "Liên kết";
            this.btnLienKet.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thời gian bắt đầu";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Location = new System.Drawing.Point(142, 15);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(200, 25);
            this.dtpNgayBatDau.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Thời gian kết thúc";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(554, 15);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(200, 25);
            this.dtpNgayKetThuc.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(142, 42);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 25);
            this.txtSoLuong.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tình trạng";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(554, 42);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(200, 25);
            this.txtTinhTrang.TabIndex = 15;
            // 
            // btnLuuBanVe
            // 
            this.btnLuuBanVe.Location = new System.Drawing.Point(574, 155);
            this.btnLuuBanVe.Name = "btnLuuBanVe";
            this.btnLuuBanVe.Size = new System.Drawing.Size(104, 30);
            this.btnLuuBanVe.TabIndex = 16;
            this.btnLuuBanVe.Text = "Lưu bán vé";
            this.btnLuuBanVe.UseVisualStyleBackColor = true;
            // 
            // frmBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 616);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmBanVe";
            this.Text = "frmBanVe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonVe)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanVe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTaoVe;
        private System.Windows.Forms.DataGridView dgvVe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLoaiVe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLuuHoaDon;
        private System.Windows.Forms.Button btnTaoHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvHoaDonVe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLienKet;
        private System.Windows.Forms.Button btnBanVe;
        private System.Windows.Forms.DataGridView dgvBanVe;
        private System.Windows.Forms.Button btnLuuBanVe;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label label7;
    }
}
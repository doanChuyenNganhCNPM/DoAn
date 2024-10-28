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
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiVe = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvHoaDonVe = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvBanVe = new System.Windows.Forms.DataGridView();
            this.btnLuuBanVe = new System.Windows.Forms.Button();
            this.btnLienKet = new System.Windows.Forms.Button();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.btnTaoHoaDon = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnTaoVe = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vé và loại vé";
            // 
            // dgvVe
            // 
            this.dgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVe.Location = new System.Drawing.Point(9, 56);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.Size = new System.Drawing.Size(198, 428);
            this.dgvVe.TabIndex = 2;
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
            // cboLoaiVe
            // 
            this.cboLoaiVe.FormattingEnabled = true;
            this.cboLoaiVe.Location = new System.Drawing.Point(66, 25);
            this.cboLoaiVe.Name = "cboLoaiVe";
            this.cboLoaiVe.Size = new System.Drawing.Size(141, 25);
            this.cboLoaiVe.TabIndex = 0;
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
            this.groupBox2.Location = new System.Drawing.Point(239, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hóa đơn";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(18, 51);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(562, 103);
            this.dgvHoaDon.TabIndex = 5;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpEnd.Location = new System.Drawing.Point(300, 24);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 21);
            this.dtpEnd.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến";
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpStart.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpStart.Location = new System.Drawing.Point(48, 24);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 21);
            this.dtpStart.TabIndex = 1;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvHoaDonVe);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(239, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hóa đơn - Bán vé";
            // 
            // dgvHoaDonVe
            // 
            this.dgvHoaDonVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonVe.Location = new System.Drawing.Point(8, 24);
            this.dgvHoaDonVe.Name = "dgvHoaDonVe";
            this.dgvHoaDonVe.Size = new System.Drawing.Size(572, 106);
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
            this.groupBox4.Location = new System.Drawing.Point(236, 383);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(593, 197);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bán vé";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTinhTrang.Location = new System.Drawing.Point(430, 38);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(153, 21);
            this.txtTinhTrang.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(300, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tình trạng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoLuong.Location = new System.Drawing.Point(142, 42);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(150, 21);
            this.txtSoLuong.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số lượng";
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(430, 15);
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(153, 21);
            this.dtpNgayKetThuc.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Thời gian kết thúc";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayBatDau.Location = new System.Drawing.Point(142, 15);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(150, 21);
            this.dtpNgayBatDau.TabIndex = 9;
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
            // dgvBanVe
            // 
            this.dgvBanVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanVe.Location = new System.Drawing.Point(6, 69);
            this.dgvBanVe.Name = "dgvBanVe";
            this.dgvBanVe.Size = new System.Drawing.Size(577, 79);
            this.dgvBanVe.TabIndex = 0;
            // 
            // btnLuuBanVe
            // 
            this.btnLuuBanVe.Image = global::GUI_Form.Properties.Resources.Lưuf;
            this.btnLuuBanVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuBanVe.Location = new System.Drawing.Point(362, 154);
            this.btnLuuBanVe.Name = "btnLuuBanVe";
            this.btnLuuBanVe.Size = new System.Drawing.Size(123, 30);
            this.btnLuuBanVe.TabIndex = 16;
            this.btnLuuBanVe.Text = "Lưu bán vé";
            this.btnLuuBanVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuBanVe.UseVisualStyleBackColor = true;
            // 
            // btnLienKet
            // 
            this.btnLienKet.Image = global::GUI_Form.Properties.Resources.Lienket;
            this.btnLienKet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLienKet.Location = new System.Drawing.Point(491, 154);
            this.btnLienKet.Name = "btnLienKet";
            this.btnLienKet.Size = new System.Drawing.Size(92, 30);
            this.btnLienKet.TabIndex = 2;
            this.btnLienKet.Text = "Liên kết";
            this.btnLienKet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLienKet.UseVisualStyleBackColor = true;
            // 
            // btnBanVe
            // 
            this.btnBanVe.Image = global::GUI_Form.Properties.Resources.them;
            this.btnBanVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanVe.Location = new System.Drawing.Point(229, 154);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(118, 30);
            this.btnBanVe.TabIndex = 1;
            this.btnBanVe.Text = "Tạo bán vé";
            this.btnBanVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanVe.UseVisualStyleBackColor = true;
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.Image = global::GUI_Form.Properties.Resources.Lưuf;
            this.btnLuuHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(442, 160);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(138, 34);
            this.btnLuuHoaDon.TabIndex = 7;
            this.btnLuuHoaDon.Text = "Lưu hóa đơn";
            this.btnLuuHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.Image = global::GUI_Form.Properties.Resources.them;
            this.btnTaoHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoHoaDon.Location = new System.Drawing.Point(273, 160);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.Size = new System.Drawing.Size(135, 34);
            this.btnTaoHoaDon.TabIndex = 6;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            this.btnTaoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnTim
            // 
            this.btnTim.Image = global::GUI_Form.Properties.Resources.Tim;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(506, 14);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(74, 36);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm ";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // btnTaoVe
            // 
            this.btnTaoVe.BackColor = System.Drawing.Color.LightGray;
            this.btnTaoVe.Image = global::GUI_Form.Properties.Resources.them;
            this.btnTaoVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoVe.Location = new System.Drawing.Point(9, 490);
            this.btnTaoVe.Name = "btnTaoVe";
            this.btnTaoVe.Size = new System.Drawing.Size(92, 36);
            this.btnTaoVe.TabIndex = 3;
            this.btnTaoVe.Text = "Tạo vé";
            this.btnTaoVe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoVe.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(313, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 29);
            this.label8.TabIndex = 58;
            this.label8.Text = "Quản lý bán vé ";
            // 
            // frmBanVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(928, 577);
            this.Controls.Add(this.label8);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label label8;
    }
}
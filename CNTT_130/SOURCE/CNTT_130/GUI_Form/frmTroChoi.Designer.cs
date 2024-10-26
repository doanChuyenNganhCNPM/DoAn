namespace GUI_Form
{
    partial class frmTroChoi
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
            this.dgvQLTroChoi = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.rdNgungHD = new System.Windows.Forms.RadioButton();
            this.rdDangHD = new System.Windows.Forms.RadioButton();
            this.cmbTheLoai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDiaDiem = new System.Windows.Forms.ComboBox();
            this.txtTenTroChoi = new System.Windows.Forms.TextBox();
            this.txtMaTroChoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTroChoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQLTroChoi
            // 
            this.dgvQLTroChoi.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQLTroChoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLTroChoi.Location = new System.Drawing.Point(2, 362);
            this.dgvQLTroChoi.Name = "dgvQLTroChoi";
            this.dgvQLTroChoi.RowHeadersWidth = 62;
            this.dgvQLTroChoi.RowTemplate.Height = 28;
            this.dgvQLTroChoi.Size = new System.Drawing.Size(944, 297);
            this.dgvQLTroChoi.TabIndex = 5;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThoat.Location = new System.Drawing.Point(752, 220);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(126, 74);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLuu.Location = new System.Drawing.Point(572, 220);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(126, 74);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSua.Location = new System.Drawing.Point(392, 220);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(126, 74);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnXoa.Location = new System.Drawing.Point(212, 220);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(126, 74);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnThem.Location = new System.Drawing.Point(32, 220);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(126, 74);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // rdNgungHD
            // 
            this.rdNgungHD.AutoSize = true;
            this.rdNgungHD.Location = new System.Drawing.Point(624, 124);
            this.rdNgungHD.Name = "rdNgungHD";
            this.rdNgungHD.Size = new System.Drawing.Size(157, 24);
            this.rdNgungHD.TabIndex = 5;
            this.rdNgungHD.TabStop = true;
            this.rdNgungHD.Text = "Ngừng hoạt động";
            this.rdNgungHD.UseVisualStyleBackColor = true;
            // 
            // rdDangHD
            // 
            this.rdDangHD.AutoSize = true;
            this.rdDangHD.Location = new System.Drawing.Point(624, 64);
            this.rdDangHD.Name = "rdDangHD";
            this.rdDangHD.Size = new System.Drawing.Size(149, 24);
            this.rdDangHD.TabIndex = 5;
            this.rdDangHD.TabStop = true;
            this.rdDangHD.Text = "Đang hoạt động";
            this.rdDangHD.UseVisualStyleBackColor = true;
            // 
            // cmbTheLoai
            // 
            this.cmbTheLoai.FormattingEnabled = true;
            this.cmbTheLoai.Location = new System.Drawing.Point(339, 146);
            this.cmbTheLoai.Name = "cmbTheLoai";
            this.cmbTheLoai.Size = new System.Drawing.Size(209, 28);
            this.cmbTheLoai.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(339, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thể loại";
            // 
            // cmbDiaDiem
            // 
            this.cmbDiaDiem.FormattingEnabled = true;
            this.cmbDiaDiem.Location = new System.Drawing.Point(339, 42);
            this.cmbDiaDiem.Name = "cmbDiaDiem";
            this.cmbDiaDiem.Size = new System.Drawing.Size(209, 28);
            this.cmbDiaDiem.TabIndex = 2;
            // 
            // txtTenTroChoi
            // 
            this.txtTenTroChoi.Location = new System.Drawing.Point(32, 149);
            this.txtTenTroChoi.Name = "txtTenTroChoi";
            this.txtTenTroChoi.Size = new System.Drawing.Size(209, 26);
            this.txtTenTroChoi.TabIndex = 1;
            // 
            // txtMaTroChoi
            // 
            this.txtMaTroChoi.Location = new System.Drawing.Point(32, 42);
            this.txtMaTroChoi.Name = "txtMaTroChoi";
            this.txtMaTroChoi.Size = new System.Drawing.Size(209, 26);
            this.txtMaTroChoi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên trò chơi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(620, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Địa điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã trò chơi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.rdNgungHD);
            this.panel1.Controls.Add(this.rdDangHD);
            this.panel1.Controls.Add(this.cmbTheLoai);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbDiaDiem);
            this.panel1.Controls.Add(this.txtTenTroChoi);
            this.panel1.Controls.Add(this.txtMaTroChoi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 296);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ TRÒ CHƠI";
            // 
            // frmTroChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 670);
            this.Controls.Add(this.dgvQLTroChoi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmTroChoi";
            this.Text = "frmTroChoi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTroChoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQLTroChoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.RadioButton rdNgungHD;
        private System.Windows.Forms.RadioButton rdDangHD;
        private System.Windows.Forms.ComboBox cmbTheLoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDiaDiem;
        private System.Windows.Forms.TextBox txtTenTroChoi;
        private System.Windows.Forms.TextBox txtMaTroChoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
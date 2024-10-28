namespace GUI_Form
{
    partial class frmQLTroChoi
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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTroChoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQLTroChoi
            // 
            this.dgvQLTroChoi.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvQLTroChoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLTroChoi.Location = new System.Drawing.Point(86, 242);
            this.dgvQLTroChoi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvQLTroChoi.Name = "dgvQLTroChoi";
            this.dgvQLTroChoi.RowHeadersWidth = 62;
            this.dgvQLTroChoi.RowTemplate.Height = 28;
            this.dgvQLTroChoi.Size = new System.Drawing.Size(629, 193);
            this.dgvQLTroChoi.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button7);
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
            this.panel1.Location = new System.Drawing.Point(86, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 192);
            this.panel1.TabIndex = 4;
            // 
            // rdNgungHD
            // 
            this.rdNgungHD.AutoSize = true;
            this.rdNgungHD.Location = new System.Drawing.Point(416, 81);
            this.rdNgungHD.Margin = new System.Windows.Forms.Padding(2);
            this.rdNgungHD.Name = "rdNgungHD";
            this.rdNgungHD.Size = new System.Drawing.Size(109, 17);
            this.rdNgungHD.TabIndex = 5;
            this.rdNgungHD.TabStop = true;
            this.rdNgungHD.Text = "Ngừng hoạt động";
            this.rdNgungHD.UseVisualStyleBackColor = true;
            // 
            // rdDangHD
            // 
            this.rdDangHD.AutoSize = true;
            this.rdDangHD.Location = new System.Drawing.Point(416, 42);
            this.rdDangHD.Margin = new System.Windows.Forms.Padding(2);
            this.rdDangHD.Name = "rdDangHD";
            this.rdDangHD.Size = new System.Drawing.Size(103, 17);
            this.rdDangHD.TabIndex = 5;
            this.rdDangHD.TabStop = true;
            this.rdDangHD.Text = "Đang hoạt động";
            this.rdDangHD.UseVisualStyleBackColor = true;
            // 
            // cmbTheLoai
            // 
            this.cmbTheLoai.FormattingEnabled = true;
            this.cmbTheLoai.Location = new System.Drawing.Point(226, 95);
            this.cmbTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTheLoai.Name = "cmbTheLoai";
            this.cmbTheLoai.Size = new System.Drawing.Size(141, 21);
            this.cmbTheLoai.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Thể loại";
            // 
            // cmbDiaDiem
            // 
            this.cmbDiaDiem.FormattingEnabled = true;
            this.cmbDiaDiem.Location = new System.Drawing.Point(226, 27);
            this.cmbDiaDiem.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDiaDiem.Name = "cmbDiaDiem";
            this.cmbDiaDiem.Size = new System.Drawing.Size(141, 21);
            this.cmbDiaDiem.TabIndex = 2;
            // 
            // txtTenTroChoi
            // 
            this.txtTenTroChoi.Location = new System.Drawing.Point(21, 97);
            this.txtTenTroChoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenTroChoi.Name = "txtTenTroChoi";
            this.txtTenTroChoi.Size = new System.Drawing.Size(141, 20);
            this.txtTenTroChoi.TabIndex = 1;
            // 
            // txtMaTroChoi
            // 
            this.txtMaTroChoi.Location = new System.Drawing.Point(21, 27);
            this.txtMaTroChoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaTroChoi.Name = "txtMaTroChoi";
            this.txtMaTroChoi.Size = new System.Drawing.Size(141, 20);
            this.txtMaTroChoi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên trò chơi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Địa điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã trò chơi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ TRÒ CHƠI";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::GUI_Form.Properties.Resources.reset_25;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(507, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 29);
            this.button4.TabIndex = 46;
            this.button4.Text = "Reset";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::GUI_Form.Properties.Resources.Lưuf;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(381, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 47;
            this.button1.Text = "Lưu";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::GUI_Form.Properties.Resources.xóa;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(135, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 44;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::GUI_Form.Properties.Resources.sửa;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(256, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 29);
            this.button3.TabIndex = 45;
            this.button3.Text = "Sửa";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::GUI_Form.Properties.Resources.them;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(22, 136);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 29);
            this.button7.TabIndex = 43;
            this.button7.Text = "Thêm";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // frmQLTroChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvQLTroChoi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frmQLTroChoi";
            this.Text = "frmQLTroChoi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTroChoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQLTroChoi;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
    }
}
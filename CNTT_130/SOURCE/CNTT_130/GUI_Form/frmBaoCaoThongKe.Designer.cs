namespace GUI_Form
{
    partial class frmBaoCaoThongKe
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
            this.dgvBaoCao_ThongKe = new System.Windows.Forms.DataGridView();
            this.cbTonKho = new System.Windows.Forms.CheckBox();
            this.cbDoanhThu = new System.Windows.Forms.CheckBox();
            this.dateTimePickerNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdPdf = new System.Windows.Forms.RadioButton();
            this.rdExcel = new System.Windows.Forms.RadioButton();
            this.rdWord = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao_ThongKe)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBaoCao_ThongKe
            // 
            this.dgvBaoCao_ThongKe.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvBaoCao_ThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao_ThongKe.Location = new System.Drawing.Point(85, 200);
            this.dgvBaoCao_ThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBaoCao_ThongKe.Name = "dgvBaoCao_ThongKe";
            this.dgvBaoCao_ThongKe.RowHeadersWidth = 62;
            this.dgvBaoCao_ThongKe.RowTemplate.Height = 28;
            this.dgvBaoCao_ThongKe.Size = new System.Drawing.Size(630, 242);
            this.dgvBaoCao_ThongKe.TabIndex = 16;
            // 
            // cbTonKho
            // 
            this.cbTonKho.AutoSize = true;
            this.cbTonKho.Location = new System.Drawing.Point(287, 127);
            this.cbTonKho.Margin = new System.Windows.Forms.Padding(2);
            this.cbTonKho.Name = "cbTonKho";
            this.cbTonKho.Size = new System.Drawing.Size(111, 17);
            this.cbTonKho.TabIndex = 13;
            this.cbTonKho.Text = "Thống kê tồn kho";
            this.cbTonKho.UseVisualStyleBackColor = true;
            // 
            // cbDoanhThu
            // 
            this.cbDoanhThu.AutoSize = true;
            this.cbDoanhThu.Location = new System.Drawing.Point(127, 127);
            this.cbDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.cbDoanhThu.Name = "cbDoanhThu";
            this.cbDoanhThu.Size = new System.Drawing.Size(123, 17);
            this.cbDoanhThu.TabIndex = 14;
            this.cbDoanhThu.Text = "Thống kê doanh thu";
            this.cbDoanhThu.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNgayKetThuc
            // 
            this.dateTimePickerNgayKetThuc.Location = new System.Drawing.Point(381, 78);
            this.dateTimePickerNgayKetThuc.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNgayKetThuc.Name = "dateTimePickerNgayKetThuc";
            this.dateTimePickerNgayKetThuc.Size = new System.Drawing.Size(139, 20);
            this.dateTimePickerNgayKetThuc.TabIndex = 11;
            // 
            // dateTimePickerNgayBatDau
            // 
            this.dateTimePickerNgayBatDau.Location = new System.Drawing.Point(127, 78);
            this.dateTimePickerNgayBatDau.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNgayBatDau.Name = "dateTimePickerNgayBatDau";
            this.dateTimePickerNgayBatDau.Size = new System.Drawing.Size(139, 20);
            this.dateTimePickerNgayBatDau.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày kết thúc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ngày bắt đầu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "BÁO CÁO THÔNG KÊ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Controls.Add(this.rdPdf);
            this.panel1.Controls.Add(this.rdExcel);
            this.panel1.Controls.Add(this.rdWord);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(85, 41);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 155);
            this.panel1.TabIndex = 15;
            // 
            // rdPdf
            // 
            this.rdPdf.AutoSize = true;
            this.rdPdf.Location = new System.Drawing.Point(410, 125);
            this.rdPdf.Margin = new System.Windows.Forms.Padding(2);
            this.rdPdf.Name = "rdPdf";
            this.rdPdf.Size = new System.Drawing.Size(40, 17);
            this.rdPdf.TabIndex = 1;
            this.rdPdf.TabStop = true;
            this.rdPdf.Text = "pdf";
            this.rdPdf.UseVisualStyleBackColor = true;
            // 
            // rdExcel
            // 
            this.rdExcel.AutoSize = true;
            this.rdExcel.Location = new System.Drawing.Point(410, 105);
            this.rdExcel.Margin = new System.Windows.Forms.Padding(2);
            this.rdExcel.Name = "rdExcel";
            this.rdExcel.Size = new System.Drawing.Size(51, 17);
            this.rdExcel.TabIndex = 1;
            this.rdExcel.TabStop = true;
            this.rdExcel.Text = "Excel";
            this.rdExcel.UseVisualStyleBackColor = true;
            // 
            // rdWord
            // 
            this.rdWord.AutoSize = true;
            this.rdWord.Location = new System.Drawing.Point(410, 86);
            this.rdWord.Margin = new System.Windows.Forms.Padding(2);
            this.rdWord.Name = "rdWord";
            this.rdWord.Size = new System.Drawing.Size(51, 17);
            this.rdWord.TabIndex = 1;
            this.rdWord.TabStop = true;
            this.rdWord.Text = "Word";
            this.rdWord.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "In báo cáo";
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Image = global::GUI_Form.Properties.Resources._in;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(511, 86);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(63, 55);
            this.btnIn.TabIndex = 2;
            this.btnIn.Text = "In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = false;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBaoCao_ThongKe);
            this.Controls.Add(this.cbTonKho);
            this.Controls.Add(this.cbDoanhThu);
            this.Controls.Add(this.dateTimePickerNgayKetThuc);
            this.Controls.Add(this.dateTimePickerNgayBatDau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmBaoCaoThongKe";
            this.Text = "frmBaoCaoThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao_ThongKe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBaoCao_ThongKe;
        private System.Windows.Forms.CheckBox cbTonKho;
        private System.Windows.Forms.CheckBox cbDoanhThu;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dateTimePickerNgayBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.RadioButton rdPdf;
        private System.Windows.Forms.RadioButton rdExcel;
        private System.Windows.Forms.RadioButton rdWord;
        private System.Windows.Forms.Label label4;
    }
}
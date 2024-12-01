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
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBanVe = new System.Windows.Forms.RadioButton();
            this.rdoThemNguoiLon = new System.Windows.Forms.RadioButton();
            this.rdoCoKM = new System.Windows.Forms.RadioButton();
            this.rdoLaoiKM = new System.Windows.Forms.RadioButton();
            this.btnBieuDo = new System.Windows.Forms.Button();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.label8.Location = new System.Drawing.Point(500, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(360, 37);
            this.label8.TabIndex = 99;
            this.label8.Text = "BÁO CÁO - THỐNG KÊ";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Arial", 11.25F);
            this.dtpEnd.Location = new System.Drawing.Point(660, 73);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 25);
            this.dtpEnd.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 22);
            this.label3.TabIndex = 102;
            this.label3.Text = "Đến";
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpStart.Font = new System.Drawing.Font("Arial", 11.25F);
            this.dtpStart.Location = new System.Drawing.Point(352, 73);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 25);
            this.dtpStart.TabIndex = 101;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 22);
            this.label2.TabIndex = 100;
            this.label2.Text = "Từ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoLaoiKM);
            this.groupBox1.Controls.Add(this.rdoCoKM);
            this.groupBox1.Controls.Add(this.rdoThemNguoiLon);
            this.groupBox1.Controls.Add(this.rdoBanVe);
            this.groupBox1.Location = new System.Drawing.Point(322, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 139);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Biểu đồ";
            // 
            // rdoBanVe
            // 
            this.rdoBanVe.AutoSize = true;
            this.rdoBanVe.Location = new System.Drawing.Point(30, 37);
            this.rdoBanVe.Name = "rdoBanVe";
            this.rdoBanVe.Size = new System.Drawing.Size(170, 26);
            this.rdoBanVe.TabIndex = 0;
            this.rdoBanVe.TabStop = true;
            this.rdoBanVe.Text = "Doanh thu bán vé";
            this.rdoBanVe.UseVisualStyleBackColor = true;
            // 
            // rdoThemNguoiLon
            // 
            this.rdoThemNguoiLon.AutoSize = true;
            this.rdoThemNguoiLon.Location = new System.Drawing.Point(30, 85);
            this.rdoThemNguoiLon.Name = "rdoThemNguoiLon";
            this.rdoThemNguoiLon.Size = new System.Drawing.Size(185, 26);
            this.rdoThemNguoiLon.TabIndex = 1;
            this.rdoThemNguoiLon.TabStop = true;
            this.rdoThemNguoiLon.Text = "Tỉ lệ thêm người lớn";
            this.rdoThemNguoiLon.UseVisualStyleBackColor = true;
            // 
            // rdoCoKM
            // 
            this.rdoCoKM.AutoSize = true;
            this.rdoCoKM.Location = new System.Drawing.Point(293, 37);
            this.rdoCoKM.Name = "rdoCoKM";
            this.rdoCoKM.Size = new System.Drawing.Size(229, 26);
            this.rdoCoKM.TabIndex = 2;
            this.rdoCoKM.TabStop = true;
            this.rdoCoKM.Text = "Tỉ lệ áp dụng khuyến mãi";
            this.rdoCoKM.UseVisualStyleBackColor = true;
            // 
            // rdoLaoiKM
            // 
            this.rdoLaoiKM.AutoSize = true;
            this.rdoLaoiKM.Location = new System.Drawing.Point(293, 85);
            this.rdoLaoiKM.Name = "rdoLaoiKM";
            this.rdoLaoiKM.Size = new System.Drawing.Size(272, 26);
            this.rdoLaoiKM.TabIndex = 3;
            this.rdoLaoiKM.TabStop = true;
            this.rdoLaoiKM.Text = "Loại khuyến mãi được áp dụng";
            this.rdoLaoiKM.UseVisualStyleBackColor = true;
            // 
            // btnBieuDo
            // 
            this.btnBieuDo.Location = new System.Drawing.Point(889, 69);
            this.btnBieuDo.Name = "btnBieuDo";
            this.btnBieuDo.Size = new System.Drawing.Size(123, 36);
            this.btnBieuDo.TabIndex = 105;
            this.btnBieuDo.Text = "Biểu đồ";
            this.btnBieuDo.UseVisualStyleBackColor = true;
            this.btnBieuDo.Click += new System.EventHandler(this.btnBieuDo_Click);
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.Location = new System.Drawing.Point(15, 316);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(1243, 481);
            this.pnlHienThi.TabIndex = 106;
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 812);
            this.Controls.Add(this.pnlHienThi);
            this.Controls.Add(this.btnBieuDo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Name = "frmBaoCaoThongKe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLaoiKM;
        private System.Windows.Forms.RadioButton rdoCoKM;
        private System.Windows.Forms.RadioButton rdoThemNguoiLon;
        private System.Windows.Forms.RadioButton rdoBanVe;
        private System.Windows.Forms.Button btnBieuDo;
        private System.Windows.Forms.Panel pnlHienThi;
    }
}
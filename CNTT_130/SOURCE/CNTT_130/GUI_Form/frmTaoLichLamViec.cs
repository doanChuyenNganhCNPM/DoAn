using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace GUI_Form
{
    public partial class frmTaoLichLamViec : MetroSet_UI.Forms.MetroSetForm
    {
        LichLamviec llv = new LichLamviec();
        BLL_NhanVien nv = new BLL_NhanVien();
        public frmTaoLichLamViec()
        {
            InitializeComponent();
            txtMaNV.Enabled = false;
            txtThoiGianLam.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadSchedule(DateTime.Now);
            LoadCBBNV();
            LoadCa();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgayLam.Format = DateTimePickerFormat.Custom;
            dtpNgayLam.CustomFormat = "dd/MM/yyyy";
            dtpNgayLam.MinDate = DateTime.Today;
            dgvLLV.ReadOnly = true;
        }

        private void frmTaoLichLamViec_Load(object sender, EventArgs e)
        {
            LoadSchedule(dtpNgay.Value);
        }

        private void LoadSchedule(DateTime selectedDate)
        {
            // Gọi hàm GetMaxNVSchedule từ BLL
            var schedules = llv.GetMaxNVSchedule(selectedDate);

            // Kiểm tra nếu không có dữ liệu, tạo một hàng trống
            if (schedules.Count == 0)
            {
                schedules.Add(new
                {
                    MaNV = "",
                    TenNV = "",
                    NgayLam = (DateTime?)null,
                    CaLam = "",
                    ThoiGianLam = ""
                });
            }

            // Gán dữ liệu vào DataGridView
            dgvLLV.DataSource = schedules;
            dgvLLV.ColumnHeadersHeight = 40;

            // Tùy chỉnh các cột nếu cần
            dgvLLV.Columns["MaNV"].HeaderText = "Mã NV";
            dgvLLV.Columns["TenNV"].HeaderText = "Tên NV";
            dgvLLV.Columns["NgayLam"].HeaderText = "Ngày Làm";
            dgvLLV.Columns["CaLam"].HeaderText = "Ca Làm";
            dgvLLV.Columns["ThoiGianLam"].HeaderText = "Thời Gian Làm";
        }

        private void LoadCBBNV()
        {
            var employeeNames = nv.GetEmployeeNames();
            txtTenNV.DataSource = employeeNames;
        }

        private void LoadCa()
        {
            var caLV = llv.GetCaLams();
            var caLamsDisplay = caLV.Select(ca => ca.HasValue ? ca.Value.ToString() : "Không có ca").ToList();
            cmbCa.DataSource = caLamsDisplay;
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            string tenNhanVien = txtTenNV.Text.Trim();

            // Nếu tên nhân viên không trống
            if (!string.IsNullOrEmpty(tenNhanVien))
            {

                // Gọi phương thức để lấy mã nhân viên theo tên
                string maNV = nv.GetMaNhanVienByName(tenNhanVien);

                // Nếu tìm thấy mã nhân viên, cập nhật vào TextBox txtMaNhanVien
                if (!string.IsNullOrEmpty(maNV))
                {
                    txtMaNV.Text = maNV;
                }
                else
                {
                    // Nếu không tìm thấy, có thể hiển thị một thông báo hoặc để trống
                    txtMaNV.Clear();
                }
            }
            else
            {
                // Nếu tên nhân viên trống, xóa mã nhân viên
                txtMaNV.Clear();
            }
        }

        private void cmbCa_TextChanged(object sender, EventArgs e)
        {
            if (cmbCa.SelectedItem != null)
            {
                int caLam = Convert.ToInt32(cmbCa.SelectedItem);
                // Gọi phương thức để lấy thời gian làm từ ca làm
                string thoiGianLam = llv.GetThoiGianLamByCa(caLam);

                // Cập nhật thời gian làm vào TextBox
                txtThoiGianLam.Text = thoiGianLam ?? "Không tìm thấy";
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text; // Mã nhân viên từ TextBox
            DateTime ngayLam = dtpNgayLam.Value; // Ngày làm từ DateTimePicker
            int caLam = Convert.ToInt32(cmbCa.SelectedValue); // Ca làm từ ComboBox
            int chamCong = ckbCong.Checked ? 1 : 0; // Lấy trạng thái từ CheckBox

            // Gọi phương thức SaveToTKB để lưu và nhận thông báo
            string message = llv.SaveToTKB(maNV, ngayLam, caLam, chamCong);

            // Hiển thị thông báo trong MessageBox
            MessageBox.Show(message);

            // Tải lại lịch làm việc sau khi thêm mới
            LoadSchedule(dtpNgayLam.Value);
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadSchedule(dtpNgay.Value);
        }

        private void frmTaoLichLamViec_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Kiểm tra nếu form đóng từ nút X (Close button)
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    // Gọi lại phương thức BindWorkScheduleToDataGridView từ form chính
                    if (this.Owner != null && this.Owner is frmQLNhanVien mainForm)
                    {
                        // Tạo tham chiếu tới panel và DateTimePicker của form chính
                        Panel panelWorkSchedule = (Panel)mainForm.Controls["panelWorkSchedule"];
                        DateTimePicker dateTimePicker = (DateTimePicker)panelWorkSchedule.Controls["dateTimePicker"];
                        DataGridView dataGridViewWorkSchedule = (DataGridView)panelWorkSchedule.Controls["dataGridViewWorkSchedule"];

                        // Gọi phương thức cập nhật dữ liệu
                        mainForm.BindWorkScheduleToDataGridView(dataGridViewWorkSchedule, dateTimePicker.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

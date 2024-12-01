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
using DTO;

namespace GUI_Form
{
    public partial class frmQLNhanVien : MetroSet_UI.Forms.MetroSetForm
    {
        BLL_NhanVien bll = new BLL_NhanVien();
        BLL_LoaiNhanVien bll_LNV = new BLL_LoaiNhanVien();

        public frmQLNhanVien()
        {
            InitializeComponent();
            LoadDataNV();
            LoadLoaiNVToCheckBox();
            LoadLoaiNV();
            txtMaNV.Enabled = false;
            dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
            txtNS.Format = DateTimePickerFormat.Custom;
            txtNS.CustomFormat = "dd/MM/yyyy";
            dgvNV.ReadOnly = true;

        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataNV();
        }

        private void LoadDataNV()
        {
            if (!dgvNV.Columns.Contains("Check"))
            {
                // Thêm cột checkbox vào đầu
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Hôm nay làm",  // Tiêu đề của cột checkbox
                    Name = "Check",
                    Width = 50,
                    FalseValue = false,
                    TrueValue = true
                };
                dgvNV.Columns.Add(checkColumn);
            }


            DataTable dt = bll.getAllData();
            dgvNV.DataSource = dt;
            dgvNV.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvNV.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dgvNV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvNV.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvNV.Columns["CCCD"].HeaderText = "CCCD";
            dgvNV.Columns["LoaiNV"].HeaderText = "Loại Nhân Viên";
            UpdateCheckBoxForToday(dgvNV);
        }

        private void LoadLoaiNVToCheckBox()
        {
            List<LoaiNV> dsLoaiNV = bll_LNV.GetLoaiNVs();
            LoaiNV allLoaiNV = new LoaiNV { MaLoai = "-1", ChucVu = "Tất cả" };
            dsLoaiNV.Insert(0, allLoaiNV);
            cbbLoaiNV.DataSource = dsLoaiNV;
            cbbLoaiNV.DisplayMember = "ChucVu";
            cbbLoaiNV.ValueMember = "MaLoai";
        }

        private void LoadLoaiNV()
        {
            List<LoaiNV> dsLoaiNV = bll_LNV.GetLoaiNVs();
            cboLNV.DataSource = dsLoaiNV;
            cboLNV.DisplayMember = "ChucVu";
            cboLNV.ValueMember = "MaLoai";
        }

        public void UpdateCheckBoxForToday(DataGridView dgv)
        {
            try
            {
                // Lấy danh sách mã nhân viên làm hôm nay
                List<string> employeesWorkingToday = bll.GetEmployeesWorkingToday();

                // Duyệt từng dòng trong DataGridView
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["MaNV"] != null && row.Cells["Check"] != null)
                    {
                        string maNV = row.Cells["MaNV"].Value?.ToString();

                        // Kiểm tra nếu mã nhân viên có trong danh sách làm hôm nay
                        if (employeesWorkingToday.Contains(maNV))
                        {
                            row.Cells["Check"].Value = true; // Tích checkbox
                        }
                        else
                        {
                            row.Cells["Check"].Value = false; // Không tích checkbox
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin của dòng được click
                DataGridViewRow row = dgvNV.Rows[e.RowIndex];

                // Điền thông tin vào các TextBox hoặc các điều khiển khác
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();  // Giả sử bạn có cột MaNV
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString(); // Cột TenNV
                txtCCCD.Text = row.Cells["CCCD"].Value.ToString();   // Cột CCCD



                // Điền thông tin ngày sinh (nếu có)
                if (row.Cells["NgaySinh"].Value != DBNull.Value)
                {
                    txtNS.Value = (DateTime)row.Cells["NgaySinh"].Value;
                }

                // Chọn giới tính
                string gioiTinh = row.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    rdoNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    rdoNu.Checked = true;
                }

                //cmb Loại NV 
                string loaiNV = row.Cells["LoaiNV"].Value.ToString();
                cboLNV.Text = bll_LNV.GetEmployeeTypeName(loaiNV);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các trường nhập liệu xem có rỗng không
                if (string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtCCCD.Text) || string.IsNullOrEmpty(cboLNV.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin nhân viên.");
                    return;
                }

                // Kiểm tra ngày sinh
                DateTime ngaySinh;
                if (!DateTime.TryParse(txtNS.Value.ToString(), out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ.");
                    return;
                }

                // Tạo đối tượng nhân viên
                string Loainv = cboLNV.SelectedValue.ToString();
                var nv = new NhanVien
                {
                    TenNV = txtTenNV.Text,
                    GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = ngaySinh.Date,
                    CCCD = txtCCCD.Text,
                    LoaiNV = Loainv
                };

                // Gọi phương thức thêm nhân viên từ lớp BLL
                bool result = bll.addEmployee(nv);

                // Kiểm tra kết quả thêm nhân viên
                if (result)
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    LoadDataNV(); // Tải lại dữ liệu nhân viên
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung nếu có
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;

            if (bll.removeEmployee(maNV))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                LoadDataNV();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string Loainv = cboLNV.SelectedValue.ToString();
            NhanVien nv = new NhanVien
            {
                TenNV = txtTenNV.Text,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                NgaySinh = txtNS.Value,
                CCCD = txtCCCD.Text,
                LoaiNV = Loainv
            };

            if (bll.updateEmployee(maNV, nv))
            {
                MessageBox.Show("Cập nhật nhân viên thành công");
                LoadDataNV();
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isReset = true;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtCCCD.Clear();
            txtNS.Value = DateTime.Now;
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            cboLNV.SelectedIndex = -1;
            txtTimKiem.Clear();
            LoadDataNV();
            isReset = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string search = txtTimKiem.Text;
            DataTable dt = bll.getDataBySearch(search);
            dgvNV.DataSource = dt;
            UpdateCheckBoxForToday(dgvNV);
            if (dgvNV.Columns.Contains("LoaiNV1"))
            {
                dgvNV.Columns.Remove("LoaiNV1");
            }
        }

        private void cbbLoaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy loại nhân viên đã chọn từ ComboBox
            var selectedLoaiNV = (LoaiNV)cbbLoaiNV.SelectedItem;
            string maLoai = selectedLoaiNV?.MaLoai;

            // Kiểm tra mã loại nhân viên được chọn
            if (maLoai == "-1") // Nếu chọn "Tất cả", hiển thị tất cả nhân viên
            {
                LoadDataNV();
            }
            else if (!string.IsNullOrEmpty(maLoai)) // Nếu có mã loại hợp lệ
            {
                // Lọc danh sách nhân viên theo loại nhân viên
                List<NhanVien> nhanViens = bll.getNhanViensByLoaiNV(maLoai);
                dgvNV.DataSource = nhanViens;
            }
            else
            {
                dgvNV.DataSource = null; // Nếu không có lựa chọn hợp lệ, xóa dữ liệu trong DataGridView
            }

            // Nếu DataGridView có cột không cần thiết, hãy xóa cột đó
            if (dgvNV.Columns.Contains("LoaiNV1"))
            {
                dgvNV.Columns.Remove("LoaiNV1");
            }
            UpdateCheckBoxForToday(dgvNV);
        }

        public void BindWorkScheduleToDataGridView(DataGridView dataGridView, DateTime targetDate)
        {
            try
            {
                // Lấy dữ liệu từ phương thức GetWorkScheduleByExactDate
                List<dynamic> workSchedule = bll.GetWorkScheduleByExactDate(targetDate) ?? new List<dynamic>();

                // Tắt tự động tạo cột
                dataGridView.AutoGenerateColumns = false;

                // Xóa toàn bộ dữ liệu cũ và cột
                dataGridView.DataSource = null;
                dataGridView.Columns.Clear();

                // Thêm cột thủ công
                // Thêm cột Checkbox cho ChamCong
                DataGridViewCheckBoxColumn chkChamCong = new DataGridViewCheckBoxColumn
                {
                    Name = "ChamCong",
                    HeaderText = "Chấm Công",
                    DataPropertyName = "ChamCong"
                };
                dataGridView.Columns.Add(chkChamCong);

                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaNV", HeaderText = "Mã Nhân Viên", DataPropertyName = "MaNV" });
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenNV", HeaderText = "Tên Nhân Viên", DataPropertyName = "TenNV" });
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "ChucVu", HeaderText = "Chức vụ", DataPropertyName = "ChucVu" });
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "NgayLam", HeaderText = "Ngày Làm", DataPropertyName = "NgayLam" });
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "ThoiGianLam", HeaderText = "Thời Gian Làm", DataPropertyName = "ThoiGianLam" });
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ca", HeaderText = "Ca Làm", DataPropertyName = "Ca" });

                // Nếu danh sách rỗng, tạo một phần tử trống để đảm bảo hiển thị cột
                if (workSchedule.Count == 0)
                {
                    workSchedule.Add(new
                    {
                        MaNV = "",
                        TenNV = "",
                        ChucVu = "",
                        NgayLam = DateTime.MinValue,
                        ThoiGianLam = "",
                        Ca = "",
                        ChamCong = 0
                    });
                }

                // Gán dữ liệu vào DataGridView
                BindingList<dynamic> bindingList = new BindingList<dynamic>(workSchedule);
                dataGridView.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Có lỗi khi lấy dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void btnLLV_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem panel đã tồn tại chưa, nếu chưa thì tạo mới
            if (this.Controls["panelWorkSchedule"] == null)
            {
                // 1. Tạo Panel
                Panel panelWorkSchedule = new Panel();
                panelWorkSchedule.Name = "panelWorkSchedule";
                panelWorkSchedule.Size = new Size(780, 400);  // Kích thước của panel
                                                              // panelWorkSchedule.Location = new Point(20, 60);
                panelWorkSchedule.BackColor = Color.White;  // Màu nền của panel
                panelWorkSchedule.BorderStyle = BorderStyle.FixedSingle; // Tạo đường viền cho panel
                panelWorkSchedule.BringToFront(); // Đảm bảo panel sẽ hiển thị lên trên form
                panelWorkSchedule.Location = new Point(
                    (this.ClientSize.Width - panelWorkSchedule.Width) / 2,  // Tính toán vị trí X
                    (this.ClientSize.Height - panelWorkSchedule.Height) / 2 // Tính toán vị trí Y
                );
                this.Controls.Add(panelWorkSchedule);  // Thêm panel vào form
                panelWorkSchedule.BringToFront();

                // 2. Tạo Label "LỊCH LÀM VIỆC"
                Label lblWorkSchedule = new Label();
                lblWorkSchedule.Text = "LỊCH LÀM VIỆC";
                lblWorkSchedule.Font = new Font("Arial", 12, FontStyle.Bold); // Cỡ chữ và kiểu chữ in đậm
                lblWorkSchedule.Size = new Size(150, 30);  // Kích thước của Label
                lblWorkSchedule.Location = new Point((panelWorkSchedule.Width - lblWorkSchedule.Width) / 2, 10); // Căn giữa Label trong panel
                panelWorkSchedule.Controls.Add(lblWorkSchedule);  // Thêm Label vào panel

                // 2. Tạo DateTimePicker để chọn ngày
                DateTimePicker dateTimePicker = new DateTimePicker();
                dateTimePicker.Name = "dateTimePicker";
                dateTimePicker.Format = DateTimePickerFormat.Short;  // Định dạng hiển thị ngày tháng
                dateTimePicker.Location = new Point(20, 20);  // Vị trí của DateTimePicker
                panelWorkSchedule.Controls.Add(dateTimePicker);  // Thêm DateTimePicker vào panel


                // Thêm sự kiện ValueChanged cho DateTimePicker
                dateTimePicker.ValueChanged += (s, ev) =>
                {
                    // Xử lý khi người dùng thay đổi giá trị của DateTimePicker
                    MessageBox.Show("Ngày đã thay đổi: " + dateTimePicker.Value.ToShortDateString());
                    // Gọi lại phương thức để cập nhật lịch làm việc dựa trên ngày đã chọn
                    BindWorkScheduleToDataGridView((DataGridView)panelWorkSchedule.Controls["dataGridViewWorkSchedule"], dateTimePicker.Value);
                };

                // 3. Tạo DataGridView để hiển thị lịch làm việc
                DataGridView dataGridViewWorkSchedule = new DataGridView();
                dataGridViewWorkSchedule.Name = "dataGridViewWorkSchedule";
                dataGridViewWorkSchedule.Size = new Size(720, 280);  // Kích thước DataGridView
                dataGridViewWorkSchedule.Location = new Point(20, 60);  // Vị trí của DataGridView
                panelWorkSchedule.Controls.Add(dataGridViewWorkSchedule);  // Thêm DataGridView vào panel
                dataGridViewWorkSchedule.ReadOnly = true;

                // 4. Tạo Button Close ở góc phải trên panel
                Button btnClosePanel = new Button();
                btnClosePanel.Text = "X";  // Dùng chữ "X" để đóng panel
                btnClosePanel.Size = new Size(30, 30);  // Kích thước nút
                btnClosePanel.Location = new Point(panelWorkSchedule.Width - 40, 10);  // Đặt nút ở góc phải trên
                btnClosePanel.Click += (s, ev) =>
                {
                    panelWorkSchedule.Visible = false; // Ẩn panel
                    LoadDataNV();
                }; // Đóng panel khi nhấn nút
                panelWorkSchedule.Controls.Add(btnClosePanel);  // Thêm nút đóng vào panel

                Button btnCreateSchedule = new Button();
                btnCreateSchedule.Text = "Tạo Lịch Làm Việc";  // Nội dung của nút
                btnCreateSchedule.Size = new Size(150, 30);  // Kích thước nút
                btnCreateSchedule.Location = new Point(panelWorkSchedule.Width - 160, dataGridViewWorkSchedule.Bottom + 10); // Đặt nút dưới DataGridView và tạo khoảng cách 10px
                btnCreateSchedule.Click += (s, ev) =>
                {
                    var existingForm = Application.OpenForms["frmTaoLichLamViec"];

                    if (existingForm == null)
                    {
                        // Nếu form chưa mở, tạo mới và hiển thị form
                        frmTaoLichLamViec frm = new frmTaoLichLamViec();
                        frm.Owner = this;
                        frm.Show();
                    }
                    else
                    {
                        // Nếu form đã mở, chỉ cần đưa nó lên trên
                        existingForm.BringToFront();
                    }
                };
                panelWorkSchedule.Controls.Add(btnCreateSchedule);  // Thêm nút vào panel

                BindWorkScheduleToDataGridView(dataGridViewWorkSchedule, dateTimePicker.Value);
            }
            else
            {
                // Nếu panel đã tồn tại, chỉ cần hiển thị panel
                Panel existingPanel = (Panel)this.Controls["panelWorkSchedule"];
                existingPanel.Visible = !existingPanel.Visible;  // Chuyển đổi trạng thái hiển thị của panel
            }
        }


        private void BindLuongToDataGridView(DataGridView dataGridView, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            try
            {
                // Lấy dữ liệu từ phương thức tính lương theo mã nhân viên và khoảng thời gian
                List<dynamic> luong = bll.TinhLuongNhanVien(ngayBatDau, ngayKetThuc);

                // Sử dụng BindingList<dynamic> để bind dữ liệu
                BindingList<dynamic> bindingList = new BindingList<dynamic>(luong);

                // Gán vào DataGridView
                dataGridView.DataSource = bindingList;

                // Tùy chỉnh các cột nếu cần
                dataGridView.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dataGridView.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
                dataGridView.Columns["ChucVu"].HeaderText = "Chức Vụ";
                dataGridView.Columns["LuongCB"].HeaderText = "Lương Cơ Bản";
                dataGridView.Columns["HeSoLuong"].HeaderText = "Hệ Số Lương";
                dataGridView.Columns["SoCaLamViec"].HeaderText = "Số Ca Làm Việc";
                dataGridView.Columns["LuongTheoCa"].HeaderText = "Lương Theo Ca";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
        private void btnLuong_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem panel đã tồn tại chưa, nếu chưa thì tạo mới
            if (this.Controls["panelLuong"] == null)
            {
                // 1. Tạo Panel
                Panel panelLuong = new Panel();
                panelLuong.Name = "panelLuong";
                panelLuong.Size = new Size(780, 400);  // Kích thước của panel
                panelLuong.Location = new Point(20, 60);
                panelLuong.BackColor = Color.White;  // Màu nền của panel
                panelLuong.BorderStyle = BorderStyle.FixedSingle; // Tạo đường viền cho panel
                                                                  // Đảm bảo panel sẽ hiển thị lên trên form
                this.Controls.Add(panelLuong);  // Thêm panel vào form
                panelLuong.BringToFront();

                // 2. Tạo Label "TÍNH LƯƠNG"
                Label lblTinhLuong = new Label();
                lblTinhLuong.Text = "TÍNH LƯƠNG";
                lblTinhLuong.Font = new Font("Arial", 12, FontStyle.Bold); // Cỡ chữ và kiểu chữ in đậm
                lblTinhLuong.Size = new Size(150, 30);  // Kích thước của Label
                lblTinhLuong.Location = new Point((panelLuong.Width - lblTinhLuong.Width) / 2, 10); // Căn giữa Label trong panel
                panelLuong.Controls.Add(lblTinhLuong);  // Thêm Label vào panel

                // 3. Tạo Label "Ngày Bắt Đầu"
                Label lblNgayBatDau = new Label();
                lblNgayBatDau.Text = "Ngày Bắt Đầu:";
                lblNgayBatDau.Location = new Point(20, 50); // Vị trí của Label
                panelLuong.Controls.Add(lblNgayBatDau);  // Thêm Label vào panel

                // 4. Tạo DateTimePicker để chọn ngày bắt đầu
                DateTimePicker dateTimePickerBatDau = new DateTimePicker();
                dateTimePickerBatDau.Name = "dateTimePickerBatDau";
                dateTimePickerBatDau.Format = DateTimePickerFormat.Short;  // Định dạng hiển thị ngày tháng
                dateTimePickerBatDau.Location = new Point(120, 50);  // Vị trí của DateTimePicker
                dateTimePickerBatDau.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // Ngày đầu tháng hiện tại
                panelLuong.Controls.Add(dateTimePickerBatDau);  // Thêm DateTimePicker vào panel

                // 5. Tạo Label "Ngày Kết Thúc"
                Label lblNgayKetThuc = new Label();
                lblNgayKetThuc.Text = "Ngày Kết Thúc:";
                lblNgayKetThuc.Location = new Point(20, 90); // Vị trí của Label
                panelLuong.Controls.Add(lblNgayKetThuc);  // Thêm Label vào panel

                // 6. Tạo DateTimePicker để chọn ngày kết thúc
                DateTimePicker dateTimePickerKetThuc = new DateTimePicker();
                dateTimePickerKetThuc.Name = "dateTimePickerKetThuc";
                dateTimePickerKetThuc.Format = DateTimePickerFormat.Short;  // Định dạng hiển thị ngày tháng
                dateTimePickerKetThuc.Location = new Point(120, 90);  // Vị trí của DateTimePicker
                dateTimePickerKetThuc.Value = DateTime.Today; // Ngày kết thúc là ngày hiện tại
                                                              //  dateTimePickerKetThuc.MaxDate = DateTime.Today;
                panelLuong.Controls.Add(dateTimePickerKetThuc);  // Thêm DateTimePicker vào panel

                // 7. Tạo DataGridView để hiển thị kết quả tính lương
                DataGridView dataGridViewLuong = new DataGridView();
                dataGridViewLuong.Name = "dataGridViewLuong";
                dataGridViewLuong.Size = new Size(730, 250);  // Kích thước DataGridView
                dataGridViewLuong.Location = new Point(20, 130);  // Vị trí của DataGridView
                panelLuong.Controls.Add(dataGridViewLuong);  // Thêm DataGridView vào panel

                // 8. Tạo Button Close ở góc phải trên panel
                Button btnClosePanel = new Button();
                btnClosePanel.Text = "X";  // Dùng chữ "X" để đóng panel
                btnClosePanel.Size = new Size(30, 30);  // Kích thước nút
                btnClosePanel.Location = new Point(panelLuong.Width - 40, 10);  // Đặt nút ở góc phải trên
                btnClosePanel.Click += (s, ev) => panelLuong.Visible = false; // Đóng panel khi nhấn nút
                panelLuong.Controls.Add(btnClosePanel);  // Thêm nút đóng vào panel

                // 9. Gọi phương thức BindLuongToDataGridView để hiển thị kết quả tính lương
                DateTime ngayBatDau = dateTimePickerBatDau.Value;
                DateTime ngayKetThuc = dateTimePickerKetThuc.Value; // Ngày kết thúc là ngày chọ

                BindLuongToDataGridView(dataGridViewLuong, ngayBatDau, ngayKetThuc);

                // 10. Thêm sự kiện ValueChanged cho DateTimePicker
                dateTimePickerBatDau.ValueChanged += (s, ev) =>
                {
                    if (dateTimePickerBatDau.Value > dateTimePickerKetThuc.Value)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dateTimePickerBatDau.Value = dateTimePickerKetThuc.Value; // Đặt lại giá trị hợp lệ
                    }
                    else
                    {
                        BindLuongToDataGridView(dataGridViewLuong, dateTimePickerBatDau.Value, dateTimePickerKetThuc.Value);
                    }
                };
                dateTimePickerKetThuc.ValueChanged += (s, ev) =>
                {
                    if (dateTimePickerKetThuc.Value < dateTimePickerBatDau.Value)
                    {
                        MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dateTimePickerKetThuc.Value = dateTimePickerBatDau.Value; // Đặt lại giá trị hợp lệ
                    }
                    else
                    {
                        BindLuongToDataGridView(dataGridViewLuong, dateTimePickerBatDau.Value, dateTimePickerKetThuc.Value);
                    }
                };

            }
            else
            {
                // Nếu panel đã tồn tại, chỉ cần hiển thị panel
                Panel existingPanel = (Panel)this.Controls["panelLuong"];
                existingPanel.Visible = !existingPanel.Visible;  // Ch
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            txtCCCD.MaxLength = 12;
        }

        private bool isReset = false;
        private void txtNS_ValueChanged(object sender, EventArgs e)
        {
            if (isReset) return;
            DateTime selectedDate = txtNS.Value;
            DateTime currentDate = DateTime.Now;


            int age = currentDate.Year - selectedDate.Year;


            if (selectedDate > currentDate.AddYears(-age))
            {
                age--;
            }


            if (age < 18)
            {
                MessageBox.Show("Nhân viên phải trên 18 tuổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtNS.Value = currentDate.AddYears(-18);
            }
        }


    }
}

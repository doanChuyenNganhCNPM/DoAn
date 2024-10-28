using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Form
{
    public partial class frmQLLoaiTroChoi : Form
    {
        public frmQLLoaiTroChoi()
        {
            InitializeComponent();
            LoadLoaiTCData();
        }

        string connectionString = "Data Source=DESKTOP-A0G3GBK\\SQLEXPRESS;Initial Catalog=DoAn;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        private void frmQLLoaiTroChoi_Load(object sender, EventArgs e)
        {

        }
        private void LoadLoaiTCData()
        {
            string connectionString = "Data Source=DESKTOP-A0G3GBK\\SQLEXPRESS;Initial Catalog=DoAn;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM LoaiTC";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Assuming you have a DataGridView control named "dataGridViewLoaiTC"
                    dgvLoaiTroChoi.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvLoaiTroChoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiTroChoi.CurrentRow != null)
            {
                // Lấy thông tin từ dòng đã double-click
                var maLoai = dgvLoaiTroChoi.CurrentRow.Cells["MaLoai"].Value.ToString();
                var tenLoai = dgvLoaiTroChoi.CurrentRow.Cells["TenLoai"].Value.ToString();
                var gia = dgvLoaiTroChoi.CurrentRow.Cells["Gia"].Value.ToString();
                var ghiChu = dgvLoaiTroChoi.CurrentRow.Cells["GhiChu"].Value.ToString();

                // Gán giá trị vào các TextBox tương ứng
                txtMaLTC.Text = maLoai;
                txtTenLTC.Text = tenLoai;
                txtGia.Text = gia;
                txtMoTa.Text = ghiChu;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLTC.Text.Trim();
            string tenLoai = txtTenLTC.Text.Trim();
            string gia = txtGia.Text.Trim();
            string ghiChu = txtMoTa.Text.Trim();

            // Kiểm tra xem các trường không được để trống
            if (string.IsNullOrEmpty(maLoai) || string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Mã loại và tên loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dữ liệu vào cơ sở dữ liệu (giả sử bạn đã có phương thức thêm)
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO LoaiTC (MaLoai, TenLoai, Gia, GhiChu) VALUES (@MaLoai, @TenLoai, @Gia, @GhiChu)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoai", maLoai);
                        command.Parameters.AddWithValue("@TenLoai", tenLoai);
                        command.Parameters.AddWithValue("@Gia", float.Parse(gia));
                        command.Parameters.AddWithValue("@GhiChu", ghiChu);

                        command.ExecuteNonQuery();
                    }
                }

                // Cập nhật DataGridView (nếu cần)
                LoadLoaiTCData(); // Gọi lại phương thức tải dữ liệu để cập nhật
                MessageBox.Show("Thêm loại trò chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa TextBox sau khi thêm
                txtMaLTC.Clear();
                txtTenLTC.Clear();
                txtGia.Clear();
                txtMoTa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string maLoai = txtMaLTC.Text.Trim();
            string tenLoai = txtTenLTC.Text.Trim();
            string gia = txtGia.Text.Trim();
            string ghiChu = txtMoTa.Text.Trim();

            // Kiểm tra xem mã loại không được để trống
            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Mã loại không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật dữ liệu vào cơ sở dữ liệu
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE LoaiTC SET TenLoai = @TenLoai, Gia = @Gia, GhiChu = @GhiChu WHERE MaLoai = @MaLoai";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoai", maLoai);
                        command.Parameters.AddWithValue("@TenLoai", tenLoai);
                        command.Parameters.AddWithValue("@Gia", float.Parse(gia));
                        command.Parameters.AddWithValue("@GhiChu", ghiChu);

                        command.ExecuteNonQuery();
                    }
                }

                // Cập nhật DataGridView (nếu cần)
                LoadLoaiTCData(); // Gọi lại phương thức tải dữ liệu để cập nhật
                MessageBox.Show("Cập nhật loại trò chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa TextBox sau khi cập nhật
                txtMaLTC.Clear();
                txtTenLTC.Clear();
                txtGia.Clear();
                txtMoTa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLoai = txtMaLTC.Text.Trim();

            // Kiểm tra nếu mã loại trống
            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Vui lòng chọn loại trò chơi cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa loại trò chơi này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // Thực hiện xóa khỏi cơ sở dữ liệu
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM LoaiTC WHERE MaLoai = @MaLoai";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaLoai", maLoai);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa loại trò chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Cập nhật DataGridView
                            LoadLoaiTCData(); // Gọi lại phương thức tải dữ liệu để cập nhật hiển thị

                            // Xóa nội dung TextBox
                            txtMaLTC.Clear();
                            txtTenLTC.Clear();
                            txtGia.Clear();
                            txtMoTa.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy loại trò chơi để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaLTC.Clear();
            txtTenLTC.Clear();
            txtGia.Clear();
            txtMoTa.Clear();
            txtTimkiem.Clear();
            rdoMaLoai.Checked = false;
            rdoTenLoai.Checked = false;
            LoadLoaiTCData();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // Từ khóa tìm kiếm từ TextBox
            string keyword = txtTimkiem.Text.Trim();

            // Kiểm tra xem người dùng chọn tìm kiếm theo Mã Loại hay Tên Loại
            string query = "";
            if (rdoMaLoai.Checked)
            {
                // Tìm kiếm theo Mã Loại
                query = "SELECT * FROM LoaiTC WHERE MaLoai LIKE @keyword";
            }
            else if (rdoTenLoai.Checked)
            {
                // Tìm kiếm theo Tên Loại
                query = "SELECT * FROM LoaiTC WHERE TenLoai LIKE @keyword";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm (Mã Loại hoặc Tên Loại).", "Thông báo");
                return;
            }

            // Kết nối tới SQL Server và thực thi câu truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm từ khóa tìm kiếm với ký tự '%' để tìm kiếm chuỗi tương tự
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Hiển thị kết quả lên DataGridView
                    dgvLoaiTroChoi.DataSource = table;
                }
            }
        }
    }
}

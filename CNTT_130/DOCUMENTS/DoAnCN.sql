CREATE DATABASE DoAn

USE DoAn
GO

CREATE TABLE [Ve] (
  [MaVe] varchar(10) PRIMARY KEY,
  [LoaiVe] varchar(10) DEFAULT (null),
  [ThoiGianBan] date,
  [ThoiGianBatDau] date,
  [ThoiGianHetHan] date,
  [SoLuong] int DEFAULT (1),
  [TinhTrang] nvarchar(30),
  [SoNguoiLon] int DEFAULT (1),
  [SoTreEm] int DEFAULT (1),
  [TroChoi] varchar(10) DEFAULT (null)
)
GO

CREATE TABLE [LoaiVe] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(30),
  [GiaTien] float DEFAULT (0)
)
GO

CREATE TABLE [NhanVien] (
  [MaNV] varchar(10) PRIMARY KEY,
  [TenNV] nvarchar(50),
  [GioiTinh] nvarchar(5),
  [NgaySinh] date,
  [CCCD] varchar(12),
  [LoaiNV] varchar(10) DEFAULT (null)
)
GO

CREATE TABLE [LoaiNV] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [ChucVu] nvarchar(50),
  [HeSoLuong] float,
  [LuongCB] float
)
GO

CREATE TABLE [TroChoi] (
  [MaTC] varchar(10) PRIMARY KEY,
  [TenTC] nvarchar(50),
  [DiaDiem] nvarchar(50),
  [LoaiTroChoi] varchar(10) DEFAULT (null),
  [NgayBatDau] date,
  [NgayKetThuc] date,
  [TinhTrang] nvarchar(50)
)
GO

CREATE TABLE [LoaiTC] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(50),
  [Gia] float,
  [GioiHanDoTuoi] int DEFAULT (0),
  [GhiChu] nvarchar(50)
)
GO

CREATE TABLE [LichLamViec] (
  [MaLich] varchar(10) PRIMARY KEY,
  [NgayLam] date,
  [Thu] nvarchar(10),
  [Ca] int,
  [ThoiGianLam] nvarchar(30)
)
GO

CREATE TABLE [TKB] (
  [MaLich] varchar(10) PRIMARY KEY,
  [MaNV] varchar(10),
  [ChamCong] int DEFAULT (0)
)
GO

CREATE TABLE [ThucPham] (
  [MaTP] varchar(10) PRIMARY KEY,
  [TenTP] nvarchar(50),
  [MoTa] nvarchar(50),
  [GiaBan] float DEFAULT (0),
  [SoLuong] int DEFAULT (0),
  [TinhTrang] nvarchar(30)
)
GO

CREATE TABLE [HoaDon] (
  [MaHD] varchar(10) PRIMARY KEY,
  [MaKH] varchar(10) DEFAULT (null),
  [MaKM] varchar(10) DEFAULT (null),
  [NgayIn] date,
  [TongTien] float DEFAULT (0)
)
GO

CREATE TABLE [HoaDon_Ve] (
  [MaCTHD] varchar(10),
  [MaHD] varchar(10),
  [MaNV] varchar(10),
  [MaVe] varchar(10),
  [SoLuongVe] int DEFAULT (1),
  [TinhTrang] nvarchar(30),
  [ThanhTien] float,
  PRIMARY KEY ([MaCTHD])
)
GO

CREATE TABLE [Ve_TP] (
  [MaCTHD] varchar(10),
  [MaTP] varchar(10),
  [SoLuong] int DEFAULT (1),
  [DonGia] float,
  [ThanhTien] float,
  PRIMARY KEY ([MaCTHD], [MaTP])
)
GO

CREATE TABLE [TaiKhoan] (
  [Username] varchar(10),
  [Password] varchar(10),
  [MaNV] varchar(10),
  [Role] varchar(10),
  PRIMARY KEY ([Username], [Password])
)
GO

CREATE TABLE [KhachHang] (
  [MaKH] varchar(10) PRIMARY KEY,
  [HoTen] nvarchar(50),
  [NgaySinh] date,
  [CCCD] varchar(12),
  [LoaiKH] varchar(10)
)
GO

CREATE TABLE [LoaiKH] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(50),
  [SoTienCanThangLoai] float
)
GO

CREATE TABLE [KhuyenMai] (
  [MaKM] varchar(10) PRIMARY KEY,
  [TenKM] nvarchar(100),
  [NgayBatDau] date DEFAULT (null),
  [NgayKetThuc] date DEFAULT (null),
  [PhanTramGiam] float,
  [TinhTrang] nvarchar(20),
  [MoTa] nvarchar(50)
)
GO

CREATE TABLE [HoaDon_ThucPham] (
  [MaHD] varchar(10),
  [MaTP] varchar(10),
  [SoLuong] int DEFAULT (0),
  [ThanhTien] float DEFAULT (0),
  [TinhTrang] nvarchar(30),
  PRIMARY KEY ([MaHD], [MaTP])
)
GO

ALTER TABLE [TaiKhoan] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [Ve] ADD FOREIGN KEY ([LoaiVe]) REFERENCES [LoaiVe] ([MaLoai])
GO

ALTER TABLE [NhanVien] ADD FOREIGN KEY ([LoaiNV]) REFERENCES [LoaiNV] ([MaLoai])
GO

ALTER TABLE [TroChoi] ADD FOREIGN KEY ([LoaiTroChoi]) REFERENCES [LoaiTC] ([MaLoai])
GO

ALTER TABLE [TKB] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [TKB] ADD FOREIGN KEY ([MaLich]) REFERENCES [LichLamViec] ([MaLich])
GO

ALTER TABLE [HoaDon_Ve] ADD FOREIGN KEY ([MaHD]) REFERENCES [HoaDon] ([MaHD])
GO

ALTER TABLE [HoaDon] ADD FOREIGN KEY ([MaKH]) REFERENCES [KhachHang] ([MaKH])
GO

ALTER TABLE [KhachHang] ADD FOREIGN KEY ([LoaiKH]) REFERENCES [LoaiKH] ([MaLoai])
GO

ALTER TABLE [HoaDon] ADD FOREIGN KEY ([MaKM]) REFERENCES [KhuyenMai] ([MaKM])
GO

ALTER TABLE [HoaDon_ThucPham] ADD FOREIGN KEY ([MaHD]) REFERENCES [HoaDon] ([MaHD])
GO

ALTER TABLE [HoaDon_ThucPham] ADD FOREIGN KEY ([MaTP]) REFERENCES [ThucPham] ([MaTP])
GO

ALTER TABLE [HoaDon_Ve] ADD FOREIGN KEY ([MaVe]) REFERENCES [Ve] ([MaVe])
GO

ALTER TABLE [HoaDon_Ve] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [Ve_TP] ADD FOREIGN KEY ([MaCTHD]) REFERENCES [HoaDon_Ve] ([MaCTHD])
GO

ALTER TABLE [Ve_TP] ADD FOREIGN KEY ([MaTP]) REFERENCES [ThucPham] ([MaTP])
GO

ALTER TABLE [Ve] ADD FOREIGN KEY ([TroChoi]) REFERENCES [TroChoi] ([MaTC])
GO


-- Bảng LoaiVe
INSERT INTO LoaiVe (MaLoai, TenLoai, GiaTien) VALUES
('LV01', 'Vé vào cổng', 100000),
('LV02', 'Vé trò chơi', 50000);

-- Bảng LoaiNV
INSERT INTO LoaiNV (MaLoai, ChucVu, HeSoLuong, LuongCB) VALUES
('LN01', 'Nhân viên', 1.5, 5000000),
('LN02', 'Quản lý', 2.0, 8000000),
('LN03', 'Giám đốc', 3.0, 15000000),
('LN04', 'Thực tập sinh', 1.0, 3000000),
('LN05', 'Bảo vệ', 1.2, 4000000);

-- Bảng NhanVien
INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, CCCD, LoaiNV) VALUES
('NV01', 'Nguyen Van A', 'Nam', '1990-05-10', '012345678901', 'LN01'),
('NV02', 'Le Thi B', 'Nữ', '1992-06-15', '012345678902', 'LN02'),
('NV03', 'Tran Van C', 'Nam', '1985-09-20', '012345678903', 'LN01'),
('NV04', 'Pham Thi D', 'Nữ', '1991-12-25', '012345678904', 'LN02'),
('NV05', 'Hoang Van E', 'Nam', '1993-03-30', '012345678905', 'LN01');

-- Bảng LoaiTC
INSERT INTO LoaiTC (MaLoai, TenLoai, Gia, GioiHanDoTuoi, GhiChu) VALUES
('LTC01', 'Xoay vòng', 20000, 12, 'Vui chơi nhẹ nhàng'),
('LTC02', 'Mạo hiểm', 50000, 18, 'Yêu cầu sức khỏe tốt'),
('LTC03', 'Bắn cung', 30000, 16, 'Tập trung cao độ'),
('LTC04', 'Xe lửa', 40000, 10, 'Thích hợp cho gia đình'),
('LTC05', 'Cầu trượt', 15000, 6, 'Trẻ em yêu thích');

-- Bảng TroChoi
INSERT INTO TroChoi (MaTC, TenTC, DiaDiem, LoaiTroChoi, NgayBatDau, NgayKetThuc, TinhTrang) VALUES
('TC01', 'Trò chơi Xoay vòng', 'Khu vực A', 'LTC01', '2024-01-01', '2024-12-31', 'Hoạt động'),
('TC02', 'Trò chơi Mạo hiểm', 'Khu vực B', 'LTC02', '2024-02-01', '2024-11-30', 'Bảo trì'),
('TC03', 'Trò chơi Bắn cung', 'Khu vực C', 'LTC03', '2024-03-01', '2024-12-31', 'Hoạt động'),
('TC04', 'Trò chơi Xe lửa', 'Khu vực D', 'LTC04', '2024-01-01', '2024-12-31', 'Hoạt động'),
('TC05', 'Trò chơi Cầu trượt', 'Khu vực E', 'LTC05', '2024-04-01', '2024-12-31', 'Bảo trì');

-- Bảng LichLamViec
INSERT INTO LichLamViec (MaLich, NgayLam, Thu, Ca, ThoiGianLam) VALUES
('LLV01', '2024-11-01', 'Thứ Hai', 1, '08:00-12:00'),
('LLV02', '2024-11-01', 'Thứ Hai', 2, '13:00-17:00'),
('LLV03', '2024-11-02', 'Thứ Ba', 1, '08:00-12:00'),
('LLV04', '2024-11-02', 'Thứ Ba', 2, '13:00-17:00'),
('LLV05', '2024-11-03', 'Thứ Tư', 1, '08:00-12:00');

-- Bảng TKB
INSERT INTO TKB (MaLich, MaNV, ChamCong) VALUES
('LLV01', 'NV01', 1),
('LLV02', 'NV02', 1),
('LLV03', 'NV03', 1),
('LLV04', 'NV04', 0),
('LLV05', 'NV05', 1);

-- Bảng ThucPham
INSERT INTO ThucPham (MaTP, TenTP, MoTa, GiaBan, SoLuong, TinhTrang) VALUES
('TP01', 'Bánh mì', 'Bánh mì kẹp thịt', 15000, 100, 'Còn hàng'),
('TP02', 'Nước ngọt', 'Nước ngọt có ga', 10000, 200, 'Còn hàng'),
('TP03', 'Bánh quy', 'Bánh quy bơ', 25000, 150, 'Còn hàng'),
('TP04', 'Kẹo', 'Kẹo socola', 5000, 300, 'Còn hàng'),
('TP05', 'Trái cây', 'Trái cây tươi', 30000, 50, 'Hết hàng');

-- Bảng LoaiKH
INSERT INTO LoaiKH (MaLoai, TenLoai, SoTienCanThangLoai) VALUES
('LKH01', 'Khách hàng thường', 500000),
('LKH02', 'Khách hàng VIP', 1000000),
('LKH03', 'Khách hàng siêu VIP', 2000000),
('LKH04', 'Khách hàng mới', 0),
('LKH05', 'Khách hàng trung thành', 1500000);

-- Bảng KhachHang
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, CCCD, LoaiKH) VALUES
('KH01', 'Nguyen Thi A', '1980-05-10', '123456789012', 'LKH01'),
('KH02', 'Tran Van B', '1990-06-20', '123456789013', 'LKH02'),
('KH03', 'Le Thi C', '2000-07-30', '123456789014', 'LKH01'),
('KH04', 'Pham Van D', '1985-08-25', '123456789015', 'LKH03'),
('KH05', 'Hoang Thi E', '1995-09-15', '123456789016', 'LKH02');

-- Bảng KhuyenMai
INSERT INTO KhuyenMai (MaKM, TenKM, NgayBatDau, NgayKetThuc, PhanTramGiam, TinhTrang, MoTa) VALUES
('KM01', 'Giảm giá mùa hè', '2024-06-01', '2024-08-31', 10, 'Đang áp dụng', 'Giảm giá 10% cho tất cả dịch vụ'),
('KM02', 'Khuyến mãi Tết', '2024-01-20', '2024-02-10', 20, 'Hết hạn', 'Giảm giá 20% cho vé Tết'),
('KM03', 'Black Friday', '2024-11-25', '2024-11-30', 50, 'Đang áp dụng', 'Giảm giá 50% cho tất cả mặt hàng'),
('KM04', 'Giảm giá mùa thu', '2024-09-01', '2024-11-30', 15, 'Đang áp dụng', 'Giảm giá 15% cho trò chơi và thực phẩm'),
('KM05', 'Khuyến mãi Giáng sinh', '2024-12-20', '2024-12-31', 25, 'Sắp diễn ra', 'Giảm giá 25% cho các dịch vụ trong dịp Giáng sinh');

-- Bảng HoaDon
INSERT INTO HoaDon (MaHD, MaKH, MaKM, NgayIn, TongTien) VALUES
('HD01', 'KH01', 'KM01', '2024-11-01', 150000),
('HD02', 'KH02', 'KM02', '2024-11-01', 200000),
('HD03', 'KH03', 'KM03', '2024-11-02', 100000),
('HD04', 'KH04', NULL, '2024-11-02', 300000),
('HD05', 'KH05', 'KM04', '2024-11-03', 400000);

-- Bảng Ve
INSERT INTO Ve (MaVe, LoaiVe, ThoiGianBan, ThoiGianBatDau, ThoiGianHetHan, SoLuong, TinhTrang, SoNguoiLon, SoTreEm, TroChoi) VALUES
('VE01', 'LV01', '2024-11-01', '2024-11-01', '2024-11-01', 1, 'Mới', 2, 1, NULL),
('VE02', 'LV01', '2024-10-15', '2024-10-15', '2024-11-15', 1, 'Đã sử dụng', 1, 0, NULL),
('VE03', 'LV02', '2024-09-10', '2024-09-10', '2025-09-10', 1, 'Hết hạn', 2, 2, 'TC01'),
('VE04', 'LV02', '2024-10-01', '2024-10-01', '2024-12-31', 1, 'Đã sử dụng', 3, 1, 'TC02'),
('VE05', 'LV02', '2024-08-01', '2024-08-01', '2024-08-30', 1, 'Hết hạn', 1, 1, 'TC03');

-- Bảng HoaDon_Ve
INSERT INTO HoaDon_Ve (MaCTHD, MaHD, MaNV, MaVe, SoLuongVe, TinhTrang, ThanhTien) VALUES
('CTHD01', 'HD01', 'NV01', 'VE01', 2, 'Đã thanh toán', 200000),
('CTHD02', 'HD02', 'NV02', 'VE02', 1, 'Chưa thanh toán', 100000),
('CTHD03', 'HD03', 'NV03', 'VE03', 4, 'Đã thanh toán', 400000),
('CTHD04', 'HD04', 'NV04', 'VE04', 1, 'Đã thanh toán', 500000),
('CTHD05', 'HD05', 'NV05', 'VE05', 3, 'Chưa thanh toán', 240000);

-- Bảng Ve_TP
INSERT INTO Ve_TP (MaCTHD, MaTP, SoLuong, DonGia, ThanhTien) VALUES
('CTHD01', 'TP01', 3, 15000, 45000),
('CTHD02', 'TP02', 2, 10000, 20000),
('CTHD03', 'TP03', 1, 25000, 25000),
('CTHD04', 'TP04', 5, 5000, 25000),
('CTHD05', 'TP05', 4, 30000, 120000);

-- Bảng HoaDon_ThucPham
INSERT INTO HoaDon_ThucPham (MaHD, MaTP, SoLuong, ThanhTien, TinhTrang) VALUES
('HD01', 'TP01', 3, 45000, 'Đã thanh toán'),
('HD02', 'TP02', 2, 20000, 'Chưa thanh toán'),
('HD03', 'TP03', 1, 25000, 'Đã thanh toán'),
('HD04', 'TP04', 5, 25000, 'Chưa thanh toán'),
('HD05', 'TP05', 4, 120000, 'Đã thanh toán');

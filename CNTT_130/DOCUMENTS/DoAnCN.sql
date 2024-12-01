CREATE DATABASE DoAn

USE DoAn
GO

-- Bảng Vé
CREATE TABLE [Ve] (
  [MaVe] varchar(10) PRIMARY KEY,
  [LoaiVe] varchar(10),
  [ThoiGianBan] date,
  [SoLuong] int DEFAULT 1,
  [TinhTrang] nvarchar(30),
  [TroChoi] varchar(10)
)
GO

-- Bảng Loại Vé
CREATE TABLE [LoaiVe] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(30),
  [GiaTien] float DEFAULT 0
)
GO

-- Bảng Nhân Viên
CREATE TABLE [NhanVien] (
  [MaNV] varchar(10) PRIMARY KEY,
  [TenNV] nvarchar(50),
  [GioiTinh] nvarchar(5),
  [NgaySinh] date,
  [CCCD] varchar(12),
  [LoaiNV] varchar(10)
)
GO

-- Bảng Loại Nhân Viên
CREATE TABLE [LoaiNV] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [ChucVu] nvarchar(50),
  [HeSoLuong] float,
  [LuongCB] float
)
GO

-- Bảng Trò Chơi
CREATE TABLE [TroChoi] (
  [MaTC] varchar(10) PRIMARY KEY,
  [TenTC] nvarchar(50),
  [DiaDiem] nvarchar(50),
  [LoaiTroChoi] varchar(10),
  [NgayBatDau] date,
  [NgayKetThuc] date,
  [TinhTrang] nvarchar(50)
)
GO

-- Bảng Loại Trò Chơi
CREATE TABLE [LoaiTC] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(50),
  [Gia] float,
  [GhiChu] nvarchar(50)
)
GO

-- Bảng Lịch Làm Việc
CREATE TABLE [LichLamViec] (
  [MaLich] varchar(10) PRIMARY KEY,
  [Ca] int,
  [ThoiGianLam] nvarchar(30)
)
GO

-- Bảng Thời Khóa Biểu
CREATE TABLE [TKB] (
  [MaLich] varchar(10),
  [MaNV] varchar(10),
  [NgayLam] date,
  [ChamCong] int DEFAULT 0,
  PRIMARY KEY ([MaLich], [MaNV],[NgayLam])
)
GO

-- Bảng Thực Phẩm
CREATE TABLE [ThucPham] (
  [MaTP] varchar(10) PRIMARY KEY,
  [TenTP] nvarchar(50),
  [MoTa] nvarchar(50),
  [GiaBan] float DEFAULT 0,
  [DVT] nvarchar(15),
  [SoLuong] int DEFAULT 0,
  [MaLoai] varchar(10),
  [TinhTrang] nvarchar(30)
)
GO
--Bảng Loại Thực Phẩm
CREATE TABLE [LoaiTP] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(50),
)
GO

-- Bảng Hóa Đơn
CREATE TABLE [HoaDon] (
  [MaHD] varchar(10) PRIMARY KEY,
  [MaKH] varchar(10),
  [MaKM] varchar(10),
  [NgayIn] date,
  [TongTien] float DEFAULT 0
)
GO

-- Bảng Chi Tiết Hóa Đơn Vé
CREATE TABLE [CTHD_Ve] (
  [MaCTHD] varchar(10) PRIMARY KEY,
  [MaHD] varchar(10),
  [MaNV] varchar(10),
  [MaVe] varchar(10),
  [SoNguoiLon] int DEFAULT 1,
  [SoTreEm] int DEFAULT 1,
  [TinhTrang] nvarchar(30),
  [ThanhTien] float
)
GO

-- Bảng Vé Thực Phẩm
CREATE TABLE [Ve_TP] (
  [MaCTHD] varchar(10),
  [MaTP] varchar(10),
  [SoLuong] int DEFAULT 1,
  [DonGia] float,
  [ThanhTien] float,
  PRIMARY KEY ([MaCTHD], [MaTP])
)
GO

-- Bảng Tài Khoản
CREATE TABLE [TaiKhoan] (
  [Username] varchar(10),
  [Password] varchar(10),
  [MaNV] varchar(10),
  [Role] varchar(10),
  PRIMARY KEY ([Username], [Password])
)
GO

-- Bảng Khách Hàng
CREATE TABLE [KhachHang] (
  [MaKH] varchar(10) PRIMARY KEY,
  [HoTen] nvarchar(50),
  [NgaySinh] date,
  [SDT] varchar(15),
  [Diem] int,
  [LoaiKH] varchar(10)
)
GO
ALTER TABLE [KhachHang]
ADD [SoTreEm] int DEFAULT 1 NOT NULL;
-- Bảng Loại Khách Hàng
CREATE TABLE [LoaiKH] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(50),
  [SoDiemCanThangLoai] int
)
GO

-- Bảng Khuyến Mãi
CREATE TABLE [KhuyenMai] (
  [MaKM] varchar(10) PRIMARY KEY,
  [TenKM] nvarchar(100),
  [NgayBatDau] date,
  [NgayKetThuc] date,
  [PhanTramGiam] float,
  [TinhTrang] nvarchar(20),
  [MoTa] nvarchar(100)
)
GO

--Bảng Thiết Bị
CREATE TABLE [ThietBi] (
  [MaTB] varchar(10) PRIMARY KEY,
  [TenTB] nvarchar(50),
  [MoTa] nvarchar(50),
  [GiaBan] float DEFAULT 0,
  [SoLuong] int DEFAULT 0
)
-- Bảng Chi tiết trò chơi
CREATE TABLE [CT_TroChoi](
  [MaTC] varchar(10),
  [MaTB] varchar(10),
  [SoLuong] int,
  PRIMARY KEY ([MaTC], [MaTB]),
  FOREIGN KEY ([MaTC]) REFERENCES [TroChoi] ([MaTC]) ON DELETE CASCADE,
  FOREIGN KEY ([MaTB]) REFERENCES [ThietBi] ([MaTB]) ON DELETE CASCADE
)

-- Bảng Chi tiết hóa đơn Thực Phẩm
CREATE TABLE [CTHD_TP] (
  [MaHD] varchar(10),
  [MaTP] varchar(10),
  [SoLuong] int DEFAULT 0,
  [ThanhTien] float DEFAULT 0,
  [TinhTrang] nvarchar(30),
  PRIMARY KEY ([MaHD], [MaTP])
)
GO

--- Bảng nhà cung cấp
CREATE TABLE [NhaCungCap] (
  [MaNCC] varchar(10) PRIMARY KEY,
  [TenNCC] nvarchar(50),
  [DiaChi] nvarchar(100),
  [SoDienThoai] varchar(15),
  [Email] nvarchar(50),
  [TinhTrang] nvarchar(30),
  [LoaiNCC] int, -- 1 nếu là trò chơi, 2 là thực phẩm
)
GO

--Bảng Phiếu nhập
CREATE TABLE [PhieuNhap] (
  [MaPhieu] varchar(10) PRIMARY KEY,
  [MaNCC] varchar(10),
  [MaNV] varchar(10),
  [NgayNhap] date,
  [TongTien] float DEFAULT (0),
  [GhiChu] nvarchar(100),
  FOREIGN KEY ([MaNCC]) REFERENCES [NhaCungCap] ([MaNCC]) ON DELETE CASCADE,
  FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
)
GO

--Bảng danh sách sản phẩm
CREATE TABLE [NhaCungCap_DanhSachSP] (
  [MaNCC] varchar(10),
  [MaSP] varchar(10),
  [TenSP] nvarchar(50) UNIQUE,
  [GiaBan] float,
  PRIMARY KEY (MaNCC, MaSP),
  FOREIGN KEY ([MaNCC]) REFERENCES [NhaCungCap] ([MaNCC]) ON DELETE CASCADE
)
GO

--Bảng chi tiết phiếu nhập thiết bị
CREATE TABLE [CTPN_TB] (
	[MaPhieu] varchar(10),
	[MaTB] varchar(10),
	[TenTB] nvarchar(50),
	[SoLuong] int,
	[GiaNhap] float,
	[ThanhTien] float,
	PRIMARY KEY (MaPhieu, MaTB),
	FOREIGN KEY (MaPhieu) REFERENCES [PhieuNhap] ([MaPhieu]) ON DELETE CASCADE,
)
GO

--Bảng chi tiết phiếu nhập thực phẩm
CREATE TABLE [CTPN_TP] (
	[MaPhieu] varchar(10),
	[MaTP] varchar(10),
	[TenTP] nvarchar(50),
	[DVT] nvarchar(15),
	[SoLuong] int,
	[GiaNhap] float,
	[ThanhTien] float,
	PRIMARY KEY (MaPhieu, MaTP),
	FOREIGN KEY (MaPhieu) REFERENCES [PhieuNhap] ([MaPhieu]) ON DELETE CASCADE,
)
GO

CREATE TABLE [VaiTro](
	[MaVaiTro] varchar(10) PRIMARY KEY,
	[TenVaiTro] nvarchar(50)
)

CREATE TABLE [ManHinh](
	[MaMH] varchar(10) PRIMARY KEY,
	[TenMH] nvarchar(100)
)

CREATE TABLE [PhanQuyen](
	[MaVaiTro] varchar(10),
	[MaMH] varchar(10),
	[HoatDong] int, -- Hoạt động là 1, Không hoạt động là 0
	PRIMARY KEY ([MaVaiTro], [MaMH])
)

ALTER TABLE [TaiKhoan] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]);
ALTER TABLE [Ve] ADD FOREIGN KEY ([LoaiVe]) REFERENCES [LoaiVe] ([MaLoai]);
ALTER TABLE [NhanVien] ADD FOREIGN KEY ([LoaiNV]) REFERENCES [LoaiNV] ([MaLoai]);
ALTER TABLE [TroChoi] ADD FOREIGN KEY ([LoaiTroChoi]) REFERENCES [LoaiTC] ([MaLoai]);
ALTER TABLE [ThucPham] ADD FOREIGN KEY ([MaLoai]) REFERENCES [LoaiTP] ([MaLoai]);
ALTER TABLE [TKB] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]);
ALTER TABLE [TKB] ADD FOREIGN KEY ([MaLich]) REFERENCES [LichLamViec] ([MaLich]);
ALTER TABLE [CTHD_Ve] ADD FOREIGN KEY ([MaHD]) REFERENCES [HoaDon] ([MaHD]);
ALTER TABLE [HoaDon] ADD FOREIGN KEY ([MaKH]) REFERENCES [KhachHang] ([MaKH]);
ALTER TABLE [KhachHang] ADD FOREIGN KEY ([LoaiKH]) REFERENCES [LoaiKH] ([MaLoai]);
ALTER TABLE [HoaDon] ADD FOREIGN KEY ([MaKM]) REFERENCES [KhuyenMai] ([MaKM]);
ALTER TABLE [CTHD_TP] ADD FOREIGN KEY ([MaHD]) REFERENCES [HoaDon] ([MaHD]);
ALTER TABLE [CTHD_TP] ADD FOREIGN KEY ([MaTP]) REFERENCES [ThucPham] ([MaTP]);
ALTER TABLE [CTHD_Ve] ADD FOREIGN KEY ([MaVe]) REFERENCES [Ve] ([MaVe]);
ALTER TABLE [CTHD_Ve] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV]);
ALTER TABLE [Ve_TP] ADD FOREIGN KEY ([MaCTHD]) REFERENCES [CTHD_Ve] ([MaCTHD]);
ALTER TABLE [Ve_TP] ADD FOREIGN KEY ([MaTP]) REFERENCES [ThucPham] ([MaTP]);
ALTER TABLE [Ve] ADD FOREIGN KEY ([TroChoi]) REFERENCES [TroChoi] ([MaTC]);
ALTER TABLE [PhanQuyen] ADD CONSTRAINT [fk_PhanQuyen_VaiTro] FOREIGN KEY ([MaVaiTro]) REFERENCES [VaiTro] ([MaVaiTro]);
ALTER TABLE [PhanQuyen] ADD CONSTRAINT [fk_PhanQuyen_ManHinh] FOREIGN KEY ([MaMH]) REFERENCES [ManHinh] ([MaMH]);
ALTER TABLE [TaiKhoan] ADD FOREIGN KEY ([Role]) REFERENCES [VaiTro] ([MaVaiTro]);
GO


-- Bảng LoaiVe
INSERT INTO LoaiVe (MaLoai, TenLoai, GiaTien) VALUES
('LV001', N'Vé vào cổng', 100000),
('LV002', N'Vé trò chơi', 50000);

-- Bảng LoaiNV
INSERT INTO LoaiNV (MaLoai, ChucVu, HeSoLuong, LuongCB) VALUES
('LN001', N'Nhân viên', 1.5, 5000000),
('LN002', N'Quản lý', 2.0, 8000000),
('LN003', N'Giám đốc', 3.0, 15000000),
('LN004', N'Thực tập sinh', 1.0, 3000000),
('LN005', N'Bảo vệ', 1.2, 4000000);

-- Bảng NhanVien
INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, CCCD, LoaiNV) VALUES
('NV001', N'Nguyen Van A', N'Nam', '1990-05-10', '012345678901', 'LN001'),
('NV002', N'Le Thi B', N'Nữ', '1992-06-15', '012345678902', 'LN002'),
('NV003', N'Tran Van C', N'Nam', '1985-09-20', '012345678903', 'LN001'),
('NV004', N'Pham Thi D', N'Nữ', '1991-12-25', '012345678904', 'LN002'),
('NV005', N'Hoang Van E', N'Nam', '1993-03-30', '012345678905', 'LN001'),
('NV006', N'Trần Thành Nam', N'Nam', '1993-03-30', '012345678905', 'LN003');

-- Bảng LoaiTC
INSERT INTO LoaiTC (MaLoai, TenLoai, Gia, GhiChu) VALUES
('LTC01', N'Xoay vòng', 20000, N'Vui chơi nhẹ nhàng'),
('LTC02', N'Mạo hiểm', 50000, N'Yêu cầu sức khỏe tốt'),
('LTC03', N'Bắn cung', 30000, N'Tập trung cao độ'),
('LTC04', N'Xe lửa', 40000, N'Thích hợp cho gia đình'),
('LTC05', N'Cầu trượt', 15000, N'Trẻ em yêu thích');

ALTER TABLE [LoaiTC]
DROP COLUMN [Gia];

-- Bảng TroChoi
INSERT INTO TroChoi (MaTC, TenTC, DiaDiem, LoaiTroChoi, NgayBatDau, NgayKetThuc, TinhTrang) VALUES
('TC001', N'Trò chơi Xoay vòng', N'Khu vực A', 'LTC01', '2024-01-01', '2024-12-31', N'Hoạt động'),
('TC002', N'Trò chơi Mạo hiểm', N'Khu vực B', 'LTC02', '2024-02-01', '2024-11-30', N'Bảo trì'),
('TC003', N'Trò chơi Bắn cung', N'Khu vực C', 'LTC03', '2024-03-01', '2024-12-31', N'Hoạt động'),
('TC004', N'Trò chơi Xe lửa', N'Khu vực D', 'LTC04', '2024-01-01', '2024-12-31', N'Hoạt động'),
('TC005', N'Trò chơi Cầu trượt', N'Khu vực E', 'LTC05', '2024-04-01', '2024-12-31', N'Bảo trì');

INSERT INTO ThietBi (MaTB, TenTB, MoTa, GiaBan, SoLuong) VALUES
('TB001', N'Khung sắt', N'Khung sắt để dựng các trò chơi', 500000, 10),
('TB002', N'Bóng nhún', N'Bóng nhún lớn để chơi nhảy', 300000, 15),
('TB003', N'Máy bắn cung', N'Máy bắn cung cho trò chơi bắn cung', 1200000, 5),
('TB004', N'Tàu lửa', N'Tàu lửa mô phỏng cho trò chơi xe lửa', 8000000, 3),
('TB005', N'Phễu trượt', N'Phễu trượt cho trò chơi cầu trượt', 200000, 8);
alter table [ThietBi]
drop column [MoTa];

INSERT INTO CT_TroChoi (MaTC, MaTB, SoLuong) VALUES
('TC001', 'TB001', 10),
('TC001', 'TB002', 15),
('TC002', 'TB003', 5),
('TC003', 'TB003', 5),
('TC004', 'TB004', 3),
('TC005', 'TB005', 8);

-- Bảng LichLamViec
INSERT INTO [LichLamViec] ([MaLich], [Ca], [ThoiGianLam])
VALUES
('L01', 1, N'07:00 - 11:00'),
('L02', 2, N'13:00 - 17:00'),
('L03', 3, N'17:00 - 22:00');

-- Bảng TKB
INSERT INTO [TKB] ([MaLich], [MaNV], [NgayLam], [ChamCong])
VALUES
('L01', 'NV001', '2024-11-16', 0), 
('L02', 'NV002', '2024-11-17', 1), 
('L03', 'NV003', '2024-11-17', 0), 
('L01', 'NV004', '2024-11-09', 0), 
('L02', 'NV005', '2024-11-18', 1),
('L02', 'NV003', '2024-11-18', 1),
('L01', 'NV005', '2024-11-15', 1),
('L03', 'NV001', '2024-11-18', 1); 

-- Bảng Loại Thực Phẩm
INSERT INTO LoaiTP (MaLoai, TenLoai) VALUES
('L001', N'Nước uống'),
('L002', N'Bánh ngọt'),
('L003', N'Kem');
-- Bảng ThucPham
INSERT INTO ThucPham (MaTP, TenTP, MoTa, GiaBan, DVT, SoLuong, MaLoai, TinhTrang) VALUES
('TP001', N'Coca-Cola', N'Nước ngọt có gas', 15000, N'Lon', 200, 'L001', N'Còn hàng'),
('TP002', N'Nước suối', N'Nước uống tinh khiết', 10000, N'Chai', 300, 'L001', N'Còn hàng'),
('TP003', N'Bánh quy', N'Bánh giòn vị bơ', 20000, N'Gói', 150, 'L002', N'Còn hàng'),
('TP004', N'Bánh mì ngọt', N'Bánh mì kẹp mứt', 25000, N'Phần', 100, 'L002', N'Còn hàng'),
('TP005', N'Kem socola', N'Kem vị socola', 30000, N'Ly', 100, 'L003', N'Còn hàng'),
('TP006', N'Kem vani', N'Kem vị vani mát lạnh', 28000, N'Ly', 80, 'L003', N'Còn hàng');
--alter table [ThucPham]
--drop column [MoTa];
-- Bảng LoaiKH
INSERT INTO LoaiKH (MaLoai, TenLoai, SoDiemCanThangLoai) VALUES
('LKH001', N'VIP', 500),
('LKH002', N'Thân thiết', 200),
('LKH003', N'Thường', 0);

-- Bảng KhachHang
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, SDT,Diem, LoaiKH) VALUES
('KH001', N'Nguyen Thi A', '1980-05-10', 0987654235,300, 'LKH001'),
('KH002', N'Tran Van B', '1990-06-20', 0877654124,50, 'LKH002'),
('KH003', N'Le Thi C', '2000-07-30', 0968543123,90, 'LKH001'),
('KH004', N'Pham Van D', '1985-08-25', 0356871234,100, 'LKH003'),
('KH005', N'Hoang Thi E', '1995-09-15', 0381234567,120, 'LKH002');

-- Bảng KhuyenMai
INSERT INTO KhuyenMai (MaKM, TenKM, NgayBatDau, NgayKetThuc, PhanTramGiam, TinhTrang, MoTa) VALUES
('KM001', N'Giảm giá mùa hè', '2024-06-01', '2024-08-31', 10, N'Đang áp dụng', N'Giảm giá 10% cho tất cả dịch vụ'),
('KM002', N'Khuyến mãi Tết', '2024-01-20', '2024-02-10', 20, N'Hết hạn', N'Giảm giá 20% cho vé Tết'),
('KM003', N'Black Friday', '2024-11-25', '2024-11-30', 50, N'Đang áp dụng', N'Giảm giá 50% cho tất cả mặt hàng'),
('KM004', N'Giảm giá mùa thu', '2024-09-01', '2024-11-30', 15, N'Đang áp dụng', N'Giảm giá 15% cho trò chơi và thực phẩm'),
('KM005', N'Khuyến mãi Giáng sinh', '2024-12-20', '2024-12-31', 25, N'Sắp diễn ra', N'Giảm giá 25% cho các dịch vụ trong dịp Giáng sinh');

-- Bảng HoaDon
INSERT INTO HoaDon (MaHD, MaKH, MaKM, NgayIn, TongTien) VALUES
('HD001', 'KH001', 'KM001', '2024-11-01', 150000),
('HD002', 'KH002', 'KM002', '2024-11-01', 200000),
('HD003', 'KH003', 'KM003', '2024-11-02', 100000),
('HD004', 'KH004', NULL, '2024-11-02', 300000),
('HD005', 'KH005', 'KM004', '2024-11-03', 400000);

-- Bảng Ve
INSERT INTO Ve (MaVe, LoaiVe, ThoiGianBan, SoLuong, TinhTrang, TroChoi) VALUES
('VE001', 'LV001', '2024-11-01', 1, N'Mới', NULL),
('VE002', 'LV002', '2024-11-02', 2, N'Đã sử dụng', 'TC001'),
('VE003', 'LV002', '2024-11-03', 1, N'Đã sử dụng', 'TC002'),
('VE004', 'LV001', '2024-11-04', 3, N'Mới', NULL),
('VE005', 'LV002', '2024-11-05', 5, N'Mới', 'TC003');

-- Bảng HoaDon_Ve
INSERT INTO CTHD_Ve (MaCTHD, MaHD, MaNV, MaVe, SoNguoiLon, SoTreEm, TinhTrang, ThanhTien) VALUES
('CTHD001', 'HD001', 'NV001', 'VE001', 1, 1, N'Đã thanh toán', 200000),
('CTHD002', 'HD002', 'NV002', 'VE002', 2, 1, N'Chưa thanh toán', 100000),
('CTHD003', 'HD003', 'NV003', 'VE003', 1, 3, N'Đã thanh toán', 400000),
('CTHD004', 'HD004', 'NV004', 'VE004', 1, 2, N'Đã thanh toán', 500000),
('CTHD005', 'HD005', 'NV005', 'VE005', 1, 1, N'Chưa thanh toán', 240000);

-- Bảng Ve_TP
INSERT INTO Ve_TP (MaCTHD, MaTP, SoLuong, DonGia, ThanhTien) VALUES
('CTHD001', 'TP001', 3, 15000, 45000),
('CTHD002', 'TP002', 2, 10000, 20000),
('CTHD003', 'TP003', 1, 25000, 25000),
('CTHD004', 'TP004', 5, 5000, 25000),
('CTHD005', 'TP005', 4, 30000, 120000);

-- Bảng HoaDon_ThucPham
INSERT INTO CTHD_TP(MaHD, MaTP, SoLuong, ThanhTien, TinhTrang) VALUES
('HD001', 'TP001', 3, 45000, N'Đã thanh toán'),
('HD002', 'TP002', 2, 20000, N'Chưa thanh toán'),
('HD003', 'TP003', 1, 25000, N'Đã thanh toán'),
('HD004', 'TP004', 5, 25000, N'Chưa thanh toán'),
('HD005', 'TP005', 4, 120000, N'Đã thanh toán');


---- Nhà cung cấp
INSERT INTO [NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [SoDienThoai], [Email], [TinhTrang], [LoaiNCC])
VALUES 
('NCC001', N'Nhà Cung Cấp ABC', N'123 Đường A, Quận 1, TP.HCM', '0909123456', 'abc@email.com', N'Hoạt động', 1),
('NCC002', N'Công Ty Thực Phẩm X', N'456 Đường B, Quận 2, TP.HCM', '0909234567', 'foodx@email.com', N'Hoạt động', 2),
('NCC003', N'Trò Chơi Việt', N'789 Đường C, Quận 3, TP.HCM', '0912345678', 'trochoiviet@email.com', N'Hoạt động', 1),
('NCC004', N'Nhà Cung Cấp DEF', N'321 Đường D, Quận 4, TP.HCM', '0909126789', 'def@email.com', N'Ngừng hoạt động', 2),
('NCC005', N'Studio Game Online', N'654 Đường E, Quận 5, TP.HCM', '0909567890', 'studioonline@email.com', N'Hoạt động', 1),
('NCC006', N'Đồ ăn văn', N'234 Lê Trọng Tấn, Tân Phú, TP.HCM', '0123456789', 'doanvat@email.com', N'Hoạt động', 2);

delete from NhaCungCap_DanhSachSP
INSERT INTO [NhaCungCap_DanhSachSP] ([MaNCC], [MaSP], [TenSP], [GiaBan])
VALUES
('NCC001', 'SP001', N'Nhà Hơi', 5000000),
('NCC001', 'SP002', N'Khung dựng nhà banh', 8000000),
('NCC001', 'SP003', N'Banh', 2000000),
('NCC002', 'SP001', N'Bánh mì kẹp thịt', 12000),
('NCC002', 'SP002', N'Nước suối', 5000),
('NCC002', 'SP003', N'Nước Coca', 8000),
('NCC003', 'SP001', N'Bộ đồ chơi câu cá', 4000000),
('NCC003', 'SP002', N'Tượng tô', 1500000),
('NCC004', 'SP001', N'Bánh quy', 20000),
('NCC005', 'SP001', N'Máy điện tử', 1000000),
('NCC006', 'SP001', N'Bánh bao', 100000),
('NCC006', 'SP002', N'Bánh nướng', 200000);


INSERT INTO [PhieuNhap] ([MaPhieu], [MaNCC], [MaNV], [NgayNhap], [TongTien], [GhiChu])
VALUES 
('PN001', 'NCC001','NV001', '2023-01-10', 13000000, N'Đã thanh toán'),
('PN002', 'NCC002','NV001', '2023-02-15', 520000, N'Đã thanh toán'),
('PN003', 'NCC003','NV002', '2023-03-20', 10500000, N'Đã thanh toán'),
('PN004', 'NCC004','NV003', '2023-04-05', 200000, N'Đã thanh toán'),
('PN005', 'NCC005','NV004', '2023-05-12', 10000000, N'Đã thanh toán');


INSERT INTO [CTPN_TP] ([MaPhieu], [MaTP], [TenTP], [DVT], [SoLuong], [GiaNhap], [ThanhTien])
VALUES
('PN002', 'TP001', N'Coca-Cola', N'Lon', 10,12000, 120000),
('PN002', 'TP002',N'Nước suối',N'Chai', 50,8000, 400000),
('PN004', 'TP003', N'Bánh quy',N'Gói', 10,20000, 200000);

INSERT INTO [CTPN_TB] ([MaPhieu], [MaTB], [TenTB], [SoLuong], [GiaNhap], [ThanhTien])
VALUES
('PN001', 'TB001',N'Khung sắt', 1, 5000000, 5000000),
('PN001', 'TB002',N'Bóng nhún', 1, 4500000, 4500000),
('PN003', 'TB003',N'Máy bắn cung', 1, 6000000, 6000000),
('PN003', 'TB004',N'Tàu lửa', 1, 24000000, 24000000),
('PN005', 'TB005',N'Phễu trượt', 1, 16000000, 1600000);

INSERT INTO [VaiTro]
VALUES
('QTV', N'Quản trị viên'),
('QL', N'Quản lý'),
('NV', N'Nhân viên');

INSERT INTO [ManHinh]
VALUES
('MH001', N'frmBanVe'),
('MH002', N'frmBaoCaoThongKe'),
('MH003', N'frmKhuyenMai'),
('MH004', N'frmLoaiTP'),
('MH005', N'frmNhaCungCap'),
('MH006', N'frmPhieuNhap'),
('MH007', N'frmQL_DSSP'),
('MH008', N'frmQLHoaDon'),
('MH009', N'frmQLKhachHang'),
('MH010', N'frmQLLoaiTroChoi'),
('MH011', N'frmQLNhanVien'),
('MH012', N'frmQLThucPham'),
('MH013', N'frmQLTroChoi'),
('MH014', N'frmTP_LTP'),
('MH015', N'frmVe'),
('MH016', N'frmVaiTro'),
('MH017', N'frmManHinh'),
('MH018', N'frmPhanQuyen'),
('MH019', N'frmQLThietBi'),
('MH020', N'frmNhapHang')

INSERT INTO [PhanQuyen] ([MaVaiTro], [MaMH], [HoatDong])
VALUES
    ('QTV', 'MH001', 1),
    ('QTV', 'MH002', 1),
    ('QTV', 'MH003', 1),
    ('QTV', 'MH004', 1),
    ('QTV', 'MH005', 1),
    ('QTV', 'MH006', 1),
    ('QTV', 'MH007', 1),
    ('QTV', 'MH008', 1),
    ('QTV', 'MH009', 1),
    ('QTV', 'MH010', 1),
    ('QTV', 'MH011', 1),
    ('QTV', 'MH012', 1),
    ('QTV', 'MH013', 1),
    ('QTV', 'MH014', 1),
    ('QTV', 'MH015', 1),
    ('QTV', 'MH016', 1),
    ('QTV', 'MH017', 1),
    ('QTV', 'MH018', 1),
	('QL', 'MH002', 1),
    ('QL', 'MH003', 1),
    ('QL', 'MH005', 1),
    ('QL', 'MH008', 1),
    ('QL', 'MH009', 1),
    ('QL', 'MH011', 1),
    ('QL', 'MH013', 1),
    ('QL', 'MH016', 1),
	('NV', 'MH001', 1),
    ('NV', 'MH003', 1),
    ('NV', 'MH015', 1); 

INSERT INTO TaiKhoan
VALUES
	('Admin', 'admin123', 'NV006', 'QTV'),
	('Aloha', 'abc123', 'NV001', 'NV');

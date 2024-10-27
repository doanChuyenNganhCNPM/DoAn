CREATE DATABASE DoAn

USE DoAn
GO

CREATE TABLE [Ve] (
  [MaVe] varchar(10) PRIMARY KEY,
  [LoaiVe] varchar(10) DEFAULT (null),
  [TinhTrang] nvarchar(30)
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
  [TenNV] nvarchar(30),
  [GioiTinh] nvarchar(5),
  [NgaySinh] date,
  [CCCD] varchar(12),
  [LoaiNVThang] varchar(10) DEFAULT (null),
  [ChucVu] varchar(10) DEFAULT (null)
)
GO

CREATE TABLE [LoaiNVThang] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(20),
  [HSLCongThem] float
)
GO

CREATE TABLE [LoaiNV] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [ChucVu] nvarchar(20),
  [HeSoLuong] float,
  [LuongCB] float
)
GO

CREATE TABLE [TroChoi] (
  [MaTC] varchar(10) PRIMARY KEY,
  [TenTC] nvarchar(30),
  [DiaDiem] nvarchar(50),
  [LoaiTroChoi] varchar(10) DEFAULT (null),
  [NgayBatDau] date,
  [NgayKetThuc] date,
  [TinhTrang] nvarchar(30)
)
GO

CREATE TABLE [LoaiTC] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(30),
  [Gia] float,
  [GhiChu] nvarchar(30)
)
GO

CREATE TABLE [LichLamViec] (
  [MaLich] varchar(10) PRIMARY KEY,
  [NgayLam] date,
  [Thu] nvarchar(10),
  [Ca] int,
  [ThoiGianLam] varchar(20)
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
  [TenTP] nvarchar(30),
  [MoTa] nvarchar(30),
  [GiaBan] float DEFAULT (0),
  [SoLuong] int DEFAULT (0),
  [TinhTrang] nvarchar(30)
)
GO

CREATE TABLE [BanVe] (
  [MaBanVe] varchar(10) PRIMARY KEY,
  [MaVe] varchar(10),
  [MaNV] varchar(10),
  [ThoiGianBan] date,
  [ThoiGianBatDau] date,
  [ThoiGianHetHan] date,
  [SoLuong] int DEFAULT (1),
  [TinhTrang] nvarchar(30),
  [TroChoi] varchar(10) DEFAULT (null)
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
  [MaHD] varchar(10),
  [MaBanVe] varchar(10),
  [TinhTrang] nvarchar(30),
  [ThanhTien] float,
  PRIMARY KEY ([MaHD], [MaBanVe])
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
  [HoTen] nvarchar(30),
  [NgaySinh] date,
  [CCCD] varchar(12),
  [LoaiKH] varchar(10)
)
GO

CREATE TABLE [LoaiKH] (
  [MaLoai] varchar(10) PRIMARY KEY,
  [TenLoai] nvarchar(30),
  [SoTienCanThangLoai] float
)
GO

CREATE TABLE [KhuyenMai] (
  [MaKM] varchar(10) PRIMARY KEY,
  [TenKM] nvarchar(30),
  [NgayBatDau] date DEFAULT (null),
  [NgayKetThuc] date DEFAULT (null),
  [PhanTramGiam] float,
  [TinhTrang] nvarchar(30),
  [MoTa] nvarchar(30)
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

ALTER TABLE [NhanVien] ADD FOREIGN KEY ([ChucVu]) REFERENCES [LoaiNV] ([MaLoai])
GO

ALTER TABLE [NhanVien] ADD FOREIGN KEY ([LoaiNVThang]) REFERENCES [LoaiNVThang] ([MaLoai])
GO

ALTER TABLE [TroChoi] ADD FOREIGN KEY ([LoaiTroChoi]) REFERENCES [LoaiTC] ([MaLoai])
GO

ALTER TABLE [TKB] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [TKB] ADD FOREIGN KEY ([MaLich]) REFERENCES [LichLamViec] ([MaLich])
GO

ALTER TABLE [BanVe] ADD FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [BanVe] ADD FOREIGN KEY ([MaVe]) REFERENCES [Ve] ([MaVe])
GO

ALTER TABLE [HoaDon_Ve] ADD FOREIGN KEY ([MaBanVe]) REFERENCES [BanVe] ([MaBanVe])
GO

ALTER TABLE [HoaDon_Ve] ADD FOREIGN KEY ([MaHD]) REFERENCES [HoaDon] ([MaHD])
GO

ALTER TABLE [BanVe] ADD FOREIGN KEY ([TroChoi]) REFERENCES [TroChoi] ([MaTC])
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

INSERT INTO [LoaiTC] ([MaLoai], [TenLoai], [Gia], [GhiChu]) VALUES
('TC01', N'Trò chơi điện tử', 150000, N'Trò chơi trên máy tính'),
('TC02', N'Trò chơi ngoài trời', 50000, N'Trò chơi vận động thể chất'),
('TC03', N'Trò chơi trí tuệ', 100000, N'Cờ vua, cờ tướng, sudoku'),
('TC04', N'Trò chơi mô phỏng', 200000, N'Mô phỏng thực tế ảo'),
('TC05', N'Trò chơi nhập vai', 250000, N'Nhập vai vào nhân vật');


select * from LoaiTC

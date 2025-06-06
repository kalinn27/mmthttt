USE [CuaHangThuocBVTV]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[InvoiceDate] [datetime] NULL,
	[TotalAmount] [decimal](12, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [decimal](12, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[TotalAmount] [decimal](12, 2) NULL,
	[CreatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UnitPrice] [decimal](12, 2) NOT NULL,
	[Unit] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL,
	[SupplierID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 23/04/2025 09:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](max) NULL,
	[RoleID] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoices] ADD  DEFAULT (getdate()) FOR [InvoiceDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO

ALTER TABLE [dbo].[Products]
ADD [ImportDate] [datetime] NOT NULL DEFAULT GETDATE();

ALTER TABLE [dbo].[Products]
ADD [ImagePath] NVARCHAR(255) NULL;


USE [CuaHangThuocBVTV];
GO

CREATE TABLE [dbo].[Accounts](
    [UserID] [int] IDENTITY(1,1) NOT NULL, -- Dùng UserID làm khóa chính và là IDENTITY
    [Username] [nvarchar](50) NOT NULL UNIQUE, -- Tên đăng nhập phải duy nhất
    [PasswordHash] [nvarchar](255) NOT NULL,
    [RoleID] [int] NOT NULL,
    [CreatedAt] [datetime] NULL DEFAULT GETDATE(),
PRIMARY KEY CLUSTERED
(
    [UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY];
GO

-- Thêm khóa ngoại liên kết RoleID với bảng Roles
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID]);
GO


USE [CuaHangThuocBVTV];
GO

-- Phương án A: Nếu bạn muốn đổi tên bảng Users hiện tại thành UserProfiles
EXEC sp_rename 'dbo.Users', 'UserProfiles';
GO

-- Sau đó, điều chỉnh cấu trúc của bảng UserProfiles (tên cũ là Users)
ALTER TABLE [dbo].[UserProfiles]
DROP CONSTRAINT [PK__Users__1788CCACBCE524E6]; -- Xóa Primary Key cũ nếu có tên mặc định
GO

ALTER TABLE [dbo].[UserProfiles]
DROP COLUMN [Username], [PasswordHash], [RoleID], [CreatedAt]; -- Xóa các cột đã chuyển sang bảng Accounts
GO

ALTER TABLE [dbo].[UserProfiles]
ADD PRIMARY KEY CLUSTERED ([UserID] ASC); -- Đảm bảo UserID vẫn là PK và tham chiếu đến Accounts.UserID
GO

-- Thêm khóa ngoại liên kết UserID với bảng Accounts
ALTER TABLE [dbo].[UserProfiles] WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Accounts] ([UserID]);
GO

INSERT INTO [CuaHangThuocBVTV].[dbo].[Accounts] 
    ([Username], [PasswordHash], [RoleID], [CreatedAt])
VALUES 
    ('admin', 'adminpass123', 1, GETDATE());

INSERT INTO [CuaHangThuocBVTV].[dbo].[Accounts] 
    ([Username], [PasswordHash], [RoleID], [CreatedAt])
VALUES 
    ('klinh', 'linhpass123', 2, GETDATE());


USE [CuaHangThuocBVTV]; 
GO

-- Thêm cột NgaySinh (kiểu DATETIME, cho phép NULL)
ALTER TABLE [dbo].[UserProfiles]
ADD [NgaySinh] DATETIME NULL;
GO

-- Thêm cột GioiTinh (kiểu NVARCHAR, ví dụ: 50 ký tự, cho phép NULL)
ALTER TABLE [dbo].[UserProfiles]
ADD [GioiTinh] NVARCHAR(50) NULL;
GO

-- Thêm cột Avatar (kiểu VARBINARY(MAX) để lưu dữ liệu ảnh, cho phép NULL)
ALTER TABLE [dbo].[UserProfiles]
ADD [Avatar] VARBINARY(MAX) NULL;
GO
USE [CuaHangThuocBVTV];
GO

-- Xóa cột NgaySinh
ALTER TABLE [dbo].[UserProfiles]
DROP COLUMN [NgaySinh];
GO

-- Xóa cột GioiTinh
ALTER TABLE [dbo].[UserProfiles]
DROP COLUMN [GioiTinh];
GO

-- Xóa cột Avatar
ALTER TABLE [dbo].[UserProfiles]
DROP COLUMN [Avatar];
GO

INSERT INTO [CuaHangThuocBVTV].[dbo].[UserProfiles] 
    ([Username], [PasswordHash], [FullName], [Email], [Phone], [RoleID], [CreatedAt])
VALUES 
    ('KhanhLinh', 'KhanhLinh123', 'Luu Khanh Linh', 'imlinh273@gmail.com', '0312654487', 3, GETDATE());

	USE [CuaHangThuocBVTV]; 
GO

DELETE FROM [dbo].[UserProfiles]
WHERE UserID = 5; -- Xóa dòng có UserID là 5
GO
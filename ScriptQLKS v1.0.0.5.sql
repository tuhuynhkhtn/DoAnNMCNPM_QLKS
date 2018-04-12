/*
Navicat SQL Server Data Transfer

Source Server         : SQL SERVER
Source Server Version : 120000
Source Host           : .\SQLEXPRESS:1433
Source Database       : QLKS
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2018-04-12 21:37:23
*/


-- ----------------------------
-- Table structure for Categories
-- ----------------------------
DROP TABLE [dbo].[Categories]
GO
CREATE TABLE [dbo].[Categories] (
[CatID] int NOT NULL IDENTITY(1,1) ,
[CatName] nvarchar(50) NOT NULL ,
[CatType] nvarchar(50) NOT NULL ,
[Price] money NOT NULL ,
[Note] nvarchar(50) NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Categories]', RESEED, 21)
GO

-- ----------------------------
-- Records of Categories
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Categories] ON
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'1', N'Thường', N'A', N'150000.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'2', N'Trung cấp', N'B', N'170000.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'3', N'Cao cấp', N'C', N'200000.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'5', N'cat', N'1', N'200000.0000', N'cat')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'9', N'cat8', N'4', N'200000.0000', N'cat3')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'11', N'a19', N'y', N'500.0000', N'y')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'12', N'a21', N'a21', N'55000.0000', N'a21')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'13', N'ee', N'ee', N'9000000.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'14', N'eee', N'eee', N'500.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'15', N'009', N'009', N'900.0000', N'009')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'18', N'a93', N'a93', N'500.0000', N'93')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'19', N'a55', N'a59', N'500.0000', N'a55')
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'21', N'a99', N'a99', N'500.0000', null)
GO
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO

-- ----------------------------
-- Table structure for Customers
-- ----------------------------
DROP TABLE [dbo].[Customers]
GO
CREATE TABLE [dbo].[Customers] (
[CusID] int NOT NULL IDENTITY(1,1) ,
[CusName] nvarchar(50) NOT NULL ,
[CusTypeID] int NOT NULL ,
[CusIDCard] int NOT NULL ,
[CusAddress] nvarchar(255) NOT NULL ,
[RoomName] nvarchar(50) NOT NULL ,
[BookRoom] int NOT NULL 
)


GO

-- ----------------------------
-- Records of Customers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Customers] ON
GO
INSERT INTO [dbo].[Customers] ([CusID], [CusName], [CusTypeID], [CusIDCard], [CusAddress], [RoomName], [BookRoom]) VALUES (N'1', N'a', N'1', N'25467879', N'Số 42, đường T4B, phường Tây Thạnh, quận Tân phú', N'C22', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO

-- ----------------------------
-- Table structure for CusTypes
-- ----------------------------
DROP TABLE [dbo].[CusTypes]
GO
CREATE TABLE [dbo].[CusTypes] (
[CusTypeID] int NOT NULL IDENTITY(1,1) ,
[CusTypeName] nvarchar(50) NOT NULL ,
[Coefficient] float(53) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[CusTypes]', RESEED, 16)
GO

-- ----------------------------
-- Records of CusTypes
-- ----------------------------
SET IDENTITY_INSERT [dbo].[CusTypes] ON
GO
INSERT INTO [dbo].[CusTypes] ([CusTypeID], [CusTypeName], [Coefficient]) VALUES (N'13', N'Nội địa ', N'0')
GO
GO
INSERT INTO [dbo].[CusTypes] ([CusTypeID], [CusTypeName], [Coefficient]) VALUES (N'14', N'Nước ngoài', N'1.5')
GO
GO
SET IDENTITY_INSERT [dbo].[CusTypes] OFF
GO

-- ----------------------------
-- Table structure for OrderDetails
-- ----------------------------
DROP TABLE [dbo].[OrderDetails]
GO
CREATE TABLE [dbo].[OrderDetails] (
[OrderID] int NOT NULL IDENTITY(1,1) ,
[ RoomID] int NOT NULL ,
[Quantity] int NOT NULL ,
[StatusForeignCus] int NOT NULL ,
[AdditionalFee] int NOT NULL ,
[OrderCheckOut] datetime NOT NULL ,
[Price] money NOT NULL ,
[Amount] money NOT NULL 
)


GO

-- ----------------------------
-- Records of OrderDetails
-- ----------------------------
SET IDENTITY_INSERT [dbo].[OrderDetails] ON
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO

-- ----------------------------
-- Table structure for Orders
-- ----------------------------
DROP TABLE [dbo].[Orders]
GO
CREATE TABLE [dbo].[Orders] (
[OrderID] int NOT NULL ,
[OrderCheckIn] datetime NOT NULL ,
[CusID] int NOT NULL ,
[Total] money NOT NULL 
)


GO

-- ----------------------------
-- Records of Orders
-- ----------------------------

-- ----------------------------
-- Table structure for Rooms
-- ----------------------------
DROP TABLE [dbo].[Rooms]
GO
CREATE TABLE [dbo].[Rooms] (
[RoomID] int NOT NULL IDENTITY(1,1) ,
[RoomName] nvarchar(50) NOT NULL ,
[RoomType] nvarchar(50) NOT NULL ,
[Price] money NOT NULL ,
[Note] nvarchar(50) NULL ,
[Status] int NOT NULL ,
[MaximumCus] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Rooms]', RESEED, 75)
GO

-- ----------------------------
-- Records of Rooms
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Rooms] ON
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'52', N'C22', N'1', N'150000.0000', null, N'0', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'53', N'C23', N'2', N'170000.0000', null, N'0', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'54', N'C43', N'3', N'200000.0000', null, N'0', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'55', N'C52', N'1', N'150000.0000', null, N'1', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'56', N'C26', N'2', N'170000.0000', null, N'1', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'70', N'room1', N'B', N'500.0000', N' ', N'0', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'71', N'a9', N'B', N'500.0000', N' ', N'0', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'72', N'C19', N'C', N'500.0000', N' ', N'0', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'73', N'a', N'A', N'500.0000', N'a ', N'1', N'3')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'74', N'a18', N'A', N'5000000.0000', N' a18', N'0', N'4')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [RoomType], [Price], [Note], [Status], [MaximumCus]) VALUES (N'75', N'aa', N'A', N'900000.0000', N'A', N'1', N'9')
GO
GO
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE [dbo].[Users]
GO
CREATE TABLE [dbo].[Users] (
[f_ID] int NOT NULL IDENTITY(1,1) ,
[f_UserName] nvarchar(50) NOT NULL ,
[f_Password] nvarchar(255) NOT NULL ,
[f_Name] nvarchar(50) NOT NULL ,
[f_Permission] int NOT NULL DEFAULT ((0)) 
)


GO
DBCC CHECKIDENT(N'[dbo].[Users]', RESEED, 5)
GO

-- ----------------------------
-- Records of Users
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_UserName], [f_Password], [f_Name], [f_Permission]) VALUES (N'1', N'admin', N'21232F297A57A5A743894AE4A801FC3', N'admin', N'1')
GO
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_UserName], [f_Password], [f_Name], [f_Permission]) VALUES (N'2', N'a', N'81DC9BDB52D04DC2036DBD8313ED055', N'a a', N'0')
GO
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_UserName], [f_Password], [f_Name], [f_Permission]) VALUES (N'3', N'a', N'81DC9BDB52D04DC2036DBD8313ED055', N'a', N'0')
GO
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_UserName], [f_Password], [f_Name], [f_Permission]) VALUES (N'4', N'b', N'81DC9BDB52D04DC2036DBD8313ED055', N'b', N'0')
GO
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

-- ----------------------------
-- Indexes structure for table Categories
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Categories
-- ----------------------------
ALTER TABLE [dbo].[Categories] ADD PRIMARY KEY ([CatID])
GO

-- ----------------------------
-- Indexes structure for table Customers
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Customers
-- ----------------------------
ALTER TABLE [dbo].[Customers] ADD PRIMARY KEY ([CusID])
GO

-- ----------------------------
-- Indexes structure for table CusTypes
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CusTypes
-- ----------------------------
ALTER TABLE [dbo].[CusTypes] ADD PRIMARY KEY ([CusTypeID])
GO

-- ----------------------------
-- Indexes structure for table OrderDetails
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table OrderDetails
-- ----------------------------
ALTER TABLE [dbo].[OrderDetails] ADD PRIMARY KEY ([OrderID], [ RoomID])
GO

-- ----------------------------
-- Indexes structure for table Orders
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Orders
-- ----------------------------
ALTER TABLE [dbo].[Orders] ADD PRIMARY KEY ([OrderID])
GO

-- ----------------------------
-- Indexes structure for table Rooms
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Rooms
-- ----------------------------
ALTER TABLE [dbo].[Rooms] ADD PRIMARY KEY ([RoomID])
GO

-- ----------------------------
-- Indexes structure for table Users
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD PRIMARY KEY ([f_ID])
GO

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

Date: 2018-03-10 16:48:28
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
DBCC CHECKIDENT(N'[dbo].[Categories]', RESEED, 3)
GO

-- ----------------------------
-- Records of Categories
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Categories] ON
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'1', N'Cao cấp', N'A', N'150000.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'2', N'Trung cấp', N'B', N'170000.0000', null)
GO
GO
INSERT INTO [dbo].[Categories] ([CatID], [CatName], [CatType], [Price], [Note]) VALUES (N'3', N'Thường', N'C', N'200000.0000', null)
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
[CusType] nvarchar(50) NOT NULL ,
[CusIDCard] int NOT NULL ,
[CusAddress] nvarchar(255) NOT NULL 
)


GO

-- ----------------------------
-- Records of Customers
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Customers] ON
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
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
[CatID] int NOT NULL ,
[Price] money NULL ,
[Status] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[Rooms]', RESEED, 13)
GO

-- ----------------------------
-- Records of Rooms
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Rooms] ON
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'1', N'C22', N'1', N'200000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'2', N'C23', N'2', N'170000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'3', N'C43', N'1', N'150000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'4', N'C19', N'1', N'200000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'5', N'C33', N'2', N'170000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'6', N'C42', N'2', N'170000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'9', N'C29', N'1', N'150000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'10', N'F109', N'1', N'200000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'11', N'F110', N'1', N'200000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'12', N'I23', N'1', N'200000.0000', N'0')
GO
GO
INSERT INTO [dbo].[Rooms] ([RoomID], [RoomName], [CatID], [Price], [Status]) VALUES (N'13', N'I22', N'1', N'200000.0000', N'0')
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
DBCC CHECKIDENT(N'[dbo].[Users]', RESEED, 2)
GO

-- ----------------------------
-- Records of Users
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Users] ON
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_UserName], [f_Password], [f_Name], [f_Permission]) VALUES (N'1', N'a', N'81DC9BDB52D04DC2036DBD8313ED055', N'a a', N'0')
GO
GO
INSERT INTO [dbo].[Users] ([f_ID], [f_UserName], [f_Password], [f_Name], [f_Permission]) VALUES (N'2', N'a', N'81DC9BDB52D04DC2036DBD8313ED055', N'a a', N'0')
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

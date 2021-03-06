USE [master]
GO
/****** Object:  Database [WarehouseManagement]    Script Date: 4/4/2022 4:36:57 PM ******/
CREATE DATABASE [WarehouseManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WarehouseManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\WarehouseManagement.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WarehouseManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\WarehouseManagement_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WarehouseManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WarehouseManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WarehouseManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WarehouseManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WarehouseManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WarehouseManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WarehouseManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [WarehouseManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [WarehouseManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WarehouseManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WarehouseManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WarehouseManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WarehouseManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WarehouseManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WarehouseManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WarehouseManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WarehouseManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WarehouseManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [WarehouseManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WarehouseManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WarehouseManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WarehouseManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WarehouseManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WarehouseManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WarehouseManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WarehouseManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WarehouseManagement] SET  MULTI_USER 
GO
ALTER DATABASE [WarehouseManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WarehouseManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WarehouseManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WarehouseManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [WarehouseManagement]
GO
/****** Object:  Table [dbo].[CostAccount]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CostAccount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CostAccountItem]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CostAccountItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [varchar](50) NOT NULL,
	[CostAccount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [varchar](10) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[IsAdmin] [bit] NOT NULL DEFAULT ((0)),
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExportHistory]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExportHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Material] [int] NOT NULL,
	[ExportDate] [date] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Receiver] [int] NOT NULL,
	[Requestor] [nvarchar](200) NULL,
	[Handler] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ImportHistory]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImportHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Material] [int] NOT NULL,
	[ImportDate] [date] NOT NULL DEFAULT (getdate()),
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Supplier] [nvarchar](200) NULL,
	[LineRequest] [int] NOT NULL,
	[Buyer] [nvarchar](100) NULL,
	[PO] [varchar](20) NULL,
	[Allocated] [bit] NOT NULL DEFAULT ((0)),
	[Handler] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inspection]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspection](
	[ImportId] [int] NOT NULL,
	[Status] [bit] NOT NULL DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
	[Inspector] [nvarchar](100) NULL,
	[Result] [bit] NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ImportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Line]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Line](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CostCenter] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Material]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QCode] [varchar](10) NOT NULL,
	[Zone] [int] NOT NULL,
	[Unit] [int] NOT NULL,
	[Location] [nvarchar](100) NOT NULL,
	[Item] [nvarchar](100) NULL,
	[Specification] [nvarchar](500) NULL,
	[Remark] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zone]    Script Date: 4/4/2022 4:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Zone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](5) NOT NULL,
	[Description] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[CostAccount] ON 

INSERT [dbo].[CostAccount] ([Id], [Name]) VALUES (1, N'602011-0000')
INSERT [dbo].[CostAccount] ([Id], [Name]) VALUES (2, N'602021-0000')
INSERT [dbo].[CostAccount] ([Id], [Name]) VALUES (3, N'602031-0000')
INSERT [dbo].[CostAccount] ([Id], [Name]) VALUES (4, N'602041-0000')
SET IDENTITY_INSERT [dbo].[CostAccount] OFF
SET IDENTITY_INSERT [dbo].[CostAccountItem] ON 

INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (1, N'CNG', 1)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (2, N'N2', 1)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (3, N'NH3', 1)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (4, N'ACID-APL', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (5, N'WATER TREAT', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (6, N'SALT', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (7, N'ETC-PRO', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (8, N'ROLL', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (9, N'ROLLING OIL', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (10, N'BACKUP BEARING', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (11, N'ANODE', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (12, N'OIL FILTER', 2)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (13, N'OIL', 3)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (14, N'BEARING', 3)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (15, N'ELECTRIC SPARE', 3)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (16, N'MECHANICAL SPARE', 3)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (17, N'TOOL', 3)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (18, N'ETC-MAINT', 3)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (19, N'PE COVER', 4)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (20, N'IN-OUTER RING', 4)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (21, N'STEEL BAND', 4)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (22, N'WOODEN PALLET', 4)
INSERT [dbo].[CostAccountItem] ([Id], [Note], [CostAccount]) VALUES (23, N'WATER PROOF, VINYL, ETC', 4)
SET IDENTITY_INSERT [dbo].[CostAccountItem] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [EmployeeId], [Password], [FirstName], [LastName], [IsAdmin], [IsActive]) VALUES (1, N'202110', N'202cb962ac59075b964b07152d234b70', N'Huy', N'Lê Anh', 1, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[ImportHistory] ON 

INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (7, 3, CAST(N'2022-03-10' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 0, 1, CAST(N'2022-03-10 15:45:12.880' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (12, 8, CAST(N'2022-03-10' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 0, 1, CAST(N'2022-03-10 15:58:29.967' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (13, 9, CAST(N'2022-03-10' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 0, 1, CAST(N'2022-03-10 15:58:35.497' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (14, 11, CAST(N'2022-03-10' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 1, 1, CAST(N'2022-03-10 16:00:23.470' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (15, 14, CAST(N'2022-03-10' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 1, 1, CAST(N'2022-03-10 16:02:51.553' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (16, 17, CAST(N'2022-03-10' AS Date), 5656, 5656, N'dfgfd', 2, N'dfgdfg', N'56', 0, 1, CAST(N'2022-03-10 16:07:20.707' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (17, 19, CAST(N'2022-03-15' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 0, 1, CAST(N'2022-03-15 13:37:35.540' AS DateTime))
INSERT [dbo].[ImportHistory] ([Id], [Material], [ImportDate], [Quantity], [Price], [Supplier], [LineRequest], [Buyer], [PO], [Allocated], [Handler], [CreatedDate]) VALUES (18, 21, CAST(N'2022-03-15' AS Date), 113, 15000, N'supplier test', 1, N'Mr Zero', N'PO nè', 0, 1, CAST(N'2022-03-15 13:52:50.250' AS DateTime))
SET IDENTITY_INSERT [dbo].[ImportHistory] OFF
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (7, 1, CAST(N'2022-03-10 15:45:12.883' AS DateTime), N'inspector test', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (12, 1, CAST(N'2022-03-10 15:58:29.970' AS DateTime), N'inspector test', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (13, 1, CAST(N'2022-03-10 15:58:35.500' AS DateTime), N'inspector test', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (14, 1, CAST(N'2022-03-10 16:00:23.470' AS DateTime), N'inspector test', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (15, 1, CAST(N'2022-03-10 16:02:51.557' AS DateTime), N'inspector test', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (16, 1, CAST(N'2022-03-10 16:07:20.710' AS DateTime), N'sdsd', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (17, 1, CAST(N'2022-03-15 13:37:35.557' AS DateTime), N'inspector test', 1)
INSERT [dbo].[Inspection] ([ImportId], [Status], [CreatedDate], [Inspector], [Result]) VALUES (18, 1, CAST(N'2022-03-15 13:52:50.257' AS DateTime), N'inspector test', 1)
SET IDENTITY_INSERT [dbo].[Line] ON 

INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (1, N'5 S', N'VVA18-Safety/Environment')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (2, N'CAPL LINE', N'VSB26-CR2-APL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (3, N'CARPENTER', N'VVH99-SUPPORT WORK COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (4, N'CBL LINE', N'VSB24-CR2-CBL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (5, N'CITY WATER', N'VTA16-Utility-Water')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (6, N'CONSTRUCT', N'VVH99-SUPPORT WORK COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (7, N'CRANE-FACTORY1', N'VSA99-UTILITY COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (8, N'CTL #2 LINE', N'VSA18-CR-#2CTL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (9, N'GARDEN', N'HSB12-HR-General Affair')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (10, N'HBA LINE', N'VSC13-Precision-PBA')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (11, N'P PACKING', N'VSC19-Precision-Packing')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (12, N'PACKING 1', N'VSA19-CR PACKING')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (13, N'PACKING 2', N'VSB19-CR2 PACKING')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (14, N'PDGL LINE', N'VSC27-Precision-PDG')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (15, N'PHBAL LINE', N'VSC13-Precision-PBA')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (16, N'P-QC', N'VVA13-SUPPORT QUALITY')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (17, N'PRODUCTION', N'VVH99-SUPPORT WORK COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (18, N'PSL  LINE', N'VSC16-Precision-#1PSL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (19, N'PTLL LINE', N'VSC25-Precision-PTL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (20, N'PZM LINE', N'VSC11-Precision-ZRM')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (21, N'QC  LINE', N'VVA13-SUPPORT QUALITY')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (22, N'QSS', N'VVA17-Support-QSS')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (23, N'RG PZM LINE', N'VSC23-Precision-Roll Grinder')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (24, N'RG SPM #2 LINE', N'VSA23-CR ROLL GRINDER')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (25, N'RG SPM #3 LINE', N'VSB23-CR2 ROLL GRINDER')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (26, N'RG ZRM LINE', N'VSA23-CR ROLL GRINDER')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (27, N'RG ZRM#3 LINE', N'VSB23-CR2 ROLL GRINDER')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (28, N'RS-LINE', N'VSB23-CR2 ROLL GRINDER')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (29, N'SAFETY', N'VVA18-Safety/Environment')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (30, N'SECURITY', N'HSB12-General Affair')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (31, N'SL #2 LINE', N'VSA16-CR-STL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (32, N'SPM #1 LINE', N'VSC15-Precision-SPM')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (33, N'SPM #2 LINE', N'VSA15-CR SPM')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (34, N'SPM #3 LINE', N'VSB15-CR2-SPM')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (35, N'STL LINE', N'VSB16-CR2 STL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (36, N'TLL LINE', N'VSB25-CR2 TLL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (37, N'UTILITY LINE', N'VTA99-UTILITY COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (38, N'VBA #1 LINE', N'VSA13-CR-#1BAL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (39, N'VBA #2 LINE', N'VSA14-CR-#2BAL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (40, N'WAREHOUSE', N'WAREHOUSE')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (41, N'WP #1 LINE', N'VSA16-CR-STL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (42, N'WP #2 LINE', N'VSB16-CR2 STL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (43, N'WWT LINE', N'VTA12-Waste Water Treatment')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (44, N'ZRM #1 LINE', N'VSA11-CR ZM1')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (45, N'ZRM #2 LINE', N'VSA12-CR ZM2')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (46, N'ZRM #3 LINE', N'VSB11-CR2-#1ZRM')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (47, N'PRODUCTION-SCRAP', N'VVH99-SUPPORT WORK COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (48, N'PACKING-VHPC', N'')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (49, N'ODER-VHPC', N'VVH99-SUPPORT WORK COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (50, N'Main (ME 1)', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (51, N'Main (ME 2)', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (52, N'Main (UTI 2 ME)', N'')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (53, N'Main (CONS)', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (54, N'Main (EL 2)', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (55, N'Main (UTI 1 ME)', N'')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (56, N'Main (EL 1)', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (57, N'Main (UTI 2 EL)', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (58, N'QC-LAB', N'VVA13-SUPPORT QUALITY')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (59, N'CRANE-FACTORY2', N'VSB99-UTILITY COMMON')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (60, N'POSCO VHPC', N'VSA18-CR2STL')
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (61, N'LSC', NULL)
INSERT [dbo].[Line] ([Id], [Name], [CostCenter]) VALUES (62, N'CPL LINE', N'VSA24-CR-CPL')
SET IDENTITY_INSERT [dbo].[Line] OFF
SET IDENTITY_INSERT [dbo].[Material] ON 

INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (3, N'Q4358113', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-10 15:45:12.860' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (8, N'A4358313', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-10 15:58:29.937' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (9, N'B4358313', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-10 15:58:35.497' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (11, N'E4358313', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-10 16:00:23.470' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (14, N'F4358313', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-10 16:02:51.550' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (17, N'F6556fg56', 2, 3, N'gdfgdf', N'dfgdfg', N'gdfgdfg', N'dfgdfgdf', CAST(N'2022-03-10 16:07:20.683' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (19, N'Q4358114', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-15 13:37:35.080' AS DateTime))
INSERT [dbo].[Material] ([Id], [QCode], [Zone], [Unit], [Location], [Item], [Specification], [Remark], [CreatedDate]) VALUES (21, N'Q4358115', 2, 1, N'location test', N'item test', N'specification test', N'remark test', CAST(N'2022-03-15 13:52:50.230' AS DateTime))
SET IDENTITY_INSERT [dbo].[Material] OFF
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [Name]) VALUES (1, N'Bottle')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (2, N'Box')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (3, N'Bul')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (4, N'Can')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (5, N'Cubic Meter')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (6, N'Drum')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (7, N'Each')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (8, N'Kilogram')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (9, N'Link')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (10, N'Liter')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (11, N'Meter')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (12, N'Pair')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (13, N'Roll')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (14, N'Set')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (15, N'Tin')
INSERT [dbo].[Unit] ([Id], [Name]) VALUES (16, N'Sheet')
SET IDENTITY_INSERT [dbo].[Unit] OFF
SET IDENTITY_INSERT [dbo].[Zone] ON 

INSERT [dbo].[Zone] ([Id], [Name], [Description]) VALUES (1, N'WH1', N'MAIN WAREHOUSE')
INSERT [dbo].[Zone] ([Id], [Name], [Description]) VALUES (2, N'WH2', N'MECHANICAL WAREHOUSE')
INSERT [dbo].[Zone] ([Id], [Name], [Description]) VALUES (3, N'WH3', N'ELECTRIC WAREHOUSE')
INSERT [dbo].[Zone] ([Id], [Name], [Description]) VALUES (4, N'WH4', N'HUGE MATERIALS ZONE')
INSERT [dbo].[Zone] ([Id], [Name], [Description]) VALUES (5, N'WH5', N'EVERY MONTHS ISSUE')
INSERT [dbo].[Zone] ([Id], [Name], [Description]) VALUES (6, N'WH6', N'INSIDE FACTORY')
SET IDENTITY_INSERT [dbo].[Zone] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UIdx_CostAccount_Name]    Script Date: 4/4/2022 4:36:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UIdx_CostAccount_Name] ON [dbo].[CostAccount]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UIdx_Employee_Code]    Script Date: 4/4/2022 4:36:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UIdx_Employee_Code] ON [dbo].[Employee]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UIdx_Material_QCode]    Script Date: 4/4/2022 4:36:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UIdx_Material_QCode] ON [dbo].[Material]
(
	[QCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UIdx_Zone_Name]    Script Date: 4/4/2022 4:36:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UIdx_Zone_Name] ON [dbo].[Zone]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExportHistory] ADD  DEFAULT (getdate()) FOR [ExportDate]
GO
ALTER TABLE [dbo].[ExportHistory] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CostAccountItem]  WITH CHECK ADD  CONSTRAINT [Fk_CostAccountItem_CostAccount] FOREIGN KEY([CostAccount])
REFERENCES [dbo].[CostAccount] ([Id])
GO
ALTER TABLE [dbo].[CostAccountItem] CHECK CONSTRAINT [Fk_CostAccountItem_CostAccount]
GO
ALTER TABLE [dbo].[ExportHistory]  WITH CHECK ADD  CONSTRAINT [Fk_ExportHistory_Handler] FOREIGN KEY([Handler])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ExportHistory] CHECK CONSTRAINT [Fk_ExportHistory_Handler]
GO
ALTER TABLE [dbo].[ExportHistory]  WITH CHECK ADD  CONSTRAINT [Fk_ExportHistory_Material] FOREIGN KEY([Material])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[ExportHistory] CHECK CONSTRAINT [Fk_ExportHistory_Material]
GO
ALTER TABLE [dbo].[ExportHistory]  WITH CHECK ADD  CONSTRAINT [Fk_ExportHistory_Receiver] FOREIGN KEY([Receiver])
REFERENCES [dbo].[Line] ([Id])
GO
ALTER TABLE [dbo].[ExportHistory] CHECK CONSTRAINT [Fk_ExportHistory_Receiver]
GO
ALTER TABLE [dbo].[ImportHistory]  WITH CHECK ADD  CONSTRAINT [Fk_ImportHistory_Handler] FOREIGN KEY([Handler])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[ImportHistory] CHECK CONSTRAINT [Fk_ImportHistory_Handler]
GO
ALTER TABLE [dbo].[ImportHistory]  WITH CHECK ADD  CONSTRAINT [Fk_ImportHistory_LineRequest] FOREIGN KEY([LineRequest])
REFERENCES [dbo].[Line] ([Id])
GO
ALTER TABLE [dbo].[ImportHistory] CHECK CONSTRAINT [Fk_ImportHistory_LineRequest]
GO
ALTER TABLE [dbo].[ImportHistory]  WITH CHECK ADD  CONSTRAINT [Fk_ImportHistory_Material] FOREIGN KEY([Material])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[ImportHistory] CHECK CONSTRAINT [Fk_ImportHistory_Material]
GO
ALTER TABLE [dbo].[Inspection]  WITH CHECK ADD  CONSTRAINT [Fk_Inspection_ImportHistory] FOREIGN KEY([ImportId])
REFERENCES [dbo].[ImportHistory] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inspection] CHECK CONSTRAINT [Fk_Inspection_ImportHistory]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [Fk_Material_Unit] FOREIGN KEY([Unit])
REFERENCES [dbo].[Unit] ([Id])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [Fk_Material_Unit]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [Fk_Material_Zone] FOREIGN KEY([Zone])
REFERENCES [dbo].[Zone] ([Id])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [Fk_Material_Zone]
GO
ALTER TABLE [dbo].[ExportHistory]  WITH CHECK ADD CHECK  (([Price]>(0)))
GO
ALTER TABLE [dbo].[ExportHistory]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[ImportHistory]  WITH CHECK ADD CHECK  (([Price]>(0)))
GO
ALTER TABLE [dbo].[ImportHistory]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
USE [master]
GO
ALTER DATABASE [WarehouseManagement] SET  READ_WRITE 
GO

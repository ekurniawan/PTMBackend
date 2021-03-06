USE [master]
GO
/****** Object:  Database [PTMDb]    Script Date: 10/19/2016 3:44:37 PM ******/
CREATE DATABASE [PTMDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PTMDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PTMDb.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PTMDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PTMDb_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PTMDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PTMDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PTMDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PTMDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PTMDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PTMDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PTMDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PTMDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PTMDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PTMDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PTMDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PTMDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PTMDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PTMDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PTMDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PTMDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PTMDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PTMDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PTMDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PTMDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PTMDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PTMDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PTMDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PTMDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PTMDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PTMDb] SET  MULTI_USER 
GO
ALTER DATABASE [PTMDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PTMDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PTMDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PTMDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PTMDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PTMDb]
GO
/****** Object:  Table [dbo].[COIDetail]    Script Date: 10/19/2016 3:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COIDetail](
	[COINumber] [varchar](50) NOT NULL,
	[PolNumber] [varchar](50) NULL,
	[IdTipeStatus] [int] NOT NULL,
	[DestinationPort] [varchar](50) NULL,
	[VesselName] [varchar](50) NULL,
 CONSTRAINT [PK_COIDetail] PRIMARY KEY CLUSTERED 
(
	[COINumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Pengguna]    Script Date: 10/19/2016 3:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pengguna](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[IdTipeUser] [int] NOT NULL,
 CONSTRAINT [PK_Pengguna] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipeStatus]    Script Date: 10/19/2016 3:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipeStatus](
	[IdTipeStatus] [int] NOT NULL,
	[NamaTipe] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipeStatus] PRIMARY KEY CLUSTERED 
(
	[IdTipeStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipeUser]    Script Date: 10/19/2016 3:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipeUser](
	[IdTipeUser] [int] NOT NULL,
	[NamaTipe] [varchar](50) NOT NULL,
	[IsConfirm] [bit] NOT NULL,
	[IsRequest] [bit] NOT NULL,
	[IsReview] [bit] NOT NULL,
	[IsApprove] [bit] NOT NULL,
	[IsAccept] [bit] NOT NULL,
 CONSTRAINT [PK_TipeUser] PRIMARY KEY CLUSTERED 
(
	[IdTipeUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[COIDetail] ([COINumber], [PolNumber], [IdTipeStatus], [DestinationPort], [VesselName]) VALUES (N'111222', N'P009988', 1, N'Surabaya', N'Merah Delima')
INSERT [dbo].[COIDetail] ([COINumber], [PolNumber], [IdTipeStatus], [DestinationPort], [VesselName]) VALUES (N'444555', N'P99885577', 1, N'Jakarta', N'Sapphire')
INSERT [dbo].[COIDetail] ([COINumber], [PolNumber], [IdTipeStatus], [DestinationPort], [VesselName]) VALUES (N'889900', N'P0099887', 3, N'Surabaya', N'Cats Eye')
INSERT [dbo].[COIDetail] ([COINumber], [PolNumber], [IdTipeStatus], [DestinationPort], [VesselName]) VALUES (N'998877', N'P0987654', 2, N'Jakarta', N'Ruby')
INSERT [dbo].[Pengguna] ([Username], [Password], [IdTipeUser]) VALUES (N'dori', N'dori', 3)
INSERT [dbo].[Pengguna] ([Username], [Password], [IdTipeUser]) VALUES (N'erick', N'erick', 2)
INSERT [dbo].[TipeStatus] ([IdTipeStatus], [NamaTipe]) VALUES (1, N'Request')
INSERT [dbo].[TipeStatus] ([IdTipeStatus], [NamaTipe]) VALUES (2, N'Confirm')
INSERT [dbo].[TipeStatus] ([IdTipeStatus], [NamaTipe]) VALUES (3, N'Review')
INSERT [dbo].[TipeStatus] ([IdTipeStatus], [NamaTipe]) VALUES (4, N'Approve')
INSERT [dbo].[TipeStatus] ([IdTipeStatus], [NamaTipe]) VALUES (5, N'Accept')
INSERT [dbo].[TipeUser] ([IdTipeUser], [NamaTipe], [IsConfirm], [IsRequest], [IsReview], [IsApprove], [IsAccept]) VALUES (1, N'Inputer', 0, 0, 0, 0, 0)
INSERT [dbo].[TipeUser] ([IdTipeUser], [NamaTipe], [IsConfirm], [IsRequest], [IsReview], [IsApprove], [IsAccept]) VALUES (2, N'Confirmer', 1, 1, 0, 0, 0)
INSERT [dbo].[TipeUser] ([IdTipeUser], [NamaTipe], [IsConfirm], [IsRequest], [IsReview], [IsApprove], [IsAccept]) VALUES (3, N'Reviewer', 1, 1, 1, 0, 0)
INSERT [dbo].[TipeUser] ([IdTipeUser], [NamaTipe], [IsConfirm], [IsRequest], [IsReview], [IsApprove], [IsAccept]) VALUES (4, N'Appover', 0, 0, 1, 1, 0)
INSERT [dbo].[TipeUser] ([IdTipeUser], [NamaTipe], [IsConfirm], [IsRequest], [IsReview], [IsApprove], [IsAccept]) VALUES (5, N'Accepter', 0, 0, 0, 1, 1)
INSERT [dbo].[TipeUser] ([IdTipeUser], [NamaTipe], [IsConfirm], [IsRequest], [IsReview], [IsApprove], [IsAccept]) VALUES (6, N'Admin', 1, 1, 1, 1, 1)
ALTER TABLE [dbo].[COIDetail]  WITH CHECK ADD  CONSTRAINT [FK_COIDetail_TipeStatus] FOREIGN KEY([IdTipeStatus])
REFERENCES [dbo].[TipeStatus] ([IdTipeStatus])
GO
ALTER TABLE [dbo].[COIDetail] CHECK CONSTRAINT [FK_COIDetail_TipeStatus]
GO
ALTER TABLE [dbo].[Pengguna]  WITH CHECK ADD  CONSTRAINT [FK_Pengguna_TipeUser] FOREIGN KEY([IdTipeUser])
REFERENCES [dbo].[TipeUser] ([IdTipeUser])
GO
ALTER TABLE [dbo].[Pengguna] CHECK CONSTRAINT [FK_Pengguna_TipeUser]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllTipeStatus]    Script Date: 10/19/2016 3:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllTipeStatus]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from TipeStatus order by NamaTipe asc
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetByIdTipeStatus]    Script Date: 10/19/2016 3:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetByIdTipeStatus]
	-- Add the parameters for the stored procedure here
	@IdTipeStatus as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from TipeStatus 
    where IdTipeStatus=@IdTipeStatus
END

GO
USE [master]
GO
ALTER DATABASE [PTMDb] SET  READ_WRITE 
GO

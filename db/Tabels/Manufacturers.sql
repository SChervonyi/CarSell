USE [CarSell]
GO

/****** Object:  Table [dbo].[Manufacturers]    Script Date: 20.02.2016 20:09:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Manufacturers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_Manufacturer]
	DROP TABLE [dbo].[Manufacturers]
GO

/****** Object:  Table [dbo].[Manufacturers]    Script Date: 20.02.2016 20:09:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Manufacturers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



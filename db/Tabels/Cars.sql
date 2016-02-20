USE [CarSell]
GO

/****** Object:  Table [dbo].[Cars]    Script Date: 20.02.2016 20:07:54 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Cars]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	DROP TABLE [dbo].[Cars]
END
GO

/****** Object:  Table [dbo].[Cars]    Script Date: 20.02.2016 20:07:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Cars](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ManufacturerId] [bigint] NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Manufacturer] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturers] ([Id])
GO

ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Manufacturer]
GO



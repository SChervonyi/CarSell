USE [CarSell]
GO

/****** Object:  Table [dbo].[cars]    Script Date: 17.02.2016 11:11:07 ******/
DROP TABLE [dbo].[cars]
GO

/****** Object:  Table [dbo].[cars]    Script Date: 17.02.2016 11:11:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cars](
	[id] [bigint] NOT NULL,
	[manufacturer_id] [bigint] NOT NULL,
	[code] [varchar](10) NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [money] NULL,
 CONSTRAINT [PK_cars] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



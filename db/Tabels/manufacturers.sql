USE [CarSell]
GO

/****** Object:  Table [dbo].[manufacturers]    Script Date: 17.02.2016 11:11:48 ******/
DROP TABLE [dbo].[manufacturers]
GO

/****** Object:  Table [dbo].[manufacturers]    Script Date: 17.02.2016 11:11:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[manufacturers](
	[id] [bigint] NOT NULL,
	[code] [varchar](10) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_manufacturers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



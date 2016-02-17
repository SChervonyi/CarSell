USE [CarSell]
GO

/****** Object:  Table [dbo].[equipment]    Script Date: 17.02.2016 11:11:28 ******/
DROP TABLE [dbo].[equipment]
GO

/****** Object:  Table [dbo].[equipment]    Script Date: 17.02.2016 11:11:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[equipment](
	[id] [bigint] NOT NULL,
	[name] [nvarchar](50) NULL,
	[rate] [real] NULL,
 CONSTRAINT [PK_equipment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



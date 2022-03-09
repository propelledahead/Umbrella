USE [Umbrella]
GO

/****** Object:  Table [dbo].[products]    Script Date: 3/8/2022 11:00:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[products](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NULL,
	[product_description] [varchar](250) NULL,
	[cost] [decimal](16, 2) NULL,
	[record_created] [datetime] NULL,
	[record_updated] [datetime] NULL,
	[record_status] [tinyint] NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



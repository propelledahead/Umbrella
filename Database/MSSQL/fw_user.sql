USE [Umbrella]
GO

/****** Object:  Table [dbo].[fw_user]    Script Date: 3/8/2022 11:00:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[fw_user](
	[id] [uniqueidentifier] NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[name_first] [varchar](50) NULL,
	[name_last] [varchar](50) NULL,
	[email_address] [varchar](150) NULL,
	[record_created] [datetime] NULL,
	[record_updated] [datetime] NULL,
	[record_status] [tinyint] NULL,
 CONSTRAINT [PK_fw_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[fw_user] ADD  CONSTRAINT [DF_fw_user_record_created]  DEFAULT (getdate()) FOR [record_created]
GO

ALTER TABLE [dbo].[fw_user] ADD  CONSTRAINT [DF_fw_user_record_updated]  DEFAULT (getdate()) FOR [record_updated]
GO

ALTER TABLE [dbo].[fw_user] ADD  CONSTRAINT [DF_fw_user_record_status]  DEFAULT ((1)) FOR [record_status]
GO



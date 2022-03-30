USE [Umbrella]
GO

/****** Object:  Table [dbo].[fw_user_role]    Script Date: 3/8/2022 11:00:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[fw_user_role](
	[id_user] [uniqueidentifier] NOT NULL,
	[id_role] [uniqueidentifier] NOT NULL,
	[record_created] [datetime] NULL,
	[record_updated] [datetime] NULL,
	[record_status] [tinyint] NULL,
 CONSTRAINT [PK_fw_user_role] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[fw_user_role] ADD  CONSTRAINT [DF_fw_user_role_record_created]  DEFAULT (getdate()) FOR [record_created]
GO

ALTER TABLE [dbo].[fw_user_role] ADD  CONSTRAINT [DF_fw_user_role_record_updated]  DEFAULT (getdate()) FOR [record_updated]
GO

ALTER TABLE [dbo].[fw_user_role] ADD  CONSTRAINT [DF_fw_user_role_record_status]  DEFAULT ((1)) FOR [record_status]
GO



USE [Umbrella]
GO

/****** Object:  Table [dbo].[fw_auth_providers]    Script Date: 3/8/2022 10:55:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[fw_auth_providers](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[record_created] [datetime] NULL,
	[record_updated] [datetime] NULL,
	[record_status] [tinyint] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[fw_auth_providers] ADD  CONSTRAINT [DF_fw_auth_providers_record_created]  DEFAULT (getdate()) FOR [record_created]
GO

ALTER TABLE [dbo].[fw_auth_providers] ADD  CONSTRAINT [DF_fw_auth_providers_record_updated]  DEFAULT (getdate()) FOR [record_updated]
GO

ALTER TABLE [dbo].[fw_auth_providers] ADD  CONSTRAINT [DF_fw_auth_providers_record_status]  DEFAULT ((1)) FOR [record_status]
GO



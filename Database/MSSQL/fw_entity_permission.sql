USE [Umbrella]
GO

/****** Object:  Table [dbo].[fw_entity_permission]    Script Date: 3/8/2022 10:59:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[fw_entity_permission](
	[entity_id] [uniqueidentifier] NOT NULL,
	[entity_type_id] [int] NOT NULL,
	[permission_id] [uniqueidentifier] NOT NULL,
	[record_created] [datetime] NULL,
	[record_updated] [datetime] NULL,
	[record_status] [tinyint] NULL,
 CONSTRAINT [PK_fw_entity_permission] PRIMARY KEY CLUSTERED 
(
	[entity_id] ASC,
	[permission_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[fw_entity_permission] ADD  CONSTRAINT [DF_fw_entity_permission_record_created]  DEFAULT (getdate()) FOR [record_created]
GO

ALTER TABLE [dbo].[fw_entity_permission] ADD  CONSTRAINT [DF_fw_entity_permission_record_updated]  DEFAULT (getdate()) FOR [record_updated]
GO

ALTER TABLE [dbo].[fw_entity_permission] ADD  CONSTRAINT [DF_fw_entity_permission_record_status]  DEFAULT ((1)) FOR [record_status]
GO



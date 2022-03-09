USE [Umbrella]
GO

/****** Object:  Table [dbo].[fw_permission]    Script Date: 3/8/2022 10:59:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[fw_permission](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](100) NOT NULL,
	[controller_name] [varchar](50) NULL,
	[action_result] [varchar](50) NULL,
	[record_created] [datetime] NULL,
	[record_updated] [datetime] NULL,
	[record_status] [tinyint] NULL,
 CONSTRAINT [PK_fw_permission] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[fw_permission] ADD  CONSTRAINT [DF_fw_permission_record_created]  DEFAULT (getdate()) FOR [record_created]
GO

ALTER TABLE [dbo].[fw_permission] ADD  CONSTRAINT [DF_fw_permission_record_updated]  DEFAULT (getdate()) FOR [record_updated]
GO

ALTER TABLE [dbo].[fw_permission] ADD  CONSTRAINT [DF_fw_permission_record_status]  DEFAULT ((1)) FOR [record_status]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'freiendly name of the permission' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fw_permission', @level2type=N'COLUMN',@level2name=N'name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'controller name is the name of the module in the project' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fw_permission', @level2type=N'COLUMN',@level2name=N'controller_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'the name of the endpoint aka. the action result' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fw_permission', @level2type=N'COLUMN',@level2name=N'action_result'
GO



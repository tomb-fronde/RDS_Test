/****** Object:  Table [rd].[user_groups]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[user_groups](
	[gp_code] [numeric](10, 0) NOT NULL,
	[gp_title] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[gp_cargo] [varchar](255) COLLATE Latin1_General_CI_AS NULL,
	[gp_created_date] [datetime] NULL,
	[gp_created_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[gp_modified_date] [datetime] NULL,
	[gp_modified_by] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[gp_level_1] [numeric](2, 0) NULL,
	[gp_level_2] [numeric](2, 0) NULL,
	[gp_level_3] [numeric](2, 0) NULL,
	[gp_level_4] [numeric](2, 0) NULL,
	[gp_level_5] [numeric](2, 0) NULL,
	[gp_level_6] [numeric](2, 0) NULL,
	[gp_level_7] [numeric](2, 0) NULL,
	[gp_level_8] [numeric](2, 0) NULL,
	[gp_level_9] [numeric](2, 0) NULL,
	[gp_odps] [numeric](2, 0) NULL,
	[gp_payrun] [numeric](2, 0) NULL,
 CONSTRAINT [user_groups_cns] PRIMARY KEY CLUSTERED 
(
	[gp_code] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

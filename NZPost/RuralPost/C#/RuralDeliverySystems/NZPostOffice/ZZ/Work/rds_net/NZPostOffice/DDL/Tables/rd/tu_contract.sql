/****** Object:  Table [rd].[tu_contract]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[tu_contract](
	[rg_code] [int] NULL,
	[con_title] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[con_rd_paper_file_text] [int] NULL,
	[con_active_sequence] [smallint] NOT NULL,
	[regionid] [int] NULL,
	[con_old_mail_service_no] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[cac_id] [int] NULL,
	[cpbu_id] [int] NULL,
	[cct_key] [int] NULL,
	[contractno] [int] NULL,
	[rc_name] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[con_base_office] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

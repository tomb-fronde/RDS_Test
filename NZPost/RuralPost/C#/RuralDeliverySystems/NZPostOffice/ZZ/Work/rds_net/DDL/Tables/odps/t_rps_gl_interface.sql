/****** Object:  Table [odps].[t_rps_gl_interface]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[t_rps_gl_interface](
	[entity_id_1] [varchar](5) COLLATE Latin1_General_CI_AS NULL,
	[journal_id_2] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[effective_date_3] [datetime] NULL,
	[journal_sequence_4] [int] NULL,
	[line_entity_id_6] [varchar](5) COLLATE Latin1_General_CI_AS NULL,
	[rc_number_7] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[account_number_8] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
	[product_code_9] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[analysis_code_10] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[primary_dr_cr_code_11] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[transaction_amount_12] [numeric](30, 6) NULL,
	[misc_cr_dr_code_13] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[misc_amount_14] [smallint] NULL,
	[jrnl_user_alpha_fld_15] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[date_created_16] [datetime] NULL,
	[description_17] [varchar](100) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

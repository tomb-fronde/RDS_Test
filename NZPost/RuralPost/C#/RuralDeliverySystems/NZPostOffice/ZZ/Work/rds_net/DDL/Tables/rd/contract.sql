/****** Object:  Table [rd].[contract]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract](
	[contract_no] [int] NOT NULL,
	[rg_code] [int] NULL,
	[con_old_mail_service_no] [varchar](6) COLLATE Latin1_General_CI_AS NULL,
	[con_title] [varchar](60) COLLATE Latin1_General_CI_AS NULL,
	[con_rd_paper_file_text] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[con_rcm_paper_file_text] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[con_base_office] [int] NULL,
	[con_lodgement_office] [int] NULL,
	[con_active_sequence] [int] NULL,
	[con_base_cont_type] [int] NULL,
	[con_rd_ref_text] [varchar](35) COLLATE Latin1_General_CI_AS NULL,
	[con_last_service_review] [datetime] NULL,
	[con_last_delivery_check] [datetime] NULL,
	[con_last_work_msrmnt_check] [datetime] NULL,
	[con_lngth_sealed_road] [int] NULL,
	[con_lngth_unsealed_road] [int] NULL,
	[con_date_terminated] [datetime] NULL,
	[con_date_last_prt_for_od] [datetime] NULL,
	[__________] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[ac_id] [int] NULL,
	[message_for_invoice] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[PBU_ID] [int] NULL,
	[cust_list_printed] [datetime] NULL,
	[cust_list_updated] [datetime] NULL,
 CONSTRAINT [contract_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

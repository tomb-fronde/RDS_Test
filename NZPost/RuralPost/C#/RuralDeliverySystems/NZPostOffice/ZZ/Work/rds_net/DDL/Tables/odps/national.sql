/****** Object:  Table [odps].[national]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [odps].[national](
	[nat_id] [int] IDENTITY(124,1) NOT NULL,
	[ac_id] [int] NULL,
	[nat_ac_id_gst_GL] [int] NULL,
	[nat_ac_id_whtax_GL] [int] NULL,
	[nat_ac_id_postax_adj_GL] [int] NULL,
	[nat_rural_post_gst_no] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[nat_gst_rate] [decimal](5, 2) NULL,
	[nat_ird_no] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[nat_rural_post_address] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[nat_rural_post_payer_name] [varchar](200) COLLATE Latin1_General_CI_AS NULL,
	[nat_acc_percentage] [decimal](5, 2) NULL,
	[nat_standard_tax_rate] [decimal](5, 2) NULL,
	[nat_day_of_month] [smallint] NULL,
	[nat_message_for_invoice] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[nat_net_pct_change_warn] [decimal](6, 2) NULL,
	[nat_seq_no_for_keys] [int] NULL,
	[nat_od_standard_gst_rate] [decimal](10, 2) NULL,
	[nat_od_tax_rate_ir13] [decimal](10, 2) NULL,
	[nat_od_tax_rate_no_ir13] [decimal](10, 2) NULL,
	[ap_net_pay_clearing_account] [int] NULL,
	[nat_effective_date] [datetime] NOT NULL,
	[nat_ac_id_contprice_GL] [int] NULL,
	[nat_ac_id_NetPay_GL] [int] NULL,
	[nat_ac_id_AccrualBalance_GL] [int] NULL,
	[nat_PBU_code_postax_GL] [int] NULL,
	[nat_PBU_code_whtax_GL] [int] NULL,
	[nat_PBU_code_GST_GL] [int] NULL,
	[nat_PBU_code_NetPay_GL] [int] NULL,
	[nat_Invoice_Number_Prefix] [varchar](20) COLLATE Latin1_General_CI_AS NULL,
	[______] [varbinary](1) NULL,
	[nat_PBU_code_AccrualBalance_GL] [int] NULL,
	[nat_FreqAdj_DefaultCompType] [int] NULL,
	[nat_ContAdj_DefaultCompType] [int] NULL,
	[nat_ContAllow_DefaultComptype] [int] NULL,
	[nat_Deductions_DefaultComptype] [int] NULL,
	[nat_CourierPost_DefaultComptype] [int] NULL,
	[nat_AdPost_DefaultComptype] [int] NULL,
	[nat_xp_defaultcomptype] [int] NULL,
	[nat_pp_defaultcomptype] [int] NULL,
 CONSTRAINT [national(primary key)] PRIMARY KEY CLUSTERED 
(
	[nat_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

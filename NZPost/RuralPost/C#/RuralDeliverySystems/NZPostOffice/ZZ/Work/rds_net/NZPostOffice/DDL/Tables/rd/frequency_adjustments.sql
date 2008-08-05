/****** Object:  Table [rd].[frequency_adjustments]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[frequency_adjustments](
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[fd_unique_seq_number] [int] NOT NULL,
	[fd_adjustment_amount] [numeric](10, 2) NULL,
	[fd_paid_to_date] [datetime] NULL,
	[fd_bm_after_extn] [numeric](10, 2) NULL,
	[fd_confirmed] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[fd_amount_to_pay] [numeric](10, 2) NULL,
	[fd_effective_date] [datetime] NULL,
	[pct_id] [int] NULL,
	[sf_key] [int] NULL,
	[rf_delivery_days] [varchar](7) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [frequency_adjustments_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[contract_seq_number] ASC,
	[fd_unique_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

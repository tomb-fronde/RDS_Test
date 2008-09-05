/****** Object:  Table [rd].[artical_count]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[artical_count](
	[contract_no] [int] NOT NULL,
	[ac_start_week_period] [datetime] NOT NULL,
	[contract_seq_number] [int] NULL,
	[ac_w1_medium_letters] [int] NULL,
	[ac_w1_other_envelopes] [int] NULL,
	[ac_w1_small_parcels] [int] NULL,
	[ac_w1_large_parcels] [int] NULL,
	[ac_w1_inward_mail] [int] NULL,
	[ac_w2_medium_letters] [int] NULL,
	[ac_w2_other_envelopes] [int] NULL,
	[ac_w2_small_parcels] [int] NULL,
	[ac_w2_large_parcels] [int] NULL,
	[ac_w2_inward_mail] [int] NULL,
	[ac_scale_factor] [numeric](10, 6) NULL,
 CONSTRAINT [artical_count_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[ac_start_week_period] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [rd].[mail_carried]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[mail_carried](
	[sf_key] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[mc_sequence_no] [int] NOT NULL,
	[rf_delivery_days] [varchar](7) COLLATE Latin1_General_CI_AS NOT NULL,
	[mc_dispatch_carried] [varchar](40) COLLATE Latin1_General_CI_AS NULL,
	[mc_uplift_time] [datetime] NULL,
	[mc_uplift_outlet] [int] NULL,
	[mc_set_down_time] [datetime] NULL,
	[mc_set_down_outlet] [int] NULL,
	[mc_disbanded_date] [datetime] NULL,
	[mc_set_down_next_day] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [mail_carried_cns] PRIMARY KEY CLUSTERED 
(
	[sf_key] ASC,
	[contract_no] ASC,
	[mc_sequence_no] ASC,
	[rf_delivery_days] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

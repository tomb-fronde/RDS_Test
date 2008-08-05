/****** Object:  Table [rd].[rate_days]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[rate_days](
	[rg_code] [int] NOT NULL,
	[rr_rates_effective_date] [datetime] NOT NULL,
	[sf_key] [int] NOT NULL,
	[rtd_days_per_annum] [int] NULL,
 CONSTRAINT [rate_days_cns] PRIMARY KEY CLUSTERED 
(
	[rg_code] ASC,
	[rr_rates_effective_date] ASC,
	[sf_key] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

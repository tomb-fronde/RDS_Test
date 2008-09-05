/****** Object:  Table [rd].[misc_rate]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[misc_rate](
	[rg_code] [int] NOT NULL,
	[mr_effective_date] [datetime] NOT NULL,
	[mr_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[mr_value] [numeric](9, 2) NULL,
	[mr_km_flag] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[mr_annual_flag] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [misc_rate_cns] PRIMARY KEY CLUSTERED 
(
	[rg_code] ASC,
	[mr_effective_date] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

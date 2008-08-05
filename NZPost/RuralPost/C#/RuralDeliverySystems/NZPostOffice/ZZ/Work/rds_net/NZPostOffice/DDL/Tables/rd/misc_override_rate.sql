/****** Object:  Table [rd].[misc_override_rate]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[misc_override_rate](
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[mor_name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[mor_value] [numeric](9, 2) NULL,
	[mor_km_flag] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[mor_annual_flag] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [misc_override_rate_cns] PRIMARY KEY CLUSTERED 
(
	[contract_no] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

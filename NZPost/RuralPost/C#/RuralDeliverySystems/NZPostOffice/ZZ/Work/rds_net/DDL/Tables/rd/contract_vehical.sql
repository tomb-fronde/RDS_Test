/****** Object:  Table [rd].[contract_vehical]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[contract_vehical](
	[vehicle_number] [int] NOT NULL,
	[contract_no] [int] NOT NULL,
	[contract_seq_number] [int] NOT NULL,
	[start_kms] [int] NULL,
	[vehicle_allowance_paid_to_date] [numeric](10, 2) NULL,
	[cv_vehical_status] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
	[signage_compliant] [varchar](1) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [contract_vehical_cns] PRIMARY KEY CLUSTERED 
(
	[vehicle_number] ASC,
	[contract_no] ASC,
	[contract_seq_number] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

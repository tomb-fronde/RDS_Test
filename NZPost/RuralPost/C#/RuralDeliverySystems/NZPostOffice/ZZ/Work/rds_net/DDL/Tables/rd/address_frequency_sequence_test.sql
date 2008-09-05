/****** Object:  Table [rd].[address_frequency_sequence_test]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [rd].[address_frequency_sequence_test](
	[adr_id] [int] NOT NULL,
	[sf_key] [int] NOT NULL,
	[rf_delivery_days] [varchar](7) COLLATE Latin1_General_CI_AS NOT NULL,
	[contract_no] [int] NOT NULL,
	[seq_num] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [rd].[contract_cust_transfer]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[contract_cust_transfer](
	[to_contract_no] [int] NOT NULL,
	[from_contract_no] [int] NOT NULL,
	[transfer_date] [datetime] NOT NULL
) ON [PRIMARY]

GO

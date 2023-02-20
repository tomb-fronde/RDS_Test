/****** Object:  Table [rd].[customer_interest]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[customer_interest](
	[cust_id] [int] NOT NULL,
	[interest_id] [int] NOT NULL,
 CONSTRAINT [customer_interest_cns] PRIMARY KEY CLUSTERED 
(
	[cust_id] ASC,
	[interest_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

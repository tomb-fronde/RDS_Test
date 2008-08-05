/****** Object:  Table [rd].[private_bags]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[private_bags](
	[pvt_date] [datetime] NOT NULL DEFAULT (getdate()),
	[pvt_bag_count] [int] NOT NULL,
	[pvt_frequency] [int] NOT NULL,
	[region_id] [int] NULL,
 CONSTRAINT [private_bags_cns] PRIMARY KEY CLUSTERED 
(
	[pvt_date] ASC,
	[pvt_frequency] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

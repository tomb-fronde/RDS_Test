/****** Object:  Table [rd].[address_geocode]    Script Date: 08/05/2008 15:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[address_geocode](
	[adr_id] [int] NOT NULL,
	[external_system_id] [int] NULL DEFAULT ((1)),
	[geocode_x] [numeric](10, 2) NOT NULL,
	[geocode_y] [numeric](10, 2) NOT NULL,
 CONSTRAINT [address_geocode_cns] PRIMARY KEY CLUSTERED 
(
	[adr_id] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

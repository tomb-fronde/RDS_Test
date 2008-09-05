/****** Object:  Table [rd].[tmp_address_geocode]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[tmp_address_geocode](
	[adr_id] [int] NOT NULL,
	[geocode_x] [numeric](10, 2) NULL,
	[geocode_y] [numeric](10, 2) NULL
) ON [PRIMARY]

GO

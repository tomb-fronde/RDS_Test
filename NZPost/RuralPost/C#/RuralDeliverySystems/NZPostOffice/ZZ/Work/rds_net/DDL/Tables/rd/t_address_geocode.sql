/****** Object:  Table [rd].[t_address_geocode]    Script Date: 08/05/2008 15:01:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [rd].[t_address_geocode](
	[adr_id] [int] NOT NULL,
	[external_system_id] [int] NOT NULL,
	[geocode_x] [decimal](8, 2) NOT NULL,
	[geocode_y] [decimal](8, 2) NOT NULL
) ON [PRIMARY]

GO

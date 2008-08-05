/****** Object:  StoredProcedure [rd].[sp_DDDW_PieceRateSuppliers]    Script Date: 08/05/2008 10:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_PieceRateSuppliers : 
--

create procedure [rd].[sp_DDDW_PieceRateSuppliers]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select prs_key,
    prs_description from
    piece_rate_supplier
end
GO

/****** Object:  StoredProcedure [rd].[sp_DDDW_PieceRates]    Script Date: 08/05/2008 10:18:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_DDDW_PieceRates : 
--

create procedure [rd].[sp_DDDW_PieceRates]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select prt_key,
    prt_code + ' (' + prt_description + ')',
    prs_description from
    piece_rate_type join piece_rate_supplier on piece_rate_type.prs_key = piece_rate_supplier.prs_key
end
GO

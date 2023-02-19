
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
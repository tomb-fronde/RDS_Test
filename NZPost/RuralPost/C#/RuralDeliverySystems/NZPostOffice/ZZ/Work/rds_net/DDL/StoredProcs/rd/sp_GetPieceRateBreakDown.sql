/****** Object:  StoredProcedure [rd].[sp_GetPieceRateBreakDown]    Script Date: 08/05/2008 10:20:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[sp_GetPieceRateBreakDown](
@in_Contract int,
@in_Supplier int,
@in_Date datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select (piece_rate_type.prt_code + ' (' + piece_rate_type.prt_description + ')') as piece_rate_description,
    piece_rate_delivery.prd_cost,
    piece_rate_delivery.prd_quantity 
  from
    piece_rate join piece_rate_type on piece_rate.prt_key=piece_rate_type.prt_key
		join piece_rate_delivery on piece_rate_type.prt_key=piece_rate_delivery.prt_key
		 join contract on piece_rate_delivery.contract_no=contract.contract_no where
    piece_rate.rg_code = contract.rg_code and
    piece_rate_delivery.prd_date = @in_Date and
    piece_rate_type.prs_key = @in_Supplier and
    piece_rate_delivery.contract_no = @in_Contract and
    piece_rate.pr_effective_date = 
    (select max(pr.pr_effective_date) from
      piece_rate as pr where
      pr.prt_key = piece_rate.prt_key and
      pr.pr_effective_date <= @in_Date and
      pr.rg_code = contract.rg_code) order by piece_rate_description asc
end
GO

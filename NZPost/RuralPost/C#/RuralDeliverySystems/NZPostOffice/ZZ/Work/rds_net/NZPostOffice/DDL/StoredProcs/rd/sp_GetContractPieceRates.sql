/****** Object:  StoredProcedure [rd].[sp_GetContractPieceRates]    Script Date: 08/05/2008 10:19:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[sp_GetContractPieceRates](@in_Contract int,@in_RetrieveType char(1),@in_DateStart datetime,@in_DateEnd datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select piece_rate_delivery.prd_date,
    piece_rate_type.prs_key,
    piece_rate_quantity=sum(piece_rate_delivery.prd_quantity),
    piece_rate_cost=sum(piece_rate_delivery.prd_cost) from
    piece_rate join piece_rate_type  on piece_rate.prt_key=piece_rate_type.prt_key
	 join piece_rate_delivery  on piece_rate_type.prt_key=piece_rate_delivery.prt_key
		join contract on contract.contract_no=piece_rate_delivery.contract_no where
    piece_rate.rg_code = contract.rg_code and
    piece_rate_delivery.contract_no = @in_Contract and
    (@in_RetrieveType = 'A' or piece_rate_delivery.prd_date between @in_DateStart and @in_DateEnd) and
    piece_rate.pr_effective_date = 
    (select max(pr.pr_effective_date) from
      piece_rate as pr where
      pr.prt_key = piece_rate.prt_key and
      pr.pr_effective_date <= piece_rate_delivery.prd_date and
      pr.rg_code = contract.rg_code)
    group by piece_rate_delivery.prd_date,
    piece_rate_type.prs_key order by piece_rate_delivery.prd_date desc,
    piece_rate_type.prs_key asc
end
GO


--
-- Definition for stored procedure sp_GetContractPieceRatesODPS : 
--
/*
EXEC [rd].[sp_GetContractPieceRatesODPS]
	@in_Contract = 5008,
	@in_RetrieveType = '',
	@in_DateStart = '21-May-2013',
	@in_DateEnd = '20-Jun-2013'
*/
CREATE procedure [rd].[sp_GetContractPieceRatesODPS](
	@in_Contract int,
	@in_RetrieveType char(1),
	@in_DateStart datetime,
	@in_DateEnd datetime)
AS
BEGIN
  -- TJB  RPCR_054  July-2013
  -- Removed extraneous code that prevented most renewal
  -- piecerates from being selected
  set CONCAT_NULL_YIELDS_NULL off

  declare @maxratedate datetime,
          @maxdeldate datetime

  if @in_RetrieveType = 'A'
    begin
      select @maxdeldate=max(piece_rate_delivery.prd_paid_to_date)
        from piece_rate_delivery 
       where piece_rate_delivery.contract_no = @in_Contract
       
      select @maxratedate=max(pr.pr_effective_date) 
        from piece_rate as pr,
             contract 
       where pr.pr_effective_date <= @maxdeldate and
             pr.rg_code = contract.rg_code and
             contract.contract_no = @in_Contract
             
      select piece_rate_delivery.prd_date,
             piece_rate_type.prs_key,
             piece_rate_quantity=sum(piece_rate_delivery.prd_quantity),
             piece_rate_cost=sum(piece_rate_delivery.prd_cost),
             paid_to_date=piece_rate_delivery.prd_paid_to_date 
        from piece_rate_delivery
           , piece_rate_type
           --, piece_rate as pr1
           --, contract 
       where piece_rate_delivery.contract_no = @in_Contract 
         and piece_rate_type.prt_key = piece_rate_delivery.prt_key 
         --and piece_rate_type.prt_key = pr1.prt_key 
         --and contract.contract_no = piece_rate_delivery.contract_no 
         --and pr1.rg_code = contract.rg_code 
         --and pr1.prt_key = piece_rate_delivery.prt_key 
         --and pr1.pr_effective_date -- = @maxratedate
         --           = (select max(pr2.pr_effective_date) 
         --                from piece_rate as pr2, contract 
         --               where pr2.pr_effective_date <= @maxdeldate 
         --                 and pr2.rg_code = contract.rg_code 
         --                 and contract.contract_no = @in_Contract
         --                 and pr2.prt_key = pr1.prt_key)
       group by 
             piece_rate_delivery.prd_date,
             piece_rate_type.prs_key,
             prd_paid_to_date 
       order by
             piece_rate_delivery.prd_date desc,
             piece_rate_type.prs_key asc
    end
  else
    begin
      select @maxdeldate=max(piece_rate_delivery.prd_paid_to_date) 
        from piece_rate_delivery 
       where piece_rate_delivery.contract_no = @in_Contract and
             piece_rate_delivery.prd_date <= @in_DateEnd

      select @maxratedate=max(pr.pr_effective_date)  
        from piece_rate as pr,
             contract 
       where pr.pr_effective_date <= @maxdeldate and
             pr.rg_code = contract.rg_code and
             contract.contract_no = @in_Contract

      select piece_rate_delivery.prd_date,
             piece_rate_type.prs_key,
             piece_rate_quantity=sum(piece_rate_delivery.prd_quantity),
             piece_rate_cost=sum(piece_rate_delivery.prd_cost),
             paid_to_date=piece_rate_delivery.prd_paid_to_date 
        from piece_rate_delivery
           , piece_rate_type
           --, piece_rate
           --, contract 
       where piece_rate_delivery.contract_no = @in_Contract 
         --and piece_rate_type.prt_key = piece_rate.prt_key 
         and piece_rate_type.prt_key = piece_rate_delivery.prt_key 
         --and contract.contract_no = piece_rate_delivery.contract_no 
         --and piece_rate.rg_code = contract.rg_code 
         --and piece_rate.prt_key = piece_rate_delivery.prt_key 
         --and piece_rate.pr_effective_date = @maxratedate 
         and piece_rate_delivery.prd_date between @in_DateStart and @in_DateEnd
       group by 
             piece_rate_delivery.prd_date,
             piece_rate_type.prs_key,
             prd_paid_to_date 
       order by
             piece_rate_delivery.prd_date desc,
             piece_rate_type.prs_key asc
    end
end
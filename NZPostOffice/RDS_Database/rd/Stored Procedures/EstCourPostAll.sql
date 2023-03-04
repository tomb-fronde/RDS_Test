

--
-- Definition for stored procedure EstCourPostAll : 
--

create procedure  [rd].[EstCourPostAll](@inAll int,@inRegion int,@inRenGroup int,@inContractType int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- 14/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
  -- sql code.  Used the corresponding piece_rate_suplier.prs_key instead.
  declare @decAmount real,
  @StartDate datetime,
  @EndDate datetime
    select @StartDate=rd.getFirstDayofMonth(dateadd(day,-125,rd.getLastDayofMonth(getdate())))
 
  select @EndDate=rd.getLastDayofMonth(dateadd(day,-32,rd.getLastDayofMonth(getdate())))
    
  if @inAll <> 1
    insert into RCMStatPR2(Region_id,CourpostCost,CourpostVol)
      select 0,
        (sum(case when isnull(piece_rate_delivery.prd_quantity,0)=0 then 0 else piece_rate_delivery.prd_quantity*isnull(piece_rate.pr_rate,0)end))*3,
        (sum(isnull(piece_rate_delivery.prd_quantity,0)))*3 from
        piece_rate,
        piece_rate_delivery,
        piece_rate_supplier,
        piece_rate_type,
        contract,
        outlet,
        renewal_group,
        contract_renewals where
        (piece_rate.prt_key = piece_rate_delivery.prt_key) and
        (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
        (piece_rate_type.prt_key = piece_rate_delivery.prt_key) and
        (piece_rate_type.prt_key = piece_rate.prt_key) and
        (contract.contract_no = piece_rate_delivery.contract_no) and
        (outlet.outlet_id = contract.con_base_office) and
        (renewal_group.rg_code = contract.rg_code) and
        (renewal_group.rg_code = piece_rate.rg_code) and
        (piece_rate.pr_effective_date = (select MAX(PR.pr_effective_date) from piece_rate as PR where pr.prt_key = piece_rate.prt_key and pr.rg_code = piece_rate.rg_code)) and
        (piece_rate_delivery.prd_date between @StartDate and @EndDate) and
        (piece_rate_supplier.prs_key = 2) and
        (contract_renewals.contract_no = contract.contract_no) and
        (contract_renewals.contract_seq_number = contract.con_active_sequence) and
        ((contract.con_base_cont_type = @inContractType and @inContractType > 0) or
        (@inContractType = 0 or @inContractType is null))
  else
    insert into RCMStatPR2(Region_id,CourpostCost,CourpostVol)
      select 0,sum(CourpostCost),sum(CourpostVol) from RCMStatPR2
  return(@inregion)
end
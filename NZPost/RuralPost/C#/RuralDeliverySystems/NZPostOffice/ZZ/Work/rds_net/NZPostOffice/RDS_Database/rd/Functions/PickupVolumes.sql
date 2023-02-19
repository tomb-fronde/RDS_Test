
create function [rd].[PickupVolumes](@inRegion int,@inOutlet int,@inRenGroup int,@inContractType int)
RETURNS numeric(12,2)
AS
BEGIN

  declare @dReturn numeric(12,2),
  @dTotal numeric(12,2)
--  create table #avg_temp(
--    inward_avg float null,
--    con_num int null,
--    )
  /* Watcom only
    local temporary table avg_temp(
    inward_avg double null,
    con_num int null,
    ) on commit delete rows
  */ -- take average - to avoid contracts with more than one entry being recorded twice
select @dTotal = sum(inward_avg) from 
(
    select 
inward_avg = avg((isnull(ac.ac_w2_inward_mail,0)+isnull(ac.ac_w1_inward_mail,0))*ac.ac_scale_factor),
con_num = ac.contract_no 
from
      artical_count as ac,contract as con join contract_renewals as cr on con.contract_no = cr.contract_no,outlet as outl where
      ac.contract_no = con.contract_no and
      ac.contract_seq_number = con.con_active_sequence and
      cr.contract_seq_number = con.con_active_sequence and
      con.con_date_terminated is null and
      cr.con_expiry_date > rd.today() and
      con.con_base_office = outl.outlet_id and
      (outl.outlet_id = @inOutlet or @inOutlet = 0) and
      (outl.region_id = @inRegion or @inRegion = 0) and
      ((con.con_base_cont_type = @inContractType and @inContractType > 0) or(@inContractType = 0 or @inContractType is null)) and
      (con.rg_code = @inRenGroup or @inRenGroup = 0)
      group by ac.contract_no
) as avt
 where
    avt.con_num is not null
  select @dReturn=isnull(@dTotal,0)
  return @dReturn

END
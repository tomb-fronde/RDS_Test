
--
-- Definition for stored procedure sp_GetRegionArticalCounts : 
--

create procedure [rd].[sp_GetRegionArticalCounts](
@in_Region int,
@in_RenewalGroup int,
@in_Period datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select artical_count.contract_no,
    artical_count.ac_start_week_period,
    artical_count.ac_w1_medium_letters,
    artical_count.ac_w1_other_envelopes,
    artical_count.ac_w1_small_parcels,
    artical_count.ac_w1_large_parcels,
    artical_count.ac_w1_inward_mail,
    artical_count.ac_w2_medium_letters,
    artical_count.ac_w2_other_envelopes,
    artical_count.ac_w2_small_parcels,
    artical_count.ac_w2_large_parcels,
    artical_count.ac_w2_inward_mail,'U'
 from
    artical_count join contract on artical_count.contract_no=contract.contract_no join outlet as fk_base_office
    on contract.con_lodgement_office=fk_base_office.outlet_id   
where
    fk_base_office.region_id = @in_Region and
    contract.rg_code = @in_RenewalGroup and
    (contract.con_date_terminated is null or contract.con_date_terminated > @in_Period) and
    artical_count.ac_start_week_period = @in_Period union
  select contract.contract_no,
    @in_Period,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,'A' from
    contract join outlet as fk_base_office on contract.con_lodgement_office=fk_base_office.outlet_id
 where
    fk_base_office.region_id = @in_Region and
    (contract.con_date_terminated is null or contract.con_date_terminated > @in_Period) and
    contract.rg_code = @in_RenewalGroup and
    0 = (select count(*) from
      artical_count where
      artical_count.contract_no = contract.contract_no and
      (contract.con_date_terminated is null or contract.con_date_terminated > @in_Period) and
      artical_count.ac_start_week_period = @in_Period)
end
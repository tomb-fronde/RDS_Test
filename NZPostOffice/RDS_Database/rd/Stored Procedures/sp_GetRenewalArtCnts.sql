
--
-- Definition for stored procedure sp_GetRenewalArtCnts : 
--

create procedure [rd].[sp_GetRenewalArtCnts](
@in_Contract int,
@in_Sequence int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select artical_count.contract_no,
    artical_count.contract_seq_number,
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
    artical_count.ac_w2_inward_mail,
    artical_count.ac_scale_factor,
    (select max(address.adr_rd_no) from
      address where
      address.contract_no = @in_Contract) from
    artical_count where
    artical_count.contract_no = @in_Contract and
    artical_count.contract_seq_number = @in_Sequence order by
    artical_count.ac_start_week_period asc
end
CREATE procedure [rd].[sp_getDriverHSInfo](
	@inDriverNo int)
AS
-- TJB  RPCR_060  Jan-2014: Created
-- Get drivers 'personal' info
--
-- TJB  RPCR_060  Mar-2014
-- Add retrieval of H&S type help
BEGIN
  set CONCAT_NULL_YIELDS_NULL OFF
  select @inDriverNo as driver_no
       , hst.hst_id, hst_name
       , hsi_date_checked, hsi_passfail_ind
       , hsi_additional_date
       , hsi_notes
       , hst_help
       , hst_additional_date_errmsg
       , hst_notes_errmsg
    from hs_type hst left outer join driver_hs_info hsi
              on hsi.hst_id = hst.hst_id
              and hsi.driver_no = @inDriverNo

END
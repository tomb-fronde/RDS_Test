CREATE procedure [rd].[sp_getContractorDriverHSInfo](
	@inContractorSupplierNo int)
AS
-- TJB  RPCR_060  Jan-2014: Created
-- Get all drivers and the most-recent Health&Safety info for a Contractor
BEGIN
  set CONCAT_NULL_YIELDS_NULL OFF
  select cd.contractor_supplier_no, cd.driver_no
       , isnull(d_title+' ','')+ isnull(d_first_names+' ','')+d_surname
       , hst_name, hsi_date_checked, hsi_passfail_ind
    from driver d
       , contractor_driver cd 
             left outer join driver_hs_info dhi
                  on dhi.driver_no = cd.driver_no
                  and dhi.hsi_date_checked 
                       = ( select max(hsi_date_checked) from driver_hs_info dhi2
                            where dhi2.driver_no = dhi.driver_no
                              and dhi2.hst_id = dhi.hst_id)
             left outer join hs_type hst
                  on hst.hst_id = dhi.hst_id
   where cd.contractor_supplier_no = @inContractorSupplierNo
     and d.driver_no = cd.driver_no
   order by driver_no, dhi.hst_id

END
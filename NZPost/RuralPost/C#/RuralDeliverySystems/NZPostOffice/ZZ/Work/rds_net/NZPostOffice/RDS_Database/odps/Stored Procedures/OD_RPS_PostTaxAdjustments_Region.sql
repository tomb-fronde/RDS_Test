
--
-- Definition for stored procedure OD_RPS_PostTaxAdjustments_Region : 
--

create procedure [odps].[OD_RPS_PostTaxAdjustments_Region](@sdate datetime,@edate datetime,@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select distinct contractor.c_surname_company ,
    contractor.c_first_names ,
    post_tax_deductions_applied.pcd_amount ,
    post_tax_deductions.ded_description,
    payment.contract_no,
    region=(select rgn_name from rd.region where region.region_id = outlet.region_id),
    region.rgn_name,
    soundeks= substring(soundex(post_tax_deductions.ded_description),2,3) from
    payment,
    post_tax_deductions_applied,
    rd.contractor,
    post_tax_deductions,
    rd.contract,
    rd.outlet,
    rd.region where
    (post_tax_deductions_applied.invoice_id = payment.invoice_id) and
    (payment.contractor_supplier_no = contractor.contractor_supplier_no) and
    (post_tax_deductions_applied.ded_id = post_tax_deductions.ded_id) and
    (payment.contract_no = contract.contract_no) and
    (contract.con_base_office = outlet.outlet_id) and
    (outlet.region_id = region.region_id) and
    ((payment.invoice_date between @sdate and @edate) and
    ((outlet.region_id = @inregion and
    @inregion > 0) or
    (@inregion = 0)))
end
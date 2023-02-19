
--
-- Definition for stored procedure OD_RPS_Pay_Summary : 
--

create procedure  [odps].[OD_RPS_Pay_Summary](@sdate datetime,@edate datetime,@inregion int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4684  20-June-2006
  -- Split SkyRoad out of contract_adjustments and added as a separately-returned value
  -- Added ParcelPost
  --
  -- 18/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
  -- sql code.  Used the corresponding payment_component_type.prs_key instead.
  -- Note:
  --	Kiwimail	1
  --	CourierPost	2
  --	XP (Skytrain)	3
  --	ParcelPost	4
  select distinct region=(select rgn_name from
      rd.region where
      region.region_id = outlet.region_id),
    contract_no=contract.contract_no,
    name=c_surname_company+case when c_initials is null then '' else ', '+c_initials end,
    m_standard=(select isnull(sum(pc_amount),0) from
       odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      (((payment_component_type.pct_description like 'Contract payment value%' or
      payment_component_type.pct_description like 'Frequency Adjustment%') and
      left(payment_component.comments,6) <> 'Arrear') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_allowance=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract allowance%' and
      left(payment_component.comments,6) <> 'Arrear') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_extension=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((left(payment_component.comments,6) = 'Arrear') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_contract_adjustment=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Contract Adjustment%' and
      left(payment_component.comments,6) <> 'Arrear') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_Adpost=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.prs_key = 1) and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_CourierPost=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.prs_key = 2) and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_GST_value=(select isnull(sum(pc_amount*-1),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'GST%') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_wtax_value=(select isnull(sum(pc_amount*-1),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Withholding Tax%') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_adj_notax=(select isnull(sum(pc_amount*-1),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.pct_description like 'Post-Tax Adjustments%') and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    contract_type=contract_type.contract_type,
    m_ParcelPost=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.prs_key = 4) and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))),
    m_SkyRoad=(select isnull(sum(pc_amount),0) from
      odps.Payment INNER JOIN
       odps.Payment_Component ON odps.Payment.Invoice_ID = odps.Payment_Component.Invoice_ID INNER JOIN
       odps.Payment_Component_Type ON odps.Payment_Component.pct_id = odps.Payment_Component_Type.pct_id where
      (payment.invoice_date between @sdate and @edate) and
--      (payment_component.invoice_id = payment.invoice_id) and
--      (payment_component_type.pct_id = payment_component.pct_id) and
      ((payment_component_type.prs_key = 3) and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no and
      payment.contract_no = contractor_renewals.contract_no and
      payment.contract_seq_number = contractor_renewals.contract_seq_number))) from
     rd.contract INNER JOIN
     rd.outlet ON contract.con_base_office = outlet.outlet_id INNER JOIN
     rd.contractor_renewals ON contract.contract_no = contractor_renewals.contract_no INNER JOIN
     rd.contractor ON (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) INNER JOIN
     rd.contract_type ON (contract.con_base_cont_type = contract_type.ct_key) where
--    (contract.con_base_office = outlet.outlet_id) and
--    (contractor_renewals.contractor_supplier_no = contractor.contractor_supplier_no) and
--    (contract.contract_no = contractor_renewals.contract_no) and
--    (contract.con_base_cont_type = contract_type.ct_key) and
    ((outlet.region_id = @inregion and @inregion > 0) or(@inregion = 0)) and
    exists(select payment.contractor_supplier_no from
      payment where
      (payment.contract_no = contractor_renewals.contract_no) and
      (payment.contractor_supplier_no = contractor_renewals.contractor_supplier_no) and
      (payment.contract_seq_number = contractor_renewals.contract_seq_number) and
      (payment.invoice_date between @sdate and @edate))
end
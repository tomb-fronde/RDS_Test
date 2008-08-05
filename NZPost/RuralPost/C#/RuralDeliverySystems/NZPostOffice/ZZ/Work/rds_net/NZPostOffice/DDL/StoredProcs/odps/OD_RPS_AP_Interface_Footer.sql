/****** Object:  StoredProcedure [odps].[OD_RPS_AP_Interface_Footer]    Script Date: 08/05/2008 10:13:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
-- Definition for stored procedure OD_RPS_AP_Interface_Footer : 
--

create procedure [odps].[OD_RPS_AP_Interface_Footer](@ProcDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select transaction_id_1='PRLN',
    vendor_2=isnull((select max(cd_old_ds_no) from rd.contractor left outer join rd.contractor_ds on contractor.contractor_supplier_no = contractor_ds.contractor_supplier_no where contractor.contractor_supplier_no = contractor_ds.contractor_supplier_no and contractor.contractor_supplier_no = p.contractor_supplier_no),convert(varchar,p.contractor_supplier_no)),vendor_location_3=' ',
    Invoice_no_4 = odps.OD_MiscF_Get_Invoicenumber(p.invoice_no,@ProcDate),
    invoice_date_5=convert(varchar,p.invoice_date,112),
    payment_number_6=0,
    column_7=convert(varchar,odps.OD_MiscF_Get_PCT_Sequence(p.invoice_id,pc.pc_id)),column_8=' ',
    column_9=convert(varchar,case when pcg.pcg_short_code = 'GST' then abs(pc.pc_amount) else pc.pc_amount end),column_10=' ',column_11=' ',column_12=' ',column_13=' ',column_14=' ',column_15=' ',column_16=' ',column_17=' ',column_18=' ',column_19=' ',column_20=' ',column_21=' ',column_22=' ',column_23=' ',column_24=' ',column_25=' ',column_26=' ',column_27=' ',column_28=' ',column_29=' ',column_30=' ',column_31=' ',column_32=' ',column_33=' ',column_34=' ',column_35=' ',column_36='101',column_37='181876',
    column_38=a.ac_code,column_39=' ',column_40=' ',column_41=' ',column_42=' ',column_43=' ',column_44=' ',column_45=' ',column_46=' ',column_47=' ',column_48=' ',column_49=' ',column_50=' ',column_51=' ',column_52=' ',column_53=' ',column_54=' ',column_55=' ',column_56=' ',column_57=' ',column_58='  ' from
    payment as p,
    payment_component as pc,
    payment_component_type as pct,
    rd.contract as c left outer join pbu_code as pbu on(pbu.pbu_id = c.pbu_id),
    account_codes as a,
    payment_component_group as pcg where
    (pc.invoice_id = p.invoice_id) and
    (pct.pct_id = pc.pct_id) and
    (a.ac_id = pct.ac_id) and
    (p.contract_no = c.contract_no) and
    (p.invoice_date = @procdate) and
    (pct.pcg_id = pcg.pcg_id) order by
    p.invoice_id asc,pc.pc_id asc
end
GO

create procedure [odps].[OD_RPS_GrossPayVariance](@sdate datetime,@edate datetime,@prevsdate datetime,@prevedate datetime)
as
select payment.contract_no,
  contractor.c_surname_company,
  contractor.c_first_names,
  contractor.c_initials,
  LastMonth=(odps.OD_RPF_PCGetSumYear(
  payment.contractor_supplier_no,
  payment.contract_no,
  payment.contract_seq_number,
  @prevsdate,
  @prevedate,'GP',null)),
  /* Commented out so that the gross pay is what is calculated and 
  *      not net pay, 16/09/1999
  * +OD_RPF_PCGetSumYear(payment.contractor_supplier_no, 
  *           payment.contract_no, payment.contract_seq_number, 
  *           @prevsdate, @prevedate, 'OGP')
  * +abs(OD_RPF_PCGetSumYear(payment.contractor_supplier_no, 
  *           payment.contract_no, payment.contract_seq_number, 
  *           @prevsdate, @prevedate, 'GST'))
  * -abs(OD_RPF_PCGetSumYear(payment.contractor_supplier_no, 
  *          payment.contract_no, payment.contract_seq_number, 
  *           @prevsdate, @prevedate, 'TAX'))
  * +OD_RPF_PCGetSumYear(payment.contractor_supplier_no, 
  *           payment.contract_no, payment.contract_seq_number, 
  *           @prevsdate, @prevedate, 'PTA')),
  */
  ThisMonth=(odps.OD_RPF_PCGetSum(payment.invoice_id,'GP')),
  /* Commented out so that the gross pay is what is calculated and 
  *      not net pay, 16/09/1999
  * +OD_RPF_PCGetSum(payment.invoice_id, 'OGP')
  * +(OD_RPF_PCGetSum(payment.invoice_id, 'GST')*-1)
  * -abs(OD_RPF_PCGetSum(payment.invoice_id, 'TAX'))
  * +OD_RPF_PCGetSum(payment.invoice_id, 'PTA')),
  */
  wrate=(select nat_net_pct_change_warn from "national" where
    nat_id = odps.od_blf_getwhichnational(@edate)) from
  rd.contractor,payment where
  contractor.contractor_supplier_no = payment.contractor_supplier_no and
  payment.invoice_date between @sdate and @edate and
  (((case when (odps.OD_RPF_PCGetSumYear(
  payment.contractor_supplier_no,
  payment.contract_no,
  payment.contract_seq_number,
  @prevsdate,
  @prevedate,'GP',null)) <> 0 then(abs(odps.OD_RPF_PCGetSum(payment.invoice_id,'GP')/*thismounth*/ - odps.OD_RPF_PCGetSumYear(
  payment.contractor_supplier_no,payment.contract_no, payment.contract_seq_number, @prevsdate, @prevedate,'GP',null) /*Lastmonth*/ )/(odps.OD_RPF_PCGetSumYear(
  payment.contractor_supplier_no,
  payment.contract_no,
  payment.contract_seq_number,
  @prevsdate,
  @prevedate,'GP',null)))*100
  else 999999
  end) >= (select nat_net_pct_change_warn from
    "national" where
    nat_id = odps.od_blf_getwhichnational(@edate))))
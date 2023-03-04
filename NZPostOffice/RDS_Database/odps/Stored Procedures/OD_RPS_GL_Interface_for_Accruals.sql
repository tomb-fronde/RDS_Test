create procedure [odps].[OD_RPS_GL_Interface_for_Accruals](@ProcDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  BEGIN TRANSACTION
  delete from t_rps_gl_interface
  commit transaction

BEGIN TRANSACTION
  insert into t_rps_gl_interface(entity_id_1,
    journal_id_2,effective_date_3,journal_sequence_4,
    line_entity_id_6,rc_number_7,account_number_8,product_code_9,
    analysis_code_10,primary_dr_cr_code_11,transaction_amount_12,
    misc_cr_dr_code_13,misc_amount_14,jrnl_user_alpha_fld_15,
    date_created_16,description_17)
    select entity_id_1='101',journal_id_2='RDS_ACCRUAL',
      effective_date_3=rd.today(),
      journal_sequence_4=1,line_entity_id_6='101',
      rc_number_7=pbu_code.pbu_code,
      account_number_8=case when contract.ac_id is null then account_codes.ac_code else (select ac2.ac_code from account_codes as ac2 where
        ac2.ac_id = contract.ac_id) end,product_code_9=' ',analysis_code_10=' ',primary_dr_cr_code_11='D',
      transaction_amount_12=round(sum(pc_amount)*.3333333333333,2),misc_cr_dr_code_13=' ',
      misc_amount_14=0,
      jrnl_user_alpha_fld_15=pbu_code.pbu_code,
      date_created_16=rd.today(),description_17='RD Accruals Contract Price' from
      rd.contract,
      payment,
      payment_component,
      payment_component_group,
      payment_component_type,
      account_codes,
      pbu_code where
      contract.contract_no = payment.contract_no and
      payment_component.invoice_id = payment.invoice_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_type.pct_id = payment_component.pct_id and
      pbu_code.pbu_id = contract.pbu_id and
      account_codes.ac_id = payment_component_type.ac_id and
      payment_component_group.pcg_short_code in('GP','OGP') and
      payment_component_type.pct_id <> 4 and
      payment_component_type.prs_key is null and
      payment.invoice_date = @procdate
      group by pbu_code.pbu_code,
      account_codes.ac_code,
      contract.ac_id
  if @@error < 0
    begin
      rollback transaction
      return(-100001000)
    end


  insert into t_rps_gl_interface(entity_id_1,
    journal_id_2,effective_date_3,journal_sequence_4,
    line_entity_id_6,rc_number_7,account_number_8,product_code_9,
    analysis_code_10,primary_dr_cr_code_11,transaction_amount_12,
    misc_cr_dr_code_13,misc_amount_14,jrnl_user_alpha_fld_15,
    date_created_16,description_17)
    select entity_id_1='101',journal_id_2='RDS_ACCRUAL',
      effective_date_3=rd.today(),
      journal_sequence_4=1,line_entity_id_6='101',
      isnull((select pbu_code.pbu_code from "national",pbu_code where
        nat_pbu_code_gst_gl = pbu_id and
        "national".nat_id = (select odps.od_blf_getwhichnational(@procdate)  )),'49999') as rc_number_7,
      account_number_8=isnull((select account_codes.ac_code from account_codes,"national" where
        nat_ac_id_accrualBalance_gl = account_codes.ac_id and
        "national".nat_id = (select odps.od_blf_getwhichnational(@procdate) )),'4250'),product_code_9=' ',analysis_code_10=' ',primary_dr_cr_code_11='C',
      transaction_amount_12=round(sum(pc_amount)*.3333333333333,2)*-1,misc_cr_dr_code_13=' ',
      misc_amount_14=0,
      jrnl_user_alpha_fld_15=isnull((select pbu_code.pbu_code from "national",pbu_code where
        nat_pbu_code_gst_gl = pbu_id and
        "national".nat_id = (select odps.od_blf_getwhichnational(@procdate)  )),'49999'), --gives jrnl_user_alpha_fld_15 the same value as rc_number_7's orgine
      date_created_16=rd.today(),description_17='RD Accruals' from
      rd.contract,
      payment,
      payment_component,
      payment_component_group,
      payment_component_type where
      contract.contract_no = payment.contract_no and
      payment_component.invoice_id = payment.invoice_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_type.pct_id = payment_component.pct_id and
      payment_component_group.pcg_short_code in('GP','OGP') and
      payment_component_type.pct_id <> 4 and
      (not payment_component_type.pct_id = any(select pct_id from rd.piece_rate_supplier)) and
      payment.invoice_date = @procdate
  if @@error < 0
    begin
      rollback transaction
      return(-100001000)
    end
  commit transaction

  select entity_id_1,
    journal_id_2,
    effective_date_3,
    journal_sequence_4,
    ROW_NUMBER() OVER (ORDER BY entity_id_1 ASC),
    line_entity_id_6,
    rc_number_7,
    account_number_8,
    product_code_9,
    analysis_code_10,
    primary_dr_cr_code_11,
    transaction_amount_12,
    misc_cr_dr_code_13,
    misc_amount_14,
    jrnl_user_alpha_fld_15,
    date_created_16,
    description_17 from
    t_rps_gl_interface
end
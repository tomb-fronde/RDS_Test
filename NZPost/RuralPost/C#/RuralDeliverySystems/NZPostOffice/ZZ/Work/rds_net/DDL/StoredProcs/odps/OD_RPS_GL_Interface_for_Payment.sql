/****** Object:  StoredProcedure [odps].[OD_RPS_GL_Interface_for_Payment]    Script Date: 08/05/2008 10:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [odps].[OD_RPS_GL_Interface_for_Payment](@ProcDate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4684  June-2006
  -- Added handling of Parcel Post
  -- 18/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
  -- sql code.  Used the corresponding payment_component_type.prs_key instead.
  -- 03/10/2002 PBY DB Upgrade from 5.x to 8.0.1
  -- NUMBER(*) function is no longer valid when used inside a UNION clause.
  -- Temporary table t_rps_gl_interface is created instead to retain
  -- the original functionality.
  begin transaction
  delete from t_rps_gl_interface
  commit transaction

  begin transaction
  insert into t_rps_gl_interface(entity_id_1,
    journal_id_2,effective_date_3,journal_sequence_4,
    line_entity_id_6,rc_number_7,account_number_8,product_code_9,
    analysis_code_10,primary_dr_cr_code_11,transaction_amount_12,
    misc_cr_dr_code_13,misc_amount_14,jrnl_user_alpha_fld_15,
    date_created_16,description_17)
    select entity_id_1='101',journal_id_2='RDS_PAYROLL',
      effective_date_3=rd.today(),
      journal_sequence_4=1,line_entity_id_6='101',
      rc_number_7=case when contract.pbu_id is null then 
      (select p.pbu_code from pbu_code as p where
        p.pbu_id = (select nat.nat_PBU_code_NetPay_GL from "national" as nat where
          nat.nat_id = odps.od_blf_getwhichnational(@ProcDate))) else 
      (select p2.pbu_code from pbu_code as p2 where
        p2.pbu_id = contract.pbu_id) end,
      account_number_8=(case when payment_component_type.prs_key is null then
			case when contract.ac_id is null then account_codes.ac_code else 
				(select ac2.ac_code from account_codes as ac2 where ac2.ac_id = contract.ac_id) end 
		else ( case when payment_component_type.prs_key = 2 then
				(select ac10.ac_code from account_codes as ac10 where ac10.ac_id = (select p10.ac_id from payment_component_type as p10 where p10.pct_id = (select n10.nat_courierpost_defaultcomptype from "national" as n10 where n10.nat_id = odps.od_blf_getwhichnational(@procdate))))
			else case when payment_component_type.prs_key = 1 then (select ac11.ac_code from account_codes as ac11 where ac11.ac_id = (select p11.ac_id from payment_component_type as p11 where p11.pct_id = (select n11.nat_AdPost_DefaultComptype from "national" as n11 where n11.nat_id = odps.od_blf_getwhichnational(@procdate)))) 
				else case when payment_component_type.prs_key = 3 then (select ac12.ac_code from account_codes as ac12 where ac12.ac_id = (select p12.ac_id from payment_component_type as p12 where p12.pct_id = (select n12.nat_XP_DefaultComptype from "national" as n12 where n12.nat_id = odps.od_blf_getwhichnational(@procdate)))) 
					else case when payment_component_type.prs_key = 4 then (select ac13.ac_code from account_codes as ac13 where ac13.ac_id = (select p13.ac_id from payment_component_type as p13 where p13.pct_id = (select n13.nat_PP_DefaultComptype from "national" as n13 where n13.nat_id = odps.od_blf_getwhichnational(@procdate))))
					end
				end
			end
		end) end ),product_code_9=' ',analysis_code_10=' ',primary_dr_cr_code_11='D',
      transaction_amount_12=sum(pc_amount),misc_cr_dr_code_13='',
      misc_amount_14=0,
      jrnl_user_alpha_fld_15=case when contract.pbu_id is null then 
      (select p.pbu_code from pbu_code as p where
        p.pbu_id = (select nat.nat_PBU_code_NetPay_GL from "national" as nat where
          nat.nat_id = odps.od_blf_getwhichnational(@ProcDate))) else 
      (select p2.pbu_code from pbu_code as p2 where
        p2.pbu_id = contract.pbu_id) end,
      date_created_16=rd.today(),description_17='RD Payments Contract Price' from
      rd.contract,
      payment,
      payment_component,
      payment_component_group,
      payment_component_type,
      account_codes where
      contract.contract_no = payment.contract_no and
      payment_component.invoice_id = payment.invoice_id and
      payment_component_type.pcg_id = payment_component_group.pcg_id and
      payment_component_type.pct_id = payment_component.pct_id and
      account_codes.ac_id = payment_component_type.ac_id and
      payment_component_group.pcg_short_code in('GP','OGP') and
      payment.invoice_date = @procdate
      group by contract.pbu_id,
      contract.ac_id,
      payment_component_type.pct_description,payment_component_type.prs_key,account_codes.ac_code,payment_component_type.prs_key,
payment_component_type.prs_key,payment_component_type.prs_key,payment_component_type.prs_key
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
    select entity_id_1='101',journal_id_2='RDS_PAYROLL',
      effective_date_3=rd.today(),
      journal_sequence_4=1,line_entity_id_6='101',
      rc_number_74=isnull((select pbu_code.pbu_code from "national",pbu_code where
        nat_PBU_code_NetPay_GL = pbu_id and
        "national".nat_id = (select odps.od_blf_getwhichnational(@procdate) )),'181876'),
      account_number_8=isnull((select account_codes.ac_code from account_codes,"national" where
        nat_ac_id_NetPay_GL = account_codes.ac_id and
        "national".nat_id = (select odps.od_blf_getwhichnational(@procdate) )),'4200'),product_code_9=' ',analysis_code_10=' ',primary_dr_cr_code_11='C',
      transaction_amount_121=(select sum(pc_amount)*-1 from
        rd.contract as c,
        payment as p,
        payment_component as pc,
        payment_component_group as pcg,
        payment_component_type as pct where
        c.contract_no = p.contract_no and
        pc.invoice_id = p.invoice_id and
        pct.pcg_id = pcg.pcg_id and
        pct.pct_id = pc.pct_id and
        p.invoice_date = @procdate and
        pcg.pcg_short_code in('GP','OGP')),misc_cr_dr_code_13='',
      misc_amount_14=0,
      jrnl_user_alpha_fld_15=isnull((select pbu_code.pbu_code from "national",pbu_code where
        nat_PBU_code_NetPay_GL = pbu_id and
        "national".nat_id = (select odps.od_blf_getwhichnational(@procdate) )),'49999'), --give jrnl_user_alpha_fld_15 the same value as rc_number_74's origine 
      date_created_16=rd.today(),description_17='RD Payments Creditors Net Pay' 
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
    row_number() over(order by entity_id_1),
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
GO

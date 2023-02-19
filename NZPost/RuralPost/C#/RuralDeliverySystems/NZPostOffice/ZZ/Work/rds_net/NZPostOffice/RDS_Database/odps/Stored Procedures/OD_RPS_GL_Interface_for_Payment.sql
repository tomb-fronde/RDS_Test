
CREATE PROCEDURE [odps].[OD_RPS_GL_Interface_for_Payment](
	@ProcDate datetime)
AS
BEGIN
  -- TJB RPCR_124  Apr 2019
  -- *Changed description for selected records (see description_17)
  -- *Added schema name to table names
  -- *Added 'order by' clause to final select statement to put the total
  -- as the last record returned with the rest of the reords sorted by
  -- account number as requested (email 16Apr2019).
  -- *Split detail calculation into two parts: one for all contracts
  -- other than Contract Posties (contract.rg_code != 10) and one for 
  -- Contract Postie contracts only (contract.rg_code = 10)
  -- *Simplified how account codes are determined for prs_keys 1-4
  -- *Determined odps.national detail row to use (nat_id) by saving 
  -- @natID = odps.od_blf_getwhichnational(@ProcDate) and using the 
  -- variable where the function was called.
  -- BUG FIX: Changed 'rc_number_74' in second INSERT statement's SELECT
  --          statement to 'rc_number_7'
  --
  -- TJB  Oct-2015
  -- Added handling of prs_key = 5 when determining GL account code
  -- This does the inverse of what is done when the psr_key is null: use 
  -- the account key associated with the payment_component_type instead 
  -- of that associated with the contract.
  --
  -- TJB  SR4684  June-2006
  -- Added handling of Parcel Post
  --
  -- 18/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
  -- sql code.  Used the corresponding payment_component_type.prs_key instead.
  --
  -- 03/10/2002 PBY DB Upgrade from 5.x to 8.0.1
  -- NUMBER(*) function is no longer valid when used inside a UNION clause.
  -- Temporary table t_rps_gl_interface is created instead to retain
  -- the original functionality.

  SET NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off

  declare @natID datetime
  set @natID = odps.od_blf_getwhichnational(@ProcDate)

  declare @ContractPostie int
  select @ContractPostie = rg_code from rd.renewal_group
   where rg_description = 'Contract Posties'

  begin transaction
  delete from odps.t_rps_gl_interface
  commit transaction

  begin transaction
/* Insert results for all renewal groups EXCEPT Contract Posties */
  insert into odps.t_rps_gl_interface
        (entity_id_1, journal_id_2, effective_date_3, journal_sequence_4,
         line_entity_id_6, rc_number_7, account_number_8, product_code_9,
         analysis_code_10, primary_dr_cr_code_11, transaction_amount_12,
         misc_cr_dr_code_13, misc_amount_14, jrnl_user_alpha_fld_15,
         date_created_16, description_17)
  select
         entity_id_1='101', 
         journal_id_2='RDS_PAYROLL',
         effective_date_3=rd.today(),
         journal_sequence_4=1, 
         line_entity_id_6='101',
         rc_number_7
             =case when contract.pbu_id is null 
                   then (select p.pbu_code from odps.pbu_code as p 
                          where p.pbu_id = (select nat.nat_PBU_code_NetPay_GL from odps."national" as nat 
                                             where nat.nat_id = @natID)) 
                   else (select p2.pbu_code from odps.pbu_code as p2 
                          where p2.pbu_id = contract.pbu_id) 
                   end,
         account_number_8 =  /* Get ac_code depending on prs_key */
                (case when payment_component_type.prs_key is null 
                      then (case when contract.ac_id is null 
                                 then account_codes.ac_code 
                                 else (select ac2.ac_code from odps.account_codes as ac2 
                                        where ac2.ac_id = contract.ac_id) 
                                 end)
                 else (case when payment_component_type.prs_key = 5
                            then account_codes.ac_code
                 else (case when payment_component_type.prs_key in (1,2,3,4)
                            then (select ac10.ac_code from odps.account_codes as ac10 
                                   where ac10.ac_id = 
                                        (select p10.ac_id from odps.payment_component_type as p10 
                                          where p10.pct_id = 
                                                (case when payment_component_type.prs_key = 1
                                                      then (select n10.nat_AdPost_defaultcomptype from odps."national" as n10 
                                                             where n10.nat_id = @natID)
                                                 else (case when payment_component_type.prs_key = 2
                                                            then (select n11.nat_courierpost_defaultcomptype from odps."national" as n11 
		                                                   where n11.nat_id = @natID)
                                                 else (case when payment_component_type.prs_key = 3 
                                                            then (select n12.nat_XP_DefaultComptype from odps."national" as n12 
                                                                   where n12.nat_id = @natID)
                                                 else (case when payment_component_type.prs_key = 4 
                                                            then (select n13.nat_PP_DefaultComptype from odps."national" as n13 
                                                                   where n13.nat_id = @natID)
                                                 end)   -- prs_key = 4
                                                 end)   -- prs_key = 3
                                                 end)   -- prs_key = 2
                                                 end))) -- prs_key = 1
                            
                            else /* prs_key not in (1,2,3,4,5) */
                                 (select ac2.ac_code from odps.account_codes as ac2 
                                   where ac2.ac_id = contract.ac_id) 
                            end)  -- prs_key in (1,2,3,4,5)
                 end)  -- prs_key = 5
                 end),  -- prs_key is null
         product_code_9=' ',
         analysis_code_10=' ',
         primary_dr_cr_code_11='D',
         transaction_amount_12=sum(pc_amount),
         misc_cr_dr_code_13='',
         misc_amount_14=0,
         jrnl_user_alpha_fld_15=case when contract.pbu_id is null 
                                     then (select p.pbu_code from odps.pbu_code as p 
                                            where p.pbu_id = (select nat.nat_PBU_code_NetPay_GL from odps."national" as nat 
                                                               where nat.nat_id = @natID)) 
                                     else (select p2.pbu_code from odps.pbu_code as p2 
                                            where p2.pbu_id = contract.pbu_id) 
                                     end,
         date_created_16=rd.today(),
         -- description_17='RD Payments Contract Price' 
         description_17=case when account_codes.ac_code = 428296
                             then case when (payment_component_type.pct_description like 'Contract payment value%'
                                              or payment_component_type.pct_description like 'Frequency Adjustment%')
                                       then 'Standard'
                                       else case when payment_component_type.pct_description like 'Contract Allowance%'
                                                 then 'Allowance'
                                                 else case when (payment_component_type.pct_description like 'Contract Adjustment%'
                                                                or payment_component_type.prs_key > 0)
                                                           then 'Contract Adjustments and Arrears'
                                                           else 'RD Payments Contract Price'
                                                           end
                                                 end
                                       end
                             else 'RD Payments Contract Price'
                             end
    from rd.contract,
         odps.payment,
         odps.payment_component,
         odps.payment_component_group,
         odps.payment_component_type,
         odps.account_codes 
   where [contract].contract_no = payment.contract_no 
     and [contract].rg_code != @ContractPostie
     and payment_component.invoice_id = payment.invoice_id 
     and payment_component_type.pcg_id = payment_component_group.pcg_id 
     and payment_component_type.pct_id = payment_component.pct_id 
     and account_codes.ac_id = payment_component_type.ac_id 
     and payment_component_group.pcg_short_code in('GP','OGP') 
     and payment.invoice_date = @procdate
   group by 
          [contract].pbu_id
         ,[contract].ac_id
         ,payment_component_type.pct_description
         ,payment_component_type.prs_key
         ,account_codes.ac_code
         
  if @@error < 0
  begin
      rollback transaction
      print 'Error: Return (-100001001)'
      return
  end

/* Insert results for Contract Posties renewal group only */
  insert into odps.t_rps_gl_interface
        (entity_id_1, journal_id_2, effective_date_3, journal_sequence_4,
         line_entity_id_6, rc_number_7, account_number_8, product_code_9,
         analysis_code_10, primary_dr_cr_code_11, transaction_amount_12,
         misc_cr_dr_code_13, misc_amount_14, jrnl_user_alpha_fld_15,
         date_created_16, description_17)
  select
         entity_id_1='101', 
         journal_id_2='RDS_PAYROLL',
         effective_date_3=rd.today(),
         journal_sequence_4=1, 
         line_entity_id_6='101',
         rc_number_7
             =case when contract.pbu_id is null 
                   then (select p.pbu_code from odps.pbu_code as p 
                          where p.pbu_id = (select nat.nat_PBU_code_NetPay_GL from odps."national" as nat 
                                             where nat.nat_id = @natID)) 
                   else (select p2.pbu_code from odps.pbu_code as p2 
                          where p2.pbu_id = contract.pbu_id) 
                   end,
         account_number_8 =  /* Get ac_code depending on prs_key */
                (case when payment_component_type.prs_key is null 
                      then (case when contract.ac_id is null 
                                 then account_codes.ac_code 
                                 else (select ac2.ac_code from odps.account_codes as ac2 
                                        where ac2.ac_id = contract.ac_id) 
                                 end)
                 else (case when payment_component_type.prs_key = 5
                            then account_codes.ac_code
                 else (case when payment_component_type.prs_key in (1,2,3,4)
                            then (select ac10.ac_code from odps.account_codes as ac10 
                                   where ac10.ac_id = 
                                        (select p10.ac_id from odps.payment_component_type as p10 
                                          where p10.pct_id = 
                                                (case when payment_component_type.prs_key = 1
                                                      then (select n10.cp_reachmedia_defaultcomptype from odps."national" as n10 
                                                             where n10.nat_id = @natID)
                                                 else (case when payment_component_type.prs_key = 2
                                                            then (select n11.cp_courierpost_defaultcomptype from odps."national" as n11 
		                                                   where n11.nat_id = @natID)
                                                 else (case when payment_component_type.prs_key = 3 
                                                            then (select n12.cp_publishing_DefaultComptype from odps."national" as n12 
                                                                   where n12.nat_id = @natID)
                                                 else (case when payment_component_type.prs_key = 4 
                                                            then (select n13.nat_PP_DefaultComptype from odps."national" as n13 
                                                                   where n13.nat_id = @natID)
                                                 end)   -- prs_key = 4
                                                 end)   -- prs_key = 3
                                                 end)   -- prs_key = 2
                                                 end))) -- prs_key = 1
                            
                            else /* prs_key not in (1,2,3,4,5) */
                                 (select ac2.ac_code from odps.account_codes as ac2 
                                   where ac2.ac_id = contract.ac_id) 
                            end)  -- prs_key in (1,2,3,4,5)
                 end)  -- prs_key = 5
                 end),  -- prs_key is null
         product_code_9=' ',
         analysis_code_10=' ',
         primary_dr_cr_code_11='D',
         transaction_amount_12=sum(pc_amount),
         misc_cr_dr_code_13='',
         misc_amount_14=0,
         jrnl_user_alpha_fld_15=case when contract.pbu_id is null 
                                     then (select p.pbu_code from odps.pbu_code as p 
                                            where p.pbu_id = (select nat.nat_PBU_code_NetPay_GL from odps."national" as nat 
                                                               where nat.nat_id = @natID)) 
                                     else (select p2.pbu_code from odps.pbu_code as p2 
                                            where p2.pbu_id = contract.pbu_id) 
                                     end,
         date_created_16=rd.today(),
         -- description_17='RD Payments Contract Price' 
         description_17=case when account_codes.ac_code = 428296
                             then case when (payment_component_type.pct_description like 'Contract payment value%'
                                              or payment_component_type.pct_description like 'Frequency Adjustment%')
                                       then 'Standard'
                                       else case when payment_component_type.pct_description like 'Contract Allowance%'
                                                 then 'Allowance'
                                                 else case when (payment_component_type.pct_description like 'Contract Adjustment%'
                                                                or payment_component_type.prs_key > 0)
                                                           then 'Contract Adjustments and Arrears'
                                                           else 'RD Payments Contract Price'
                                                           end
                                                 end
                                       end
                             else 'RD Payments Contract Price'
                             end
    from rd.contract,
         odps.payment,
         odps.payment_component,
         odps.payment_component_group,
         odps.payment_component_type,
         odps.account_codes 
   where [contract].contract_no = payment.contract_no 
     and [contract].rg_code = @ContractPostie
     and payment_component.invoice_id = payment.invoice_id 
     and payment_component_type.pcg_id = payment_component_group.pcg_id 
     and payment_component_type.pct_id = payment_component.pct_id 
     and account_codes.ac_id = payment_component_type.ac_id 
     and payment_component_group.pcg_short_code in('GP','OGP') 
     and payment.invoice_date = @procdate
   group by 
          [contract].pbu_id
         ,[contract].ac_id
         ,payment_component_type.pct_description
         ,payment_component_type.prs_key
         ,account_codes.ac_code
         
  if @@error < 0
  begin
      rollback transaction
      print 'Error: Return (-100001002)'
      return
  end

/* Insert summary for all renewal groups including Contract Posties */
  insert into odps.t_rps_gl_interface
        (entity_id_1, journal_id_2, effective_date_3, journal_sequence_4,
         line_entity_id_6, rc_number_7, account_number_8, product_code_9,
         analysis_code_10, primary_dr_cr_code_11, transaction_amount_12,
         misc_cr_dr_code_13, misc_amount_14, jrnl_user_alpha_fld_15,
         date_created_16, description_17)
  select 
         entity_id_1='101',
         journal_id_2='RDS_PAYROLL',
         effective_date_3=rd.today(),
         journal_sequence_4=1, 
         line_entity_id_6='101',
         rc_number_74=isnull((select pbu_code.pbu_code from odps."national", odps.pbu_code 
                               where nat_PBU_code_NetPay_GL = pbu_id 
                                 and "national".nat_id = (select @natID )),'181876'),
         account_number_8=isnull((select account_codes.ac_code from odps.account_codes,odps."national" 
                                   where nat_ac_id_NetPay_GL = account_codes.ac_id 
                                     and "national".nat_id = (select @natID )),'4200'),
         product_code_9=' ',
         analysis_code_10=' ',
         primary_dr_cr_code_11='C',
         transaction_amount_121=(select sum(pc_amount)*-1 
                                   from rd.contract as c, odps.payment as p, odps.payment_component as pc
                                      , odps.payment_component_group as pcg, odps.payment_component_type as pct 
                                  where c.contract_no = p.contract_no 
                                    and pc.invoice_id = p.invoice_id 
                                    and pct.pcg_id = pcg.pcg_id 
                                    and pct.pct_id = pc.pct_id 
                                    and p.invoice_date = @procdate 
                                    and pcg.pcg_short_code in('GP','OGP')),
         misc_cr_dr_code_13='',
         misc_amount_14=0,
         --give jrnl_user_alpha_fld_15 the same value as rc_number_74's origine 
         jrnl_user_alpha_fld_15=isnull((select pbu_code.pbu_code from odps."national", odps.pbu_code 
                                         where nat_PBU_code_NetPay_GL = pbu_id 
                                           and "national".nat_id = (select @natID )),'49999'),
         date_created_16=rd.today(),
         description_17='RD Payments Creditors Net Pay' 
         
  if @@error < 0
  begin
      rollback transaction
      print 'Error: return(-100001003)'
      return
  end
  commit transaction

/* Return result   */
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
         description_17 
    from odps.t_rps_gl_interface
   order by primary_dr_cr_code_11 desc
          , account_number_8
END
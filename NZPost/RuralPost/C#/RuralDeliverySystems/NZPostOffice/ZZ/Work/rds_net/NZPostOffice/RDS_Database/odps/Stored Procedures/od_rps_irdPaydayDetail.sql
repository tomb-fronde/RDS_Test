
CREATE PROCEDURE [odps].[od_rps_irdPaydayDetail](
          @startdate datetime
        , @enddate datetime)
AS
BEGIN
  -- TJB  IRD Payday Export  Feb-2022
  -- Added 6 columns:
  -- hours_paid, gross_prior_adjustments, 
  -- paye_prior_adjustments, slcir_deductions, 
  -- slbor_deductions, share_scheme 
  --
  -- TJB  RPCR_128 Bug fix  July-2019
  -- Exclude result where 'Total Paye' is 0
  --
  -- TJB  RPCR_128  June-2019: New
  -- Adapted from od_rps_ir348Detail

  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off

  begin transaction
  delete from odps.t_irdPayday

  insert into odps.t_irdPayday(
        contractor_supplier_no
      , start_date)
  select cor0.contractor_supplier_no
       , cor0.cr_effective_date 
    from rd.contract_renewals cr0
       , rd.contractor_renewals cor0
       , rd.[contract] c0
   where cor0.contract_no = cr0.contract_no 
     and c0.contract_no = cr0.contract_no 
     and ( ( (cr0.con_start_date <= @enddate) 
             and (c0.con_date_terminated is null 
                  or c0.con_date_terminated >= @startdate 
                  or datediff(day,c0.con_date_terminated,@startdate) < 32 
                  or c0.con_date_terminated between @startdate and @enddate)) 
           or exists(select contractor_supplier_no from odps.payment
                      where invoice_date between @startdate and @enddate)) 
     and cor0.cr_effective_date = 
            (select max(cor2.cr_effective_date) from rd.contractor_renewals as cor2 
              where cor2.contractor_supplier_no = cor0.contractor_supplier_no)
   group by cor0.contractor_supplier_no, cor0.cr_effective_date
  commit transaction

  select Hdr = 'DEI'
       , IRD_no = (case when len(c_ird_no) = 8 
                        then '0' + c_ird_no 
		           when len(c_ird_no) = 0 or c_ird_no is null 
		           then '000000000'
		           else c_ird_no end)
       , Employee_Full_Name = left((case when len(c_initials) > 0 
                                         then c_initials + ' '
                                         else '' end) 
                                   + c_surname_company,20)
       , tax_code = (case when len(c_ird_no) = 0 or c_ird_no is null 
                          then 'ND' else 'WT' end)
       , start_date = case when (select min(cor2.cr_effective_date) from rd.contractor_renewals as cor2 
                                  where cor2.contractor_supplier_no = cor0.contractor_supplier_no) 
                                between @startdate and @enddate 
                           then convert(char(10)
                                        ,(select min(cor2.cr_effective_date) from rd.contractor_renewals as cor2 
                                           where cor2.contractor_supplier_no = cor0.contractor_supplier_no)
                                        ,112)
                           else '' end
       , end_date = case when (select max(end_date) from odps.t_irdPayday 
                                where contractor_supplier_no = cor0.contractor_supplier_no) 
                         between @startdate and @enddate 
                         then convert(char(10)
                                      ,(select max(end_date) from odps.t_irdPayday 
                                         where contractor_supplier_no = cor0.contractor_supplier_no)
                                      ,112)
                         else '' end
       , pay_start_date = convert(char(10),@startdate,112)
       , pay_end_date   = convert(char(10),@enddate,112)
       , pay_cycle      = 'MT'
       , hours_paid     = 0
       , Gross_Earnings = (select convert(decimal(10),isnull(round(sum(pc1.pc_amount),0)*100,0)) 
                             from odps.payment p1, odps.payment_component pc1
                                , odps.payment_component_type pct1, odps.payment_component_group pcg1 
                            where pc1.invoice_id = p1.invoice_id 
                              and pc1.pct_id = pct1.pct_id 
                              and pcg1.pcg_id = pct1.pcg_id 
                              and pcg1.pcg_short_code in('GP','OGP') 
                              and p1.contractor_supplier_no = cor0.contractor_supplier_no 
                              and p1.invoice_date between @startdate and @enddate)
       , Gross_Prior_Adjustments = 0
       , Not_Liable = (case when NZ_Post_Employee is null or NZ_Post_Employee = 'N' 
                            then convert(decimal(10),
                                 (select convert(decimal(10),isnull(round(sum(pc2.pc_amount),0)*100,0)) 
                                    from odps.payment p2, odps.payment_component pc2 
                                       , odps.payment_component_type pct2, odps.payment_component_group pcg2
                                   where pc2.invoice_id = p2.invoice_id 
                                     and pc2.pct_id = pct2.pct_id 
                                     and pcg2.pcg_id = pct2.pcg_id 
                                     and pcg2.pcg_short_code in('GP','OGP') 
                                     and p2.contractor_supplier_no = cor0.contractor_supplier_no 
                                     and p2.invoice_date between @startdate and @enddate)) 
                            else 0 
                            end)
       , Lump_sum = 0
       , Total_PAYE = (select isnull(convert(decimal(10),round(sum(pc3.pc_amount)*-100,0)),0) 
                         from odps.payment p3, odps.payment_component pc3
                            , odps.payment_component_type pct3 
                        where pc3.invoice_id = p3.invoice_id 
                          and pc3.pct_id = pct3.pct_id 
                          and p3.contractor_supplier_no = cor0.contractor_supplier_no 
                          and pct3.pct_description like 'Withholding tax%' 
                          and p3.invoice_date between @startdate and @enddate)
       , Paye_Prior_Adjustments = 0
       , CS_Deductions     = 0
       , CS_DeductionCode  = ''
       , SL_Deductions     = 0
       , SLcir_Deductions  = 0
       , SLbor_Deductions  = 0
       , KS_Deductions     = 0
       , KS_Emp_Contrib    = 0
       , ESCT_Deductions   = 0
       , Tax_Credits       = 0
       , Family_Assistance = 0 
       , Share_Scheme      = 0
    from rd.contractor cor0
   where cor0.contractor_supplier_no = any(select contractor_supplier_no from odps.t_irdPayday) 
     and (select convert(decimal(10),isnull(round(sum(pc4.pc_amount),0)*100,0)) 
            from odps.payment p4, odps.payment_component pc4 
               , odps.payment_component_type pct4, odps.payment_component_group pcg4 
           where pc4.invoice_id = p4.invoice_id 
             and pc4.pct_id = pct4.pct_id 
             and pcg4.pcg_id = pct4.pcg_id 
             and pcg4.pcg_short_code in('GP','OGP') 
             and p4.contractor_supplier_no = cor0.contractor_supplier_no 
             and p4.invoice_date between @startdate and @enddate) 
           >= 0 
     and (select isnull(convert(decimal(10),round(sum(pc5.pc_amount)*-100,0)),0) 
            from odps.payment p5, odps.payment_component pc5, odps.payment_component_type pct5 
           where pc5.invoice_id = p5.invoice_id 
             and pc5.pct_id = pct5.pct_id 
             and p5.contractor_supplier_no = cor0.contractor_supplier_no 
             and pct5.pct_description like 'Withholding tax%' 
             and p5.invoice_date between @startdate and @enddate) 
          >= 0
     and /* Total Paye != 0 */
         (select isnull(convert(decimal(10),round(sum(pc3.pc_amount)*-100,0)),0) 
            from odps.payment p3, odps.payment_component pc3
               , odps.payment_component_type pct3 
           where pc3.invoice_id = p3.invoice_id 
             and pc3.pct_id = pct3.pct_id 
             and p3.contractor_supplier_no = cor0.contractor_supplier_no 
             and pct3.pct_description like 'Withholding tax%' 
             and p3.invoice_date between @startdate and @enddate)
           != 0
   order by c_surname_company asc

END
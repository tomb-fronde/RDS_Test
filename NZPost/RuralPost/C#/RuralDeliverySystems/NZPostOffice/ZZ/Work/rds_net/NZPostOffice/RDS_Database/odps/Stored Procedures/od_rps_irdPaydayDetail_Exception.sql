
CREATE PROCEDURE [odps].[od_rps_irdPaydayDetail_Exception](
	 @startdate datetime
	,@enddate datetime)
AS
BEGIN
  -- TJB IRD Payrun Export  17-Feb-2022
  -- Added c_ird_no heading and right(...,9) to query
  --
  -- TBJ  RPCR_128  June-2019
  -- Adapted from od_rps_ir348Detail_Exception

  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off

  begin transaction
  delete from odps.t_irdPayday

  insert into odps.t_irdPayday
      (contractor_supplier_no, start_date)
  select cor1.contractor_supplier_no,
         cor1.cr_effective_date 
    from rd.contract_renewals  cr1,
         rd.contractor_renewals cor1,
         rd.[contract] c1
   where (cor1.contract_no = cr1.contract_no) 
     and (cor1.contract_seq_number = cr1.contract_seq_number) 
     and (c1.contract_no = cr1.contract_no) 
     and (cr1.contract_seq_number = c1.con_active_sequence 
           or exists(select p.contract_seq_number from odps.payment as p 
                      where p.contractor_supplier_no = cor1.contractor_supplier_no 
                        and p.contract_no = c1.contract_no 
                        and p.invoice_date between @startdate and @enddate)) 
     and (((cr1.con_start_date <= @enddate) 
            and (c1.con_date_terminated is null 
                  or c1.con_date_terminated >= @startdate 
                  or datediff(day,c1.con_date_terminated,'1999-2-21') < 32 
                  or c1.con_date_terminated between @startdate and @enddate)) 
            or   exists(select contractor_supplier_no 
                         from odps.payment 
                        where invoice_date between @startdate and @enddate)) 
     and cor1.cr_effective_date = 
            (select max(cr_effective_date) from rd.contractor_renewals as cor2 
              where cor2.contractor_supplier_no = cor1.contractor_supplier_no)
   group by cor1.contractor_supplier_no, cor1.cr_effective_date
  commit transaction

  select dtl='DTL'
       , c_ird_no = right('0' + (case when len(c_ird_no) = 0 or c_ird_no is null 
                                      then '00000000' 
                                      else c_ird_no 
                                 end)
                          ,9)
       , employee_full_name=left((case when len(c_initials) > 0 
                                       then c_initials + ' ' else '' end) 
                           + c_surname_company,20)
       , tax_code=(case when len(c_ird_no) = 0 or c_ird_no is null 
                        then 'ND' else 'M' end)
       , start_date=case when (select min(cr2.cr_effective_date) 
                                 from rd.contractor_renewals as cr2 
                                where cr2.contractor_supplier_no = cor0.contractor_supplier_no) 
                      between @startdate and @enddate 
                         then convert(char,(select min(cr2.cr_effective_date) 
                                              from rd.contractor_renewals as cr2 
                                             where cr2.contractor_supplier_no = cor0.contractor_supplier_no),112) -- yyyymmdd
                         else  null end
       , end_date=case when (select max(end_date) from odps.t_irdPayday 
                              where contractor_supplier_no = cor0.contractor_supplier_no) 
                       between @startdate and @enddate 
                       then convert(char,(select max(end_date) from odps.t_irdPayday 
                                           where contractor_supplier_no = cor0.contractor_supplier_no),112)
                       else '' end
       , gross_earnings=(select convert(decimal(10),isnull(round(sum(pc1.pc_amount),0)*100,0)) 
                           from odps.payment p1, odps.payment_component pc1
                              , odps.payment_component_type pct1, odps.payment_component_group pcg1
                          where pc1.invoice_id = p1.invoice_id 
                            and pc1.pct_id = pct1.pct_id 
                            and pcg1.pcg_id = pct1.pcg_id 
                            and pcg1.pcg_short_code in('GP','OGP')
                            and p1.contractor_supplier_no = cor0.contractor_supplier_no 
                            and p1.invoice_date between @startdate and @enddate)
       , not_liable=(case when NZ_Post_Employee is null or NZ_Post_Employee = 'N' 
                          then convert(decimal(10),(select convert(decimal(10),isnull(round(sum(pc2.pc_amount),0)*100,0)) 
                                                      from odps.payment p2, odps.payment_component pc2
                                                         , odps.payment_component_type pct2
                                                         , odps.payment_component_group pcg2
                                                     where pc2.invoice_id = p2.invoice_id 
                                                       and pc2.pct_id = pct2.pct_id 
                                                       and pcg2.pcg_id = pct2.pcg_id 
                                                       and pcg2.pcg_short_code in('GP','OGP') 
                                                       and p2.contractor_supplier_no = cor0.contractor_supplier_no 
                                                       and p2.invoice_date between @startdate and @enddate)) 
                          else 0 end)
       , lump_sum=0
       , total_paye=(select isnull(convert(decimal(10),round(sum(pc3.pc_amount)*-100,0)),0) 
                       from odps.payment p3, odps.payment_component pc3
                          , odps.payment_component_type pct3
                      where pc3.invoice_id = p3.invoice_id 
                        and pc3.pct_id = pct3.pct_id 
                        and p3.contractor_supplier_no = cor0.contractor_supplier_no 
                        and pct3.pct_description like 'Withholding tax%' 
                        and p3.invoice_date between @startdate and @enddate)
       , cs_deductions     = 0
       , cs_deduction_code = ''
       , sl_deductions     = 0
       , family_assistance = 0 
    from rd.contractor cor0
   where cor0.contractor_supplier_no 
            = any(select contractor_supplier_no from odps.t_irdPayday) 
     and ((select convert(decimal(10),isnull(round(sum(pc4.pc_amount),0)*100,0)) 
             from odps.payment p4, odps.payment_component pc4
                , odps.payment_component_type pct4
                , odps.payment_component_group pcg4
            where pc4.invoice_id = p4.invoice_id 
              and pc4.pct_id = pct4.pct_id 
              and pcg4.pcg_id = pct4.pcg_id 
              and pcg4.pcg_short_code in('GP','OGP') 
              and p4.contractor_supplier_no = cor0.contractor_supplier_no 
              and p4.invoice_date between @startdate and @enddate) < 0 
          or (select isnull(convert(decimal(10),round(sum(pc5.pc_amount)*-100,0)),0) 
                from odps.payment p5, odps.payment_component pc5
                   , odps.payment_component_type pct5
               where pc5.invoice_id = p5.invoice_id 
                 and pc5.pct_id = pct5.pct_id 
                 and p5.contractor_supplier_no = cor0.contractor_supplier_no 
                 and pct5.pct_description like 'Withholding tax%' 
                 and p5.invoice_date between @startdate and @enddate) < 0) 
   order by c_surname_company asc

END
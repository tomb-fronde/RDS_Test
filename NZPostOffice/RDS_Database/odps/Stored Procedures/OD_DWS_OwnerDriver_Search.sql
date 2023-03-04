
CREATE procedure[odps].[OD_DWS_OwnerDriver_Search](
	  @inOwnerDriver varchar(40)
	, @sdate datetime
	, @edate datetime
	, @inRgCode int
	, @inContractNo int)
-- TJB  RPCR_141  June-2019
-- Added @inRgCode and @inContractNo parameters
-- Changed lookup to take into account specified rg_code and/or contract_no
-- If neither specified, behaviour unchanged.
-- Prettified the code to make it easier to read
--
-- TWC - 11/08/2003 -- changed this procedure to handle contractor / renewal changes
AS
BEGIN
  set NOCOUNT on
  set CONCAT_NULL_YIELDS_NULL off

  select top 1 0,0,odcontracts='<All Contractors/Contracts>',enddate=rd.date(rd.today())  
  UNION
  select distinct 
         c.contract_no,
         cor.contractor_supplier_no,
         c_surname_company 
            + (case when len(c_first_names) > 0 
                    then ',' + c_first_names 
                    else '' 
                    end),
         contractor_end_date
            = (select dateadd(day,-1,min(crx.cr_effective_date)) 
                 from rd.contractor_renewals as crx 
                where crx.contract_no = cr.contract_no 
                  and crx.contract_seq_number = cr.contract_seq_number 
                  and crx.cr_effective_date > corr.cr_effective_date) 
    from rd.contract c,
         rd.contract_renewals cr,
         rd.contractor cor,
         rd.contractor_renewals corr
   where (corr.contractor_supplier_no = cor.contractor_supplier_no) 
     and (corr.contract_no = cr.contract_no) 
     and (corr.contract_seq_number = cr.contract_seq_number) 
         -- TWC - if a renewal has gone through - old renewal may be part of this period
         -- (contract.con_active_sequence = contract_renewals.contract_seq_number) 
     and (cr.contract_seq_number 
            = rd.maxSeqContractor(corr.contract_no,corr.contractor_supplier_no)) 
     and (c.contract_no = cr.contract_no) 
     and (cor.c_surname_company like ISNULL(@inOwnerDriver,'') + '%') 
     and (c.con_date_terminated is null 
            or c.con_date_terminated > @edate 
            or datediff(day,con_date_terminated,@sdate) < 63) 
     and (corr.cr_effective_date <= @edate) 
         -- check that the end date of the contract is smaller than the end date
     and (rd.getContractorEnd(c.contract_no,cor.contractor_supplier_no) 
             >= dateadd(month,-2,@sdate)) 
     and (/*contractor_end_date > @edate*/     
             (select dateadd(day,-1,min(crx.cr_effective_date))
                from rd.contractor_renewals as crx 
               where crx.contract_no = cr.contract_no 
                 and crx.contract_seq_number = cr.contract_seq_number 
                 and crx.cr_effective_date > corr.cr_effective_date)      > @edate 
           or /*contractor_end_date is null*/
                 (select dateadd(day,-1,min(crx.cr_effective_date)) 
                    from rd.contractor_renewals as crx 
                   where crx.contract_no = cr.contract_no 
                     and crx.contract_seq_number = cr.contract_seq_number 
                     and crx.cr_effective_date > corr.cr_effective_date)  is null 
           or /*datediff(day,contractor_end_date,@sdate) < 63*/
              datediff(day
                       ,(select dateadd(day,-1,min(crx.cr_effective_date)) 
                           from rd.contractor_renewals as crx 
                          where crx.contract_no = cr.contract_no 
                            and crx.contract_seq_number = cr.contract_seq_number 
                            and crx.cr_effective_date > corr.cr_effective_date)
                       ,@sdate) < 63)
     -- TJB  RPCR_141  June-2019  Added these 4 lines
     and (@inRgCode is null or @inRgCode = 0
            or @inRgCode = c.rg_code)
     and (@inContractNo is null or @inContractNo = 0
            or @inContractNo = c.contract_no)
                       
END
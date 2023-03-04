
CREATE procedure [rd].[sp_SearchForContract4](@in_Region int, @in_Contract int, @in_ContractTitle varchar(60)
            , @in_ConMSN varchar(6), @in_LastServiceStart datetime ,@in_LastServiceEnd datetime
            , @in_LastDelStart datetime, @in_LastDelEnd datetime, @in_LastWorkStart datetime
            , @in_LastWorkEnd datetime, @in_ContractType int, @in_PbuId int)
AS
BEGIN
  -- TJB RPCR_122 July-2018
  -- Added @in_PbuId as parameter and condition in select
  
  SET NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off
  
  select distinct contract_no
       , con_title
       , con_date_terminated 
    from contract 
   where (contract_no = @in_Contract 
          or @in_Contract = 0) 
     and (con_base_cont_type = @in_ContractType 
          or @in_ContractType = 0) 
     and (con_old_mail_service_no like @in_ConMSN + '%' 
          or @in_ConMSN = '') 
     and (con_title like @in_ContractTitle + '%') 
     and ((con_last_service_review 
               between (case when @in_LastServiceStart is null 
                                  and @in_LastServiceEnd is not null 
                             then cast('1900-1-1' as datetime) 
                             else @in_LastServiceStart 
                             end) 
                   and (case when @in_LastServiceEnd is null 
                                  and @in_LastServiceStart is not null 
                             then getdate() 
                             else @in_LastServiceEnd 
                             end)) 
           or (@in_LastServiceStart is null and @in_LastServiceEnd is null)) 
     and ((con_last_delivery_check 
               between (case when @in_LastDelStart is null
                                  and @in_LastDelEnd is not null 
                             then cast('1900-1-1' as datetime) 
                             else @in_LastDelStart 
                             end) 
                   and (case when @in_LastDelEnd is null 
                                  and @in_LastDelStart is not null 
                             then getdate() 
                             else @in_LastDelEnd 
                             end)) 
           or (@in_LastDelStart is null and @in_LastDelEnd is null)) 
     and ((con_last_work_msrmnt_check 
               between (case when @in_LastWorkStart is null 
                                  and @in_LastWorkEnd is not null 
                             then cast('1900-1-1' as datetime)
                             else @in_LastWorkStart 
                             end) 
                   and (case when @in_LastWorkEnd is null 
                                  and @in_LastWorkStart is not null 
                             then getdate() 
                             else @in_LastWorkEnd 
                             end)) 
           or (@in_LastWorkStart is null and @in_LastWorkEnd is null)) 
     and (@in_Region = 0 
          or con_base_office = any(select outlet_id from outlet 
                                    where region_id = @in_Region)) 
     and (pbu_id = @in_PbuId
          or @in_PbuId = 0)
order by con_title asc
end
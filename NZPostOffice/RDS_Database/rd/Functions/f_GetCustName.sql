
CREATE FUNCTION [rd].[f_GetCustName](@p_cust_id int)
returns varchar(255)
as
begin

  declare @sret varchar(255)
  
  select @sret = (case when c.cust_title is null or c.cust_title = '' then '' else c.cust_title+' ' end) 
                   + (case when c.cust_initials is null or c.cust_initials = '' then '' else c.cust_initials+ ' ' end) 
                   + (case when c.cust_surname_company is null or c.cust_surname_company = '' then '' else c.cust_surname_company end)
    from rd.rds_customer c
   where c.cust_id = @p_cust_id

  return(@sret)
end
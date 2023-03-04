

--
-- Definition for user-defined function OD_MiscF_Get_Invoicenumber : 
--

create function [odps].[OD_MiscF_Get_Invoicenumber](@in_invnumber int,@inPayPeriod_End datetime)
returns char(30)
AS
BEGIN

  declare @v_cinvoicenumber char(30)
  select @v_cinvoicenumber = right(convert(varchar,year(@inPayPeriod_End)),2) + 
left(DATENAME ( month, @inPayPeriod_End),3) + 
right(REPLICATE ('0',10-len(convert(varchar,@in_invnumber))) + 
    convert(varchar,@in_invnumber),4) 
    
  return(@v_cinvoicenumber)
end
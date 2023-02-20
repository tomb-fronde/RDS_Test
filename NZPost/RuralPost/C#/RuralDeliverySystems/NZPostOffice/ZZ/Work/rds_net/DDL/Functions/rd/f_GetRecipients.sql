/****** Object:  UserDefinedFunction [rd].[f_GetRecipients]    Script Date: 08/05/2008 11:24:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--
-- Definition for user-defined function f_GetRecipients : 
--

create function [rd].[f_GetRecipients](@ai_cust_id int)
returns char(2000)
AS
BEGIN

  declare @sret varchar(2000),
  @stemp1 varchar(100),
  @stemp2 varchar(100)
  declare mail_recp /*dynamic scroll mkwang_msd*/ cursor for select rds_customer.cust_initials,
      rds_customer.cust_surname_company from
      rds_customer where
      (rds_customer.master_cust_id = @ai_cust_id)
  open mail_recp
  /* Watcom only
  myloop:
  while 1=1 
    begin*/
      fetch next from  mail_recp into @stemp1,@stemp2
      while @@fetch_status = 0
       begin
        /*break*/
        /* Watcom only
        myloop
        */
      -- TJB 30-Sep-2004 SR4637
      -- Changed to improve performance
      -- (tjb) Trailing linefeed on last recipient irrelevant so don''t need test to eliminate it.
      -- if length(sret) > 0 then
      -- PBY SR#4373,4368 Commented out char(13) so only a newline is used. (char13 is carriage return)
      -- set sret=sret || "char"(10) -- || "char"(13)
      -- end if;
      -- (tjb) Note: Probably meant "ifnull" with stemp1 and stemp2 switched around
      --    set sret=sret+' '+stemp1+' '+isnull(stemp2,'',', '+' '+stemp2)
      select @sret=isnull(@sret,'')+isnull(@stemp1,'')+' '+isnull(@stemp2,'')+char(10)
      fetch next from  mail_recp into @stemp1,@stemp2
    end
  close mail_recp
  return(@sret)
end
GO

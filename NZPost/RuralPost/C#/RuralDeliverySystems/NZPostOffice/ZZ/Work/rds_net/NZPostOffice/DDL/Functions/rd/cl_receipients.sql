/****** Object:  UserDefinedFunction [rd].[cl_receipients]    Script Date: 08/05/2008 11:23:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create function [rd].[cl_receipients](@icust_id int)
returns char(2000)
AS
BEGIN

  declare @sret char(2000),
  @stemp1 char(100),
  @stemp2 char(100)
  declare mail_recp /*dynamic scroll mkwang_msd*/ cursor for select recipient.rc_surname_company,
      recipient.rc_first_names from
      rd.recipient where
      (recipient.cust_id = @icust_id)
 open mail_recp
  /* Watcom only
  myloop:
 while 1=1 
    begin */
      fetch next FROM mail_recp into @stemp1,@stemp2
      while @@fetch_status = 0
      begin
        /*break*/
        /* Watcom only
        myloop
        */
      if len(@sret) > 0
        select @sret=@sret + CHAR(10) + CHAR(13)
      select @sret=@sret + @stemp1 + case when isnull(@stemp2,'') = '' THEN '' ELSE ', ' END  + @stemp2   
      fetch next FROM mail_recp into @stemp1,@stemp2
    end
  close mail_recp
  return(@sret)
end
GO

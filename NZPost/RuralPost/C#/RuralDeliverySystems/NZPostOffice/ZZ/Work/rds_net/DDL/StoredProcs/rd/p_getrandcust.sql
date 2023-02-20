/****** Object:  StoredProcedure [rd].[p_getrandcust]    Script Date: 08/05/2008 10:17:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure p_getrandcust : 
--
create procedure [rd].[p_getrandcust](@xrequired int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @xrand int,
  @xcust_id int,
  @xcount int,
  @xnum int,
  @xcust_title char(10),
  @xcust_surname_company char(45),
  @xcust_initials char(16),
  @xcust_mailing_address_no char(9),
  @xcust_mailing_address_road char(45),
  @xcust_mailing_address_locality char(45),
  @xcust_mail_town char(45),
  @xcust_rd_number char(40),
  @xcon_rd_ref_text char(35),
  @xuzed int,
  @xerr int
  /* Watcom only
  err_notfound exception for sqlstate value '02000'
  */
  /* Watcom only
    local temporary table tmp_mine(
    cust_title char(10) null,
    cust_surname_company char(45) null,
    cust_initials char(16) null,
    cust_mailing_address_no char(9) null,
    cust_mailing_address_road char(45) null,
    cust_mailing_address_locality char(45) null,
    cust_mail_town char(45) null,
    cust_rd_number char(40) null,
    con_rd_ref_text char(35) null,
    uzed integer null,
    ) on commit delete rows
  */
  declare CurCust cursor for select distinct
      customer.cust_title,
      customer.cust_surname_company,
      customer.cust_initials,
      customer.cust_mailing_address_no,
      customer.cust_mailing_address_road,
      customer.cust_mailing_address_locality,
      customer.cust_mail_town,
      customer.cust_rd_number,
      contract.con_rd_ref_text,
      customer.cust_id from
      contract,
      customer,
      tmp_rand_cust_list where
      (contract.contract_no = customer.contract_no) and
      (customer.cust_id = tmp_rand_cust_list.cust_id)
  select @xnum=Count(*) from tmp_rand_cust_list
  if @xnum = 0
    raiserror 17001 'No rows to return'
  open CurCust
  select @xcount=1
  /* Watcom only
  CursorLoop:
  */while 1=1 
    begin
      select @xrand=(rand()*@xnum)
      select @xrand=round(@xrand,0)
      if @xcount > @xrequired
        break
        /* Watcom only
        CursorLoop
        */
      if @xrand <> 0
        /* Watcom only
        FetchLoop:
        */while 1=1 
          begin
              /* Watcom only
              absolute @xrand CurCust
            */
            fetch next from CurCust into @xcust_title,
              @xcust_surname_company,
              @xcust_initials,
              @xcust_mailing_address_no,
              @xcust_mailing_address_road,
              @xcust_mailing_address_locality,
              @xcust_mail_town,
              @xcust_rd_number,
              @xcon_rd_ref_text,
              @xuzed
            select @xerr=@@error
            if @@FETCH_STATUS < 0
              break
              /* Watcom only
              CursorLoop
              */
            if @xerr <> 0
              begin
                close CurCust
                --raiserror (@xerr, 10, 1)--
              end
            if not exists(select uzed from tmp_mine where uzed = @xuzed)
              begin
                select @xnum=@xnum-1
                select @xcount=@xcount+1
                insert into tmp_mine(cust_title,
                  cust_surname_company,
                  cust_initials,
                  cust_mailing_address_no,
                  cust_mailing_address_road,
                  cust_mailing_address_locality,
                  cust_mail_town,
                  cust_rd_number,
                  con_rd_ref_text,
                  uzed) values(
                  @xcust_title,
                  @xcust_surname_company,
                  @xcust_initials,
                  @xcust_mailing_address_no,
                  @xcust_mailing_address_road,
                  @xcust_mailing_address_locality,
                  @xcust_mail_town,
                  @xcust_rd_number,
                  @xcon_rd_ref_text,
                  @xuzed)
                if @xnum = 0
                  break
                  /* Watcom only
                  CursorLoop
                  */
                break
                /* Watcom only
                FetchLoop
                */
              end
            else
              begin
                select @xrand=@xrand+1
                if @xrand > @xnum
                  select @xrand=1
              end
          end
    end
  close CurCust
  select cust_title,
    cust_surname_company,
    cust_initials,
    cust_mailing_address_no,
    cust_mailing_address_road,
    cust_mailing_address_locality,
    cust_mail_town,
    cust_rd_number,
    con_rd_ref_text from
    tmp_mine
end
GO

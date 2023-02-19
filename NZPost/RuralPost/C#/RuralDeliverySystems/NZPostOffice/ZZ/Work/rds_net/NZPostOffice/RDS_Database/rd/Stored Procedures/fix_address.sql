create procedure [rd].[fix_address]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @v_cust int,
  @v_road char(45),
  @v_no char(45),
  @v_1char char(1),
  @v_ctr int
  declare c1 cursor for select custid from t_rand_customer
  insert into t_rand_customer
    select cust_id from rd.customer where
      (cust_mailing_address_no is null or len(cust_mailing_address_no) = 0) and
      ascii(left(cust_mailing_address_road,1)) between 48 and 57
  if @@error <> 0 /* <> was < */ RAISERROR('',10,1)
    /* Watcom only
    resignal
    */
  open c1
  /* Watcom only
  fixloop:
  */while 1=1 
    begin
      fetch next from c1 into @v_cust
      if @@fetch_status <0
        break
        /* Watcom only
        fixloop
        */
      if @@error <> 0 RAISERROR('',10,1)
        /* Watcom only
        resignal
        */
      select @v_road = cust_mailing_address_road from rd.customer where cust_id = @v_cust
      if @@error <> 0 /* <> was < */ RAISERROR('',10,1)
        /* Watcom only
        resignal
        */
      select @v_ctr=0
      select @v_no=''
      select @v_ctr=0
      while @v_ctr < 9
        begin
          select @v_ctr=@v_ctr+1
          select @v_1char=substring(@v_road,@v_ctr,1)
          if ascii(@v_1char) between 48 and 57
            select @v_no=@v_no + @v_1char else
          if ascii(@v_1char) <> 32
            begin
              select @v_no=''
              select @v_ctr=99
            end
        end
      if len(@v_no) > 0
        update rd.customer set cust_mailing_address_no = @v_no,
          cust_mailing_address_road = right(rd.cust_mailing_address_road, case when len(rd.trim(cust_mailing_address_road))-len(@v_no) >=0 then len(rd.trim(cust_mailing_address_road))-len(@v_no) else 0 end  ) where
          cust_id = @v_cust
      if @@error <> 0 /* <> was < */ RAISERROR('',10,1)
        /* Watcom only
        resignal
        */
    end
  close c1
  if @@error <> 0 /* <> was < */ RAISERROR('',10,1)
    /* Watcom only
    resignal
    */
  if @@error <> 0 /* <> was < */
    begin
      rollback transaction
		RAISERROR('',10,1)
      /* Watcom only
      resignal
      */
    end
  commit transaction
  return(0)
end

CREATE FUNCTION [rd].[f_getAdrDeliveryDays](@adr_id int)
RETURNS int
AS
BEGIN
  -- ===========================================================
  -- = TJB 23-Apr-2012  RPCR_036   New                         =
  -- = Return the total number of delivery days for an address =
  -- = Hacked from f_getFrequency                              =
  -- ===========================================================

  declare @lv_Result varchar(8)
  declare @lv_freq char(7)
  declare @lv_temp varchar(7)
  declare @li_x int
  declare @li_total int
  declare @ls_terminal char(1)
  
  declare c1 cursor for 
      select address_frequency.rf_delivery_days 
        from address_frequency,
             route_frequency 
       where address_frequency.adr_id = @adr_id
         and address_frequency.sf_key = route_frequency.sf_key 
         and address_frequency.rf_delivery_days = route_frequency.rf_delivery_days 
         and address_frequency.contract_no = route_frequency.contract_no 
         and route_frequency.rf_active = 'Y' 
         
  select @lv_result=''
  select @lv_temp=''
  select @lv_freq=''

  open c1
  if @@error <> 0 /* <> was < */
  begin
      --select ''
      return ''
  end

  while 1=1 
  begin
      fetch next from c1 into @lv_freq
      if @@FETCH_STATUS = -2
      begin
          --select ''
          return ''
      end
      if @@FETCH_STATUS = -1
          break

      select @lv_freq=rd.TRIM(@lv_freq)
      select @li_x=1

      if @lv_result = ''
          select @lv_result=@lv_freq
      else
      begin
          select @lv_temp=''
          while @li_x <= len(@lv_freq)
          begin
              if substring(@lv_freq,@li_x,1) = 'Y' or substring(@lv_result,@li_x,1) = 'Y'
                  if @li_x = 1
                      select @lv_temp='Y'
                  else
                      select @lv_temp=(@lv_temp+'Y')
              else
                  if @li_x = 1
                      select @lv_temp='N'
                  else
                      select @lv_temp=(@lv_temp+'N')
              select @li_x=@li_x+1
          end
          select @lv_result=@lv_temp
      end
  end
  close c1
  DEALLOCATE c1

  -- Work out total number of 'Y's and append this information 
  -- at the end of the string
  select @li_x=1
  select @li_total=0
  while @li_x <= len(@lv_result)
  begin
      if substring(@lv_result,@li_x,1) = 'Y'
          select @li_total=@li_total+1
      select @li_x=@li_x+1
  end
  --return @lv_result+CAST(@li_total AS VARCHAR)
  return @li_total
END
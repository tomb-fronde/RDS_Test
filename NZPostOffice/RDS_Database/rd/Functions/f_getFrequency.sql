CREATE FUNCTION [rd].[f_getFrequency](
	@address_id int,
	@pi_contract_no int,
	@ps_terminal char(1))
RETURNS char(8)
AS
BEGIN
  -- =======================================================
  -- = TJB Sequencing Review Jan 2011                      =
  -- = New version - Uses address_frequency table          =
  -- =               instead of address_frequency_sequence =
  -- =======================================================

  -- If contract number is passed in,
  -- we are trying to find the frequencies for terminal points
  declare @lv_Result varchar(8)
  declare @lv_freq char(7)
  declare @lv_temp varchar(7)
  declare @li_x int
  declare @li_total int
  declare @ls_terminal char(1)
  
  declare c1 cursor for 
      select rf_delivery_days 
        from route_description 
       where adr_id = @address_id 
         and contract_no = @pi_contract_no 
         and @ps_terminal = 'Y' 
      union
      select address_frequency.rf_delivery_days 
        from address_frequency,
             address,
             route_frequency 
       where address.adr_id = address_frequency.adr_id 
         and address_frequency.sf_key = route_frequency.sf_key 
         and address_frequency.rf_delivery_days = route_frequency.rf_delivery_days 
         and address_frequency.contract_no = route_frequency.contract_no 
         and route_frequency.rf_active = 'Y' 
         and address.adr_id = @address_id 
         and @ps_terminal <> 'Y'
         
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
--   at the end of the string
  select @li_x=1
  select @li_total=0
  while @li_x <= len(@lv_result)
    begin
      if substring(@lv_result,@li_x,1) = 'Y'
        select @li_total=@li_total+1
      select @li_x=@li_x+1
    end
  --select @lv_result+CAST(@li_total AS VARCHAR)
  return @lv_result+CAST(@li_total AS VARCHAR)
END
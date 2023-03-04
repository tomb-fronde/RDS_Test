
CREATE PROCEDURE rd.Update_Frequency_Ind( 
    @contract_no int, 
    @valid_date datetime, 
    @valid_ind int,
    @valid_user varchar(20), 
    @rf_frozen int)
AS
BEGIN
  declare @sf_key int
  declare @delivery_days char(7)

  declare c1 cursor for
          select sf_key, rf_delivery_days 
            from route_frequency
           where contract_no = @contract_no
             and rf_active = 'Y'
           order by sf_key

  open c1

  while 1 = 1
  begin
    FETCH next FROM c1 INTO @sf_key, @delivery_days

    if @@FETCH_STATUS = -1
        break

    UPDATE route_frequency 
       SET rf_valid_date=@valid_date
         , rf_valid_ind=@valid_ind
         , rf_valid_user=@valid_user
         , rf_frozen=@rf_frozen
     WHERE route_frequency.contract_no = @contract_no
       AND route_frequency.rf_active = 'Y' 
       AND route_frequency.sf_key = @sf_key
       AND route_frequency.rf_delivery_days = @delivery_days
  
  end
  close c1
  deallocate c1
end
create procedure [rd].[sp_SequenceCust](@inContract int,@inSfKey int,@inDays char(7),@inCustid integer,@inPreCustid integer,@inSeq int) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  insert into cust_frequency_order(contract_no,sf_key,rf_delivery_days,cust_id,cfo_previous_customer,cfo_sequence) values(
    @inContract,@inSfKey,@inDays,@inCustid,@inPreCustid,@inSeq)
  if @inSfKey = 1
    update customer set
      sf_key1 = 1 where
      cust_id = @inCustid
  if @inSfKey = 2
    update customer set
      sf_key2 = 1 where
      cust_id = @inCustid
  if @inSfKey = 3
    update customer set
      sf_key3 = 1 where
      cust_id = @inCustid
  if @inSfKey = 4
    update customer set
      sf_key4 = 1 where
      cust_id = @inCustid
  if @inSfKey = 5
    update customer set
      sf_key5 = 1 where
      cust_id = @inCustid
  if @inSfKey = 6
    update customer set
      sf_key6 = 1 where
      cust_id = @inCustid
  if @inSfKey = 7
    update customer set
      sf_key7 = 1 where
      cust_id = @inCustid
  if @inSfKey = 8
    update customer set
      sf_key8 = 1 where
      cust_id = @inCustid
  if @inSfKey = 9
    update customer set
      sf_key9 = 1 where
      cust_id = @inCustid
end
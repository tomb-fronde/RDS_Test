/****** Object:  StoredProcedure [rd].[sp_resequencecusts]    Script Date: 08/05/2008 10:22:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[sp_resequencecusts](@inContract int,@inSfKey int,@inDays char(7)) AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @nSequence integer,
  @nCustomer integer,
  @nCount integer
  select @nSequence=0
  select @nCustomer=0
  select @nCount=count(*) 
    from cust_frequency_order where
    contract_no = @inContract and
    sf_key = @inSFKey and
    rf_delivery_days = @inDays
  if @nCount > 0
    /* Watcom only
    SequenceLoop:
    */while 1=1 
      begin
        select @nCustomer=cust_id 
          from cust_frequency_order where
          contract_no = @inContract and
          sf_key = @inSFKey and
          rf_delivery_days = @inDays and
          cfo_previous_customer = @nCustomer
        select @nSequence=@nSequence+1
        update cust_frequency_order set
          cfo_sequence = @nSequence where
          contract_no = @inContract and
          sf_key = @inSFKey and
          rf_delivery_days = @inDays and
          cust_id = @nCustomer
        if @inSFKey = 1
          update customer set
            sf_key1 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 2
          update customer set
            sf_key2 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 3
          update customer set
            sf_key3 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 4
          update customer set
            sf_key4 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 5
          update customer set
            sf_key5 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 6
          update customer set
            sf_key6 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 7
          update customer set
            sf_key7 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 8
          update customer set
            sf_key8 = 1 where
            cust_id = @nCustomer
        if @inSFKey = 9
          update customer set
            sf_key9 = 1 where
            cust_id = @nCustomer
        if @nSequence = @nCount
          break
          /* Watcom only
          SequenceLoop
          */
      end
end
GO

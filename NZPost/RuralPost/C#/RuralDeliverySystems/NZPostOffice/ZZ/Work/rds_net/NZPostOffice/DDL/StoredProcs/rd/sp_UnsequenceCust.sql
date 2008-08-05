/****** Object:  StoredProcedure [rd].[sp_UnsequenceCust]    Script Date: 08/05/2008 10:23:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_UnsequenceCust : 
--

create procedure [rd].[sp_UnsequenceCust](@inContract int,@inSfKey int,@inCustid int,@inRf_delivery_days char(7)) 
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  if @inSfKey = 1
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key1 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 2
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key2 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 3
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key3 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 4
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key4 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 5
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key5 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 6
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key6 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 7
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key7 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 8
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key8 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
  if @inSfKey = 9
    begin
      delete from cust_frequency_order where
        contract_no = @inContract and
        cust_id = @inCustid and
        sf_key = @inSfKey and
        rf_delivery_days = @inRf_delivery_days
      update customer set
        sf_key9 = 0 where
        contract_no = @inContract and
        cust_id = @inCustid
    end
end
GO

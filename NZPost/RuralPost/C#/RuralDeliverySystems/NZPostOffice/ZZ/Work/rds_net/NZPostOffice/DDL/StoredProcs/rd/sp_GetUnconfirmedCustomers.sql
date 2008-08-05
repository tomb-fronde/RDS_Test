/****** Object:  StoredProcedure [rd].[sp_GetUnconfirmedCustomers]    Script Date: 08/05/2008 10:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure sp_GetUnconfirmedCustomers : 
--

create procedure [rd].[sp_GetUnconfirmedCustomers](@Inregion int,@inOutlet int,@inContract int,@indate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  if @indate is not null
    select region.rgn_name,
      outlet.o_name,contract_no,
      con_title,
      count1=(select count(*) from
        customer where
        (customer.contract_no = contract.contract_no) and
        (cust_date_first_loaded <= @indate) and
        ((customer.cust_date_commenced is null) or(customer.cust_date_commenced >= @indate))) from
      outlet,
      region,
      contract where
      (region.region_id = outlet.region_id) and
      (outlet.outlet_id = contract.con_base_office) and
      (contract.con_active_sequence > 0) and
      ((@incontract = contract.contract_no and
      @incontract > 0) or
      (@inoutlet = contract.con_base_office and
      @inoutlet > 0 and
      @incontract = 0) or
      (@inregion = outlet.region_id and
      @inregion > 0 and
      @inoutlet = 0 and @incontract = 0) or
      (@inRegion = 0 and @inoutlet = 0 and @incontract = 0))
  else
    select region.rgn_name,
      outlet.o_name,contract_no,
      con_title,
      count1=(select count(*) from
        customer where
        (customer.contract_no = contract.contract_no) and
        ((customer.cust_date_commenced is null))) from
      outlet,
      region,
      contract where
      (region.region_id = outlet.region_id) and
      (outlet.outlet_id = contract.con_base_office) and
      (contract.con_active_sequence > 0) and
      ((@incontract = contract.contract_no and
      @incontract > 0) or
      (@inoutlet = contract.con_base_office and
      @inoutlet > 0 and
      @incontract = 0) or
      (@inregion = outlet.region_id and
      @inregion > 0 and
      @inoutlet = 0 and @incontract = 0) or
      (@inRegion = 0 and @inoutlet = 0 and @incontract = 0))
end
GO

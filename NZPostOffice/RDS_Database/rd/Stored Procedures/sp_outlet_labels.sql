
--
-- Definition for stored procedure sp_outlet_labels : 
--

create procedure [rd].[sp_outlet_labels](@in_Region int,@in_phyFlag int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB SR4647  Feb 2005
  -- Added the 'distinct' and additional conditions to return 
  -- only outlets that are the base office of at least one 
  -- non-terminated 'Rural Delivery' contract.
  -- TJB  SR4647 part2  June 2005
  -- Added in_phyFlag: Use physical address if available if = 1
  if @in_phyFlag = 0
    -- This is the original query: use the postal address omly
    select distinct
      o.o_name,
      o.o_address,
      o.o_manager,
      ot.ot_outlet_type from
      rd.outlet as o,
      rd.outlet_type as ot,
      rd.contract as c,
      rd.types_for_contract as tc,
      rd.contract_type as ct where
      (o.region_id = @in_Region or @in_Region = 0) and
      o.o_name <> 'Non-RD Dummy' and
      ot.ot_code = o.ot_code and
      c.con_base_office = o.outlet_id and
      con_date_terminated is null and
      tc.contract_no = c.contract_no and
      tc.ct_key = 1 -- Rural Delivery Contracts only
  else
    -- This query has been added (TJB June05)
    -- Use the physical address if there is one, otherwise the postal address
    -- (otherwise the queries are identical)
    select distinct
      o.o_name,
      case when o.o_phy_address is null then o.o_address else (case when o.o_phy_address = '' then
        o.o_address
      else o.o_phy_address
      end) end ,o.o_manager,
      ot.ot_outlet_type from
      rd.outlet as o,
      rd.outlet_type as ot,
      rd.contract as c,
      rd.types_for_contract as tc,
      rd.contract_type as ct where
      (o.region_id = @in_Region or @in_Region = 0) and
      o.o_name <> 'Non-RD Dummy' and
      ot.ot_code = o.ot_code and
      c.con_base_office = o.outlet_id and
      con_date_terminated is null and
      tc.contract_no = c.contract_no and
      tc.ct_key = 1 -- Rural Delivery Contracts only
end
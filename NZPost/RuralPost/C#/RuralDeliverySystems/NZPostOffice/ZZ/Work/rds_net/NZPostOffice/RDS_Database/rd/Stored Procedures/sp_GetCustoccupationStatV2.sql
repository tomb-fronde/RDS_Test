

--
-- Definition for stored procedure sp_GetCustoccupationStatV2 : 
--

--
-- Definition for stored procedure sp_GetCustoccupationStatV2 : 
--

create procedure [rd].[sp_GetCustoccupationStatV2](@inRegion int,@inOutlet int,@inContractType int,@inPrivacy int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @lCount integer
  if @inPrivacy = 1
    begin
      select @lCount=count(*)  from t_custstat where id = 0
      if @lcount = 1
        select region=region.rgn_name,
          occupation=occupation.occupation_description,
          occupationcount=(select count(rds_customer.cust_id) from
            address,
            contract,
            customer_address_moves,
            customer_occupation,
            outlet,
            rds_customer where
            (contract.contract_no = address.contract_no) and
            (customer_address_moves.adr_id = address.adr_id) and
            (occupation.occupation_id = customer_occupation.occupation_id) and
            (rds_customer.cust_id = customer_address_moves.cust_id) and
            (region.region_id = outlet.region_id) and
            (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
            (outlet.outlet_id = contract.con_base_office) and
            ((contract.con_base_cont_type = @inContractType) or(@inContractType = 0 or @inContractType is null)) and
            (customer_occupation.cust_id = rds_customer.cust_id) and
            ((rds_customer.master_cust_id is null) and
            (customer_address_moves.move_out_date is null))) from
          region,occupation where
          (region.region_id = @inRegion or @inRegion = 0)
      else
        select region=region.rgn_name,
          occupation=occupation.occupation_description,
          occupationcount=(select count(rds_customer.cust_id) from
            address,
            contract,
            customer_address_moves,
            customer_occupation,
            outlet,
            rds_customer where
            (contract.contract_no = address.contract_no) and
            (customer_address_moves.adr_id = address.adr_id) and
            (occupation.occupation_id = customer_occupation.occupation_id) and
            (rds_customer.cust_id = customer_address_moves.cust_id) and
            (region.region_id = outlet.region_id) and
            (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
            (outlet.outlet_id = contract.con_base_office) and
            ((contract.con_base_cont_type = @inContractType) or(@inContractType = 0 or @inContractType is null)) and
            (customer_occupation.cust_id = rds_customer.cust_id) and
            ((rds_customer.master_cust_id is null) and
            (customer_address_moves.move_out_date is null))) from
          region,occupation where
          (occupation_id = any(select id from t_custstat)) and
          (region.region_id = @inRegion or @inRegion = 0)
    end
  else
    begin
      select @lCount=count(*) from t_custstat where id = 0
      if @lcount = 1
        select region=region.rgn_name,
          occupation=occupation.occupation_description,
          occupationcount=(select count(rds_customer.cust_id) from
            address,
            contract,
            customer_address_moves,
            customer_occupation,
            outlet,
            rds_customer where
            (contract.contract_no = address.contract_no) and
            (customer_address_moves.adr_id = address.adr_id) and
            (occupation.occupation_id = customer_occupation.occupation_id) and
            (rds_customer.cust_id = customer_address_moves.cust_id) and
            (region.region_id = outlet.region_id) and
            (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
            (outlet.outlet_id = contract.con_base_office) and
            ((contract.con_base_cont_type = @inContractType) or(@inContractType = 0 or @inContractType is null)) and
            (customer_occupation.cust_id = rds_customer.cust_id) and
            ((rds_customer.master_cust_id is null) and
            (rds_customer.cust_dir_listing_ind = 'Y') and
            (customer_address_moves.move_out_date is null))) from
          region,occupation where
          (region.region_id = @inRegion or @inRegion = 0)
      else
        select region=region.rgn_name,
          occupation=occupation.occupation_description,
          occupationcount=(select count(rds_customer.cust_id) from
            address,
            contract,
            customer_address_moves,
            customer_occupation,
            outlet,
            rds_customer where
            (contract.contract_no = address.contract_no) and
            (customer_address_moves.adr_id = address.adr_id) and
            (occupation.occupation_id = customer_occupation.occupation_id) and
            (rds_customer.cust_id = customer_address_moves.cust_id) and
            (region.region_id = outlet.region_id) and
            (outlet.outlet_id = @inOutlet or @inOutlet = 0) and
            (outlet.outlet_id = contract.con_base_office) and
            ((contract.con_base_cont_type = @inContractType) or(@inContractType = 0 or @inContractType is null)) and
            (customer_occupation.cust_id = rds_customer.cust_id) and
            ((rds_customer.master_cust_id is null) and
            (rds_customer.cust_dir_listing_ind = 'Y') and
            (customer_address_moves.move_out_date is null))) from
          region,occupation where
          (occupation_id = any(select id from t_custstat)) and
          (region.region_id = @inRegion or @inRegion = 0)
    end
end

-- select [rd].[f_CheckVehicleOwnership]('HFC768', 4290)

CREATE FUNCTION [RD].[f_CheckVehicleOwnership] (
          @inVehicleRegNo varchar(10)
        , @inContractNo   int)
-- TJB Frequencies & Vehicles  Dec-2020  NEW
--
RETURNS int
AS
BEGIN
	-- Given a vehicle registration number and contract number, return 
	--  0 - new vehicle
	--  1 - Existing vehicle owned by this contractor or not by anyone
	--  2 - Existing vehicle for another contractor
	--  3 - Existing vehicle already associated with this contract
	-- -1 - Some other error
	-- ("owned by " means the contractor who owns a current contract
	--  and that the vehicle is associated with.  The vehicle may be
	--  associated with more than one current contract.)

  declare @ContractSeqNo  int
        , @ContractorNo   int
		, @VehicleNo      int
		, @TempResult     int
		, @ReturnValue    int

  -- Get the current contract sequence number for this contract
  select @ContractSeqNo = rd.GetConSeqNo( @inContractNo)

  -- Get the contractor for this contract 
  -- (assumed owner of any vehicles associated with this contract)
  select @ContractorNo = cr.contractor_supplier_no
    from rd.contractor_renewals cr
   where cr.contract_no = @inContractNo
     and cr.contract_seq_number = @ContractSeqNo

  -- Default - this is a new vehicle
  select @ReturnValue = 0
       , @TempResult  = 0

  -- Check to see if we already know this vehicle
  -- - it may or may not be associated with one or more current contracts
  --   that may or may not be current
  select @TempResult = 1
       , @VehicleNo  = v.vehicle_number
    from rd.vehicle v
   where v.v_vehicle_registration_number = @inVehicleRegNo

   -- Check to see if this vehicle is associated with a current contract
   -- and if so, who owns it.
   if( @TempResult = 1)
   begin
       -- Does the contractor already own this vehicle (may be in another contract)
       select @ReturnValue = 1
	     from rd.contract_vehical cv
		where cv.vehicle_number = @VehicleNo
		  and cv.contract_no in 
		           (select cr.contract_no
                      from rd.contractor_renewals cr, contract c
                     where cr.contractor_supplier_no = @ContractorNo
                       and cr.contract_seq_number    = rd.GetConSeqNo(cr.contract_no)
	                   and c.contract_no = cr.contract_no
	                   and c.con_date_terminated is null)
		  and cv.contract_seq_number = rd.GetConSeqNo(cv.contract_no)

       -- This contractor already owns this vehicle; is it already associated with this contract
       if (@ReturnValue = 1)
	   begin
	       select @ReturnValue = 3
		     from rd.contract_vehical cv
            where cv.vehicle_number = @VehicleNo
			  and cv.contract_no    = @inContractNo
			  and cv.contract_seq_number = @ContractSeqNo
	   end

	   -- Finally, is this vehicle owned by a different contractor
       select @ReturnValue = 2
	     from rd.contract_vehical cv
		where cv.vehicle_number = @VehicleNo
		  and cv.contract_no in 
		           (select cr.contract_no
                      from rd.contractor_renewals cr, contract c
                     where cr.contractor_supplier_no != @ContractorNo
                       and cr.contract_seq_number    = rd.GetConSeqNo(cr.contract_no)
	                   and c.contract_no = cr.contract_no
	                   and c.con_date_terminated is null)
		  and cv.contract_seq_number = rd.GetConSeqNo(cv.contract_no)

   end

   if (@TempResult = 1 and @ReturnValue = 0)
       select @ReturnValue = 1

   return @ReturnValue
END
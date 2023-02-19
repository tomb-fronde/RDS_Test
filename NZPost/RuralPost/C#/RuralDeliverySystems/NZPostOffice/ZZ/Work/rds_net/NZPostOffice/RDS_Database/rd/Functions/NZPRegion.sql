
--
-- Definition for user-defined function NZPRegion : 
--

CREATE function [rd].[NZPRegion](
	@inRegion int,
	@inOutlet int,
	@inRenGroup int)
returns decimal(10,2)
AS
BEGIN
  -- TJB RPCR_017 July-2010: added ca_approved condition

  declare @dReturn decimal(10,2),
  @dTotal decimal(10,2)
  select @dTotal = sum(isnull(contract_renewals.con_renewal_payment_value,0))
    from contract_renewals join [contract] as aa 
                  on   contract_renewals.contract_no = aa.contract_no 
                   and contract_renewals.contract_seq_number = aa.con_active_sequence,
         [contract] join outlet 
                  on   [contract].con_base_office = outlet.outlet_id 
                   and (outlet.region_id = @inRegion or @inRegion = 0) 
                   and (outlet.outlet_id = @inOutlet or @inOutlet = 0) 
   where [contract].con_date_terminated is null 
     and contract_renewals.contract_no = [contract].contract_no 
     and contract_renewals.contract_seq_number = [contract].con_active_sequence 
     and ([contract].rg_code = @inRenGroup or @inRenGroup = 0)
     
  select @dReturn=isnull(@dTotal,0)
  
  select @dTotal = sum(isnull(frequency_adjustments.fd_amount_to_pay,0))
    from contract_renewals join [contract] as aa 
                  on   contract_renewals.contract_no = aa.contract_no 
                   and contract_renewals.contract_seq_number = aa.con_active_sequence 
             join frequency_adjustments 
                  on   contract_renewals.contract_no = frequency_adjustments.contract_no 
                   and contract_renewals.contract_seq_number = frequency_adjustments.contract_seq_number 
                   and frequency_adjustments.fd_confirmed = 'Y',
         [contract] join outlet 
                  on   [contract].con_base_office = outlet.outlet_id 
                   and (outlet.region_id = @inRegion or @inRegion = 0) 
                   and (outlet.outlet_id = @inOutlet or @inOutlet = 0) 
   where [contract].con_date_terminated is null 
     and contract_renewals.contract_no = [contract].contract_no 
     and contract_renewals.contract_seq_number = [contract].con_active_sequence 
     and ([contract].rg_code = @inRenGroup or @inRenGroup = 0)
     
  select @dReturn=@dReturn+isnull(@dTotal,0)
  
  select @dTotal = sum(isnull(contract_allowance.ca_annual_amount,0))
    from contract_renewals join [contract] as aa 
                  on   contract_renewals.contract_no = aa.contract_no 
                   and contract_renewals.contract_seq_number = aa.con_active_sequence 
             join contract_allowance 
                  on   contract_renewals.contract_no = contract_allowance.contract_no,
         [contract] join outlet 
                  on   [contract].con_base_office = outlet.outlet_id 
                   and (outlet.region_id = @inRegion or @inRegion = 0) 
                   and (outlet.outlet_id = @inOutlet or @inOutlet = 0) 
   where [contract].con_date_terminated is null 
     and contract_renewals.contract_no = [contract].contract_no 
     and contract_renewals.contract_seq_number = [contract].con_active_sequence 
     and ([contract].rg_code = @inRenGroup or @inRenGroup = 0)
     and contract_allowance.ca_approved = 'Y'  -- TJB RPCR_017 July-2010: added

  select @dReturn=@dReturn+isnull(@dTotal,0)
  
  if @dReturn = 0
    select @dReturn=null
    
  return @dReturn
end
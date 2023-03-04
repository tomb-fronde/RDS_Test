
CREATE function [odps].[OD_RPF_PCTGetSum](
	  @Invoice int
	, @ShortCode char(5))
RETURNS decimal(12,2)
AS
BEGIN
  -- TJB  RPCR_094  Mar-2015
  -- Added fake ShortCode of 'CP' to return the contract payment value
  -- of an invoice for.  Used in OD_RPS_TNegativePay to get the actual
  -- payment when the calculated net pay is negative.
  
  declare @amt decimal(12,2)
  
  if ( @ShortCode = 'CP' )
  begin
      select @amt = sum(t_payment_component.pc_amount) 
        from odps.t_payment_component
       where t_payment_component.invoice_id = @Invoice
         and t_payment_component.pct_id = 2 
  end
  else
  begin
      select @amt = sum(t_payment_component.pc_amount) 
        from t_payment_component
           , payment_component_type
           , payment_component_group 
       where t_payment_component.invoice_id = @invoice 
         and t_payment_component.pct_id = payment_component_type.pct_id 
         and -- Added 16/09/1999,this stops it from adding Kiwimail ,Courierpost and XP.
             -- So that the extension ,Standard and allowance are the only values that are 
             -- calculated.  
             payment_component_type.pct_id <> 7 
         and payment_component_type.pct_id <> 9 
         and payment_component_type.pct_id <> 13 
         and payment_component_type.pcg_id = payment_component_group.pcg_id 
         and payment_component_group.pcg_short_code = @ShortCode
  end
     
  if @amt is null
    return 0
  else
    return @amt
return -1
end
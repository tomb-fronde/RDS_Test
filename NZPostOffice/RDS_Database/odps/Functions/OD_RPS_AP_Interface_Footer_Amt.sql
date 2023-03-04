

--
-- Definition for user-defined function OD_RPS_AP_Interface_Footer_Amt : 
--

create function  [odps].[OD_RPS_AP_Interface_Footer_Amt](@INV int,@inac int)
returns decimal (18,2)
AS
BEGIN

	declare @damt decimal (18,2)
	(select @damt=sum(case when pcgx.pcg_short_code = 'GST' then abs(pcx.pc_amount) else pcx.pc_amount end)  
		from payment_component as pcx,payment_component_type as pctx,payment_component_group as pcgx where
    pcx.invoice_id = @INV and pcx.pct_id = pctx.pct_id and pctx.pcg_id = pcgx.pcg_id and
    (pctx.ac_id = @inac))
    return @damt
end
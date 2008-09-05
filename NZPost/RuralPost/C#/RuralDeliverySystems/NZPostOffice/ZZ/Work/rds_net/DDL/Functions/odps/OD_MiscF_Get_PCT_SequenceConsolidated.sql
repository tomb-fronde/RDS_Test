/****** Object:  UserDefinedFunction [odps].[OD_MiscF_Get_PCT_SequenceConsolidated]    Script Date: 08/05/2008 11:22:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_MiscF_Get_PCT_SequenceConsolidated : 
--

create function [odps].[OD_MiscF_Get_PCT_SequenceConsolidated](@inInvoice_id int,@inacid_id int)
returns int
AS
BEGIN

	declare @iSeqCount int 
	select @iSeqCount = count(distinct pct.ac_id) 
    from payment_component as pc,
    payment_component_type as pct where pc.invoice_id = @inInvoice_id and pc.pct_id = pct.pct_id and
    pct.ac_id < @inacid_id
  if @iSeqCount is null or @iSeqCount = 0
    return(1)
  else return(@iSeqCount+1)
  --if @@fetch_status < 0 -- by fyb
   -- begin
    --  rollback transaction
   --   return(-1)
  --  end
 -- return(InvoiceNumber) 
 return (-1)
end
GO

/****** Object:  UserDefinedFunction [odps].[OD_MiscF_Get_PCT_Sequence]    Script Date: 08/05/2008 11:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_MiscF_Get_PCT_Sequence : 
--

create function [odps].[OD_MiscF_Get_PCT_Sequence](@inInvoice_id int,@inpct_id int)
returns int
AS
BEGIN

  declare @iSeqCount int
  select @iSeqCount = count(*) 
    from payment_component where
    invoice_id = @inInvoice_id and
    pc_id < @inpct_id
  if @iSeqCount is null or @iSeqCount = 0
    return(1)
  else
    return(@iSeqCount+1)
  --if @@fetch_status < 0// by fyb
   -- begin
      -- rollback transaction 
    --  return(-1)
   -- end
 return(1)
end
GO

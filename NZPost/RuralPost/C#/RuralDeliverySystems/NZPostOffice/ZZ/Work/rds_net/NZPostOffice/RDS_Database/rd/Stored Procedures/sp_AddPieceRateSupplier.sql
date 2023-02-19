
CREATE PROCEDURE [rd].[sp_AddPieceRateSupplier](
	@inPrsDescription varchar(40), 
	@inPctId  int )
AS
-- ========================================================================
-- Author:	Tom Britton
-- Create date: 25-July-2013, RPCR_054
-- Description:	
--    Insert a new piece rate supplier 
--    Update payment_component_type with the new supplier's prs_key
-- Returns
--    prs_key of inserted piece_rate_supplier record
--    null or 0    Insert failed
-- ========================================================================
--
BEGIN

  declare @PrsKey integer
  set @PrsKey = 0

 -- NOTE: prs_key is an identity column
  insert into rd.piece_rate_supplier
     (prs_description, pct_id)
  values
     (@inPrsDescription, @inPctId)
     
  select @PrsKey = @@Identity
  
  update odps.payment_component_type
     set prs_key = @PrsKey
   where pct_id = @inPctId

  select @PrsKey
END
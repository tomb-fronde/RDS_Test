
CREATE PROCEDURE [rd].[sp_AddPieceRate](
	@inPrtKey int, 
	@inRGCode int,
	@inPrEffectiveDate datetime,
	@inPrActive char(1),
	@inPrRate numeric(8,5)
	)
AS
-- ========================================================================
-- Author:	Tom Britton
-- Create date: 27-June-2013, RPCR_054
-- Description:	
--    Insert a new piece rate type with initial values into the piece_rate table
--    Checks first to see if there is already an existing entry for this type/region
-- Returns
--    0    Insert failed (duplicate)
--    1    Insert successful
--
BEGIN

  declare @nCount integer

  select @nCount=count(*)
    from piece_rate 
   where prt_key = @inPrtKey
     and rg_code = @inRGCode

  if @nCount > 0
    select 0

  insert into piece_rate
     (prt_key, pr_effective_date, rg_code, pr_active_status, pr_rate)
  values
     (@inPrtKey, @inPrEffectiveDate, @inRGCode, @inPrActive, @inPrRate)
  
  select 1
END
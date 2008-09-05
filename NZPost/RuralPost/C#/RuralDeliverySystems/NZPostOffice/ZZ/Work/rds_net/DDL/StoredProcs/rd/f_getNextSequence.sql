/****** Object:  StoredProcedure [rd].[f_getNextSequence]    Script Date: 08/05/2008 10:16:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for stored procedure f_getNextSequence : 
--

create procedure  [rd].[f_getNextSequence](@sequencename char(20),@update_flag int,@wrapValue int)
/******************************************************************
* Description
*    This function returns the next ID value from the id_codes table.
*
* Parameters
*    sequencename  - The name of the ID
*    update_flag   - 1 = update the table to the next value
*                    0 = just return the current value
*    wrapValue     - Wrap value: reset to 1 at this value
*
* Returns
*    Current next_value value for the named sequence
*    -1   if error (eg sequencename not found)
*
* System
*    NPAD2 - NZ Post
*
* Author
*    Tom Britton, Synergy International
*
* Created on
*    November 2005
*
* Modification history
* 10 Apr 2006  TJB  Added 3rd parameter: wrap value
* 19 May 2006  TJB  Added table lock
*
*****************************************************************/

AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @nextValue int
  declare @newValue int
set nocount on
  /* Watcom only
  lock table rd.id_codes in exclusive mode
  */
BEGIN TRANSACTION
  select @nextValue = next_value from
    rd.id_codes where
    sequence_name = @sequencename
  if @@error <> 0
    begin 
      -- Some error including sequencename doesn''t exist
      rollback tran
      return(-1)
    end
  if @update_flag = 1
    begin
      select @newValue=@nextValue+1
      if @wrapValue > 0 and @newValue >= @wrapValue
        select @newValue=1
      update id_codes set
        next_value = @newValue where
        sequence_name = @sequencename
      if @@error <> 0
        begin
          rollback transaction
          return(-1)
        end
    end
  commit tran
  return(@nextValue)
end
GO

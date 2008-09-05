/****** Object:  UserDefinedFunction [rd].[f_getPostCodeID]    Script Date: 08/05/2008 11:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_getPostCodeID : 
--

create function [rd].[f_getPostCodeID](@inPostCode char(4),@inTcID int,@inRoadID int)
/******************************************************************
* Description
*    This function returns the Post Code ID for the given Post Code.
*    Complicated by the fact that the post code may have more than one 
*    ID depending on the mailtown (this may only apply to the current
*    way Post Codes are defined - there is a new scheme on the offing).
*
*    Note too that the tc_id is from the townCity table, and MAY not 
*    be for a town that is in the post_code table; if so, we can try 
*    getting the post_code_id from the address table.
*
*    Failing any of that, return one of the IDs for the post code from 
*    the post_code table, or -1 if the post_code does not actually exist.
*    
* Parameters
*    @inPostCode   - The Post Code
*    @inTcID       - The tc_id of the town the post code is to be for
*    @inRoadID     - The road_id of the road the post code is to be for
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
*
*****************************************************************/
returns int
AS
BEGIN

  declare @postCodeID int,
  @found integer
  -- First, check that the post code actually exists
  if not exists(select 1 from post_code where
      post_code = @inPostCode)
    return(-1)
  -- Now see if there is a post code for the mailtown
  select @postCodeID=null
  select @postCodeID = post_code_id from
    post_code as pc,townCity as tc where
    pc.post_code = @inPostCode and
    pc.post_mail_town = tc.tc_name and
    tc_id = @inTcID
  if @postCodeID is not null
    return(@postCodeID)
  -- No:  now try via the roadID in the address table
  select @found = count(distinct(post_code_id)) from
    address as addr where
    addr.road_id = @inRoadID and
    addr.tc_id = @inTcID
  -- If we found one post_code_id, return it
  if @found is not null and @found = 1
    begin
      select @postCodeID = addr.post_code_id from
        address as addr where
        addr.road_id = @inRoadID and
        addr.tc_id = @inTcID
      return(@postCodeID)
    end
  -- If we found more than one post_code_id, return the first
  if @found is not null and @found > 1
    begin
      select top 1 @postCodeID = addr.post_code_id from
        address as addr where
        addr.road_id = @inRoadID and
        addr.tc_id = @inTcID
      return(@postCodeID)
    end
  -- We haven''t found the post_code_id via either the mailtown or roadID
  -- (perhaps this is the first time an address has been added on this road) 
  -- so now we'll revert to picking one at 'random''.
  select @postCodeID = post_code_id from
    post_code as pc where
    pc.post_code = @inPostCode
  return(@postCodeID)
end
GO

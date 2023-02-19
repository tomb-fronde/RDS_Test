
CREATE PROCEDURE [rd].[sp_DDDW_AllowanceTypeV2](
    @inAlctId int)
AS
BEGIN
  -- TJB Allowances 13-Mar-2021
  -- Added @inAlctId to return specific sets of allowances
  set nocount on
  if (@inAlctId is null)
  begin
    select alt_key
         , alt_description 
      from allowance_type
     order by alt_description
  end
  else
  begin
    select alt_key
         , alt_description 
      from allowance_type
     where alct_id = @inAlctId
     order by alt_description
  end
end
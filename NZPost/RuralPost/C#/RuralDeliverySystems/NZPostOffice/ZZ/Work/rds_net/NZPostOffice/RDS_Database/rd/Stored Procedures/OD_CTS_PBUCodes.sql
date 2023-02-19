
create procedure [rd].[OD_CTS_PBUCodes]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select PBU_Code.PBU_Code,
    PBU_Code.PBU_Description,
    PBU_Code.PBU_ID from
    odps.pbu_code order by 1 asc
end
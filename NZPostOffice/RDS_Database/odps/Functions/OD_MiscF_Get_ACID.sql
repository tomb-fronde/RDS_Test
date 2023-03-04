


--
-- Definition for user-defined function OD_MiscF_Get_ACID : 
--

create function [odps].[OD_MiscF_Get_ACID](@inContract int)
returns char(30)
AS
BEGIN

  -- PBY 12/09/2002 SR#4456 
  -- Changed ACID data type from INT to VARCHAR(30)
  declare @ACID varchar(30)
  select @ACID = case when isnull(contract.ac_id,0) = 0 then (select ac2.ac_code from "national",account_codes as ac2 where "national".ac_id = ac2.ac_id and "national".nat_id = odps.od_blf_getwhichnational('2000-6-20')) 
		else (select ac.ac_code from account_codes as ac where ac.ac_id = contract.ac_id) end 
    from rd.contract where contract_no = @inContract
  return(@ACID)
end
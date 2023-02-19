create procedure [rd].[sp_AssignFixedAssetToContract] (
	@in_fixed_asset_no varchar(10),
	@in_contract_no int )
--
-- TJB  RPCR_026  July-2011: New
--
-- Modifications
-- 18-Jul-2011  TJB   Fixed bug is selecting a contract's current strip height
--
AS
BEGIN
  set CONCAT_NULL_YIELDS_NULL off
  declare @sh_id int
  
  select top(1) @sh_id = sh_id
    from contract_fixed_assets
   where contract_no = @in_contract_no
     
  if @sh_id is null
      set @sh_id = 4
      
  insert into contract_fixed_assets
      (contract_no, fa_fixed_asset_no, sh_id)
  values
      (@in_contract_no, @in_fixed_asset_no, @sh_id)
end
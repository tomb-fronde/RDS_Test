
create procedure [rd].[sp_GetContractFixedAssets](@in_Contract int)
AS
BEGIN
  select cfa.contract_no,
    cfa.fa_fixed_asset_no,
    fa.fat_id,
    fa.fa_owner,
    fa.fa_purchase_date,
    fa.fa_purchase_price from
    contract_fixed_assets as cfa join fixed_asset_register as fa on cfa.fa_fixed_asset_no=fa.fa_fixed_asset_no where
    cfa.contract_no = @in_Contract
end
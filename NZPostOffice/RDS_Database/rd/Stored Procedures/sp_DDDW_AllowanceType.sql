
CREATE PROCEDURE [rd].[sp_DDDW_AllowanceType]
AS
BEGIN
  -- TJB RPCR_149 May-2020 
  -- Added order by clause
  select alt_key
       , alt_description 
    from allowance_type
   order by alt_description
end

CREATE procedure [rd].[sp_GetContractorDS](@in_Contractor int)
AS
-- TJB  AP Extract Format  Dec-2013
-- Add supplier_no to returned values
--
-- TJB  AP Extract Format  Jan-2014: Bug fix
-- Change contractor/contractor_ds join to left outer join
-- - unable to retreive supplier_no when there is no old DS no
BEGIN
  select c.contractor_supplier_no
       , ds.cd_old_ds_no 
       , c.supplier_no
    from contractor c left outer join contractor_ds ds
               on ds.contractor_supplier_no = c.contractor_supplier_no
   where c.contractor_supplier_no = @in_Contractor 
   order by cd_old_ds_no asc
end
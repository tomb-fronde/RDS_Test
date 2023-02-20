/****** Object:  UserDefinedFunction [odps].[OD_BLF_GetTaxRate]    Script Date: 08/05/2008 11:22:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--
-- Definition for user-defined function OD_BLF_GetTaxRate : 
--

create function [odps].[OD_BLF_GetTaxRate](@inContractor int,@effective_date datetime)
returns decimal(12,2)
AS
BEGIN

  declare @OD_Taxrate decimal(5,2),
  @tax_certificate char(20),
  @IR13_TaxRate decimal(5,2),
  @NoIR13_TaxRate decimal(5,2),
  @Standard_TaxRate decimal(5,2)
  select @tax_certificate = contractor.c_witholding_tax_certificate,@OD_TaxRate = c_tax_rate from rd.contractor where
    contractor.contractor_supplier_no = @inContractor
  if @@error <> 0 /* <> was < */
    return(-1)
  if @tax_certificate is null
    select @tax_certificate='N'
  if @OD_TaxRate is null
    select @OD_TaxRate=0
  select @Standard_TaxRate = isnull("national".nat_od_standard_gst_rate,0),
    @IR13_TaxRate = isnull("national".nat_od_tax_rate_ir13,0),
    @NoIR13_TaxRate = isnull("national".nat_od_tax_rate_no_ir13,0) from "national" where
    "national".nat_id = (select top 1 odps.od_blf_getwhichnational(@effective_date) from sysobjects)
  if @@rowcount = 0 /* was @@error =100 */
    begin
      select @IR13_TaxRate=0
      select @NoIR13_TaxRate=0
      select @Standard_TaxRate=0
    end
  if @@error <> 0 /* <> was < */
    return(-1)
  if @tax_certificate = 'X'
    return(0.0) else if @tax_certificate = 'Y'
    if @OD_TaxRate > 0
      return(@OD_TaxRate)
    else
      return(@IR13_TaxRate) else if @tax_certificate = 'N'
    return(@NoIR13_TaxRate)
  return(-1)
end
GO

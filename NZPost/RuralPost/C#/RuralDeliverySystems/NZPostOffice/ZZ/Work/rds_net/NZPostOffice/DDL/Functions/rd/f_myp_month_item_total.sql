/****** Object:  UserDefinedFunction [rd].[f_myp_month_item_total]    Script Date: 08/05/2008 11:24:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_myp_month_item_total : 
--

create function [rd].[f_myp_month_item_total](@region int,@outlet int,@contract int,@mo int,@yr int,@prs int,@prt int)
returns decimal
AS
BEGIN

  declare @decAmount decimal
  select @decAmount=sum(isnull(piece_rate_delivery.prd_quantity,0)) from
    piece_rate,
    piece_rate_delivery,
    piece_rate_supplier,
    piece_rate_type,
    contract,
    outlet,
    renewal_group where
    (piece_rate.prt_key = piece_rate_delivery.prt_key) and
    (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
    (piece_rate_type.prt_key = piece_rate_delivery.prt_key) and
    (piece_rate_type.prt_key = piece_rate.prt_key) and
    (contract.contract_no = piece_rate_delivery.contract_no) and
    (outlet.outlet_id = contract.con_base_office) and
    (renewal_group.rg_code = contract.rg_code) and
    (renewal_group.rg_code = piece_rate.rg_code) and
    (month(piece_rate_delivery.prd_date) = @mo) and
    (year(piece_rate_delivery.prd_date) = @yr) and
    (piece_rate_type.prt_key = @prt) and
    (piece_rate_supplier.prs_key = @prs) and
    ((outlet.region_id = -1 and
    -1 <> -1) or
    (-1 = -1)) and
    ((outlet.outlet_id = -1 and
    -1 <> -1) or
    (-1 = -1)) and
    ((contract.contract_no = -1 and
    -1 <> -1) or
    (-1 = -1))
  return(@decAmount)
end
GO

/****** Object:  UserDefinedFunction [rd].[f_piecerate]    Script Date: 08/05/2008 11:24:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function f_piecerate : 
--

create function [rd].[f_piecerate](@contract int,@mo int,@yr int,@prsk int)
returns decimal
AS
BEGIN

  declare @decAmount decimal
  select @decAmount=sum(isnull(prd_quantity,0)) 
    from piece_rate_delivery,
    piece_rate_supplier,
    piece_rate_type where
    @mo < 13 and
    piece_rate_type.prs_key = piece_rate_supplier.prs_key and
    piece_rate_supplier.prs_key = @prsk and
    piece_rate_delivery.prt_key = piece_rate_type.prt_key and
    (month(piece_rate_delivery.prd_date) = @mo and year(piece_rate_delivery.prd_date) = @yr) and
    ((piece_rate_delivery.contract_no = @contract and @contract <> -1) or
    (@contract = -1))
  if @decamount > 0
    return(@decamount)
  select @decAmount=sum(isnull(prd_quantity,0))+isnull(@decAmount,0)
    from piece_rate_delivery,
    piece_rate_supplier,
    piece_rate_type where
    @mo > 12 and
    piece_rate_type.prs_key = piece_rate_supplier.prs_key and
    piece_rate_supplier.prs_key = @prsk and
    piece_rate_delivery.prt_key = piece_rate_type.prt_key and
    (month(piece_rate_delivery.prd_date) = (@mo-12) and year(piece_rate_delivery.prd_date) = @yr+1) and
    ((piece_rate_delivery.contract_no = @contract and @contract <> -1) or
    (@contract = -1))
  return(@decAmount)
end
GO

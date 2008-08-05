/****** Object:  StoredProcedure [odps].[OD_RPS_Invoice_pay_piecerate_detail]    Script Date: 08/05/2008 10:14:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_Invoice_pay_piecerate_detail : 
--

create procedure [odps].[OD_RPS_Invoice_pay_piecerate_detail](@invoiceid int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @v_tempint int,
  @v_tempint2 int
  select @v_tempint = count(*) 
    from t_invoice_piecerates where invoice_id = @invoiceid
  select @v_tempint2 = count(*) 
    from t_invoice_piecerates2 where invoice_id = @invoiceid
  if(@v_tempint >= @v_tempint2) or((@v_tempint2 is null) or(@v_tempint2 = 0))
    select t_invoice_piecerates.invoice_id,
      t_invoice_piecerates.prd_date,
      t_invoice_piecerates.prt_code,
      t_invoice_piecerates.prd_quantity,
      t_invoice_piecerates.rate,
      t_invoice_piecerates.cost,
      t_invoice_piecerates2.prd_date,
      t_invoice_piecerates2.prt_code,
      t_invoice_piecerates2.prd_quantity,
      t_invoice_piecerates2.rate,
      t_invoice_piecerates2.cost from
      t_invoice_piecerates left outer join t_invoice_piecerates2 on t_invoice_piecerates.invoice_id = t_invoice_piecerates2.invoice_id and
      t_invoice_piecerates.rownum = t_invoice_piecerates2.rownum where
      t_invoice_piecerates.invoice_id = @invoiceid order by
      t_invoice_piecerates.prd_date asc,
      t_invoice_piecerates.prt_code asc
  else
    select t_invoice_piecerates2.invoice_id,
      t_invoice_piecerates.prd_date,
      prt_code=t_invoice_piecerates.prt_code,
      t_invoice_piecerates.prd_quantity,
      t_invoice_piecerates.rate,
      t_invoice_piecerates.cost,
      t_invoice_piecerates2.prd_date,
      t_invoice_piecerates2.prt_code,
      t_invoice_piecerates2.prd_quantity,
      t_invoice_piecerates2.rate,
      t_invoice_piecerates2.cost from
      t_invoice_piecerates2 left outer join t_invoice_piecerates on t_invoice_piecerates2.invoice_id = t_invoice_piecerates.invoice_id and
      t_invoice_piecerates2.rownum = t_invoice_piecerates.rownum where
      t_invoice_piecerates2.invoice_id = @invoiceid order by
      t_invoice_piecerates2.prd_date asc,
      t_invoice_piecerates2.prt_code asc
end
GO

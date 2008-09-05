/****** Object:  StoredProcedure [odps].[OD_RPF_Invoice_pay_piecerate_detailv2]    Script Date: 08/05/2008 10:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPF_Invoice_pay_piecerate_detailv2 : 
--

create procedure [odps].[OD_RPF_Invoice_pay_piecerate_detailv2](@incontractor int,@indate datetime,@incontract int,@inregion int,@cname char(40))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- 14/02/02 PBY Request#4326
  -- Removed hardcoding of 'Kiwimail', 'CourierPost' and 'XP' from
  -- sql code.  Used the corresponding piece_rate_suplier.prs_key instead.
  declare @lcontract int,
  @linvoice int
  declare vc_contract_list cursor for select payment.contract_no,payment.invoice_id from
      payment,
      rd.contract,
      rd.outlet,
      rd.contractor where
      (payment.contract_no = contract.contract_no) and
      (contract.con_base_office = outlet.outlet_id) and
      (contractor.contractor_supplier_no = payment.contractor_supplier_no) and
      ((c_surname_company like @cname + '%' and len(@cname) > 0) or(len(@cname) = 0) or(@cname is null)) and
      (payment.invoice_date = @indate) and
      ((outlet.region_id = @inregion and @inregion > 0) or
      (@inregion = 0) or(@inregion is null))
  delete from t_invoice_piecerates
  delete from t_invoice_piecerates2
  delete from t_invoice_piecerates3
  commit transaction
  if(@incontract is not null) and(@incontract > 0)
    begin
      insert into t_invoice_piecerates(invoice_id,atype,prd_date,prt_code,prd_quantity,cost,rate,rownum)
        select invoice_id,prs_description,piece_rate_delivery.prd_date,
          piece_rate_type.prt_code,
          piece_rate_delivery.prd_quantity,
          piece_rate_delivery.prd_cost,
          rate=prd_cost/prd_quantity,
          row_number() over (order by invoice_id asc)
		  from
          rd.piece_rate_type,
          rd.piece_rate_delivery,
          payment,
          rd.piece_rate_supplier where
          (payment.contract_no = piece_rate_delivery.contract_no) and
          (piece_rate_type.prs_key = piece_rate_supplier.prs_key) and
          (piece_rate_type.prt_key = piece_rate_delivery.prt_key) and
          (payment.invoice_date = piece_rate_delivery.prd_paid_to_date) and
          ((payment.contract_no = @incontract) and
          (piece_rate_supplier.prs_key = 1)) and
          (invoice_date = @indate) and
          (piece_rate_delivery.prd_paid_to_date = @indate)
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-100001000)
        end
      insert into t_invoice_piecerates2(invoice_id,atype,prd_date,prt_code,prd_quantity,cost,rate,rownum)
        select invoice_id,prs_description,piece_rate_delivery.prd_date,
          piece_rate_type.prt_code,
          piece_rate_delivery.prd_quantity,
          piece_rate_delivery.prd_cost,
          rate=prd_cost/prd_quantity,
          row_number() over (order by invoice_id asc)
		  from
          rd.piece_rate_type,
          rd.piece_rate_delivery,
          payment,
          rd.piece_rate_supplier where
          (payment.contract_no = piece_rate_delivery.contract_no) and
          (piece_rate_type.prs_key = piece_rate_supplier.prs_key) and
          (piece_rate_type.prt_key = piece_rate_delivery.prt_key) and
          (payment.invoice_date = piece_rate_delivery.prd_paid_to_date) and
          ((payment.contract_no = @incontract) and
          (piece_rate_supplier.prs_key = 2)) and
          (invoice_date = @indate) and
          (piece_rate_delivery.prd_paid_to_date = @indate)
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-100001010)
        end
      insert into t_invoice_piecerates3(invoice_id,atype,prd_date,prt_code,prd_quantity,cost,rate,rownum)
        select invoice_id,prs_description,piece_rate_delivery.prd_date,
          piece_rate_type.prt_code,
          piece_rate_delivery.prd_quantity,
          piece_rate_delivery.prd_cost,
          rate=prd_cost/prd_quantity,
          row_number() over (order by invoice_id asc)
		  from
          rd.piece_rate_type,
          rd.piece_rate_delivery,
          payment,
          rd.piece_rate_supplier where
          (payment.contract_no = piece_rate_delivery.contract_no) and
          (piece_rate_type.prs_key = piece_rate_supplier.prs_key) and
          (piece_rate_type.prt_key = piece_rate_delivery.prt_key) and
          (payment.invoice_date = piece_rate_delivery.prd_paid_to_date) and
          ((payment.contract_no = @incontract) and
          (piece_rate_supplier.prs_key = 3)) and
          (invoice_date = @indate) and
          (piece_rate_delivery.prd_paid_to_date = @indate)
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-100001110)
        end
    end
  else
    begin
      open vc_contract_list
      if @@error <> 0
        begin
          rollback transaction
          return(-100001001)
        end
      /* Watcom only
      cListLoop:
      */while 1=1 
        begin
          fetch next from vc_contract_list into @lcontract,@linvoice
          if @@fetch_status <0
            break
            /* Watcom only
            cListLoop
            */
          insert into t_invoice_piecerates(invoice_id,atype,prd_date,prt_code,prd_quantity,cost,rate,rownum)
            select invoice_id,prs_description,piece_rate_delivery.prd_date,
              piece_rate_type.prt_code,
              piece_rate_delivery.prd_quantity,
              piece_rate_delivery.prd_cost,
              rate=prd_cost/prd_quantity,
              row_number() over (order by invoice_id asc)
			  from
              rd.piece_rate_type,
              rd.piece_rate_delivery,
              payment,
              rd.piece_rate_supplier where
              (piece_rate_delivery.prt_key = piece_rate_type.prt_key) and
              (piece_rate_delivery.prd_paid_to_date = payment.invoice_date) and
              (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
              (piece_rate_supplier.prs_key = 1) and
              (payment.contract_no = @lcontract) and
              (payment.invoice_id = @linvoice) and
              (payment.invoice_date = @indate) and
              (payment.contract_no = piece_rate_delivery.contract_no)
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-100001101)
            end
          insert into t_invoice_piecerates2(invoice_id,atype,prd_date,prt_code,prd_quantity,cost,rate,rownum)
            select invoice_id,prs_description,piece_rate_delivery.prd_date,
              piece_rate_type.prt_code,
              piece_rate_delivery.prd_quantity,
              piece_rate_delivery.prd_cost,
              rate=prd_cost/prd_quantity,
              row_number() over (order by invoice_id asc)
		      from
              rd.piece_rate_type,
              rd.piece_rate_delivery,
              payment,
              rd.piece_rate_supplier where
              (piece_rate_delivery.prt_key = piece_rate_type.prt_key) and
              (piece_rate_delivery.prd_paid_to_date = payment.invoice_date) and
              (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
              (piece_rate_supplier.prs_key = 2) and
              (payment.invoice_date = @indate) and
              (payment.contract_no = @lcontract) and
              (payment.invoice_id = @linvoice) and
              (payment.contract_no = piece_rate_delivery.contract_no)
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-100001102)
            end
          insert into t_invoice_piecerates3(invoice_id,atype,prd_date,prt_code,prd_quantity,cost,rate,rownum)
            select invoice_id,prs_description,piece_rate_delivery.prd_date,
              piece_rate_type.prt_code,
              piece_rate_delivery.prd_quantity,
              piece_rate_delivery.prd_cost,
              rate=prd_cost/prd_quantity,
              row_number() over (order by invoice_id asc)
		      from
              rd.piece_rate_type,
              rd.piece_rate_delivery,
              payment,
              rd.piece_rate_supplier where
              (piece_rate_delivery.prt_key = piece_rate_type.prt_key) and
              (piece_rate_delivery.prd_paid_to_date = payment.invoice_date) and
              (piece_rate_supplier.prs_key = piece_rate_type.prs_key) and
              (piece_rate_supplier.prs_key = 3) and
              (payment.invoice_date = @indate) and
              (payment.contract_no = @lcontract) and
              (payment.invoice_id = @linvoice) and
              (payment.contract_no = piece_rate_delivery.contract_no)
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-100001112)
            end
        end
      close vc_contract_list
      commit transaction
    end
  return(0)
end
GO

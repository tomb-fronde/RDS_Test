/****** Object:  StoredProcedure [odps].[OD_RPF_Invoice_pay_piecerate_detail]    Script Date: 08/05/2008 10:13:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [odps].[OD_RPF_Invoice_pay_piecerate_detail](@inContractor int,@inDate datetime,@inContract int,@inRegion int,@inCname char(40),@inCtKey int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  -- TJB  SR4684  June/2006
  -- Addd processing for Parcel Post
  --
  -- 14/02/02 PBY Request#4326
  -- Removed hardcoding of Kiwimail, CourierPost and XP from sql code.
  -- Used the corresponding piece_rate_suplier.prs_key instead.
  --
  -- Kiwimail       prs_key 1
  -- CourierPost    prs_key 2
  -- XP  (Skyroad)  prs_key 3
  -- Parcel Post    prs_key 4
  --
  set implicit_transactions on
  --begin transaction
  declare @lcontract int,
  @linvoice int
  -- TJB SR4639 3/12/04 - Add contract type as one of the selection criteria
  -- If the user selects one of the contracts returned by the selection, inContract will hold that value.
  -- and (inContract is null or inContract=0 or (inContract<>0 and contract.contract_no=inContract))
  declare vc_contract_list cursor for select distinct
      payment.contract_no,
      payment.invoice_id from
      payment,
      rd.contract,
      rd.outlet,
      rd.contractor,
      rd.types_for_contract where
      payment.contract_no = contract.contract_no and
      contract.con_base_office = outlet.outlet_id and
      contractor.contractor_supplier_no = payment.contractor_supplier_no and
      payment.invoice_date = @inDate and
      ((c_surname_company like @inCname+'%' and len(@inCname) > 0) or len(@inCname) = 0 or @inCname is null) and
      ((outlet.region_id = @inRegion and @inRegion > 0) or @inRegion = 0 or @inRegion is null) and
      (@inCtKey is null or @inCtKey = 0 or(@inCtKey <> 0 and types_for_contract.ct_key = @inCtKey)) and
      types_for_contract.contract_no = contract.contract_no
  delete from t_invoice_piecerates -- Kiwimail
  delete from t_invoice_piecerates2 -- Courier Post
  delete from t_invoice_piecerates3 -- SkyRoad (XP)
  delete from t_invoice_piecerates4 -- Parcel Post
  commit transaction
  -- If specific contract is specified, do this
  if(@inContract is not null) and(@inContract > 0)
    begin
      insert into t_invoice_piecerates(invoice_id,
        atype,
        prd_date,
        prt_code,
        prd_quantity,
        cost,
        rate,
        rownum)
        select invoice_id,
          prs_description,
          piece_rate_delivery.prd_date,
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
          payment.contract_no = piece_rate_delivery.contract_no and
          piece_rate_type.prs_key = piece_rate_supplier.prs_key and
          piece_rate_type.prt_key = piece_rate_delivery.prt_key and
          payment.invoice_date = piece_rate_delivery.prd_paid_to_date and
          (payment.contract_no = @inContract and piece_rate_supplier.prs_key = 1) and
          payment.invoice_date = @inDate and
          piece_rate_delivery.prd_paid_to_date = @inDate
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          set implicit_transactions off --add
          return(-100001000)
        end
      insert into t_invoice_piecerates2(invoice_id,
        atype,
        prd_date,
        prt_code,
        prd_quantity,
        cost,
        rate,
        rownum)
        select invoice_id,
          prs_description,
          piece_rate_delivery.prd_date,
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
          payment.contract_no = piece_rate_delivery.contract_no and
          piece_rate_type.prs_key = piece_rate_supplier.prs_key and
          piece_rate_type.prt_key = piece_rate_delivery.prt_key and
          payment.invoice_date = piece_rate_delivery.prd_paid_to_date and
          (payment.contract_no = @inContract and piece_rate_supplier.prs_key = 2) and
          payment.invoice_date = @inDate and
          piece_rate_delivery.prd_paid_to_date = @inDate
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          set implicit_transactions off  --add
          return(-100001010)
        end
      insert into t_invoice_piecerates3(invoice_id,
        atype,
        prd_date,
        prt_code,
        prd_quantity,
        cost,
        rate,
        rownum)
        select invoice_id,
          prs_description,
          piece_rate_delivery.prd_date,
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
          payment.contract_no = piece_rate_delivery.contract_no and
          piece_rate_type.prs_key = piece_rate_supplier.prs_key and
          piece_rate_type.prt_key = piece_rate_delivery.prt_key and
          payment.invoice_date = piece_rate_delivery.prd_paid_to_date and
          (payment.contract_no = @inContract and piece_rate_supplier.prs_key = 3) and
          payment.invoice_date = @inDate and
          piece_rate_delivery.prd_paid_to_date = @inDate
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          set implicit_transactions off --add
          return(-100001110)
        end
      insert into t_invoice_piecerates4(invoice_id,
        atype,
        prd_date,
        prt_code,
        prd_quantity,
        cost,
        rate,
        rownum)
        select invoice_id,
          prs_description,
          piece_rate_delivery.prd_date,
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
          payment.contract_no = piece_rate_delivery.contract_no and
          piece_rate_type.prs_key = piece_rate_supplier.prs_key and
          piece_rate_type.prt_key = piece_rate_delivery.prt_key and
          payment.invoice_date = piece_rate_delivery.prd_paid_to_date and
          (payment.contract_no = @inContract and piece_rate_supplier.prs_key = 4) and
          payment.invoice_date = @inDate and
          piece_rate_delivery.prd_paid_to_date = @inDate
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          set implicit_transactions off --add
          return(-100001210)
        end
        commit transaction --add by hhuang on 2007/10/10
    end
  else
    begin
      -- If its an 'all contracts' situation, do this
      open vc_contract_list
      if @@error <> 0
        begin
          rollback transaction
          set implicit_transactions off --add
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
          insert into t_invoice_piecerates(invoice_id,
            atype,
            prd_date,
            prt_code,
            prd_quantity,
            cost,
            rate,
            rownum)
            select invoice_id,
              prs_description,
              piece_rate_delivery.prd_date,
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
              piece_rate_delivery.prt_key = piece_rate_type.prt_key and
              piece_rate_delivery.prd_paid_to_date = payment.invoice_date and
              piece_rate_supplier.prs_key = piece_rate_type.prs_key and
              piece_rate_supplier.prs_key = 1 and
              payment.contract_no = @lcontract and
              payment.invoice_id = @linvoice and
              payment.invoice_date = @inDate and
              payment.contract_no = piece_rate_delivery.contract_no
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              set implicit_transactions off --add
              return(-100001101)
            end
          insert into t_invoice_piecerates2(invoice_id,
            atype,
            prd_date,
            prt_code,
            prd_quantity,
            cost,
            rate,
            rownum)
            select invoice_id,
              prs_description,
              piece_rate_delivery.prd_date,
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
              piece_rate_delivery.prt_key = piece_rate_type.prt_key and
              piece_rate_delivery.prd_paid_to_date = payment.invoice_date and
              piece_rate_supplier.prs_key = piece_rate_type.prs_key and
              piece_rate_supplier.prs_key = 2 and
              payment.invoice_date = @inDate and
              payment.contract_no = @lcontract and
              payment.invoice_id = @linvoice and
              payment.contract_no = piece_rate_delivery.contract_no
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              set implicit_transactions off --add
              return(-100001102)
            end
          insert into t_invoice_piecerates3(invoice_id,
            atype,
            prd_date,
            prt_code,
            prd_quantity,
            cost,
            rate,
            rownum)
            select invoice_id,
              prs_description,
              piece_rate_delivery.prd_date,
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
              piece_rate_delivery.prt_key = piece_rate_type.prt_key and
              piece_rate_delivery.prd_paid_to_date = payment.invoice_date and
              piece_rate_supplier.prs_key = piece_rate_type.prs_key and
              piece_rate_supplier.prs_key = 3 and
              payment.invoice_date = @inDate and
              payment.contract_no = @lcontract and
              payment.invoice_id = @linvoice and
              payment.contract_no = piece_rate_delivery.contract_no
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              set implicit_transactions off --add
              return(-100001112)
            end
          insert into t_invoice_piecerates4(invoice_id,
            atype,
            prd_date,
            prt_code,
            prd_quantity,
            cost,
            rate,
            rownum)
            select invoice_id,
              prs_description,
              piece_rate_delivery.prd_date,
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
              piece_rate_delivery.prt_key = piece_rate_type.prt_key and
              piece_rate_delivery.prd_paid_to_date = payment.invoice_date and
              piece_rate_supplier.prs_key = piece_rate_type.prs_key and
              piece_rate_supplier.prs_key = 4 and
              payment.invoice_date = @inDate and
              payment.contract_no = @lcontract and
              payment.invoice_id = @linvoice and
              payment.contract_no = piece_rate_delivery.contract_no
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              set implicit_transactions off  --add
              return(-100001212)
            end
        end
      close vc_contract_list
      commit transaction
      set implicit_transactions off --add
    end
    DEALLOCATE vc_contract_list --add by hhuang on 2007/10/10
  return(0)
end
GO

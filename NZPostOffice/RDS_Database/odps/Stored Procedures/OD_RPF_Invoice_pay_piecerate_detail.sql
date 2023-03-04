
CREATE procedure  [odps].[OD_RPF_Invoice_pay_piecerate_detail](
	 @inContractor int
	,@inDate datetime
	,@inContract int
	,@inRegion int
	,@inCname varchar(40)
	,@inCtKey int
	,@inExportFlag int = 0)
AS
BEGIN
  -- TJB  RPCR_054  July-2013
  -- Add inExportFlag to input parameters and prs_key to output values
  -- Change t_invoice_piecerates to accomodate prs_key values
  -- inExportFlag
  --    0 (or null) = output for printed invoices (results in t_invoice_piecerates and t_invoice_piecerates2)
  --    1 = All output in t_invoice_piecerates
  -- Changed inCname type from char ro varchar to fix vc_contract_list cursor
  -- Changed loops selecting odd and even prs_keys to use modulo arithmetic rather than loops.
  --
  -- TJB  RPCR_054  Apr-2013
  -- Change to process an open-ended number of suppliers' piecerates
  --     odd-numbered suppliers go into t_invoice_piecerates
  --     ever-numbered suppliers go into t_invoice_piecerates2
  -- to get printed as separate columns on the invoices.
  --
  -- TJB  SR4684  June/2006
  -- Added processing for Parcel Post
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
  set CONCAT_NULL_YIELDS_NULL off
  
  declare @lcontract int
  declare @linvoice int
  declare @PrsKey int
  declare @maxPrsKey int

  --print 'Contract ' + convert(varchar,@inContract)
  --print 'Contractor ' + convert(varchar,@inContractor)
  --print 'Date ' + convert(varchar,@inDate)

  --set implicit_transactions on
  --begin transaction

  delete from t_invoice_piecerates  -- Kiwimail      [v2: odd-numbered suppliers]
  delete from t_invoice_piecerates2 -- Courier Post  [v2: even-numbered suppliers]
  delete from t_invoice_piecerates3 -- SkyRoad (XP)  [v2: obsolete and not used]
  delete from t_invoice_piecerates4 -- Parcel Post   [v2: obsolete and not used]
  --commit transaction

  if (@inCtKey is null) set @inCtKey = 0
  if (@inRegion is null) set @inRegion = 0
  if (@inCname is null) set @inCname = ''
  
  --set implicit_transactions on

  -- TJB SR4639 3/12/04 - Add contract type as one of the selection criteria
  -- If the user selects one of the contracts returned by the selection, inContract will hold that value.

  -- If specific contract is specified, extract piecerate payments for each supplier
  if (@inContract is not null) and (@inContract > 0)
  begin
      --print 'Process single contract for invoice'
      if (@inExportFlag = 0)
      begin
          --print 'Process the odd-numbered supplier piecerates for contract ' + convert(varchar(12),@inContract)
          insert into t_invoice_piecerates(
                 invoice_id,
                 atype,
                 prd_date,
                 prt_code,
                 prd_quantity,
                 cost,
                 rate,
                 rownum,
                 prs_key)
          select invoice_id,
                 piece_rate_supplier.prs_description,
                 piece_rate_delivery.prd_date,
                 piece_rate_type.prt_code,
                 piece_rate_delivery.prd_quantity,
                 piece_rate_delivery.prd_cost,
                 rate=prd_cost/prd_quantity,
                 row_number() over (order by invoice_id asc),
                 piece_rate_supplier.prs_key
            from rd.piece_rate_type,
                 rd.piece_rate_delivery,
                 odps.payment,
                 rd.piece_rate_supplier 
           where payment.contract_no = piece_rate_delivery.contract_no 
             and piece_rate_type.prs_key = piece_rate_supplier.prs_key 
             and piece_rate_type.prt_key = piece_rate_delivery.prt_key 
             and payment.invoice_date = piece_rate_delivery.prd_paid_to_date 
             and payment.contract_no = @inContract 
             and payment.invoice_date = @inDate 
             and piece_rate_delivery.prd_paid_to_date = @inDate
             and (piece_rate_supplier.prs_key % 2) = 1
           order by invoice_id, prs_key

          if @@error <> 0
          begin
              --rollback transaction
              --set implicit_transactions off --add
              return (-100001000)
          end

          --print 'Process the even-numbered supplier piecerates for contract ' + convert(varchar(12),@inContract)
          insert into t_invoice_piecerates2(
                 invoice_id,
                 atype,
                 prd_date,
                 prt_code,
                 prd_quantity,
                 cost,
                 rate,
                 rownum)
          select invoice_id,
                 piece_rate_supplier.prs_description,
                 piece_rate_delivery.prd_date,
                 piece_rate_type.prt_code,
                 piece_rate_delivery.prd_quantity,
                 piece_rate_delivery.prd_cost,
                 rate=prd_cost/prd_quantity,
                 row_number() over (order by invoice_id asc)
            from rd.piece_rate_type,
                 rd.piece_rate_delivery,
                 odps.payment,
                 rd.piece_rate_supplier 
           where payment.contract_no = piece_rate_delivery.contract_no 
             and piece_rate_type.prs_key = piece_rate_supplier.prs_key 
             and piece_rate_type.prt_key = piece_rate_delivery.prt_key 
             and payment.invoice_date = piece_rate_delivery.prd_paid_to_date 
             and payment.contract_no = @inContract 
             and payment.invoice_date = @inDate 
             and piece_rate_delivery.prd_paid_to_date = @inDate
             and (piece_rate_supplier.prs_key % 2) = 0
           order by invoice_id

          if @@error <> 0
          begin
              --rollback transaction
              --set implicit_transactions off  --add
              return (-100001010)
          end
          --commit transaction
      end
      else  -- [@inExportFlag != 0 - process for export]
      begin
          --print 'Process all supplier piecerates for contract ' + convert(varchar(12),@inContract)
          insert into t_invoice_piecerates(
                 invoice_id,
                 atype,
                 prd_date,
                 prt_code,
                 prd_quantity,
                 cost,
                 rate,
                 rownum,
                 prs_key)
          select invoice_id,
                 piece_rate_supplier.prs_description,
                 piece_rate_delivery.prd_date,
                 piece_rate_type.prt_code,
                 piece_rate_delivery.prd_quantity,
                 piece_rate_delivery.prd_cost,
                 rate=prd_cost/prd_quantity,
                 row_number() over (order by invoice_id asc),
                 piece_rate_supplier.prs_key
            from rd.piece_rate_type,
                 rd.piece_rate_delivery,
                 odps.payment,
                 rd.piece_rate_supplier 
           where payment.contract_no = piece_rate_delivery.contract_no 
             and piece_rate_type.prs_key = piece_rate_supplier.prs_key 
             and piece_rate_type.prt_key = piece_rate_delivery.prt_key 
             and payment.invoice_date = piece_rate_delivery.prd_paid_to_date 
             and payment.contract_no = @inContract 
             and payment.invoice_date = @inDate 
             and piece_rate_delivery.prd_paid_to_date = @inDate
           order by invoice_id, prs_key

          if @@error <> 0
          begin
              --rollback transaction
              --set implicit_transactions off --add
              return (-100001000)
          end
          --commit transaction

      end   -- [@inExportFlag != 0]

  end -- [end single contract processing]
  else      -- If its an 'all contracts' situation, process all contracts
  begin
      -- TJB  RPCR_054  June-2013
      -- Modified cursor query.
      
      -- Declare cursor to step through each invoice
      declare vc_contract_list cursor for 
          select distinct
                 payment.contract_no,
                 payment.invoice_id 
            from odps.payment,
                 rd.contract,
                 rd.outlet,
                 rd.contractor,
                 rd.types_for_contract 
           where payment.contract_no = contract.contract_no 
             and contract.con_base_office = outlet.outlet_id 
             and contractor.contractor_supplier_no = payment.contractor_supplier_no 
             and types_for_contract.contract_no = contract.contract_no
             and payment.invoice_date = @inDate 
             and (len(@inCname) = 0 or c_surname_company like @inCname+'%') 
             and (@inRegion = 0 or outlet.region_id = @inRegion) 
             and (@inCtKey = 0 or types_for_contract.ct_key = @inCtKey) 
             --and ((c_surname_company like @inCname+'%' and len(@inCname) > 0) or len(@inCname) = 0 or @inCname is null) 
             --and ((outlet.region_id = @inRegion and @inRegion > 0) or @inRegion = 0 or @inRegion is null) 
             --and (@inCtKey is null or @inCtKey = 0 or (@inCtKey <> 0 and types_for_contract.ct_key = @inCtKey)) 

      --print 'Declare cursor to step through each invoice'

      -- For testing limit number of times through the contract loop
      --declare @nContracts int
      --set @nContracts = 0

      if (@inExportFlag = 0)
      begin
          -- print 'Process all contracts for invoice'
          open vc_contract_list

          if @@error <> 0
          begin
              --rollback transaction
              --set implicit_transactions off --add
              return (-100001001)
          end

          while 1=1    -- All contracts loop
          begin
              -- For testing limit number of times through the contract loop
              --set @nContracts = @nContracts + 1
              --if (@nContracts > 3) break

              fetch next from vc_contract_list into @lcontract,@linvoice

              if @@fetch_status <0
                  break

              --print 'Process the odd-numbered supplier piecerates for contract ' + convert(varchar(12),@lcontract)
              insert into t_invoice_piecerates(
                     invoice_id,
                     atype,
                     prd_date,
                     prt_code,
                     prd_quantity,
                     cost,
                     rate,
                     rownum,
                     prs_key)
              select invoice_id,
                     piece_rate_supplier.prs_description,
                     piece_rate_delivery.prd_date,
                     piece_rate_type.prt_code,
                     piece_rate_delivery.prd_quantity,
                     piece_rate_delivery.prd_cost,
                     rate=prd_cost/prd_quantity,
                     row_number() over (order by invoice_id asc),
                     piece_rate_supplier.prs_key
                from rd.piece_rate_type,
                     rd.piece_rate_delivery,
                     odps.payment,
                     rd.piece_rate_supplier 
               where piece_rate_delivery.prt_key = piece_rate_type.prt_key 
                 and piece_rate_delivery.prd_paid_to_date = payment.invoice_date 
                 and piece_rate_supplier.prs_key = piece_rate_type.prs_key 
                 and payment.contract_no = piece_rate_delivery.contract_no
                 and payment.contract_no         = @lcontract 
                 and payment.invoice_id          = @linvoice 
                 and payment.invoice_date        = @inDate 
                 and (piece_rate_supplier.prs_key % 2) = 1
               order by invoice_id, prs_key

              if @@error <> 0
              begin
                  --rollback transaction
                  --set implicit_transactions off --add
                  return (-100001101)
              end

              --print 'Process the even-numbered supplier piecerates for contract ' + convert(varchar(12),@lcontract)
              insert into t_invoice_piecerates2(
                     invoice_id,
                     atype,
                     prd_date,
                     prt_code,
                     prd_quantity,
                     cost,
                     rate,
                     rownum)
              select invoice_id,
                     piece_rate_supplier.prs_description,
                     piece_rate_delivery.prd_date,
                     piece_rate_type.prt_code,
                     piece_rate_delivery.prd_quantity,
                     piece_rate_delivery.prd_cost,
                     rate=prd_cost/prd_quantity,
                     row_number() over (order by invoice_id asc)
                from rd.piece_rate_type,
                     rd.piece_rate_delivery,
                     odps.payment,
                     rd.piece_rate_supplier 
               where piece_rate_delivery.prt_key = piece_rate_type.prt_key 
                 and piece_rate_delivery.prd_paid_to_date = payment.invoice_date 
                 and piece_rate_supplier.prs_key = piece_rate_type.prs_key 
                 and payment.contract_no  = piece_rate_delivery.contract_no
                 and payment.invoice_date        = @inDate 
                 and payment.contract_no         = @lcontract 
                 and payment.invoice_id          = @linvoice 
                 and (piece_rate_supplier.prs_key % 2) = 0
               order by invoice_id

              if @@error <> 0
              begin
                  --rollback transaction
                  --set implicit_transactions off --add
                  return (-100001102)
              end

              --commit transaction
          end --[fetch next contract loop]
          --print 'End fetch next contract loop'

          close vc_contract_list
          deallocate vc_contract_list
      end -- [@inExportFlag = 0]

      else   -- [@inExportFlag != 0]
      begin  
          --print 'Process all contracts for export'
          open vc_contract_list

          if @@error <> 0
          begin
              --rollback transaction
              --set implicit_transactions off --add
              return (-100001001)
          end

          while 1=1    -- All contracts loop
          begin
              -- For testing limit number of times through the contract loop
              --set @nContracts = @nContracts + 1
              --if (@nContracts > 3) break

              fetch next from vc_contract_list into @lcontract,@linvoice

              if @@fetch_status <0
                  break

              --print 'Process all supplier piecerates for contract ' + convert(varchar(12),@lcontract)
                  
              insert into t_invoice_piecerates(
                     invoice_id,
                     atype,
                     prd_date,
                     prt_code,
                     prd_quantity,
                     cost,
                     rate,
                     rownum,
                     prs_key)
              select invoice_id,
                     piece_rate_supplier.prs_description,
                     piece_rate_delivery.prd_date,
                     piece_rate_type.prt_code,
                     piece_rate_delivery.prd_quantity,
                     piece_rate_delivery.prd_cost,
                     rate=prd_cost/prd_quantity,
                     row_number() over (order by invoice_id asc),
                     piece_rate_supplier.prs_key
                from rd.piece_rate_type,
                     rd.piece_rate_delivery,
                     odps.payment,
                     rd.piece_rate_supplier 
               where piece_rate_delivery.prt_key = piece_rate_type.prt_key 
                 and piece_rate_delivery.prd_paid_to_date = payment.invoice_date 
                 and piece_rate_supplier.prs_key = piece_rate_type.prs_key 
                 and payment.contract_no = piece_rate_delivery.contract_no
                 and payment.contract_no         = @lcontract 
                 and payment.invoice_id          = @linvoice 
                 and payment.invoice_date        = @inDate 
               order by invoice_id, prs_key

              if @@error <> 0
              begin
                  --rollback transaction
                  --set implicit_transactions off
                  return (-100001101)
              end

              --commit transaction
          end --[fetch next contract loop]
          --print 'End fetch next contract loop'

          close vc_contract_list
          deallocate vc_contract_list
      end -- [@inExportFlag != 0]
  end -- [process all contracts]
  --commit transaction
  --set implicit_transactions off --add
  
  return (0)
end
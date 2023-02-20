/****** Object:  StoredProcedure [odps].[OD_BLF_Mainrun_Grosspay_Piecerates]    Script Date: 08/05/2008 10:13:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure  [odps].[OD_BLF_Mainrun_Grosspay_Piecerates](@incontract_no int,@inSequence_no int,@inPayPeriod_Start datetime,@inPayPeriod_End datetime,@InvoiceNumber int,@in_PrType char(1),@v_contractor_contract_start datetime,@v_contractor_contract_end datetime,@incontractor_no int)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
	declare @p_pieceratetype int,
		@p_piecerateqty int,
		@p_pieceratecost numeric(12,2),
		@p_pieceratetotcost numeric(12,2),
		@p_pct_id int,
		@v_tempint int,
		@vt_sdate datetime,
		@vt_edate datetime,
		@ComponentNumber int,
		@pcom_number int,
		@period_nat_id int
	declare @int_temp int
	declare @str_temp varchar(40)
	declare c_AdPost cursor for select piece_rate_type.prt_key from rd.piece_rate_supplier piece_rate_supplier,rd.piece_rate_type  piece_rate_type
		where piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 1
	declare c_CourierPost cursor for select piece_rate_type.prt_key from rd.piece_rate_supplier piece_rate_supplier,rd.piece_rate_type piece_rate_type
		where piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 2
	declare c_XP cursor for select piece_rate_type.prt_key from rd.piece_rate_supplier piece_rate_supplier, rd.piece_rate_type piece_rate_type
		where piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 3
	declare c_ParcelPost cursor for select piece_rate_type.prt_key from rd.piece_rate_supplier piece_rate_supplier,rd.piece_rate_type piece_rate_type
		where piece_rate_type.prs_key = piece_rate_supplier.prs_key and piece_rate_supplier.prs_key = 4
	select @p_pieceratetotcost=0.0
	if @in_PrType = 'A' open c_AdPost
	if @in_PrType = 'C' open c_CourierPost
	if @in_PrType = 'X' open c_XP
	if @in_PrType = 'P' open c_ParcelPost
	if @@error <> 0 
	begin
		deallocate c_AdPost
		deallocate c_CourierPost
		deallocate c_XP
		deallocate c_ParcelPost
		return(-1010)
	end
	select @ComponentNumber = max(pc_id)+1 from t_payment_component
	if @@ERROR <> 0 
	begin
		deallocate c_AdPost
		deallocate c_CourierPost
		deallocate c_XP
		deallocate c_ParcelPost
		return(-1020)
	end
	if @ComponentNumber is null select @ComponentNumber=1
	if @ComponentNumber <= 0 select @ComponentNumber=1
	select @period_nat_id=(select odps.od_blf_getwhichnational(@inPayPeriod_End) )
	if @in_PrType = 'A'
		begin
			select @p_pct_id = pct_id from rd.piece_rate_supplier where prs_key = 1
			if @@ERROR <> 0 
			begin
				deallocate c_AdPost
				deallocate c_CourierPost
				deallocate c_XP
				deallocate c_ParcelPost
				return(-1019)
			end
			select @int_temp = nat_AdPost_DefaultComptype from "national" 
				where nat_id = (select odps.od_blf_getwhichnational(@inPayPeriod_End) )
			select @int_temp = isnull(@p_pct_id,@int_temp)
			select @str_temp = prs_description from rd.piece_rate_supplier where prs_key = 1
			SET IDENTITY_INSERT odps.t_payment_component On --2008
			insert into t_payment_component(pc_id,pct_id,invoice_id,pc_amount,comments) 
				values (@ComponentNumber,@int_temp,@InvoiceNumber,0,@str_temp)
			SET IDENTITY_INSERT odps.t_payment_component Off --2008
      if @@ERROR <> 0
		begin
		deallocate c_AdPost
		deallocate c_CourierPost
		deallocate c_XP
		deallocate c_ParcelPost
        return(-1021)
		end
    end
  if @in_PrType = 'C'
    begin
      select @p_pct_id = pct_id
        from rd.piece_rate_supplier where
        prs_key = 2
      if @@ERROR <> 0
		begin
		deallocate c_AdPost
		deallocate c_CourierPost
		deallocate c_XP
		deallocate c_ParcelPost
        return(-1023)
		end
select @int_temp = nat_AdPost_DefaultComptype from
          "national" where
          nat_id = (select odps.od_blf_getwhichnational(@inPayPeriod_End)  )
       select @str_temp = prs_description from rd.piece_rate_supplier where
          prs_key = 2
      SET IDENTITY_INSERT odps.t_payment_component On --2008
      insert into t_payment_component(pc_id,pct_id,invoice_id,pc_amount,comments)
		values(@ComponentNumber,isnull(@p_pct_id,@int_temp),@InvoiceNumber,0,@str_temp)
	  SET IDENTITY_INSERT odps.t_payment_component Off --2008
    end
  if @in_PrType = 'X'
    begin
      select @p_pct_id = pct_id
        from rd.piece_rate_supplier where
        prs_key = 3
      if @@ERROR <> 0
		begin
			deallocate c_AdPost
			deallocate c_CourierPost
			deallocate c_XP
			deallocate c_ParcelPost
			return(-1123)
		end
        select @str_temp = prs_description from rd.piece_rate_supplier where
          prs_key = 3
		 SET IDENTITY_INSERT odps.t_payment_component On --2008
         insert into t_payment_component(pc_id,pct_id,invoice_id,pc_amount,comments) 
		values(@ComponentNumber, @p_pct_id,@InvoiceNumber,0,@str_temp)
		 SET IDENTITY_INSERT odps.t_payment_component Off --2008
    end
  if @in_PrType = 'P'
    begin
      select @p_pct_id = pct_id  
        from rd.piece_rate_supplier where
        prs_key = 4
      if @@ERROR <> 0
		begin
			deallocate c_AdPost
			deallocate c_CourierPost
			deallocate c_XP
			deallocate c_ParcelPost
			return(-1133)
		end
select @int_temp = nat_AdPost_DefaultComptype from
          "national" where
          nat_id = (select odps.od_blf_getwhichnational(@inPayPeriod_End) )
select @str_temp = prs_description from rd.piece_rate_supplier where
          prs_key = 4
	  SET IDENTITY_INSERT odps.t_payment_component On --2008
      insert into t_payment_component(pc_id,pct_id,invoice_id,pc_amount,comments) 
		values(@ComponentNumber,isnull(@p_pct_id,@int_temp),@InvoiceNumber,0,@str_temp)
	  SET IDENTITY_INSERT odps.t_payment_component Off --2008
    end
  if @@ERROR <> 0
	begin
		deallocate c_AdPost
		deallocate c_CourierPost
		deallocate c_XP
		deallocate c_ParcelPost
		return(-1030)
	end
while 1=1 
    begin
      if @in_PrType = 'A'
        fetch next from c_AdPost into @p_pieceratetype
      if @in_PrType = 'C'
        fetch next from c_CourierPost into @p_pieceratetype
      if @in_PrType = 'X'
        fetch next from c_XP into @p_pieceratetype
      if @in_PrType = 'P'
        fetch next from c_ParcelPost into @p_pieceratetype
      if @@FETCH_STATUS <0 or @@ERROR <> 0
        break
      select 
        @p_pieceratecost = sum(prd_cost),
        @p_piecerateqty = sum(prd_quantity)
         from rd.piece_rate_delivery,
        rd.[contract],
        rd.contract_renewals join rd.contractor_renewals on
		contract_renewals.contract_no = contractor_renewals.contract_no and 
		contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number  where
        contract.contract_no = piece_rate_delivery.contract_no and
        contract_renewals.contract_no = contract.contract_no and
        contract_renewals.contract_seq_number = rd.maxSeqContractor(contract.contract_no,contractor_renewals.contractor_supplier_no) and
        (rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) >= dateadd(month,-3,@inPayPeriod_End)) and
        piece_rate_delivery.prt_key = @p_pieceratetype and
        contract.contract_no = @incontract_no and
        contractor_renewals.contractor_supplier_no = @incontractor_no and
        prd_date <= odps.OD_MiscF_GetLastDayofMonth(@inPayPeriod_start) and
        prd_date >= rd.getContractorStart(contract.contract_no,contractor_renewals.contractor_supplier_no) and
        prd_date <= rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) and
        prd_date <= @inPayPeriod_End and
        contract_renewals.con_rates_effective_date <= @inPayPeriod_End and
        piece_rate_delivery.prd_paid_to_date is null
      if @@ERROR <> 0
		begin
			deallocate c_AdPost
			deallocate c_CourierPost
			deallocate c_XP
			deallocate c_ParcelPost
			return(-1040)
		end
      if @p_pieceratecost <> 0.0 or @p_piecerateqty <> 0.0
        begin
          select @pcom_number = max(pcpr_id)+1
            from t_payment_component_piece_rates
          if @pcom_number <= 0
			begin
				deallocate c_AdPost
				deallocate c_CourierPost
				deallocate c_XP
				deallocate c_ParcelPost
				return(-1050)
			end
          if @pcom_number is null
            select @pcom_number=1
		 SET IDENTITY_INSERT odps.t_payment_component_piece_rates On --2008
         insert into t_payment_component_piece_rates(pcpr_id,prt_key,pc_id,pcpr_volume,pcpr_value) 
			values(@pcom_number, @p_pieceratetype,@ComponentNumber,@p_piecerateqty,@p_pieceratecost)
		 SET IDENTITY_INSERT odps.t_payment_component_piece_rates Off --2008
          if @@ERROR <> 0
			begin
				deallocate c_AdPost
				deallocate c_CourierPost
				deallocate c_XP
				deallocate c_ParcelPost
				return(-1060)
			end
          insert into odps.t_piecerate_tracker values(@incontract_no,@v_contractor_contract_start,odps.OD_MiscF_GetLastDayofMonth(@inPayPeriod_start))
          if @@ERROR <> 0
			begin
				deallocate c_AdPost
				deallocate c_CourierPost
				deallocate c_XP
				deallocate c_ParcelPost
				return(-1061)
			end
        end
      else
        select @p_pieceratecost=0.0
      select @p_pieceratetotcost=@p_pieceratetotcost+@p_pieceratecost
    end
  if @@ERROR <> 0
	begin
		deallocate c_AdPost
		deallocate c_CourierPost
		deallocate c_XP
		deallocate c_ParcelPost
		return(-1075)
	end
  if @in_PrType = 'A'
    close c_AdPost
  if @in_PrType = 'C'
    close c_CourierPost
  if @in_PrType = 'X'
    close c_XP
  if @in_PrType = 'P'
    close c_ParcelPost

  if @p_pieceratetotcost <> 0
    begin
      update t_payment_component set pc_amount = @p_pieceratetotcost 
		where t_payment_component.pc_id = @ComponentNumber
      if @@ERROR <> 0
		begin
			deallocate c_AdPost
			deallocate c_CourierPost
			deallocate c_XP
			deallocate c_ParcelPost
			return(-1070)
		end
    end
  else
    begin   
     delete from t_payment_component where pc_id = @ComponentNumber
    --add 
     if (@ComponentNumber >1)
          select @ComponentNumber=@ComponentNumber-1
      DBCC CHECKIDENT ('odps.t_payment_component', RESEED,@ComponentNumber )
    --add end
      if @@ERROR <> 0
		begin
			deallocate c_AdPost
			deallocate c_CourierPost
			deallocate c_XP
			deallocate c_ParcelPost
	        return(-1080)
		end
    end

deallocate c_AdPost
deallocate c_CourierPost
deallocate c_XP
deallocate c_ParcelPost
  return(0)
/* Watcom only
exception
  when others then
    rollback transaction
    resignal
    return(-1)
*/
end
GO

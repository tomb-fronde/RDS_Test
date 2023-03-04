
CREATE procedure  [odps].[OD_BLF_Mainrun_Grosspay_Piecerates](
    @incontract_no       int,
    @inSequence_no       int,
    @inPayPeriod_Start   datetime,
    @inPayPeriod_End     datetime,
    @InvoiceNumber       int,
    @in_PrType           char(1),
    @v_contractor_contract_start datetime,
    @v_contractor_contract_end datetime,
    @incontractor_no     int)
AS
BEGIN
    -- TJB  RPCR_0054 Payrun ixup  Sep-2013
    -- Re-arranged insert/update of t_payment_component
    --
    -- TJB  RPCR_0054  Apr-2013:
    -- Calculates piecerates for all piece rate suppliers 
    -- (previously did it for each of 4 suppliers separately via @in_PrType)
    -- Note: Parameter @in_PrType is no longer used
    --
    -- TJB  RD7_0031   13-Apr-2009
    -- Added @contract_seq_no, @contractor_start, @contractor_end and @LastDayofMonth
    -- to simplify.  No functional changes.

    set CONCAT_NULL_YIELDS_NULL off
    declare @p_pieceratetype         int,
            @p_piecerateqty          int,
            @p_pieceratecost         numeric(12,2),
            @p_pieceratetotcost      numeric(12,2),
            @p_supplierpieceratecost numeric(12,2),
            @p_pct_id                int,
            @v_tempint               int,
            @vt_sdate                datetime,
            @vt_edate                datetime,
            @ComponentNumber         int,
            @pcom_number             int,
            @period_nat_id           int
            
    declare @int_temp                int,
            @supplier                varchar(40)

    declare @contract_seq_no         int,
            @contractor_start        datetime,
            @contractor_end          datetime,
            @LastDayofMonth          datetime

    declare @prs_key                 int
          , @max_prs_key             int
          , @prt_key                 int

    -- Get base "ComponentNumber" - used as pc_id [was number + 1]
    select @ComponentNumber = max(pc_id) from t_payment_component
    if @@ERROR <> 0 
    begin
        return (-1020)
    end
    
    if (@ComponentNumber is null) or (@ComponentNumber <= 0)
        select @ComponentNumber=0
    
    select @contract_seq_no  = rd.maxSeqContractor(@incontract_no,@incontractor_no)
    select @contractor_start = rd.getContractorStart(@incontract_no,@incontractor_no)
    select @contractor_end   = rd.getContractorEnd(@incontract_no,@incontractor_no)
    select @LastDayofMonth   = odps.OD_MiscF_GetLastDayofMonth(@inPayPeriod_start)
    select @period_nat_id    = (select odps.od_blf_getwhichnational(@inPayPeriod_End) )

    select @p_pieceratetotcost=0.0
    
    select @prs_key = 1
    select @max_prs_key = max(prs_key) from rd.piece_rate_supplier

    -- For each supplier (prs_key)
    while @prs_key <= @max_prs_key
    begin
        select @p_supplierpieceratecost=0.0

        -- Get this supplier's name 
        select @supplier = prs_description 
          from rd.piece_rate_supplier 
         where prs_key = @prs_key
        
        -- Get the default payment component type for this supplier
        select @p_pct_id = pct_id 
          from rd.piece_rate_supplier 
         where prs_key = @prs_key
         
        if @@ERROR <> 0 
        begin
            return (-1015)
        end

        -- The original did this lookup for each of the specific prs keys
        -- The value retrieved wasn't actually used as @p_pct_id was always non-null
        -- Retained for completeness
        if @p_pct_id is null
        begin
            if @prs_key = 1 or @prs_key = 2 or @prs_key = 4
                select @p_pct_id = nat_AdPost_DefaultComptype 
                  from [national] 
                 where nat_id = @period_nat_id
            else -- [new] skip if no pct_id has been specified for this supplier
                break
        end
        
        -- Add a payment component for this supplier
        select @ComponentNumber = @ComponentNumber + 1
    
        -- TJB  RPCR_054  July-2013
        -- Changed saved cost from @p_pieceratetotcost to @p_supplierpieceratecost
        SET IDENTITY_INSERT odps.t_payment_component On --2008
        insert into t_payment_component
            ( pc_id,           pct_id,   invoice_id,    pc_amount,           comments ) 
        values 
            ( @ComponentNumber, @p_pct_id, @InvoiceNumber, 0, @supplier)
        SET IDENTITY_INSERT odps.t_payment_component Off --2008
        
        if @@ERROR <> 0
        begin
            return (-1021)
        end

        declare c_PrtKey cursor for 
               select piece_rate_type.prt_key 
                 from rd.piece_rate_type
                where piece_rate_type.prs_key = @prs_key
        
        if @@error <> 0 
        begin
            deallocate c_PrtKey
            return (-1010)
        end

        -- Open the cursor for processing
        open c_PrtKey
        
        if @@error <> 0 
        begin
            deallocate c_PrtKey
            return (-1020)
        end

        -- For each of the supplier's piece rate types
        while 1=1 
        begin
            -- Get the next type
            fetch next from c_PrtKey into @p_pieceratetype
    
            -- (assume only error is end of data)
            if @@FETCH_STATUS <0
                break
            
            -- If the FETCH returned an error ... abort 
            if @@ERROR <> 0
            begin
                close c_PrtKey
                deallocate c_PrtKey
                return (-1075)
            end

            -- Get the total cost and quantity for this type
            select @p_pieceratecost = sum(prd_cost),
                   @p_piecerateqty  = sum(prd_quantity)
              from rd.piece_rate_delivery,
                   rd.[contract],
                   rd.contract_renewals join rd.contractor_renewals 
                                 on  contract_renewals.contract_no = contractor_renewals.contract_no 
                                 and contract_renewals.contract_seq_number = contractor_renewals.contract_seq_number  
             where contract.contract_no = piece_rate_delivery.contract_no and
                   contract_renewals.contract_no = contract.contract_no and
                   -- contract_renewals.contract_seq_number = rd.maxSeqContractor(contract.contract_no,contractor_renewals.contractor_supplier_no) and
                   contract_renewals.contract_seq_number = @contract_seq_no and
                   -- (rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) >= dateadd(month,-3,@inPayPeriod_End)) and
                   @contractor_end >= dateadd(month,-3,@inPayPeriod_End) and
                   piece_rate_delivery.prt_key = @p_pieceratetype and
                   contract.contract_no = @incontract_no and
                   contractor_renewals.contractor_supplier_no = @incontractor_no and
                   -- prd_date <= odps.OD_MiscF_GetLastDayofMonth(@inPayPeriod_start) and
                   -- prd_date >= rd.getContractorStart(contract.contract_no,contractor_renewals.contractor_supplier_no) and
                   -- prd_date <= rd.getContractorEnd(contract.contract_no,contractor_renewals.contractor_supplier_no) and
                   prd_date <= @LastDayofMonth   and
                   prd_date >= @contractor_start and
                   prd_date <= @contractor_end   and
                   prd_date <= @inPayPeriod_End  and
                   contract_renewals.con_rates_effective_date <= @inPayPeriod_End and
                   piece_rate_delivery.prd_paid_to_date is null

            if @@ERROR <> 0
            begin
                deallocate c_PrtKey
                return (-1040)
            end
    
            -- If either cost or quantity non-zero, add an entry into the t_payment_component_piece_rates table
            if (@p_pieceratecost <> 0.0) or (@p_piecerateqty <> 0.0)
            begin
                select @pcom_number = max(pcpr_id)+1
                  from t_payment_component_piece_rates
                  
                if @pcom_number <= 0
                begin
                    deallocate c_PrtKey
                    return (-1050)
                end

                if @pcom_number is null
                    select @pcom_number=1
            
                SET IDENTITY_INSERT odps.t_payment_component_piece_rates On --2008
                insert into t_payment_component_piece_rates
                    ( pcpr_id,      prt_key,          pc_id,            pcpr_volume,     pcpr_value) 
                values
                    ( @pcom_number, @p_pieceratetype, @ComponentNumber, @p_piecerateqty, @p_pieceratecost)
                SET IDENTITY_INSERT odps.t_payment_component_piece_rates Off --2008
        
                if @@ERROR <> 0
                begin
                    deallocate c_PrtKey
                    return (-1060)
                end
        
                -- ... and an entry in the t_piecerate_tracker table
                -- (don't know why this is duplicated for each supplier/type 
                --   - should only be done for each supplier)
                insert into odps.t_piecerate_tracker 
                values( @incontract_no
                       ,@v_contractor_contract_start
                       ,@LastDayofMonth)
        
                if @@ERROR <> 0
                begin
                    deallocate c_PrtKey
                    return (-1061)
                end
            end
            else    -- If either cost or quantity zero ensure the cost is zero 
            begin   -- so nothing is added to the overall-total below
                select @p_pieceratecost=0.0
            end

            -- Accumulate the supplier's overall total cost
            select @p_supplierpieceratecost=@p_supplierpieceratecost+@p_pieceratecost
            
        end   -- End prt_key loop

        close c_PrtKey
        deallocate c_PrtKey
        
        -- Accumulate the overall total cost (TJB - we don't actually save/use this anywhere now)
        select @p_pieceratetotcost = @p_pieceratetotcost + @p_supplierpieceratecost
            
        -- If there were piece rates for this supplier, update the supplier's record 
        -- in the t_payment_component table
        if @p_supplierpieceratecost <> 0
        begin
            update t_payment_component 
               set pc_amount = @p_supplierpieceratecost 
             where t_payment_component.pc_id = @ComponentNumber

            if @@ERROR <> 0
            begin
                return (-1070)
            end
        end
        else  -- If there were no piece rates for this supplier
        begin -- remove the supplier's record from the t_payment_component table
              -- NOTE: the supplier record needs to be in the t_payment_component table
              --       before adding records to the t_payment_component_rates table to 
              --       satisfy a foreign key constraint on it.

            delete from t_payment_component 
             where pc_id = @ComponentNumber

            if (@ComponentNumber >1)
                select @ComponentNumber=@ComponentNumber-1

            DBCC CHECKIDENT ('odps.t_payment_component', RESEED, @ComponentNumber )

            if @@ERROR <> 0
            begin
                return (-1080)
            end    
        end

        select @prs_key = @prs_key + 1
    end  -- End prs_key (each piece rate supplier) loop
    
    return (0)
END
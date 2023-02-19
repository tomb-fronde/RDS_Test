-- exec [rd].[sp_generate_updated_allowances] 33, -1, '20-Jul-2021', 'Test allowance' 
-- exec [rd].[sp_generate_updated_allowances] -33, 1, '20-Jul-2021', 'Test vehicle' 
CREATE PROCEDURE [rd].[sp_generate_updated_allowances](
        @in_alt_key int
      , @in_var_id  int
      , @new_effective_date datetime
      , @new_notes varchar(200))
AS
BEGIN
    -- TJB Allowances 22-May-2021 
    -- Generates contract_allowance records where a contract has a 
    -- current allowance of the type - in response to one or more 
    -- allowance_type factors having changed.  
    -- When @var_id is <=0, process records with allowance_type = @alt_key
    -- When @alt_key <=0, process records with vehicle allowance_rates = @var_id
    -- Returns the number of records inserted + updated
    set nocount on
    declare @contract_no int
          , @ca_effective_date datetime
          , @ca_annual_amount numeric(10, 2) 
          , @ca_notes varchar(200) 
          , @ca_paid_to_date datetime 
          , @pct_id int 
          , @ca_approved char(1) 
          , @ca_doc_description varchar(500) 
          , @ca_var1 numeric(10, 2) 
          , @ca_dist_day numeric(10, 2) 
          , @ca_hrs_wk numeric(10, 2) 
          , @var_id int 
          , @ca_costs_covered char(1) 
          , @ca_row_changed char(1) 
          , @net_amt numeric(10, 2) 
          , @alct_id int 
          , @new_net_amt numeric(10, 2) 
          , @new_annual_amt numeric(10, 2) 
          , @prev_annual_amt numeric(10, 2) 
          , @new_paid_to_date datetime 
          , @alt_key int 
          , @alt_description varchar(35) 
          , @alt_rate numeric(10, 2) 
          , @is_approved char(1) 
          , @logmsg varchar(255)
          , @nUpdated int
          , @nProcessed int

    declare @factor_ok int       -- Used as a boolean: 0 = true, 1 = false
          , @TRUE  int
          , @FALSE int

    select  @TRUE  = 0
         ,  @FALSE = 1
         ,  @factor_ok = @TRUE

    declare @run_date datetime 
    select  @run_date = getdate()

    -- Get everything from contract_allowance for this record
	-- - we'll be inserting most of it into new contract_allowance records.
    declare cur1 cursor for
            select ca.contract_no,
                    ca_effective_date,
                    ca_annual_amount,
                    ca_notes,
                    ca_paid_to_date,
                    pct_id,
                    ca_approved,
                    ca_doc_description,
                    ca_var1,
                    ca_dist_day,
                    ca_hrs_wk,
                    var_id,
                    ca_costs_covered,
                    ca_row_changed,
                    ca.alt_key,
                    alt.alct_id,
                    alt.alt_rate,
                    [rd].[f_GetAllowanceAmount]( ca.contract_no, ca.alt_key, ca.ca_effective_date)
              from rd.contract_allowance ca, rd.allowance_type alt
             where (ca.alt_key = @in_alt_key
                     or ca.var_id = @in_var_id)
               and ca.ca_effective_date 
                       = (select max(ca2.ca_effective_date)
					        from rd.contract_allowance ca2
                           where ca2.contract_no = ca.contract_no
                             and ca2.alt_key = ca.alt_key)
               and alt.alt_key = ca.alt_key
             order by ca.contract_no

    select @alt_description = alt_description
      from rd.allowance_type
     where alt_key = @alt_key

    select @new_paid_to_date = null
    select @nProcessed = 0
    select @nUpdated = 0

    open cur1

    while( 1 = 1 )
    begin
        fetch next from cur1 into
            @contract_no,
            @ca_effective_date,
            @ca_annual_amount,
            @ca_notes,
            @ca_paid_to_date,
            @pct_id,
            @ca_approved,
            @ca_doc_description,
            @ca_var1,
            @ca_dist_day,
            @ca_hrs_wk,
            @var_id,
            @ca_costs_covered,
            @ca_row_changed,
            @alt_key,
            @alct_id,
            @alt_rate,
            @net_amt

        if( @@FETCH_STATUS <> 0 )
            break

        select @nProcessed = @nProcessed + 1

        -- If the current record's net_amount is 0, the allowance has been terminated
        -- and no additional record will be generated for it.
        if( @net_amt = 0 )
        begin
            --insert into rd.contract_allowance_update_log
            --    (run_date, contract_no, alt_key, alt_description, effective_date, alct_id, var_id, result)
            --values
            --    (@run_date, @contract_no, @alt_key, @alt_description, @new_effective_date, @alct_id, @var_id,
            --     'Skipped: allowance terminated (net amount = 0)')

            continue
        end

        -- Initialise some values
        select @is_approved = isnull(@ca_approved,'N')
             , @factor_ok = @TRUE

        -- The net_amt fetched is the current net amount.  We'll calculate a new amount
        -- using the selected record's factors and the new 'hidden' factors
        -- NOTE: Fixed type doesn't have a calculated net amount so no records will be generated
        if( @alct_id = 2 )
        begin
            if( @ca_var1 is null )
                select @factor_ok = @FALSE
            else 
                select @new_net_amt = [rd].[f_CalcROIAllowance]( @alt_key, @ca_var1)       -- @ca_var1 is investment_amount
        end
        else if( @alct_id = 3 )
        begin
            if( @ca_var1 is null )
                select @factor_ok = @FALSE
            else 
                select @new_net_amt = [rd].[f_CalcActivityAllowance]( @alt_key, @ca_var1)  -- @ca_var1 is activity_count
        end
        else if( @alct_id = 4 )
        begin
            if( @ca_hrs_wk is null )
                select @factor_ok = @FALSE
            else 
                select @new_net_amt = [rd].[f_calcTimeAllowance]( @alt_key, @ca_hrs_wk)
        end
        else if( @alct_id = 5 )
        begin
            if( @ca_var1 is null or @ca_hrs_wk is null or @ca_dist_day is null )
                select @factor_ok = @FALSE
            else 
                select @new_net_amt = [rd].[f_CalcDistanceAllowance]( @alt_key, @var_id, @ca_var1, @ca_hrs_wk, @ca_dist_day, @ca_costs_covered )
                                                                    -- @ca_var1 is days_per_year
        end
        else  -- skip any where alct_id  is not in (2,3,4,5): as the saying goes "this should never happen"
        begin
            insert into rd.contract_allowance_update_log
                (run_date, contract_no, alt_key, alt_description, effective_date, alct_id, var_id, result)
            values
                (@run_date, @contract_no, @alt_key, @alt_description, @new_effective_date, @alct_id, @var_id, 
                   'Skipped: invalid calc type (alct_id = ' + convert(varchar,@alct_id) + ')')

            continue
        end

        -- We're about to insert a new or update an existing record
        -- Ensure the date of the record we're inserting is greater than the current record's
        -- to avoid a duplicate key error.
	if( @new_effective_date <= @ca_effective_date )
	    select @new_effective_date = dateadd(day,1,@ca_effective_date)

        -- If the user-factors for this allowance haven't been entered, and the record has been approved
        -- create (insert) a new unapproved record with the annual amount = 0
        if( @factor_ok = @FALSE )
        begin
            if( @is_approved = 'Y' )
            begin
                insert into rd.contract_allowance
                    ( alt_key, contract_no, ca_effective_date, ca_annual_amount, ca_notes,
                      ca_paid_to_date, pct_id, ca_approved, ca_doc_description, ca_var1, 
                      ca_dist_day, ca_hrs_wk, var_id, ca_costs_covered, ca_row_changed)
                values
                    ( @alt_key, @contract_no, @new_effective_date, 0, @new_notes,
                      @new_paid_to_date, @pct_id, 'N', @ca_doc_description, @ca_var1, 
                      @ca_dist_day, @ca_hrs_wk, @var_id, @ca_costs_covered, 'N')

                select @logmsg = 'Approved allowance, user factor missing - inserted dummy'
            end
            else  -- If the record is not approved, update it
            begin
                update rd.contract_allowance
                   set ca_annual_amount = 0
                     , ca_effective_date= @new_effective_date
                     , ca_notes = @new_notes
                 where contract_no = @contract_no
                   and ca_effective_date = @ca_effective_date
                   and alt_key = @alt_key    

                select @logmsg = 'Unapproved allowance, user factor missing - updated'
            end

            insert into rd.contract_allowance_update_log
                (run_date, contract_no, alt_key, alt_description, effective_date, alct_id, var_id, result)
            values
                (@run_date, @contract_no, @alt_key, @alt_description, @new_effective_date, @alct_id, @var_id, @logmsg)

            select @nUpdated = @nUpdated + 1
            continue
        end

        -- If there's no change in the ca_annual_amount, there's no need for a new record
        if( @new_annual_amt = 0 )
        begin
            insert into rd.contract_allowance_update_log
                (run_date, contract_no, alt_key, alt_description, effective_date, alct_id, var_id, result)
            values
                (@run_date, @contract_no, @alt_key, @alt_description, @new_effective_date, @alct_id, @var_id,
                 'Skipped: net amount unchanged (@new_net_amt = @net_amt)')

            continue
        end

        -- If this record has been approved, create (insert) a new one
        if( @is_approved = 'Y' )
        begin
            -- Calculate the new annual amount
	        select @prev_annual_amt = @net_amt
            select @new_annual_amt = @new_net_amt - @prev_annual_amt

            insert into rd.contract_allowance
                ( alt_key, contract_no, ca_effective_date, ca_annual_amount, ca_notes,
                  ca_paid_to_date, pct_id, ca_approved, ca_doc_description, ca_var1, 
                  ca_dist_day, ca_hrs_wk, var_id, ca_costs_covered, ca_row_changed)
            values
                ( @alt_key, @contract_no, @new_effective_date, @new_annual_amt, @new_notes,
                  @new_paid_to_date, @pct_id, 'N', @ca_doc_description, @ca_var1, 
                  @ca_dist_day, @ca_hrs_wk, @var_id, @ca_costs_covered, @ca_row_changed)

            select @logmsg = 'Allowance approved - inserted new record.' 
        end
        else  -- If not yet approved, update the current record
        begin 
            -- Calculate the new annual amount
            select @prev_annual_amt = @net_amt - @ca_annual_amount
            select @new_annual_amt = @new_net_amt - @prev_annual_amt

			update rd.contract_allowance
				set ca_annual_amount = @new_annual_amt
					, ca_effective_date = @new_effective_date
					, ca_notes = @new_notes
				where contract_no = @contract_no
				and ca_effective_date = @ca_effective_date
				and alt_key = @alt_key    
			
            select @logmsg = 'Allowance not approved - updated record.' 
        end

        --select @logmsg = @logmsg 
        --               + ' alt_rate = ' + convert(varchar,@alt_rate)
        --               + ', @ca_annual_amount = '+convert(varchar,@ca_annual_amount)+', @net_amt = '+convert(varchar,@net_amt)
        --               + ', @new_net_amt = '+convert(varchar,@new_net_amt)
        insert into rd.contract_allowance_update_log
            (run_date, contract_no, alt_key, alt_description, effective_date, alct_id, var_id, result)
        values
            (@run_date, @contract_no, @alt_key, @alt_description, @new_effective_date, @alct_id, @var_id, @logmsg)

        select @nUpdated = @nUpdated + 1
    end  -- end proceeing loop
    
    -- Add a summary to the log
    select @logmsg = convert(varchar,@nProcessed)+' records processed, ' 
                   + convert(varchar,@nUpdated)+' records updated'
    insert into rd.contract_allowance_update_log
        (run_date, result)
    values
        (@run_date, @logmsg)
    
    select @nUpdated as nUpdated
END
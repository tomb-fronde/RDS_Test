/****** Object:  StoredProcedure [rd].[mpt_customers_delta]    Script Date: 08/05/2008 10:17:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rd].[mpt_customers_delta] ( 
        @last_run_date   datetime 
)
/******************************************************************
 * Description
 *    This routine extracts changed customer data from the RDS database 
 *    for the MPT repository data feed.  It extracts new customers,
 *    deleted customers, and customers whose address has changed.  It 
 *    also reports other changes in the customer's details (from the
 *    rds_customer table - such as name, or residence classification).
 *    Changes in interests or occupation are not included.
 *
 * Parameters
 *    @last_run_date    datetime 
 *
 * Returns
 *    The procedure creates a RESULT SET:
 *          change_type       char(1)       NOT NULL
 *          cust_id           integer       NOT NULL
 *          dp_id             integer       NOT NULL
 *          title             varchar(10)       NULL
 *          initial           varchar(30)       NULL
 *          surname           varchar(45)   NOT NULL
 *          classification    char(1)           NULL
 *          move_in_date      datetime          NULL
 *          move_out_date     datetime          NULL
 *          opt_in_ind        char(1)           NULL
 *
 *
 * System
 *    VAS Programme
 *
 * Author
 *    Tom Britton, Fronde Systems Group
 *
 * Created on
 *    June 2008
 *
 * Modification history
 * 13 Jun 2008  TJB  Fixed bug with excluding duplicate records
 * 18 Jun 2008  TJB  Add adr_id to output
 *  4 Jul 2008  TJB  Removed adr_id from returned data
 *  8 Jul 2008  TJB  Added move_out_date to returned data
 *  8 Jul 2008  TJB  Changed name to mpt_customers_delta
 *  9 Jul 2008  TJB  Added Rural Delivery contracts only restriction
 *                   Change date check to range last_run and twoWeeksHence
 * 11 Jul 2008  TJB  Changed to return data as result set.
 * 17 Jul 2008  TJB  Converted to SQL Server syntax
 * 28 Jul 2008  TJB  Added handling of master<-->recipient changes
 *****************************************************************/
AS
BEGIN
    declare @status        integer;
    declare @description   varchar(100);
    declare @now           datetime;
    declare @purge_date    datetime;
    declare @twoWeeksHence datetime;
    
    declare @newcusts      integer;
    declare @movedcusts    integer;
    declare @deletedcusts  integer;
    declare @changedcusts  integer;

    CREATE TABLE #tmp_mpt_customers_delta
    (
            change_type    char(1)      NOT NULL
          , cust_id        integer      NOT NULL
          , dp_id          integer      NOT NULL
          , title          varchar(10)      NULL
          , initial        varchar(30)      NULL
          , surname        varchar(45)  NOT NULL
          , classification char(1)          NULL
          , move_in_date   datetime         NULL
          , move_out_date  datetime         NULL
          , opt_in_ind     char(1)          NULL
    );

    CREATE TABLE #tmp_mpt_customers
    (
          cust_id        integer  NOT NULL
    );

        -- Need the date and time for the logged actions
    set @now    = convert(datetime,convert(varchar(10),getdate(),120));
    set @status = 0;
    set @twoWeeksHence = dateadd( day, 14, @now );
    set @purge_date = dateadd( day, -14, @last_run_date );


    /***************************************************************
     * Prepare mpt_customers_old table for this run
     ***************************************************************/

        -- Purge expired deleted entries from mpt_customers_old
    if @status = 0 
    begin
        print 'Purge expired deleted entries from mpt_customers_old'
              +': Purge date = '+convert(varchar,@purge_date)
        
        delete from mpt_customers_old
         where change_date <= @purge_date
           and change_type = 'D';
    
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' purging expired records from mpt_customers_old';
        end
    end

        -- Reset state of mpt_changes_old in case this is a rerun
        -- Remove and "New" records added after the last run     
    if @status = 0 
    begin
        print 'Remove and "New" records added after the last run'
        print '    - delete from mpt_customers_old'
        print '       where change_date between '+convert(varchar,@last_run_date)+' and '+convert(varchar,@twoWeeksHence)
     
        delete from mpt_customers_old
         where change_date between @last_run_date and @twoWeeksHence
           and change_type = 'N';
    
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' resetting mpt_customers_old "new" records';
        end
    end

        -- Undo any "Delete"d records changed after the last run     
        -- (we use the purge_date because we don't know what their 
        --     original 'new' date was)
    if @status = 0 
    begin
        print 'Undo any "Delete"d records changed after the last run'
        print '    - update mpt_customers_old'

        update mpt_customers_old
           set change_type = 'N'
             , change_date = @purge_date
         where change_date between @last_run_date and @twoWeeksHence
           and change_type = 'D';
    
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' resetting mpt_customers_old "deleted" records';
        end
    end

    /****************************************************************
     * Clear the data table
     ****************************************************************/
     
    if @status = 0 
    begin
        print 'truncate TABLE #tmp_mpt_customers_delta'

        truncate TABLE #tmp_mpt_customers_delta;
    
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' truncating table tmp_mpt_customers_data';
        end
    end

    /****************************************************************
     * Gather new customers data
     * - master customers with a move_in_date since the last_run_date
     *   who haven't yet moved out (move_out_date is null).
     ****************************************************************/

    if @status = 0 
    begin
        print 'Gather "new" customers data'

        insert into #tmp_mpt_customers_delta
            (change_type, cust_id, dp_id, title, initial, surname, 
             classification, move_in_date, move_out_date, opt_in_ind)
        select 'N'
             , c.cust_id
             , isnull(cam.dp_id,a.dp_id)
             , rd.trim(cust_title)
             , rd.trim(cust_initials)
             , cust_surname_company
             , (case when c.cust_business = 'Y' then 'B' else
                case when c.cust_rural_farmer = 'Y' then 'F' else
                case when c.cust_rural_resident = 'Y' then 'R' else ' ' 
                end end end)     as classification
             , cam.move_in_date
             , cam.move_out_date
             , isnull(c.cust_dir_listing_ind,'N')
          from rds_customer c
             , address a
             , customer_address_moves cam
         where c.master_cust_id is null
           and c.cust_surname_company != 'Dummy'
           and cam.cust_id = c.cust_id
           and a.adr_id = cam.adr_id
           and a.dp_id is not null
           and a.contract_no < 6000      -- Rural Delivery contracts only
           and cam.move_in_date between @last_run_date and @twoWeeksHence
           and cam.move_out_date is null
           and not exists (select 1 from customer_address_moves cam2
                            where cam2.cust_id = c.cust_id
                              and move_out_date between @last_run_date and @twoWeeksHence)
         order by c.cust_id;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering new customer data';
        end;
    end;


    /****************************************************************
     * Gather moved customers data
     * - master customers with a move_in_date since the last_run_date
     *   who have also moved out since the last_run_date
     ****************************************************************/

    if @status = 0 
    begin
        print 'Gather "moved" customers data'

        insert into #tmp_mpt_customers_delta
            (change_type, cust_id, dp_id, title, initial, surname, 
             classification, move_in_date, move_out_date, opt_in_ind)
        select 'M'
             , c.cust_id
             , isnull(cam.dp_id,a.dp_id)
             , rd.trim(cust_title)
             , rd.trim(cust_initials)
             , cust_surname_company
             , (case when c.cust_business = 'Y' then 'B' else
                case when c.cust_rural_farmer = 'Y' then 'F' else
                case when c.cust_rural_resident = 'Y' then 'R' else ' ' 
                end end end)     as classification
             , cam.move_in_date
             , cam.move_out_date
             , isnull(c.cust_dir_listing_ind,'N')
          from rds_customer c
             , address a
             , customer_address_moves cam
         where c.master_cust_id is null
           and c.cust_surname_company != 'Dummy'
           and cam.cust_id = c.cust_id
           and a.adr_id = cam.adr_id
           and a.dp_id is not null
           and a.contract_no < 6000      -- Rural Delivery contracts only
           and cam.move_in_date between @last_run_date and @twoWeeksHence
           and cam.move_out_date is null
           and exists (select 1 from customer_address_moves cam2
                        where cam2.cust_id = c.cust_id
                          and move_out_date between @last_run_date and @twoWeeksHence)
         order by c.cust_id;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering moved customer data';
        end;
    end;


    /*****************************************************************
     * Gather deleted customers data
     * - master customers with a move_out_date since the last_run_date
     *   and who have not moved in elsewhere (transferred)
     *****************************************************************/

    if @status = 0 
    begin
        print 'Gather "deleted" customers data'

        insert into #tmp_mpt_customers_delta
            (change_type, cust_id, dp_id, title, initial, surname, 
             classification, move_in_date, move_out_date, opt_in_ind)
        select 'D'
             , c.cust_id
             , isnull(cam.dp_id,a.dp_id)
             , rd.trim(cust_title)
             , rd.trim(cust_initials)
             , cust_surname_company
             , (case when c.cust_business = 'Y' then 'B' else
                case when c.cust_rural_farmer = 'Y' then 'F' else
                case when c.cust_rural_resident = 'Y' then 'R' else ' ' 
                end end end)     as classification
             , cam.move_in_date
             , cam.move_out_date
             , isnull(c.cust_dir_listing_ind,'N')
          from rds_customer c
             , address a
             , customer_address_moves cam
         where c.master_cust_id is null
           and c.cust_surname_company != 'Dummy'
           and cam.cust_id = c.cust_id
           and a.adr_id = cam.adr_id
           and a.dp_id is not null
           and a.contract_no < 6000      -- Rural Delivery contracts only
           and cam.move_out_date between @last_run_date and @twoWeeksHence
           and not exists (select 1 from customer_address_moves cam2
                            where cam2.cust_id = c.cust_id
                              and move_out_date is null)
         order by c.cust_id;

        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering deleted customer data';
        end;
    end;


    /*************************************************************************
     * Gather changed customers data
     * - Customers whose records have been changed since the last_amended_date 
     *   Note: we don't know what has changed.  The last_amended_date is not 
     *         updated when the customer moves or transfers but is if the 
     *         customer is new (ie not a transferree),  In the latter case we 
     *         don't want to create a "changed" record where there exists a 
     *         "new" record.
     *************************************************************************/

        -- Prepare a list of "New" and "Deleted" customers to match "Changed"
        -- customers against.
    if @status = 0 
    begin
        print 'Gather "changed" customers data'

        insert into #tmp_mpt_customers ( cust_id )
        select cust_id from #tmp_mpt_customers_delta;

        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' listing modified customer.';
        end;
    end;

        -- Add the "Changed" customers to the customers_delta list
    if @status = 0 
    begin
        print 'Add the "Changed" customers to the customers_delta list'

        insert into #tmp_mpt_customers_delta
            (change_type, cust_id, dp_id, title, initial, surname, 
             classification, move_in_date, move_out_date, opt_in_ind)
        select 'C'
             , c.cust_id
             , isnull(cam.dp_id,a.dp_id)
             , rd.trim(cust_title)
             , rd.trim(cust_initials)
             , cust_surname_company
             , (case when c.cust_business = 'Y' then 'B' else
                case when c.cust_rural_farmer = 'Y' then 'F' else
                case when c.cust_rural_resident = 'Y' then 'R' else ' ' 
                end end end) as classification
             , cam.move_in_date
             , cam.move_out_date
             , isnull(c.cust_dir_listing_ind,'N')
          from rds_customer c
             , address a
             , customer_address_moves cam
         where c.master_cust_id is null
           and c.cust_surname_company != 'Dummy'
           and cam.cust_id = c.cust_id
           and a.adr_id = cam.adr_id
           and a.dp_id is not null
           and a.contract_no < 6000            -- Rural Delivery contracts only
           and cam.move_out_date is null
           and c.cust_last_amended_date between @last_run_date and @twoWeeksHence
           and c.cust_id not in (select tmpt2.cust_id from #tmp_mpt_customers tmpt2)
         order by c.cust_id;

        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering changed customer data';
        end
    end

    /********************************************************************************
     * Now we need to determine something about the "Changed" customers.
     *
     * It is possible for a master customer to become a recipient without
     * moving or transferring, and similarly for a recipient to become a master.
     * In these cases, the customer's last_amended_date is updated, but there 
     * are no corresponding customer moves records.  To keep the MPT customer 
     * list holding only master customers, we have to treat a master-->recipient 
     * change as a "Delete" and a recipient-->master change as a "New".
     *
     * So we have to determine which of the "Change" records are master/recipient
     * changes and change the records' change_type to "New" or "Delete" as
     * appropriate.
     *
     * The mpt_customers_old table lists the master customers as at the last
     * run (or can be modified to return it to that state if this is a rerun). 
     * - If a "Changed" record's customer doesn't appear in the mpt_customers_old
     *   list, it must be a recipient who has become a master; change the change_type
     *   to "New".
     * - now find any recipients whose last_changed_date is since the last run date
     *   and whose customer_id is in the mpt_customers_old list; this is a master 
     *   who has become a recipient. Insert a "Delete" record.
     ********************************************************************************/

        -- Look for recipient-->master changes
    if @status = 0 
    begin
        print 'Look for recipient-->master changes'
        print '    - update #tmp_mpt_customers_delta'

        update #tmp_mpt_customers_delta
           set change_type = 'N'
         where change_type = 'C'
           and not exists (select 1 from mpt_customers_old co
                            where co.cust_id = cust_id);

        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' looking for recipient-->master changes';
        end
    end

        -- Look for master-->recipient changes
    if @status = 0 
    begin
        print 'Look for master-->recipient changes'
        print '    - insert into #tmp_mpt_customers_delta'

        insert into #tmp_mpt_customers_delta
            (change_type, cust_id, dp_id, title, initial, surname, 
             classification, move_in_date, move_out_date, opt_in_ind)
        select 'D'
             , c.cust_id
             , isnull(cam.dp_id,a.dp_id)
             , rd.trim(cust_title)
             , rd.trim(cust_initials)
             , cust_surname_company
             , (case when c.cust_business = 'Y' then 'B' else
                case when c.cust_rural_farmer = 'Y' then 'F' else
                case when c.cust_rural_resident = 'Y' then 'R' else ' ' 
                end end end) as classification
             , cam.move_in_date
             , cam.move_out_date
             , isnull(c.cust_dir_listing_ind,'N')
          from rds_customer c
             , address a
             , customer_address_moves cam
         where c.master_cust_id is not null           -- A recipient
           and c.cust_surname_company != 'Dummy'
           and cam.cust_id = c.cust_id
           and a.adr_id = cam.adr_id
           and a.dp_id is not null
           and a.contract_no < 6000                   -- Rural Delivery contracts only
           and cam.move_out_date is null
           and c.cust_last_amended_date between @last_run_date and @twoWeeksHence
           and exists (select 1 from mpt_customers_old co
                        where co.cust_id = c.cust_id)
         order by c.cust_id;

        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' looking for master-->recipient changes';
        end
    end

    /***************************************************************************
     * Update the mpt_customers_old table so it reflects the changes
     ***************************************************************************/

        -- Flag any deleted customers
    if @status = 0 
    begin
        print 'Flag any deleted customers'
        print '    - update mpt_customers_old'

        update mpt_customers_old
           set change_type = 'D'
             , change_date = @now
          from #tmp_mpt_customers_delta cd
         where cd.cust_id = mpt_customers_old.cust_id
           and cd.change_type = 'D';
           
        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' upsdating mpt_customers_old with deletes';
        end
    end

        -- Add any new customers
    if @status = 0 
    begin
        print 'Insert any new customers'

        insert into mpt_customers_old
               ( cust_id, change_type, change_date )
            select cust_id, change_type, @now
              from #tmp_mpt_customers_delta
             where change_type = 'N';
           
        if @@error <> 0
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' upsdating mpt_customers_old with inserts';
        end
    end

    /************************************************************
     * Return the results as a result set
     ************************************************************/

    if @status = 0 
    begin
        print 'Return the result set'

        select * from #tmp_mpt_customers_delta
         order by cust_id, change_type;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' returning results';
        end;
    end;

    /************************************************************
     * Done.
     ************************************************************/

    set @newcusts     = 0;
    set @movedcusts   = 0;
    set @deletedcusts = 0;
    set @changedcusts = 0;
    
    if @status = 0 
    begin
        select @newcusts = count(*)
          from #tmp_mpt_customers_delta
         where change_type = 'N';

        select @movedcusts = count(*)
          from #tmp_mpt_customers_delta
         where change_type = 'M';

        select @deletedcusts = count(*)
          from #tmp_mpt_customers_delta
         where change_type = 'D';

        select @changedcusts = count(*)
          from #tmp_mpt_customers_delta
         where change_type = 'C';
    end
    
    if @status = 0 
        print 'Completed successfully: '
              + convert(varchar(8),@newcusts) + ' new, '
              + convert(varchar(8),@movedcusts) + ' moved, '
              + convert(varchar(8),@deletedcusts) + ' deleted'
              + convert(varchar(8),@changedcusts) + ' changed'
    else
        print @description;
    
END
GO

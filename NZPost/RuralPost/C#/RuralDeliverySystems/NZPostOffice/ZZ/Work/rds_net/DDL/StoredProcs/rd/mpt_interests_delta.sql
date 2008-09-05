/****** Object:  StoredProcedure [rd].[mpt_interests_delta]    Script Date: 08/05/2008 10:17:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rd].[mpt_interests_delta] (
      @run_date     datetime 
    )
/*****************************************************************************
 * Description
 *    This routine extracts customer interest and occupation data 
 *    from the RDS database for the MPT repository data feed and 
 *    returns a list of changes (New, Deleted) since the last run.
 *
 * Parameters
 *    run_date     - usually the current date but can be set to a
 *                   date a day or so earlier to get changes since 
 *                   and including that date.
 *
 * Returns
 *    Data as a result set:
 *          cust_id      integer      NOT NULL
 *          type         char(1)      NOT NULL
 *          code         integer      NOT NULL
 *          change_type  char(1)      NOT NULL
 *          change_date  datetime     NOT NULL
 *
 * System
 *    VAS Programme
 *
 * Author
 *    Tom Britton, Fronde Systems Group
 *
 * Created on
 *    July 2008
 *
 * Modification history
 *  7 Jul 2008  TJB  Made purge_date fixed at 14 days before run_date
 *  9 Jul 2008  TJB  Added Rural Delivery contracts only restriction
 *                      for customer selection.
 *                   Added removal of 'deleted' records from "old" table
 *                      when the same record is added as a 'new' record.
 * 11 Jul 2008  TJB  Changed to return data as result set.
 * 16 Jul 2008  TJB  Changed column names to be consistent with specifications
 *                   (changed type_ind --> type, value --> code)
 * 17 Jul 2008  TJB  Converted to SQL Server syntax
 *****************************************************************************/
AS
BEGIN
    declare @status              integer;
    declare @description         varchar(100);
    declare @interests_added     integer;
    declare @interests_deleted   integer;
    declare @occupations_added   integer;
    declare @occupations_deleted integer;
    declare @purge_date          datetime;

    declare @newcusts            integer;
    declare @deletedcusts        integer;
    declare @changedcusts        integer;

    set @status = 0;
    set @purge_date = dateadd( day, -14, @run_date );

    /************************************************************
     * Create required tables, if they don't already exist
     ************************************************************/

    if @status = 0 
    begin
        if not exists (select 1 from sysobjects where name = 'mpt_interests_old') 
        begin

            CREATE TABLE mpt_interests_old
               (    cust_id         integer NOT NULL
                  , code            integer NOT NULL
                  , type            char(1) NOT NULL        -- 'O' (occupation) or 'I' (interest)
                  , change_type     char(1) NOT NULL        -- 'N' (new) or 'D' (deleted)
                  , change_date     datetime    NOT NULL
               );

            if @@error <> 0 
            begin
                set @status = -1;
                set @description = 'SQL Error '+convert(varchar(10),@@error)
                                   +' creating table mpt_interests_old';
            end;

            if @status = 0 
            begin
                CREATE INDEX mpt_interests_old_ndx
                    ON mpt_interests_old (cust_id ASC);

                if @@error <> 0 
                begin
                    set @status = -1;
                    set @description = 'SQL Error '+convert(varchar(10),@@error)
                                       +' creating index on mpt_interests_old';
                end;
            end;
        end;
    end;

    if @status = 0 
    begin
        if not exists (select 1 from sysobjects where name = 'mpt_interests_new') 
        begin

            CREATE TABLE mpt_interests_new
               (    cust_id         integer NOT NULL
                  , code            integer NOT NULL
                  , type            char(1) NOT NULL        -- 'O' (occupation) or 'I' (interest)
               );

            if @@error <> 0 
            begin
                set @status = -1;
                set @description = 'SQL Error '+convert(varchar(10),@@error)
                                   +' creating table mpt_interests_new';
            end;

            if @status = 0 
            begin
                CREATE INDEX mpt_interests_new_ndx
                    ON mpt_interests_new (cust_id ASC);

                if @@error <> 0 
                begin
                    set @status = -1;
                    set @description = 'SQL Error '+convert(varchar(10),@@error)
                                       +' creating index on mpt_interests_new';
                end;
            end;
        end;
    end;

    if @status = 0 
    begin
        if not exists (select 1 from sysobjects where name = 'mpt_interests_changes') 
        begin

            CREATE TABLE mpt_interests_changes
               (    cust_id         integer NOT NULL
                  , type            char(1) NOT NULL        -- 'O' (occupation) or 'I' (interest)
                  , code            integer NOT NULL
                  , change_type     char(1) NOT NULL        -- 'N' (new) or 'D' (deleted)
               );

            if @@error <> 0 
            begin
                set @status = -1;
                set @description = 'SQL Error '+convert(varchar(10),@@error)
                                   +' creating table mpt_interests_changes';
            end;

            if @status = 0 
            begin
               CREATE INDEX mpt_interests_changes_ndx
                   ON mpt_interests_changes (cust_id ASC);

                if @@error <> 0 
                begin
                    set @status = -1;
                    set @description = 'SQL Error '+convert(varchar(10),@@error)
                                       +' creating index on mpt_interests_changes';
                end;
            end;
        end;
    end;

    /************************************************************
     * Clear the current interests and changes tables
     ************************************************************/
     
    if @status = 0 
    begin

        print 'truncate TABLE mpt_interests_new'
        
        truncate TABLE mpt_interests_new;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' truncating table mpt_interests_new';
        end;
    end;

    if @status = 0 
    begin

        print 'truncate TABLE mpt_interests_changes'
        
        truncate TABLE mpt_interests_changes;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' truncating table mpt_interests_changes';
        end;
    end;


    /************************************************************
     * Prepare the mpt_interests_old table
     ************************************************************/
            -- Purge old "deleted" records
    if @status = 0 
    begin

        print 'Purge mpt_interests_old - purge date '+convert(varchar,@purge_date)
        
        delete from mpt_interests_old 
         where change_type = 'D'
           and change_date <= @purge_date;
         
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' purging old "deleted" records';
        end;
    end;
    
           -----------------------------------------------------------------
           -- Reorganise the retained interests/occupation data to reflect -
           -- the state at the specified run_date (this may be a re-run).  -
           -----------------------------------------------------------------
           
           -- Delete any "new" records added on or after the run_date
    if @status = 0 
    begin

        print 'Delete "new" from mpt_interests_old where change_date >= '+convert(varchar,@run_date)
        
        delete from mpt_interests_old 
         where change_type = 'N'
           and change_date >= @run_date;
         
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' deleting post run_date "new" records';
        end;
    end;
    
           -- Mark any records deleted on or after the run_date as existing ("new") at least 
           -- as far back as the purge date (we don't know when they were actually added).
    if @status = 0 
    begin
        print 'Undelete records where change_date >= '+convert(varchar,@run_date)


        update mpt_interests_old 
           set change_type = 'N'
             , change_date = @purge_date
         where change_type = 'D'
           and change_date >= @run_date;
         
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' undeleting post run_date "deleted" records';
        end;
    end;
     

    /************************************************************
     * Gather current interest and occupation data
     ************************************************************/

           -- Select all current interests into 
           -- the mpt_interests_new table.
    if @status = 0 
    begin
        print 'insert current interests into mpt_interests_new'
        
        insert into mpt_interests_new
             ( cust_id, code,        type  )
        select cust_id, interest_id, 'I' 
          from customer_interest
         where cust_id in (select c.cust_id
                             from rds_customer c
                                , address a
                                , customer_address_moves cam
                            where c.master_cust_id is null
                              and c.cust_surname_company != 'Dummy'
                              and cam.cust_id = c.cust_id
                              and cam.move_out_date is null
                              and a.adr_id = cam.adr_id
                              and a.contract_no < 6000      -- Rural Delivery contracts only
                              and a.dp_id is not null );

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering current interest data';
        end;
    end;

           -- Select all current occupations into 
           -- the mpt_interests_new table.
    if @status = 0 
    begin
        print 'insert current occupations into mpt_interests_new'

        insert into mpt_interests_new
             ( cust_id, code,          type  )
        select cust_id, occupation_id, 'O' 
          from customer_occupation
         where cust_id in (select c.cust_id
                             from rds_customer c
                                , address a
                                , customer_address_moves cam
                            where c.master_cust_id is null
                              and c.cust_surname_company != 'Dummy'
                              and cam.cust_id = c.cust_id
                              and cam.move_out_date is null
                              and a.adr_id = cam.adr_id
                              and a.contract_no < 6000      -- Rural Delivery contracts only
                              and a.dp_id is not null );

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering current occupation data';
        end;
    end;

    /************************************************************
     * Determine what's changed since the run_date
     ************************************************************/

           -- Add any 'new' records to the "changes" table
           -- 'New' records are those that exist in the "New" table 
           -- but not in the "Old" table.
    if @status = 0 
    begin
        print 'Add "new" records to mpt_interests_changes'
        
        insert into mpt_interests_changes
	     ( cust_id, type, code, change_type )
        select cust_id, type, code, 'N'
          from mpt_interests_new inew
         where not exists ( select 1 from mpt_interests_old iold
                             where iold.cust_id = inew.cust_id
                               and iold.code    = inew.code
                               and iold.type    = inew.type 
                               and iold.change_type = 'N' );

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' determining "new" records';
        end;
    end;

           -- Add any 'deleted' records to the "changes" table
           -- 'Deleted' records are those that exist in the "Old" table but
           -- not in the "New" table.
    if @status = 0 
    begin
        print 'Add "Deleted" records to mpt_interests_changes'

        insert into mpt_interests_changes
             ( cust_id, type, code, change_type )
        select cust_id, type, code, 'D'
          from mpt_interests_old iold
         where iold.change_type = 'N'
           and not exists ( select 1 from mpt_interests_new inew
                             where inew.cust_id = iold.cust_id
                               and inew.code    = iold.code
                               and inew.type    = iold.type  );

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' determining "deleted" records';
        end;
    end;

    /************************************************************
     * Update the mpt_interests_old table with current 
     * records' status
     ************************************************************/

           -- Mark any 'New' records in the "Old" table as 'deleted' that 
           -- are marked 'deleted' in the "Change" table.
           -- Set the change date to the run_date
    if @status = 0 
    begin
        print 'Mark any "New" records in the "Old" table as "deleted"'

        update mpt_interests_old
           set change_type = 'D'
             , change_date = @run_date
          from mpt_interests_changes change
         where mpt_interests_old.cust_id = change.cust_id
           and mpt_interests_old.code    = change.code
           and mpt_interests_old.type    = change.type 
           and mpt_interests_old.change_type = 'N'
           and change.change_type = 'D';
           
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' marking "deleted" records in mpt_interests_old';
        end;
    end;

           -- Add any 'new' records in the "Change" table to the "Old" table.
           -- Set the change date to the run_date
    if @status = 0 
    begin
        print 'Add any "new" records in the "Change" table to the "Old" table'

        insert into mpt_interests_old
             ( cust_id, code, type, change_type, change_date )
        select cust_id, code, type, 'N',         @run_date
          from mpt_interests_changes change
         where change.change_type = 'N';

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' inserting "new" records into mpt_interests_old';
        end;
    end;

           -- Purge any 'deleted' records in the "old" table that exist 
           -- in the "change" table as 'new'.  This prevents there being 
           -- 'new' and 'deleted' records for the same customer/value/type.
    if @status = 0 
    begin
        print 'Purge any "deleted" records in the "old" table that exist in the "change" table as "new"'

        delete 
          from mpt_interests_old
          from mpt_interests_changes as change
         where mpt_interests_old.change_type   = 'D'
           and change.change_type = 'N';

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' removing "deleted" records from mpt_interests_old';
        end;
    end;

    /************************************************************
     * Return the results as a result set
     ************************************************************/

    if @status = 0 
    begin
        print 'Return the result set'

        select * from mpt_interests_changes
         order by cust_id, type, code;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' returning results';
        end;
    end;

    /************************************************************
     * Done.
     ***********************************************************/

    set @newcusts     = 0;
    set @deletedcusts = 0;
    set @changedcusts = 0;
    
    if @status = 0 
    begin
        select @newcusts = count(*)
          from mpt_interests_changes
         where change_type = 'N';

        select @deletedcusts = count(*)
          from mpt_interests_changes
         where change_type = 'D';

        select @changedcusts = count(*)
          from mpt_interests_changes
         where change_type = 'C';
    end
    
    if @status = 0 
        print 'Completed successfully: '
              + convert(varchar(10),@newcusts) + ' new, '
              + convert(varchar(10),@deletedcusts) + ' deleted, '
              + convert(varchar(10),@changedcusts) + ' changed'
    else
        print @description;
    

END
GO

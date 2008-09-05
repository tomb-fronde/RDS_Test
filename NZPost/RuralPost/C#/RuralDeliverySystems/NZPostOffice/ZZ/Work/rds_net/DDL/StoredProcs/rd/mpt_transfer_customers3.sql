/****** Object:  StoredProcedure [rd].[mpt_transfer_customers3]    Script Date: 08/05/2008 10:17:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rd].[mpt_transfer_customers3](
    @outfile       varchar(255)
	)
/******************************************************************
 * Description
 *    This routine extracts customer data from the RDS database for the 
 *    MPT repository data frrd.
 *
 * Parameters
 *    None
 *
 * Returns
 *    status       integer,
 *    description  char(60)
 *
 * Output file
 *    The procedure creates an output file containing a comma-separated 
 *    list (CSV file) of data. The columns in this file are:
 *           cust_id          intege
 *           dp_id            integer
 *           title            varchar(10)
 *           initial          varchar(30)
 *           surname          varchar(45)
 *           classification   char(1)
 *           move_in_date     datetime
 *           move_out_date    datetime
 *           opt_in_ind       char(1)     
 *
 *    NOTE:  The output filename is hardcoded into this procedure 
 *           at about line 76.  It must be set manually before 
 *           loading and running this procedure!
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
 * 10 Jun 2008  TJB  Removed opt in/out from selection criteria
 *                   Added opt in/out flag to output file
 * 18 Jun 2008  TJB  Add adr_id to output
 *  4 Jul 2008  TJB  Removed adr_id from returned data
 *  8 Jul 2008  TJB  Added move_out_date to returned data
 * 16 Jul 2008  TJB  Converted to SQL Server syntax
 * 28 Jul 2008  TJB  Added code to create and populate the mpt_customers_old table
 * 30 Jul 2008  TJB  Changed to make output filename a parameter
 *****************************************************************/
AS     
BEGIN
    declare @status        integer;
    declare @errmsg        varchar(120)
    declare @now           datetime
    
    CREATE TABLE #tmp_mpt_transfer_data
    (
            cust_id        integer     NOT NULL
          , dp_id          integer     NOT NULL
          , title          varchar(10)     NULL
          , initial        varchar(30)     NULL
          , surname        varchar(45) NOT NULL
          , classification char(1)         NULL
          , move_in_date   datetime        NULL
          , move_out_date  datetime        NULL
          , opt_in_ind     char(1)         NULL
    )

        -- Need the date and time for the logged actions
    set @now = getdate()
    set @status = 0

    /*****************************************************************
     * Create the mpt_customers_old table if it doesn't already exist
     *****************************************************************/

        -- Create the mpt_customers_old table if it doesn't already exist
        -- (this should "never happen" since it should have been created by the
        --  mpt_transfer_customers procedure or a separate table setup script)
    if @status = 0
    begin
        if not exists (select 1 from sysobjects where name = 'mpt_customers_old') 
        begin

            print 'CREATE TABLE mpt_customers_old';
            
            CREATE TABLE mpt_customers_old
               (    cust_id         integer  NOT NULL
                  , change_type     char(1)  NOT NULL        -- 'N' (new) or 'D' (deleted)
                  , change_date     datetime NOT NULL
               );

            if @@error <> 0 
            begin
                set @status = -1;
                set @errmsg = 'SQL Error '+convert(varchar(10),@@error)
                              +' creating mpt_customers_old table';
            end

            if @status = 0
            begin
                print 'CREATE INDEX mpt_customers_old_ndx';
                
                CREATE INDEX mpt_customers_old_ndx
                    ON mpt_customers_old (cust_id ASC);
            
                if @@error <> 0 
                begin
                    set @status = -1;
                    set @errmsg = 'SQL Error '+convert(varchar(10),@@error)
                                  +' creating index on mpt_customers_old';
                end
            end
        end
    end

    /************************************************************
     * Clear the temporary data table
     ***********************************************************/
     
    if @status = 0
    begin
        truncate TABLE #tmp_mpt_transfer_data
    
        if @@error <> 0 
        begin
            set @status = -1
            set @errmsg = 'SQL Error '+convert(varchar(10),@@error)
                             +' truncating table tmp_mpt_transfer_data'
        end
    end

    /************************************************************
     * Gather customer data
     ***********************************************************/

    if @status = 0 
    begin
        print 'Gather customer data'
        
        insert into #tmp_mpt_transfer_data
            (cust_id, dp_id, title, initial,surname, classification,
             move_in_date, move_out_date, opt_in_ind)
        select c.cust_id
             , isnull(cam.dp_id,a.dp_id)
             , rd.trim(cust_title)
             , rd.trim(cust_initials)
             , cust_surname_company
             , (case when c.cust_business = 'Y' then 'B' else
                case when c.cust_rural_farmer = 'Y' then 'F' else
                case when c.cust_rural_resident = 'Y' then 'R' else ' ' 
                end end end)        as cust_class
             , cam.move_in_date
             , cam.move_out_date
             , isnull(c.cust_dir_listing_ind,'N')
          from rds_customer c
             , address a
             , customer_address_moves cam
         where c.master_cust_id is null
           and c.cust_surname_company != 'Dummy'
           and cam.cust_id = c.cust_id
           and cam.move_out_date is null
           and a.adr_id = cam.adr_id
           and a.dp_id is not null
         order by c.cust_id

        if @@error <> 0
        begin
            set @status = -1
            set @errmsg = 'SQL Error '+convert(varchar(10),@@error)
                          +' gathering customer data'
        end
    end

    /************************************************************
     * Write the results to a file
     ***********************************************************/

    DECLARE @object        int 
    DECLARE @hr            int  
    DECLARE @filehandle    int 
    DECLARE @src           varchar(255)
    DECLARE @desc          varchar(255)
    DECLARE @xout          int  
    
        -- Cursor to scan #tmp_mpt_transfer_data row-by-row
        -- to generate output file line-by-line
    declare c1 cursor for
        select cust_id, dp_id, title, initial, surname, 
               classification, move_in_date, move_out_date, opt_in_ind
          from #tmp_mpt_transfer_data
  
    if @status = 0 
    begin
        print 'Write the results to ' + @outfile

             -- create a Scripting Object for openning file
        EXEC @hr =   sp_OACreate 'Scripting.FileSystemObject', @object OUT   

        IF   @hr <> 0   
        BEGIN 
            EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     

            set @status = -1
            set @errmsg = 'create a Scripting Object failed: rc = '+convert(varchar(20),@hr)
                          + isnull(@desc,'')
        END   
    end

         -- create the output file
    if @status = 0 
    begin
        EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT, @outfile

        IF   @hr <> 0   
        BEGIN 
            EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     
        
            set @status = -1
            set @errmsg = 'Create a text file failed: rc = '+convert(varchar(20),@hr)
                          + isnull(@desc,'')
                          + '; File = ' + isnull(@outfile,'NULL')
        END
    end
    
        -- Loop through rows in #tmp_mpt_transfer_data
    if @status = 0 
    begin
             -- open cursor
        open c1
        set @xout = 0

        while @status = 0
        begin
            declare @o_cust_id        integer
            declare @o_dp_id          integer
            declare @o_title          char(10)
            declare @o_initial        char(30)
            declare @o_surname        char(45)
            declare @o_classification char(1)
            declare @o_move_in_date   datetime
            declare @o_move_out_date  datetime
            declare @o_opt_in_ind     char(1)

            declare @outstring        varchar(255)
        
            fetch next from c1
                into @O_cust_id, @O_dp_id, @O_title, @O_initial, @O_surname,
                     @O_classification, @O_move_in_date, @O_move_out_date, @O_opt_in_ind

            if @@fetch_status < 0 break

            set @outstring = isnull(convert(varchar(8),@o_cust_id),'') + ','
                             + isnull(convert(varchar(8),@o_dp_id),'') + ','
                             + isnull(rd.trim(@o_title),'')   + ','
                             + isnull(rd.trim(@o_initial),'') + ','
                             + isnull(rd.trim(@o_surname),'') + ','
                             + isnull(@o_classification,'')   + ','
                             + isnull(convert(varchar(10),@o_move_in_date,120),'')+','
                             + isnull(convert(varchar(10),@o_move_out_date,120),'')+','
                             + isnull(@o_opt_in_ind,'')
                             + char(10) + char(13)
        
                 -- write message to the file  
            EXEC @hr = sp_OAMethod @filehandle, 'Write', NULL, @outstring
   
            IF   @hr <> 0   
            BEGIN
                EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     

                set @status = -1
                set @errmsg = 'Write a text file failed: rc = '+convert(varchar(20),@hr)
                              + isnull(@desc,'')
            END   

            select @xout = @xout + 1
        end

        close c1
    
             --close the file  
        EXEC @hr = sp_OAMethod @filehandle, 'Close', NULL
    
        IF   @hr <> 0   
        BEGIN   
            EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT

            SET @status = -1
            SET @errmsg = 'Write or close a text file failed: rc = '+convert(varchar(20),@hr)
                          + isnull(@desc,'') 
        END
    end
     
    /************************************************************
     * Populate the mpt_customers_old table
     ***********************************************************/
     
    if @status = 0 
    begin
        TRUNCATE TABLE mpt_customers_old;

        if @@error <> 0
        begin
            set @status = -1;
            set @errmsg = 'SQL Error '+convert(varchar(10),@@error)
                               +' truncating mpt_customers_old';
        end
        
        if @status = 0 
        begin
            print 'Populate mpt_customers_old';
            
            insert into mpt_customers_old
                ( cust_id, change_type, change_date )
              select cust_id, 'N', @now
                from #tmp_mpt_transfer_data;

            if @@error <> 0
            begin
                set @status = -1;
                set @errmsg = 'SQL Error '+convert(varchar(10),@@error)
                                   +' populating mpt_customers_old';
            end
        end
    end
    
    /************************************************************
     * Done.  Return status
     ***********************************************************/

    if @status = 0 
        set @errmsg = 'Success - ' + convert(varchar(10),@xout) + ' records output'
    else
        set @errmsg = 'SQL Error - ' + @errmsg

    
        -- Return status
    select @status      as Status
         , @errmsg      as description

END
GO

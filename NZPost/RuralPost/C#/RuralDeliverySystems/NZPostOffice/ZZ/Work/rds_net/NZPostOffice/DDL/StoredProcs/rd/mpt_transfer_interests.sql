/****** Object:  StoredProcedure [rd].[mpt_transfer_interests]    Script Date: 08/05/2008 10:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rd].[mpt_transfer_interests]
/***********************************************************************
 * Description
 *    This routine extracts customer interest and occupation data 
 *    from the RDS database for the MPT repository data feed.
 *
 * Parameters
 *    @outfile     varchar(255)     Output filename
 *
 * Returns
 *    status       integer,
 *    description  varchar(100)
 *
 * Output file
 *    The procedure creates an output file containing a comma-separated 
 *    list (CSV file) of data. The columns in this file are:
 *          cust_id    integer      NOT NULL
 *          type       char(1)      NOT NULL
 *          code       integer      NOT NULL
 *
 *    NOTE:  The output filename is hardcoded into this procedure 
 *           at about line 67.  It must be set manually before 
 *           loading and running this procedure!
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
 * 10 Jun 2008  TJB  Removed opt in/out from selection criteria
 *  1 Jul 2008  TJB  Fixed bug with occupations type indicator
 *  9 Jul 2008  TJB  Added step to populate the mpt_interests_old table
 *                   and create it if it doesn't already exist.
 *                   Added Rural Delivery contracts only restriction
 *                      for customer selection.
 * 17 Jul 2008  TJB  Converted to SQL Server syntax
 ***********************************************************************/
AS     
BEGIN
    declare @status        integer;
    declare @interests     integer;
    declare @occupations   integer;
    declare @description   varchar(120);
    declare @today         datetime;
    declare @outfile       varchar(255)
    
    CREATE TABLE #tmp_mpt_transfer_interests
       (
	        cust_id        	integer NOT NULL
	      , type           	char(1) NOT NULL
	      , code           	integer NOT NULL
       );

    /*************************************************************
     *                        NOTE                               *
     * To change the output filename and/or location, change the *
     * literal assigned to the @outfile variable below, then     *
     * reload the procedure.                                     *
     *                                                           *
     *************************************************************/

    set @outfile = 'C:\rdsruntime\mpt_transfer_interests.csv'

       -- Need the date without the time
    set @today  = convert(datetime,convert(varchar(10),getdate(),120));
    set @status = 0;

    /************************************************************
     * Clear the data table
     ***********************************************************/
     
    truncate TABLE #tmp_mpt_transfer_interests;
    
    if @@error <> 0 
    begin
        set @status = -1;
        set @description = 'SQL Error '+convert(varchar(10),@@error)
                           +' truncating table tmp_mpt_transfer_interests';
    end;

    /************************************************************
     * Gather interest data
     ***********************************************************/

    if @status = 0 
    begin
        insert into #tmp_mpt_transfer_interests
            ( cust_id, type, code )
        select cust_id, 'I', interest_id 
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

        set @interests = isnull(@@rowcount,0);
        
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering interest data';
        end;
    end;

    /************************************************************
     * Gather occupation data
     ***********************************************************/

    if @status = 0 
    begin
        insert into #tmp_mpt_transfer_interests
            ( cust_id, type, code )
        select cust_id, 'O', occupation_id 
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

        set @occupations = isnull(@@rowcount,0);

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' gathering occupation data';
        end;
    end;

    /*************************************************************
     * Write the results to a file
     *************************************************************/

    DECLARE   @object       int 
    DECLARE   @hr           int  
    DECLARE   @filehandle   int 
    DECLARE   @src          varchar(255)
    DECLARE   @desc         varchar(255)
    DECLARE   @xout         int  

        -- Cursor to scan #tmp_mpt_transfer_interests row-by-row
        -- to generate output file line-by-line
    declare c1 cursor for
        select cust_id, type, code
          from #tmp_mpt_transfer_interests
  
         -- create a Scripting Object for openning file
    if @status = 0 
    begin
        EXEC @hr =   sp_OACreate 'Scripting.FileSystemObject', @object OUT   

        IF   @hr <> 0   
        BEGIN 
            EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     

            set @status = -1
            set @description = 'create a Scripting Object failed: rc = '+convert(varchar(20),@hr)
                               + isnull(@desc,'')
        END
    end

         -- create a file
    if @status = 0 
    begin
        EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT, @outfile

        IF   @hr <> 0   
        BEGIN 
            EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     
        
            set @status = -1
            set @description = 'Create a text file failed: rc = '+convert(varchar(20),@hr)
                               + isnull(@desc,'')
                               + '; File = ' + isnull(@outfile,'NULL')
        END
    end
    
        -- Loop through rows in #tmp_mpt_transfer_interests
    if @status = 0 
    begin
             -- open cursor
        open c1
        set @xout = 0

        while @status = 0
        begin
            declare @o_cust_id        integer
            declare @o_code           integer
            declare @o_type           char(1)
            declare @outstring        varchar(255)
        
            fetch next from c1
                into @O_cust_id, @O_type, @O_code

            if @@fetch_status < 0 break

            set @outstring = isnull(convert(varchar(8),@o_cust_id),'') + ','
                             + isnull(rd.trim(@o_type),'')   + ','
                             + isnull(convert(varchar(8),@o_code),'')
                             + char(10) + char(13)
        
                 -- write message to the file  
            EXEC @hr = sp_OAMethod @filehandle, 'Write', NULL, @outstring
   
            IF   @hr <> 0   
            BEGIN
                EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     

                set @status = -1
                set @description = 'Write a text file failed: rc = '+convert(varchar(20),@hr)
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
            SET @description = 'Write or close a text file failed: rc = '+convert(varchar(20),@hr)
                               + isnull(@desc,'') 
        END
    end
 

    /****************************************************************
     * Populate the mpt_interests_old table
     ****************************************************************/
        -- We do this to provide the initial state for the 
        -- mpt_interests_delta procedure.  We continue to use the
        -- temporary table so that the change_type and change_date 
        -- aren't included in this procedure's output file (UNLOAD
        -- TABLE unloads all columns to the output file).
        

        -- if it doesn't already exist, create it
    if @status = 0 
    begin
        if not exists (select 1 from sysobjects where name = 'mpt_interests_old' and type = 'U') 
        begin

            CREATE TABLE mpt_interests_old
               (    cust_id         integer     NOT NULL
                  , code            integer     NOT NULL
                  , type            varchar(1)  NOT NULL        -- 'O' (occupation) or 'I' (interest)
                  , change_type     varchar(1)  NOT NULL        -- 'N' (new) or 'D' (deleted)
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
        end
    end;

        -- Make sure it starts out empty
    if @status = 0 
    begin
        truncate table mpt_interests_old;

        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' truncating table mpt_interests_old';
        end;
    end;

        -- Populate it
    if @status = 0 
    begin
        insert into mpt_interests_old
             ( cust_id, code, type, change_type, change_date )
        select cust_id, code, type, 'N',         @today
          from #tmp_mpt_transfer_interests
         order by cust_id;
        
        if @@error <> 0 
        begin
            set @status = -1;
            set @description = 'SQL Error '+convert(varchar(10),@@error)
                               +' populating mpt_interests_old';
        end;
    end;

    /************************************************************
     * Done.  Return status
     ***********************************************************/

    if @status = 0 
        set @description = 'Success - '
                           + convert(varchar(8),@interests) + ' interests, and ' 
                           + convert(varchar(8),@occupations) + ' occupations found.';

        -- Return status
    select @status      as Status
         , @description as Description
END
GO

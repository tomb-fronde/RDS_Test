
CREATE procedure [rd].[f_rds_npad_modify_customer](
	@dpid int,
	@username char(20),
	@description char(120),
	@outfile char(120))
AS
/******************************************************************
 * Description
 *    This function generates a 'modify customer name' NPAD interface
 *    message (XML file).
 *    ==> Only checks that input DPID isn't null (or 0);
 *        assumes caller has passed the right values.
 *
 * Parameters
 *    dpid          Dpid of the customer whose name details are to be modified
 *    username      Name of user making change
 *    description   Description of message for XML file header
 *    outfile       Name of output XML file
 *
 * Returns
 *    0   Success
 *    1   Invalid dpid
 *   < 0  Error writing XML file
 * <sqlcode> SQL error (looking up customer details)
 *
 * System
 *    NPAD2 - NZ Post
 *
 * Author
 *    Tom Britton, Synergy International
 *
 * Created on
 *    December 2005
 *
 * Modification history
 * 12 Jan 2006  TJB  Added schema to NZPost definition, 
 *                   and date format to XML standards
 * 21 Mar 2006  TJB  Add output filename to npad_msg_log.description
 * 20 June 2006 TJB  Added check of xp_write_file & record result in
 *                   npad_msg_log and improve error messages in npad_msg_log.
 * 14 Feb 2008  TJB  Added rtrim() to input strings and made internal 
 *                    char()'s varchar() to trim trailing spaces
 *    2008     Metex Translated to SQL Server's SQL
 * 27 Jan 2009  TJB  Added error checking when writing XML file
 * 25 Feb 2009  TJB  Changed default <null> value for initials and title
 *                   to <empty string>
 ******************************************************************/
BEGIN
  declare @surname    varchar(45),
          @initials   varchar(30),
          @title      varchar(10),
          @todaysDate varchar(10),
          @todaysTime varchar(8),
          @s_dpid     varchar(8),
          @outstring  varchar(2000), -- Max 32K 
          @schema     varchar(64),
          @crlf       char(2),
          @status     int,
          @now        datetime,
          @rc         int,
          @status_msg varchar(120),
          @filename   varchar(120)

  select @status=0
  select @schema='http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
  select @rc=0
  select @status_msg=''
  select @filename = ltrim(rtrim(@outfile))

  -- Need today''s date/time for the XML file
  select @now = getdate()

  -- Need the DPID as a string for the XML file
  -- (or for error message)
  select @s_dpid = convert(varchar(8),@dpid)

  -- Validate the DPID
  if @dpid is null or @dpid <= 0
  begin
      select @status = 1
      select @status_msg = 'Invalid DPID: '+isnull(@s_dpid,'null')
  end
  else
  begin
      -- Look up the customer details
      select @surname = cust_surname_company
            ,@initials = cust_initials
            ,@title = cust_title 
        from customer_address_moves as cam
            ,rds_customer as c 
       where cam.dp_id = @dpid 
         and cam.move_out_date is null 
         and c.cust_id = cam.cust_id

      if @@error <> 0
      begin
          select @status=@@error
          select @status_msg = ERROR_MESSAGE()
      end
  end

  set @initials = isnull(@initials,'')
  set @title    = isnull(@title,'')
  if @surname is null
  begin
     select @surname = 'null'
			-- This is a hack.
			-- @@error isn't being set when no records are found.
			-- If the surname is null, assume the record wasn't found
			-- (a surname is a required value, so if its missing there
			--  shouldn't have been a record.  If there actually is a
			--  record with a surname of <null>, that is a different error)
			-- TJB  14-Feb-2008
     select @status = -1
     select @status_msg = 'DPID '+@s_dpid+' not found'
  end

      -- Prepare the XML file contents
  if @status = 0
  begin
      -- Format today''s date/time for the XML file
      select @todaysDate=convert(varchar(10),@now,105) -- yyyy-mm-dd
      select @todaysTime=convert(varchar(8),@now,108) -- HH:mm:ss
      select @crlf= char(13)+ char(10)

      select @outstring='<?xml version="1.0"?>'+@crlf
                     +'<NZPost xmlns="'+@schema+'">'+@crlf
                     +'<Header>'+@crlf
                     +'  <ChannelType>RDSNPAD</ChannelType>'+@crlf+
                     +'  <Version>0.1</Version>'+@crlf
                     +'  <Description>'+rtrim(@description)+'</Description>'+@crlf
                     +'  <Priority>1</Priority>'+@crlf
                     +'  <ProduceDate>'+@todaysDate+'T'+@todaysTime+'</ProduceDate>'+@crlf
                     +'</Header>'+@crlf
                     +'<RDSNPAD>'+@crlf
                     +'  <CustomerModify>'+@crlf
                     +'    <DPID>'+@s_dpid+'</DPID>'+@crlf
                     +'    <Surname>'+@surname+'</Surname>'+@crlf
                     +'    <Initials>'+@initials+'</Initials>'+@crlf
                     +'    <Title>'+@title+'</Title>'+@crlf
                     +'    <UserID>'+rtrim(@username)+'</UserID>'+@crlf
                     +'  </CustomerModify>'+@crlf
                     +'</RDSNPAD>'+@crlf
                     +'</NZPost>'

      select @status_msg = @title+' '+@initials+' '+@surname+' File = '+@filename 
      
      -- Write the file
      DECLARE   @object   int --create a Scripting Object for openning file
      DECLARE   @hr   int  
      DECLARE   @filehandle   int 

      set @hr = 0

      if @status = 0 
      begin
         EXEC @hr = sp_OACreate 'Scripting.FileSystemObject', @object OUT   

         if @hr != 0 
         begin
            set @status_msg = 'ERROR: sp_OACreate RC = '+convert(varchar,@hr)
            set @status = @hr
         end
      end

      if @status = 0 
      begin
         EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT , @filename   --create a file

         if @hr != 0 
         begin
            set @status_msg = 'ERROR: sp_OAMethod CreateTextFile, RC = '+convert(varchar,@hr)
            set @status = @hr
         end
      end
 
      if @status = 0 
      begin
         EXEC @hr = sp_OAMethod @filehandle, 'Write', NULL, @outstring    --write message to the file

         if @hr != 0 
         begin
            set @status_msg = 'ERROR: sp_OAMethod Write, RC = '+convert(varchar,@hr)
            set @status = @hr
         end
      end
 
      if @status = 0 
      begin
         EXEC @hr = sp_OAMethod @filehandle, 'Close', NULL     --close the file

         if @hr != 0 
         begin
            set @status_msg = 'ERROR: sp_OAMethod Close, RC = '+convert(varchar,@hr)
            set @status = @hr
         end
      end
    end

  /**************************
  *  Exit
  **************************/
  -- Log the message
  insert into rd.NPAD_msg_log
		(msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values
		(@now, rtrim(@username), 'modify customer', @dpid, @status, 
                     @status_msg  + ', Outfile = ' + @filename )

   return @status
END
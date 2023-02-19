
CREATE procedure [rd].[f_rds_npad_transfer_customer](
	@old_dpid int,
	@new_dpid int,
	@username char(20),
	@description char(120),
	@outfile char(120))
as
/******************************************************************
 * Description
 *    This function generates a 'transfer customer' NPAD interface
 *    message (an XML file).
 *    ==> Only checks that input arguments aren''t null (or 0);
 *        assumes caller has passed the right DPIDs.
 *
 * Parameters
 *    old_dpid      Dpid of the customer who is transferring
 *    new_dpid      Dpid of the address the customer is transferring to
 *    username      Name of user making change
 *    description   Description of message for XML file header
 *    outfile       Name of output XML file
 *
 * Returns
 *    0   Success
 *    1   Invalid old dpid
 *    2   Invalid new dpid
 *   < 0  Error writing XML file
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
 * 12 Jan 2006  TJB  Added schema to NZPost definition, and date 
 *                   format to XML standards.
 * 16 Mar 2006  TJB  Changed "Old_DPID" to "OldDPID" and "New_DPID" 
 *                   to "NewDPID" in XML message.
 * 21 Mar 2006  TJB  Fixed bug in writing to npad message log
 * 20 June 2006 TJB  Added check of xp_write_file & record result in
 *                   npad_msg_log and improve error messages in npad_msg_log.
 * 14 Feb 2008  TJB  Added rtrim() to input strings and made internal 
 *                    char()'s varchar() to trim trailing spaces
 *    2008     Metex Translated to SQL Server's SQL
 * 26 Jan 2009  TJB  Added error checking when writing XML file
 ******************************************************************/
begin
  declare @todaysDate varchar(10),
          @todaysTime varchar(8),
          @s_old_dpid varchar(8),
          @s_new_dpid varchar(8),
          @outstring  varchar(2000), -- Max 32K
          @schema     varchar(64),
          @crlf       char(2),
          @status     integer,
          @now        datetime,
          @rc         integer,
          @status_msg varchar(120),
          @filename   varchar(120)

  select @status=0
  select @schema='http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
  select @rc=0
  select @status_msg=''
  select @crlf= char(13)+ char(10)
  select @filename = ltrim(rtrim(@outfile))

  -- Need the date and time for the XML file
  select @now=getdate()

  -- Convert the DPIDs to strings for the output file
  -- (or for the error message if the values are invalid)
  select @s_old_dpid=convert(varchar(8),@old_dpid)
  select @s_new_dpid=convert(varchar(8),@new_dpid)

  set @s_old_dpid = isnull(@s_old_dpid,'null')
  set @s_new_dpid = isnull(@s_new_dpid,'null')

  -- Check the validity of the old DPID
  if @old_dpid is null or @old_dpid <= 0
  begin
     select @status=1
     select @status_msg='Invalid old DPID: '+@s_old_dpid
  end
  else
  if @new_dpid is null or @new_dpid <= 0
  begin
     -- Check the validity of the new DPID
     select @status=2
     select @status_msg='Invalid new DPID: '+@s_new_dpid
  end
  else
  begin
     -- Format the date and time for XML file elements
     select @todaysDate = convert(varchar(10),@now,105)  -- yyyy-mm-dd
     select @todaysTime = convert(varchar(8),@now,108)   -- HH:mm:ss

     -- Prepare XML file contents
     select @outstring='<?xml version="1.0"?>'+@crlf
                        +'<NZPost xmlns="'+@schema+'">'+@crlf
                        +'<Header>'+@crlf
                        +'  <ChannelType>RDSNPAD</ChannelType>'+@crlf
                        +'  <Version>0.1</Version>'+@crlf
                        +'  <Description>'+rtrim(@description)+'</Description>'+@crlf
                        +'  <Priority>1</Priority>'+@crlf
                        +'  <ProduceDate>'+@todaysDate+'T'+@todaysTime+'</ProduceDate>'+@crlf
                        +'</Header>'+@crlf
                        +'<RDSNPAD>'+@crlf
                        +'  <MasterRecipientUpdate>'+@crlf
                        +'    <OldDPID>'+@s_old_dpid+'</OldDPID>'+@crlf
                        +'    <NewDPID>'+@s_new_dpid+'</NewDPID>'+@crlf
                        +'    <UserID>'+rtrim(@username)+'</UserID>'+@crlf
                        +'  </MasterRecipientUpdate>'+@crlf
                        +'</RDSNPAD>'+@crlf
                        +'</NZPost>'

     set @status_msg = 'New DPID = '+@s_new_dpid+'  Outfile = '+@filename
      
     -- Create the XML file
     DECLARE   @object     int
     DECLARE   @hr         int  
     DECLARE   @filehandle int 

     set @hr = 0

     if @status = 0 
     begin
        EXEC   @hr   =   sp_OACreate   'Scripting.FileSystemObject',   @object   OUT   
        if @hr != 0 
        begin
           set @status_msg = 'ERROR: sp_OACreate RC = '+convert(varchar,@hr)
           set @status = @hr
        end
     end
     if @status = 0 
     begin
        EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT , @outfile   --create a file
        if @hr != 0 
        begin
           set @status_msg = 'ERROR: sp_OAMethod CreateTextFile, RC = '+convert(varchar,@hr)
           set @status = @hr
        end
     end
     if @status = 0 
     begin
        EXEC   @hr   =   sp_OAMethod   @filehandle,   'Write',NULL,   @outstring    --write message to the file
        if @hr != 0 
        begin
           set @status_msg = 'ERROR: sp_OAMethod Write, RC = '+convert(varchar,@hr)
           set @status = @hr
        end
     end
     if @status = 0 
     begin
        EXEC   @hr   =   sp_OAMethod   @filehandle,   'Close',NULL     --close the file
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
		(@now, rtrim(@username), 'transfer customer', @old_dpid, @status, 
                     @status_msg  + ', Outfile = ' + @filename )

   return @status
end
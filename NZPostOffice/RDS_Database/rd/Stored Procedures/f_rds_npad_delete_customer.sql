
CREATE procedure [rd].[f_rds_npad_delete_customer](
	@dpid int,
	@username char(20),
	@description char(120),
	@outfile char(120) )
AS
/******************************************************************
 * Description
 *    This function generates a 'delete customer' NPAD interface
 *    message (XML file).
 *    ==> Only checks that input DPID isn't null (or 0);
 *        assumes caller has passed the right values.
 *
 * Parameters
 *    dpid          Dpid of the customer to be deleted
 *    description   Description of message for XML file header
 *    outfile       Name of output XML file
 *
 * Returns
 *    0   Success
 *    1   Invalid dpid
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
 * 12 Jan 2006  TJB  Added schema to NZPost definition, 
 *                   and date format to XML standards
 * 14 Feb 2008  TJB  Added rtrim() to input strings and made internal 
 *                    char()'s varchar() to trim trailing spaces
 *    2008     Metex Translated to SQL Server's SQL
 * 27-Jan-2009  TJB  Fixed error reporting to log file creation errors
 ******************************************************************/
BEGIN
   declare @todaysDate varchar(10),
           @todaysTime varchar(8),
           @s_dpid varchar(8),
           @outstring varchar(2000), -- Max 32K
           @schema varchar(64),
           @crlf char(2),
           @status int,
           @now datetime,
           @rc int,
           @errmsg varchar(40),
           @filename varchar(120),
           @status_msg VARCHAR(120)


   set @status=0
   set @schema='http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
   set @rc=0
   set @errmsg=''
   set @filename = ltrim(rtrim(@outfile))

   -- Need the date and time for the XML file
   select @now=getdate()

   -- Convert dpid to string for the XML output file
   -- (or error message)
   select @s_dpid=convert(varchar(8),@dpid)

   -- Check the DPID for validity
   if @dpid is null or @dpid <= 0
   begin
       select @status=1
       select @status_msg='Invalid DPID: '+isnull(@s_dpid,'null')
   end
   else
   begin
       -- Format the date and time for the XML file
       set @todaysDate=convert(varchar(10),@now,105)  -- yyyy-mm-dd
       set @todaysTime=convert(varchar(8),@now,108)   -- HH:mm:ss
       set @crlf=char(13)+char(10)

       -- Prepare the XML file contents
       set @outstring = '<?xml version="1.0"?>'+@crlf
                         +'<NZPost xmlns="'+@schema+'">'+@crlf
                         +'<Header>'+@crlf
                         +'  <ChannelType>RDSNPAD</ChannelType>'+@crlf
 	                    +'  <Version>0.1</Version>'+@crlf
	                    +'  <Description>'+rtrim(@description)+'</Description>'+@crlf
	                    +'  <Priority>1</Priority>'+@crlf
	                    +'  <ProduceDate>'+@todaysDate+'T'+@todaysTime+'</ProduceDate>'+@crlf
	                    +'</Header>'+@crlf
	                    +'<RDSNPAD>'+@crlf
	                    +'  <CustomerDelete>'+@crlf
	                    +'    <DPID>'+@s_dpid+'</DPID>'+@crlf
	                    +'    <UserID>'+rtrim(@username)+'</UserID>'+@crlf
	                    +'  </CustomerDelete>'+@crlf
	                    +'</RDSNPAD>'+@crlf
	                    +'</NZPost>'+@crlf

       set @status_msg = 'Succeeded'
       
       -- Write out the file
       DECLARE   @object   int
       DECLARE   @hr       int  
       DECLARE   @filehandle   int 

       set @hr = 0
       
       -- Create a Scripting Object for openning file
       if @status = 0 
       begin
           EXEC   @hr = sp_OACreate   'Scripting.FileSystemObject',   @object   OUT   
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
                set @status_msg = 'ERROR: sp_OAMethod CreateTextFile RC = '+convert(varchar,@hr)
                set @status = @hr
            end
        end
        if @status = 0 
        begin
            EXEC   @hr   =   sp_OAMethod   @filehandle,   'Write',NULL,   @outstring    --write message to the file
            if @hr != 0 
            begin
                set @status_msg = 'ERROR: sp_OAMethod Write RC = '+convert(varchar,@hr)
                set @status = @hr
            end
        end
        if @status = 0 
        begin
            EXEC   @hr   =   sp_OAMethod   @filehandle,   'Close',NULL     --close the file
            if @hr != 0 
            begin
                set @status_msg = 'ERROR: sp_OAMethod Close RC = '+convert(varchar,@hr)
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
 		(@now, @username, 'delete customer', @dpid, @status,
                     @status_msg  + ', Outfile = ' + @filename )

   return @status
END
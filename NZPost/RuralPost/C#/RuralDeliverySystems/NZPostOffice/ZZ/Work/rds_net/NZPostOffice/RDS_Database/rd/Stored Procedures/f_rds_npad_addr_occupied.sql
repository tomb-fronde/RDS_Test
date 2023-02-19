
CREATE procedure [rd].[f_rds_npad_addr_occupied] 
	@dpid INT ,
	@occupied CHAR(5) ,
	@username CHAR(20) ,
	@description CHAR(120) ,
	@outfile CHAR(120) ,
	@SWP_Re INT OUTPUT 
AS
/******************************************************************
 * Description
 *    This function generates an 'address occupied status' NPAD interface
 *    message (an XML file).
 *
 *    ==> Only checks that input arguments aren't null (or 0);
 *        assumes caller has passed the right DPIDs.
 *
 * Parameters
 *    dpid          Dpid of the address
 *    occupied      'true' or 'false' (is occupied or not)
 *    username      Name of user making change
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
 * Created
 *    7 May 2007
 *
 * Modification history
 * 14 May 2007  TJB  Updated format to match ECN's specifications
 * 14 Feb 2008  TJB  Added rtrim() to input strings and made internal 
 *                    char()'s varchar() to trim trailing spaces
 *    2008     Metex Translated to SQL Server's SQL
 * 26 Jan 2009  TJB  Added error checking when writing XML file
 * 10 Feb 2009  TJB  Changed <in></in> to  <int></int> in XML output
 *                   Changed to use 126 format for xml date (produceDate)
 * 19 Feb 2009  TJB  Changed namespace (@schema) in output XML file

 ******************************************************************/
BEGIN
   declare @produceDate VARCHAR(32)
   declare @s_dpid VARCHAR(8)
   declare @outstring VARCHAR(2000)
   declare @schema VARCHAR(64)
   declare @crlf CHAR(2)
   declare @status INT
   declare @now DATETIME
   declare @filename VARCHAR(120)
   declare @status_msg VARCHAR(120)

  declare @file_path varchar(200), @file_name varchar(200)
  declare @i int, @j int

   set @status = 0
   -- set @schema = 'http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
   set @schema = 'http://schemas.nzpost.co.nz/NPAD/v2/DeliveryStatusUpdateNPAD'
   set @filename = ltrim(rtrim(@outfile))

   -- TJB  15-Oct-2009: Add 'DSU' to the output file's name
   set @j = 0
   set @i = charindex('\',@filename)
   while @i > 0
   begin
      set @j = @i
      set @i = charindex('\',@filename,(@j + 1))
   end
   set @file_path = left(@filename, @j)
   set @file_name = right(@filename, (len(@filename) - @j))
   set @filename = @file_path + 'DSU' + @file_name

   -- Need the date and time for the XML file
   set @now = GetDate()
   
   -- Convert dpid to string for the XML output file
   -- (or error message)
   select @s_dpid=convert(varchar(8),@dpid)

   -- Check the validity of the old DPID
   if @dpid is null or @dpid <= 0
   begin
      set @status = 1
      set @status_msg = 'Invalid DPID:  '+isnull(@s_dpid,'null')
   end
   else
   begin
          -- Format the date and time for XML file elements
      set @produceDate = convert(VARCHAR,@now,126)     -- XML format: yyyy-mm-ddThh:mm:ss.mmmm
      set @crlf = char(13)+char(10)
      
          -- Prepare XML file contents
      set @outstring = '<?xml version="1.0"?>'+@crlf
                        +'<NZPost xmlns="'+@schema+'">'+@crlf
                        +'<Header>'+@crlf
                        +'  <ChannelType>RDSNPAD</ChannelType>'+@crlf
	                    +'  <Version>0.1</Version>'+@crlf
	                    +'  <Description>'+rtrim(@description)+'</Description>'+@crlf
	                    +'  <Priority>1</Priority>'+@crlf
	                    +'  <ProduceDate>'+@produceDate+'</ProduceDate>'+@crlf
	                    +'</Header>'+@crlf
	                    +'<NPAD>'+@crlf
	                    +'  <DeliveryStatusUpdate>'+@crlf
	                    +'    <DPIDs>'+@crlf
	                    +'      <int>'+@s_dpid+'</int>'+@crlf
	                    +'    </DPIDs>'+@crlf
	                    +'    <DeliveredTo>'+rtrim(@occupied)+'</DeliveredTo>'+@crlf
	                    +'    <UserID>'+rtrim(@username)+'</UserID>'+@crlf
	                    +'  </DeliveryStatusUpdate>'+@crlf
	                    +'</NPAD>'+@crlf
	                    +'</NZPost>'+@crlf

        set @status_msg = 'Occupied flag = '+rtrim(@occupied)

        -- Create the XML file
            --! EXECUTE xp_write_file @outfile ,@outstring
            -- Write a file

        DECLARE   @object   int --create a Scripting Object for openning file
        DECLARE   @hr       int  
        DECLARE   @filehandle   int 

        set @hr = 0

        if @status = 0 
        begin
            EXEC   @hr =   sp_OACreate   'Scripting.FileSystemObject',   @object   OUT   
            if @hr != 0 
            begin
                set @status_msg = 'ERROR: sp_OACreate RC = '+convert(varchar,@hr)
                set @status = @hr
            end
        end
        if @status = 0 
        begin
            EXEC   @hr   =   sp_OAMethod   @object, 'CreateTextFile', @filehandle OUTPUT , @filename   --create a file
            if @hr != 0 
            begin
                set @status_msg = 'ERROR: sp_OAMethod CreateTextFile, RC = '+convert(varchar,@hr)
                set @status = @hr
            end
        end
        if @status = 0 
        begin
            EXEC   @hr =   sp_OAMethod   @filehandle,   'Write',  NULL,   @outstring    --write message to the file
            if @hr != 0 
            begin
                set @status_msg = 'ERROR: sp_OAMethod Write, RC = '+convert(varchar,@hr)
                set @status = @hr
            end
        end
        if @status = 0 
        begin
            EXEC   @hr =   sp_OAMethod   @filehandle,   'Close',  NULL                  --close the file
            if @hr != 0 
            begin
                set @status_msg = 'ERROR: sp_OAMethod Close. RC = '+convert(varchar,@hr)
                set @status = @hr
            end
        end
   end

   /**************************
   *  Exit
   **************************/
   -- set @status_msg = 'Occupied flag = '+rtrim(@occupied)
   insert into rd.NPAD_msg_log
		(msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
   values
		(@now, rtrim(@username), 'address occupied(v2)', @dpid, @status, 
                     @status_msg  +', Description = '+ltrim(rtrim(@description)) + ', Outfile = ' + @filename )

   set 	@SWP_Re = @status
   return @status
END
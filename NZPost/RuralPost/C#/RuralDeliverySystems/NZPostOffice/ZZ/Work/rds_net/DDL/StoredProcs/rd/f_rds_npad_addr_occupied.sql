/****** Object:  StoredProcedure [rd].[f_rds_npad_addr_occupied]    Script Date: 08/05/2008 10:16:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[f_rds_npad_addr_occupied] 
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
******************************************************************/
begin
   declare @todaysDate VARCHAR(10)
   declare @todaysTime VARCHAR(8) -- Max 32K
   declare @s_dpid VARCHAR(8)
   declare @outstring VARCHAR(2000)
   declare @schema VARCHAR(64)
   declare @crlf CHAR(2)
   declare @status INT
   declare @now DATETIME
   declare @filename VARCHAR(120)

   set @status = 0
   set @schema = 'http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
   set @filename = ltrim(rtrim(@outfile))

  -- Need the date and time for the XML file
   set @now = GetDate()
  -- Check the validity of the old DPID
   if @dpid is null or @dpid <= 0
   begin
      set @status = 1
   end
   else
   begin
    -- Convert the DPID to a string for the output file
      set @s_dpid = convert(VARCHAR(8),@dpid)
    -- Format the date and time for XML file elements
      set @todaysDate = convert(VARCHAR(10),@now,103) -- yyyy-mm-dd
      set @todaysTime = convert(VARCHAR(8),@now,108) -- HH:mm:ss
      set @crlf = char(13)+char(10)
    -- Prepare XML file contents
      set @outstring = '<?xml version="1.0"?>'+@crlf
                        +'<NZPost xmlns="'+@schema+'">'+@crlf
                        +'<Header>'+@crlf
                        +'  <ChannelType>RDSNPAD</ChannelType>'+@crlf
	                    +'  <Version>0.1</Version>'+@crlf
	                    +'  <Description>'+rtrim(@description)+'</Description>'+@crlf
	                    +'  <Priority>1</Priority>'+@crlf
	                    +'  <ProduceDate>'+@todaysDate+'T'+@todaysTime+'</ProduceDate>'+@crlf
	                    +'</Header>'+@crlf
	                    +'<NPAD>'+@crlf
	                    +'  <DeliveryStatusUpdate>'+@crlf
	                    +'    <DPIDs>'+@crlf
	                    +'      <in>'+@s_dpid+'</in>'+@crlf
	                    +'    </DPIDs>'+@crlf
	                    +'    <DeliveredTo>'+rtrim(@occupied)+'</DeliveredTo>'+@crlf
	                    +'    <UserID>'+rtrim(@username)+'</UserID>'+@crlf
	                    +'  </DeliveryStatusUpdate>'+@crlf
	                    +'</NPAD>'+@crlf
	                    +'</NZPost>'+@crlf
    -- Create the XML file
      --! EXECUTE xp_write_file @outfile ,@outstring
      -- Write a file

		DECLARE   @object   int --create a Scripting Object for openning file
		DECLARE   @hr   int  
		DECLARE   @filehandle   int 
		DECLARE   @src   varchar(255),   @desc   varchar(255)   

		EXEC   @hr   =   sp_OACreate   'Scripting.FileSystemObject',   @object   OUT   

		EXEC   @hr   =   sp_OAMethod   @object, 'CreateTextFile', @filehandle OUTPUT , @filename   --create a file
		 
		EXEC   @hr   =   sp_OAMethod   @filehandle,   'Write',  NULL,   @outstring    --write message to the file
		 
		EXEC   @hr   =   sp_OAMethod   @filehandle,   'Close',  NULL                  --close the file
   end
  /**************************
  *  Exit
  **************************/
  -- Log the message
   insert into rd.NPAD_msg_log
		(msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
   values
		(@now, rtrim(@username),'address occupied',@dpid,@status,'Occupied flag = '+rtrim(@occupied))
   set @SWP_Re = @status
end
GO

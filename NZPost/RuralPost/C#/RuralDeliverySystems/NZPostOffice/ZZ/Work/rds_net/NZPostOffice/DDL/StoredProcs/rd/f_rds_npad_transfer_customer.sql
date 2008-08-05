/****** Object:  StoredProcedure [rd].[f_rds_npad_transfer_customer]    Script Date: 08/05/2008 10:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[f_rds_npad_transfer_customer](
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
* Parameters
*    old_dpid      Dpid of the customer who is transferring
*    new_dpid      Dpid of the address the customer is transferring to
*    username      Name of user making change
*    description   Description of message for XML file header
*    outfile       Name of output XML file
* Returns
*    0   Success
*    1   Invalid old dpid
*    2   Invalid new dpid
* System
*    NPAD2 - NZ Post
* Author
*    Tom Britton, Synergy International
* Created on
*    December 2005
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
          @errmsg     varchar(40),
          @filename   varchar(120)

  select @status=0
  select @schema='http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
  select @rc=0
  select @errmsg=''
  select @crlf= char(13)+ char(10)
  select @filename = ltrim(rtrim(@outfile))

  -- Need the date and time for the XML file
  select @now=getdate()

  -- Convert the DPIDs to strings for the output file
  -- (or for the error message if the values are invalid)
  select @s_old_dpid=convert(varchar(8),@old_dpid)
  select @s_new_dpid=convert(varchar(8),@new_dpid)
  if @old_dpid is null
    select @s_old_dpid='null'
  if @new_dpid is null
    select @s_new_dpid='null'

  -- Check the validity of the old DPID
  if @old_dpid is null or @old_dpid <= 0
    begin
      select @status=1
      select @errmsg='Invalid old DPID: '+@s_old_dpid
    end
  else
  if @new_dpid is null or @new_dpid <= 0
    begin
      -- Check the validity of the new DPID
      select @status=2
      select @errmsg='Invalid new DPID: '+@s_new_dpid
    end
  else
    begin
      -- Format the date and time for XML file elements
      select @todaysDate=convert(varchar(10),@now,105) -- yyyy-mm-dd
      select @todaysTime=convert(varchar(8),@now,108) -- HH:mm:ss

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

      DECLARE   @object   int --create a Scripting Object for openning file
      DECLARE   @hr   int  
      DECLARE   @filehandle   int 
      DECLARE   @src   varchar(255),   @desc   varchar(255)   

      EXEC   @hr   =   sp_OACreate   'Scripting.FileSystemObject',   @object   OUT   
        IF   @hr   <>   0   
        BEGIN   
            EXEC   sp_OAGetErrorInfo   @object,   @src   OUT,   @desc   OUT     
              --SELECT   hr=convert(varbinary(4),@hr),   Source=@src,   Description=@desc
      		select @errmsg='create a Scripting Object failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
        END   

      EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT , @outfile   --create a file
       IF   @hr   <>   0   
        BEGIN   
            EXEC   sp_OAGetErrorInfo   @object,   @src   OUT,   @desc   OUT     
      		select @errmsg='Create a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
        END   
 
      EXEC   @hr   =   sp_OAMethod   @filehandle,   'Write',NULL,   @outstring    --write message to the file
        IF   @hr   <>   0   
        BEGIN   
            EXEC   sp_OAGetErrorInfo   @object,   @src   OUT,   @desc   OUT     
      		select @errmsg='Write a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
        END   
 
      EXEC   @hr   =   sp_OAMethod   @filehandle,   'Close',NULL     --close the file
        IF   @hr   <>   0   
        BEGIN   
            EXEC   sp_OAGetErrorInfo   @object,   @src   OUT,   @desc   OUT     
      		select @errmsg='Write close a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
            select @status=-1
        END
        ELSE
           begin
              select @errmsg='New DPID = '+@s_new_dpid+'  Outfile = '+@filename
           end

      -- Create the XML file
	  /*!
      execute @rc = xp_write_file @outfile,@outstring
      if @rc = 0
        -- If successful, "errmsg" contains details of the message
        select @errmsg='New DPID = '+@s_new_dpid+'  Outfile = '+@outfile
      else
        begin
          -- If not successful, "errmsg" contains the error code and output filename
          select @status=-1
          select @errmsg='xp_write_file failed: rc = '+convert(char(4),@rc)+'; File = '+@outfile
        end
	   */
    end

  /**************************
  *  Exit
  **************************/
  -- Log the message
  insert into NPAD_msg_log
		(msg_date, msg_username, msg_type, msg_dpid, msg_status, msg_description) 
  values
		(@now, rtrim(@username), 'transfer customer', @s_old_dpid, @status, @errmsg)
  return @status
end
GO

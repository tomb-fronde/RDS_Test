/****** Object:  StoredProcedure [rd].[f_rds_npad_delete_customer]    Script Date: 08/05/2008 10:16:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[f_rds_npad_delete_customer](
	@dpid int,
	@username char(20),
	@description char(120),
	@outfile char(120) )
as
/******************************************************************
 * Description
 *    This function generates a 'delete customer' NPAD interface
 *    message (XML file).
 *    ==> Only checks that input DPID isn't null (or 0);
 *        assumes caller has passed the right values.
 * Parameters
 *    dpid          Dpid of the customer to be deleted
 *    description   Description of message for XML file header
 *    outfile       Name of output XML file
 * Returns
 *    0   Success
 *    1   Invalid dpid
 * System
 *    NPAD2 - NZ Post
 * Author
 *    Tom Britton, Synergy International
 * Created on
 *    December 2005
 * Modification history
 * 12 Jan 2006  TJB  Added schema to NZPost definition, 
 *                   and date format to XML standards
* 14 Feb 2008  TJB  Added rtrim() to input strings and made internal 
*                    char()'s varchar() to trim trailing spaces
 ******************************************************************/
begin
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
          @filename varchar(120)

  set @status=0
  set @schema='http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
  set @rc=0
  set @errmsg=''
  set @filename = ltrim(rtrim(@outfile))

  -- Need the date and time for the XML file
  select @now=getdate()
  -- Convert to string for the XML output file
  -- (or error message)
  select @s_dpid=convert(varchar(8),@dpid)
  if @dpid is null
    select @s_dpid='null'
  -- Check the DPID for validity
  if @dpid is null or @dpid <= 0
    begin
      select @status=1
      select @errmsg='Invalid DPID: '+@s_dpid
    end
  else
    begin
      -- Format the date and time for the XML file
      set @todaysDate=convert(varchar(10),@now,105) -- yyyy-mm-dd
      set @todaysTime=convert(varchar(8),@now,108) -- HH:mm:ss
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

      EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT , @filename   --create a file
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
		      select @errmsg='Write or close a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
              select @status=-1
        END
        ELSE
        BEGIN   
              select @errmsg='succeeded'
        END

      -- Create the file
	  /*!
      execute @rc = xp_write_file @outfile,@outstring
      if @rc = 0
        -- If successful, "errmsg" says so (the details are in other the columns)
        select @errmsg='succeeded'
      else
        begin
          -- If not successful, "errmsg" contains the error code and output filename
          select @status=-1
          select @errmsg='xp_write_file failed: rc = '+convert(char(4),@rc)+'; File = '+@outfile
        end
	   */
    end

  -- Log the message
  insert into NPAD_msg_log
		(msg_date,msg_username,msg_type,msg_dpid,msg_status,msg_description) 
  values
		(@now,@username,'delete customer',@dpid,@status,@errmsg)
  return @status
end
GO

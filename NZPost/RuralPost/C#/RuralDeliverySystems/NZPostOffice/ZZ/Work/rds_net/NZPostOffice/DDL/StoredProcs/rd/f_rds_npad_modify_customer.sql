/****** Object:  StoredProcedure [rd].[f_rds_npad_modify_customer]    Script Date: 08/05/2008 10:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [rd].[f_rds_npad_modify_customer](
	@dpid int,
	@username char(20),
	@description char(120),
	@outfile char(120))
as
/******************************************************************
 * Description
 *    This function generates a 'modify customer name' NPAD interface
 *    message (XML file).
 *    ==> Only checks that input DPID isn't null (or 0);
 *        assumes caller has passed the right values.
 * Parameters
 *    dpid          Dpid of the customer whose name details are to be modified
 *    username      Name of user making change
 *    description   Description of message for XML file header
 *    outfile       Name of output XML file
 * Returns
 *    0   Success
 *    1   Invalid dpid
 * <sqlcode> SQL error (looking up customer details)
 * System
 *    NPAD2 - NZ Post
 * Author
 *    Tom Britton, Synergy International
 * Created on
 *    December 2005
 * Modification history
 * 12 Jan 2006  TJB  Added schema to NZPost definition, 
 *                   and date format to XML standards
 * 21 Mar 2006  TJB  Add output filename to npad_msg_log.description
 * 20 June 2006 TJB  Added check of xp_write_file & record result in
 *                   npad_msg_log and improve error messages in npad_msg_log.
 * 14 Feb 2008  TJB  Added rtrim() to input strings and made internal 
 *                    char()'s varchar() to trim trailing spaces
 ******************************************************************/
begin
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
          @errmsg     varchar(120),
          @filename   varchar(120)

  select @status=0
  select @schema='http://schemas.nzpost.co.nz/NPAD/v2/RDSNPAD'
  select @rc=0
  select @errmsg=''
  select @filename = ltrim(rtrim(@outfile))

  -- Need today''s date/time for the XML file
  select @now=getdate()

  -- Need the DPID as a string for the XML file
  -- (or for error message)
  if @dpid is null
    select @s_dpid='null'
  else
    select @s_dpid=convert(varchar(8),@dpid)

  -- Validate the DPID
  if @dpid is null or @dpid <= 0
    begin
      select @status = 1
      select @errmsg = 'Invalid DPID: '+@s_dpid
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
          --select @errmsg = errormsg(@status)
          select @errmsg = ERROR_MESSAGE()
        end
    end

  if @initials is null
    select @initials = 'null'
  if @title is null
    select @title = 'null'
  if @surname is null
  begin
    select @surname = 'null'
			-- This is a hack.
			-- @@error isn't being set when no records are found.
			-- Id the surname is null, assume the record wasn't found
			-- (a surname is a required value, so if its missing there
			--  shouldn't have been a record.  If there actually is a
			--  record with a surname of <null>, that is a different error)
			-- TJB  14-Feb-2008
    select @status = -1
    select @errmsg = 'DPID '+@s_dpid+' not found'
  end

  if @status = 0
    begin
      -- Format today''s date/time for the XML file
      select @todaysDate=convert(varchar(10),@now,105) -- yyyy-mm-dd
      select @todaysTime=convert(varchar(8),@now,108) -- HH:mm:ss
      select @crlf= char(13)+ char(10)

      -- Prepare the XML file contents
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

      -- Write the file
      DECLARE   @object   int --create a Scripting Object for openning file
      DECLARE   @hr   int  
      DECLARE   @filehandle   int 
      DECLARE   @src   varchar(255),   @desc   varchar(255)   

      EXEC @hr = sp_OACreate 'Scripting.FileSystemObject', @object OUT   
        IF   @hr   <>   0   
        BEGIN   
            EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     
            --SELECT   hr=convert(varbinary(4),@hr),   Source=@src,   Description=@desc
      		select @errmsg='create a Scripting Object failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
          
        END   

      EXEC @hr = sp_OAMethod @object, 'CreateTextFile', @filehandle OUTPUT , @filename   --create a file
       IF    @hr   <>   0   
        BEGIN   
             EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     
      		 select @errmsg='Create a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 

        END   
 
      EXEC @hr = sp_OAMethod @filehandle, 'Write', NULL, @outstring    --write message to the file
        IF   @hr   <>   0   
        BEGIN   
             EXEC   sp_OAGetErrorInfo   @object,   @src   OUT,   @desc   OUT     
      		 select @errmsg='Write a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename   
        END   
 
      EXEC @hr = sp_OAMethod @filehandle, 'Close', NULL     --close the file
        IF   @hr   <>   0   
        BEGIN   
             EXEC sp_OAGetErrorInfo @object, @src OUT, @desc OUT     
      		 select @errmsg='Write close a text file failed: rc = '+convert(varchar(4),@hr)+ @desc +'; File = ' + @filename 
             select @status=-1
        END
        ELSE
        BEGIN   
             select @errmsg=@title+' '+@initials+' '+@surname+' File = '+@filename 
        END

      /*
	  execute @rc = xp_write_file @outfile,@outstring
      if @rc = 0
        -- If successful, "errmsg" contains details of the message
        select @errmsg=@title+' '+@initials+' '+@surname+' File = '+@outfile
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
		(@now, rtrim(@username), 'modify customer', @dpid, @status, @errmsg)
  return @status
end
GO

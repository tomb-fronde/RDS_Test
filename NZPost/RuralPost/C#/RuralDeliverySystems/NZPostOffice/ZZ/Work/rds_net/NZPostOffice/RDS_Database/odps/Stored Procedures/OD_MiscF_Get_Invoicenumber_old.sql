-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create procedure [odps].[OD_MiscF_Get_Invoicenumber_old] 
(@inPayPeriod_End datetime)
	-- Add the parameters for the stored procedure here
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
  declare @InvoiceNumber integer,
  @InvoiceSequenceStart integer
  select @InvoiceSequenceStart = "national".nat_seq_no_for_keys
    from "national" where
    "national".nat_effective_date = (select max(nat_effective_date) from
      "national" where "national".nat_effective_date <= @inPayPeriod_End)
--insert into temp_int values(1) --exec odps.od_blf_getnextsequence('invoice') 
--select @InvoiceNumber= intvalue from temp_int
 --select @InvoiceNumber = odps.od_blf_getnextsequence('invoice') 
exec @InvoiceNumber = odps.od_blf_getnextsequence '360'

 
  if @InvoiceNumber <= 0
    begin
      --rollback transaction // by fyb
      return(-1)
    end
  return(@InvoiceNumber)
    -- Insert statements for procedure here
END
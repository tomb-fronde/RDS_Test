/****** Object:  StoredProcedure [odps].[OD_BLF_GetNextSequence]    Script Date: 08/05/2008 10:13:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_BLF_GetNextSequence : 
--

create procedure [odps].[OD_BLF_GetNextSequence](@sequencename varchar(20))
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @nNextValue int
  declare @rowcnt int
  declare @err    int
  select @nNextValue = next_value 
    from rd.id_codes where
    sequence_name = @sequencename
  select @rowcnt=@@rowcount,@err=@@error
  if @err <> 0
    return(-1)
  if @rowcnt = 0
    begin
      insert into rd.id_codes(sequence_name,
        next_value) values(@sequencename,2)
      if @@ROWCOUNT = 0
        return(-1)
      return(1)
    end
  else
    begin
      update rd.id_codes set
        next_value = @nNextValue+1 where
        sequence_name = @sequencename
      if @@ROWCOUNT = 0
        return(-1)
      return (@nNextValue)
    end
end
GO

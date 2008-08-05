/****** Object:  UserDefinedFunction [odps].[OD_MiscF_ParseIRDNo]    Script Date: 08/05/2008 11:22:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for user-defined function OD_MiscF_ParseIRDNo : 
--

create function [odps].[OD_MiscF_ParseIRDNo](@inIRD char(20))
returns char(10)
AS
BEGIN

  declare @v_IRDNo varchar(10),
  @vt_IRDNo varchar(8)
  select @vt_IRDNo=left(@inIRD,8)
  if len(@vt_IRDNo) < 4
    return(@vt_IRDNo)
  select @v_IRDNo=left(@vt_IRDNo,3) + '-'
  select @vt_IRDNo=right(@vt_IRDNo,len(@vt_IRDNo)-3)
  if len(@vt_IRDNo) < 4
    return(@v_IRDNo + @vt_IRDNo)
  select @v_IRDNo=@v_IRDNo + left(@vt_IRDNo,3) + '-' + right(@vt_IRDNo,len(@vt_IRDNo)-3)
  return(@v_IRDNo)
end
GO

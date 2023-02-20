/****** Object:  StoredProcedure [odps].[od_rps_ir348header]    Script Date: 08/05/2008 10:14:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--
-- Definition for stored procedure od_rps_ir348header : 
--

create procedure [odps].[od_rps_ir348header](@startdate datetime,@enddate datetime)
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  select HDR='HDR',IRD_No='0' + 
    left((select [national].nat_ird_no from [national] where nat_id = odps.od_BLF_getWhichNational(@enddate)),2)+
    substring((select [national].nat_ird_no from [national] where nat_id = odps.od_BLF_getWhichNational(@enddate)),4,3)+
    right((select [national].nat_ird_no from [national] where nat_id = odps.od_BLF_getWhichNational(@enddate)),3),
    Return_Period=convert(CHAR(10),odps.od_Miscf_GetLastDayofMonth(@enddate),112/*!'yyyymmdd'*/),Contact_Person='PR Drysdale',Contact_Phone='04 576 5220',Total_PAYE='0',Child_Support='0',Student_Loan='0',Family_Assistance='0',Gross='0',Not_Liable='0',Form_Version_No='0001'
end
GO

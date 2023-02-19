
CREATE PROCEDURE [odps].[od_rps_irdPaydayHeader](
	 @startdate datetime
	,@enddate datetime)
AS
BEGIN
  -- TJB  IRD Payday Export  Feb-2022
  -- Changes required for updated IRD requirements
  -- Header changed to 'HEI2'; Gross and Paye columns moved
  -- Gross and paye prior deduction, SLCIR and SLBOR and share scheme columns added
  --
  -- TJB  RPCR_128  June-2019
  -- Copied/adapted from OD_RPS_IR348Header

  set NOCOUNT ON
  set CONCAT_NULL_YIELDS_NULL off

  -- Changed query to move IRD No selects from subqueries
  select HDR = 'HEI2'
       , IRD_No = '0' 
                + left(nat_ird_no,2)
                + substring(nat_ird_no,4,3)
                + right(nat_ird_no,3)
       , Pay_Date = convert(CHAR(10),odps.OD_Miscf_SetDayOfMonth(20,@enddate),112/*!'yyyymmdd'*/)
       , Final_Return = 'N'
       , Nil_Return = 'N'
       , PAYE_Intermediary = ''
       , Contact_Person = IRD_contact_name      -- 'Norman Tutaki'
       , Contact_Phone =  IRD_contact_phone     -- '027 2410389'
       , Contact_Email =  IRD_contact_email     -- 'ruralpayments@nzpost.co.nz'
       , Total_Lines = '0'
       , Gross = '0'
	   , Prior_Gross_Adjustments = '0'
       , Total_PAYE = '0'
	   , Prior_PAYE_Adjustments = '0'
       , Not_Liable = '0'
       , Child_Support = '0'
       , Student_Loan = '0'
	   , SLCIR_deductions = '0'
	   , SLBOR_deductions = '0'
       , Kiwi_Deducted = '0'
       , Kiwi_Emp_Contrib = '0'
       , ESCT_Deducted = '0'
       , Total_Deducted = '0'
       , Total_Credits = '0'
       , Family_Assistance = '0'
	   , Share_scheme = '0'
       , Package = 'RDS'
       , Form_Version_No = '0001'
    from odps.[national] 
   where nat_id = odps.od_BLF_getWhichNational(@enddate)
END
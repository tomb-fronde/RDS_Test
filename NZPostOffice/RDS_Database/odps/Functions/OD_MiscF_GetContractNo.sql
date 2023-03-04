
CREATE function [odps].[OD_MiscF_GetContractNo](
    @p_ded_reference char(200))
returns int
AS
BEGIN
    -- TJB  RPCR_094  Mar-2015
    -- Changed to look for "Contract xxxx " in input
    -- Input no longer starts with "Telecom" or "Shell"
    --
    -- TJB RPCR_020 20-Sep-2010: New
    -- Created from OD_BLF_Mainrun_PostTaxAdj
    -- Extracts the contract number from the input string, where the input looks like
    --    "Telecom Deduction Contract #### imported on <date>"
    -- or
    --    "Shell Deduction Contract #### imported on <date>"
    
    declare @startString varchar(20);
    declare @temps    varchar(20);
    declare @tempint1 int;
    declare @tempint2 int;
    declare @contract int;

    set @startString = 'Contract ';
    set @tempint1 = charindex(@startString, @p_ded_reference,1)+len(@startString)
    set @tempint2 = charindex(' ', @p_ded_reference,@tempint1+1)

    if @tempint2 > @tempint1
        set @temps = rtrim(ltrim(substring(@p_ded_reference,@tempint1,@tempint2-@tempint1)))
    else
        set @temps = ''

    if len(@temps) > 0 and substring(@temps, 1, 1) in ('1','2','3','4','5','6','7','8','9','0')
        set @contract = convert(int, @temps)
    else
        set @contract = null

    return(@contract)

END
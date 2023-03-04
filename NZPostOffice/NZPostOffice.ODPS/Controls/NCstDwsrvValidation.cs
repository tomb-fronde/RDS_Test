using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.ODPS.Controls
{
    public class NCstDwsrvValidation
    {
        //public StringArray is_Column = new StringArray();
        List<string> is_Column = new List<string>();

        public int ii_MaxColumn;

        public int ii_ErrorWindowX;

        public int ii_ErrorWindowY;

        public int ii_ErrorWindowWidth;

        public int ii_ErrorWindowHeight;

        public bool ib_ErrorWindowAtBottom = true;

        public bool ib_ErrorWindowProperties = false;

        public NCstValidationattrib inv_ValidationAttrib;

        public NCstString inv_String;

        public NCstDwsrvValidation()
        {
        }

        //        public virtual void constructor()
        //        {
        //            //?base.constructor();
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			Constructor
        //            // 	Description:	set the defaults for the service
        //            this.of_setcolumnnamesource(csconstant.DisplayTagHdrDWHiearchy);
        //        }

        //        public virtual string of_reformatvalidationrule(int aiv_column)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_ReformatValidationRule
        //            // 	Description:	reformat the validation rule from the datawindow painter so
        //            // 						we can perform the powerscript equivalent
        //            // 	Arguments:		aiv_Column - integer containing the index to the column name array
        //            // 	Returns:			string containing the corrected rule
        //            string ls_ColumnType;
        //            string ls_Replacement;
        //            string ls_ValidationRule;
        //            int li_ParenPosition;
        //            NCstString lnv_String;

        //            // 	determine if there is a validation rule and it contains some fashion of "GetText"
        //            ls_ValidationRule = idw_requestor.GetValidate(is_Column[aiv_column]);
        //            if (IsNull(ls_ValidationRule) || ls_ValidationRule <= "" || TextUtil.Pos(Upper(ls_ValidationRule), "GETTEXT", 1) <= 0)
        //            {
        //                return "";
        //            }
        //            // 	get the column type, it is not a string, we need to convert all occurrences of 
        //            // 	GetText ( ) to String ( column name) otherwise  we need to convert GetText ( ) to column name
        //            ls_ColumnType = idw_requestor.Describe(is_Column[aiv_column] + ".ColType");
        //            li_ParenPosition = TextUtil.Pos(ls_ColumnType, " ( ", 1);
        //            if (li_ParenPosition > 0)
        //            {
        //                ls_ColumnType = TextUtil.Left(ls_ColumnType, li_ParenPosition - 1);
        //            }
        //            // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //            unknown TestExpr = Upper(ls_ColumnType);
        //            if (TestExpr == "CHAR" || TestExpr == "STRING")
        //            {
        //                ls_Replacement = is_Column[aiv_column];
        //            }
        //            else if (TestExpr == "NUMBER" || TestExpr == "DECIMAL" || TestExpr == "DATE" || TestExpr == "DATETIME" || TestExpr == "INTEGER" || TestExpr == "LONG" || TestExpr == "TIME" || TestExpr == "TIMESTAMP")
        //            {
        //                ls_Replacement = "String (  " + is_Column[aiv_column] + ')';
        //            }
        //            // 	do the actual conversion
        //            ls_ValidationRule = lnv_String.of_globalreplace(ls_ValidationRule, "GetText ( )", ls_Replacement, true);
        //            ls_ValidationRule = lnv_String.of_globalreplace(ls_ValidationRule, "GetText  ( )", ls_Replacement, true);
        //            ls_ValidationRule = lnv_String.of_globalreplace(ls_ValidationRule, "GetText (  )", ls_Replacement, true);
        //            ls_ValidationRule = lnv_String.of_globalreplace(ls_ValidationRule, "GetText  (  )", ls_Replacement, true);
        //            // 	replace all occurrences of ' with ~'  ( this is necessary for
        //            // 	the Evaluate function to work)
        //            ls_ValidationRule = lnv_String.of_globalreplace(ls_ValidationRule, '\'', "~\'");
        //            return ls_ValidationRule;
        //        }

        //        public virtual int of_checkforrequired(int aiv_column, string asv_value)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForRequired
        //            // 	Description:	this function will check to see if the column passes the required field check or not
        //            // 	Arguments:		aiv_Column - integer containing the index to the column array
        //            // 						asv_Value - string containing the value for the column
        //            // 	Returns:			0 if everything is cool, -1 if an error condition is found
        //            string ls_Required;
        //            // 	get the required field attribute from the datawindow
        //            ls_Required = Upper(idw_requestor.Describe(is_Column[aiv_column] + '.' + idw_requestor.Describe(is_Column[aiv_column] + ".Edit.Style") + ".Required"));
        //            // 	check to see if the field is required, if so, make sure it has a value
        //            if (ls_Required == "YES" && (IsNull(asv_value) || asv_value.Trim() == ""))
        //            {
        //                return -(1);
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }

        //        public virtual int of_clearerrors()
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_ClearErrors
        //            // 	Description:	reset the nonvisual object holding the errors
        //            // 	Arguments:		none
        //            // 	Returns:			0
        //            IntArray li_ErrorColumn = new IntArray();
        //            IntArray li_SeverityLevel = new IntArray();
        //            IntArray ll_ErrorRow = new IntArray();
        //            StringArray ls_ErrorMsg = new StringArray();
        //            inv_ValidationAttrib.ii_ErrorColumn = li_ErrorColumn;
        //            inv_ValidationAttrib.ii_SeverityLevel = li_SeverityLevel;
        //            inv_ValidationAttrib.il_ErrorRow = ll_ErrorRow;
        //            inv_ValidationAttrib.is_ErrorMsg = ls_ErrorMsg;
        //            return 0;
        //        }

        //        public virtual string of_loadtimeextensions(int alv_row, int aiv_column) {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_LoadTimeExtensions
        //            // 	Description:	this function will force the time portion of a datetime to the appropriate value
        //            // 	Arguments:		alv_Row - row that is being validated
        //            // 						aiv_Column - index to the column name to force time for
        //            // 	Returns:			string containing the changed value
        //            string ls_TimeExtension;
        //            string ls_ColumnType;
        //            DateTime ldt_Value;
        //            // 	first make sure this column is a datetime column, get the column type for the column
        //            ls_ColumnType = Upper(idw_requestor.Describe(is_Column[aiv_column] + ".ColType"));
        //            if (ls_ColumnType == "DATETIME" || ls_ColumnType == "TIMESTAMP") {
        //                // 	first get the datetime column value
        //                ldt_Value = idw_requestor.GetItemDateTime(alv_row, is_Column[aiv_column]);
        //                // 	check to see if we are to set the time portion, 
        //                // 	first check for begin date  ( 00:00:00:000 should be the default)
        //                if (Pos(Upper(idw_requestor.Describe(is_Column[aiv_column] + ".Tag")), "BEGINDATE", 1) > 0) {
        //                    idw_requestor.SetItem(alv_row, is_Column[aiv_column], System.Convert.ToDateTime ( System.Convert.ToDateTime ( ldt_Value  ), Time("00:00:00:000")));
        //                    // 	if not, check for end date  ( 23:59:59:333 should be the default)
        //                }
        //                else if (Pos(Upper(idw_requestor.Describe(is_Column[aiv_column] + ".Tag")), "ENDDATE", 1) > 0) {
        //                    idw_requestor.SetItem(alv_row, is_Column[aiv_column], System.Convert.ToDateTime ( System.Convert.ToDateTime ( ldt_Value  ), Time("23:59:59:333")));
        //                }
        //            }
        //            // 	return the changed value
        //            return this.of_getitem(alv_row, is_Column[aiv_column], primary!, false);
        //        }

        //        public virtual int of_checkforvalidationrule(int alv_row, int aiv_column, string asv_value)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForValidationRule
        //            // 	Description:	this function will perform any validation rule as set forth by the developer 
        //            // 						in the datawindow painter
        //            // 	Arguments:		alv_Row - row number being validated
        //            // 						aiv_Column - index to the column being validated
        //            // 						asv_Value - value for the column from the row
        //            // 	Returns:			0 if no error found, -1 if an error was found
        //            string ls_ValidationRule;
        //            string ls_Evaluate;
        //            int li_Return;
        //            // 	check for a validation rule and message  ( if any)
        //            ls_ValidationRule = this.of_reformatvalidationrule(aiv_column);
        //            // 	if there is a validation rule, evaluate the rule
        //            if (IsNull(ls_ValidationRule) == false && ls_ValidationRule != "")
        //            {
        //                // 	evalute the expression, first we need to call the function to replace any conversion 
        //                // 	functions that were embedded in the rule
        //                ls_Evaluate = "Evaluate ( \'If ( " + ls_ValidationRule + ", ~\'TRUE~\', ~\'FALSE~\')\', " + alv_row.ToString() + ')';
        //                ls_Evaluate = Upper(idw_requestor.Describe(ls_Evaluate));
        //                if (ls_Evaluate == "FALSE")
        //                {
        //                    li_Return = -(1);
        //                }
        //            }
        //            return li_Return;
        //        }

        //        public virtual int of_checkallrowsfordaterangegap(string asv_begdatecolumn, string asv_enddatecolumn)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckAllRowsForDateRangeGap
        //            // 	Description:	this event will check all rows for a date range gap violation for the specified
        //            // 						begin and end date columns
        //            // 	Arguments:		asv_BeginDateColumn - column name for the begin date
        //            // 						asv_EndDateColumn - column name for the end date
        //            // 	Returns:			0 if no violation, -1 if a date range gap was found
        //            // 
        //            //  this is here for backward compatability, call the new function
        //            return this.of_checkallrowsforrangegap(asv_begdatecolumn, asv_enddatecolumn);
        //        }

        //        public virtual int of_checkforduplicate(int alv_row, int aiv_column)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForDuplicate
        //            // 	Description:	this event will check the datawindow for duplicates for a specified column
        //            // 	Arguments:		alv_Row - row that is being validated
        //            // 						aiv_Column - column to check for duplicates
        //            // 	Returns:			0 if there are no duplicates, -1 if a duplicate was found
        //            string ls_Find;
        //            string ls_ColumnType;
        //            string ls_ColumnValue;
        //            string ls_AdditionalColumn;
        //            string ls_Case;
        //            string ls_Column;
        //            int ll_Row;
        //            int ll_RowCount;
        //            int ll_Delimiter;
        //            int li_ParenPosition;
        //            int li_Return;
        //            bool lb_MoreToProcess = true;
        //            bool lb_AllValuesFound = true;
        //            // 	extract the case to do a compare
        //            ls_Case = Upper(inv_String.of_getkeyvalue(idw_requestor.Describe(is_Column[aiv_column] + ".Tag"), "NoDup", ';'));
        //            // 	if no key value was found, see if just the key word is found, if so, assume nocase
        //            if (IsNull(ls_Case) || ls_Case <= "")
        //            {
        //                if (Pos(Upper(idw_requestor.Describe(is_Column[aiv_column] + ".Tag")), "NODUP", 1) > 0)
        //                {
        //                    ls_Case = "NOCASE";
        //                }
        //            }
        //            // 	determine if this column is to be checked
        //            if (IsNull(ls_Case) || ls_Case <= "")
        //            {
        //                return 0;
        //            }
        //            // 	extract any additional columns to include in the find syntax
        //            ls_AdditionalColumn = inv_String.of_getkeyvalue(idw_requestor.Describe(is_Column[aiv_column] + ".Tag"), "DupColumn", ';');
        //            // 	process the first column and optionally 
        //            ls_Column = is_Column[aiv_column];
        //            // 	stay in this loop until all columns are processed
        //            while (lb_MoreToProcess)
        //            {
        //                // 	extract the column value and type
        //                ls_ColumnType = Upper(idw_requestor.Describe(ls_Column + ".ColType"));
        //                li_ParenPosition = TextUtil.Pos(ls_ColumnType, " ( ", 1);
        //                if (li_ParenPosition > 0)
        //                {
        //                    ls_ColumnType = TextUtil.Left(ls_ColumnType, li_ParenPosition - 1);
        //                }
        //                // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //                string TestExpr = ls_ColumnType;
        //                if (TestExpr == "CHAR" || TestExpr == "STRING")
        //                {
        //                    ls_ColumnValue = idw_requestor.GetItemString(alv_row, ls_Column);
        //                    // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //                    string TestExpr = ls_Case;
        //                    if (TestExpr == "CASE")
        //                    {
        //                        ls_Find = ls_Find + ls_Column + " = \"" + ls_ColumnValue + '~';
        //                    }
        //                    else
        //                    {
        //                        ls_Find = ls_Find + "Upper ( " + ls_Column + ") = \"" + Upper(ls_ColumnValue) + '~';
        //                    }
        //                    // 	for numbers, it is just a straight compare
        //                }
        //                else if (TestExpr == "NUMBER" || TestExpr == "LONG" || TestExpr == "INTEGER" || TestExpr == "DECIMAL")
        //                {
        //                    ls_ColumnValue = String(idw_requestor.GetItemNumber(alv_row, ls_Column));
        //                    ls_Find = ls_Find + ls_Column + " = " + ls_ColumnValue;
        //                    // 	if this is a datetime column, we need to wrap with a DateTime function
        //                }
        //                else if (TestExpr == "DATETIME" || TestExpr == "TIMESTAMP")
        //                {
        //                    ls_ColumnValue = String(idw_requestor.GetItemDateTime(alv_row, ls_Column));
        //                    ll_Delimiter = TextUtil.Pos(ls_ColumnValue, ' ', 1);
        //                    ls_Find = ls_Find + ls_Column + " = System.Convert.ToDateTime (  System.Convert.ToDateTime (  \'" + TextUtil.Left(ls_ColumnValue, ll_Delimiter - 1) + "\'), " + "Time ( \'" + TextUtil.Right(ls_ColumnValue, ls_ColumnValue.Len() - ll_Delimiter) + "\'))";
        //                    // 	if this is a date column, we need to wrap with a Date function
        //                }
        //                else if (TestExpr == "DATE")
        //                {
        //                    ls_ColumnValue = String(idw_requestor.GetItemDateTime(alv_row, ls_Column).Date);
        //                    ls_Find = ls_Find + ls_Column + " = System.Convert.ToDateTime (  \'" + TextUtil.Left(ls_ColumnValue, TextUtil.Pos(ls_ColumnValue, ' ', 1) - 1) + "\')";
        //                    // 	if this is a time column, we need to wrap with a Time function
        //                }
        //                else if (TestExpr == "TIME")
        //                {
        //                    ls_ColumnValue = String(idw_requestor.GetItemDateTime(alv_row, ls_Column).TimeOfDay);
        //                    ls_Find = ls_Find + ls_Column + " = Time ( \'" + TextUtil.Right(ls_ColumnValue, ls_ColumnValue.Len() - TextUtil.Pos(ls_ColumnValue, ' ', 1)) + "\')";
        //                }
        //                else
        //                {
        //                    ls_Find = null;
        //                }
        //                // 	make sure a column value was found
        //                if (IsNull(ls_ColumnValue) || ls_ColumnValue <= "")
        //                {
        //                    lb_AllValuesFound = false;
        //                    break;
        //                }
        //                // 	determine if there are any move columns to process
        //                if (IsNull(ls_AdditionalColumn) || ls_AdditionalColumn.Len() <= 0)
        //                {
        //                    lb_MoreToProcess = false;
        //                    // 	extract the next additional column
        //                }
        //                else
        //                {
        //                    ls_Find = ls_Find + " AND ";
        //                    ls_Column = inv_String.of_gettoken(ls_AdditionalColumn, '\\');
        //                }
        //            }
        //            // 	only need to do this check if all ColumnValues exists
        //            if (lb_AllValuesFound)
        //            {
        //                // 	we need to first get the number of rows to check
        //                ll_RowCount = idw_requestor.RowCount;
        //                // 	now do the finds for the duplicate value, we know we will always find one, so we must 
        //                // 	"double pump" the find, if a second row is found, then we know there is a duplicate
        //                ll_Row = idw_requestor.Find(ls_Find).Length;
        //                if (ll_Row < ll_RowCount && idw_requestor.Find(ls_Find).Length > 0)
        //                {
        //                    li_Return = -(1);
        //                }
        //            }
        //            return li_Return;
        //        }

        //        public virtual int of_checkfordaterangeoverlap(int alv_row, string asv_begdatecolumn, string asv_enddatecolumn, DateTime adtv_begdate, DateTime adtv_enddate)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForDateRangeOverlap
        //            // 	Description:	this event will check a given row/column for date range overlap violation
        //            // 	Arguments:		alv_Row - row that is being validated
        //            // 						asv_BegDateColumn - begin date column
        //            // 						asv_EndDateColumn - end date column
        //            // 						adtv_BegDate - begin datetime
        //            // 						adtv_EndDate - end datetime
        //            // 	Returns:			0 if no overlap was found, -1 if an overlap was found
        //            // 
        //            //  this is here for backward compatability, call the new function
        //            return this.of_checkforrangeoverlap(alv_row, asv_begdatecolumn, asv_enddatecolumn, adtv_begdate, adtv_enddate);
        //        }

        //        public virtual int of_validaterow(int alv_row) 
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_ValidateRow
        //            // 	Description:	this function will record any problems for required columns and
        //            // 						for failures for validation purposes.  the errors
        //            // 						will be recorded in a nonvisual user object for later use
        //            // 	Arguments:		alv_Row - row number being validated
        //            // 	Returns:			0 if row has no error, -1 if an error was found
        //            string ls_ValidationMsg;
        //            string ls_Warning;
        //            string ls_ColumnValue;
        //            StringArray ls_MsgParms = new StringArray();
        //            string ls_DisplayName;
        //            StringArray ls_Null = new StringArray();
        //            string ls_Evaluate;
        //            bool lb_ErrorFound = false;
        //            int li_Column;
        //            int li_SeverityLevel;
        //            int li_Return;
        //            // 	we need to first get all the columns from the datawindow
        //            if (ii_MaxColumn <= 0) {
        //                ii_MaxColumn = this.of_getobjects(is_Column, "column", "detail", true);
        //            }
        //            // 	now we need to walk through for each column performing the necessary checks
        //            for (li_Column = 1; li_Column <= ii_MaxColumn; li_Column++) {
        //                lb_ErrorFound = false;
        //                ls_MsgParms = ls_Null;
        //                // 	if this is a column that is enterable but not to be modified we want to turn the status 
        //                // 	to NotModified! so as not to try and update the database, in addition, we have no 
        //                // 	further checking to do
        //                if (Pos(Upper(idw_requestor.Describe(is_Column[li_Column] + ".Tag")), "NOUPDATE", 1) > 0) {
        //                    idw_requestor.SetItemStatus(alv_row, is_Column[li_Column], primary!, notmodified!);
        //                    continue;
        //                }
        //                // 	if this is a datetime column that is to have the time portion always set to a particular value
        //                ls_ColumnValue = this.of_loadtimeextensions(alv_row, li_Column);
        //                ls_DisplayName = this.of_getdisplayname(is_Column[li_Column]);
        //                // 	now perform the various validation checks,	first check for required fields
        //                if (this.of_checkforrequired(li_Column, ls_ColumnValue) < 0) {
        //                    lb_ErrorFound = true;
        //                    ls_MsgParms[1] = ls_DisplayName;
        //                    if (IsValid(gnv_app.inv_Error)) {
        //                        ls_ValidationMsg = gnv_app.inv_Error.of_GetMessageText("CS5-0010", ls_MsgParms);
        //                    }
        //                    else {
        //                        ls_ValidationMsg = ls_DisplayName + " is a required column";
        //                    }
        //                    // 	the column has passed the required check, now check for duplicates
        //                }
        //                else if (this.of_checkforduplicate(alv_row, li_Column) < 0) {
        //                    lb_ErrorFound = true;
        //                    ls_MsgParms[1] = ls_ColumnValue;
        //                    ls_MsgParms[2] = ls_DisplayName;
        //                    if (IsValid(gnv_app.inv_Error)) {
        //                        ls_ValidationMsg = gnv_app.inv_Error.of_GetMessageText("CS5-0011", ls_MsgParms);
        //                    }
        //                    else {
        //                        ls_ValidationMsg = '\'' + ls_ColumnValue + '\'' + " is  ( part of) a duplicate value for " + ls_DisplayName;
        //                    }
        //                    // 	the column has passed the required and duplicate check, now check for range stuff
        //                }
        //                else if (this.of_checkforrange(alv_row, li_Column, ls_ValidationMsg) < 0) {
        //                    lb_ErrorFound = true;
        //                    // 	everything is cool so far, now check for a validation rules
        //                }
        //                else if (this.of_checkforvalidationrule(alv_row, li_Column, ls_ColumnValue) < 0) {
        //                    // 	validation failed, extract the message from the datawindow
        //                    ls_ValidationMsg = idw_requestor.Describe(is_Column[li_Column] + ".ValidationMsg");
        //                    // 	first check to see if we have an expression to evaluate first
        //                    if (Pos(ls_ValidationMsg, '+', 1) > 0 ||  TextUtil.Left(ls_ValidationMsg, 1) != '\'' &&  TextUtil.Left(ls_ValidationMsg, 1) != '\"') {
        //                        ls_Evaluate = "Evaluate ( \'" + ls_ValidationMsg + "\', " + alv_row.ToString() + ')';
        //                        ls_ValidationMsg = idw_requestor.Describe(ls_Evaluate);
        //                    }
        //                    // 	strip off any leading and trailing double quotes
        //                    if (Left(ls_ValidationMsg, 1) == '\"') {
        //                        ls_ValidationMsg =  TextUtil.Mid (ls_ValidationMsg, 2,  ls_ValidationMsg.Len() - 2);
        //                    }
        //                    ls_ValidationMsg = inv_String.of_globalreplace(ls_ValidationMsg, '\'', "");
        //                    ls_ValidationMsg = inv_String.of_globalreplace(ls_ValidationMsg, "~~\"", "");
        //                    lb_ErrorFound = true;
        //                }
        //                // 	if there was an error found, set the error message
        //                if (lb_ErrorFound) {
        //                    li_Return = -(1);
        //                    // 	now determine whether the error message is a warning or an error
        //                    if (Pos(Upper(idw_requestor.Describe(is_Column[li_Column] + ".Tag")), "WARNING", 1) > 0) {
        //                        li_SeverityLevel = 0;
        //                    }
        //                    else {
        //                        li_SeverityLevel = 9;
        //                    }
        //                    // 	load the error message
        //                    this.of_adderrormsg(alv_row, System.Conver.ToInt32 ( idw_requestor.Describe(is_Column[li_Column] + ".ID" )), li_SeverityLevel, ls_ValidationMsg);
        //                }
        //            }
        //            return li_Return;
        //        }

        //        public virtual int of_validate() {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_Validate
        //            // 	Description:	perform the validation for all modified rows in the datawindow
        //            // 	Arguments:		none
        //            // 	Returns:			0 if no errors, -1 if errors found
        //            int li_Return;
        //            int ll_Row;
        //            // 	we need to first get all the columns from the datawindow
        //            if (ii_MaxColumn <= 0) {
        //                ii_MaxColumn = this.of_getobjects(is_Column, "column", '*', true);
        //                // 	if there are no columns, there can be no errors!
        //                if (ii_MaxColumn <= 0) {
        //                    return 0;
        //                }
        //            }
        //            ll_Row = idw_requestor.GetNextModified(0, primary!);
        //            // 	if at least one row was changed, perform the check for date range gaps
        //            if (ll_Row > 0 || idw_requestor.DeletedCount() > 0) {
        //                li_Return = li_Return + this.of_checkforrangegap();
        //            }
        //            while (ll_Row > 0) {
        //                // 	provide the developer with a "hook" to do things before the row is validated
        //                if (idw_requestor.cs_prevalidaterow(ll_Row) < 0) {
        //                    li_Return = -(1);
        //                }
        //                // 	if an error was found, set the function return value
        //                if (this.of_validaterow(ll_Row) < 0) {
        //                    li_Return = -(1);
        //                }
        //                // 	provide the developer with a "hook" to do things after the row is validated
        //                if (idw_requestor.cs_postvalidaterow(ll_Row) < 0) {
        //                    li_Return = -(1);
        //                }
        //                // 	get the next row
        //                ll_Row = idw_requestor.GetNextModified(ll_Row, primary!);
        //            }
        //            return li_Return;
        //        }

        //        public virtual int of_adderrormsg(int alv_row, int aiv_column, int aiv_severitylevel, string asv_msg)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_AddErrorMsg
        //            // 	Description:	adds an error into the error structure
        //            // 	Arguments:		alv_Row - row in error
        //            // 						aiv_Column - column in error
        //            // 						aiv_SeverityLevel - string containing whether this is an error or warning message
        //            // 						asv_Msg - message describing the error
        //            // 	Returns:			integer containing the number of errors so far
        //            int li_MaxError;
        //            // 	load the datawindow and window
        //            inv_ValidationAttrib.idw_WithError = idw_requestor;
        //            idw_requestor.of_getparentwindow(inv_ValidationAttrib.iw_Parent);
        //            li_MaxError = inv_ValidationAttrib.il_ErrorRow.UpperBound + 1;
        //            inv_ValidationAttrib.il_ErrorRow[li_MaxError] = alv_row;
        //            inv_ValidationAttrib.ii_ErrorColumn[li_MaxError] = aiv_column;
        //            inv_ValidationAttrib.ii_SeverityLevel[li_MaxError] = aiv_severitylevel;
        //            inv_ValidationAttrib.is_ErrorMsg[li_MaxError] = asv_msg;
        //            return li_MaxError;
        //        }

        //        public virtual int of_checkfordaterangegap()
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForDateRangeGap
        //            // 	Description:	this event will check all given rows/column for date	range violations related to gaps
        //            // 	Arguments:		none
        //            // 	Returns:			0 if everything is cool, -1 if a violation was found
        //            // 
        //            //  this is here for backward compatability, call the new function
        //            return this.of_checkforrangegap();
        //        }

        //        public virtual n_cst_validationattrib of_geterrors()
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_GetErrors
        //            // 	Description:	retrieve the nonvisual user object containing the error messages
        //            // 	Arguments:		none
        //            // 	Returns:			nonvisual user object of type n_cst_ValidationAttrib
        //            return inv_ValidationAttrib;
        //        }

        //        public virtual int of_checkfordaterange(int alv_row, int aiv_column, ref string asr_errormsg)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForDateRange
        //            // 	Description:	this event will check a given row/column that has been specified as a "BeginDate"
        //            // 						for date range violations  ( comparison, gaps and/or overlaps)
        //            // 	Arguments:		alv_Row - row that is being validated
        //            // 						aiv_Column - index to the column name to check for violations
        //            // 						asr_ErrorMsg - string containing the error message supplied if any
        //            // 	Returns:			0 if no error found, -1 if an error was found
        //            //  this is here for backward compatability, call the new function
        //            return this.of_checkforrange(alv_row, aiv_column, asr_errormsg);
        //        }

        //        public virtual int of_seterrorwindowproperties(int aiv_x, int aiv_y, int aiv_width, int aiv_height)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_SetErrorWindowProperties
        //            // 	Description:	manually set the error window properties
        //            // 	Arguments:		aiv_X - integer containing the x offset from window top left
        //            // 						aiv_Y - integer containing the y offset from window top left
        //            // 						aiv_Width - integer containing the width of the error window
        //            // 						aiv_Height - integer containing the height of the error window
        //            // 	Returns:			0
        //            ii_ErrorWindowX = aiv_x;
        //            ii_ErrorWindowY = aiv_y;
        //            ii_ErrorWindowWidth = aiv_width;
        //            ii_ErrorWindowHeight = aiv_height;
        //            ib_ErrorWindowProperties = true;
        //            return 0;
        //        }

        //        public virtual int of_geterrorwindowproperties(ref int air_x, ref int air_y, ref int air_width, ref int air_height)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_GetErrorWindowProperties
        //            // 	Description:	get the error window properties
        //            // 	Arguments:		air_X - integer containing the x offset from window top left
        //            // 						air_Y - integer containing the y offset from window top left
        //            // 						air_Width - integer containing the width of the error window
        //            // 						airv_Height - integer containing the height of the error window
        //            // 	Returns:			0
        //            air_x = ii_ErrorWindowX;
        //            air_y = ii_ErrorWindowY;
        //            air_width = ii_ErrorWindowWidth;
        //            air_height = ii_ErrorWindowHeight;
        //            return 0;
        //        }

        //        public virtual bool of_geterrorwindowatbottom()
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_GetErrorWindowAtBottom
        //            // 	Description:	get whether the popup window to display at the bottom  ( TRUE) or top  ( FALSE) of screen
        //            // 	Arguments:		none
        //            // 	Returns:			boolean indicating the position of the error window
        //            return ib_ErrorWindowAtBottom;
        //        }

        //        public virtual int of_seterrorwindowatbottom(bool abv_switch)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_SetErrorWindowAtBottom
        //            // 	Description:	set whether the popup window to display at the bottom  ( TRUE) or top  ( FALSE) of screen
        //            // 	Arguments:		abv_Switch - boolean indicating the position of the error window
        //            // 	Returns:			0
        //            ib_ErrorWindowAtBottom = abv_switch;
        //            return 0;
        //        }

        //        public virtual bool of_geterrorwindowpropertiesmanual()
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_GetErrorWindowPropertiesManual
        //            // 	Description:	get whether the popup window properties have been manually assigned or not
        //            // 	Arguments:		none
        //            // 	Returns:			boolean indicating whether error window properties were given or not
        //            return ib_ErrorWindowProperties;
        //        }

        //        public virtual bool of_displayerrors() {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_DisplayErrors
        //            // 	Description:	open the window to display any datawindow errors found
        //            // 	Arguments:		none
        //            // 	Returns:			boolean indicating whether any errors were found or not
        //            bool lb_ErrorFound = true;
        //            int li_Choice;
        //            w_master lw_Parent;
        //            // 	get the parent window
        //            idw_requestor.of_getparentwindow(lw_Parent);
        //            // 	check to see if the error window is already open, if not, open, then  ( or else) load the errors
        //            if (IsValid(lw_Parent.iw_ValidationError) == false) {
        //                Open(lw_Parent.iw_ValidationError, lw_Parent);
        //            }
        //            // 	setup the validation error window stuff
        //            if (ib_ErrorWindowProperties) {
        //                lw_Parent.iw_ValidationError.of_setwindowproperties(ii_ErrorWindowX, ii_ErrorWindowY, ii_ErrorWindowWidth, ii_ErrorWindowHeight);
        //            }
        //            else {
        //                lw_Parent.iw_ValidationError.of_setwindowatbottom(lw_Parent, ib_ErrorWindowAtBottom);
        //            }
        //            lw_Parent.iw_ValidationError.show();
        //            lw_Parent.iw_ValidationError.of_seterrors(inv_ValidationAttrib);
        //            // 	make sure the window was opened successfully
        //            if (IsValid(lw_Parent.iw_ValidationError) == false) {
        //                if (IsValid(gnv_app.inv_Error)) {
        //                    gnv_app.inv_Error.of_Message("CS5-0016");
        //                }
        //                else {
        //                    MessageBox("Application Error", "Error opening Validation Errors window.", stopsign!, ok!, 1);
        //;
        //                }
        //                // 	check to see if only warnings were found, if so, prompt the user as to what to do
        //            }
        //            else if (lw_Parent.iw_ValidationError.of_geterrordisplayed() == false) {
        //                if (IsValid(gnv_app.inv_Error)) {
        //                    li_Choice = gnv_app.inv_Error.of_Message("CS5-0017");
        //                }
        //                else {
        //                    li_Choice = MessageBox("Validation Messages", "Only Warning Messages were found.  Do you want to continue processing?", question!, yesno!, 2);
        //                }
        //                // 	if the user wants to save, shut down the window
        //                if (li_Choice == 1) {
        //                    Close(lw_Parent.iw_ValidationError);
        //                    lb_ErrorFound = false;
        //                }
        //            }
        //            return lb_ErrorFound;
        //        }

        //        public virtual int of_checkforrangegap()
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForRangeGap
        //            // 	Description:	this event will check all given rows/column for range violations related to gaps
        //            // 	Arguments:		none
        //            // 	Returns:			0 if everything is cool, -1 if a violation was found
        //            string ls_EndColumn;
        //            string ls_ColumnType;
        //            int li_Column;
        //            int li_Return;
        //            // 	walk through each column looking for a datetime columntype
        //            for (li_Column = 1; li_Column <= ii_MaxColumn; li_Column++)
        //            {
        //                // 	check to see if we have any range gap rules to check
        //                if (Pos(Upper(idw_requestor.Describe(is_Column[li_Column] + ".Tag")), "NOGAP", 1) > 0)
        //                {
        //                    ls_EndColumn = inv_String.of_getkeyvalue(idw_requestor.Describe(is_Column[li_Column] + ".Tag"), "CompareEnd", ';');
        //                    if (IsNull(ls_EndColumn) || ls_EndColumn == "")
        //                    {
        //                        ls_EndColumn = inv_String.of_getkeyvalue(idw_requestor.Describe(is_Column[li_Column] + ".Tag"), "CompareEndDate", ';');
        //                    }
        //                    // 	if an end date column was found, perform the check
        //                    if (IsNull(ls_EndColumn) == false && ls_EndColumn != "")
        //                    {
        //                        li_Return = this.of_checkallrowsforrangegap(is_Column[li_Column], ls_EndColumn);
        //                        if (li_Return < 0)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            // 	if we got this far, there was no problem
        //            return li_Return;
        //        }

        //        public virtual int of_checkallrowsforrangegap(string asv_begcolumn, string asv_endcolumn)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckAllRowsForRangeGap
        //            // 	Description:	this event will check all rows for a range gap violation for the specified
        //            // 						begin and end columns
        //            // 	Arguments:		asv_BeginColumn - column name for the begin value
        //            // 						asv_EndColumn - column name for the end value
        //            // 	Returns:			0 if no violation, -1 if a range gap was found
        //            string ls_OldSort;
        //            string ls_ColumnType;
        //            string ls_ErrorMsg;
        //            StringArray ls_MsgParms = new StringArray();
        //            int ll_Row;
        //            int ll_MaxRow;
        //            DateTime ldt_PriorEndDate;
        //            object lany_PriorValue;
        //            int li_Return;
        //            int li_SeverityLevel;
        //            int li_ParenPosition;
        //            bool lb_ErrorFound = false;
        //            //  pass substitution values to string array
        //            ls_MsgParms[1] = asv_begcolumn;
        //            ls_MsgParms[2] = asv_endcolumn;
        //            // 	get the rows in the datawindow
        //            ll_MaxRow = idw_requestor.RowCount;
        //            // 	extract the severity level from the tag value
        //            if (Pos(Upper(idw_requestor.Describe(asv_begcolumn + ".Tag")), "WARNING", 1) > 0)
        //            {
        //                li_SeverityLevel = 0;
        //            }
        //            else
        //            {
        //                li_SeverityLevel = 9;
        //            }
        //            // 	we must first sort the datawindow in begin date sequence,
        //            // 	keep the old sort sequence so we can redisplay the information
        //            ls_OldSort = idw_requestor.Describe("DataWindow.Table.Sort");
        //            idw_requestor.of_setredraw(false);
        //            // 	now add the begin date column to the end 
        //            idw_requestor.SetSort(asv_begcolumn + " A");
        //            idw_requestor.Sort();
        //            // 	we must walk through all the rows looking for gaps
        //            for (ll_Row = 1; ll_Row <= ll_MaxRow; ll_Row++)
        //            {
        //                ls_ColumnType = Upper(idw_requestor.Describe(asv_begcolumn + ".ColType"));
        //                li_ParenPosition = TextUtil.Pos(ls_ColumnType, " ( ", 1);
        //                if (li_ParenPosition > 0)
        //                {
        //                    ls_ColumnType = TextUtil.Left(ls_ColumnType, li_ParenPosition - 1);
        //                }
        //                //  check column type
        //                // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //                string TestExpr = ls_ColumnType;
        //                if (TestExpr == "DATETIME" || TestExpr == "TIMESTAMP")
        //                {
        //                    // 	if this is not the first row, make sure the begin value of this row
        //                    // 	is exactly one greater than the end value of the prior row
        //                    if (ll_Row != 1)
        //                    {
        //                        if (DaysAfter(System.Convert.ToDateTime(ldt_PriorEndDate), System.Convert.ToDateTime(idw_requestor.GetItemDateTime(ll_Row, asv_begcolumn))) != 1)
        //                        {
        //                            lb_ErrorFound = true;
        //                            break;
        //                        }
        //                    }
        //                    // 	get the end date for the next compare
        //                    ldt_PriorEndDate = idw_requestor.GetItemDateTime(ll_Row, asv_endcolumn);
        //                }
        //                else if (TestExpr == "NUMBER" || TestExpr == "LONG" || TestExpr == "INTEGER" || TestExpr == "UNSIGNEDINTEGER" || TestExpr == "UNSIGNEDLONG" || TestExpr == "DECIMAL" || TestExpr == "DOUBLE" || TestExpr == "REAL")
        //                {
        //                    // 	if this is not the first row, make sure the begin value of this row
        //                    // 	is exactly one greater than the end value of the prior row
        //                    if (ll_Row != 1)
        //                    {
        //                        if (this.of_getitemany(ll_Row, asv_begcolumn) - lany_PriorValue != 1)
        //                        {
        //                            lb_ErrorFound = true;
        //                            break;
        //                        }
        //                    }
        //                    // 	get the end date for the next compare
        //                    lany_PriorValue = this.of_getitemany(ll_Row, asv_endcolumn);
        //                }
        //            }
        //            //  if an error was found, check if error service is running, if yes, retrieve error message text
        //            if (lb_ErrorFound)
        //            {
        //                if (IsValid(gnv_app.inv_Error))
        //                {
        //                    ls_ErrorMsg = gnv_app.inv_Error.of_GetMessageText("CS5-0008", ls_MsgParms);
        //                }
        //                else
        //                {
        //                    ls_ErrorMsg = this.of_getdisplayname(asv_begcolumn) + " / " + this.of_getdisplayname(asv_endcolumn) + " range cannot have any \'gaps\'.";
        //                }
        //                this.of_adderrormsg(ll_Row, System.Conver.ToInt32(idw_requestor.Describe(asv_begcolumn + ".ID")), li_SeverityLevel, ls_ErrorMsg);
        //                li_Return = -(1);
        //            }
        //            // 	if no error was found, the datawindow has no gaps, reset the sort sequence
        //            if (li_Return == 0)
        //            {
        //                idw_requestor.SetSort(ls_OldSort);
        //                idw_requestor.Sort();
        //            }
        //            idw_requestor.of_setredraw(true);
        //            return li_Return;
        //        }

        //        public virtual int of_checkforrange(int alv_row, int aiv_column, ref string asr_errormsg)
        //        {
        //            //  Object:			cs_n_cst_dwsrv_Validation
        //            //  Method:			of_CheckForRange
        //            //  Description:	this event will check a given row/column that has been specified as
        //            // 						"Begin" for range violations  ( comparison, gaps and or/overlaps)
        //            //  Arguments:	alv_Row - row that is being validated	
        //            // 						aiv_Column - index to the column name to check for violations
        //            // 						asr_ErrorMsg - string containing the error message supplied if any
        //            //  Returns:		0 if no error found, -1 if an error was found
        //            string ls_EndColumn;
        //            string ls_ColumnType;
        //            string ls_ValidationMsg;
        //            StringArray ls_MsgParms = new StringArray();
        //            object lany_EndValue;
        //            object lany_BeginValue;
        //            int li_Return;
        //            //  set the error message to empty before starting
        //            asr_errormsg = "";
        //            //  check the datatype of this column
        //            ls_ColumnType = Upper(idw_requestor.Describe(is_Column[aiv_column] + ".ColType"));
        //            //  get the end column to compare to
        //            ls_EndColumn = inv_String.of_getkeyvalue(idw_requestor.Describe(is_Column[aiv_column] + ".Tag"), "CompareEnd", ';');
        //            if (IsNull(ls_EndColumn) || ls_EndColumn <= "")
        //            {
        //                ls_EndColumn = inv_String.of_getkeyvalue(idw_requestor.Describe(is_Column[aiv_column] + ".Tag"), "CompareEndDate", ';');
        //            }
        //            //  get the begin and end values
        //            lany_BeginValue = this.of_getitemany(alv_row, is_Column[aiv_column]);
        //            lany_EndValue = this.of_getitemany(alv_row, ls_EndColumn);
        //            //  pass the substitution values to the string array
        //            ls_MsgParms[1] = this.of_getdisplayname(is_Column[aiv_column]);
        //            ls_MsgParms[2] = this.of_getdisplayname(ls_EndColumn);
        //            ls_MsgParms[3] = lany_BeginValue.ToString();
        //            ls_MsgParms[4] = lany_EndValue.ToString();
        //            //  only need to do this check if the values exists
        //            if (IsNull(lany_BeginValue) || IsNull(lany_EndValue))
        //            {
        //                return 0;
        //            }
        //            //  check for relational
        //            if (this.of_checkrelational(alv_row, is_Column[aiv_column], ls_EndColumn, lany_BeginValue, lany_EndValue, ls_ValidationMsg) < 0)
        //            {
        //                asr_errormsg = ls_ValidationMsg;
        //            }
        //            //  check for overlap
        //            if (Pos(Upper(idw_requestor.Describe(is_Column[aiv_column] + ".Tag")), "NOOVERLAP", 1) > 0)
        //            {
        //                if (this.of_checkforrangeoverlap(alv_row, is_Column[aiv_column], ls_EndColumn, lany_BeginValue, lany_EndValue) < 0)
        //                {
        //                    if (IsValid(gnv_app.inv_Error))
        //                    {
        //                        asr_errormsg = gnv_app.inv_error.of_GetMessageText("CS5-0009", ls_MsgParms);
        //                    }
        //                    else
        //                    {
        //                        asr_errormsg = this.of_getdisplayname(is_Column[aiv_column]) + " / " + this.of_getdisplayname(ls_EndColumn) + " range  (  " + lany_BeginValue.ToString() + " thru " + lany_EndValue.ToString() + ") overlaps with another row.";
        //                    }
        //                }
        //            }
        //            if (asr_errormsg != "")
        //            {
        //                li_Return = -(1);
        //            }
        //            else
        //            {
        //                li_Return = 0;
        //            }
        //            return li_Return;
        //        }

        //        public virtual int of_checkforrangeoverlap(int alv_row, string asv_begcolumn, string asv_endcolumn, object aany_begvalue, object aany_endvalue)
        //        {
        //            // 	Object:			cs_n_cst_dwsrv_Validation
        //            // 	Method:			of_CheckForRangeOverlap
        //            // 	Description:	this event will check a given row/column for range overlap violation
        //            // 	Arguments:		alv_Row - row that is being validated
        //            // 						asv_BegColumn - begin column
        //            // 						asv_EndColumn - end column
        //            // 						arv_BegValue - begin value
        //            // 						arv_EndValue - end value
        //            // 	Returns:			0 if no overlap was found, -1 if an overlap was found
        //            string ls_Find;
        //            string ls_ColumnType;
        //            int ll_Row;
        //            int ll_RowCount;
        //            int li_ParenPosition;
        //            int li_Return;
        //            // 	if there is no end column, there is nothing to do!
        //            if (IsNull(asv_endcolumn) || asv_endcolumn <= "")
        //            {
        //                return 0;
        //            }
        //            ls_ColumnType = Upper(idw_requestor.Describe(asv_begcolumn + ".ColType"));
        //            li_ParenPosition = TextUtil.Pos(ls_ColumnType, " ( ", 1);
        //            if (li_ParenPosition > 0)
        //            {
        //                ls_ColumnType = TextUtil.Left(ls_ColumnType, li_ParenPosition - 1);
        //            }
        //            // 	extract the begin and end values
        //            aany_begvalue = this.of_getitemany(alv_row, asv_begcolumn);
        //            aany_endvalue = this.of_getitemany(alv_row, asv_endcolumn);
        //            //  get the rows in the datawindow
        //            ll_RowCount = idw_requestor.RowCount;
        //            // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //            string TestExpr = ls_ColumnType;
        //            if (TestExpr == "DATETIME" || TestExpr == "TIMESTAMP")
        //            {
        //                ls_Find = " (  " + asv_begcolumn + " <= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_begvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_begvalue, "hh:mm:ss") + "\")) AND " + asv_endcolumn + " >= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_begvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_begvalue, "hh:mm:ss") + "\"))" + ") OR  ( " + asv_begcolumn + " <= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_endvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_endvalue, "hh:mm:ss") + "\")) AND " + asv_endcolumn + " >= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_endvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_endvalue, "hh:mm:ss") + "\")) " + ") OR  ( " + asv_begcolumn + " >= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_begvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_begvalue, "hh:mm:ss") + "\")) AND " + asv_begcolumn + " <= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_endvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_endvalue, "hh:mm:ss") + "\")) " + ") OR  ( " + asv_endcolumn + " >= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_begvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_begvalue, "hh:mm:ss") + "\")) AND " + asv_endcolumn + " <= System.Convert.ToDateTime (  System.Convert.ToDateTime (  \"" + String(aany_endvalue, "yyyy/mm/dd") + "\"), Time ( \"" + String(aany_endvalue, "hh:mm:ss") + "\")) " + ')';
        //            }
        //            else if (TestExpr == "NUMBER" || TestExpr == "LONG" || TestExpr == "INTEGER" || TestExpr == "UNSIGNEDINTEGER" || TestExpr == "UNSIGNEDLONG" || TestExpr == "DECIMAL" || TestExpr == "DOUBLE" || TestExpr == "REAL")
        //            {
        //                //  build the syntax that is to be used
        //                ls_Find = "  (  " + asv_begcolumn + " <= " + aany_begvalue.ToString() + " AND " + asv_endcolumn + " >= " + aany_begvalue.ToString() + ") OR  ( " + asv_begcolumn + " <= " + aany_endvalue.ToString() + " AND " + asv_endcolumn + " >= " + aany_endvalue.ToString() + ") OR  ( " + asv_begcolumn + " >= " + aany_begvalue.ToString() + " AND " + asv_begcolumn + " <= " + aany_endvalue.ToString() + ") OR  ( " + asv_endcolumn + " >= " + aany_begvalue.ToString() + " AND " + asv_endcolumn + " <= " + aany_endvalue.ToString() + ')';
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //            //  now do the finds for the range values, we know we will always
        //            //  find one, so we must "double pump" the find, if a second row is
        //            //  found, then we know there is an overlap
        //            ll_Row = idw_requestor.Find(ls_Find).Length;
        //            if (ll_Row < ll_RowCount && idw_requestor.Find(ls_Find).Length > 0)
        //            {
        //                li_Return = -(1);
        //            }
        //            else
        //            {
        //                li_Return = 0;
        //            }
        //            return li_Return;
        //        }

        //        public virtual int of_checkrelational(int alv_row, string asv_begcolumn, string asv_endcolumn, object aanyv_begvalue, object aanyv_endvalue, ref string asr_errormsg)
        //        {
        //            //  object:			cs_n_cst_dwsrv_validation
        //            //  Method:			of_CheckRelational
        //            //  Descripion:	this event will check the relational tag value, and check for range accordingly
        //            //  Arguments:	alv_Row - long containing the row to check
        //            // 						asv_BegColumn - string containing the starting column to check
        //            // 						asv_EndColumn - string containing the ending column to check
        //            // 						aanyv_BegValue - any containing the begin value for checking
        //            // 						aanyv_EndValue - any containing the end value for checking
        //            // 						asr_ErrorMsg - string passed by reference for any error message built
        //            //  Returns:		0 if relation is OK, -1 if not OK
        //            string ls_Relation;
        //            string ls_Find;
        //            string ls_ColumnType;
        //            StringArray ls_MsgParms = new StringArray();
        //            int li_Return;
        //            bool lb_ErrorFound = false;
        //            asr_errormsg = "";
        //            //  extract comparerelational tag value
        //            ls_Relation = Upper(inv_String.of_getkeyvalue(idw_requestor.Describe(asv_begcolumn + ".Tag"), "CompareRelational", ';'));
        //            if (IsNull(ls_Relation) || ls_Relation <= "")
        //            {
        //                ls_Relation = "<=";
        //            }
        //            // 	get the display names for the begin and end columns
        //            asv_begcolumn = this.of_getdisplayname(asv_begcolumn);
        //            asv_endcolumn = this.of_getdisplayname(asv_endcolumn);
        //            //  pass substitution values to the string array
        //            ls_MsgParms[1] = asv_begcolumn;
        //            ls_MsgParms[2] = aanyv_begvalue.ToString();
        //            ls_MsgParms[3] = ls_Relation;
        //            ls_MsgParms[4] = asv_endcolumn;
        //            ls_MsgParms[5] = aanyv_endvalue.ToString();
        //            //  check relation
        //            // PowerBuilder 'Choose Case' statement converted into 'if' statement
        //            unknown TestExpr = RightTrim(ls_Relation);
        //            if (TestExpr == '=' || TestExpr == "EQ" || TestExpr == "EQUAL" || TestExpr == "EQUALS")
        //            {
        //                if (aanyv_begvalue != aanyv_endvalue)
        //                {
        //                    lb_ErrorFound = true;
        //                }
        //            }
        //            else if (TestExpr == "<>" || TestExpr == "NE" || TestExpr == "NOT EQUAL" || TestExpr == "NOTEQUAL" || TestExpr == "NOT EQUALS" || TestExpr == "NOTEQUALS")
        //            {
        //                if (aanyv_begvalue == aanyv_endvalue)
        //                {
        //                    lb_ErrorFound = true;
        //                }
        //            }
        //            else if (TestExpr == '<' || TestExpr == "LESS" || TestExpr == "LESS THAN" || TestExpr == "LT")
        //            {
        //                if (aanyv_begvalue >= aanyv_endvalue)
        //                {
        //                    lb_ErrorFound = true;
        //                }
        //            }
        //            else if (TestExpr == "<=" || TestExpr == "LE" || TestExpr == "LESS THAN OR EQUAL TO" || TestExpr == "LESS EQUAL" || TestExpr == "LESSEQUAL")
        //            {
        //                if (aanyv_begvalue > aanyv_endvalue)
        //                {
        //                    lb_ErrorFound = true;
        //                }
        //            }
        //            else if (TestExpr == '>' || TestExpr == "GREATER" || TestExpr == "GT" || TestExpr == "GREATER THAN" || TestExpr == "GREATERTHAN")
        //            {
        //                if (aanyv_begvalue <= aanyv_endvalue)
        //                {
        //                    lb_ErrorFound = true;
        //                }
        //            }
        //            else if (TestExpr == ">=" || TestExpr == "GE" || TestExpr == "GREATER EQUAL" || TestExpr == "GREATER THAN OR EQUAL TO")
        //            {
        //                if (aanyv_begvalue < aanyv_endvalue)
        //                {
        //                    lb_ErrorFound = true;
        //                }
        //            }
        //            // 	if we found an error, build the message appropriately
        //            if (lb_ErrorFound)
        //            {
        //                if (IsValid(gnv_app.inv_Error))
        //                {
        //                    asr_errormsg = gnv_app.inv_Error.of_GetMessageText("CS5-0007", ls_MsgParms);
        //                }
        //                else
        //                {
        //                    asr_errormsg = asv_begcolumn + "  (  " + aanyv_begvalue.ToString() + " ) " + "must be " + ls_Relation + ' ' + asv_endcolumn + "  (  " + aanyv_endvalue.ToString() + " ).";
        //                }
        //                li_Return = -(1);
        //            }
        //            return li_Return;
        //        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;

namespace NZPostOffice.ODPS.Controls
{
    public partial class WValidationerror : FormBase
    {
        //public Cl_u_dwArray idw_Error = new Cl_u_dwArray();
        public List<URdsDw> idw_Error = new List<URdsDw>();

        private int ii_ErrorSeverity = 1;

        public WValidationerror()
        {
            InitializeComponent();
        }

        public override void open()
        {
            base.open();
            // 	Object:			cs_w_ValidationError
            // 	Method:			Open
            // 	Description:	setup the window accordingly
            // 	make sure the rowfocusindicator bitmap is loaded properly

            //?if (StaticVariables.gnv_app.of_GetUseIconsPath()) {
            //?    p_rowfocusindicator.PictureName = gnv_app.of_GetIconsPath() + p_rowfocusindicator.PictureName;
            //?}
            //?dw_error.SetRowFocusIndicator(p_rowfocusindicator);

            // 	force this child window always visible

            this.TopMost = true; //this.SetPosition(topmost!);
        }

        /*? public override void resize()
         {
             base.resize();
             // 	Object:			cs_w_ValidationError
             // 	Method:			Resize
             // 	Description:	position the datawindow accordingly

             dw_error.Resize(this.WorkSpaceWidth(), this.WorkSpaceHeight());
             dw_error.Move(1, 1);
         }*/

        public virtual int of_seterrors(NCstValidationattrib anvro_error)
        {
            // 	Object:			cs_w_ValidationError
            // 	Method:			of_SetErrors
            // 	Description:	populate the external datawindow with the errors that have been posted
            // 	Arguments:		anvro_Error - nonvisual user object of type n_cst_ValidationAttrib
            // 											that contains the errors to be displayed
            // 	Returns:			integer containing the number of errors loaded
            int li_MaxError;
            int li_Error;
            int li_dw;
            string ls_Import;
            string ls_Picture;
            // 	get the total number of errors to load
            li_MaxError = anvro_error.il_ErrorRow.Count;//.UpperBound;
            // 	make sure there are errors to load
            if (li_MaxError <= 0)
            {
                return 0;
            }
            // 	we need to know how many datawindow errors are currently displayed and we will add to it!
            li_dw = idw_Error.Count;//.UpperBound;
            // 	build the import string to add the rows
            // for (li_Error = 1; li_Error <= li_MaxError; li_Error++)
            for (li_Error = 0; li_Error < li_MaxError; li_Error++)
            {
                // 	determine what picture to load
                // PowerBuilder 'Choose Case' statement converted into 'if' statement
                int TestExpr = 0;//? anvro_error.ii_SeverityLevel[li_Error];
                if (TestExpr < ii_ErrorSeverity)
                {
                    ls_Picture = "excl.bmp";
                }
                else
                {
                    ls_Picture = "stop.bmp";
                }
                // 	build the import string containing the next error
                //?ls_Import = ls_Import + li_dw.ToString() + '~' + anvro_error.il_ErrorRow[li_Error].ToString() + '~' + anvro_error.ii_ErrorColumn[li_Error].ToString() + '~' + anvro_error.ii_SeverityLevel[li_Error].ToString() + '~' + anvro_error.is_ErrorMsg[li_Error].ToString() + '~';
                /*? if (StaticVariables.gnv_app.of_GetUseIconsPath())
                 {
                     ls_Import = ls_Import + gnv_app.of_GetIconsPath() + ls_Picture + "\r\n";
                 }
                 else
                 {
                     ls_Import = ls_Import + ls_Picture + "\r\n";
                 }
                 */
                // 	set the datawindow in error
                li_dw++;
                idw_Error[li_dw] = anvro_error.idw_WithError;
            }
            // 	now import the errors and sort the datawindow

            //?li_MaxError = dw_error.ImportString(ls_Import);
            //?dw_error.Sort();
            // 	reset the modified flags so as not to trigger a pending update message
            dw_error.ResetUpdate();
            //?dw_error.RowFocusChanged(1);
            return li_MaxError;
        }

        public virtual int of_clearerrors()
        {
            // 	Object:			w_ValidationError
            // 	Method:			of_ClearErrors
            // 	Description:	clear out the external datawindow for display of error messages
            // 	Arguments:		none
            // 	Returns:			0

            //? Cl_u_dwArray ldw_Null = new Cl_u_dwArray();

            // 	reset both the datawindows that have errors and the datawindow for displaying
            // 	the error messages
            dw_error.Reset();
            idw_Error = null;// ldw_Null;
            return 0;
        }

        public virtual bool of_geterrordisplayed()
        {
            // 	Object:			w_ValidationError
            // 	Method:			of_GetErrorDisplayed
            // 	Description:	returns TRUE if any errors are displayed, FALSE
            // 						if only warnings are displayed
            // 	Arguments:		none
            // 	Returns:			TRUE or FALSE

            if (dw_error.Find("SeverityLevel", ii_ErrorSeverity) >= 0)//  "System.Conver.ToInt32 (   SeverityLevel  ) > " + ii_ErrorSeverity).ToString().Length) > 0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int of_setwindowatbottom(FormBase awro_parent, bool abv_switch)
        {
            // 	Object:			cs_w_ValidationError
            // 	Method:			of_SetWindowAtBottom
            // 	Description:	set the window to display at the top  ( FALSE) or bottom  (  TRUE )
            // 	Arguments:		awro_Parent - readonly pointer to the window opening this popup
            // 						abv_Switch - boolean indicating whether to display at the bottom or top
            // 	Returns:			0
            int li_X;
            int li_Y;
            int li_Width;
            int li_Height;
            // 	position window within the parent
            // 	AJB - constant thing
            // IF awro_Parent.WindowType = Response! THEN
            // 	li_X = csConstant.WindowBorderWidth
            // ELSE
            // 	li_X = awro_Parent.Left  + csConstant.WindowBorderWidth
            // END IF
            // li_Width = awro_Parent.Width - csConstant.WindowBorderWidth * 2
            // li_Height = This.Height
            if (!(awro_parent.IsMdiChild) && !(awro_parent.IsMdiContainer))   // (awro_parent.WindowType == response!) 
            {
                li_X = 11;
            }
            else
            {
                li_X = awro_parent.Left + 11;
            }
            li_Width = awro_parent.Width - 11 * 2;
            li_Height = this.Height;
            if (abv_switch)
            {
                // 	li_Y = awro_Parent.Height - This.Height - csConstant.WindowBorderWidth
                li_Y = awro_parent.Height - this.Height - 11;
            }
            else
            {
                // 	li_Y = csConstant.WindowBorderWidth
                li_Y = 11;
            }
            this.of_setwindowproperties(li_X, li_Y, li_Width, li_Height);
            return 0;
        }

        public virtual int of_setwindowproperties(int aiv_x, int aiv_y, int aiv_width, int aiv_height)
        {
            // 	Object:			cs_w_ValidationError
            // 	Method:			of_SetWindowProperties
            // 	Description:	set the positioning of the error window
            // 	Arguments:		aiv_X - integer containing the x offset
            // 						aiv_Y - integer containing the y offset
            // 						aiv_Width - integer containing the width of the window
            // 						aiv_Height - integer containing the height of the window
            // 	Returns:			0

            //?this.resize(aiv_width, aiv_height);
            //?this.move(aiv_x, aiv_y);
            return 0;
        }

        public virtual int of_seterrorseverity(int aiv_severity)
        {
            // 	Object:			cs_w_ValidationError
            // 	Method:			of_SetErrorSeverity
            // 	Description:	set the level at which a message becomes an error vs. a warning
            // 	Arguments:		aiv_Severity - integer containing the severity level
            // 	Returns:			0
            ii_ErrorSeverity = aiv_severity;
            return 0;
        }

        public virtual bool of_checkparent(/*powerobject*/Control aporo_object)
        {
            // 	Object:			cs_w_ValidationErrors
            // 	Method:			of_CheckParent
            // 	Description:	determine the type of the passed powerobject, if we are on a userobject
            // 						we need to check to see if it's owner is a tab, if so, select the tab and keep
            // 						calling this function recursively
            // 	Arguments:		aporo_Object - powerobject passed by readonly to check
            // 	Returns:			TRUE if the parent is a user object, FALSE if not
            Control lpo_Parent;//powerobject lpo_Parent;
            TabControl luo_Parent;// UserObject luo_Parent;
            TabControl ltab_Parent;
            bool lb_Return = false;
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            /*?
            unknown TestExpr = aporo_object.TypeOf();
            if (TestExpr == userobject!) {
            {
                lb_Return = true;
                luo_Parent = aporo_object;
                lpo_Parent = luo_Parent.GetParent();
                // 	if it is a tab page, select the appropriate tab page
                if (lpo_Parent == TabControl)//.TypeOf() == tab!) {
                {
                    ltab_Parent = lpo_Parent;
                    ltab_Parent.SelectTab(luo_Parent);
                    lpo_Parent = ltab_Parent.GetParent();
                    // 	otherwise, we may be on a wizard, if so, display it
                }
                else if (luo_Parent.TriggerEvent("cs_Descendant") > 0)
                {
                    luo_Parent.of_DisplayWizardLevel();
                }
                // 	now call this function recursively to go up the chain to the top
                this.of_checkparent(lpo_Parent);
                //  if at a window level  ( or anything else, really not possible), we are done
            }
            else {
                lb_Return = false;
            }
             */
            return lb_Return;
        }

        public virtual bool of_displayparent(int alv_row)
        {
            // 	Object:			cs_w_ValidationErrors.dw_Error
            // 	Method:			of_DisplayParent
            // 	Description:	select all parent tab pages and/or wizard levels if appropriate
            // 	Arguments:		alv_Row - long containing the row that was clicked on
            // 	Returns:			TRUE if the object exists on a user object, FALSE if not
            Control lpo_Parent;// powerobject lpo_Parent;
            // 	determine if this datawindow is owned by a tab folder, if so, make sure the tab page is selected
            lpo_Parent = idw_Error[alv_row].Parent;//.GetParent();
            // 	call the function that will be called recursively to make sure that all tab pages are selected
            return this.of_checkparent(lpo_Parent);
        }

        public virtual void dw_error_rowfocuschanged(object sender, EventArgs e)
        {
            //?base.rowfocuschanged();
            // 	Object:			cs_w_ValidationErrors.dw_Error
            // 	Method:			RowFocusChanged
            // 	Description:	highlight the current row and advance to the window in error
            int ll_Row;
            int ll_ErrorRow;
            int li_ErrorColumn;

            int currentrow = dw_error.GetRow();
            // 	make sure there is a current row
            if (currentrow == null || currentrow < 0)
            {
                return;
            }
            // 	make sure the error has a datawindow associated with it, if not, nothing to do
            if (idw_Error[currentrow] == null)// (IsValid(idw_Error[currentrow]) == false) {
            {
                return;
            }
            // 	get the row and column in error, and then scroll to row and column in error
            ll_ErrorRow = dw_error.GetValue<int>(currentrow, "ErrorRow");//.GetItemNumber(currentrow, "ErrorRow");
            li_ErrorColumn = dw_error.GetValue<int>(currentrow, "ErrorColumn");//.GetItemNumber(currentrow, "ErrorColumn");
            // 	determine if this datawindow is owned by a tab folder, if so, make sure the tab page is selected
            if (this.of_displayparent(currentrow) == false)
            {
                //  if this datawindow is not on a userobject, check to see if it is a wizard object
                /*? if (idw_Error[currentrow].TriggerEvent("cs_Descendant") > 0)
                 {
                     idw_Error[currentrow].of_displaywizardlevel();
                 }*/
            }

            idw_Error[currentrow].SetCurrent(ll_ErrorRow); //idw_Error[currentrow].ScrollToRow(ll_ErrorRow);
            // 	if a column was specified, set focus to it
            if (li_ErrorColumn > 0)
            {
                //?idw_Error[currentrow].SetColumn(li_ErrorColumn);
            }
            // 	set the focus to the datawindow in error
            idw_Error[currentrow].Focus();
            // 	force this child window always visible
            this.TopMost = true;//parent.SetPosition(topmost!);

        }

        public virtual void dw_error_clicked(object sender, EventArgs e)
        {
            //?base.clicked();
            // 	Object:			cs_w_ValidationError.dw_Error
            // 	Method:			Clicked
            // 	Description:	fire the rowfocus changed event to set column in error
            //?dw_error.rowfocuschanged(row);
        }

        public virtual void constructor()
        {
            //?base.constructor();
            //// 	Object:			cs_w_ValidationError.dw_Error
            //// 	Method:			Constructor
            //// 	Description:	start the color manager service
            //if (StaticVariables.gnv_app != null)//(IsValid(gnv_app))
            //{
            //     if (IsValid(StaticVariables.gnv_app.inv_ColorManager))
            //     {
            //         dw_error.of_setcolormanager(true);
            //         dw_error.inv_ColorManager.of_setobjectcolors();
            //     }
            //}
        }

        /*?public virtual void pfc_prermbmenu() 
        {
            base.pfc_prermbmenu();
            // 	Object:			cs_w_ValidationError.dw_Error
            // 	Method:			pfc_PreRMBMenu
            // 	Description:	setup the appropriate menus
            am_dw.m_Table.m_Delete.Visible = true;
            am_dw.m_Table.m_Delete.Enabled = true;
            am_dw.m_Table.m_RestoreRow.Visible = true;
            am_dw.m_Table.m_RestoreRow.Enabled = true;
            am_dw.m_Table.m_Cut.Visible = false;
            am_dw.m_Table.m_Copy.Visible = false;
            am_dw.m_Table.m_Paste.Visible = false;
            am_dw.m_Table.m_SelectAll.Visible = false;
            am_dw.m_Table.m_Dash11.Visible = false;
            am_dw.m_Table.m_AddRow.Visible = false;
            am_dw.m_Table.m_Insert.Visible = false;
            am_dw.m_Table.m_Dash12.Visible = false;
            am_dw.m_Table.m_Columns.Visible = false;
            am_dw.m_Table.m_Functions.Visible = false;
            am_dw.m_Table.m_Operators.Visible = false;
            am_dw.m_Table.m_Values.Visible = false;
            am_dw.m_Table.m_Dash13.Visible = false;
            am_dw.m_Table.m_Debug.Visible = false;
            am_dw.m_Table.m_Properties.Visible = false;
            am_dw.m_Table.cs_m_4.Visible = false;
            am_dw.m_Table.m_CopyRow.Visible = false;
            am_dw.m_Table.cs_m_dw_3.Visible = false;
            am_dw.m_Table.m_Scroll.Visible = false;
            am_dw.m_Table.m_Sort.Visible = false;
            am_dw.m_Table.m_Filter.Visible = false;
            am_dw.m_Table.m_Query.Visible = false;
            am_dw.m_Table.m_-.Visible = false;
            am_dw.m_Table.m_Notes.Visible = false;
            am_dw.m_Table.m_Duplicate.Visible = false;
        }*/

        public virtual void pfc_restorerow()
        {
            //? base.pfc_restorerow();
            // 	Object:			cs_w_ValidationError.dw_Error
            // 	Method:			pfc_RestoreRow
            // 	Description:	this is an OVERRIDE of the ancestor script,
            // 						we want to restore the original value for the row clicked
            int ll_Row;
            int ll_ErrorRow;
            int li_ErrorColumn;
            object lany_Value;
            //?powerobject lpo_Parent;
            //?UserObject luo_Parent;
            TabControl ltab_Parent;
            // 	make sure there is a current row
            ll_Row = dw_error.GetRow();

            if (ll_Row == null || ll_Row <= 0)
            {
                return;// -(1);
            }
            // 	make sure the error has a datawindow associated with it, if not, nothing to do
            if (idw_Error[ll_Row] == null)// == false) {
            {
                return;// -(1);
            }
            // 	get the row and column in error, and then scroll to row and column in error
            ll_ErrorRow = dw_error.GetValue<int>(ll_Row, "ErrorRow");//.GetItemNumber(ll_Row, "ErrorRow");
            li_ErrorColumn = dw_error.GetValue<int>(ll_Row, "ErrorColumn");//.GetItemNumber(ll_Row, "ErrorColumn");
            // 	restore the original value if a column was specified, and set focus to it
            if (li_ErrorColumn > 0)
            {
                //?lany_Value = idw_Error[ll_Row].inv_Validation.of_getitemany(ll_ErrorRow, li_ErrorColumn, primary!, true);
                //?idw_Error[ll_Row].SetValue(ll_ErrorRow, li_ErrorColumn, lany_Value);
                //?idw_Error[ll_Row].SetColumn(li_ErrorColumn);
            }
            // 	set the focus to the datawindow in error
            idw_Error[ll_Row].Focus();
            // 	determine if this datawindow is owned by a tab folder, if so, make sure the tab page is selected

            /*?lpo_Parent = idw_Error[ll_Row].GetParent();
            // 	if the parent is a user object, there is a chance it is a tab page, if so, get it's parent
            if (lpo_Parent.TypeOf() == userobject!) {
                luo_Parent = lpo_Parent;
                lpo_Parent = luo_Parent.GetParent();
                // 	if we are on a tab page, display it
                if (lpo_Parent.TypeOf() == tab!) {
                    ltab_Parent = lpo_Parent;
                    ltab_Parent.SelectTab(luo_Parent);
                    // 	otherwise, we may be on a wizard, if so, display it
                }
                else if (luo_Parent.TriggerEvent("cs_Descendant") > 0) {
                    luo_Parent.of_DisplayWizardLevel();
                }
                //  if this datawindow is not on a userobject, check to see if it is a wizard object
            }
            else if (idw_Error[ll_Row].TriggerEvent("cs_Descendant") > 0) {
                idw_Error[ll_Row].of_displaywizardlevel();
            }
             */
            return;// 0;
        }
    }
}
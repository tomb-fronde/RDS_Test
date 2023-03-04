using System;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using Metex.Windows;
using NZPostOffice.RDS.Struct;
using NZPostOffice.Shared;
using System.Data.SqlClient;

namespace NZPostOffice.RDS.Controls
{

    public class WQuery : WResponse
    {
        #region Define
        public DataUserControl idw_Search;

        public SqlConnection it_Trans;

        public bool[] ib_ModRows = new bool[48];

        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        public Button cb_cancel;

        public Button cb_search;

        protected DataUserControlContainer dw_search;

        #endregion

        public WQuery()
        {
            this.InitializeComponent();
            this.Load += new EventHandler(WQuery_Load);
        }

        public virtual void WQuery_Load(object sender, EventArgs e)
        {
            base.open();
            //? Environment envCurrent;
            int lWidth = 0;
            int lLoop;
            int lObjectWidth;
            int lHeight = 0;
            int lObjectHeight;
            int lScreenHeight = 0;
            int lScreenWidth = 0;
            string sTab = "~";
            string sObjectList;
            string sObject;
            StSearch stParm = new StSearch();
            stParm = (StSearch)StaticMessage.PowerObjectParm;
            StaticMessage.StringParm = "NoSearch";
            idw_Search = stParm.query_datawindow.DataObject;
            it_Trans = new SqlConnection();
            it_Trans = stParm.query_transaction;
            //?dw_search.DataObject = idw_Search.DataObject;
            //? sObjectList = idw_Search.Describe("Datawindow.Objects");
            // Do While  sObjectList.Len() > 0
            // 
            // 	if TextUtil.Pos (  sObjectList, sTab ) > 0 then
            // 		sObject =  TextUtil.Left(  sObjectList, TextUtil.Pos ( sObjectList, sTab) - 1 )
            // 		sObjectList =  TextUtil.Mid (  sObjectList, TextUtil.Pos ( sObjectList, sTab) + 1 )
            // 	else
            // 		sObject = sObjectList
            // 		sObjectList = ""
            // 	end if
            // 
            // 	lObjectWidth = Metex.Common.Convert.ToInt32(  idw_Search.Describe (  sObject + ".x" ) ) + &
            // 	              Metex.Common.Convert.ToInt32(  idw_Search.Describe (  sObject + ".width" ) )
            // 
            // 	if lWidth < lObjectWidth Then lWidth = lObjectWidth
            // 
            // Loop
            lWidth = idw_Search.Width;
            lHeight = idw_Search.Height;
            dw_search.Width = lWidth;
            // sObjectList = idw_Search.Describe (  "Datawindow.Bands" )
            // 
            // Do While  sObjectList.Len() > 0
            // 
            // 	if TextUtil.Pos (  sObjectList, sTab ) > 0 then
            // 		sObject =  TextUtil.Left(  sObjectList, TextUtil.Pos ( sObjectList, sTab) - 1 )
            // 		sObjectList =  TextUtil.Mid (  sObjectList, TextUtil.Pos ( sObjectList, sTab) + 1 )
            // 	else
            // 		sObject = sObjectList
            // 		sObjectList = ""
            // 	end if
            // 
            // 	lObjectHeight = Metex.Common.Convert.ToInt32(  idw_Search.Describe (  "DataWindow." + sObject + ".Height" ) )
            // 
            // 	lHeight = lHeight + lObjectHeight
            // 
            // Loop
            // 
            dw_search.Height = lHeight;
            this.Width = dw_search.Location.X * 2 + dw_search.Size.Width + 9;
            // This.Height =  (  dw_Search.y * 2 ) &
            //            + dw_Search.Height &
            //            + cb_Search.Height &
            //            + st_label.Height &
            //            + PixelsToUnits (  12, yPixelsToUnits! ) &
            //            + PixelsToUnits (  Metex.Common.Convert.ToInt32(  ProfileString (  "win.ini", "Windows", "BorderWidth", "0" ) ) * 2, yPixelsToUnits! )
            // st_label.Text = g_system.w_active_sheet.st_label.text + "SR"
            cb_search.Left = dw_search.Location.Y + dw_search.Size.Height + 3;
            cb_cancel.Left = dw_search.Location.Y + dw_search.Size.Height + 3;
            cb_search.Top = dw_search.Location.X + Convert.ToInt32(dw_search.Size.Width / 2) - cb_search.Size.Width - 3;
            cb_cancel.Top = dw_search.Location.X + Convert.ToInt32(dw_search.Width / 2) + 3;
            // st_Label.y = cb_Search.y + cb_Search.Height + PixelsToUnits (  3, yPixelsToUnits! )
            // This.Height = st_label.y + st_Label.Height + PixelsToUnits (  Metex.Common.Convert.ToInt32(  ProfileString (  "win.ini", "Windows", "BorderWidth", "0" ) ) * 2, yPixelsToUnits! ) + PixelsToUnits (  25, yPixelsToUnits! )
            //? dw_search.Modify("Datawindow.QueryMode=Yes");
            dw_search.Focus();
            //? GetEnvironment(envCurrent);
            //?lScreenHeight = PixelsToUnits(envCurrent.ScreenHeight, ypixelstounits!);
            //?lScreenWidth = PixelsToUnits(envCurrent.ScreenWidth, xpixelstounits!);
            this.Left = Convert.ToInt32(lScreenWidth / 2) - Convert.ToInt32(this.Width / 2);
            this.Top = Convert.ToInt32(lScreenHeight / 2) - Convert.ToInt32(this.Height / 2);

        }

        #region Form Design
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.cb_cancel = new Button();
            this.cb_search = new Button();
            this.dw_search = new URdsDw();
            Controls.Add(cb_cancel);
            Controls.Add(cb_search);
            this.Text = "Query Mode";
            this.ControlBox = true;
            this.Size = new System.Drawing.Size(34, 255);
            this.Location = new System.Drawing.Point(147, 66);

            // 
            // cb_cancel
            // 
            cb_cancel.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.CancelButton = cb_cancel;
            cb_cancel.Text = "Cancel";
            cb_cancel.TabIndex = 3;
            cb_cancel.Location = new System.Drawing.Point(80, 184);
            cb_cancel.Size = new System.Drawing.Size(54, 22);
            cb_cancel.Click += new EventHandler(cb_cancel_clicked);

            // 
            // cb_search
            // 
            cb_search.Font = new System.Drawing.Font("MS Sans Serif", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_search;
            cb_search.Text = "&Search";
            cb_search.TabIndex = 2;
            cb_search.Location = new System.Drawing.Point(10, 184);
            cb_search.Size = new System.Drawing.Size(60, 22);
            cb_search.Click += new EventHandler(cb_search_clicked);

            // 
            // dw_search
            // 
            dw_search.VerticalScroll.Visible = true;
            dw_search.TabIndex = 1;
            dw_search.Location = new System.Drawing.Point(3, 4);
            dw_search.Size = new System.Drawing.Size(330, 170);
            dw_search.ItemChanged += new EventHandler(dw_search_ItemChanged);
            this.ResumeLayout();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Events

        public virtual int wf_check_dw()
        {
            string sText;
            int lColumnNumber;
            string sColumnName;
            int lColumnCount;
            int lRowCount;
            int lRowNumber;
            int lReturn;
            string sIsDDDW;
            DataUserControl dwChild;
            this.SuspendLayout();

            //? lColumnCount = Convert.ToInt32(dw_search.Describe("datawindow.column.count"));
            lRowCount = dw_search.RowCount;
            for (lRowNumber = 0; lRowNumber < lRowCount; lRowNumber++)
            {
                if (ib_ModRows[lRowNumber])
                {
                    /*? for (lColumnNumber = 1; lColumnNumber <= lColumnCount; lColumnNumber++) 
                     {
                        // dw_search.SetRow(lRowNumber);
                         dw_search.SetCurrent(lRowNumber);
                         if (Metex.Common.Convert.ToInt32(dw_search.Describe('#' + lColumnNumber.ToString() + ".tabsequence")) > 0 && Upper(Left(dw_search.Describe('#' + lColumnNumber.ToString() + ".ColType"), 4)) == "CHAR") {
                             if (dw_search.Describe('#' + lColumnNumber.ToString() + ".DDDW.Name") == '?') {
                                 dw_search.SetColumn(lColumnNumber);
                                 sText = dw_search.GetText();
                                 if (!(StaticVariables.gnv_app.of_isempty(sText))) {
                                     if (Upper(Left(sText, 5)) != "LIKE " && Upper(Left(sText, 4)) != "AND " && Upper(Left(sText, 4)) != "OR " && TextUtil.Pos ("<>=",  TextUtil.Left(sText, 1)) == 0) {
                                         sText = "LIKE " + sText;
                                         while (Pos(sText, '*') > 0) {
                                             sText =  TextUtil.Left(sText, TextUtil.Pos (sText, '*') - 1) + '%' +  TextUtil.Mid (sText, TextUtil.Pos (sText, '*') + 1);
                                         }
                                         if (Right(sText, 1) != '%') {
                                             sText = sText + '%';
                                         }
                                         dw_search.SetText(sText);
                                     }
                                 }
                             }
                         }
                     }*/
                }
            }
            this.ResumeLayout(false);
            return 0;
        }

        public virtual void cb_cancel_clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void cb_search_clicked(object sender, EventArgs e)
        {
            string sSQLSelect;
            string sSQLCounter;
            string sSQLStorage;
            int lCount = 0;
            dw_search.DataObject.AcceptText();
            wf_check_dw();
            dw_search.DataObject.AcceptText();
            /*? sSQLSelect = dw_search.GetSQLSelect();
             sSQLCounter = "select count ( *) " +  TextUtil.Mid (sSQLSelect, TextUtil.Pos (Upper(sSQLSelect), " FROM "));
             if (Pos(Upper(sSQLCounter), "ORDER BY") > 0) 
             {
                 sSQLCounter =  TextUtil.Left(sSQLCounter, TextUtil.Pos (Upper(sSQLCounter), "ORDER BY"));
             }
             if (Pos(Upper(sSQLCounter), "GROUP BY") > 0) {
                 sSQLCounter =  TextUtil.Left(sSQLCounter, TextUtil.Pos (Upper(sSQLCounter), "GROUP BY"));
             }
             if (Pos(Upper(sSQLCounter), " HAVING ") > 0) {
                 sSQLCounter =  TextUtil.Left(sSQLCounter, TextUtil.Pos (Upper(sSQLCounter), " HAVING "));
             }
             DECLARE search_counter DYNAMIC CURSOR FOR SQLSA;
             PREPARE SQLSA FROM :sSQLCounter USING it_Trans;
             OPEN search_counter
             FETCH search_counter INTO :lCount ;
             CLOSE search_counter
            
             if (lCount == 0) {
                 MessageBox.Show ( "Search Unsuccessful",parent.Title, MessageBoxButtons.OK, MessageBoxIcon.Information );
             }
             else {
                 sSQLSelect = f_Translate(sSQLSelect, '\"', "");
                 sSQLSelect = f_translate(sSQLSelect, '~', "");
                 sSQLStorage = idw_Search.Describe("DataWindow.Table.Selec_t");
                 idw_Search.Modify("DataWindow.Table.Selec_t=\"" + sSQLSelect + '\"');
                 idw_Search.Retrieve();
                 sSQLStorage = f_Translate(sSQLStorage, '\"', "");
                 idw_Search.Modify("DataWindow.Table.Selec_t=\"" + sSQLStorage + '\"');
                 parent.SetRedraw(false);
                 if (lCount > 1) {
                     dw_search.dataobject = idw_Search.DataObject + "_listing";
                     if (!(StaticVariables.gnv_app.of_isempty(dw_search.describe("datawindow.syntax")))) {
                         OpenWithParm(w_quick_select, idw_Search);
                     }
                 }
                 parent.ResumeLayout ( false );
                 CloseWithReturn(parent, "OK");
             }*/
        }

        public virtual void dw_search_ItemChanged(object sender, EventArgs e)
        {
            ib_ModRows[dw_search.GetRow()] = true;
        }
        #endregion
    }
}

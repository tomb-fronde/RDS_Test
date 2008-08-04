using System;
using System.Windows.Forms;
using NZPostOffice.Shared;
using Metex.Windows;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Controls;
using NZPostOffice.RDS.Windows.Ruralbase;
using NZPostOffice.RDS.Windows.Ruralrpt;

namespace NZPostOffice.RDS.Controls
{
    public class WReportAncestor : WAncestorWindow
    {
        #region Define

        public bool[] ib_ModRows = new bool[48];

        public int i_lPageFrom = 0;

        public int i_lPageTo = 0;

        public int i_lPageNo = 0;

        public bool ib_rowspending = false;

        public bool ib_Abort;



        public URdsDw dw_parameters;

        public Button cb_getreport;

        public URdsDw dw_report;

        public WPrintAbort w_print_abort = null;

        #endregion

        public WReportAncestor()
        {
            this.InitializeComponent();
        }
 
        #region Form Design      
        
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.dw_parameters = new URdsDw();
            this.cb_getreport = new Button();
            this.dw_report = new URdsDw();
            this.dw_report.Dock = DockStyle.Fill;
            Controls.Add(dw_parameters);
            Controls.Add(cb_getreport);
            Controls.Add(dw_report);
            this.Size = new System.Drawing.Size(570, 400);

            // 
            // st_label
            // 
            st_label.Top = 331;

            // 
            // dw_parameters
            // 
            dw_parameters.VerticalScroll.Visible = false;
            dw_parameters.Visible = false;
            dw_parameters.TabIndex = 1;
            dw_parameters.Location = new System.Drawing.Point(117, 197);
            dw_parameters.Size = new System.Drawing.Size(268, 49);
            dw_parameters.ItemChanged += new EventHandler(dw_parameters_itemchanged);

            // 
            // cb_getreport
            // 
            cb_getreport.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            this.AcceptButton = cb_getreport;
            cb_getreport.Text = "Retrieve";
            cb_getreport.Visible = false;
            cb_getreport.TabIndex = 2;
            cb_getreport.Location = new System.Drawing.Point(410, 211);
            cb_getreport.Size = new System.Drawing.Size(65, 22);
            cb_getreport.Click += new EventHandler(cb_getreport_clicked);

            // 
            // dw_report
            // 
            dw_report.TabIndex = 0;
            dw_report.Location = new System.Drawing.Point(5, 4);
            dw_report.Size = new System.Drawing.Size(550, 380);//323);
            //?dw_report.DataObject.RetrieveStart += new RetrieveEventHandler(dw_report_retrievestart);
            //?dw_report.DataObject.RetrieveEnd += new EventHandler(dw_report_retrieveend);
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

        #region Methods
        public override void resize(object sender, EventArgs args)
        {
            /*? base.resize();
            dw_report.Height = this.Height - 250;
            dw_report.Width = this.Width - 100;
            dw_parameters.Top  = dw_report.Top  + dw_report.Height + PixelsToUnits(2, ypixelstounits!);
            cb_getreport.Top  = dw_parameters.Top  + Int(dw_parameters.Height / 2 - cb_getreport.Height / 2); */
        }

        public virtual void ue_abort()
        {
            MessageBox.Show("Data retrieval has been cancelled", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (ib_rowspending)
            {
                //? dw_report.dbcancel();
            }
            //? dw_report.PrintCancel();
            ib_Abort = true;
            // Post close ( this)
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            Cursor.Current = Cursors.WaitCursor;
            this.Text = StaticMessage.StringParm;
            dw_report.SuspendLayout();
            //? dw_report.Modify("DataWindow.Print.Preview=Yes");
            if (w_print_abort == null)
            {
                //OpenWithParm(w_print_abort, this);
                StaticMessage.PowerObjectParm = this;
                w_print_abort = new WPrintAbort();
                w_print_abort.Show();
            }
            //TriggerEvent("ue_Report"); 
            ue_report();
        }

        public virtual void ue_report()
        {
        }

        public override void close()
        {
            base.close();
            if (w_print_abort != null)
            {
                w_print_abort.Close();
            }
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            if (w_print_abort != null)
            {
                w_print_abort.Close();
            }
            MSheet lm_Menu;
            if ((this.MainMenuStrip != null))
            {
                lm_Menu = this.m_sheet;
                lm_Menu.m_print.Enabled = true;
                lm_Menu.m_print.Visible = true;
                //lm_Menu.m_file.m_Print.ToolbarItemVisible = true;
            }
            dw_report.ResumeLayout();
        }

        public virtual void pfc_print()
        {
            //  16/04/2002 PBY Added. Call the wf_print ( ) method to print
            //  the report.
            wf_print();
            // dw_report.Print ( )
        }

        public override int wf_scroll(string aMethod)
        {
            // PowerBuilder 'Choose Case' statement converted into 'if' statement
            string TestExpr = aMethod;
            if (TestExpr == "LastPage")
            {
                //? dw_report.ScrollPriorPage();
            }
            else if (TestExpr == "NextPage")
            {
                //? dw_report.ScrollNextPage();
            }
            return 0;
        }

        public override int wf_printzoom()
        {
            int lZoomRatio = 0;
            //? lZoomRatio = Convert.ToInt32(dw_report.Describe("DataWindow.Print.Preview.Zoom"));
            //  OpenWithParm(w_preview_zoom, lZoomRatio);
            StaticMessage.IntegerParm = lZoomRatio;
            WPreviewZoom w_preview_zoom = new WPreviewZoom();
            w_preview_zoom.ShowDialog();
            if (StaticMessage.DoubleParm > 0)
            {
                lZoomRatio = Convert.ToInt32(StaticMessage.DoubleParm);
                //? dw_report.Modify("DataWindow.Print.Preview.Zoom=" + lZoomRatio).ToString();
            }
            return 0;
        }

        public virtual int wf_print()
        {
            int lLoop;
            int lCopies;
            string sPrintRange;
            int iReturn;
            /*? OpenWithParm(w_print_options, dw_report);
             if (StaticMessage.StringParm != "None") 
             {
                 sPrintRange = StaticMessage.StringParm;
                 i_lPageFrom = Convert.ToInt32(Left(sPrintRange, TextUtil.Pos (sPrintRange, ':') - 1));
                 sPrintRange =  TextUtil.Mid (sPrintRange, TextUtil.Pos (sPrintRange, ':') + 1);
                 i_lPageTo = Convert.ToInt32(Left(sPrintRange, TextUtil.Pos (sPrintRange, ';') - 1));
                 sPrintRange =  TextUtil.Mid (sPrintRange, TextUtil.Pos (sPrintRange, ';') + 1);
                 lCopies = Convert.ToInt32(sPrintRange);
                 for (lLoop = 1; lLoop <= lCopies; lLoop++) 
                 {
                     iReturn = dw_report.Print(true);
                     if (iReturn < 1) {
                         lLoop = lCopies + 1;
                     }
                 }
             }*/
            return 0;
        }

        public virtual void ue_deleteitem()
        {
            string sName;
            int lRow;
            int? lNull;
            string sNull;
            DateTime? dNull;
            lNull = null;
            sNull = null;
            dNull = null;
            /*? if (KeyDown(keydelete!)) {
                dw_parameters.SetText("");
            } */
        }

        public virtual void ue_setuprow()
        {
            //   Do Nothing
        }
    
        public virtual void ue_vscroll()
        {
            //   Do Nothing
        }

        public virtual void printpage()
        {
            //? base.printpage();
            int lActionCode = 0;
            i_lPageNo++;
            if (i_lPageNo < i_lPageFrom || i_lPageNo > i_lPageTo)
            {
                lActionCode = 1;
            }
            //? return lActionCode;
        }

        public virtual void retrieverow()
        {
            Application.DoEvents();
        }
 
        public virtual void printstart()
        {
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //? u_rds_dw.printstart();
            i_lPageNo = 0;
        }
        #endregion

        #region Events
        public virtual void dw_report_retrievestart(object sender, EventArgs e)
        {
            //? base.retrievestart();
            ib_rowspending = true;
        }

        public virtual void dw_report_retrieveend(object sender, EventArgs e)
        {
            //? base.retrieveend();
            ib_rowspending = false;
            if (w_print_abort != null)
            {
                w_print_abort.Close();
            }
        }
    
        public virtual void cb_getreport_clicked(object sender, EventArgs e)
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
            string sSQLSelect;
            this.SuspendLayout();
            dw_parameters.DataObject.AcceptText();
            /*?
            lColumnCount = Metex.Common.Convert.ToInt32(dw_parameters.Describe("datawindow.column.count"));
            lRowCount = dw_parameters.RowCount;
            for (lRowNumber = 1; lRowNumber <= lRowCount; lRowNumber++) {
                if (ib_ModRows[lRowNumber]) {
                    for (lColumnNumber = 1; lColumnNumber <= lColumnCount; lColumnNumber++) {
                        if (Metex.Common.Convert.ToInt32(dw_parameters.Describe('#' + lColumnNumber.ToString() + ".tabsequence")) > 0 && Upper(Left(dw_parameters.Describe('#' + lColumnNumber.ToString() + ".ColType"), 4)) == "CHAR") {
                            if (dw_parameters.Describe('#' + lColumnNumber.ToString() + ".DDDW.Name") == '?') {
                                dw_parameters.SetColumn(lColumnNumber);
                                sText = dw_parameters.GetText();
                                if (!(StaticVariables.gnv_app.of_isempty(sText))) {
                                    if (Upper(Left(sText, 5)) != "LIKE " && Upper(Left(sText, 4)) != "AND " && Upper(Left(sText, 4)) != "OR " && TextUtil.Pos ("<>=",  TextUtil.Left(sText, 1)) == 0) {
                                        sText = "LIKE " + sText;
                                        while (Pos(sText, '*') > 0) {
                                            sText =  TextUtil.Left(sText, TextUtil.Pos (sText, '*') - 1) + '%' +  TextUtil.Mid (sText, TextUtil.Pos (sText, '*') + 1);
                                        }
                                        if (Right(sText, 1) != '%') {
                                            sText = sText + '%';
                                        }
                                        dw_parameters.SetText(sText);
                                    }
                                }
                            }
                        }
                    }
                }
            } 
            sSQLSelect = dw_parameters.GetSQLSelect();
            sSQLSelect = f_translate(sSQLSelect, '\"', "");
            dw_report.Modify("DataWindow.Table.Selec_t=\"" + sSQLSelect + '\"'); */
            dw_report.Retrieve(new object[] { });
            this.ResumeLayout();
        }
 
        public virtual void dw_parameters_itemchanged(object sender, System.EventArgs e)
        {
            // WARNING: Call not Isimmediate Ancestor Event : change manually
            //? u_rds_dw.itemchanged();
            // ib_ModRows[ This.GetRow ( ) ] = True
        }

        #endregion
    }

    public struct WstReportInstances
    {
        public int WinOrigHeight;

        public int dworigheight;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.DataControls.OdpsInvoice;
using System.IO;
using NZPostOffice.ODPS.Menus;

namespace NZPostOffice.ODPS.Windows.OdpsInvoice
{
    public partial class WInvoice : WMaster
    {
        // TJB  RPCR_054  June-2013
        // Removed unused cb_export and cb_save
        // Changed format of rate in piece rate sections:
        //     REDwInvoiceDetailPaymentPrDetailcp.rpt
        //     REDwInvoiceDetailPaymentPrDetailkm.rpt
        //  Now handle multiple types within supplier.
        //
        // TJB  RPCR_056  June-2013
        // Added allowance breakdown section.
        // See
        //     REDwInvoiceDetailAllowanceBreakdown.rpt
        //
        // TJB  12-Sep-2012
        // Changed format of rate in piece rate sections.
        // See
        //     REDwInvoiceDetailPaymentPrDetailcp.rpt
        //     REDwInvoiceDetailPaymentPrDetailkm.rpt
        //     REDwInvoiceDetailPaymentPrDetailxp.rpt
        //     REDwInvoiceDetailPaymentPrDetailpp.rpt
        //
        // TJB RPCR_012 July-2010
        // Adjusted size of screen and fixed resizing

        #region Define
        public bool ib_canexit = true;

        public MOdpsReport m_report;

        #endregion

        public WInvoice()
        {
            m_report = new MOdpsReport(this);
            InitializeComponent();

            //TJB Jan-2009:  Added Dataobject definition (missing ??)
            //               Need to fix resizability 
            dw_1.DataObject = new DwInvoiceHeaderv5();
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();
            object any_var = null;
            DateTime? sdate;
            DateTime? edate;
            int? lcontractor;
            int? lcontract;
            int? lregion;
            string sname;
            int? li_ctKey;
            Cursor.Current = Cursors.WaitCursor;
            // 	start the resize service
            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "Startdate", ref any_var, "Y");
            sdate = Convert.ToDateTime(any_var);

            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "Enddate", ref any_var, "Y");
            edate = Convert.ToDateTime(any_var);

            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "contractor", ref any_var, "Y");
            lcontractor = Convert.ToInt32(any_var);

            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "contract", ref any_var, "Y");
            lcontract = Convert.ToInt32(any_var);

            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "region", ref any_var, "Y");
            lregion = Convert.ToInt32(any_var);

            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "name", ref any_var, "Y");
            sname = Convert.ToString(any_var);

            StaticVariables.gnv_app.inv_ObjectMsg.of_getmsg("w_invoice", "ctKey", ref any_var, "Y");
            li_ctKey = Convert.ToInt32(any_var);

            dw_1.SuspendLayout();
            ((DwInvoiceHeaderv5)dw_1.DataObject).Retrieve(sdate, edate, lcontractor, lcontract, lregion, sname, li_ctKey);
            dw_1.ResumeLayout();
            // Messagebox.Show(dw_1.describe("dpr.height"),"")
        }

        public virtual void pfc_pagesetup()
        {
            //? return dw_1.pfc_pagesetup();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // setpointer(hourglass!)
            // 
            // any any_var
            // Date edate
            // long lcontractor, lcontract, lregion
            // string sname
            // 
            // //	start the resize service
            // This.of_SetResize( TRUE )
            // 
            // gnv_App.inv_ObjectMsg.of_GetMsg('w_invoice','Enddate',any_var,'Y')
            // edate= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg('w_invoice','contractor',any_var,'Y')
            // lcontractor= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg('w_invoice','contract',any_var,'Y')
            // lcontract= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg('w_invoice','region',any_var,'Y')
            // lregion= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg('w_invoice','name',any_var,'Y')
            // sname= any_var
            // 
            // 
            // dw_1.settransobject(sqlca)
            // dw_1.retrieve(edate,lcontractor,lcontract,lregion,sname)
            // 
            // 
            // //messagebox("",dw_1.describe("dpr.height"))
            // 
        }

        public override void open()
        {
            base.open();
            // m_odps_report m_menu
            // m_menu=menuid
            // if isvalid(m_menu) then
            // 	if f_hqaccess()  then
            // 		m_menu.m_reports.m_post-taxadjustment.visible=true
            // 		m_menu.m_reports.m_volumesvalues.visible=true
            // 	else
            // 		m_menu.m_reports.m_post-taxadjustments2.visible=true
            // 		m_menu.m_reports.m_volumesvalues2.visible=true
            // 	end if
            // end if
            // 
        }

        public virtual void constructor()
        {
            //? dw_1.of_setreport(true);
            //? dw_1.of_setprintpreview(true);
        }

        public virtual void retrieverow()
        {
            //? SetMicroHelp(RowCount().ToString() + " invoices retrieved");
        }

        public virtual void pfc_printpreview()
        {
            return;
        }

        #region Events

        public override void resize(object sender, EventArgs args)
        {
            base.resize(this, new EventArgs());
            //dw_1.Height = this.Height - 100;
            //dw_1.Width = this.Width - 20;
        }

        public virtual void dw_1_retrieveend(object sender, EventArgs e)
        {
            ib_canexit = true;
        }

        #endregion
    }
}
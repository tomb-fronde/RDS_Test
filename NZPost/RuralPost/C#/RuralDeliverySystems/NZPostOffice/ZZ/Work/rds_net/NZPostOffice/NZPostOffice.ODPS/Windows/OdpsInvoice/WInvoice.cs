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
            this.cb_save.Visible = false;
            this.cb_save.Enabled = false;
            //? m_odps_report = new NZPostOffice.ODPS.Menus.MOdpsReport(this);
            //? m_odps_report_menu.SetFunctionalPart(m_odps_report);
            //? m_odps_report_toolbar.SetFunctionalPart(m_odps_report);
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
            //? dw_1.settransobject(StaticVariables.sqlca);

            dw_1.SuspendLayout();
            ((DwInvoiceHeaderv5)dw_1.DataObject).Retrieve(sdate, edate, lcontractor, lcontract, lregion, sname, li_ctKey);
            dw_1.ResumeLayout();
            // messagebox ( "",dw_1.describe ( "dpr.height"))
        }

        public virtual void pfc_pagesetup()
        {
            //? return dw_1.pfc_pagesetup();
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            // setpointer ( hourglass!)
            // 
            // any any_var
            // Date edate
            // long lcontractor, lcontract, lregion
            // string sname
            // 
            // //	start the resize service
            // This.of_SetResize  (  TRUE )
            // 
            // gnv_App.inv_ObjectMsg.of_GetMsg ( 'w_invoice','Enddate',any_var,'Y')
            // edate= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg ( 'w_invoice','contractor',any_var,'Y')
            // lcontractor= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg ( 'w_invoice','contract',any_var,'Y')
            // lcontract= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg ( 'w_invoice','region',any_var,'Y')
            // lregion= any_var
            // gnv_App.inv_ObjectMsg.of_GetMsg ( 'w_invoice','name',any_var,'Y')
            // sname= any_var
            // 
            // 
            // dw_1.settransobject ( sqlca)
            // dw_1.retrieve ( edate,lcontractor,lcontract,lregion,sname)
            // 
            // 
            // //messagebox ( "",dw_1.describe ( "dpr.height"))
            // 
        }

        public override void open()
        {
            base.open();
            // m_odps_report m_menu
            // m_menu=menuid
            // if isvalid ( m_menu) then
            // 	if f_hqaccess ( )  then
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
            //cb_save.Location = new Point(557, dw_1.Location.Y + dw_1.Height + 20);
            //cb_export.Location = new Point(473, dw_1.Location.Y + dw_1.Height + 20);
        }

        public virtual void cb_export_clicked(object sender, EventArgs e)
        {
            //  TJB  SR4685  May 2006    - New -
            /*  ----------------------- Debugging ----------------------- //
            long		ll_rc, ll_temp, ll_rows, ll_row, ll_rowcount
            string	ls_name, ls_dwo, ls_bands, ls_objects, ls_type, ls_temp
            string	ls_rows, ls_dw, ls_rowcount
            datawindowchild	ldwc_dw
            // ls_name    = dw_1.describe ( 'datawindow.Name')
            // ls_dwo     = dw_1.describe ( 'datawindow.DataWindowObject')
            // ls_bands   = dw_1.describe ( 'datawindow.Bands')
            // ls_objects = dw_1.describe ( 'datawindow.Objects')
            // 
            // if isnull ( ls_dwo)     then ls_dwo     = 'Null'
            // if isnull ( ls_name)    then ls_name    = 'Null'
            // if isnull ( ls_bands)   then ls_bands   = 'Null'
            // if isnull ( ls_objects) then ls_objects = 'Null'
            // 
            // messagebox ( 'w_invoice.cb_export.clicked',  &
            // 		'Dwo     = '+ls_dwo+'\n'       &
            // 		+'Name    = '+ls_name+'\n'     &
            // 		+'Bands   = '+ls_bands+'\n'    &
            // 		+'Objects = '+ls_objects+'\n'  )
            ll_rowcount = dw_1.RowCount
            ls_rows = ll_rowcount.ToString()
            if isnull ( ll_rowcount) then ls_rows = 'Null'
            ls_rowcount = "Report rowcount = "+ls_rows+'\n'
            MessageBox.Show (  ls_rowcount ,  'w_invoice.cb_export.clicked' )
            string	ds_row
            string	ds_con_no, ds_con_title, ds_gst_no, ds_sup_no
            string	ds_sup_name, ds_sup_address, ds_inv_no, ds_end_date
            string	ds_nat_address, ds_nat_gst
            string	ds_rows, ds_prd_date, ds_prt_code
            string	ds_prd_qty, ds_prd_rate, ds_prd_cost, ds_tot_cost
            Boolean	lb_test
            for ll_row = 1 to ll_rowcount
            ds_row = ll_row.ToString()
            ds_con_no   = dw_1.Object.contract_no[ll_row].ToString()
            ds_end_date = dw_1.Object.compute_2[ll_row].ToString()
            ds_sup_name = dw_1.Object.compute_4[ll_row].ToString()
            if isnull ( ds_con_no)   then ds_con_no   = 'Null'
            if isnull ( ds_end_date) then ds_end_date = 'Null'
            if isnull ( ds_sup_name) then ds_sup_name = 'Null'
            MessageBox.Show (  & '========== New Invoice ==========\n'  & +'Row = '+ds_row+'\n'           & +'Contract = '+ds_con_no+'\n'   & +'End date = '+ds_end_date+'\n' & +'Supplier = '+ds_sup_name      ,  'w_invoice.cb_export.clicked' )
            ls_temp = ''
            ls_dw = 'dw_2'
            //ll_rc =  dw_1.getChild ( ls_dw,ldwc_dw)
            ls_temp = dw_1.Object.dw_2.visible.ToString()
            ls_temp = dw_1.Object.dw_2.height.ToString()
            ls_temp = dw_1.Object.dw_2.width.ToString()
            ls_temp = dw_1.Object.dw_2.Left.ToString()
            ls_temp = dw_1.Object.dw_2.Top.ToString()
            if dw_1.Object.dw_2[ll_row].Object.rowcount[1] > 0 then
            ds_rows     = dw_1.Object.dw_2[ll_row].Object.rowcount[1].ToString()
            ds_prd_date = dw_1.Object.dw_2[ll_row].Object.prd_date_1[1].ToString()
            ds_prt_code = dw_1.Object.dw_2[ll_row].Object.prt_code[1].ToString()
            ds_prd_qty  = dw_1.Object.dw_2[ll_row].Object.prd_quantity[1].ToString()
            ds_prd_rate = dw_1.Object.dw_2[ll_row].Object.rate[1].ToString()
            ds_prd_cost = dw_1.Object.dw_2[ll_row].Object.cost[1].ToString()
            ds_tot_cost = dw_1.Object.dw_2[ll_row].Object.compute_1[1].ToString()
            else
            ds_rows     = 'Null'
            ds_prd_date = 'Null'
            ds_prt_code = 'Null'
            ds_prd_qty  = 'Null'
            ds_prd_rate = 'Null'
            ds_prd_cost = 'Null'
            ds_tot_cost = 'Null'
            end if
            if isnull ( ds_rows)     then ds_rows     = 'Null'
            if isnull ( ds_prd_date) then ds_prd_date = 'Null'
            if isnull ( ds_prt_code) then ds_prt_code = 'Null'
            if isnull ( ds_prd_qty)  then ds_prd_qty  = 'Null'
            if isnull ( ds_prd_rate) then ds_prd_rate = 'Null'
            if isnull ( ds_prd_cost) then ds_prd_cost = 'Null'
            if isnull ( ds_tot_cost) then ds_tot_cost = 'Null'
            MessageBox.Show (  & '+++ Kiwimail +++\n'        & +'Rows  = '+ds_rows+'\n'     & +'Date  = '+ds_prd_date+'\n' & +'Code  = '+ds_prt_code+'\n' & +'Qty   = '+ds_prd_qty +'\n' & +'Rate  = '+ds_prd_rate+'\n' & +'Cost  = '+ds_prd_cost+'\n' & +'Total = '+ds_tot_cost+'\n' & ,  'w_invoice.cb_export.clicked' )
            next
            // ---------------------------------------------------------  */
        }

        public virtual void dw_1_retrieveend(object sender, EventArgs e)
        {
            ib_canexit = true;
        }

        public virtual void cb_save_clicked(object sender, EventArgs e)
        {
            string sInitFileName;
            string sReturnedFIleName;
            //if (saveFileDialog.GetFileSaveName("Save to File", sInitFileName, sReturnedFIleName, "PSR", "PSR Files  ( *.PSR),*.PSR") == 1) 
            DialogResult li_ret;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save to File";
            saveFileDialog.DefaultExt = "PSR";
            saveFileDialog.Filter = "PSR Files (*.PSR)|*.PSR";
            li_ret = saveFileDialog.ShowDialog();
            sInitFileName = saveFileDialog.FileName;
            sReturnedFIleName = sInitFileName.Substring(sInitFileName.LastIndexOf("\\") + 1);
            saveFileDialog.AddExtension = true;
            if (li_ret == DialogResult.OK)
            {
                //if (FileExists(sReturnedFIleName)) 
                if (File.Exists(sInitFileName))
                {
                    if (MessageBox.Show("Do you want to replace the existing file " + sReturnedFIleName + '?'
                                       , "Save to File"
                                       , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) 
                        == DialogResult.Yes)
                    {
                        //? dw_1.saveas(sReturnedFIleName, psreport!, true);
                        //FileStream fs = new FileStream(sInitFileName, FileMode.Create,FileAccess.Write);
                        //StreamWriter a = new StreamWriter(fs);   
                    }
                }
                else
                {
                    //? dw_1.saveas(sReturnedFIleName, psreport!, true);
                }
            }
        }
        #endregion
    }
}
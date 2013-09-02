using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Windows.OdpsLib;
using Microsoft.Win32;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.Entity.OdpsInvoice;
using NZPostOffice.ODPS.DataControls.OdpsInvoice;
using System.IO;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.ODPS.Controls;

namespace NZPostOffice.ODPS.Windows.OdpsInvoice
{
    public partial class WInvoiceSearch : WCriteriaSearch
    {
        // TJB  Release Fixup Aug-2013
        // Copied allowance breakdown retrieval to cb_export_clicked from 
        // cb_open_clicked
        //
        // TJB  RPCR_054 June-2013: NEW
        // of_process_detail_piecerates adapted from of_process_detail_km
        // Consolidate code to simplify of_process_detail_piecerates
        //   output_piecerate_detail
        //   output_piecerate_total
        //
        // TJB  RPCR_056  July-2013  NEW
        // of_process_allowance_breakdown
        // Process the allowance breakdown for this invoice
        //
        // TJB  RPCR_056  June-2013
        // Get invoice allowance details into temporary file
        // (ODPSDataService.GetODDWSInvoiceAllowanceDetail)
        //
        // TJB  RPCR_012 July-2010
        // Added sSupplier code to of_process_detail{km,cp,pp,xp}

        #region Define

        public FileStream ii_file;
        public string is_contract = String.Empty;
        public ODPSDataService dataService = null;

        #endregion

        public WInvoiceSearch()
        {
            InitializeComponent();

            dw_search.DataObject = new DwInvoiceSearch();
            dw_search.DataObject.BorderStyle = BorderStyle.Fixed3D;
            dw_results.DataObject = new DwInvoiceSearchResults();
            dw_results.DataObject.BorderStyle = BorderStyle.Fixed3D;

            ((NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).LostFocus += new EventHandler(dw_search_itemchanged);
            ((NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).KeyPress += new KeyPressEventHandler(WInvoiceSearch_KeyPress);
        }

        public override void pfc_preopen()
        {
            base.pfc_preopen();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("Printers\\Connections");//RegistryKeys("HKEY_CURRENT_USER\\Printers\\Connections", ls_subkeylistNT);
            RegistryKey rk95 = Registry.CurrentConfig.OpenSubKey("System\\CurrentControlSet\\Control\\Print\\Printers");//RegistryKeys("HKEY_CURRENT_CONFIG\\System\\CurrentControlSet\\Control\\Print\\Printers", ls_subkeylist95);
            string[] ls_subkeylistNT = null;
            if (rk != null)
            {
                ls_subkeylistNT = rk.GetValueNames(); //string[] ls_subkeylistNT = rk.GetSubKeyNames();
            }

            string[] ls_subkeylist95 = null;
            if (rk95 != null)
            {
                ls_subkeylist95 = rk95.GetValueNames();
            }

            if ((ls_subkeylistNT == null || ls_subkeylistNT.Length == 0) && (ls_subkeylist95 == null || ls_subkeylist95.Length == 0)) //(ls_subkeylistNT.UpperBound == 0 && ls_subkeylist95.UpperBound == 0) 
            {
//pp!                MessageBox.Show("No printer connections set. Invoice(s) will not be retrieved properly"
//pp!                               , "Warning"
//pp!                               , MessageBoxButtons.OK
//pp!                               , MessageBoxIcon.Information);
            }
            this.of_setaccess("Regional");

            this.Text = StaticMessage.StringParm;
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            DateTime dStart;
            DateTime dEnd;
            DateTime ld_invoice_date;
            string sStartDay;
            string sStartMonth;
            string sStartYear;
            string sEndDay;
            string sEndMonth;
            string sEndYear;
            int li_start_day;
            int li_start_month;
            int li_start_year;
            int li_end_day;
            int li_end_month;
            int li_end_year;
            //  TJB  SR4667  June 2005
            //  Change start/end search dates to follow invoice dates
            //  (21 - 20 of each month instead of calendar months)
            //  TJB  SR4667  July 2005
            //  Use the most-recent invoice date to set the default dates
            // select max(invoice_date) into :ld_invoice_date from odps.payment using SQLCA;

            //  The invoice date is the end date of the period
            //  and is *always* the 20th of the month
            dataService = ODPSDataService.GetMaxPayment();
            ld_invoice_date = dataService.LdInvoiceDate;
            li_end_day = ld_invoice_date.Day;
            li_end_month = ld_invoice_date.Month;
            li_end_year = ld_invoice_date.Year;
            //  The start date is one month earlier than the end date
            //  and is *always* the 21st of the month.  
            //  WARNING: This code will break if the invoice date is 
            //  changed to the end of the month!
            li_start_day = li_end_day + 1;
            li_start_month = li_end_month - 1;
            li_start_year = li_end_year;
            if (li_start_month < 1)
            {
                li_start_month = 12;
                li_start_year = li_start_year - 1;
            }
            sStartDay = li_start_day.ToString();
            sStartMonth = li_start_month.ToString();
            sStartYear = li_start_year.ToString();
            sEndDay = li_end_day.ToString();
            sEndMonth = li_end_month.ToString();
            sEndYear = li_end_year.ToString();
            dStart = System.Convert.ToDateTime(sStartYear + "/" + sStartMonth + "/" + sStartDay);
            dEnd = System.Convert.ToDateTime(sEndYear + "/" + sEndMonth + "/" + sEndDay);

            dw_search.SetValue(0, "start_date", dStart);
            dw_search.SetValue(0, "end_date", dEnd);
            dw_search.SetValue(0, "owner_driver", "");

            dw_search.DataObject.BindingSource.CurrencyManager.Refresh(); //added by jlwang
            // datawindowchild dwc
            // 
            // if f_hqaccess() then
            // 	dw_search.getchild("region_id",dwc)
            // 	dwc.insertrow(1)
            // 	dwc.setitem(1,"region_id",0)
            // 	dwc.setitem(1,"rgn_name","<All Regions>")
            // 	dw_search.setitem(1,"region_id",0)
            // 
            // else
            // 	if f_regreportaccess() then
            // 		dw_search.setitem(1,"region_id",f_getregion())
            // 		dw_search.Modify("region_id.protect=1")
            //   	   dw_search.object.region_id.background.color=rgb(192,192,192)
            // 	end  if
            // end if
            //  PBY 03/09/2002 SR#4449

            dw_search.of_filter_regions("ODPS Invoice");
            if (this.of_close())
                this.Close();
        }

        public override void ue_search()
        {
            base.ue_search();
            DateTime? ldt_sdate;
            DateTime? ldt_edate;
            string ls_name;
            string ls_contractNo;
            int? ll_region;
            int? ll_ctKey;
            int ll_contractNo = 0;
            int ll_resultRows;

            ldt_sdate = dw_search.GetValue<DateTime?>(0, "start_date");
            ldt_edate = dw_search.GetValue<DateTime?>(0, "end_date");
            ls_name = dw_search.GetValue<string>(0, "owner_driver");
            ll_region = dw_search.GetValue<int?>(0, "region_id");
            //  TJB SR4639
            //  Added contract number and type to selcetion criteria
            //  See stored procedure
            //OD_dws_ownerdriver_search_region

            messagearea.Text = "";

            ls_contractNo = dw_search.GetValue<string>(0, "contract_no");
            if (ls_contractNo != null && ls_contractNo.Length > 0)
            {
                if (StaticFunctions.IsNumber(ls_contractNo))
                {
                    ll_contractNo = StaticFunctions.ToInt32(ls_contractNo).Value;
                }
                else
                {
                    MessageBox.Show("Contract No must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dw_search.SetValue(0, "contract_no", "");
                    return;
                }
            }

            ll_ctKey = dw_search.GetValue<int?>(0, "ct_key");
            ((DwInvoiceSearchResults)dw_results.DataObject).Retrieve(ls_name, ll_region, ldt_sdate, ldt_edate, ll_contractNo, ll_ctKey);
            ll_resultRows = dw_results.RowCount;
            if (ll_resultRows == 1)
            {
                MessageBox.Show("No contracts found for search criteria", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dw_results.DataObject.DeleteItemAt(0);
            }
            else
            {
                ll_resultRows = ll_resultRows - 1;
                if (ll_resultRows > 1)
                {
                    messagearea.Text = ll_resultRows.ToString() + " contracts found";
                }
                else
                {
                    messagearea.Text = ll_resultRows.ToString() + " contract found";
                }
            }
        }

        #region Methods

        public virtual void pfc_validation(object[] apo_control)
        {
            //MessageBox.Show("PFC_VALIDATION", "wInvoiceSearch"
            //               , MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public virtual string of_display(object aa_value)
        {
            //  TJB  SR4685  May/2006    - New -
            //  Convert a value to a string for display
            //  Return 'Null' if the value is null
            string ls_temp;
            ls_temp = aa_value.ToString();
            if (aa_value == null)
            {
                ls_temp = "Null";
            }
            return ls_temp;
        }

        public virtual int of_process_detail_piecerates(int? al_invid)
        {
            //  TJB  RPCR_054 June-2013: NEW
            //  of_process_detail_piecerates adapted from of_process_detail_km

            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            int? ll_prd_qty;
            DateTime? ld_prd_date;
            string ls_prt_code;
            string sSupplier, sSupplier2;
            string ls_temp;
            decimal? ldc_prd_rate;
            decimal? ldc_prd_cost;
            decimal? ldc_tot_cost;
            int nPrsKey, nPrsKey2, rc;

            ((DwInvoiceDetailPaymentPiecerates)ids_detail_piecerates.DataObject).Retrieve(al_invid);
            ll_rowcount = ids_detail_piecerates.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("Invoice ID = " + of_display(al_invid) + "\n"
                             + "Rowcount   = " + ll_rowcount.ToString()
                             , "of_process_detail_piecerates");
            // ---------------------------------------------------------  */
            sSupplier2 = "";
            nPrsKey2 = 0;
            if (ll_rowcount > 0)
            {
                nPrsKey2 = (int)ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(0).PrsKey;
                sSupplier2 = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(0).Atype;
                sSupplier2 = sSupplier2.Trim();
            }
            ldc_tot_cost = 0.0M;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                sSupplier    = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).Atype;
                sSupplier    = sSupplier.Trim();
                ld_prd_date  = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).PrdDate;
                ls_prt_code  = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).PrtCode;
                ll_prd_qty   = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).PrdQuantity;
                ldc_prd_rate = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).Rate;
                ldc_prd_cost = ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).Cost;
                nPrsKey = (int)ids_detail_piecerates.GetItem<InvoiceDetailPaymentPiecerates>(ll_row).PrsKey;

                if (nPrsKey != nPrsKey2)
                {
                    ll_rc = output_piecerate_total(is_contract, sSupplier2, ldc_tot_cost);
                    if (ll_rc != 0)
                        return ll_rc;

                    ldc_tot_cost = 0.0M;
                    nPrsKey2 = nPrsKey;
                    sSupplier2 = sSupplier + "";
                }

                ldc_tot_cost += ldc_prd_cost;

                ll_rc = output_piecerate_detail(is_contract, ll_row, sSupplier, ld_prd_date
                                                  , ls_prt_code, ll_prd_qty, ldc_prd_rate
                                                  , ldc_prd_cost);
                if (ll_rc != 0)
                    return ll_rc;

            }
            if (ll_rowcount > 0)
            {
                ll_rc = output_piecerate_total(is_contract, sSupplier2, ldc_tot_cost);
                if (ll_rc != 0)
                    return ll_rc;
            }
            return ll_rowcount;
        }

        // TJB RPCR_054 June-2013: NEW
        // output_piecerate_detail
        // Consolidate code to simplify of_process_detail_piecerates
        private int output_piecerate_detail(string is_contract, int ll_row, string sSupplier, DateTime? ld_prd_date
                                                  , string ls_prt_code, int? ll_prd_qty, decimal? ldc_prd_rate
                                                  , decimal? ldc_prd_cost)
        {
            string ls_temp;

            ls_temp = "6" + "|" + "D" + "|" + sSupplier + "|" + of_output(ld_prd_date) + "|" 
                    + of_output(ls_prt_code) + "|" + of_output(ll_prd_qty) + "|" 
                    + of_output(ldc_prd_rate, 3) + "|" + of_output(ldc_prd_cost, 2);

            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("Row = "+string(ll_row)+"\n"
                           +"Supplier = "+sSupplier + "\n"    
                           +"Prd date = "+of_display(ld_prd_date)+"\n" 
                           +"Prt code = "+of_display(ls_prt_code)+"\n" 
                           +"Prd qty  = "+of_display(ll_prd_qty)+"\n"
                           +"Prd rate = "+of_display(ldc_prd_rate)+"\n"
                           +"Prd cost = "+of_display(ldc_prd_cost)+"\n"
                           +"\n" + ls_temp + "\n"
                           ,"output_piecerate_detail" );
            // ---------------------------------------------------------  */
            try
            {
                sw.WriteLine(ls_temp);
            }
            catch
            {
                MessageBox.Show("Error writing " + sSupplier + "detail record.\n"
                                + "Contract    = " + is_contract + "\n"
                                + "Item        = " + of_display(ll_row) + "\n"
                                , "Error - output_piecerate_detail"
                                , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            return 0;
        }

        // TJB RPCR_054 June-2013: NEW
        // output_piecerate_total
        // Consolidate code to simplify of_process_detail_piecerates
        private int output_piecerate_total(string sContract, string sSupplier, decimal? dTotalcost)
        {
            string sTemp;

            sTemp = "6" + "|" + "T" + "|" + sSupplier + "|" + "|" + "|" + "|" + "|" + of_output(dTotalcost, 2);
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("Total cost = " + of_display(dTotalcost) + "\n"
                          + "Supplier   = " + of_display(sSupplier) + "\n\n"
                          + sTemp + "\n"
                          , "output_piecerate_total");
            // ---------------------------------------------------------  */
            try
            {
                sw.WriteLine(sTemp);
            }
            catch
            {
                MessageBox.Show("Error writing" + sSupplier + "total record.\n"
                               + "Contract    = " + sContract + "\n"
                               , "Error - output_piecerate_total"
                               , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -(1);
            }
            return 0;
        }

        public virtual int of_process_detailkm(int? al_invid, int? al_contractno, int? al_contractorid, DateTime? ad_startdate, DateTime? ad_enddate)
        {
            //  TJB  SR4685  May/2006   - New -
            //  Process the REACHMEDIA data for this invoice
            //
            // TJB  RPCR_012 July-2010
            // Added sSupplier code

            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            int? ll_prd_qty;
            DateTime? ld_prd_date;
            string ls_prt_code, sSupplier = "";
            string ls_temp;
            decimal? ldc_prd_rate;
            decimal? ldc_prd_cost;
            decimal? ldc_tot_cost = 0;
            ((DwInvoiceDetailPaymentPrDetailkm)ids_detailkm.DataObject).Retrieve(al_invid, al_contractno, al_contractorid, ad_startdate, ad_enddate);
            ll_rowcount = ids_detailkm.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show ("++++++++ REACHMEDIA Section ++++++++\n" 
                            +"Invoice ID = "+of_display(al_invId)+"\n"
                            +"Rowcount   = "+ll_rowcount.ToString()
                            ,"w_invoice_search.of_process_detailkm" );
            // ---------------------------------------------------------  */
            if (ll_rowcount > 0)
            {
                sSupplier = ids_detailkm.GetItem<InvoiceDetailPaymentPrDetailkm>(0).Atype;
                sSupplier = sSupplier.Trim();
                ldc_tot_cost = ((DwInvoiceDetailPaymentPrDetailkm)ids_detailkm.DataObject).Sum;
            }
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ld_prd_date = ids_detailkm.GetItem<InvoiceDetailPaymentPrDetailkm>(ll_row).PrdDate;
                ls_prt_code = ids_detailkm.GetItem<InvoiceDetailPaymentPrDetailkm>(ll_row).PrtCode;
                ll_prd_qty = ids_detailkm.GetItem<InvoiceDetailPaymentPrDetailkm>(ll_row).PrdQuantity;
                ldc_prd_rate = ids_detailkm.GetItem<InvoiceDetailPaymentPrDetailkm>(ll_row).Rate;
                ldc_prd_cost = ids_detailkm.GetItem<InvoiceDetailPaymentPrDetailkm>(ll_row).Cost;

                ls_temp = "5" + "|" + "D" + "|" + sSupplier + "|" + of_output(ld_prd_date) + "|" + of_output(ls_prt_code) + "|" + of_output(ll_prd_qty) + "|" + of_output(ldc_prd_rate, 3) + "|" + of_output(ldc_prd_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                               +"Supplier = "+sSupplier + "\n"    
                               +"Prd date = "+of_display(ld_prd_date)+"\n" 
                               +"Prt code = "+of_display(ls_prt_code)+"\n" 
                               +"Prd qty  = "+of_display(ll_prd_qty)+"\n"
                               +"Prd rate = "+of_display(ldc_prd_rate)+"\n"
                               +"Prd cost = "+of_display(ldc_prd_cost)+"\n"
                               +"\n" & +ls_temp+"\n"
                               ,"w_invoice_search.of_process_detailkm" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing "+ sSupplier +"detail record.\n" + "Contract    = " + is_contract + "~" + "Item        = " + of_display(ll_row) + "Return code = " + of_display(ll_rc), 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            if (ll_rowcount > 0)
            {
                ls_temp = "5" + "|" + "T" + "|" + sSupplier + "|" + "|" + "|" + "|" + "|" + of_output(ldc_tot_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Tot cost = "+of_display(ldc_tot_cost)+"\n"
                               +"\n" & +ls_temp+"\n"
                               ,"w_invoice_search.of_process_detailkm" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing"+sSupplier+"total record.\n"
                                   + "Contract    = " + is_contract + "\n" 
                                   + "Return code = " + of_display(ll_rc)
                                   , "Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual int of_process_detailcp(int? al_invid, int? al_contractno, int? al_contractorid, DateTime? ad_startdate, DateTime? ad_enddate)
        {
            //  TJB  SR4685  May/2006   - New -
            //  Process the Courier Post data for this invoice
            //
            // TJB  RPCR_012 July-2010
            // Added sSupplier code

            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            int? ll_prd_qty;
            DateTime? ld_prd_date;
            string ls_prt_code, sSupplier="";
            string ls_temp;
            decimal? ldc_prd_rate;
            decimal? ldc_prd_cost;
            decimal? ldc_tot_cost = 0;
            ((DwInvoiceDetailPaymentPrDetailcp)ids_detailcp.DataObject).Retrieve(al_invid, al_contractno, al_contractorid, ad_startdate, ad_enddate);
            ll_rowcount = ids_detailcp.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("++++++++ Courier Post Section ++++++++\n"
                           +"Invoice ID = "+of_display(al_invId)+"\n"
                           +"Rowcount   = "+string(ll_rowcount
                           ,"w_invoice_search.of_process_detailcp" )
            // ---------------------------------------------------------  */
            if (ll_rowcount > 0)
            {
                sSupplier = ids_detailcp.GetItem<InvoiceDetailPaymentPrDetailcp>(0).Atype;
                sSupplier = sSupplier.Trim();
                //ldc_tot_cost = ids_detailcp.GetItemNumber(1, "compute_1");
                ldc_tot_cost = ((DwInvoiceDetailPaymentPrDetailcp)ids_detailcp.DataObject).Compute1.GetValueOrDefault();
            }
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ld_prd_date = ids_detailcp.GetItem<InvoiceDetailPaymentPrDetailcp>(ll_row).PrdDate;
                ls_prt_code = ids_detailcp.GetItem<InvoiceDetailPaymentPrDetailcp>(ll_row).PrtCode;
                ll_prd_qty = ids_detailcp.GetItem<InvoiceDetailPaymentPrDetailcp>(ll_row).PrdQuantity;
                ldc_prd_rate = ids_detailcp.GetItem<InvoiceDetailPaymentPrDetailcp>(ll_row).Rate;
                ldc_prd_cost = ids_detailcp.GetItem<InvoiceDetailPaymentPrDetailcp>(ll_row).Cost;

                ls_temp = "5" + "|" + "D" + "|" + sSupplier + "|" + of_output(ld_prd_date) + "|" + of_output(ls_prt_code) + "|" + of_output(ll_prd_qty) + "|" + of_output(ldc_prd_rate, 3) + "|" + of_output(ldc_prd_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                               +"Prd date = "+of_display(ld_prd_date)+"\n"
                               +"Prt code = "+of_display(ls_prt_code)+"\n"
                               +"Prd qty  = "+of_display(ll_prd_qty)+"\n"
                               +"Prd rate = "+of_display(ldc_prd_rate)+"\n"
                               +"Prd cost = "+of_display(ldc_prd_cost)+"\n"
                               +"\n"+ls_temp+"\n"
                               ,"w_invoice_search.of_process_detailcp" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing"+sSupplier+"detail record.\n" 
                                    + "Contract    = " + is_contract + "\n"
                                    + "Item        = " + of_display(ll_row) + "\n" 
                                    + "Return code = " + of_display(ll_rc)
                                    , "Error - of_process_detailcp"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            if (ll_rowcount > 0)
            {
                ls_temp = "5" + "|" + "T" + "|" + sSupplier + "|" + "|" + "|" + "|" + "|" + of_output(ldc_tot_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Tot cost = "+of_display(ldc_tot_cost) +"\n"
                               +ls_temp+"\n"
                               ,"w_invoice_search.of_process_detailcp" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing "+sSupplier+" total record.\n"
                                   + "Contrct    = " + is_contract + "\n" 
                                   + "Return code = " + of_display(ll_rc)
                                   , "Error - of_process_detailcp"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual int of_process_detailxp(int? al_invid, int? al_contractno, int? al_contractorid, DateTime? ad_startdate, DateTime? ad_enddate)
        {
            //  TJB  SR4685  May/2006   - New -
            //  Process the SkyRoad data for this invoice
            //
            // TJB  RPCR_012 July-2010
            // Added sSupplier code

            int ll_rowcount;
            int ll_row;
            int ll_rc = 0;
            int? ll_prd_qty;
            DateTime? ld_prd_date;
            string ls_prt_code, sSupplier="";
            string ls_temp;
            decimal? ldc_prd_rate;
            decimal? ldc_prd_cost;
            decimal? ldc_tot_cost = 0;
            ((DwInvoiceDetailPaymentPrDetailxp)ids_detailxp.DataObject).Retrieve(al_invid, al_contractno, al_contractorid, ad_startdate, ad_enddate);
            ll_rowcount = ids_detailxp.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("++++++++ SkyRoad Section ++++++++\n"
                            + "Invoice ID = "+of_display(al_invId)+"\n"
                            + "Rowcount   = "+string(ll_rowcount)
                            , "w_invoice_search.of_process_detailxp" )
            // ---------------------------------------------------------  */
            if (ll_rowcount > 0)
            {
                sSupplier = ids_detailxp.GetItem<InvoiceDetailPaymentPrDetailxp>(0).Atype;
                sSupplier = sSupplier.Trim();
                //ldc_tot_cost = ids_detailxp.GetItemNumber(1, "compute_1");
                ldc_tot_cost = ((DwInvoiceDetailPaymentPrDetailxp)ids_detailxp.DataObject).Compute1.GetValueOrDefault();
            }
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ld_prd_date = ids_detailxp.GetItem<InvoiceDetailPaymentPrDetailxp>(ll_row).PrdDate;
                ls_prt_code = ids_detailxp.GetItem<InvoiceDetailPaymentPrDetailxp>(ll_row).PrtCode;
                ll_prd_qty = ids_detailxp.GetItem<InvoiceDetailPaymentPrDetailxp>(ll_row).PrdQuantity;
                ldc_prd_rate = ids_detailxp.GetItem<InvoiceDetailPaymentPrDetailxp>(ll_row).Rate;
                ldc_prd_cost = ids_detailxp.GetItem<InvoiceDetailPaymentPrDetailxp>(ll_row).Cost;

                ls_temp = "5" + "|" + "D" + "|" + sSupplier + "|" + of_output(ld_prd_date) + "|" + of_output(ls_prt_code) + "|" + of_output(ll_prd_qty) + "|" + of_output(ldc_prd_rate, 3) + "|" + of_output(ldc_prd_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                                + "Prd date = "+of_display(ld_prd_date)+"\n"
                                + "Prt code = "+of_display(ls_prt_code)+"\n"
                                + "Prd qty  = "+of_display(ll_prd_qty)+"\n"
                                + "Prd rate = "+of_display(ldc_prd_rate)+"\n"
                                + "Prd cost = "+of_display(ldc_prd_cost)+"\n\n"
                                + ls_temp+"\n"
                                , "w_invoice_search.of_process_detailxp" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing "+sSupplier+" detail record.\n"
                        + "Contract    = " + is_contract + "\n"
                        + "Item        = " + of_display(ll_row) + "\n"
                        + "Return code = " + of_display(ll_rc)
                        , "Error"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            if (ll_rowcount > 0)
            {
                ls_temp = "5" + "|" + "T" + "|" + sSupplier + "|" + "|" + "|" + "|" + "|" + of_output(ldc_tot_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Tot cost = "+of_display(ldc_tot_cost)+"\n"
                                + ls_temp+"\n"
                                , "w_invoice_search.of_process_detailxp" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing "+sSupplier+" total record.\n"
                                       + "Contract    = " + is_contract + "\n"
                                       + "Return code = " + of_display(ll_rc)
                                       , "Error"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual int of_process_payment_details(int? al_invid, DateTime? ad_enddate, int? al_contractorid, int? al_contractno)
        {
            //  TJB  SR4685  May/2006   - New -
            //  Process the payment details for this invoice
            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            string ls_m_temp;
            string ls_y_temp;
            decimal? ldc_m_standard;
            decimal? ldc_m_allowance;
            decimal? ldc_m_taxable_adj;
            decimal? ldc_m_gst_rate;
            decimal? ldc_m_gst_value;
            decimal? ldc_m_wtax_rate;
            decimal? ldc_m_wtax_value;
            decimal? ldc_m_tot_b4_tax;
            decimal? ldc_m_adj_notax;
            decimal? ldc_m_total = 0;
            decimal? ldc_y_standard;
            decimal? ldc_y_allowance;
            decimal? ldc_y_taxable_adj;
            decimal? ldc_y_2date_tax;
            decimal? ldc_y_gst_value;
            decimal? ldc_y_wtax_value;
            decimal? ldc_y_adj_notax;
            decimal? ldc_y_total = 0;

            ((DwInvoiceDetailPayment)ids_payment_details.DataObject).Retrieve(al_invid, ad_enddate, al_contractorid, al_contractno);
            ll_rowcount = ids_payment_details.RowCount;
            /*  ------------------------ Debugging ---------------------- //
            MessageBox.Show("++++++++ Payment Details Section ++++++++\n"
                            +"Rowcount   = "+string(ll_rowcount)+"\n\n"
                            +"InvoiceID  = "+string(al_invid)+"\n"
                            +"End date   = "+string(ad_enddate)+"\n"
                            +"Contractor = "+string(al_contractorid)+"\n"
                            +"Contract   = "+string(al_contractno)+"\n"
                            ,"w_invoice_search.of_process_payment_details" )
            // ---------------------------------------------------------  */
            if (ll_rowcount >= 1)
            {
                ldc_m_total = ids_payment_details.GetItem<InvoiceDetailPayment>(0).Compute1;
                ldc_y_total = ids_payment_details.GetItem<InvoiceDetailPayment>(0).Compute2;
            }
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ldc_m_standard = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MStandard;
                ldc_m_allowance = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MAllowance;
                ldc_m_taxable_adj = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MTaxableAdjustments;
                ldc_m_tot_b4_tax = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MTotalBeforeTax;
                ldc_m_gst_rate = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MGstRate;
                ldc_m_gst_value = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MGstValue;
                ldc_m_wtax_rate = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MWtaxRate;
                ldc_m_wtax_value = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MWtaxValue;
                ldc_m_adj_notax = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).MAdjNotax;
                ldc_y_standard = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YStandard;
                ldc_y_allowance = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YAllowance;
                ldc_y_taxable_adj = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YTaxableAdjustments;
                ldc_y_2date_tax = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YTotalBeforeTax;
                ldc_y_gst_value = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YGstValue;
                ldc_y_wtax_value = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YWtaxValue;
                ldc_y_adj_notax = ids_payment_details.GetItem<InvoiceDetailPayment>(ll_row).YAdjNotax;

                ls_m_temp = "2" + "|" + of_output(ldc_m_standard, 2) + "|" + of_output(ldc_m_allowance, 2) + "|" + 
                                        of_output(ldc_m_taxable_adj, 2) + "|" + of_output(ldc_m_tot_b4_tax, 2) + "|" + 
                                        of_output(ldc_m_gst_rate, 2) + "|" + of_output(ldc_m_gst_value, 2) + "|" + 
                                        of_output(ldc_m_wtax_rate, 2) + "|" + of_output(ldc_m_wtax_value, 2) + "|" + 
                                        of_output(ldc_m_adj_notax, 2) + "|" + of_output(ldc_m_total, 2);

                ls_y_temp = "3" + "|" + of_output(ldc_y_standard, 2) + "|" + of_output(ldc_y_allowance, 2) + "|" + 
                                        of_output(ldc_y_taxable_adj, 2) + "|" + of_output(ldc_y_2date_tax, 2) + "|" + 
                                        of_output(ldc_y_gst_value, 2) + "|" + of_output(ldc_y_wtax_value, 2) + "|" + 
                                        of_output(ldc_y_adj_notax, 2) + "|" + of_output(ldc_y_total, 2);
                /*  ------------------------ Debugging ---------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                                + "m_standard    = "+of_display(ldc_m_standard)+"\n"
                                + "m_allowance   = "+of_display(ldc_m_allowance)+"\n"
                                + "m_taxable_adj = "+of_display(ldc_m_taxable_adj)+"\n"
                                + "m_tot_b4_tax  = "+of_display(ldc_m_tot_b4_tax)+"\n"
                                + "m_gst_rate    = "+of_display(ldc_m_gst_rate)+"\n"
                                + "m_gst_value   = "+of_display(ldc_m_gst_value)+"\n"
                                + "m_wtax_rate   = "+of_display(ldc_m_wtax_rate)+"\n"
                                + "m_wtax_value  = "+of_display(ldc_m_wtax_value)+"\n"
                                + "m_adj_notax   = "+of_display(ldc_m_adj_notax)+"\n"
                                + "m_total       = "+of_display(ldc_m_total)+"\n\n"
                                + ls_m_temp+"\n\n"
                                + "y_standard    = "+of_display(ldc_y_standard)+"\n"
                                + "y_allowance   = "+of_display(ldc_y_allowance)+"\n"
                                + "y_taxable_adj = "+of_display(ldc_y_taxable_adj)+"\n"
                                + "y_2date_tax   = "+of_display(ldc_y_2date_tax)+"\n"
                                + "y_gst_value   = "+of_display(ldc_y_gst_value)+"\n"
                                + "y_wtax_value  = "+of_display(ldc_y_wtax_value)+"\n"
                                + "y_adj_notax   = "+of_display(ldc_y_adj_notax)+"\n"
                                + "y_total       = "+of_display(ldc_y_total)+"\n\n"
                                + ls_y_temp+"\n"
                                , "w_invoice_search.of_process_payment_details" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_m_temp);
                try
                {
                    sw.WriteLine(ls_m_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing current pay summary record.\n"
                                       + "Contract    = " + is_contract + "\n"
                                       + "Return code = " + of_display(ll_rc)
                                       , "Error"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Exclamation);
                    return -(1);
                }
                //ll_rc = FileWrite(ii_file, ls_y_temp);
                try
                {
                    sw.WriteLine(ls_y_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing YTD pay summary record.\n"
                                       + "Contract    = " + is_contract + "\n"
                                       + "Return code = " + of_display(ll_rc)
                                       , "Error"
                                       , MessageBoxButtons.OK
                                       , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual int of_process_payment_ded(int? al_invid)
        {
            //  TJB  SR4685  May/2006   - New -
            //  Process the payment ded for this invoice
            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            DateTime? ld_pcd_date;
            string ls_ded_desc;
            string ls_temp;
            string ls_lineout;
            decimal? ldc_pcd_amount;
            decimal? ldc_total = 0;
            ((DwInvoiceDetailPaymentDed)ids_payment_ded.DataObject).Retrieve(al_invid);
            ll_rowcount = ids_payment_ded.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("++++++++ Payment DED Section ++++++++\n"
                            + "Rowcount   = "+string(ll_rowcount)+"\n\n"
                            + "InvoiceID  = "+string(al_invid)+"\n"
                            , "w_invoice_search.of_process_payment_ded" )
            // ---------------------------------------------------------  */
            if (ll_rowcount >= 1)
            {
                //ldc_total = ids_payment_ded.GetItemNumber(1, "compute_1");
                ldc_total = ((DwInvoiceDetailPaymentDed)ids_payment_ded.DataObject).Compute1.GetValueOrDefault();
            }
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ld_pcd_date = ids_payment_ded.GetItem<InvoiceDetailPaymentDed>(ll_row).PcdDate;
                ls_temp = ids_payment_ded.GetItem<InvoiceDetailPaymentDed>(ll_row).DedDescription;
                ldc_pcd_amount = ids_payment_ded.GetItem<InvoiceDetailPaymentDed>(ll_row).PcdAmount;
                ls_ded_desc = of_remove_crlf(ls_temp);

                ls_lineout = "4" + "|" + "D" + "|" + "N" + "|" + of_output(ld_pcd_date) + "|" + of_output(ls_ded_desc) + "|" + of_output(ldc_pcd_amount, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                                + "pcd_date   = "+of_display(ld_pcd_date)+"\n"
                                + "ded_desc   = "+of_display(ls_ded_desc)+"\n"
                                               + "pcd_amount = "+of_display(ldc_pcd_amount)+"\n\n"
                                + ls_lineout+"\n"
                                , "w_invoice_search.of_process_payment_ded" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_lineout);
                try
                {
                    sw.WriteLine(ls_lineout);
                }
                catch
                {
                    MessageBox.Show("Error writing non-taxable adjustment detail record.\n" 
                                    + "Contract    = " + is_contract + "\n"
                                    + "Item        = " + of_display(ll_row) +"\n"
                                    + "Return code = " + of_display(ll_rc)
                                    , "Error"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            //  TJB  SR4685 fixup
            //  Added missing +"||" 
            if (ll_rowcount >= 1)
            {
                ls_lineout = "4" + "|" + "T" + "|" + "N" + "|" + "||" + of_output(ldc_total, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("total      = "+of_display(ldc_total)+"\n\n"
                                + ls_lineout+"\n"
                                , "w_invoice_search.of_process_payment_ded" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_lineout);
                try
                {
                    sw.WriteLine(ls_lineout);
                }
                catch
                {
                    MessageBox.Show("Error writing non-taxable adjustment total record.\n"
                                    + "Contract    = " + is_contract + "\n"
                                    + "Return code = " + of_display(ll_rc)
                                    , "Error"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual int of_process_payment_pr(int? al_invid, DateTime? ad_enddate)
        {
            //  TJB  SR4685  May/2006   - New -
            //  Process the payment pr for this invoice
            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            DateTime? ld_in_date;
            string ls_prs_desc;
            string ls_temp;
            string ls_lineout;
            decimal? ldc_pvalue;
            decimal ldc_total = 0;

            ((DwInvoiceDetailPaymentPr)ids_payment_pr.DataObject).Retrieve(al_invid, ad_enddate);
            ll_rowcount = ids_payment_pr.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("++++++++ Payment Pr Section ++++++++\n"
                            +"Rowcount   = "+string(ll_rowcount)+"\n\n"
                            +"InvoiceID  = "+string(al_invid)+"\n"
                            +"End date   = "+string(ad_enddate)+"\n",
                            "w_invoice_search.of_process_payment_pr" )
            // ---------------------------------------------------------  */
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ld_in_date = ids_payment_pr.GetItem<InvoiceDetailPaymentPr>(ll_row).InDate;
                ls_temp = ids_payment_pr.GetItem<InvoiceDetailPaymentPr>(ll_row).PrsDescription;
                ldc_pvalue = ids_payment_pr.GetItem<InvoiceDetailPaymentPr>(ll_row).Pvalue;
                ls_prs_desc = of_remove_crlf(ls_temp);

                ls_lineout = "4" + "|" + "D" + "|" + "T" + "|" + of_output(ld_in_date) + "|" + of_output(ls_prs_desc) + "|" + of_output(ldc_pvalue, 2);

                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                                + "in_date  = "+of_display(ld_in_date)+"\n"
                                + "prs_desc = "+of_display(ls_prs_desc)+"\n"
                                + "pvalue   = "+of_display(ldc_pvalue)+"\n"
                                + "\n" +ls_lineout+"\n"
                                , "w_invoice_search.of_process_payment_pr" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_lineout);

                try
                {
                    sw.WriteLine(ls_lineout);
                }
                catch
                {
                    MessageBox.Show("Error writing taxable adjustment detail record.\n"
                                    + "Contract    = " + is_contract + "\r"
                                    + "Item        = " + of_display(ll_row) + "\r"
                                    + "Return code = " + of_display(ll_rc)
                                    , "Error"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
                // TJB Jan 2009:  Moved ldc_total calculation/access to follow
                //                detail output.Done when trying to track down a
                //                bug; left because it didn"t make any difference.
            if (ll_rowcount >= 1)
            {
                //ldc_total = ids_payment_pr.GetItemNumber(1, "compute_1");
                ldc_total = ((DwInvoiceDetailPaymentPr)ids_payment_pr.DataObject).Compute1.GetValueOrDefault();

                ls_lineout = "4" + "|" + "T" + "|" + "T" + "|" + "||" + of_output(ldc_total, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("total    = "+of_display(ldc_total)+"\n\n"
                                + ls_lineout+"\n"
                                , "w_invoice_search.of_process_payment_pr" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_lineout);
                try
                {
                    sw.WriteLine(ls_lineout);
                }
                catch
                {
                    MessageBox.Show("Error writing taxable adjustment total record.\n" 
                                    + "Contract    = " + is_contract + "\n"
                                    + "Return code = " + of_display(ll_rc)
                                    , "Error"
                                    , MessageBoxButtons.OK
                                    , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        // TJB  RPCR_056  July-2013  NEW
        // of_process_allowance_breakdown
        // Process the allowance breakdown for this invoice
        public virtual int of_process_allowance_breakdown(int? al_contractno, int? al_invid)
        {
            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            string ls_alt_desc;
            string ls_temp;
            string ls_lineout;
            decimal? ldc_alt_value;
            decimal ldc_total = 0;

            ((DwInvoiceDetailAllowanceBreakdown)ids_allowance_breakdown.DataObject).Retrieve(al_invid);
            ll_rowcount = ids_allowance_breakdown.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("++++++++ Payment Pr Section ++++++++\n"
                            + "Rowcount   = " + ll_rowcount.ToString() + "\n\n"
                            + "InvoiceID  = " + al_invid.ToString() + "\n"
                            , "of_process_allowance_breakdown" );
            // ---------------------------------------------------------  */
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ls_temp = ids_allowance_breakdown.GetItem<InvoiceDetailAllowanceBreakdown>(ll_row).AltDescription;
                ldc_alt_value = ids_allowance_breakdown.GetItem<InvoiceDetailAllowanceBreakdown>(ll_row).AltValue;
                ls_alt_desc = of_remove_crlf(ls_temp);

                ls_lineout = "5" + "|" + "D" + "|" + of_output(ls_alt_desc) + "|" + of_output(ldc_alt_value, 2);

                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = " + ll_row.ToString() + "\n"
                                + "alt_desc  = " + of_display(ls_alt_desc) + "\n"
                                + "alt_value = " + of_display(ldc_alt_value) + "\n"
                                + "\n" + ls_lineout + "\n"
                                , "of_process_allowance_breakdown" );
                // ---------------------------------------------------------  */

                try
                {
                    sw.WriteLine(ls_lineout);
                }
                catch
                {
                    MessageBox.Show("Error writing taxable adjustment detail record.\n"
                                    + "Contract    = " + is_contract + "\n"
                                    + "Item        = " + of_display(ll_row) + "\n"
                                    + "Return code = " + of_display(ll_rc)
                                    , "of_process_allowance_breakdown - Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            // TJB Jan 2009:  Moved ldc_total calculation/access to follow
            //                detail output. Done when trying to track down a
            //                bug; left because it didn't make any difference.
            if (ll_rowcount >= 1)
            {
                ldc_total = ((DwInvoiceDetailAllowanceBreakdown)ids_allowance_breakdown.DataObject).Compute1.GetValueOrDefault();

                ls_lineout = "5" + "|" + "T" + "||" + of_output(ldc_total, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("total    = " + of_display(ldc_total) + "\n\n"
                                + ls_lineout + "\n"
                                , "of_process_allowance_breakdown" );
                // ---------------------------------------------------------  */
                try
                {
                    sw.WriteLine(ls_lineout);
                }
                catch
                {
                    MessageBox.Show("Error writing allowance breakdown total record.\n"
                                    + "Contract    = " + is_contract + "\n"
                                    + "Return code = " + of_display(ll_rc)
                                    , "of_process_allowance_breakdown - Error"
                                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual int of_process_detailpp(int? al_invid, int? al_contractno, int? al_contractorid, DateTime? ad_startdate, DateTime? ad_enddate)
        {
            //  TJB  SR4684  June/2006   - New -
            //  Process the ParcelPost data for this invoice
            //
            // TJB  RPCR_012 July-2010
            // Added sSupplier code

            int ll_rowcount;
            int ll_row;
            int ll_rc = -1;
            int? ll_prd_qty;
            DateTime? ld_prd_date;
            string ls_prt_code, sSupplier="";
            string ls_temp;
            decimal? ldc_prd_rate;
            decimal? ldc_prd_cost;
            decimal? ldc_tot_cost = 0;
            ((DwInvoiceDetailPaymentPrDetailpp)ids_detailpp.DataObject).Retrieve(al_invid, al_contractno, al_contractorid, ad_startdate, ad_enddate);
            ll_rowcount = ids_detailpp.RowCount;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show("++++++++ Parcel Post Section ++++++++\n"
                            + "Invoice ID = "+of_display(al_invId)+"\n"
                            + "Rowcount   = "+string(ll_rowcount)
                            , "w_invoice_search.of_process_detailpp" )
            // ---------------------------------------------------------  */
            if (ll_rowcount > 0)
            {
                sSupplier = ids_detailpp.GetItem<InvoiceDetailPaymentPrDetailpp>(0).Atype;
                sSupplier = sSupplier.Trim();
                //ldc_tot_cost = ids_detailpp.GetItemNumber(1, "compute_1");
                ldc_tot_cost = ((DwInvoiceDetailPaymentPrDetailpp)ids_detailpp.DataObject).Compute1;
            }
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ld_prd_date = ids_detailpp.GetItem<InvoiceDetailPaymentPrDetailpp>(ll_row).PrdDate;
                ls_prt_code = ids_detailpp.GetItem<InvoiceDetailPaymentPrDetailpp>(ll_row).PrtCode;
                ll_prd_qty = ids_detailpp.GetItem<InvoiceDetailPaymentPrDetailpp>(ll_row).PrdQuantity;
                ldc_prd_rate = ids_detailpp.GetItem<InvoiceDetailPaymentPrDetailpp>(ll_row).Rate;
                ldc_prd_cost = ids_detailpp.GetItem<InvoiceDetailPaymentPrDetailpp>(ll_row).Cost;

                ls_temp = "5" + "|" + "D" + "|" + sSupplier + "|" + of_output(ld_prd_date) + "|" + of_output(ls_prt_code) + "|" + of_output(ll_prd_qty) + "|" + of_output(ldc_prd_rate, 3) + "|" + of_output(ldc_prd_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show("Row = "+string(ll_row)+"\n"
                                + "Prd date = "+of_display(ld_prd_date)+"\n"
                                + "Prt code = "+of_display(ls_prt_code)+"\n"
                                + "Prd qty  = "+of_display(ll_prd_qty)+"\n"
                                + "Prd rate = "+of_display(ldc_prd_rate)+"\n"
                                + "Prd cost = "+of_display(ldc_prd_cost)+"\n"
                                + "\n"+ls_temp+"\n"
                                , "w_invoice_search.of_process_detailpp" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing "+sSupplier+" detail record.\n" 
                                    + "Contract    = " + is_contract + "\n"
                                    + "Item        = " + of_display(ll_row) +"\n"
                                    + "Return code = " + of_display(ll_rc)
                                    , "Error", MessageBoxButtons.OK
                                    , MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            if (ll_rowcount > 0)
            {
                ls_temp = "5" + "|" + "T" + "|" + sSupplier + "|" + "|" + "|" + "|" + "|" + of_output(ldc_tot_cost, 2);
                /*  ----------------------- Debugging ----------------------- //
                MessageBox.Show(+"Tot cost = "+of_display(ldc_tot_cost)
                                +"\n"+ls_temp+"\n"
                                ,"w_invoice_search.of_process_detailpp" )
                // ---------------------------------------------------------  */
                //ll_rc = FileWrite(ii_file, ls_temp);
                try
                {
                    sw.WriteLine(ls_temp);
                }
                catch
                {
                    MessageBox.Show("Error writing "+sSupplier+" total record.\n" 
                                   + "Contract    = " + is_contract + "~" + "Return code = " + of_display(ll_rc)
                                   ,"Error"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -(1);
                }
            }
            return ll_rowcount;
        }

        public virtual string of_output(object aa_value)
        {
            //  TJB  SR4685  May/2006    - New -
            //  Convert a value to a string for output
            //  Return "" if the value is null
            //  If the string contains <cr> characters, 
            //     add quotes around the string
            string ls_temp;
            //ls_temp = aa_value.ToString();
            if (aa_value == null)
            {
                ls_temp = "";
            }
            else
                ls_temp = aa_value.ToString();

            if (aa_value is DateTime)
            {
                return ((DateTime)aa_value).ToShortDateString();
            }
            // Commented out - TJB  4-May-2009 - Quotes incorrectly added
            //else if ((ls_temp.GetType() == typeof(string)) && (ls_temp.Length == 13))  //if (Match(ls_temp, Char(13))) 
            //{
            //    ls_temp = '\"' + ls_temp + '\"';
            //}

            return ls_temp;
        }

        public virtual string of_output(object aa_value, int ai_decimals)
        {
            //  TJB  SR4685  May/2006    - New -
            //  Convert a value to a string for output
            //  Return '' if the value is null
            //  If the string contains <cr> characters, 
            //     add quotes around the string
            //  If ai_decimals is > 0 then format with that number of decimal places
            //  NOTE: only caters for 1, 2, or 3 decimals
            string ls_temp;
            ls_temp = aa_value + "";
            if (aa_value == null)
            {
                ls_temp = "";
            }
            else if ((ls_temp.GetType() == typeof(string)) && (ls_temp.Length == 13))//(Match(ls_temp, Char(13))) 
            {
                ls_temp = '\"' + ls_temp + '\"';
            }
            else if (StaticFunctions.ToInt32(ls_temp) != null)
            {
                if (ai_decimals == 1)
                {
                    ls_temp = string.Format("0.0;-0.0", aa_value);
                }
                else if (ai_decimals == 2)
                {
                    ls_temp = string.Format("0.00;-0.00", aa_value);
                }
                else if (ai_decimals == 3)
                {
                    ls_temp = string.Format("0.000;-0.000", aa_value);
                }
            }
            return ls_temp;
        }

        public virtual string of_monthname(DateTime ad_date)
        {
            //  TJB  SR4685  May/2006    - New - 
            //  Return the 3-character month name from the given date
            int ll_month;
            string ls_month;
            ll_month = ad_date.Month;
            //ls_month =  TextUtil.Mid ("JanFebMarAprMayJunJulAugSepOctNovDec", (ll_month - 1) * 3 + 1, 3);
            ls_month = "JanFebMarAprMayJunJulAugSepOctNovDec".Substring((ll_month - 1) * 3, 3);
            return ls_month;
        }

        public virtual string of_split_address(string as_addr)
        {
            //  TJB  SR4685  July 2006    - New -
            //  Split the contractor's address into 4 address lines 
            //  and the post code.
            // 
            //  Return the address with the <cr><lf>s removed, as a
            //  string with the address lines and post code separated 
            //  with '|'s.  
            //  Return '||||' if the address is empty or null.
            //  Return NULL if there's an error.
            int ll_i;
            int ll_j;
            string ls_temp;

            Dictionary<int, string> ls_addr = new Dictionary<int, string>();

            string ls_postcode;
            ls_temp = as_addr.Trim();
            if (ls_temp == null)
            {
                ls_temp = "||||";
                ls_postcode = "";
            }
            else
            {
                //ls_postcode =  TextUtil.Right(ls_temp, 4);
                ls_postcode = ls_temp.Substring(ls_temp.Length - 4);
                if (StaticFunctions.ToInt32(ls_postcode) != null)
                {
                    //ls_temp = Trim(Left(ls_temp,  ls_temp.Len() - 4));
                    ls_temp = ls_temp.Substring(0, ls_temp.Length - 4).Trim();
                }
                else
                {
                    ls_postcode = "";
                }
                // for (ll_i = 0; ll_i < 4; ll_i++)
                // {
                //     //ll_j = TextUtil.Pos (ls_temp, Char(13));
                //     ll_j = ls_temp.IndexOf("\r");
                //     if (ll_j > 0)
                //     {
                //         ls_addr[ll_i] = ls_temp.Substring(0, ll_j).Trim();   //ls_addr[ll_i] = Trim(Left(ls_temp, ll_j - 1));
                //         ls_temp = ls_temp.Substring(ll_j + 1 + 1).Trim();  //ls_temp = Trim(Right(ls_temp,  ls_temp.Len() - ll_j - 1));
                //     }
                //     else
                //     {
                //         ls_addr[ll_i] = ls_temp;
                //         ls_temp = "";
                //     }
                // }

                const char quote = '"';
                char[] quotess = new Char[]
                    {
                        quote
                    };
                const char nl = '\n';
                const char cr = '\r';
                char[] lineendings = new Char[]
                    {
                        nl, cr
                    };
                String[] split_address = ls_temp.Split(lineendings);

                ll_i = 0;
                foreach ( String address_line in split_address )
                {
                    if (address_line.Length > 0)
                    {
                        ls_addr[ll_i] = address_line.Trim(quotess);
                        ll_i++;
                    }
                };
                while ( ll_i < 4 )
                {
                    ls_addr[ll_i] = "";
                    ll_i++;
                };

                ls_temp = ls_addr[0] + "|" + ls_addr[1] + "|" + ls_addr[2] + "|" + ls_addr[3] + "|" + ls_postcode;
            }
            return ls_temp;
        }

        public virtual string of_remove_crlf(string as_string)
        {
            //  TJB  SR4685 fixup  July 2006    - New -
            //  Remove <cr> and/or <lf> characters from the input string.
            int ll_i;
            int ll_j;
            string ls_temp;
            List<string> ls_addr = new List<string>();
            string ls_postcode;
            ls_temp = as_string.Trim();
            if (ls_temp == null)
            {
                //  If the input string is null, return the empty string
                ls_temp = "";
            }
            else
            {
                //  If there are any <cr><lf>'s, replace them with a single space
                //ll_j = TextUtil.Pos (ls_temp, Char(13) + Char(10));
                ll_j = ls_temp.IndexOf("\r\n");
                while (ll_j > 0)
                {
                    ll_i = ls_temp.Length;
                    if (ll_j + 1 >= ll_i)
                    {
                        //ls_temp =  TextUtil.Mid (ls_temp, 1, ll_j - 1);
                        ls_temp = ls_temp.Substring(0, ll_j);
                    }
                    else
                    {
                        //ls_temp =  TextUtil.Mid (ls_temp, 1, ll_j - 1) + ' ' +  TextUtil.Mid (ls_temp, ll_j + 2);
                        ls_temp = ls_temp.Substring(0, ll_j) + " " + ls_temp.Substring(ll_j + 2);
                    }
                    //ll_j = TextUtil.Pos (ls_temp, Char(13) + Char(10));
                    ll_j = ls_temp.IndexOf("\r\n");
                }
                //  If there are any bare <cr>'s, replace them with a single space
                //ll_j = TextUtil.Pos (ls_temp, Char(13));
                ll_j = ls_temp.IndexOf("\r");
                while (ll_j > 0)
                {
                    ll_i = ls_temp.Length;
                    if (ll_j >= ll_i)
                    {
                        //ls_temp =  TextUtil.Mid (ls_temp, 1, ll_j - 1);
                        ls_temp = ls_temp.Substring(0, ll_j);
                    }
                    else
                    {
                        //ls_temp =  TextUtil.Mid (ls_temp, 1, ll_j - 1) + ' ' +  TextUtil.Mid (ls_temp, ll_j + 1);
                        ls_temp = ls_temp.Substring(0, ll_j) + " " + ls_temp.Substring(ll_j + 1);
                    }
                    //ll_j = TextUtil.Pos (ls_temp, Char(13));
                    ll_j = ls_temp.IndexOf("\r");
                }
                //  If there are any bare <lf>'s, replace them with a single space
                //ll_j = TextUtil.Pos (ls_temp, Char(10));
                ll_j = ls_temp.IndexOf("\n");
                while (ll_j > 0)
                {
                    ll_i = ls_temp.Length;
                    if (ll_j >= ll_i)
                    {
                        ls_temp = ls_temp.Substring(0, ll_j);//ls_temp =  TextUtil.Mid (ls_temp, 1, ll_j - 1);
                    }
                    else
                    {
                        //ls_temp =  TextUtil.Mid (ls_temp, 1, ll_j - 1) + ' ' +  TextUtil.Mid (ls_temp, ll_j + 1);
                        ls_temp = ls_temp.Substring(0, ll_j) + " " + ls_temp.Substring(ll_j + 1);
                    }
                    ll_j = ls_temp.IndexOf("\n"); //ll_j = TextUtil.Pos (ls_temp, Char(10));
                }
            }
            return ls_temp;
        }

        public virtual void ue_afterchanged()
        {
            DateTime? dstart;
            DateTime? dEnd;
            string sStartMonth;
            string sStartYear;
            //dEnd = dw_search.GetItemDateTime(1, "end_date").Date;
            if (dw_search.DataObject.GetItem<InvoiceSearch>(0).EndDate == null)
                dstart = null;
            else
            {
                dEnd = dw_search.DataObject.GetItem<InvoiceSearch>(0).EndDate.GetValueOrDefault().Date;
                //dstart = System.Convert.ToDateTime ( String(Year(StaticMethods.RelativeDate(dEnd, -(28 )))) + '/' + String(Month(StaticMethods.RelativeDate(dEnd, -(28)))) + "/21");
                dstart = System.Convert.ToDateTime((dEnd.Value.AddDays(-28).Year).ToString() + '/' + (dEnd.Value.AddDays(-28).Month).ToString() + "/21");
            }
            //dw_search.setitem(1, "start_date", dstart);
            dw_search.DataObject.SetValue(0, "start_date", dstart);
            dw_search.DataObject.BindingSource.CurrencyManager.Refresh();
        }

        private delegate void delegateInvoke();

        public virtual void CallUeAfterchanged()
        {
            ue_afterchanged();
        }

        public virtual void dw_results_constructor()
        {
            //?of_setsort(true);
        }

        StreamWriter sw = null;

        #endregion

        #region Events
        public virtual void dw_search_itemchanged(object sender, System.EventArgs e)
        {
            //if (getcolumnname() == "end_date") 
            //if (dw_search.GetColumnName() == "end_date")
            //{
            BeginInvoke(new delegateInvoke(CallUeAfterchanged)); //dw_search.postevent("ue_afterchanged");
            //}
        }

        public override void cb_open_clicked(object sender, EventArgs e)
        {
            int alcontractor;
            int lreturn;
            int? alcontract;
            int? alregion;
            DateTime sdate;
            DateTime edate;
            string sname;
            WInvoice w_window;
            //  TJB SR4639
            int? li_ctKey;
            string ls_contractNo;
            int ll_contractNo;

            Cursor.Current = Cursors.WaitCursor;
            dw_search.DataObject.AcceptText();
            if (dw_results.RowCount == 0)
            {
                MessageBox.Show("You must select a contractor", "Invoice"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dw_search.GetValue(0, "end_date") == null)
            {
                MessageBox.Show("You must specify a period end date", "Invoice"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dw_results.GetSelectedRow(0) == -1)
            {
                MessageBox.Show("You must select a contractor", "Invoice"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dw_results.GetValue(dw_results.GetSelectedRow(0), "contractor_no") == null)
            {
                MessageBox.Show("You must select a contractor", "Invoice"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sdate = dw_search.GetValue<DateTime>(0, "start_date");
            edate = dw_search.GetValue<DateTime>(0, "end_date");
            alregion = dw_search.GetValue<int?>(0, "region_id");
            sname = dw_search.GetValue<string>(0, "owner_driver");
            alcontractor = dw_results.GetValue<int>(dw_results.GetSelectedRow(0), "contractor_no");
            alcontract = dw_results.GetValue<int?>(dw_results.GetSelectedRow(0), "contract_no");
            if (alcontract == null)
            {
                alcontract = 0;
            }
            if (alregion == null)
            {
                alregion = 0;
            }
            if (sname == null)
            {
                sname = "";
            }
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show ('sdate        = '+of_display(sdate)+'\n'
                             +'edate        = '+of_display ( edate)+'\n'
                             +'alregion     = '+of_display ( alregion)+'\n'
                             +'sname        = '+of_display ( sname)+'\n'
                             +'alcontractor = '+of_display ( alcontractor)+'\n'
                             +'alcontract   = '+of_display ( alcontract)+'\n'
                             ,'w_invoice.cb_open.clicked' )
            // ---------------------------------------------------------  */
            //  TJB SR4639
            //  Get the contract type specified in the search criteria to pass 
            //  to the invoice calculation stored procedure so it can reproduce 
            //  the search if the user selected the 'all' option.

            li_ctKey = dw_search.GetValue<int?>(0, "ct_key");

            ls_contractNo = dw_search.GetValue<string>(0, "contract_no");
            if (li_ctKey == null)
            {
                li_ctKey = 0;
            }
            if (ls_contractNo == null)
            {
                ls_contractNo = "";
            }
            //  TJB: if a contract number was specified in the search criteria
            //  and the user selected the 'all' option, use that number.
            //  NOTE (1): there are situations where there will be more than one 
            //           contractor associated with a single contract (eg if the 
            //           contract changes hands during the invoice period).
            //  NOTE (2): actually the contractor ID isn't used.
            if (ls_contractNo.Length > 0 && alcontract < 1)
            {
                alcontract = StaticFunctions.ToInt32(ls_contractNo).Value;
            }

            // TJB  RPCR_056  June-2013
            // Get allowance details into temporary file (t_invoice_allowances)
            dataService = ODPSDataService.GetODDWSInvoiceAllowanceDetail(alcontractor, alcontract, edate, alregion, li_ctKey);
            lreturn = dataService.LReturn;
            if (dataService.SQLCode < 0)
            {
                MessageBox.Show("Error running procedure GetODDWSInvoiceAllowanceDetail.\n"
                                + dataService.SQLErrText
                                , "Error [cb_open_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lreturn < 0)
            {
                MessageBox.Show("Error running procedure GetODDWSInvoiceAllowanceDetail.\n"
                                + "Error number is " + string.Format("Invoice", lreturn)
                                , "Error [cb_open_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Preprocess REACHMEDIA and CourierPost
            //  TJB SR4639
            //  select OD_RPF_Invoice_pay_piecerate_detailv2(:alcontractor,:edate,:alcontract,:alregion,:sname) into :lreturn from sys.dummy;
            // 
            //  TJB SR4684 June/2006
            //  Added ParcelPost

            // Get piecerate details into temporary file (t_invoice_piecerates)
            dataService = ODPSDataService.GetODRPFInvoicePayPiecerateDetail(alcontractor, edate, alcontract, alregion, sname, li_ctKey);
            lreturn = dataService.LReturn;
            if (dataService.SQLCode < 0)
            {
                MessageBox.Show("Error running procedure GetODRPFInvoicePayPiecerateDetail.\n" 
                                + dataService.SQLErrText
                                , "Error [cb_open_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lreturn < 0)
            {
                MessageBox.Show("Error running procedure GetODRPFInvoicePayPiecerateDetail.\n" 
                                + "Errornumber is " + string.Format("Invoice", lreturn)
                                , "Error [cb_open_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "Startdate", sdate);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "Enddate", edate);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "contractor", alcontractor);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "contract", alcontract);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "region", alregion);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "name", sname);
            StaticVariables.gnv_app.inv_ObjectMsg.of_addmsg("w_invoice", "ctKey", li_ctKey);

            OpenSheet<WInvoice>(this);
        }

        public virtual void dw_results_doubleclicked(object sender, EventArgs e)
        {
            cb_open_clicked(this, null);
        }

        public virtual void cb_export_clicked(object sender, EventArgs e)
        {
            // (Based on cb_open.clicked)
            int? alcontractor;
            int lreturn;
            int? alcontract;
            int? alregion;
            DateTime? sdate;
            DateTime? edate;
            string sname;
            //  TJB SR4639
            int? li_ctKey;
            string ls_contractNo;
            int ll_contractNo;
            int ll_row;
            int ll_rows;
            int ll_rowcount;

            Cursor.Current = Cursors.WaitCursor;
            dw_search.DataObject.AcceptText();
            ll_rows = dw_results.RowCount - 1;
            if (ll_rows < 0)
            {
                MessageBox.Show("You must search for a contractor"
                                ,"Invoice"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                return;
            }
            if (dw_search.GetValue(0, "end_date") == null)
            {
                MessageBox.Show("You must specify a period end date"
                                , "Invoice"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                return;
            }
            ll_row = dw_results.GetSelectedRow(0);
            if (ll_row < 0)
            {
                MessageBox.Show("You must select a contractor"
                                , "Invoice"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                return;
            }
            if (dw_results.GetValue(ll_row, "contractor_no") == null)
            {
                MessageBox.Show("You must select a contractor"
                                , "Invoice"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                return;
            }

            sdate = dw_search.GetValue<DateTime?>(0, "start_date");
            edate = dw_search.GetValue<DateTime?>(0, "end_date");
            alregion = dw_search.GetValue<int?>(0, "region_id");
            sname = dw_search.GetValue<string>(0, "owner_driver");
            alcontractor = dw_results.GetValue<int?>(ll_row, "contractor_no");
            alcontract = dw_results.GetValue<int?>(ll_row, "contract_no");

            if (alcontract == null) alcontract = 0;
            if (alregion == null) alregion = 0;
            if (sname == null) sname = "";

            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show ('sdate        = '+of_display(sdate)+'\n'
                             +'edate        = '+of_display(edate)+'\n'
                             +'alregion     = '+of_display(alregion)+'\n'
                             +'sname        = '+of_display(sname)+'\n'
                             +'alcontractor = '+of_display(alcontractor)+'\n'
                             +'alcontract   = '+of_display(alcontract)+'\n'
                             ,'w_invoice.cb_export.clicked' )
            // ---------------------------------------------------------  */
            //  TJB SR4639
            //  Get the contract type specified in the search criteria to pass 
            //  to the invoice calculation stored procedure so it can reproduce 
            //  the search if the user selected the 'all' option.

            li_ctKey = dw_search.GetValue<int?>(0, "ct_key");
            ls_contractNo = dw_search.GetValue<string>(0, "contract_no");
            if (li_ctKey == null) li_ctKey = 0;
            if (ls_contractNo == null) ls_contractNo = "";

            //  TJB: if a contract number was specified in the search criteria
            //  and the user selected the 'all' option, use that number.
            //  NOTE (1): there are situations where there will be more than one 
            //           contractor associated with a single contract  ( eg if the 
            //           contract changes hands during the invoice period).
            //  NOTE (2): actually the contractor ID isn't used.
            //if (lenw(ls_contractNo) > 0 && alcontract < 1) 
            if (ls_contractNo.Length > 0 && alcontract < 1)
            {
                alcontract = StaticFunctions.ToInt32(ls_contractNo);
            }

            // TJB  RPCR_056  June-2013
            // Get allowance details into temporary file (t_invoice_allowances)
            dataService = ODPSDataService.GetODDWSInvoiceAllowanceDetail(alcontractor, alcontract, edate, alregion, li_ctKey);
            lreturn = dataService.LReturn;
            if (dataService.SQLCode < 0)
            {
                MessageBox.Show("Error running procedure GetODDWSInvoiceAllowanceDetail.\n"
                                + dataService.SQLErrText
                                , "Error [cb_export_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lreturn < 0)
            {
                MessageBox.Show("Error running procedure GetODDWSInvoiceAllowanceDetail.\n"
                                + "Error number is " + string.Format("Invoice", lreturn)
                                , "Error [cb_export_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Preprocess REACHMEDIA and CourierPost
            //  TJB SR4639
            //  select OD_RPF_Invoice_pay_piecerate_detailv2(:alcontractor,:edate,:alcontract,:alregion,:sname) into :lreturn from sys.dummy;
            // 
            //  TJB SR4684 June/2006
            //  Added ParcelPost
            //  select odps.OD_RPF_Invoice_pay_piecerate_detailv3( 

            dataService = ODPSDataService.GetODRPFInvoicePayPiecerateDetail(alcontractor, edate, alcontract, alregion, sname, li_ctKey, 1);
            lreturn = dataService.LReturn;
            if (dataService.SQLCode < 0)
            {
                MessageBox.Show("Error running procedure OD_RPF_Invoice_pay_piecerate_detail.\n" 
                                + dataService.SQLErrText,
                                "SQL Error [cb_export_clicked]"
                                ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (lreturn < 0)
            {
                MessageBox.Show("Error running procedure OD_RPF_Invoice_pay_piecerate_detail.\n" 
                                +"Error number is " + string.Format("Invoice", lreturn)
                                , "Error [cb_export_clicked]"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int ll_rc = -1;
            DialogResult ll_file_select;
            int? ll_continue;
            int? ll_inv_id;
            int? ll_contract_no;
            int? ll_contractor_no;
            string ls_contractor_name = string.Empty;
            string ls_contractor_addr;
            string ls_contractor_gst;
            string ls_contract_title;
            string ls_invoice_no;
            string ls_ds_no;
            string ds_con_no;
            string ds_con_title;
            string ds_gst_no;
            string ds_sup_no;
            string ds_sup_name;
            string ds_sup_address;
            string ds_inv_no;
            string ds_inv_id;
            string ds_start_date;
            string ds_end_date;
            string ds_nat_address;
            string ds_nat_gst;
            string ds_prd_date;
            string ds_prt_code;
            string ds_prd_qty;
            string ds_prd_rate;
            string ds_prd_cost;
            string ds_tot_cost;
            string ls_message;
            string ls_temp;
            DateTime ldt_issue_date = DateTime.Now;                                         //?
            DateTime ldt_end_date = DateTime.Now;                                           //?
            DateTime ld_issue_date;
            DateTime ld_end_date;
            string ls_pathname = string.Empty;
            string ls_filename;
            //ids_invoice = new DataStore();
            ids_invoice = new URdsDw();
            ids_invoice.DataObject = new DwInvoiceHeaderOnly();

            //  Start procesing
            //  Get the set of invoices
            ((DwInvoiceHeaderOnly)ids_invoice.DataObject).Retrieve(sdate, edate, alcontractor, alcontract, alregion, sname, li_ctKey);
            ll_rowcount = ids_invoice.RowCount;
            MessageBox.Show(of_display(ll_rowcount)+" invoices found.\n\n" 
                            + "Please select a file to export the invoice details to."
                            , "Invoice Export"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
            ll_file_select = 0;
            ls_pathname = "C:\\rdsruntime\\rds_invoices_" + of_monthname(edate.Value) + edate.Value.Year.ToString() + ".txt";
            DialogResult li_ret;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Select File";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text Files  ( *.TXT)|*.TXT";
            saveFileDialog.FileName = ls_pathname;
            li_ret = saveFileDialog.ShowDialog();
            if (li_ret == DialogResult.Cancel)
                return;
            ll_file_select = li_ret;

            ls_pathname = saveFileDialog.FileName;
            ls_filename = ls_pathname.Substring(ls_pathname.LastIndexOf("\\") + 1);
            saveFileDialog.AddExtension = true;
            /*  ----------------------- Debugging ----------------------- //
            MessageBox.Show('ll_rc = '+of_display(ll_rc)+'\n'
                            +'ls_pathname = '+of_display(ls_pathname)+'\n'
                            +'ls_filename = '+of_display(ls_filename)+'\n'
                            ,'w_invoice.cb_export.clicked' );
            // ---------------------------------------------------------  */

            sw = new StreamWriter(ls_pathname);

            ids_detail_piecerates = new URdsDw();
            ids_detail_piecerates.DataObject = new DwInvoiceDetailPaymentPiecerates();

//            ids_detailkm = new URdsDw();
//            ids_detailkm.DataObject = new DwInvoiceDetailPaymentPrDetailkm();
//
//            ids_detailcp = new URdsDw();
//            ids_detailcp.DataObject = new DwInvoiceDetailPaymentPrDetailcp();
//
//            ids_detailxp = new URdsDw();
//            ids_detailxp.DataObject = new DwInvoiceDetailPaymentPrDetailxp();
//
//            //  TJB  SR4684  June/2006
//            ids_detailpp = new URdsDw();
//            ids_detailpp.DataObject = new DwInvoiceDetailPaymentPrDetailpp();

            ids_payment_details = new URdsDw();
            ids_payment_details.DataObject = new DwInvoiceDetailPayment();

            ids_payment_pr = new URdsDw();
            ids_payment_pr.DataObject = new DwInvoiceDetailPaymentPr();

            ids_payment_ded = new URdsDw();
            ids_payment_ded.DataObject = new DwInvoiceDetailPaymentDed();

            ids_allowance_breakdown = new URdsDw();
            ids_allowance_breakdown.DataObject = new DwInvoiceDetailAllowanceBreakdown();

            string ls_address;
            for (ll_row = 0; ll_row < ll_rowcount; ll_row++)
            {
                ll_inv_id = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).PaymentInvoiceId;
                ls_invoice_no = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).CinvoiceNo;
                ll_contract_no = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).ContractNo;

                ls_contract_title = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).ConTitle;
                ldt_issue_date = dw_search.GetValue<DateTime>(0, "end_date");
                ldt_end_date = dw_search.GetValue<DateTime>(0, "end_date");

                ll_contractor_no = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).ContractorContractorSupplierNo;
                ls_ds_no = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).DsNo;
                ls_contractor_name = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).Compute4;

                ls_contractor_addr = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).CAddress;
                ls_contractor_gst = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).CGstNumber;
                ls_message = ids_invoice.GetItem<InvoiceHeaderOnly>(ll_row).Cinvmessage;

                ls_contractor_gst = ls_contractor_gst == null ? null : ls_contractor_gst.Trim();
                ls_message = ls_message.Trim();
                ls_invoice_no = ls_invoice_no.Trim();
                ld_issue_date = System.Convert.ToDateTime(ldt_issue_date);
                ld_end_date = System.Convert.ToDateTime(ldt_end_date);
                is_contract = of_display(ll_contract_no);
                //  TJB  SR4685  July 2006
                //  Split the contractor's address into 4 address lines 
                //  and the post code.
                ls_address = of_split_address(ls_contractor_addr);
                ls_temp = "1" + "|" + of_output(ll_contract_no) 
                              + "|" + of_output(ls_contractor_gst) 
                              + "|" + of_output(ls_ds_no)       
                              + "|" + of_output(ls_contractor_name) 
                              + "|" + ls_address                
                              + "|" + of_output(ls_contract_title) 
                              + "|" + of_output(ld_end_date)    
                              + "|" + of_output(ld_issue_date) 
                              + "|" + of_output(ls_invoice_no)  
                              + "|" + of_output(ls_message);
                /*  ----------------------- Debugging ----------------------- //
                string ds_address = (ls_address == null) ? "NULL" : ls_address;
                MessageBox.Show("========== New Invoice ==========\n"  
                                +"Row = "+ll_row.ToString()+"\n"
                                +"Invoice ID  = "+ll_inv_id.ToString()+"\n"
                                +"- number    = "+ls_invoice_no+"\n"
                                +"Contract    = "+ll_contract_no.ToString()+"\n"
                                +"- title     = "+ls_contract_title+"\n"
                                +"- issued    = "+ld_issue_date.ToString()+"\n"
                                +"End date    = "+ld_end_date.ToString()+"\n"
                                +"Supplier No = "+ll_contractor_no.ToString()+"\n"
                                +"- name      = "+ls_contractor_name+"\n" 
                                +"- GST       = "+ls_contractor_gst+"\n" 
                                +"- address   = "+ds_address+"\n" 
                                +"Message     = "+ls_message+"\n" 
                                +"\n"
                                +ls_temp+"\n");
                // ---------------------------------------------------------  */
                ll_continue = 1;
                if (ll_continue == null || ll_continue == 1)
                {
                    try
                    {
                        //StreamWriter writeData = new StreamWriter(ii_file);
                        //writeData.WriteLine(ls_temp);
                        sw.WriteLine(ls_temp);
                    }
                    catch
                    {
                        MessageBox.Show("Error writing payee details record.\n" 
                                         + "Contract    = " + is_contract + "\n" 
                                         + "Return code = " + of_display(ll_rc)
                                        ,"Error"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    ll_rc = of_process_payment_details(ll_inv_id, edate, ll_contractor_no, ll_contract_no);
                    if (ll_rc < 0)
                    {
                        break;
                    }
                    ll_rc = of_process_payment_pr(ll_inv_id, edate);
                    if (ll_rc < 0)
                    {
                        break;
                    }
                    ll_rc = of_process_payment_ded(ll_inv_id);
                    if (ll_rc < 0)
                    {
                        break;
                    }
                    ll_rc = of_process_allowance_breakdown(ll_contract_no, ll_inv_id);
                    if (ll_rc < 0)
                    {
                        break;
                    }
                    // TJB  RPCR_054  June-2013: Added
                    // Replaces of_process_detail{km,cp,pp,xp}
                    ll_rc = of_process_detail_piecerates(ll_inv_id);
                    if (ll_rc < 0)
                    {
                        break;
                    }
//                    ll_rc = of_process_detailkm(ll_inv_id, ll_contract_no, ll_contractor_no, sdate, edate);
//                    if (ll_rc < 0)
//                    {
//                        break;
//                    }
//                    ll_rc = of_process_detailcp(ll_inv_id, ll_contract_no, ll_contractor_no, sdate, edate);
//                    if (ll_rc < 0)
//                    {
//                        break;
//                    }
//                    ll_rc = of_process_detailxp(ll_inv_id, ll_contract_no, ll_contractor_no, sdate, edate);
//                    if (ll_rc < 0)
//                    {
//                        break;
//                    }
//                    //  TJB  SR4684  June/2006
//                    //  Added support for ParcelPost
//                    ll_rc = of_process_detailpp(ll_inv_id, ll_contract_no, ll_contractor_no, sdate, edate);
//                    if (ll_rc < 0)
//                    {
//                        break;
//                    }
                }
                else if (ll_rc == 3)
                {
                    break;
                }
            }
            //FileClose(ii_file);
            sw.Close(); //?ii_file.Close();
            GC.Collect();
            MessageBox.Show("Invoice export completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void WInvoiceSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((NZPostOffice.Shared.VisualComponents.DateTimeMaskedTextBox)this.dw_search.GetControlByName("end_date")).SelectionStart == 10)
                this.ProcessDialogKey(Keys.Tab);
        }
        #endregion
    }
}
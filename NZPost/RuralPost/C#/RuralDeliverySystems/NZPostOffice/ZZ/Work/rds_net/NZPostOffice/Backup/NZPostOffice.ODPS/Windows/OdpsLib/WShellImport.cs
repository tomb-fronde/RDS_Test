using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.ODPS.Entity.OdpsLib;
using NZPostOffice.ODPS.DataControls.OdpsLib;

namespace NZPostOffice.ODPS.Windows.OdpsLib
{
    // TJB  RPCR_094  Mar-2015
    // Changed 'Shell deduction' to 'Fuel card deduction'
    // Changed name from SelectTShellImport to CountTShellImport
    // Changed InsertPostTaxAdjustments to InsertShellPostTaxAdjustments
    //  - Added Billdate parameter

    public partial class WShellImport : WMaster
    {
        public string is_docname = String.Empty;

        public WShellImport()
        {
            InitializeComponent();

            this.dw_import.DataObject = new DShellImport();
            dw_import.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }

        public override void close()
        {
            base.close();
        }

        public override int closequery()
        {
            return base.closequery();
        }

        public virtual void cb_import_clicked(object sender, EventArgs e)
        {
            int ll_import;
            int ll_rowcount;
            int ll_row;
            string ls_contract;
            string ls_contract_no = string.Empty;
            string ls_contractor = string.Empty;
            System.Decimal? dc_dollars;
            System.Decimal? dc_dollars_gst;
            System.Decimal? dc_discount;
            System.Decimal? dc_discount_gst;
            System.Decimal? dc_total_deduction;
            System.Decimal dc_sum_deduction;

            //  TJB SR4597 14 May 2004
            //  Add collection and display of summary values, and Continue? option
            //int li_ok;
            DialogResult li_ok;
            string ls_message;
            string ls_total_contracts;
            string ls_import_total;
            System.Decimal ld_import_total;
            ls_total_contracts = "";
            ls_import_total = "";
            ls_message = "";
            if (sle_filename.Text == "")
            {
                MessageBox.Show("Please click browse and select a file you wish to import."
                               , "Import"
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dw_import.InsertItem<ShellImport>(0);
            dw_import.Reset();

            //delete from odps.t_shell_import
            //if (StaticVariables.sqlca.SQLCode != 0)
            //{
            //    MessageBox.Show("Delete failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop );
            //    //  PBY 26/04/2002 added ROLLBACK to avoid table locking problem.
            //    return -(1);
            //}
            if (ODPSDataService.DeleteTShellImport() != 0)
            {
                MessageBox.Show("Delete failed"
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            ll_import = dw_import.ImportFile(sle_filename.Text, 1);
            Cursor.Current = Cursors.WaitCursor;
            ll_row = 0;
            ll_rowcount = dw_import.RowCount;
            ODPSDataService service;
            while (ll_rowcount > ll_row)
            {
                ls_contract = dw_import.GetItem<ShellImport>(ll_row).Column7;
                dc_dollars = dw_import.GetItem<ShellImport>(ll_row).Column15;
                dc_dollars_gst = dw_import.GetItem<ShellImport>(ll_row).Column16;
                dc_discount = dw_import.GetItem<ShellImport>(ll_row).Column17;
                dc_discount_gst = dw_import.GetItem<ShellImport>(ll_row).Column18;
                dc_total_deduction = dc_dollars + dc_dollars_gst - (dc_discount + dc_discount_gst);
                if (!(ls_contract == null))
                {
                    ls_contract_no = ls_contract.Substring(0, 5);
                    if (ls_contract.Length > 46)
                        ls_contractor = ls_contract.Substring(6, 40);
                    else
                        ls_contractor = ls_contract.Substring(6);
                }
                //insert into odps.t_shell_import(contract_no,contractor,total_deduction)
                //values(:ls_contract_no,:ls_contractor,:dc_total_deduction) using sqlca;
                service = ODPSDataService.InsertTShellImport(ls_contract_no, ls_contractor, dc_total_deduction);
                if (service.SQLCode != 0)
                {
                    MessageBox.Show(service.SQLErrText, 
                                   "Error inserting into t_shell_import");
                    return;
                }
                ll_row++;
            }
            // TJB  RPCR_094  Mar-2015
            // Changed name from SelectTShellImport to CountTShellImport
            //
            // TJB SR4597 (May 2004)
            //  Query the database for the summary info
            //  then ask if the user wants to continue.
            //     select count(distinct(contract_no)), sum(total_deduction) 
            //       into :ls_total_contracts, :ls_import_total 
            //       from odps.t_shell_import 

            service = ODPSDataService.CountTShellImport();
            if (service.SQLCode != 0)
            {
                ls_message = "Error obtaining summary totals from t_shell_import";
                MessageBox.Show(ls_message + "\n" 
                               + service.SQLErrText
                               , "Error"
                               , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                ls_total_contracts = service.shellImport.ContractNo;
                ls_import_total = service.shellImport.TotalDeduction.ToString();
            }
            ld_import_total = Convert.ToDecimal(ls_import_total);
            ls_message = "Totals: " + "\n"
                         + "Records  " + ll_import.ToString() + "\n"
                         + "Contracts  " + ls_total_contracts + "\n"
                         + "Value   " + (ld_import_total == 0 ? "" : ld_import_total.ToString("$###,###.##"));

            li_ok = MessageBox.Show(ls_message
                                   , "Summary"
                                   , MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (li_ok != DialogResult.OK)
            {
                MessageBox.Show("Import cancelled"
                               , ""
                               ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                ll_import = 0;
            }

            if (ll_import > 0)
            {
                // Insert shell data into post_tax_adjustments

                // Determine billing date (month/year one month ago)
                DateTime billdate = DateTime.Today.AddDays(-30);
                string sBilldate = billdate.ToString("MMM yyyy");

                // TJB  RPCR_094  Mar-2015
                // Changed InsertPostTaxAdjustments to InsertShellPostTaxAdjustments
                // Added Billdate parameter
                service = ODPSDataService.InsertShellPostTaxAdjustments(sBilldate);
                if (service.SQLCode != 0)
                {
                    MessageBox.Show("Error inserting into post_tax_deductions\n\n"
                                    + service.SQLErrText
                                   , "Error");
                    return;
                }

                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ll_import.ToString() + " Records Imported"
                               ,"Import complete");
            }
        }

        public virtual void cb_close_clicked(object sender, EventArgs e)
        {
            dw_import.Reset();
            this.Close();
        }

        public virtual void cb_browse_clicked(object sender, EventArgs e)
        {
            string ls_named;
            int li_value;
            dw_import.Reset();
            //li_value = GetFileOpenName("Select File", is_docname, ls_named, "DOC", "Text Files  ( *.TXT),*.TXT,");
            //sle_filename.text = is_docname;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.AddExtension = true;
            dialog.DefaultExt = "DOC";
            dialog.Filter = "Text Files (*.TXT)|*.TXT";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                is_docname = dialog.FileName;
                sle_filename.Text = is_docname;
            }
        }
    }
}
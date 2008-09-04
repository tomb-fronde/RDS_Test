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
            base.close();// this.Close();
        }

        public override int closequery()
        {
            //close(this);
            return base.closequery();
        }

        #region Events
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
                MessageBox.Show("Please click browse and select a file you wish to import.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dw_import.InsertItem<ShellImport>(0);
            dw_import.Reset();
            //delete from odps.t_shell_import
            //using sqlca;
            //if (StaticVariables.sqlca.SQLCode != 0)
            //{
            //    MessageBox.Show ( "Delete failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop );
            //    //  PBY 26/04/2002 added ROLLBACK to avoid table locking problem.
            //?               ROLLBACK;
            //    return -(1);
            //}
            if (ODPSDataService.DeleteTShellImport() != 0)
            {
                MessageBox.Show("Delete failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //ll_import = dw_import.ImportFile(sle_filename.Text, 2);
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
                    ls_contract_no = ls_contract.Substring(0, 5);//TextUtil.Left(ls_contract, 5);
                    if (ls_contract.Length > 46)  //jlwang
                        ls_contractor = ls_contract.Substring(6, 40);//TextUtil.Mid (ls_contract, 7, 40);
                    else
                        ls_contractor = ls_contract.Substring(6);
                }
                //insert into odps.t_shell_import ( contract_no,contractor,total_deduction)
                //values ( :ls_contract_no,:ls_contractor,:dc_total_deduction) using sqlca;
                service = ODPSDataService.InsertTShellImport(ls_contract_no, ls_contractor, dc_total_deduction);
                if (service.SQLCode != 0)
                {
                    MessageBox.Show(service.SQLErrText, "Error inserting into t_shell_import");
                    return;
                }
                ll_row++;
            }
            //  TJB SR4597  ( May 2004)
            //  Query the database for the summary info
            //  then ask if the user wants to continue.
            //select count ( distinct ( contract_no)), sum ( total_deduction) into :ls_total_contracts, :ls_import_total from odps.t_shell_import 
            //using sqlca;

            service = ODPSDataService.SelectTShellImport();
            if (service.SQLCode != 0)
            {
                ls_message = "Error obtaining summary totals from t_shell_import";
                MessageBox.Show(ls_message + "          " + service.SQLErrText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //? ROLLBACK;
                return;
            }
            else
            {
                ls_total_contracts = service.shellImport.ContractNo;
                ls_import_total = service.shellImport.TotalDeduction.ToString();
            }
            ld_import_total = Convert.ToDecimal(ls_import_total);
            ls_message = "Totals: " + "\r";
            ls_message = ls_message + "Contracts  " + ls_total_contracts + "\r";
            ls_message = ls_message + "Value   " + (ld_import_total == 0 ? "" : ld_import_total.ToString("$###,###.##"));
            li_ok = MessageBox.Show(ls_message, "Summary", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (li_ok == 2) 
            if (li_ok == DialogResult.Cancel)
            {
                MessageBox.Show("Import cancelled", "",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ll_import = 0;
            }
            if (ll_import > 0)
            {
                // insert shell data into post_tax_adjustments
                //INSERT INTO odps.post_tax_deductions  
                // (  ded_id,   
                //ded_description,   
                //ded_priority,   
                //pct_id,   
                //ded_reference,   
                //ded_type_period,   
                //ded_percent_gross,   
                //ded_percent_net,   
                //ded_percent_start_balance,   
                //ded_fixed_amount,   
                //ded_min_threshold_gross,   
                //ded_max_threshold_net_pct,   
                //ded_default_minimum,   
                //ded_start_balance,   
                //ded_end_balance,   
                //contractor_supplier_no,   
                //ded_pay_highest_value )
                //select null,
                //'Shell Deduction Month' + ' ' + string ( Month ( Today ( )-30)),
                //1,   				
                //6,    				
                //'Shell Deductions imported on ' || string ( today ( )),
                //'M',   
                //null, 
                //null, 
                //null, 
                //sum ( total_deduction),
                //null,    	
                //null,      	
                //sum ( total_deduction), 
                //sum ( total_deduction), 
                //sum ( total_deduction),
                // (  SELECT rd.contractor_renewals.contractor_supplier_no  
                //FROM rd.contract,   
                //rd.contract_renewals,   
                //rd.contractor_renewals  
                //WHERE rd.contract_renewals.contract_no = rd.contract.contract_no and  
                //rd.contract.con_active_sequence = rd.contract_renewals.contract_seq_number  and  
                //rd.contractor_renewals.contract_no = rd.contract_renewals.contract_no  and  
                //rd.contractor_renewals.contract_seq_number = rd.contract_renewals.contract_seq_number  and  
                //rd.contractor_renewals.cr_effective_date = 
                // ( select max ( cr_effective_date) 
                //from   rd.contractor_renewals cr 
                //where  cr.contract_no         = contract_renewals.contract_no 
                //and    cr.contract_seq_number = contract_renewals.contract_seq_number 
                //and    cr_effective_date      <= getdate ( ) ) 
                //and contract.contract_no = t_shell_import.contract_no) as contractor,
                //0
                //from odps.t_shell_import
                //group by contract_no, contractor
                //using SQLCA;
                service = ODPSDataService.InsertPostTaxAdjustments();
                if (service.SQLCode != 0)
                {
                    MessageBox.Show(service.SQLErrText, "Error inserting into post_tax_deductions");
                    //ROLLBACK
                    return;
                }
                //commit; 

                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Import complete", "" + ll_import.ToString() + " Rows Imported");
            }
            //  select    null,   			//id
            //            'Shell Deduction Month' + ' ' + string ( Month ( Today ( )-30)), //description  
            //            1,   				//priority
            //            6,    				//later, grab the proper type of the description
            //            'Shell Deductions imported on ' || string ( today ( )),    //reference
            //            'M',   
            //            null,   //% of gross
            //            null,   //% of net
            //            null,   //%of start balance
            //            total_deduction,   //fixed amount
            //            null,    		//min threshold gross
            //            null,      		//min threshold net at 0 = may use all of net pay
            //            total_deduction,   //default minimum
            //            total_deduction,   //start balance
            //            total_deduction,   //end balance
            //  (  SELECT rd.contractor_renewals.contractor_supplier_no  
            //     FROM rd.contract,   
            //          rd.contract_renewals,   
            //          rd.contractor_renewals  
            //    WHERE rd.contract_renewals.contract_no = rd.contract.contract_no and  
            //          rd.contract.con_active_sequence = rd.contract_renewals.contract_seq_number  and  
            //          rd.contractor_renewals.contract_no = rd.contract_renewals.contract_no  and  
            //          rd.contractor_renewals.contract_seq_number = rd.contract_renewals.contract_seq_number  and  
            //          rd.contractor_renewals.cr_effective_date = 
            // 			      ( select max ( cr_effective_date) 
            //                from   rd.contractor_renewals cr 
            //               	where  cr.contract_no         = contract_renewals.contract_no 
            //                and    cr.contract_seq_number = contract_renewals.contract_seq_number 
            //                and    cr_effective_date      <= getdate ( ) ) 
            // 					and contract.contract_no = t_shell_import.contract_no) as contractor,
            // 		          0              //pay highest value
            //   from odps.t_shell_import
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
            dialog.Filter = "Text Files  ( *.TXT)|*.TXT";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                is_docname = dialog.FileName;
                sle_filename.Text = is_docname;
            }
        }
        #endregion
    }
}
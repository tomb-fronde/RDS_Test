using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Controls;
using NZPostOffice.ODPS.DataControls.OdpsPayrun;
using NZPostOffice.Shared;
using NZPostOffice.ODPS.DataService;
using NZPostOffice.ODPS.Entity.OdpsPayrun;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace NZPostOffice.ODPS.Windows.OdpsPayrun
{
    // TJB  RPCR_143  Sep-2019
    // Removed cb_print button and associated references
    // here and in designer
    //
    // TJB  RPCR_094  Mar-2015
    // Fix negative pay reporting. See pfc_postopen.

    public partial class WPaymentRunResults : WMaster
    {
        #region Define
        public DateTime? id_Enddate = DateTime.MinValue;

        public int? ilcontr;
        #endregion

        public WPaymentRunResults()
        {
            this.InitializeComponent();

            this.dw_2.DataObject = new DwAcceptRejectMainrundetailGrid();
            this.dw_1.DataObject = new DwAcceptRejectMainrunGrid();
            this.dw_negative.DataObject = new DwPayrunNegativepay();
            dw_negative.DataObject.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            ((Metex.Windows.DataEntityGrid)dw_1.GetControlByName("grid")).DoubleClick += new EventHandler(dw_1_doubleclicked);
        }

        public override void open()
        {
            base.open();
            int lcount;
            bool lb_valid;
            ((DwAcceptRejectMainrunGrid)dw_1.DataObject).Retrieve();
            WPaymentRunSearch w_payment_run_search = (WPaymentRunSearch)StaticMessage.PowerObject;
            //lb_valid = IsValid(w_payment_run_search);
            if (w_payment_run_search != null)
            {
                id_Enddate = w_payment_run_search.wf_getenddate();
            }
            else
            {
                MessageBox.Show("Cannot grab period end date", "Fatal Error");
                cb_accept.Enabled = false;
            }
            lcount = dw_1.RowCount;
            if (lcount > 0)
            {
                double temp;
                temp = StaticMessage.DoubleParm / lcount;
                // st_processingtime.Text = "Processing time: " + StaticMessage.DoubleParm.ToString() + " seconds  ( " + String(Truncate(StaticMessage.DoubleParm / lcount, 2)) + " seconds per contract-O/D)";
                st_processingtime.Text = "Processing time: " + Convert.ToInt32(StaticMessage.DoubleParm).ToString() + " seconds " 
                                         + "(" + string.Format("{0:F2}",temp) + " seconds per contract-O/D)";
            }
        }

        public override void pfc_postopen()
        {
            base.pfc_postopen();
            int lcount;
            if (dw_1.RowCount == 0)
            {
                MessageBox.Show("Nobody got paid anything", "Payment Run");
                this.Close();
            }
            // TJB  RPCR_094  Mar-2015
            // Created WNegativePayReport and got working here

            // Find out if any negative pays were produced and if so print a list of them
            dw_negative.Retrieve();
            if (dw_negative.RowCount > 0)
            {
                string Pays;
                Pays = (dw_negative.RowCount > 1) ? "pays" : "pay";
                cb_accept.Enabled = false;
                MessageBox.Show(dw_negative.RowCount.ToString() + " Negative "+Pays+" detected!\n\n"
                                + "Negative pay report will be displayed"
                                , "Warning!"
                                , MessageBoxButtons.OK, MessageBoxIcon.Stop);

                Cursor.Current = Cursors.WaitCursor;
                StaticVariables.gnv_app.of_get_parameters().dateparm = id_Enddate;
                WNegativePayReport w_negative_pay_report = new WNegativePayReport();

                w_negative_pay_report.ShowDialog();
            }

            //SELECT count(t_posttax_deductions_not_applied.ded_id)
            //  INTO :lcount 
            //  FROM t_posttax_deductions_not_applied;
            ODPSDataService dataservice = ODPSDataService.GetCountFromTPosttaxDeductionsNotApplied();
            lcount = dataservice.Count; 

            if (lcount > 0)
            {
                MessageBox.Show("Not all post-tax deductions are automatically deducted"
                               , base.Text);
                //open(w_payment_manual_adjustment);
                WPaymentManualAdjustment w_payment_manual_adjustment = new WPaymentManualAdjustment();
                w_payment_manual_adjustment.ShowDialog();
                cb_deduct.Visible = true;
            }
        }

        public virtual void dw_2_constructor()
        {
            //?dw_2.of_setsort(true);
        }

        public virtual void dw_1_constructor()
        {
            //?dw_1.of_setsort(true);
        }

        public virtual void constructor()
        {
        }

        #region Events
        public virtual void cb_accept_clicked(object sender, EventArgs e)
        {
            int lAcceptResults;
            if (MessageBox.Show("Are you sure you want to accept the results?"
                               , "Accepting the Payment Run"
                               , MessageBoxButtons.YesNo
                               , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;

                //select od_blf_mainrun_accept ( :id_Enddate) into :lAcceptResults from sys.dummy;
                ODPSDataService dataservice = ODPSDataService.GetOdBlfMainrunAcceptFromDummy(id_Enddate);
                lAcceptResults = dataservice.LAcceptResults;

                if (lAcceptResults < 0 || dataservice.SQLCode < 0)
                {
                    MessageBox.Show(Convert.ToString(dataservice.SQLCode) 
                                    + " Error text: " + dataservice.SQLErrText + "\n" 
                                    + "Error accepting run results - Ref#" + Convert.ToString(lAcceptResults));
                    //  CloseWithReturn(parent, -(1));
                    StaticMessage.IntegerParm = -1;
                    this.Close();
                }
                else
                {
                    // CloseWithReturn(parent, 1);
                    StaticMessage.IntegerParm = 1;
                    this.Close();
                }
            }
        }

        public virtual void cb_reject_clicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reject the results?"
                               , "Rejecting the Payment Run"
                               , MessageBoxButtons.YesNo
                               , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                //DELETE FROM t_posttax_deductions_not_applied  commit;
                ODPSDataService dataservice = ODPSDataService.DeleteFromTPosttaxDeductionsNotApplied();

                //CloseWithReturn(parent, -(1));
                StaticMessage.IntegerParm = -1;
                this.Close();
            }
        }

        public virtual void cb_details_clicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dw_2.Visible)
            {
                cb_details.Text = "&Details";
                dw_2.Visible = false;
                dw_1.Visible = true;
            }
            else
            {
                cb_details.Text = "&Summary";
                dw_2.Visible = true;
                if (dw_2.RowCount == 0)
                {
                    ((DwAcceptRejectMainrundetailGrid)dw_2.DataObject).Retrieve();
                    ((Metex.Windows.DataEntityGrid)((DwAcceptRejectMainrundetailGrid)dw_2.DataObject).GetControlByName("grid")).Rows[0].Selected = false;
                }
                dw_1.Visible = false;
            }
        }

        public virtual void cb_deduct_clicked(object sender, EventArgs e)
        {
            //open(w_payment_manual_adjustment);
            WPaymentManualAdjustment w_payment_manual_adjustment = new WPaymentManualAdjustment();
            w_payment_manual_adjustment.ShowDialog();
        }

        public virtual void dw_1_doubleclicked(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int ll_found;

            if (dw_1.GetRow() < 0)
            {
                return;
            }
            ilcontr = dw_1.DataObject.GetItem<AcceptRejectMainrunGrid>(dw_1.GetRow()).ContractNo;
            if (dw_2.RowCount == 0)
            {
                ((DwAcceptRejectMainrundetailGrid)dw_2.DataObject).Retrieve();
            }
            dw_2.Visible = true;
            cb_details.Text = "&Summary";
            dw_2.Visible = true;
            if (dw_2.RowCount == 0)
            {
                ((DwAcceptRejectMainrundetailGrid)dw_2.DataObject).Retrieve();
            }
            dw_1.Visible = false;
            // ll_found = dw_2.Find(("contract_no = " + ilcontr).ToString().Length);
            if (ilcontr != null)
            {
                ll_found = dw_2.DataObject.Find("contract_no", ilcontr);
                if (ll_found > 0)
                {
                    dw_2.SetCurrent(ll_found);
                }
            }
        }
        #endregion
    }
}
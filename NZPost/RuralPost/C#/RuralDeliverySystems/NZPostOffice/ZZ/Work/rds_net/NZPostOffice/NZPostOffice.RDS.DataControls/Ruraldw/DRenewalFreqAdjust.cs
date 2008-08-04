using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DRenewalFreqAdjust : Metex.Windows.DataUserControl
    {
        public DRenewalFreqAdjust()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

            pct_id.AssignDropdownType<DddwPaymentComponents>("PctId", "PctDescription");
        }


         public System.Windows.Forms.TextBox StConfirmAccess
            {
                get
                {
                    return this.st_confirm_access;   
                }
            }

        public int Retrieve(int? contract_no, int? sequence)
        {
            decimal? total1 = 0;
            decimal? total2 = 0;
            decimal? total3 = 0;
            List<RenewalFreqAdjust> rstList = new List<RenewalFreqAdjust>(RenewalFreqAdjust.GetAllRenewalFreqAdjust(contract_no, sequence));
            foreach (RenewalFreqAdjust renewalFreqAdjust in rstList)
            {
                if (renewalFreqAdjust.FdAdjustmentAmount != null)
                {
                    total1 += renewalFreqAdjust.FdAdjustmentAmount;
                }
                if (renewalFreqAdjust.FdAmountToPayDisplayOnly != null)
                {
                    total2 += renewalFreqAdjust.FdAmountToPayDisplayOnly;
                }
                if (renewalFreqAdjust.FdConfirmed == "Y")
                {
                    total3 += renewalFreqAdjust.FdAmountToPayDisplayOnly;
                }
            }

            compute_2.Text = string.Format("{0:#,##0.00;(#,##0.00)}", total1);
            compute_3.Text = string.Format("{0:#,##0.00;(#,##0.00)}", total2);
            compute_4.Text = "(Confirmed:" + string.Format("{0:#,##0.00;(#,##0.00)}", total3) + ")";

            if (rstList.Count == 0)
            {
                compute_2.Visible = false;
                compute_3.Visible = false;
                compute_4.Visible = false;
                line1.Visible = false;
                line2.Visible = false;
                line3.Visible = false;
            }
            else
            {
                compute_2.Visible = true;
                compute_3.Visible = true;
                compute_4.Visible = true;
                line1.Visible = true;
                line2.Visible = true;
                line3.Visible = true;
            }           

            return RetrieveCore<RenewalFreqAdjust>(new List<RenewalFreqAdjust>
                (RenewalFreqAdjust.GetAllRenewalFreqAdjust(contract_no, sequence)));
        }
    }
}

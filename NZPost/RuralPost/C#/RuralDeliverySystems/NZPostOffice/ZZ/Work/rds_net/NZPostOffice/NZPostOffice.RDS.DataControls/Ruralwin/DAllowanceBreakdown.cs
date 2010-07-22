using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    public partial class DAllowanceBreakdown : Metex.Windows.DataUserControl
    {
        // TJB  RPCR_017 July-2010
        // Added 'Approved' column + associated layout changes
        // Added setTotal method so WAllowanceBreakdown can 
        // save recalculated compute_1 value.

        public DAllowanceBreakdown()
        {
            InitializeComponent();
        }

        // TJB  RPCR_017 July-2010: added
        // Called from WAllowanceBreakdown when a record is deleted.
        public void setTotal(decimal? newTotal)
        {
            // Resets the total (Compute1)
            this.compute_1.Text = "$" + string.Format("{0:#,##0.00}", newTotal);
        }

        public int Retrieve(int? inContractNo, int? inAltKey)
        {
            //compute column 
            decimal? total = 0;
            List<AllowanceBreakdown> rstList = new List<AllowanceBreakdown>(AllowanceBreakdown.GetAllAllowanceBreakdown(inContractNo, inAltKey));

            foreach (AllowanceBreakdown allowanceBreakdown in rstList)
            {
                if (allowanceBreakdown.AnnualAmount != null)
                {
                    total += allowanceBreakdown.AnnualAmount;
                }
            }
            compute_1.Text = "$" + string.Format("{0:#,##0.00}", total);

            this.grid.Height = rstList.Count * this.grid.RowTemplate.Height + this.grid.ColumnHeadersHeight;
            this.compute_1.Top = this.grid.Top + this.grid.Height + 5;
            this.panel2.Top = this.grid.Top + this.grid.Height + 3;

            return RetrieveCore<AllowanceBreakdown>(new List<AllowanceBreakdown>
                (AllowanceBreakdown.GetAllAllowanceBreakdown(inContractNo, inAltKey)));
        }
    }
}

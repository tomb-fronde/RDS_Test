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
    // TJB  Allowances  26-Apr-2021
    // Added Net Amount and Doc Description columns
    //
    // TJB  RPCR_017 July-2010
    // Added 'Approved' column + associated layout changes
    // Added setTotal method so WAllowanceBreakdown can 
    // save recalculated compute_1 value.

    public partial class DAllowanceBreakdown : Metex.Windows.DataUserControl
    {
        public DAllowanceBreakdown()
        {
            InitializeComponent();

            // These settings allow the row height to adjust to the text if it wraps.
            this.doc_description.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.doc_description.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        // TJB  RPCR_017 July-2010: added
        // Called from WAllowanceBreakdown when a record is deleted.
        public void setTotal(decimal? newTotal)
        {
            // Resets the total (Compute1)
            this.compute_11.Text = "$" + string.Format("{0:#,##0.00}", newTotal);
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
            compute_11.Text = "$" + string.Format("{0:#,##0.00}", total);

            this.grid.Height = rstList.Count * this.grid.RowTemplate.Height + this.grid.ColumnHeadersHeight;
            this.compute_11.Top = this.grid.Top + this.grid.Height + 5;
            this.panel2.Top = this.grid.Top + this.grid.Height + 3;

            return RetrieveCore<AllowanceBreakdown>(new List<AllowanceBreakdown>
                (AllowanceBreakdown.GetAllAllowanceBreakdown(inContractNo, inAltKey)));
        }
    }
}

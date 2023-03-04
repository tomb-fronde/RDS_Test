using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    // TJB  Allowances  1-Jun-2021: New
    // Data control for allowance_type history display

	public partial class DAllowanceTypeHistory : Metex.Windows.DataUserControl
	{
		public DAllowanceTypeHistory()
		{
			InitializeComponent();

            // For dates, it sets the prompt to '\0' instead of '0'
            this.alt_effective_date.PromptChar = '0';
            this.alt_effective_date.Mask = "00/00/0000";
            this.alt_effective_date.ValueType = typeof(System.DateTime);

            // These settings allow the row height to adjust to the text if it wraps.
            this.alt_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Needed to ignore data errors (probably null values)
            this.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
        }

        void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {  // Needed to ignore data errors (probably null values)
           //throw new Exception("The method or operation is not implemented.");
        }

        public int Retrieve(int? AltKey)
		{
			int ret = RetrieveCore<AllowanceTypeHistory>(new List<AllowanceTypeHistory>
                                (AllowanceTypeHistory.GetAllAllowanceTypeHistory(AltKey)));
            this.SortString = "alt_effective_date Desc";
            if(this.SortString != "")
                this.Sort<AllowanceTypeHistory>();
            return ret;
		}
    }
}

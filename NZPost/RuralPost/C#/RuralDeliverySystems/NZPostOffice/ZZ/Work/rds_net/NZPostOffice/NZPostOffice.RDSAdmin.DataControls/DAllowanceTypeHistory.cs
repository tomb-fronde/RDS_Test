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
    // TJB  Allowances  1-Jun-2021: Ney
    // Data control for allowance_type history display

	public partial class DAllowanceTypeHistory : Metex.Windows.DataUserControl
	{
		public DAllowanceTypeHistory()
		{
			InitializeComponent();
            InitializeDropdown();
            this.SortString = "alt_description A";

            // For dates, it sets the prompt to '\0' instead of '0'
            this.alt_effective_date.PromptChar = '0';
            this.alt_effective_date.Mask = "00/00/0000";
            this.alt_effective_date.ValueType = typeof(System.DateTime);

            // These settings allow the row height to adjust to the text if it wraps.
            this.alt_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.alt_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void InitializeDropdown()
        {
            alct_id.AssignDropdownType<DddwAllowanceCalcType>("AlctId", "AlctDescription");
        }

        public override int Retrieve(int? AltKey)
		{
			int ret = RetrieveCore<AllowanceTypeHistory>(new List<AllowanceTypeHistory>(AllowanceTypeHistory.GetAllAllowanceType(AltKey)));
            if(this.SortString != "")
                this.Sort<AllowanceTypeHistory>();
            return ret;
		}
    }
}

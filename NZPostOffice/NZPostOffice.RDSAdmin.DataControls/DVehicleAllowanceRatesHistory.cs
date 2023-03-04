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
    // TJB  Allowances 21-Apr-2021: New
    // Form for display of vehicle allowance rates history

	public partial class DVehicleAllowanceRatesHistory : Metex.Windows.DataUserControl
	{
		public DVehicleAllowanceRatesHistory()
		{
			InitializeComponent();

            // For dates, it sets the prompt to '\0' instead of '0'
            this.var_effective_date.PromptChar = '0';
            this.var_effective_date.Mask = "00/00/0000";
            this.var_effective_date.ValueType = typeof(System.DateTime);

            // These settings allow the row height to adjust to the text if it wraps.
            this.var_notes.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.var_notes.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public int Retrieve(int? VarId)
		{
			int ret = RetrieveCore<VehicleAllowanceRatesHistory>(new List<VehicleAllowanceRatesHistory>
                          (VehicleAllowanceRatesHistory.GetAllVehicleAllowanceRatesHistory(VarId)));
            this.SortString = "var_effective_date Desc";
            this.Sort<VehicleAllowanceRatesHistory>();
            return ret;
		}
	}
}

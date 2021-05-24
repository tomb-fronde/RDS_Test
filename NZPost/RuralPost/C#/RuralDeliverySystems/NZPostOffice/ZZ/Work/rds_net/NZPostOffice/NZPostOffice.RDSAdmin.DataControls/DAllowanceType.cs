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
    // TJB  Allowances  21-Apr-2021
    // Added AllowanceCalcType dropdown

	public partial class DAllowanceType : Metex.Windows.DataUserControl
	{
		public DAllowanceType()
		{
			InitializeComponent();
            InitializeDropdown();
            this.SortString = "alt_description A";
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            this.grid.DataError += new DataGridViewDataErrorEventHandler(grid_DataError);
            this.grid.Validating += new CancelEventHandler(grid_Validating);

		}

        private void InitializeDropdown()
        {
            alct_id.AssignDropdownType<DddwAllowanceCalcType>("AlctId", "AlctDescription");
        }

        public override int Retrieve()
		{
			int ret = RetrieveCore<AllowanceType>(new List<AllowanceType>(AllowanceType.GetAllAllowanceType()));
            if(this.SortString != "")
                this.Sort<AllowanceType>();
            return ret;
		}

        // TJB  Allowance  23-Apr-2021
        // The grid columns for this tab (see designer)
        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {  /********************************************************* *****
            * NOTE:                                                       *
            * The required values in the allowance_type table depend      *
            * on the calculation type (alct_id). If the alct_id value     *
            * changes, code here checks that some value has been entered  *
            * for the required values.                                    *
            * Calc type required values are:                              *
            * Fixed (1)    <none>                                         *
            * ROI (2)      Rate                                           *
            * Activity (3) Rate, Weeks                                    *
            * Time (4)     Rate, Weeks, Acc                               *
            * Distance (5) Rate, Weeks. ACC, Fuel, RUC                    *
            *    (plus factors in the vehicle_allowance_rates table)      *
            ***************************************************************/
            int column, thisRow;
            string column_name;

            thisRow = e.RowIndex;
            column = e.ColumnIndex;
            column_name = this.grid.Columns[column].Name;
            int? alct_id = 0;

            if (column_name == "alct_id")
            {
                alct_id = (int?)grid.Rows[thisRow].Cells["alct_id"].Value;
                if (alct_id == null)
                {
                    MessageBox.Show("Please select a calculation type.", ""
                                   , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

        }

        void grid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This gets around a problem where the user has entered one of the
            // fields then cleared it and wants to move on.  Without this,
            // the focus would stay in the field without 'saying' anything about why.

            int thisRow = this.grid.CurrentCell.RowIndex;
            string column = this.grid.CurrentColumnName;
            string errmsg = check_columns(thisRow, column);

            if (errmsg.Length > 0)
                MessageBox.Show(errmsg, ""
                              , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string column = this.grid.CurrentColumnName;

            if( column == "alct_id" )
                MessageBox.Show("Please select a calc type"
                                , "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if( column == "alt_description" )
                MessageBox.Show("Please enter a name for the allowance"
                                ,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
                MessageBox.Show("Please enter a value (or Ctrl-0 for null)"
                                , "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string  check_columns( int thisRow, string column )
        {
            string errmsg = "";
            if (column == "alt_description" && grid.Rows[thisRow].Cells["alt_description"].Value == null)
            {
                errmsg += "Please enter a name for this allowance type.\n";
                return errmsg;
            }

            if( column == "alct_id")
            {
                int? nAlctId = (int?)grid.Rows[thisRow].Cells["alct_id"].Value;
                string sAlctId = (string)grid.Rows[thisRow].Cells["alct_id"].EditedFormattedValue;
                if ((nAlctId == null || nAlctId == 0)
                    || sAlctId == null || sAlctId == "")
                errmsg += "Please select a calc type. \n";
                return errmsg;
            }
            return errmsg;
        }

    }
}

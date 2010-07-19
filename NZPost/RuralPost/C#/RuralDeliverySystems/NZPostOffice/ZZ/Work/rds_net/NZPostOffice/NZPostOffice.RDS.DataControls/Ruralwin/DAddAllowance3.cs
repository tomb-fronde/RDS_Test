using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DAddAllowance3 : Metex.Windows.DataUserControl
	{
		public DAddAllowance3()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

	        protected override void OnHandleCreated(EventArgs e)
        	{
	            if (!DesignMode)
        	    {
                	InitializeDropdown();
	            }
    
	            base.OnHandleCreated(e);
        	}

		private void InitializeDropdown()
		{
			alt_key.AssignDropdownType<DddwAllowanceTypes>();
		}

		public int Retrieve( int? inContract, DateTime? inEffDate)
		{
            set_row_readability();
            return RetrieveCore<AddAllowance2>(new List<AddAllowance2>
			                           	(AddAllowance2.GetAllAddAllowance(inContract, inEffDate)));
		}

        public void SetGridCellSelected(int pRow, string pColumnName, bool pValue)
        {
            this.grid.Rows[pRow].Cells[pColumnName].Selected = pValue;
            for (int i = 0; i < this.grid.ColumnCount; i++)
                if (this.grid.Columns[i].Name == pColumnName)
                {
                    this.grid.Rows[pRow].Cells[i].Selected = pValue;
                    break;
                }
        }

        public void SetGridRowReadOnly(int pRow, bool pValue)
        {
            this.grid.Rows[pRow].ReadOnly = pValue;
        }

        public bool GetGridRowReadOnly(int pRow)
        {
            return this.grid.Rows[pRow].ReadOnly;
        }

        public void SetGridColumnReadOnly(string pColumnName, bool pValue)
        {
            for (int i = 0; i < this.grid.ColumnCount; i++)
                if (this.grid.Columns[i].Name == pColumnName)
                {
                    this.grid.Columns[i].ReadOnly = pValue;
                    break;
                }
        }
    }
}

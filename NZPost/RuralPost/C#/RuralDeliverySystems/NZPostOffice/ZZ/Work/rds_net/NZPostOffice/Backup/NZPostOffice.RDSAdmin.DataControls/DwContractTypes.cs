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
	public partial class DwContractTypes : Metex.Windows.DataUserControl
	{
		public DwContractTypes()
		{
			InitializeComponent();
            this.SortString = "contract_type_contract_type A";
		}

		public int Retrieve( int al_ui_id )
		{
			int ret = RetrieveCore<ContractTypes>(new List<ContractTypes>
				(ContractTypes.GetAllContractTypes( al_ui_id )));
            if(this.SortString != "" && this.SortString != null)
                this.Sort<ContractTypes>();
            return ret;
		}

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Metex.Windows.DataEntityGrid grid = (Metex.Windows.DataEntityGrid)sender; 

            
        }

        public event EventHandler CellClick;

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (CellClick != null)
                {
                    this.CellClick(sender, e);
                }
            }
        }
	}
}

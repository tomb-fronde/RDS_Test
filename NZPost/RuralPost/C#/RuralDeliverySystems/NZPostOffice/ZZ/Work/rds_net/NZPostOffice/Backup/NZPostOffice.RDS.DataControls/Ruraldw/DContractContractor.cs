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
    public partial class DContractContractor : Metex.Windows.DataUserControl
	{
		public DContractContractor()
		{
			InitializeComponent();
            grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            grid.CellValueChanged += new DataGridViewCellEventHandler(grid_CellValueChanged);
		}

        void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (CellValueChanged != null)
                this.CellValueChanged(sender, e);
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(CellClick != null && e.ColumnIndex == 2)
                this.CellClick(sender, e);
        }

		public int Retrieve( int? contract_no, int? contract_seq_number )
		{
			return RetrieveCore<ContractContractor>(new List<ContractContractor>
				(ContractContractor.GetAllContractContractor( contract_no, contract_seq_number )));
		}
        public event EventHandler CellClick;
        public event EventHandler CellValueChanged;
	}
}

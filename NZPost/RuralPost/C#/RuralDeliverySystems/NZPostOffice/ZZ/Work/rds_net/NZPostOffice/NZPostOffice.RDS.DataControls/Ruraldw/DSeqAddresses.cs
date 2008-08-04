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
	public partial class DSeqAddresses : Metex.Windows.DataUserControl
	{
		public DSeqAddresses()
		{
			InitializeComponent();

            grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            grid.CellMouseDown += new DataGridViewCellMouseEventHandler(grid_CellMouseDown);
		}

        void grid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CellMouseDown != null)
                CellMouseDown(sender, e);
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
                CellClick(sender,e);
        }

		public int Retrieve( int? al_contract_no, int? al_sf_key, string as_rf_delivery_days )
		{
			int rowCount = RetrieveCore<SeqAddresses>(new List<SeqAddresses>
				(SeqAddresses.GetAllSeqAddresses(al_contract_no, al_sf_key, as_rf_delivery_days )));
            if(rowCount>0)
                this.SortString = "seq_num A";
                this.Sort<SeqAddresses>();
            return rowCount;
		}

        public event EventHandler CellClick;
        public event DataGridViewCellMouseEventHandler CellMouseDown;
	}
}

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
	public partial class DUnseqAddresses : Metex.Windows.DataUserControl
	{
		public DUnseqAddresses()
		{
			InitializeComponent();

            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            this.grid.CellMouseEnter += new DataGridViewCellEventHandler(grid_CellMouseEnter);
            this.SortString = "RoadName A,AdrNoNumeric A,AdrAlpha A,AdrUnit A,Customer A";
		}

        void grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (CellMouseEnter != null)
            {
                CellMouseEnter(sender, e);
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

		public int Retrieve( int? al_contract_no, int? al_sf_key, string as_rf_delivery_days )
		{
			int rowCount = RetrieveCore<UnseqAddresses>(new List<UnseqAddresses>
				(UnseqAddresses.GetAllUnseqAddresses(al_contract_no,al_sf_key,as_rf_delivery_days)));
            if (rowCount > 0)
                this.Sort<UnseqAddresses>();
            return rowCount;
		}

        public event EventHandler CellClick;
        public event DataGridViewCellEventHandler CellMouseEnter;
	}
}

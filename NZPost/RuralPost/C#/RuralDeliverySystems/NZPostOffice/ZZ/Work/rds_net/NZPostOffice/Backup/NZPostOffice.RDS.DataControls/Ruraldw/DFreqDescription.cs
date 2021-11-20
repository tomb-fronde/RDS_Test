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
	public partial class DFreqDescription : Metex.Windows.DataUserControl
	{
		public DFreqDescription()
		{
			InitializeComponent();
			InitializeDropdown();
            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
		}

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null && e.ColumnIndex == 3 && ((NZPostOffice.RDS.DataControls.Ruraldw.DGVCustomButtonCell)(this.grid.Rows[e.RowIndex].Cells[3])).Enabled)
            {
                CellClick(sender, e);
            }
        }

        public Metex.Windows.DataEntityGrid Grid 
        {
            get
            {
                return grid;
            }
        }

		private void InitializeDropdown()
		{
			rfv_id.AssignDropdownType<DddwVerbs>("RfvId","RfvDescription");
            rfv_id_2.AssignDropdownType<DddwVerbs>("RfvId", "RfvDescription");
            rfpt_id.AssignDropdownType<DddwPointTypes>("RfptId", "RfptDescription");
		}

		public int Retrieve( int? inContract, int? inSFKey, string inDelDays )
		{
			return RetrieveCore<FreqDescription>(new List<FreqDescription>
				(FreqDescription.GetAllFreqDescription( inContract, inSFKey, inDelDays )));
		}

        public event EventHandler CellClick;
	}
}

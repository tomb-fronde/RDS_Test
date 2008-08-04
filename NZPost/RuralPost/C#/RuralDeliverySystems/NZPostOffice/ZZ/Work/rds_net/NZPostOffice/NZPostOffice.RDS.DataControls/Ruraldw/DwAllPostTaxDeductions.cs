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
	public partial class DwAllPostTaxDeductions : Metex.Windows.DataUserControl
	{
		public DwAllPostTaxDeductions()
		{
			InitializeComponent();

            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }

		public int Retrieve( int? as_contractor_supplier_no )
		{
			return RetrieveCore<AllPostTaxDeductions>(new List<AllPostTaxDeductions>
				(AllPostTaxDeductions.GetAllAllPostTaxDeductions(as_contractor_supplier_no)),new Comparison<AllPostTaxDeductions>(ded_id_desc),null);
		}
        private int ded_id_desc<T>(T x, T y)
        {
            AllPostTaxDeductions X = x as AllPostTaxDeductions;
            AllPostTaxDeductions Y = y as AllPostTaxDeductions;
            if (X.DedId > Y.DedId)
            {
                return -1;
            }
            else if (X.DedId < Y.DedId)
            {
                return 1;
            }
            else
                return 0;
        }

        public event EventHandler CellDoubleClick;
	}
}

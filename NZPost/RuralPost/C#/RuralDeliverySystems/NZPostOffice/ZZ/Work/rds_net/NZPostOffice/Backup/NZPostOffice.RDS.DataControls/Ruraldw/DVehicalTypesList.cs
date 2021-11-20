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
	public partial class DVehicalTypesList : Metex.Windows.DataUserControl
	{
		public DVehicalTypesList()
		{
			InitializeComponent();

            this.grid.BorderStyle = BorderStyle.Fixed3D;
		}

		public override int Retrieve( )
        {
			return RetrieveCore<VehicalTypesList>(new List<VehicalTypesList>(VehicalTypesList.GetAllVehicalTypesList()),new Comparison<VehicalTypesList>(vt_description_asc),null);
		}
        private int vt_description_asc<T>(T x, T y)
        {
            VehicalTypesList X = x as VehicalTypesList;
            VehicalTypesList Y = y as VehicalTypesList;
            return String.Compare(X.VtDescription, Y.VtDescription, StringComparison.Ordinal);
        }
	}
}

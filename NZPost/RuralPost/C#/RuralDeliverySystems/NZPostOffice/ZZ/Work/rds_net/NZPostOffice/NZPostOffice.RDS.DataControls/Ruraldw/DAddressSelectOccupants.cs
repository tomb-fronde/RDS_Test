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
	public partial class DAddressSelectOccupants : Metex.Windows.DataUserControl
	{
		public DAddressSelectOccupants()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_cust_id )
		{
			return RetrieveCore<AddressSelectOccupants>(new List<AddressSelectOccupants>
				(AddressSelectOccupants.GetAllAddressSelectOccupants( al_cust_id )));
		}
	}
}

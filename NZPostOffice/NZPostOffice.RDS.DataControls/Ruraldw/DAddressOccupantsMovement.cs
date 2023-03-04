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
	public partial class DAddressOccupantsMovement : Metex.Windows.DataUserControl
	{
		public DAddressOccupantsMovement()
		{
			InitializeComponent();
		}

		public int Retrieve( int? al_adr_id )
		{
			return RetrieveCore<AddressOccupantsMovement>(new List<AddressOccupantsMovement>
				(AddressOccupantsMovement.GetAllAddressOccupantsMovement( al_adr_id )));
		}
	}
}

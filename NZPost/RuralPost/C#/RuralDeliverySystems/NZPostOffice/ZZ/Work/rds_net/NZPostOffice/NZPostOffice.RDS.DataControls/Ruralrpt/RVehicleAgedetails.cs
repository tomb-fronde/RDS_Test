using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RVehicleAgedetails : Metex.Windows.DataUserControl
	{
		public RVehicleAgedetails()
		{
			InitializeComponent();
		}

        public int Retrieve(int? inContract, int? inSequence, int? inVehicleNo)
		{
			return RetrieveCore<VehicleAgedetails>(new List<VehicleAgedetails>
				(VehicleAgedetails.GetAllVehicleAgedetails( inContract, inSequence, inVehicleNo )));
		}
	}
}

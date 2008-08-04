using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwOdpsPiecerateVolumes : Metex.Windows.DataUserControl
	{
		public DwOdpsPiecerateVolumes()
		{
			InitializeComponent();
		}

        public int Retrieve(int? in_Contract, int? in_Sequence, int? in_Contractor)
        {
			return RetrieveCore<OdpsPiecerateVolumes>(OdpsPiecerateVolumes.GetAllOdpsPiecerateVolumes(in_Contract, in_Sequence, in_Contractor));
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DFuelType : Metex.Windows.DataUserControl
	{
		public DFuelType()
		{
			InitializeComponent();
            this.SortString = "ft_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<FuelType>(new List<FuelType>
				(FuelType.GetAllFuelType(  )));
            if(this.SortString != "")
                this.Sort<FuelType>();
            return ret;
		}
	}
}

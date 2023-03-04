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
	public partial class DVehicalClass : Metex.Windows.DataUserControl
	{
		public DVehicalClass()
		{
			InitializeComponent();
            this.SortString = "vs_description A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<VehicalClass>(new List<VehicalClass>
                (VehicalClass.GetAllVehicalClass()));
            if(this.SortString != "" && this.SortString != null)
                this.Sort<VehicalClass>();
            return ret;
		}
	}
}

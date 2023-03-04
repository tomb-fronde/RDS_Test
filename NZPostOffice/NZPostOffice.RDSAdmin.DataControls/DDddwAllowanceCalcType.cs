using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    // TJB  Allowances  Apr-2021: New
    // Allowance calc type dropdown for allowance_type

	public partial class DDddwAllowanceCalcType : Metex.Windows.DataUserControl
	{
		public DDddwAllowanceCalcType()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			return RetrieveCore<DddwAllowanceCalcType>( new List<DddwAllowanceCalcType>(DddwAllowanceCalcType.GetAllDddwAllowanceCalcType()));
		}
	}
}

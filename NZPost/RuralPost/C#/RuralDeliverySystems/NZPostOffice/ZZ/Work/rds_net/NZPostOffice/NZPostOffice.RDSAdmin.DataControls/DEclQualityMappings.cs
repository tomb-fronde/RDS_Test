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
	public partial class DEclQualityMappings : Metex.Windows.DataUserControl
	{
		public DEclQualityMappings()
		{
			InitializeComponent();
			this.SortString = "ecl_column_name A, ecl_match_string A";
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<EclQualityMappings>(new List<EclQualityMappings>
			(EclQualityMappings.GetAllEclQualityMappings()));
			if(this.SortString != "")
				this.Sort<EclQualityMappings>();
			return ret;
		}

	}
}

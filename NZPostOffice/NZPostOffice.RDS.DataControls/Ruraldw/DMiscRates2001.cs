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
	public partial class DMiscRates2001 : Metex.Windows.DataUserControl
	{
		public DMiscRates2001()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_RgCode, DateTime? in_EffectDate )
		{
			return RetrieveCore<MiscRates2001>(new List<MiscRates2001>
				(MiscRates2001.GetAllMiscRates2001( in_RgCode, in_EffectDate )));
		}
	}
}

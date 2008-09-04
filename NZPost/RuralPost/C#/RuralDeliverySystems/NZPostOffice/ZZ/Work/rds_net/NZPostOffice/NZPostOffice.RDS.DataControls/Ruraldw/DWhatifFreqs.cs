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
	public partial class DWhatifFreqs : Metex.Windows.DataUserControl
	{
		public DWhatifFreqs()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }
            
            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
			sf_key.AssignDropdownType<DddwStandardFrequency>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<WhatifFreqs>(new List<WhatifFreqs>
				(WhatifFreqs.GetAllWhatifFreqs()));
		}
	}
}

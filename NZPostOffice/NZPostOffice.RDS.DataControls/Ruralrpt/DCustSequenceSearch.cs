using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class DCustSequenceSearch : Metex.Windows.DataUserControl
	{
		public DCustSequenceSearch()
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
			sf_key.AssignDropdownType<DDddwStandardFrequency>();
		}

		public override int Retrieve( )
        {
            return RetrieveCore<CustSequenceSearch>(new List<CustSequenceSearch>(CustSequenceSearch.GetAllCustSequenceSearch()));
		}
	}
}

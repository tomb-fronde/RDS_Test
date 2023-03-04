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
	public partial class DQsOutletDetails : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_047  Jan-2013:  New
        // Displays outlet address details on the contract outlet search screen (WQsOutlet)

		public DQsOutletDetails()
		{
			InitializeComponent();
		}
        
        public int Retrieve( int? in_outlet_id )
        {
            return RetrieveCore<QsOutletDetails>(new List<QsOutletDetails>
                (QsOutletDetails.GetAllQsOutletDetails( in_outlet_id )));
        }
    }
}

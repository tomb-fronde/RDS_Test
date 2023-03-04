using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Mar-2014
    // Removed unused buttons (function moved to WContractor Driver H&S tab)
    //
    // TJB  RPCR_060  Jan-2014:  NEW
    // Displays summary H&S information about a contractor's drivers
    // Displayed as a (new) tab in the WContractor2001 window
    // Contains Add and Remove buttons to add and remove drivers
    
	public partial class DContractorDriverHSInfo : Metex.Windows.DataUserControl
	{
		public DContractorDriverHSInfo()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_contractor )
		{
            return RetrieveCore<ContractorDriverHSInfo>(new List<ContractorDriverHSInfo>
				(ContractorDriverHSInfo.GetAllContractorDriverHSInfo( in_contractor )));
		}
	}
}

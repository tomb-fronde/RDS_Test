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
    //TJB Frequencies Nov 2020 NEW
    //Provides data for vehicle dropdown in DRouteFrequency2Rows

	public partial class DDddwContractorVehicles : Metex.Windows.DataUserControl
	{
        public DDddwContractorVehicles()
		{
			InitializeComponent();
		}

		public override int Retrieve()
        {
            int? dummy_contract_no;
            dummy_contract_no = 5308;
                        int rc = 0;
            string msg;
            try
            {
                rc = RetrieveCore<ContractorVehicles>(ContractorVehicles.GetAllContractorVehicles(dummy_contract_no));
            }
            catch (Exception e)
            {
                msg = e.Message;
                MessageBox.Show("Retrieve error: " + msg, "DDddwContractorVehicles");
            }
            int nRows = this.RowCount;
            int n = nRows;
            return rc;
        }
	}
}

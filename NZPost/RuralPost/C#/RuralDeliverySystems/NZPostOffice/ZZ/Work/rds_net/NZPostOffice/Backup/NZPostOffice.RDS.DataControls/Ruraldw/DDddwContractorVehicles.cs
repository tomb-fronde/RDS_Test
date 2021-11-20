using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Shared;
using NZPostOffice.Shared.Managers;


namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB Frequencies & Vehicles  Dec-2020
    // Changed the name of the associated entity from ContractorVehicles do DddwContractorVehicles
    //
    // TJB Frequencies Nov 2020 NEW
    // Provides data for vehicle dropdown in DRouteFrequency2Rows

	public partial class DDddwContractorVehicles : Metex.Windows.DataUserControl
	{
        int? contract_no;

        public DDddwContractorVehicles()
		{
			InitializeComponent();
		}

        public virtual void get_contract_no()
        {
            // TJB Frequencies Nov-2020
            // Get the saved contract number for use when retrieving 
            // the vehicle list.

            contract_no = StaticMessage.ContractNoParm;
        }

		public override int Retrieve()
        {
            //int? dummy_contract_no;
            int rc = 0;
            get_contract_no();
            try
            {
                rc = RetrieveCore<DddwContractorVehicles>(DddwContractorVehicles.GetAllDddwContractorVehicles(contract_no));
            }
            catch (Exception e)
            {
                string msg = e.Message;
                MessageBox.Show("Retrieve error: " + msg
                               ,"DDddwContractorVehicles");
            }
            return rc;
        }
	}
}

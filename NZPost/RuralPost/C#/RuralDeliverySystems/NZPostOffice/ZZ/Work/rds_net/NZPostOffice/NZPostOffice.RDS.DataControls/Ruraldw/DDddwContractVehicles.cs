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
    //TJB Frequencies & Values  Dec 2020 NEW
    // Gets all vehicles (active or not) linked to the current contract contract 
    // where previously DDddwContractorVehicles got all vehicles linked to contracts 
    // owned by the contractor who owns this contract.
    //Provides data for vehicle dropdown in DRouteFrequency2Rows
    // Changed from DDddwContractorVehicles

	public partial class DDddwContractVehicles : Metex.Windows.DataUserControl
	{
        int? contract_no;

        public DDddwContractVehicles()
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
                rc = RetrieveCore<DddwContractVehicles>(DddwContractVehicles.GetAllDddwContractVehicles(contract_no));
            }
            catch (Exception e)
            {
                string msg = e.Message;
                MessageBox.Show("Retrieve error: " + msg
                               ,"DDddwContractVehicles");
            }
            return rc;
        }
	}
}

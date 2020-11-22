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
    //TJB Frequencies Nov 2020 NEW
    //Provides data for vehicle dropdown in DRouteFrequency2Rows

	public partial class DDddwContractorVehicles : Metex.Windows.DataUserControl
	{
        int? contract_no;

        public DDddwContractorVehicles()
		{
			InitializeComponent();
            get_contract_no();
		}

        public virtual void get_contract_no()
        {
            // TJB Frequencies Nov-2020
            // Get and save the contract number for use when retrieving 
            // the vehicle list.

            NParameters lnv_Parameters;
            lnv_Parameters = (NParameters)StaticMessage.PowerObjectParm;
            contract_no = lnv_Parameters.longparm;
            //il_sf_key = lnv_Parameters.integerparm;
            //is_delivery_days = lnv_Parameters.stringparm;
        }

		public override int Retrieve()
        {
            //int? dummy_contract_no;
            //dummy_contract_no = 5308;
            int rc = 0;
            string msg;
            try
            {
                rc = RetrieveCore<ContractorVehicles>(ContractorVehicles.GetAllContractorVehicles(contract_no));
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

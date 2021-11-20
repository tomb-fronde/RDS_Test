using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    // TJB  Frequencies & Vehicles  Feb-2021
    // Changes in designer
    // Some experiments trying to detect changes in the active flag that failed
    // and manipulation of the scrollbar that also failed.
    // Code to be removed during code tidyup.
     
    public partial class DContractVehicle : Metex.Windows.DataUserControl
    {
        public DContractVehicle()
        {
            InitializeComponent();
        }

        public int Retrieve(int? contract_no, int? contract_seq_number)
        {
            retrieve_end = false;
            return RetrieveCore<ContractVehicle>(new List<ContractVehicle>
                (ContractVehicle.GetAllContractVehicle(contract_no, contract_seq_number)));
        }
    }
}

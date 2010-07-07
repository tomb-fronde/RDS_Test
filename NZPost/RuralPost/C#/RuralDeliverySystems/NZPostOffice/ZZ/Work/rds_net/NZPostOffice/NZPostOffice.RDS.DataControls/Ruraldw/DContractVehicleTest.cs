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
    public partial class DContractVehicleTest : Metex.Windows.DataUserControl
    {
        public DContractVehicleTest()
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

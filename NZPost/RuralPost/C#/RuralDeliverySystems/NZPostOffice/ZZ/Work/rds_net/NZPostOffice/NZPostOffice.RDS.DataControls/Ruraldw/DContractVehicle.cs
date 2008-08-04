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
    public partial class DContractVehicleTest : Metex.Windows.DataUserControl
    {
        public DContractVehicleTest()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            ft_key.AssignDropdownType<DDddwFuewTypes>();
            vt_key.AssignDropdownType<DDddwVehicalTypes>();
            vs_key.AssignDropdownType<DDddwVehicalStyles>();

            #region vehicle_v_vehicle_month
            System.Data.DataTable sourceTable1 = new System.Data.DataTable();
            sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(string))
			});
            sourceTable1.Rows.Add(new object[] { "January", "1" });
            sourceTable1.Rows.Add(new object[] { "February", "2" });
            sourceTable1.Rows.Add(new object[] { "March", "3" });
            sourceTable1.Rows.Add(new object[] { "April", "4" });
            sourceTable1.Rows.Add(new object[] { "May", "5" });
            sourceTable1.Rows.Add(new object[] { "June", "6" });
            sourceTable1.Rows.Add(new object[] { "July", "7" });
            sourceTable1.Rows.Add(new object[] { "August", "8" });
            sourceTable1.Rows.Add(new object[] { "September", "9" });
            sourceTable1.Rows.Add(new object[] { "October", "10" });
            sourceTable1.Rows.Add(new object[] { "November", "11" });
            sourceTable1.Rows.Add(new object[] { "December", "12" });
            this.v_vehicle_month.DataSource = sourceTable1;
            this.v_vehicle_month.DisplayMember = "Display";
            this.v_vehicle_month.ValueMember = "Value";
            #endregion
        }

        public int Retrieve(int? contract_no, int? contract_seq_number)
        {
            return RetrieveCore<ContractVehicle>(new List<ContractVehicle>
                (ContractVehicle.GetAllContractVehicle(contract_no, contract_seq_number)));
        }
    }
}

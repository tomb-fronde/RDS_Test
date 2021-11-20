using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//?////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DContractVehicalForm : Metex.Windows.DataUserControl
	{
		public DContractVehicalForm()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			vehicle_vt_key.AssignDropdownType<DDddwVehicalTypes>();
			vehicle_ft_key.AssignDropdownType<DDddwFuewTypes>();
			#region vehicle_v_vehicle_month
			System.Data.DataTable sourceTable1 = new System.Data.DataTable();
			sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(string))
			});
			sourceTable1.Rows.Add(new object[] { "January", "1"});
			sourceTable1.Rows.Add(new object[] { "February", "2"});
			sourceTable1.Rows.Add(new object[] { "March", "3"});
			sourceTable1.Rows.Add(new object[] { "April", "4"});
			sourceTable1.Rows.Add(new object[] { "May", "5"});
			sourceTable1.Rows.Add(new object[] { "June", "6"});
			sourceTable1.Rows.Add(new object[] { "July", "7"});
			sourceTable1.Rows.Add(new object[] { "August", "8"});
			sourceTable1.Rows.Add(new object[] { "September", "9"});
			sourceTable1.Rows.Add(new object[] { "October", "10"});
			sourceTable1.Rows.Add(new object[] { "November", "11"});
			sourceTable1.Rows.Add(new object[] { "December", "12"});
			this.vehicle_v_vehicle_month.DataSource = sourceTable1;
			this.vehicle_v_vehicle_month.DisplayMember = "Display";
			this.vehicle_v_vehicle_month.ValueMember = "Value";
			#endregion

		}

		public int Retrieve( int? contract_no, int? contract_seq_number )
        {
			return RetrieveCore<ContractVehicalForm>(ContractVehicalForm.GetAllContractVehicalForm(contract_no, contract_seq_number));
		}
	}
}

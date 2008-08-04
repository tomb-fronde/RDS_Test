using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DRouteAudit : Metex.Windows.DataUserControl
	{
		public DRouteAudit()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			#region ra_day_of_check
			System.Data.DataTable sourceTable1 = new System.Data.DataTable();
			sourceTable1.Columns.AddRange(new System.Data.DataColumn[]
			{
				new System.Data.DataColumn("Display", typeof(string)),
				new System.Data.DataColumn("Value", typeof(string))
			});
			sourceTable1.Rows.Add(new object[] { "Monday", "1"});
			sourceTable1.Rows.Add(new object[] { "Tuesday", "2"});
			sourceTable1.Rows.Add(new object[] { "Wednesday", "3"});
			sourceTable1.Rows.Add(new object[] { "Thursday", "4"});
			sourceTable1.Rows.Add(new object[] { "Friday", "5"});
			sourceTable1.Rows.Add(new object[] { "Saturday", "6"});
			sourceTable1.Rows.Add(new object[] { "Sunday", "7"});
			this.ra_day_of_check.DataSource = sourceTable1;
			this.ra_day_of_check.DisplayMember = "Display";
			this.ra_day_of_check.ValueMember = "Value";
			#endregion

		}

		public override int Retrieve( )
        {
			return RetrieveCore<RouteAudit>(RouteAudit.GetAllRouteAudit());
		}
	}
}

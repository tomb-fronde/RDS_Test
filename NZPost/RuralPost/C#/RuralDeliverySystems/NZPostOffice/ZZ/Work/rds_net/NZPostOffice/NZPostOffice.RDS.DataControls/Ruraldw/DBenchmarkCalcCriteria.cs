using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.DataControls;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DBenchmarkCalcCriteria : Metex.Windows.DataUserControl
	{
		public DBenchmarkCalcCriteria()
		{
			InitializeComponent();
			//!InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
			region_id.AssignDropdownType<DDddwRegions>();
			rg_code.AssignDropdownType<DDddwRenewalgroup>();
		}

		public override int Retrieve( )
		{
			return RetrieveCore<BenchmarkCalcCriteria>(new List<BenchmarkCalcCriteria>
				(BenchmarkCalcCriteria.GetAllBenchmarkCalcCriteria(  )));
		}
	}
}

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
	public partial class DRenewal : Metex.Windows.DataUserControl
	{
		public DRenewal()
		{
			InitializeComponent();
            // TJB  27-May-2010 RPI_001
            //    Added some of these and moved the rest from the DRenewal.designer.cs file.
            //    Also added the "$" for the benchmark and payment fields.
            this.con_date_last_assigned.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_start_pay_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_expiry_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_start_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_rates_effective_date.DataBindings[0].FormatString = "dd/MM/yyyy";
            this.con_renewal_benchmark_price.DataBindings[0].FormatString = "$###,###.00";
            this.con_renewal_payment_value.DataBindings[0].FormatString = "$###,###.00";
            this.con_distance_at_renewal.DataBindings[0].FormatString = "###,###.00";
            this.con_volume_at_renewal.DataBindings[0].FormatString = "###,###";
            //InitializeDropdown();
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
			con_rg_code_at_renewal.AssignDropdownType<DDddwRenewalgroup>();
		}

		public int Retrieve( int? in_ContractNo, int? in_ContractSeq )
		{
			return RetrieveCore<Renewal>(new List<Renewal>
				(Renewal.GetAllRenewal( in_ContractNo, in_ContractSeq )));
		}
	}
}

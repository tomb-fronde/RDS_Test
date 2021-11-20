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
	public partial class DRenewalDates2001a : Metex.Windows.DataUserControl
	{
		public DRenewalDates2001a()
		{
			InitializeComponent();
			//!InitializeDropdown();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {          
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender,e);
            }
        }

		private void InitializeDropdown()
		{
			rg_code.AssignDropdownType<DddwRenewalgroup>("RgCode","RgDescription");
		}

		public int Retrieve( int? inregion )
		{
            int li_return;
            li_return = RetrieveCore<RenewalDates2001a>(new List<RenewalDates2001a>
				(RenewalDates2001a.GetAllRenewalDates2001a(inregion )));
            this.SortString = "rr_rates_effective_date D";
            this.Sort<RenewalDates2001a>();
            return li_return;
		}

        public event EventHandler CellDoubleClick;
	}
}

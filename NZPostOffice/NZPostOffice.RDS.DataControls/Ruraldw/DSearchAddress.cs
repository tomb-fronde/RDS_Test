using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DSearchAddress : Metex.Windows.DataUserControl
	{
		public DSearchAddress()
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

        public ComboBox SuburbsCombo
        {
            get { return this.sl_name; }
        }

		private void InitializeDropdown()
		{
			//!sl_name.AssignDropdownType<DDddwSuburbNames>();
            List<NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames> source 
                = new List<NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames>
                             (NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames.GetAllDddwSuburbNames());

            NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames emptyRow = new NZPostOffice.RDS.Entity.Ruralwin.DddwSuburbNames();
            emptyRow.SlName = "";
            //! Add an empy entry as dropdown cannot show empty text otherwise
            source.Insert(0, emptyRow);
            sl_name.DataSource = source;            

            rs_id.AssignDropdownType<DDddwRoadSuffix>();
            tc_id.AssignDropdownType<DDddwTownOnly>();
            rt_id.AssignDropdownType<DDddwRoadType>();
		}

		public override int Retrieve( )
        {
			return RetrieveCore<SearchAddress>(SearchAddress.GetAllSearchAddress());
		}
	}
}

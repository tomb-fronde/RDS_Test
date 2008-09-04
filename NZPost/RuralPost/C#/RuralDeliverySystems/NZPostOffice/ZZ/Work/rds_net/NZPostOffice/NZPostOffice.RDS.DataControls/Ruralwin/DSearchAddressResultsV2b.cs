using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
	public partial class DSearchAddressResultsV2b : Metex.Windows.DataUserControl
	{
		public DSearchAddressResultsV2b()
		{
			InitializeComponent();
			//!InitializeDropdown();

            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
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

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender,e);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender,e);
            }
        }

		private void InitializeDropdown()
		{
            sl_id.AssignDropdownType<NZPostOffice.RDS.Entity.Ruraldw.DddwSuburb>();//!("SlId","SlName");
			tc_id.AssignDropdownType<NZPostOffice.RDS.Entity.Ruraldw.DddwTown>();
		}

        Metex.Core.EntityBindingList<SearchAddressResultsV2b> SourceList = null;
		public int Retrieve( string in_AdrNum, string in_roadName, int? in_roadType, int? in_roadSuffix, string in_Suburb, string in_Town, int? in_Contract, string in_RDNo, string in_Surname, string in_Initials, string in_UI_UserId, int? in_ComponentId, int? in_rd_contract, int? in_dpid )
		{
            int li_return;
			li_return = RetrieveCore<SearchAddressResultsV2b>(new List<SearchAddressResultsV2b>
				(SearchAddressResultsV2b.GetAllSearchAddressResultsV2b( in_AdrNum, in_roadName, in_roadType, in_roadSuffix, in_Suburb, in_Town, in_Contract, in_RDNo, in_Surname, in_Initials, in_UI_UserId, in_ComponentId, in_rd_contract, in_dpid )));
            if (li_return > 0)
            {
                this.SortString = "RoadName A, AdrNo A, AdrAlpha A, AdrUnit A";
                this.Sort<SearchAddressResultsV2b>();
            }
            SourceList = (Metex.Core.EntityBindingList<SearchAddressResultsV2b>)this.bindingSource.DataSource;

            return li_return;
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}

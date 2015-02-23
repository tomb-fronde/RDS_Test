using System;
using System.Collections;
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
    // TJB  RPCR_093  Feb-2015: New
    // Datawindow for WDailyArticalCounts

    //==============================> BEWARE!! <==================================
    // To make GUI changes, change designer code BY HAND!  Saving designer changes
    // made with the GUI rearranges code and stuffs it up!!!
    //============================================================================

    public partial class DDailyArticalCounts : Metex.Windows.DataUserControl
	{
		public DDailyArticalCounts()
		{
			InitializeComponent();
			//!InitializeDropdown();

            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
            //this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(grid_CellFormatting);            
		}
/*
        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
        }
*/
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
		}

        Metex.Core.EntityBindingList<DailyArticalCounts> SourceList = null;
        public int Retrieve(int? in_contract_no, DateTime? in_period_start_date, int? in_week_no)
		{
            int li_return;
			li_return = RetrieveCore<DailyArticalCounts>(new List<DailyArticalCounts>
				(DailyArticalCounts.GetAllDailyArticalCounts( in_contract_no, in_period_start_date, in_week_no )));
            if (li_return > 0)
            {
                //this.SortString = "RoadName A, AdrNo A, AdrAlpha A, AdrUnit A";
                //this.Sort<DailyArticalCounts>();
            }
            SourceList = (Metex.Core.EntityBindingList<DailyArticalCounts>)this.bindingSource.DataSource;

            return li_return;
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;

	}
}

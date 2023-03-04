using System;
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
	public partial class DCmbAddressList : Metex.Windows.DataUserControl
	{
		public DCmbAddressList()
		{
			InitializeComponent();

            this.grid.CellClick += new DataGridViewCellEventHandler(grid_CellClick);
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender, e);
            }
        }
        private List<DataGridViewRow> selectedRowList = new List<DataGridViewRow>();

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClick != null)
            {
                CellClick(sender, e);
            }
        }

		public int Retrieve( int? in_contract_no )
		{
           //summary 
            List<CmbAddressList> rstList = new  List<CmbAddressList>(CmbAddressList.GetAllCmbAddressList( in_contract_no ));
            this.cmbs_found.Text = (rstList.Count > 1 ? rstList.Count + " CMBs Found" : (rstList.Count == 1 ? "1 CMB Found" : "No CMBs Found"));
			
            return RetrieveCore<CmbAddressList>(new List<CmbAddressList>
				(CmbAddressList.GetAllCmbAddressList( in_contract_no )));
		}

        public event EventHandler CellClick;
        public event EventHandler CellDoubleClick;
	}
}

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
    public partial class DAddressList : Metex.Windows.DataUserControl
	{
		public DAddressList()
		{
			InitializeComponent();
            this.grid.CellDoubleClick += new DataGridViewCellEventHandler(grid_CellDoubleClick);
		}

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClick != null)
            {
                CellDoubleClick(sender,e);
            }
        }

		public int Retrieve( int? al_contract_no )
		{
            string rst="";
            List<AddressList> addRst = new List<AddressList>(AddressList.GetAllAddressList(al_contract_no));
           if ( addRst.Count >1)
               rst=addRst.Count.ToString()+" Addresses Found"   ;
           else if( addRst.Count ==1)
               rst= "1 Address Found";
           else
               rst="No Addresses Found";

           this.address_count.Text = rst;
			return RetrieveCore<AddressList>(new List<AddressList>
				(AddressList.GetAllAddressList( al_contract_no )));
		}

        public event EventHandler CellDoubleClick;
	}
}

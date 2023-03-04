using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	public partial class DwUserRegion : Metex.Windows.DataUserControl
	{
		public DwUserRegion()
		{
			InitializeComponent();
		}

		public int Retrieve( int user_id )
		{
			return RetrieveCore<UserRegion>(new List<UserRegion>
				(UserRegion.GetAllUserRegion( user_id )));
		}        

        //public event EventHandler CellClick;

        //private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 1)
        //    {
        //        if (CellClick != null)
        //        {
        //            this.CellClick(sender, e);
        //        }
        //    }
        //}
	}
}

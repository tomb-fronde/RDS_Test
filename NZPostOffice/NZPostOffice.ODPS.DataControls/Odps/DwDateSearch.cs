using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwDateSearch : Metex.Windows.DataUserControl
	{
		public DwDateSearch()
		{
			InitializeComponent();
		}

		public override int Retrieve()
        {
            List<NZPostOffice.ODPS.Entity.Odps.DateSearch> list = new List<NZPostOffice.ODPS.Entity.Odps.DateSearch>();

            NZPostOffice.ODPS.Entity.Odps.DateSearch item = new NZPostOffice.ODPS.Entity.Odps.DateSearch();
            list.Add(item);
            return RetrieveCore<NZPostOffice.ODPS.Entity.Odps.DateSearch>(list);

            //return RetrieveCore<NZPostOffice.ODPS.Entity.Odps.DwDateSearch>(new List<NZPostOffice.ODPS.Entity.Odps.DwDateSearch>
                //(NZPostOffice.ODPS.Entity.Odps.DwDateSearch.GetAllDateSearch()));
        }
	}                                             
}

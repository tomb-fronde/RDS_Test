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
	public partial class DSuburblocality : Metex.Windows.DataUserControl
	{
		public DSuburblocality()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			int ret= RetrieveCore<Suburblocality>(new List<Suburblocality>
                (Suburblocality.GetAllSuburblocality()));
            //Sort();
            return ret;
		}

        public void Sort()
        {
            SortOnce<Suburblocality>(new Comparison<Suburblocality>(this.defaultSorter));
        }

        private int defaultSorter(Suburblocality s1, Suburblocality s2)
        {
            return string.Compare(s1.SlName, s2.SlName);
        }
	}
}

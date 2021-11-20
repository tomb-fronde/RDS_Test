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
	public partial class DwComponentList : Metex.Windows.DataUserControl
	{
		public DwComponentList()
		{
			InitializeComponent();
		}
        public override int Retrieve()
        {
            int ret = RetrieveCore<ComponentList>(new List<ComponentList>
                (ComponentList.GetAllComponentList()));
            Sort();
            return ret;
        }

        public void Sort()
        {
            SortOnce<ComponentList>(new Comparison<ComponentList>(this.defaultSorter));
        }

        private int defaultSorter(ComponentList s1, ComponentList s2)
        {
            return string.Compare(s1.RcDescription, s2.RcDescription);
        }
	}
}

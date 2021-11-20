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
    public partial class DContractorList : Metex.Windows.DataUserControl
	{

		public DContractorList()
		{
			InitializeComponent();
            this.grid.DoubleClick += new EventHandler(grid_DoubleClick);
		}

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            if (this.DoubleClick != null)
            {
                this.DoubleClick(sender, e);
            }
        }

        public int Retrieve(int? in_ContractorSupplierNo, int? in_ContractNo, int? in_ct_key, int? in_region_id, string in_c_surname_company, string in_c_first_names, string in_c_phone_day)
		{
			return RetrieveCore<ContractorList>(new List<ContractorList>
				(ContractorList.GetAllContractorList( in_ContractorSupplierNo, in_ContractNo, in_ct_key, in_region_id, in_c_surname_company, in_c_first_names, in_c_phone_day )));
		}

        public event EventHandler DoubleClick;
	}
}

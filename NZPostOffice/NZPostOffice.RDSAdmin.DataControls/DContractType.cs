using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    public partial class DContractType : Metex.Windows.DataUserControl
	{
		public DContractType()
		{
			InitializeComponent();
            this.SortString = "contract_type A";
		}

		public override int Retrieve(  )
		{
            int ret = RetrieveCore<ContractTypeBE>(new List<ContractTypeBE>
                (ContractTypeBE.GetAllContractType()));
            if (this.SortString != "")
                this.Sort<ContractTypeBE>();
            return ret;
		}
	}
}

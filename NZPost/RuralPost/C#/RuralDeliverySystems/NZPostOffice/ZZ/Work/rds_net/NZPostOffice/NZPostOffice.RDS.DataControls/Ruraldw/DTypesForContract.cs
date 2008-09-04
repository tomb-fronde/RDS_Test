using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.Entity;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DTypesForContract : Metex.Windows.DataUserControl
	{
		public DTypesForContract()
		{
			InitializeComponent();
			//InitializeDropdown();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            if (!DesignMode)
            {
                InitializeDropdown();
            }

            base.OnHandleCreated(e);
        }

		private void InitializeDropdown()
		{
			ct_key.AssignDropdownType<DddwContractTypes>("CtKey","ContractType");
		}

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<TypesForContract>(new List<TypesForContract>
				(TypesForContract.GetAllTypesForContract(in_Contract)));
		}
	}
}

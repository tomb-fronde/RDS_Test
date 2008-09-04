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
	public partial class DTypesForContractor : Metex.Windows.DataUserControl
	{
		public DTypesForContractor()
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
            ct_key_1.AssignDropdownType<DddwContractTypes>("CtKey", "ContractType");
            //ct_key_2.AssignDropdownType<DddwContractTypes>();
            //ct_key_3.AssignDropdownType<DddwContractTypes>();
		}

		public int Retrieve( int? in_Contractor )
		{
			return RetrieveCore<TypesForContractor>(new List<TypesForContractor>
				(TypesForContractor.GetAllTypesForContractor(in_Contractor )));
		}
	}
}

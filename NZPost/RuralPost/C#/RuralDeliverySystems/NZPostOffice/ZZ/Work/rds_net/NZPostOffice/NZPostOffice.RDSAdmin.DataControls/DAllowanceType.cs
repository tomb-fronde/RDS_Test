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
    // TJB  Allowances  21-Apr-2021
    // Added AllowanceCalcType dropdown

	public partial class DAllowanceType : Metex.Windows.DataUserControl
	{
		public DAllowanceType()
		{
			InitializeComponent();
            InitializeDropdown();
            this.SortString = "alt_description A";
		}

        private void InitializeDropdown()
        {
            alct_id.AssignDropdownType<DddwAllowanceCalcType>("AlctId", "AlctDescription");
        }

        public override int Retrieve()
		{
			int ret = RetrieveCore<AllowanceType>(new List<AllowanceType>(AllowanceType.GetAllAllowanceType()));
            if(this.SortString != "")
                this.Sort<AllowanceType>();
            return ret;
		}
	}
}

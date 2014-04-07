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
    // TJB  RPCR_060  Mar-2014: NEW
    //
    // TJB  RPCR_060  Apr-2014
    // Added  hst_additional_date_errmsg and hst_notes_errmsg columns
    // and removed hst_description.

	public partial class DHsType : Metex.Windows.DataUserControl

	{
		public DHsType()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
			int ret = RetrieveCore<HSType>(new List<HSType>
                (HSType.GetAllHSType()));
            if(this.SortString != "")
                this.Sort<HSType>();
            return ret;
		}
	}
}

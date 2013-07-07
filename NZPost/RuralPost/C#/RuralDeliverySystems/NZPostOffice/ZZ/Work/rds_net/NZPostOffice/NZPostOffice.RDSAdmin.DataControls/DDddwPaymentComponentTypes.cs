using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDSAdmin.Entity.Security;
//!using NZPostOffice.RDSAdmin.DataControls.EpDropdowns;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
    // TJB  RPCR_054  July-2013: NEW
    // Added to piece rate supplier for addition of new suppliers

	public partial class DDddwPaymentComponentTypes : Metex.Windows.DataUserControl
	{
        public DDddwPaymentComponentTypes()
		{
			InitializeComponent();
		}

		public override int Retrieve(  )
		{
            return RetrieveCore<PaymentComponentTypes>(new List<PaymentComponentTypes>(PaymentComponentTypes.GetAllDddwPaymentComponentTypes()));
		}
	}
}

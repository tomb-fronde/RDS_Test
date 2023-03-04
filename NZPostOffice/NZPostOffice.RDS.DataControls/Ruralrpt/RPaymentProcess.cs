using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
//using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RPaymentProcess : Metex.Windows.DataUserControl
	{
		public RPaymentProcess()
		{
			InitializeComponent();
		}

        private DateTime adt_in_pay_period = DateTime.MinValue;

		public int Retrieve(DateTime? inPayPeriod)
        {
            adt_in_pay_period = inPayPeriod.GetValueOrDefault();
            int ret = RetrieveCore<PaymentProcess>(new List<PaymentProcess>(PaymentProcess.GetAllPaymentProcess(inPayPeriod)));
            this.viewer.RefreshReport();
            return ret;
		}
	}
}

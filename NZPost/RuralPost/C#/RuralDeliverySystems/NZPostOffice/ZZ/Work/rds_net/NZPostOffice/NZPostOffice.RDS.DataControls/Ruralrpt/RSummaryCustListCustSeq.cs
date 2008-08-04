using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RSummaryCustListCustSeq : Metex.Windows.DataUserControl
	{
		public RSummaryCustListCustSeq()
		{
			InitializeComponent();
		}

        public int Retrieve(int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder)
		{
			return RetrieveCore<SummaryCustListCustSeq>(new List<SummaryCustListCustSeq>
				(SummaryCustListCustSeq.GetAllSummaryCustListCustSeq( in_contract_no, in_sf_key, in_rd_del_days, in_sortorder )));
		}
	}
}

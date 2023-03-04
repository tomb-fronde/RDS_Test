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
	public partial class RSummaryCustListUnseq : Metex.Windows.DataUserControl
	{
		public RSummaryCustListUnseq()
		{
			InitializeComponent();
		}

		public int Retrieve( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
        {
            return RetrieveCore<SummaryCustListUnseq>(new List<SummaryCustListUnseq>(SummaryCustListUnseq.GetAllSummaryCustListUnseq(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder)));
		}
	}
}

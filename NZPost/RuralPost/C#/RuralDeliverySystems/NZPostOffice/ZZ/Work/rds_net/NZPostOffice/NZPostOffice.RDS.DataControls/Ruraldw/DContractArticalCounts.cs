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
    public partial class DContractArticalCountsTest : Metex.Windows.DataUserControl
	{
        public DContractArticalCountsTest()
        {
            InitializeComponent();

            this.compute_1.BorderStyle = BorderStyle.None;
            this.ac_start_week_period.BorderStyle = BorderStyle.None;
            this.ac_w1_inward_mail.BorderStyle = BorderStyle.None;
            this.ac_w1_medium_letters.BorderStyle = BorderStyle.None;
            this.ac_w1_other_envelopes.BorderStyle = BorderStyle.None;
            this.week1del.BorderStyle = BorderStyle.None;
            this.ac_w2_inward_mail.BorderStyle = BorderStyle.None;
            l_1.BorderStyle = BorderStyle.None;
            this.ac_w2_medium_letters.BorderStyle = BorderStyle.None;
            this.ac_w2_other_envelopes.BorderStyle = BorderStyle.None;
            this.week2del.BorderStyle = BorderStyle.None;
            l_2.BorderStyle = BorderStyle.None;
            l_3.BorderStyle = BorderStyle.None;
            this.compute_5.BorderStyle = BorderStyle.None;
            this.compute_6.BorderStyle = BorderStyle.None;
            this.compute_7.BorderStyle = BorderStyle.None;
            this.compute_2.BorderStyle = BorderStyle.None;
            this.ac_w1_small_parcels.BorderStyle = BorderStyle.None;
            this.ac_w2_small_parcels.BorderStyle = BorderStyle.None;
            this.compute_3.BorderStyle = BorderStyle.None;
            this.ac_w1_large_parcels.BorderStyle = BorderStyle.None;
            this.ac_w2_large_parcels.BorderStyle = BorderStyle.None;
            this.compute_4.BorderStyle = BorderStyle.None;


        }

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<ContractArticalCounts>(new List<ContractArticalCounts>
				(ContractArticalCounts.GetAllContractArticalCounts(in_Contract )));
		}
	}
}

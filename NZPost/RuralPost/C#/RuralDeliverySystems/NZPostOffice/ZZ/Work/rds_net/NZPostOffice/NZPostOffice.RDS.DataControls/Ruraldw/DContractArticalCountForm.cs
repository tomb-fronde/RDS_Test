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
    public partial class DContractArticalCountForm : Metex.Windows.DataUserControl
	{
		public DContractArticalCountForm()
		{
			InitializeComponent();
		}

        public void InitializeControl()
        {
            if (this.RowCount <= 0)
                return;

            //if(isnull(contract_seq_number),0,1)
            //!if (this.GetItem<ContractArticalCountForm>(0).ContractSeqNumber == 0)//null)
            if (!this.GetItem<ContractArticalCountForm>(0).ContractSeqNumber.HasValue)
            {
                ac_w1_medium_letters.ReadOnly = false;
                ac_w2_medium_letters.ReadOnly = false;
                ac_w1_other_envelopes.ReadOnly = false;
                ac_w2_other_envelopes.ReadOnly = false;
                ac_w1_small_parcels.ReadOnly = false;
                ac_w2_small_parcels.ReadOnly = false;
                ac_w1_large_parcels.ReadOnly = false;
                ac_w2_large_parcels.ReadOnly = false;
                ac_w1_inward_mail.ReadOnly = false;
                ac_w2_inward_mail.ReadOnly = false;

                ac_w1_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w2_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w1_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w2_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w1_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w2_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w1_large_parcels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w2_large_parcels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w1_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                ac_w2_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }
            else
            {
                ac_w1_medium_letters.ReadOnly = true;
                ac_w2_medium_letters.ReadOnly = true;
                ac_w1_other_envelopes.ReadOnly = true;
                ac_w2_other_envelopes.ReadOnly = true;
                ac_w1_small_parcels.ReadOnly = true;
                ac_w2_small_parcels.ReadOnly = true;
                ac_w1_large_parcels.ReadOnly = true;
                ac_w2_large_parcels.ReadOnly = true;
                ac_w1_inward_mail.ReadOnly = true;
                ac_w2_inward_mail.ReadOnly = true;

                ac_w1_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w2_medium_letters.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w1_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w2_other_envelopes.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w1_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w2_small_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w1_large_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w2_large_parcels.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w1_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
                ac_w2_inward_mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }

		public int Retrieve( int? in_Contract )
		{
			return RetrieveCore<ContractArticalCountForm>(new List<ContractArticalCountForm>
				(ContractArticalCountForm.GetAllContractArticalCountForm( in_Contract )));
		}
	}
}

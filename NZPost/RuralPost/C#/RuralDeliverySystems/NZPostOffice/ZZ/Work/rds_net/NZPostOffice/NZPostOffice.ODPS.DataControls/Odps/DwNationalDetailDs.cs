using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;
using NZPostOffice.ODPS.DataControls.OdpsCodes;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwNationalDetailDs : Metex.Windows.DataUserControl
	{
		public DwNationalDetailDs()
		{
			InitializeComponent();
			InitializeDropdown();
		}

		private void InitializeDropdown()
		{
			nat_ac_id_postax_adj_gl.AssignDropdownType<DDddwAccountCodes>();
			nat_courierpost_defaultcompty.AssignDropdownType<DddwPaymentComponentType>();
			nat_ac_id_whtax_gl.AssignDropdownType<DDddwAccountCodes>();
			nat_pbu_code_accrualbalance_g.AssignDropdownType<DDddwPbuCodes>();
			nat_ac_id_netpay_gl.AssignDropdownType<DDddwAccountCodes>();
			nat_deductions_defaultcomptyp.AssignDropdownType<DddwPaymentComponentType>();
			nat_ac_id_gst_gl.AssignDropdownType<DDddwAccountCodes>();
			nat_ac_id_contprice_gl.AssignDropdownType<DDddwAccountCodes>();
			nat_pbu_code_netpay_gl.AssignDropdownType<DDddwPbuCodes>();
			nat_contadj_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
			ac_id.AssignDropdownType<DDddwAccountCodes>();
			nat_adpost_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
			nat_ac_id_accrualbalance_gl.AssignDropdownType<DDddwAccountCodes>();
			nat_pbu_code_whtax_gl.AssignDropdownType<DDddwPbuCodes>();
			nat_pbu_code_gst_gl.AssignDropdownType<DDddwPbuCodes>();
			nat_pbu_code_postax_gl.AssignDropdownType<DDddwPbuCodes>();
			nat_contallow_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
			nat_freqadj_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
		}

		public int Retrieve( int? a_national_id )
        {
			return RetrieveCore<NationalDetailDs>(NationalDetailDs.GetAllNationalDetailDs(a_national_id));
		}

        private void nat_rural_post_address_t_Click(object sender, EventArgs e)
        {

        }
	}
}

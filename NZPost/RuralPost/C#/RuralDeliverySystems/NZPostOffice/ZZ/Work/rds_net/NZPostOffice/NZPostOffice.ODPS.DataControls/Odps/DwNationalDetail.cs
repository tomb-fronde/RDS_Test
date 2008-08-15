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
    public partial class DwNationalDetail : Metex.Windows.DataUserControl
    {
        public DwNationalDetail()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            nat_ac_id_gst_gl.AssignDropdownType<DDddwAccountCodes>();
            nat_ac_id_whtax_gl.AssignDropdownType<DDddwAccountCodes>();
            nat_ac_id_postax_adj_gl.AssignDropdownType<DDddwAccountCodes>();
            nat_ac_id_contprice_gl.AssignDropdownType<DDddwAccountCodes>();
            nat_ac_id_netpay_gl.AssignDropdownType<DDddwAccountCodes>();
            nat_ac_id_accrualbalance_gl.AssignDropdownType<DDddwAccountCodes>();
  
            ac_id.AssignDropdownType<DDddwAccountCodes>();

            nat_pbu_code_postax_gl.AssignDropdownType<DDddwPbuCodes>();
            nat_pbu_code_whtax_gl.AssignDropdownType<DDddwPbuCodes>();
            nat_pbu_code_gst_gl.AssignDropdownType<DDddwPbuCodes>();
            nat_pbu_code_netpay_gl.AssignDropdownType<DDddwPbuCodes>();
            nat_pbu_code_accrualbal.AssignDropdownType<DDddwPbuCodes>();

            nat_freqadj_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
            nat_contadj_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
            nat_contallow_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();

            nat_deductions_defaultcomptype.AssignDropdownType<DDddwPaymentComponents>();
            nat_courierpost_defaultcomptype.AssignDropdownType<DDddwPaymentComponents>();

            nat_adpost_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
            nat_xp_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
            nat_pp_defaultcomptype.AssignDropdownType<DddwPaymentComponentType>();
         
        }

        public int Retrieve(int? a_national_id)
        {
            return RetrieveCore<NationalDetail>(NationalDetail.GetAllNationalDetail(a_national_id));
        }
    }
}

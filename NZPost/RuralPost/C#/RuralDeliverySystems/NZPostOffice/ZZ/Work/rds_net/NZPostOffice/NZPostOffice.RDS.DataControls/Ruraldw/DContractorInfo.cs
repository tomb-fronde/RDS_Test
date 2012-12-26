using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;
//////using NZPostOffice.RDS.DataControls.EpDropdowns;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    public partial class DContractorInfo : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_037  Dec-2012
        // Added Mobile2, Primary contact checkboxes, and contractor notes
        // Added mobile2 to set_phone_masks
        //
        // TJB  RPI_002  June-2010
        //      Added routines to determine the correct phone number mask
        //      for the contractor's day, night and mobile phones.

        public DContractorInfo()
		{
			InitializeComponent();
            // TJB  RPI_002  June-2010: Added
            this.RetrieveEnd += new System.EventHandler(this.DContractorInfo_RetrieveEnd);
        }

		public int Retrieve( int? al_contract_no )
        {
            return RetrieveCore<ContractorInfo>(ContractorInfo.GetAllContractorInfo(al_contract_no));
        }

        // TJB  RPI_002  June-2010: Added
        private void set_phoneNo_masks()
        {
            string sPhoneNo = "";
            string sMask = "";
            // Set the current field mask to "" so the Text contains the unmasked value
            this.contractor_c_phone_day.Mask = "";
            sPhoneNo = this.contractor_c_phone_day.Text;
            sMask = set_phone_mask(sPhoneNo);
            this.contractor_c_phone_day.Mask = sMask;
            this.contractor_c_phone_night.Mask = "";
            sPhoneNo = this.contractor_c_phone_night.Text;
            sMask = set_phone_mask(sPhoneNo);
            this.contractor_c_phone_night.Mask = sMask;
            this.contractor_c_mobile.Mask = "";
            sPhoneNo = this.contractor_c_mobile.Text;
            sMask = set_phone_mask(sPhoneNo);
            this.contractor_c_mobile.Mask = sMask;
            this.contractor_c_mobile2.Mask = "";
            sPhoneNo = this.contractor_c_mobile2.Text;
            sMask = set_phone_mask(sPhoneNo);
            this.contractor_c_mobile2.Mask = sMask;
        }

        // TJB  RPI_002  June-2010: Added
        private string set_phone_mask(string s_phone_no)
        {
            // Return the mask with extra '#'s in case the value has extra digits
            string ls_temp = "";
            if (s_phone_no != null && s_phone_no.Length > 1)
            {
                if ( s_phone_no.Substring(0, 2) == "02")
                {
                    if (s_phone_no.Length > 10)
                        ls_temp = "(###) ####-#######";
                    else
                        ls_temp = "(###) ###-#######";
                }
                else
                {
                    if (s_phone_no.Length > 9)
                        ls_temp = "(##) ####-#######";
                    else
                        ls_temp = "(##) ###-#######";
                }
            }
            return ls_temp;
        }

        // TJB  RPI_002  June-2010: Added
        private void DContractorInfo_RetrieveEnd(object sender, EventArgs e)
        {
            set_phoneNo_masks();
        }
    }
}

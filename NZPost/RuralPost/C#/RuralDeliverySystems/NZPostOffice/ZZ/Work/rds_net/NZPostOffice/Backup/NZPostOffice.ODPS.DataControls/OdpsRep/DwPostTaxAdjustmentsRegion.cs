using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    public partial class DwPostTaxAdjustmentsRegion : Metex.Windows.DataUserControl
    {
        public DwPostTaxAdjustmentsRegion()
        {
            InitializeComponent();
        }

        private DateTime ui_sdate = DateTime.MinValue;
        private DateTime ui_edate = DateTime.MinValue;
        private int ui_inregion = 0;
        public int Retrieve(DateTime? sdate, DateTime? edate, int? inregion)
        {
            ui_sdate = sdate.GetValueOrDefault();
            ui_edate = edate.GetValueOrDefault();
            ui_inregion = inregion.GetValueOrDefault();
            int ret =  RetrieveCore<PostTaxAdjustmentsRegion>(new List<PostTaxAdjustmentsRegion>
                (PostTaxAdjustmentsRegion.GetAllPostTaxAdjustmentsRegion(sdate, edate, inregion)));
            this.viewer.RefreshReport();
            return ret;
        }

        private int PostTaxAdjustmentsRegionSorter(PostTaxAdjustmentsRegion s1, PostTaxAdjustmentsRegion s2)
        {
            int compareRegion = string.Compare(s1.Region, s2.Region);
            if (compareRegion != 0)
            {
                return compareRegion;
            }
            else
            {
                int compareDedDescription = string.Compare(s1.DedDescription, s2.DedDescription);
                if (compareDedDescription != 0)
                {
                    return compareDedDescription;
                }
                else
                {
                    int compareContractNo = string.Compare(s1.ContractNo.ToString(), s2.ContractNo.ToString());
                    return compareContractNo;
                }
            }
        }
    }
}

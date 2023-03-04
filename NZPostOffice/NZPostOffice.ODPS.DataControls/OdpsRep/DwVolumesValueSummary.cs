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
    public partial class DwVolumesValueSummary : Metex.Windows.DataUserControl
    {
        public DwVolumesValueSummary()
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
            int ret =  RetrieveCore<VolumesValueSummary>(new List<VolumesValueSummary>
                (VolumesValueSummary.GetAllVolumesValueSummary(sdate, edate, inregion)));
            this.viewer.RefreshReport();
            return ret;
        }

        private int VolumesValueSummarySorter(VolumesValueSummary s1, VolumesValueSummary s2)
        {
            int compareRegion = string.Compare(s1.Region, s2.Region);
            if (compareRegion != 0)
            {
                return compareRegion;
            }
            else
            {
                int compareConttype = string.Compare(s1.Conttype, s2.Conttype);
                if (compareConttype != 0)
                {
                    return compareConttype;
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

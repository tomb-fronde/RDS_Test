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
    public partial class DwVolumesValueDetail : Metex.Windows.DataUserControl
    {
        public DwVolumesValueDetail()
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
            int ret =  RetrieveCore<VolumesValueDetail>(new List<VolumesValueDetail>
                (VolumesValueDetail.GetAllVolumesValueDetail(sdate, edate, inregion)));
            this.viewer.RefreshReport();
            return ret;
        }

        private int VolumesValueDetailSorter(VolumesValueDetail s1, VolumesValueDetail s2)
        {
            int compareConttype = string.Compare(s1.Conttype, s2.Conttype);
            if (compareConttype != 0)
            {
                return compareConttype;
            }
            else
            {
                int compareContractNo = string.Compare(s1.ContractNo.ToString(), s2.ContractNo.ToString());
                if (compareContractNo != 0)
                {
                    return compareContractNo;
                }
                else
                {
                    int compareCSurnameCompany = string.Compare(s1.CSurnameCompany, s2.CSurnameCompany);
                    if (compareCSurnameCompany != 0)
                    {
                        return compareCSurnameCompany;
                    }
                    else
                    {
                        int compareCFirstNames = string.Compare(s1.CFirstNames, s2.CFirstNames);
                        if (compareCFirstNames != 0)
                        {
                            return compareCFirstNames;
                        }
                        else
                        {
                            int comparePrsDescription = string.Compare(s1.PrsDescription, s2.PrsDescription);
                            if (comparePrsDescription != 0)
                            {
                                return comparePrsDescription;
                            }
                            else
                            {
                                int comparePrtDescription = string.Compare(s1.PrtDescription, s2.PrtDescription);
                                return comparePrtDescription;
                            }
                        }
                    }
                }
            }
        }
    }
}

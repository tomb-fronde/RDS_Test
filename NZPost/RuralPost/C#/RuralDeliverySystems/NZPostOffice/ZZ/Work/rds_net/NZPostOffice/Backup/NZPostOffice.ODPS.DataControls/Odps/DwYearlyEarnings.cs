using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Odps
{
	public partial class DwYearlyEarnings : Metex.Windows.DataUserControl
	{
		public DwYearlyEarnings()
		{
			InitializeComponent();
		}

		public int Retrieve( DateTime? sdate, DateTime? edate, int? inregion )
        {
            this.eDate = edate;
			return RetrieveCore<YearlyEarnings>(YearlyEarnings.GetAllYearlyEarnings(sdate, edate, inregion));
		}
        private int Sorter(YearlyEarnings s1, YearlyEarnings s2)
        {
            int region = string.Compare(s1.Region,s2.Region);
            if (region != 0)
            {
                return region;
            }
            else
            {
                int contractNo = string.Compare(s1.ContractNo.ToString(), s2.ContractNo.ToString());
                if (contractNo != 0)
                {
                    return contractNo;
                }
                else
                {
                    int cSurnameCompany = string.Compare(s1.CSurnameCompany, s2.CSurnameCompany);
                    if (cSurnameCompany != 0)
                    {
                        return cSurnameCompany;
                    }
                    else
                    {
                        int cIrdNo = string.Compare(s1.CIrdNo, s2.CIrdNo);
                        return cIrdNo;
                    }
                }
            }
        }
	}
}

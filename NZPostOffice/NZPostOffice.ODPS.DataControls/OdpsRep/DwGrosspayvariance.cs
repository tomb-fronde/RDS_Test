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
    public partial class DwGrosspayvariance : Metex.Windows.DataUserControl
	{
		public DwGrosspayvariance()
		{
			InitializeComponent();
		}

		public int Retrieve( DateTime? sdate, DateTime? edate, DateTime? prevsdate, DateTime? prevedate )
		{
            this.eDate = edate;
			int ret = RetrieveCore<Grosspayvariance>(new List<Grosspayvariance>
				(Grosspayvariance.GetAllGrosspayvariance( sdate, edate, prevsdate, prevedate )));
            //SortOnce<Grosspayvariance>(new Comparison<Grosspayvariance>(this.Sorter));

            table = new  NZPostOffice.ODPS.DataControls.Report.GrossPayVarianceDataSet(this.bindingSource.DataSource);
            this.reDwGrossPayVariance.SetDataSource(table);
            viewer.RefreshReport();

            return ret;
		}

        private int Sorter(Grosspayvariance s1, Grosspayvariance s2)
        {
            return string.Compare(s1.ContractNo.ToString(), s2.ContractNo.ToString());
        }

	}
}

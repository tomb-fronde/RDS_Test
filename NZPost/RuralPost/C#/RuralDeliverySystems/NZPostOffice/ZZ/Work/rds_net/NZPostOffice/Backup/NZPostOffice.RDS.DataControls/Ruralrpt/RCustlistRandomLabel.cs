using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RCustlistRandomLabel : Metex.Windows.DataUserControl
	{
		public RCustlistRandomLabel()
		{
			InitializeComponent();
		}

        private int ai_xrequired = 0;

        public int Retrieve(int? xrequired)
		{
            ai_xrequired = xrequired.GetValueOrDefault();
			int ret = RetrieveCore<CustlistRandomLabel>(new List<CustlistRandomLabel>(CustlistRandomLabel.GetAllCustlistRandomLabel(xrequired)));

            //!(this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).ReportDefinition.ReportObjects["CustMailTown1"].Top =
            //!((this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).ReportDefinition.ReportObjects["Box1"]
            //!    as CrystalDecisions.CrystalReports.Engine.BoxObject).Bottom = 120;
            //!((this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).ReportDefinition.ReportObjects["Box1"]
            //!    as CrystalDecisions.CrystalReports.Engine.BoxObject).Top = 120;
                
            //!    (this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).ReportDefinition.ReportObjects["compute11"].Height +
            //!    (this.viewer.ReportSource as CrystalDecisions.CrystalReports.Engine.ReportClass).ReportDefinition.ReportObjects["compute21"].Height + 100;




            this.viewer.RefreshReport();
            return ret;
		}
	}
}

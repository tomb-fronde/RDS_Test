using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using NZPostOffice.RDS.DataControls.Report;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RDeedCompliance : Metex.Windows.DataUserControl
	{
		public RDeedCompliance()
		{
			InitializeComponent();
		}

		public override int Retrieve()
		{
            int ret = 0;// RetrieveCore<DeedCompliance>(new List<DeedCompliance>(DeedCompliance.GetAllDeedCompliance()));

            DataTable custDT = new DeedCompRegCustDataSet(DeedCompRegCust.GetAllDeedCompRegCust());
            this.report.Subreports["REDDeedCompRegCust.rpt"].SetDataSource(custDT);
            (this.report.Subreports["REDDeedCompRegCust.rpt"].ReportDefinition.ReportObjects["Text135"] as
                CrystalDecisions.CrystalReports.Engine.TextObject).Text = "100.00%";//! code to remove a space in the text without changing subreport's designer
            //!(this.report.Subreports["REDDeedCompRegCust.rpt"].ReportDefinition.ReportObjects["Text152"] as//! code to align the header without changing subreport's designer
            //    CrystalDecisions.CrystalReports.Engine.TextObject).Top -= 50;//!30;
            //(this.report.Subreports["REDDeedCompRegCust.rpt"].ReportDefinition.ReportObjects["Text152"] as
            //    CrystalDecisions.CrystalReports.Engine.TextObject).Height += 100;
            //(this.report.Subreports["REDDeedCompRegCust.rpt"].ReportDefinition.ReportObjects["Text152"] as
            //!    CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = true;

            DataTable addrDT = new DeedCompRegAddrDataSet(DeedCompRegAddr.GetAllDeedCompRegAddr());
            this.report.Subreports["REDDeedCompRegAddr.rpt"].SetDataSource(addrDT);
            (this.report.Subreports["REDDeedCompRegAddr.rpt"].ReportDefinition.ReportObjects["Text79"] as
                CrystalDecisions.CrystalReports.Engine.TextObject).Text = "100.00%";//! code to remove a space in the text without changing subreport's designer

            //pp! make a field a bit bigger to show all text "Under 5 day" - avoid changing report's GUI            
            (this.report.Subreports["REDDeedCompRegAddr.rpt"].ReportDefinition.ReportObjects["Text84"] as
               CrystalDecisions.CrystalReports.Engine.TextObject).Width = 980;
            //!(this.report.Subreports["REDDeedCompRegAddr.rpt"].ReportDefinition.ReportObjects["Text94"] as//! code to align the header without changing subreport's designer
            //    CrystalDecisions.CrystalReports.Engine.TextObject).Top -= 50;//!30;
            //(this.report.Subreports["REDDeedCompRegAddr.rpt"].ReportDefinition.ReportObjects["Text94"] as
            //    CrystalDecisions.CrystalReports.Engine.TextObject).Height += 100;
            //(this.report.Subreports["REDDeedCompRegAddr.rpt"].ReportDefinition.ReportObjects["Text94"] as
            //!    CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.EnableCanGrow = true;

            DataTable occupiedDT = new DeedCompRegOccupiedDataSet(DeedCompRegOccupied.GetAllDeedCompRegOccupied());
            this.report.Subreports["REDDeedCompRegOccupied.rpt"].SetDataSource(occupiedDT);
            (this.report.Subreports["REDDeedCompRegOccupied.rpt"].ReportDefinition.ReportObjects["Text6"] as
                CrystalDecisions.CrystalReports.Engine.TextObject).Text = "100.00%";//! code to remove a space in the text without changing subreport's designer
            //!(this.report.Subreports["REDDeedCompRegOccupied.rpt"].ReportDefinition.ReportObjects["Text11"] as//! code to align the header without changing subreport's designer
            //    CrystalDecisions.CrystalReports.Engine.TextObject).ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign;
            //(this.report.Subreports["REDDeedCompRegOccupied.rpt"].ReportDefinition.ReportObjects["Text11"] as//! code to align the header without changing subreport's designer
            //    CrystalDecisions.CrystalReports.Engine.TextObject).Top -= 50;//!+= 30;
            //(this.report.Subreports["REDDeedCompRegOccupied.rpt"].ReportDefinition.ReportObjects["Text11"] as
            //!    CrystalDecisions.CrystalReports.Engine.TextObject).Height += 30;

            viewer.RefreshReport();

            return ret;
		}
	}
}

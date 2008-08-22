using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;
using CrystalDecisions.CrystalReports.Engine;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RBenchmarkReport2006 : Metex.Windows.DataUserControl
	{
		public RBenchmarkReport2006()
		{
            InitializeComponent();

            this.BackColor = System.Drawing.Color.White;
            //this.VerticalScroll.Visible = true;
            //this.HorizontalScroll.Visible = true;
            this.RetrieveEnd += new EventHandler(RBenchmarkReport2006_RetrieveEnd);
		}

        void RBenchmarkReport2006_RetrieveEnd(object sender, EventArgs e)
        {
            DataTable table = new NZPostOffice.RDS.DataControls.Report.BenchmarkReport2006DataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table);
        }

        private int ai_inContract = 0;
        private int ai_inSequence = 0;

        // MTX010 - Next 5 lines added
        public void ClearSource()
        {
            combinedSource.Clear();
        }
        List<BenchmarkReport2006> combinedSource = new List<BenchmarkReport2006>();

        public int Retrieve(int? inContract, int? inSequence)
		{
            ai_inContract = inContract.GetValueOrDefault();
            ai_inSequence = inSequence.GetValueOrDefault();
            List<BenchmarkReport2006> source 
                        = new List<BenchmarkReport2006>(BenchmarkReport2006.GetAllBenchmarkReport2006(inContract, inSequence));

            // MTX010 - Next 4 lines added
            foreach (BenchmarkReport2006 item in source)
            {
                combinedSource.Add(item);
            }

            int ret = -1;
            try
            {
                // ret = RetrieveCore<BenchmarkReport2006>(new List<BenchmarkReport2006>(source));   // MTX010
                ret = RetrieveCore<BenchmarkReport2006>(combinedSource);
            }
            catch (Exception e)
            {
            }
                //!(BenchmarkReport2006.GetAllBenchmarkReport2006(inContract, inSequence)));
                //! if( isnull(denddate), relativedate(dstartdate,364), denddate) 
            if (source.Count > 0)
            {
                // TJB  RD7_0005 Aug 2008:
                //     If not all Piece Rate Suppliers are included, slide the total up
                //     under the ones that are.  Since Crystal Reports doesn't appear to
                //     have a function for "sliding" things (whichever direction), we have 
                //     to do it manually.
                //
                //     NOTE: there's a bug (in Crystal?, C#?, the interface between them?) 
                //           that means we can't change the position of the line under the 
                //           column of values the way we can change the position of the total
                //           field.  The following hack involves having lines under each of 
                //           the numbers in the column, and turning them off by changing them 
                //           to "noline"s (can't even change the line's visibility!) except
                //           for the one we want to see.
                //
                //     The code assumes there will always be two suppliers ...
                //     It also assumes any "missing" suppliers will always be the last ones ...
                
                if (source[0].PrsSupplier3 == null)
                {
                    LineObject line31 = (LineObject)this.report.ReportDefinition.ReportObjects["Line31"];
                    LineObject line41 = (LineObject)this.report.ReportDefinition.ReportObjects["Line41"];
                    LineObject line51 = (LineObject)this.report.ReportDefinition.ReportObjects["Line51"];

                    int ll_top = (this.report.ReportDefinition.ReportObjects["PrsCost21"] as
                                    CrystalDecisions.CrystalReports.Engine.FieldObject).Top + 375;

                    (this.report.ReportDefinition.ReportObjects["prtotal1"] as
                             CrystalDecisions.CrystalReports.Engine.FieldObject).Top = ll_top;

                    // Hide the lower lines
                    line31.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line41.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line51.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                }
                else if (source[0].PrsSuppleir4 == null)
                {
                    LineObject line21 = (LineObject)this.report.ReportDefinition.ReportObjects["Line21"];
                    LineObject line41 = (LineObject)this.report.ReportDefinition.ReportObjects["Line41"];
                    LineObject line51 = (LineObject)this.report.ReportDefinition.ReportObjects["Line51"];

                    int ll_top = (this.report.ReportDefinition.ReportObjects["PrsCost31"] as
                                    CrystalDecisions.CrystalReports.Engine.FieldObject).Top + 375;

                    (this.report.ReportDefinition.ReportObjects["prtotal1"] as
                             CrystalDecisions.CrystalReports.Engine.FieldObject).Top = ll_top;

                    // Hide the other lines
                    line21.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line41.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line51.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                }
                else if (source[0].PrsSupplier5 == null)
                {
                    LineObject line21 = (LineObject)this.report.ReportDefinition.ReportObjects["Line21"];
                    LineObject line31 = (LineObject)this.report.ReportDefinition.ReportObjects["Line31"];
                    LineObject line51 = (LineObject)this.report.ReportDefinition.ReportObjects["Line51"];

                    int ll_top = (this.report.ReportDefinition.ReportObjects["PrsCost41"] as
                                    CrystalDecisions.CrystalReports.Engine.FieldObject).Top + 375;

                    (this.report.ReportDefinition.ReportObjects["prtotal1"] as
                             CrystalDecisions.CrystalReports.Engine.FieldObject).Top = ll_top;

                    // Hide the other lines
                    line21.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line31.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line51.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                }
                else
                {
                    LineObject line21 = (LineObject)this.report.ReportDefinition.ReportObjects["Line21"];
                    LineObject line31 = (LineObject)this.report.ReportDefinition.ReportObjects["Line31"];
                    LineObject line41 = (LineObject)this.report.ReportDefinition.ReportObjects["Line41"];

                    // Hide the other lines
                    line21.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line31.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                    line41.LineStyle = CrystalDecisions.Shared.LineStyle.NoLine;
                }

                // Determine the report's end date
                //
                // TJB  RD7_0005 Aug 2008:  Changed to use either the EndDate or ExpiryDate
                // If EndDate is null, use ExpiryDate, otherwise EndDate

                if (source[0].Denddate.HasValue)
                {
                    (this.report.ReportDefinition.ReportObjects["EndDate"] as
                        CrystalDecisions.CrystalReports.Engine.TextObject).Text = string.Format("{0:dd-MMM-yyyy}", source[0].Denddate);
                }
                else
                {
                    if (source[0].Dexpirydate.HasValue)
                    {
                        (this.report.ReportDefinition.ReportObjects["EndDate"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject).Text = string.Format("{0:dd-MMM-yyyy}", source[0].Dexpirydate);
                    }
                    else  // If neither an end date nor expiry date is specified, use the start date + 364 days
                    {
                        if (source[0].Dstartdate.HasValue)
                        {
                            (this.report.ReportDefinition.ReportObjects["EndDate"] as
                                CrystalDecisions.CrystalReports.Engine.TextObject).Text
                                         = string.Format("{0:dd-MMM-yyyy}", source[0].Dstartdate.GetValueOrDefault().AddDays(364));
                        }
                    }   // Finally, if there's no start date either, leave the displayed end date blank
                }
            }

            try
            {
                DataTable table2 = new NZPostOffice.RDS.DataControls.Report.BenchmarkReportFrequenciesDataSet
                                                       (BenchmarkReportFrequencies.GetAllBenchmarkReportFrequencies(inContract));
                this.report.Subreports["RERBenchmarkReportFrequencies.rpt"].SetDataSource(table2);
            }
            catch (Exception e)
            {
            }

            this.viewer.RefreshReport();
            return ret;
		}
	}
}

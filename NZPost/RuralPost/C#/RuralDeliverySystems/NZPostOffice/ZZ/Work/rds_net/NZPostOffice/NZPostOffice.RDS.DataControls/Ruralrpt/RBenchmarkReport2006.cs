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
                if (!source[0].Denddate.HasValue)
                {
                    if (source[0].Dstartdate.HasValue)
                    {
                        (this.report.ReportDefinition.ReportObjects["EndDate"] as
                            CrystalDecisions.CrystalReports.Engine.TextObject).Text 
                                     = string.Format("{0:dd-MMM-yyyy}",source[0].Dstartdate.GetValueOrDefault().AddDays(364));
                    }  //! else is empty
                }
                else
                {
                    (this.report.ReportDefinition.ReportObjects["EndDate"] as
                        CrystalDecisions.CrystalReports.Engine.TextObject).Text = string.Format("{0:dd-MMM-yyyy}", source[0].DEnddate);
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

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
	public partial class RBenchmarkReport2010 : Metex.Windows.DataUserControl
	{
        // TJB  RPCR_054  Jul-2013
        // Retrieve the data for the Piecerates subreport 
        // (see RBenchmarkReport2010_RetrieveEnd())
        // NOTE: Although multiple contracts can be selected for benchmark 
        //       reports, only the first is actually displayed
        //
        // TJB Oct 2010
        // Updated version of RBenchmarkReport2006
        // Removed Frequencies subreport and some processing of end date and Piecerate
        // display.  Dataset and database query names changed to ...2010.  Main change 
        // is that the stored proc used for obtaining data is changed to sp_GetBenchmarkRpt2010
        // which includes data for up to 5 frequencies per contract.
		public RBenchmarkReport2010()
		{
            InitializeComponent();

            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;

            //this.VerticalScroll.Visible = true;
            //this.HorizontalScroll.Visible = true;
            this.RetrieveEnd += new EventHandler(RBenchmarkReport2010_RetrieveEnd);
		}

        void RBenchmarkReport2010_RetrieveEnd(object sender, EventArgs e)
        {
            // TJB  July-2013: NOTE
            // See See RDS.DataControls.Ruralrpt.RBenchmarkReport2010.Designer.cs InitializeComponent()
            // where DataSources are defined for the main report and itrs subreports.
            // This is needed to prevent connection login details being asked for
            // for the main and subreport.

            DataTable table1 = new NZPostOffice.RDS.DataControls.Report.BenchmarkReport2010DataSet(this.bindingSource.DataSource);
            this.report.SetDataSource(table1);

            // TJB  RPCR_054  Jul-2013
            // Retrieve the data for the Piecerates subreport
            // Where more than one contract has been selected, table1 contains 
            // multiple rows, with new rows added for each contract
            // (this may or may not be the "right" way to do it, but it works after much experimentation)
            int nRow, nContractNo;
            nRow = table1.Rows.Count;
            nContractNo = (int)table1.Rows[nRow-1]["ContractNo"];
            DataTable table2 = new NZPostOffice.RDS.DataControls.Report.BenchmarkReportPieceratesDataSet(BenchmarkReportPiecerates.GetAllBenchmarkReportPiecerates(nContractNo));
            this.report.Subreports["RERBenchmarkReportPiecerates.rpt"].SetDataSource(table2);
        }

        private int ai_inContract = 0;
        private int ai_inSequence = 0;

        List<BenchmarkReport2010> combinedSource = new List<BenchmarkReport2010>();

        // MTX010 - Next 5 lines added
        public void ClearSource()
        {
            combinedSource.Clear();
        }

        public int Retrieve(int? inContract, int? inSequence)
		{
            int ret = -1;

            ai_inContract = inContract.GetValueOrDefault();
            ai_inSequence = inSequence.GetValueOrDefault();
            List<BenchmarkReport2010> source 
                        = new List<BenchmarkReport2010>(BenchmarkReport2010.GetAllBenchmarkReport2010(inContract, inSequence));
            // MTX010 - Next 4 lines added
            foreach (BenchmarkReport2010 item in source)
            {
                combinedSource.Add(item);
            }

            try
            {
                // ret = RetrieveCore<BenchmarkReport2010>(new List<BenchmarkReport2010>(source));   // MTX010
                ret = RetrieveCore<BenchmarkReport2010>(combinedSource);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error retreiving report data \n"
                                + e.Message
                                , "DataControls.Ruralrpt.RBenchmarkReport2010");
            }
                //!(BenchmarkReport2010.GetAllBenchmarkReport2010(inContract, inSequence)));
                //! if( isnull(denddate), relativedate(dstartdate,364), denddate) 
            if (source.Count > 0)
            {
                // TJB Oct-2010:  ++++ Note ++++
                // Based on trying to get the original report's Frequencies subreport 
                // to populate based on each report's data, the code below is likely 
                // misbehave.  Changes made here appear to be made for each individual
                // report, but when displayed/printed only the changes for the last
                // report of the set are effected for all reports in the set.  In the 
                // code below, that means that the total value and separator line are
                // positioned according to the number of piece rate suppliers for the
                // last contract of the group, and the end date is that for the last 
                // of the group not the contract's end date.
                //
                // +++++++++++++++++++++++++++++
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
                // TJB Oct-2010
                // Changed how the line is provided: Added as a top "border" on the total field.
                // Removed line hiding code (see RBenchmarkReport2006 for the 'old' way).
                //
                //     The code assumes there will always be two suppliers ...
                //     It also assumes any "missing" suppliers will always be the last ones ...
/* TJB  RPCR_054  July-2013
 * Removed - no longer needed (Piece rates shown in sub-report)  
 *         - was causing 'index out of bounds' error
                int ll_top;
                if (source[0].PrsSupplier3 == null)
                {
                    ll_top = (this.report.ReportDefinition.ReportObjects["PrsCost21"] as
                                    CrystalDecisions.CrystalReports.Engine.FieldObject).Top + 375;
                    (this.report.ReportDefinition.ReportObjects["prtotal1"] as
                             CrystalDecisions.CrystalReports.Engine.FieldObject).Top = ll_top;
                }
                else if (source[0].PrsSupplier4 == null)
                {
                    ll_top = (this.report.ReportDefinition.ReportObjects["PrsCost31"] as
                                    CrystalDecisions.CrystalReports.Engine.FieldObject).Top + 375;
                    (this.report.ReportDefinition.ReportObjects["prtotal1"] as
                             CrystalDecisions.CrystalReports.Engine.FieldObject).Top = ll_top;
                }
                else if (source[0].PrsSupplier5 == null)
                {
                    ll_top = (this.report.ReportDefinition.ReportObjects["PrsCost41"] as
                                    CrystalDecisions.CrystalReports.Engine.FieldObject).Top + 375;
                    (this.report.ReportDefinition.ReportObjects["prtotal1"] as
                             CrystalDecisions.CrystalReports.Engine.FieldObject).Top = ll_top;
                }
*/
                // Determine the report's end date
                //
                // TJB  RD7_0005 Aug 2008:  Changed to use either the EndDate or ExpiryDate
                // If EndDate is null, use ExpiryDate, otherwise EndDate

                // TJB Oct-2010
                // Use computed field in report to determine end date
                // if (source[0].Denddate.HasValue)
                // {
                //     (this.report.ReportDefinition.ReportObjects["EndDate"] as
                //         CrystalDecisions.CrystalReports.Engine.TextObject).Text = string.Format("{0:dd-MMM-yyyy}", source[0].Denddate) + "E";
                // }
                // else if (source[0].Dexpirydate.HasValue)
                // {
                //     (this.report.ReportDefinition.ReportObjects["EndDate"] as
                //         CrystalDecisions.CrystalReports.Engine.TextObject).Text = string.Format("{0:dd-MMM-yyyy}", source[0].Dexpirydate)+ "X";
                // }
                // // If neither an end date nor expiry date is specified, use the start date + 364 days
                // else if (source[0].Dstartdate.HasValue)
                // {
                //     (this.report.ReportDefinition.ReportObjects["EndDate"] as
                //         CrystalDecisions.CrystalReports.Engine.TextObject).Text
                //                  = string.Format("{0:dd-MMM-yyyy}", source[0].Dstartdate.GetValueOrDefault().AddDays(364))+ "S";
                // }
            }

            // TJB Oct-2010: Removed BenchmarkReportFrequencies subreport
            // Below originally attempted to populate subreport via (table2).  
            // This worked OK for a single report but when there were multiple reports,
            // all the subreports were populated with the last report's Frequencies.
            // try
            // {
            //     //DataTable table2 = new NZPostOffice.RDS.DataControls.Report.BenchmarkReportFrequenciesDataSet
            //     //                                       (BenchmarkReportFrequencies.GetAllBenchmarkReportFrequencies(inContract));
            //     //    this.report.Subreports["RERBenchmarkReportFrequencies.rpt"].SetDataSource(table2);
            // }
            // catch (Exception e)
            // {
            //     MessageBox.Show("Error setting up frequencies sub-report \n"
            //                     + e.Message
            //                     , "DataControls.Ruralrpt.RBenchmarkReport2010");
            // }

            this.viewer.RefreshReport();
            return ret;
		}

        private void tjb_display_datatable( DataTable dTable )
        {
            int nRow, nRows;
            int nCol, nCols;
            string sCols, tCols;
            string sRow, sRows;
            DataColumn dCol;
            DataRow dRow;

            nCols = dTable.Columns.Count;
            nRows = dTable.Rows.Count;
            sCols = tCols = "";

            for (nCol = 0; nCol < nCols; nCol++)
            {
                dCol = dTable.Columns[nCol];
                sCols += dCol.ColumnName + " + ";
                tCols += dCol.DataType.Name + " + ";
            }

            sRow = sRows = "";
            for (nRow = 0; nRow < nRows; nRow++)
            {
                dRow = dTable.Rows[nRow];
                sRow = "   " + nRow.ToString() + " + ";
                sRow += dRow[0] + " + ";
                sRow += dRow[1] + " + ";
                sRow += dRow[2].ToString();
                sRows += sRow + " \n";
            }
            MessageBox.Show("Datatable: \n"
                            + "   Columns = " + nCols.ToString() + "  \n"
                            + "   Column names: " + sCols + "  \n"
                            + "   Column types: " + tCols + "  \n"
                            + "   \n"
                            + "   Rows    = " + nRows.ToString() + "  \n"
                            + sRows
                            , "DataControls.Ruralrpt.RBenchmarkReport2010");
        }

        private void tjb_set_frequencies(DataTable dTable, int nContract)
        {
            int nRow, nRows;
            int nCol, nCols;
            string sCols, tCols;
            string sRow, sRows;
            string sDesc, sFreq, sDist;
            string sMon, sTue, sWed, sThu, sFri, sSat, sSun;
            string sMsg;
            DataColumn dCol;
            DataRow dRow;

            nCols = dTable.Columns.Count;
            nRows = dTable.Rows.Count;
            sCols = tCols = "";

            sRow = sRows = "";
            sDesc = sFreq = sDist = "";
            sMon = sTue = sWed = sThu = sFri = sSat = sSun = "";
            sMsg = "Contract " + nContract.ToString() + "\n";
            for (nRow = 0; nRow < nRows; nRow++)
            {
                dRow = dTable.Rows[nRow];
                sDesc = (string)dRow[0];
                sFreq = (string)dRow[1];
                sDist = dRow[2].ToString();
                sMon = sFreq.Substring(0, 1);
                sTue = sFreq.Substring(1, 1);
                sWed = sFreq.Substring(2, 1);
                sThu = sFreq.Substring(3, 1);
                sFri = sFreq.Substring(4, 1);
                sSat = sFreq.Substring(5, 1);
                sSun = sFreq.Substring(6, 1);

                sMsg += sDesc + " "
                        + " " + sMon + " "
                        + " " + sTue + " "
                        + " " + sWed + " "
                        + " " + sThu + " "
                        + " " + sFri + " "
                        + " " + sSat + " "
                        + " " + sSun + " "
                        + " " + sDist;

                if (nRow == 0)
                {
                    (this.report.ReportDefinition.ReportObjects["Freq_desc0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = "+" + sDesc;
                    (this.report.ReportDefinition.ReportObjects["Freq_mon0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sMon;
                    (this.report.ReportDefinition.ReportObjects["Freq_tue0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sTue;
                    (this.report.ReportDefinition.ReportObjects["Freq_wed0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sWed;
                    (this.report.ReportDefinition.ReportObjects["Freq_thu0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sThu;
                    (this.report.ReportDefinition.ReportObjects["Freq_fri0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sFri;
                    (this.report.ReportDefinition.ReportObjects["Freq_sat0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sSat;
                    (this.report.ReportDefinition.ReportObjects["Freq_sun0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sSun;
                    (this.report.ReportDefinition.ReportObjects["Freq_dist0"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sDist;
                }
                else if (nRow == 1)
                {
                    (this.report.ReportDefinition.ReportObjects["Freq_desc1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = "+" + sDesc;
                    (this.report.ReportDefinition.ReportObjects["Freq_mon1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sMon;
                    (this.report.ReportDefinition.ReportObjects["Freq_tue1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sTue;
                    (this.report.ReportDefinition.ReportObjects["Freq_wed1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sWed;
                    (this.report.ReportDefinition.ReportObjects["Freq_thu1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sThu;
                    (this.report.ReportDefinition.ReportObjects["Freq_fri1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sFri;
                    (this.report.ReportDefinition.ReportObjects["Freq_sat1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sSat;
                    (this.report.ReportDefinition.ReportObjects["Freq_sun1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sSun;
                    (this.report.ReportDefinition.ReportObjects["Freq_dist1"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sDist;
                }
                else if (nRow == 2)
                {
                    (this.report.ReportDefinition.ReportObjects["Freq_desc2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = "+" + sDesc;
                    (this.report.ReportDefinition.ReportObjects["Freq_mon2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sMon;
                    (this.report.ReportDefinition.ReportObjects["Freq_tue2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sTue;
                    (this.report.ReportDefinition.ReportObjects["Freq_wed2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sWed;
                    (this.report.ReportDefinition.ReportObjects["Freq_thu2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sThu;
                    (this.report.ReportDefinition.ReportObjects["Freq_fri2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sFri;
                    (this.report.ReportDefinition.ReportObjects["Freq_sat2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sSat;
                    (this.report.ReportDefinition.ReportObjects["Freq_sun2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sSun;
                    (this.report.ReportDefinition.ReportObjects["Freq_dist2"] as
                           CrystalDecisions.CrystalReports.Engine.TextObject).Text = sDist;
                }
            }
            MessageBox.Show(sMsg, "DataControls.Ruralrpt.RBenchmarkReport2010");
        }

        //public override void Print()
        //{
        //    this.viewer.PrintReport();
        //}
    }
}

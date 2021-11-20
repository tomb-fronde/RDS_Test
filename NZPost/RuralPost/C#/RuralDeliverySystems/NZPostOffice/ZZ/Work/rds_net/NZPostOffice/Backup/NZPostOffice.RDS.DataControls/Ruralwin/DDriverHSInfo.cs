using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralwin;

namespace NZPostOffice.RDS.DataControls.Ruralwin
{
    // TJB  RPCR_060  Mar-2014
    // Added dataGridView1_CellToolTipTextNeeded event handler
    // to populate a tooltip for the H&S Notes cell with help 
    // text from the HS_Type table.
    //
    // TJB  RPCR_060  Feb-2014
    // Added HsiAdditionalDate to display
    //
    // TJB  RPCR_060  Jan-2014: NEW
    // Datacontrol for Driver Health & Safety info

    public partial class DDriverHSInfo : Metex.Windows.DataUserControl
    {
        public DDriverHSInfo()
        {
            InitializeComponent();

            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dataGridView1_CellToolTipTextNeeded);
        }

        public int Retrieve(int? in_driver_no)
        {
            return RetrieveCore<DriverHSInfo>(DriverHSInfo.GetAllDriverHSInfo(in_driver_no));
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errmsg;
            int nRow, nCol;

            errmsg = e.Exception.Message;
            nRow = e.RowIndex;
            nCol = e.ColumnIndex;

            MessageBox.Show(errmsg + "\n"
                           + "at row " + nRow.ToString() + ", column " + nCol.ToString()
                           , "Data error");
        }

        // TJB  RPCR_060  Mar-2014
        // Added this event handler to populate a tooltip for the H&S Notes cell 
        // (ColumnIndex=4)with help text from the HS_Type table.
        void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            string newLine = Environment.NewLine;
            if (e.RowIndex > -1)
            {
                DataGridViewRow dataGridViewRow1 = dataGridView1.Rows[e.RowIndex];

                if (e.ColumnIndex == 4)
                {
                    e.ToolTipText =  (string)dataGridViewRow1.Cells["HstHelp"].Value;
                }
                else
                    e.ToolTipText = String.Empty;

/******************************************************************************** 
  // From the DataGridView.CellToolTipTextNeeded event handler example ...
                // Add the employee's name to the ToolTipText.
                e.ToolTipText += String.Format("{0} {1} {2}{3}",
                    dataGridViewRow1.Cells["TitleOfCourtesy"].Value.ToString(),
                    dataGridViewRow1.Cells["FirstName"].Value.ToString(),
                    dataGridViewRow1.Cells["LastName"].Value.ToString(),
                    newLine);
******************************************************************************* */
            }
        }
    }
}

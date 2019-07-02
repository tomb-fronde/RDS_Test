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
    // TJB  RPCR_128  June-2019: New
    // Derived from DwIr348Detail
    // Disabled Retrieve() and modified RetrieveCore
    // Added new fields in designer

    public partial class DwIrdPaydayDetail : Metex.Windows.DataUserControl
    {
        public DwIrdPaydayDetail()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? startdate, DateTime? enddate)
        {
/*          // TJB  RPCR_128  June-2019
            // "Old" method of culling 0 totals (a) didn't work, and (b) no longer needed
            // since culling is done in stored procedure.
 
            //!Filter:  gross_earnings <> 0 
            List<IrdPaydayDetail> SourceList = new List<IrdPaydayDetail>();
            IrdPaydayDetail [] beforeFilter = IrdPaydayDetail.GetAllIrdPaydayDetail(startdate, enddate);

            foreach (IrdPaydayDetail item in beforeFilter)
            {
                // tjb  RPI_004  June-2010
                // Changed GrossEarnings from decimal? to string in definition
                // Changed test to suit.

                // TJB RPCR_128 June-2019: Changed GrossEarnings back to decimal
                if (item.GrossEarnings != 0)
                //if (item.GrossEarnings != null
                //    && item.GrossEarnings.Length > 1
                //    && item.GrossEarnings != "0")
                {
                    SourceList.Add(item);
                }
            }

            return RetrieveCore<IrdPaydayDetail>(new List<IrdPaydayDetail>(SourceList));
*/
            return RetrieveCore<IrdPaydayDetail>(new List<IrdPaydayDetail>
                   (IrdPaydayDetail.GetAllIrdPaydayDetail(startdate, enddate)));
        }
    }
}

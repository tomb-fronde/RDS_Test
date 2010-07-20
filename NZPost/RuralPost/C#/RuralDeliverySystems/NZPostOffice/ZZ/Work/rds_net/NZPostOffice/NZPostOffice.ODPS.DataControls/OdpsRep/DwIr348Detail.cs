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
    public partial class DwIr348Detail : Metex.Windows.DataUserControl
    {
        public DwIr348Detail()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? startdate, DateTime? enddate)
        {
            //!Filter:  gross_earnings <> 0 
            List<Ir348Detail> SourceList = new List<Ir348Detail>();
            Ir348Detail [] beforeFilter = Ir348Detail.GetAllIr348Detail(startdate, enddate);

            foreach (Ir348Detail item in beforeFilter)
            {
                // tjb  RPI_004  June-2010
                // Changed GrossEarnings from decimal? to string in definition
                // Changed test to suit.

                //if (item.GrossEarnings != 0)
                if (item.GrossEarnings != null
                    && item.GrossEarnings.Length > 1
                    && item.GrossEarnings != "0")
                {
                    SourceList.Add(item);
                }
            }

            return RetrieveCore<Ir348Detail>(new List<Ir348Detail>(SourceList));

            
        }
    }
}

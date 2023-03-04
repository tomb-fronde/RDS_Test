using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.OdpsInvoice
{
    // TJB  RPCR_058  Jan-2014
    // Fixed bug in DwInvoiceHeaderv5_RetrieveEnd for cp subreport (table8)
    // (see designer)
    //
    // TJB  RPCR_056  June-2013
    // Add info for Allowance Breakdown subreport (see designer code)

    public partial class DwInvoiceHeaderv5 : Metex.Windows.DataUserControl
    {
        public DwInvoiceHeaderv5()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {

        }

        public int Retrieve(DateTime? start_date, DateTime? end_date, int? contractor, int? contract, int? region, string cname, int? ctKey)
        {
            this.eDate = end_date;
            this.StartDate = start_date;
            this.EndDate = end_date;
            int retVal = 0;

            try
            {
                retVal = RetrieveCore<InvoiceHeaderv5>(new List<InvoiceHeaderv5>(
                    InvoiceHeaderv5.GetAllInvoiceHeaderv5(start_date, end_date, contractor, contract, region, cname, ctKey)));
            }
            catch(Exception e)
            {
                sqlerrtext = e.Message;
            }
            return retVal;
        }
        DateTime? EndDate;
        DateTime? StartDate;
        string sqlerrtext = "";
    }
}

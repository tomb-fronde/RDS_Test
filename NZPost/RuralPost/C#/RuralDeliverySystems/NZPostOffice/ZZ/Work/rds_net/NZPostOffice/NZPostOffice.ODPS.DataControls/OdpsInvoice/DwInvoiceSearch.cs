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
    public partial class DwInvoiceSearch : Metex.Windows.DataUserControl
    {
        public DwInvoiceSearch()
        {
            InitializeComponent();
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            this.region_id.AssignDropdownType<DDddwRegions>();
            this.ct_key.AssignDropdownType<DDddwContracttypes>();
            this.RetrieveEnd += new EventHandler(DwInvoiceSearch_RetrieveEnd);
        }

        private void DwInvoiceSearch_RetrieveEnd(object sender, System.EventArgs e)
        {
            region_id.SelectedIndex = 6;
            ct_key.SelectedIndex = 1;
        }

        public int Retrieve()
        {
            return RetrieveCore<InvoiceSearch>(new List<InvoiceSearch>(InvoiceSearch.GetAllInvoiceSearch()));
        }
    }
}

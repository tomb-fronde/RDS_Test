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
    public partial class DwPaymentSummary : Metex.Windows.DataUserControl
    {
        public DwPaymentSummary()
        {
            InitializeComponent();
        }

        private DateTime ui_sdate = DateTime.MinValue;
        private DateTime ui_edate = DateTime.MinValue;
        private int ui_inregion = 0;
        public int Retrieve(DateTime? sdate, DateTime? edate, int? inregion)
        {
            ui_sdate = sdate.GetValueOrDefault();
            ui_edate = edate.GetValueOrDefault();
            ui_inregion = inregion.GetValueOrDefault();
            int ret = 0;
            try//! avoid "No Error" error from Crystal Viewer
            {
                ret = RetrieveCore<PaymentSummary>(new List<PaymentSummary>
                    (PaymentSummary.GetAllPaymentSummary(sdate, edate, inregion)));
                this.SortString = "region A,contract_type A,contract_no A";
                this.Sort<PaymentSummary>();
                this.viewer.RefreshReport();
            }catch(Exception e)
            {
            }

            return ret;
        }
    }
}

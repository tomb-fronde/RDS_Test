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
    public partial class DwPaymentSummaryCtype : Metex.Windows.DataUserControl
    {
        public DwPaymentSummaryCtype()
        {
            InitializeComponent();
        }

        private DateTime ui_sdate = DateTime.MinValue;
        private DateTime ui_edate = DateTime.MinValue;
        private int ui_inregion = 0;
        private string ui_inctype = string.Empty;
        public int Retrieve(DateTime? sdate, DateTime? edate, int? inregion, string inctype)
        {
            ui_sdate = sdate.GetValueOrDefault();
            ui_edate = edate.GetValueOrDefault();
            ui_inregion = inregion.GetValueOrDefault();
            ui_inctype = inctype;
            int ret = 0;
             try//! avoid "No Error" error from Crystal Viewer
            {
                ret =  RetrieveCore<PaymentSummaryCtype>(new List<PaymentSummaryCtype>
                    (PaymentSummaryCtype.GetAllPaymentSummaryCtype(sdate, edate, inregion, inctype)));
                this.viewer.RefreshReport();
            }
            catch (Exception e)
            {
            }
            return ret;
        }

        private int PaymentSummaryCtypeSorter(PaymentSummaryCtype s1, PaymentSummaryCtype s2)
        {
            int compareRegion = string.Compare(s1.Region, s2.Region);
            if (compareRegion != 0)
            {
                return compareRegion;
            }
            else
            {
                int compareContractType = string.Compare(s1.ContractType, s2.ContractType);
                if (compareContractType != 0)
                {
                    return compareContractType;
                }
                else
                {
                    int compareContractNo = string.Compare(s1.ContractNo.ToString(), s2.ContractNo.ToString());
                    return compareContractNo;
                }
            }
        }
    }
}

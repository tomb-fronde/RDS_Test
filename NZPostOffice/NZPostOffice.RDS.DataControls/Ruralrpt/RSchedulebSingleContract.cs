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
    // TJB  RPCR_057  Jan-2014
    // Added overload Retrieve() with ReportDate parameter

    public partial class RSchedulebSingleContract : Metex.Windows.DataUserControl
    {
        public RSchedulebSingleContract()
        {
            InitializeComponent();
            //this.SortString = "contract_no A, piece_rate_supplier_prs_description A, piece_rate_type_prt_code A";
        }

        public int Retrieve(int? incontract, int? inSequence)
        {
            int ret = RetrieveCore<SchedulebSingleContract>(new List<SchedulebSingleContract>(SchedulebSingleContract.GetAllSchedulebSingleContract(incontract, inSequence)));

            return ret;
        }

        // TJB  RPCR_057  Jan-2014
        // Added overload with ReportDate parameter
        public int Retrieve(int? incontract, int? inSequence, DateTime? inReportDate)
        {
            int ret = RetrieveCore<SchedulebSingleContract>(new List<SchedulebSingleContract>(SchedulebSingleContract.GetAllSchedulebSingleContract(incontract, inSequence, inReportDate)));

            return ret;
        }

        private int ContractNoSorter(SchedulebSingleContract s1, SchedulebSingleContract s2)
        {
            int compareContractNo = string.Compare(s1.ContractNo.ToString(), s2.ContractNo.ToString());
            if (compareContractNo != 0)
            {
                return compareContractNo;
            }
            else
            {
                int comparePieceRateSupplierPrsDescription = string.Compare(s1.PieceRateSupplierPrsDescription, s2.PieceRateSupplierPrsDescription);
                if (comparePieceRateSupplierPrsDescription != 0)
                {
                    return comparePieceRateSupplierPrsDescription;
                }
                else
                {
                    int comparePieceRateTypePrtCode = string.Compare(s1.PieceRateTypePrtCode, s2.PieceRateTypePrtCode);
                    return comparePieceRateTypePrtCode;
                }
            }
        }
    }
}

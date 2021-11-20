using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RNationalHistoryChanges
    {
        public int NatAcIdGstGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatAcIdGstGl
        {
            get
            {
                return 0;
            }
        }
        public int NatAcIdWhtaxGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatAcIdWhtaxGl
        {
            get
            {
                return 0;
            }
        }
        public int NatAcIdPostaxAdjGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatAcIdPostaxAdjGl
        {
            get
            {
                return 0;
            }
        }
        public string NatRuralPostGstNo
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal NatGstRate
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatGstRate
        {
            get
            {
                return 0;
            }
        }
        public string NatIrdNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string NatRuralPostAddress
        {
            get
            {
                return string.Empty;
            }
        }
        public string NatRuralPostPayerName
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal NatAccPercentage
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatAccPercentage
        {
            get
            {
                return 0;
            }
        }
        public decimal NatStandardTaxRate
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatStandardTaxRate
        {
            get
            {
                return 0;
            }
        }
        public int NatDayOfMonth
        {
            get
            {
                return 0;
            }
        }
        public int RENatDayOfMonth
        {
            get
            {
                return 0;
            }
        }
        public string NatMessageForInvoice
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal NatNetPctChangeWarn
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatNetPctChangeWarn
        {
            get
            {
                return 0;
            }
        }
        public int NatSeqNoForKeys
        {
            get
            {
                return 0;
            }
        }
        public int RENatSeqNoForKeys
        {
            get
            {
                return 0;
            }
        }
        public decimal NatOdStandardGstRate
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatOdStandardGstRate
        {
            get
            {
                return 0;
            }
        }
        public decimal NatOdTaxRateIr13
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatOdTaxRateIr13
        {
            get
            {
                return 0;
            }
        }
        public decimal NatOdTaxRateNoIr13
        {
            get
            {
                return 0;
            }
        }
        public decimal RENatOdTaxRateNoIr13
        {
            get
            {
                return 0;
            }
        }
        public int ApNetPayClearingAccount
        {
            get
            {
                return 0;
            }
        }
        public int REApNetPayClearingAccount
        {
            get
            {
                return 0;
            }
        }
        public DateTime NatEffectiveDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RENatEffectiveDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int NatAcIdContpriceGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatAcIdContpriceGl
        {
            get
            {
                return 0;
            }
        }
        public int NatAcIdNetpayGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatAcIdNetpayGl
        {
            get
            {
                return 0;
            }
        }
        public int NatAcIdAccrualbalanceGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatAcIdAccrualbalanceGl
        {
            get
            {
                return 0;
            }
        }
        public int NatPbuCodePostaxGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatPbuCodePostaxGl
        {
            get
            {
                return 0;
            }
        }
        public int NatPbuCodeWhtaxGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatPbuCodeWhtaxGl
        {
            get
            {
                return 0;
            }
        }
        public int NatPbuCodeGstGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatPbuCodeGstGl
        {
            get
            {
                return 0;
            }
        }
        public int NatPbuCodeNetpayGl
        {
            get
            {
                return 0;
            }
        }
        public int RENatPbuCodeNetpayGl
        {
            get
            {
                return 0;
            }
        }
        public string NatInvoiceNumberPrefix
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class NationalHistoryChangesDataSet : ReportDataSet<NationalHistoryChanges>
    {

        public DataColumn NatAcIdGstGl = new DataColumn("NatAcIdGstGl", typeof(int));

        public DataColumn RENatAcIdGstGl = new DataColumn("RENatAcIdGstGl", typeof(int));

        public DataColumn NatAcIdWhtaxGl = new DataColumn("NatAcIdWhtaxGl", typeof(int));

        public DataColumn RENatAcIdWhtaxGl = new DataColumn("RENatAcIdWhtaxGl", typeof(int));

        public DataColumn NatAcIdPostaxAdjGl = new DataColumn("NatAcIdPostaxAdjGl", typeof(int));

        public DataColumn RENatAcIdPostaxAdjGl = new DataColumn("RENatAcIdPostaxAdjGl", typeof(int));

        public DataColumn NatRuralPostGstNo = new DataColumn("NatRuralPostGstNo", typeof(string));

        public DataColumn NatGstRate = new DataColumn("NatGstRate", typeof(decimal));

        public DataColumn RENatGstRate = new DataColumn("RENatGstRate", typeof(decimal));

        public DataColumn NatIrdNo = new DataColumn("NatIrdNo", typeof(string));

        public DataColumn NatRuralPostAddress = new DataColumn("NatRuralPostAddress", typeof(string));

        public DataColumn NatRuralPostPayerName = new DataColumn("NatRuralPostPayerName", typeof(string));

        public DataColumn NatAccPercentage = new DataColumn("NatAccPercentage", typeof(decimal));

        public DataColumn RENatAccPercentage = new DataColumn("RENatAccPercentage", typeof(decimal));

        public DataColumn NatStandardTaxRate = new DataColumn("NatStandardTaxRate", typeof(decimal));

        public DataColumn RENatStandardTaxRate = new DataColumn("RENatStandardTaxRate", typeof(decimal));

        public DataColumn NatDayOfMonth = new DataColumn("NatDayOfMonth", typeof(int));

        public DataColumn RENatDayOfMonth = new DataColumn("RENatDayOfMonth", typeof(int));

        public DataColumn NatMessageForInvoice = new DataColumn("NatMessageForInvoice", typeof(string));

        public DataColumn NatNetPctChangeWarn = new DataColumn("NatNetPctChangeWarn", typeof(decimal));

        public DataColumn RENatNetPctChangeWarn = new DataColumn("RENatNetPctChangeWarn", typeof(decimal));

        public DataColumn NatSeqNoForKeys = new DataColumn("NatSeqNoForKeys", typeof(int));

        public DataColumn RENatSeqNoForKeys = new DataColumn("RENatSeqNoForKeys", typeof(int));

        public DataColumn NatOdStandardGstRate = new DataColumn("NatOdStandardGstRate", typeof(decimal));

        public DataColumn RENatOdStandardGstRate = new DataColumn("RENatOdStandardGstRate", typeof(decimal));

        public DataColumn NatOdTaxRateIr13 = new DataColumn("NatOdTaxRateIr13", typeof(decimal));

        public DataColumn RENatOdTaxRateIr13 = new DataColumn("RENatOdTaxRateIr13", typeof(decimal));

        public DataColumn NatOdTaxRateNoIr13 = new DataColumn("NatOdTaxRateNoIr13", typeof(decimal));

        public DataColumn RENatOdTaxRateNoIr13 = new DataColumn("RENatOdTaxRateNoIr13", typeof(decimal));

        public DataColumn ApNetPayClearingAccount = new DataColumn("ApNetPayClearingAccount", typeof(int));

        public DataColumn REApNetPayClearingAccount = new DataColumn("REApNetPayClearingAccount", typeof(int));

        public DataColumn NatEffectiveDate = new DataColumn("NatEffectiveDate", typeof(DateTime));

        public DataColumn RENatEffectiveDate = new DataColumn("RENatEffectiveDate", typeof(DateTime));

        public DataColumn NatAcIdContpriceGl = new DataColumn("NatAcIdContpriceGl", typeof(int));

        public DataColumn RENatAcIdContpriceGl = new DataColumn("RENatAcIdContpriceGl", typeof(int));

        public DataColumn NatAcIdNetpayGl = new DataColumn("NatAcIdNetpayGl", typeof(int));

        public DataColumn RENatAcIdNetpayGl = new DataColumn("RENatAcIdNetpayGl", typeof(int));

        public DataColumn NatAcIdAccrualbalanceGl = new DataColumn("NatAcIdAccrualbalanceGl", typeof(int));

        public DataColumn RENatAcIdAccrualbalanceGl = new DataColumn("RENatAcIdAccrualbalanceGl", typeof(int));

        public DataColumn NatPbuCodePostaxGl = new DataColumn("NatPbuCodePostaxGl", typeof(int));

        public DataColumn RENatPbuCodePostaxGl = new DataColumn("RENatPbuCodePostaxGl", typeof(int));

        public DataColumn NatPbuCodeWhtaxGl = new DataColumn("NatPbuCodeWhtaxGl", typeof(int));

        public DataColumn RENatPbuCodeWhtaxGl = new DataColumn("RENatPbuCodeWhtaxGl", typeof(int));

        public DataColumn NatPbuCodeGstGl = new DataColumn("NatPbuCodeGstGl", typeof(int));

        public DataColumn RENatPbuCodeGstGl = new DataColumn("RENatPbuCodeGstGl", typeof(int));

        public DataColumn NatPbuCodeNetpayGl = new DataColumn("NatPbuCodeNetpayGl", typeof(int));

        public DataColumn RENatPbuCodeNetpayGl = new DataColumn("RENatPbuCodeNetpayGl", typeof(int));

        public DataColumn NatInvoiceNumberPrefix = new DataColumn("NatInvoiceNumberPrefix", typeof(string));


        public NationalHistoryChangesDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				NatAcIdGstGl,RENatAcIdGstGl,NatAcIdWhtaxGl,RENatAcIdWhtaxGl,NatAcIdPostaxAdjGl,RENatAcIdPostaxAdjGl,NatRuralPostGstNo,NatGstRate,RENatGstRate,NatIrdNo,NatRuralPostAddress,NatRuralPostPayerName,NatAccPercentage,RENatAccPercentage,NatStandardTaxRate,RENatStandardTaxRate,NatDayOfMonth,RENatDayOfMonth,NatMessageForInvoice,NatNetPctChangeWarn,RENatNetPctChangeWarn,NatSeqNoForKeys,RENatSeqNoForKeys,NatOdStandardGstRate,RENatOdStandardGstRate,NatOdTaxRateIr13,RENatOdTaxRateIr13,NatOdTaxRateNoIr13,RENatOdTaxRateNoIr13,ApNetPayClearingAccount,REApNetPayClearingAccount,NatEffectiveDate,RENatEffectiveDate,NatAcIdContpriceGl,RENatAcIdContpriceGl,NatAcIdNetpayGl,RENatAcIdNetpayGl,NatAcIdAccrualbalanceGl,RENatAcIdAccrualbalanceGl,NatPbuCodePostaxGl,RENatPbuCodePostaxGl,NatPbuCodeWhtaxGl,RENatPbuCodeWhtaxGl,NatPbuCodeGstGl,RENatPbuCodeGstGl,NatPbuCodeNetpayGl,RENatPbuCodeNetpayGl,NatInvoiceNumberPrefix
				});
            NatAcIdGstGl.AllowDBNull = true;
            NatAcIdWhtaxGl.AllowDBNull = true;
            NatAcIdPostaxAdjGl.AllowDBNull = true;
            NatGstRate.AllowDBNull = true;
            NatAccPercentage.AllowDBNull = true;
            NatStandardTaxRate.AllowDBNull = true;
            NatDayOfMonth.AllowDBNull = true;
            NatNetPctChangeWarn.AllowDBNull = true;
            NatSeqNoForKeys.AllowDBNull = true;
            NatOdStandardGstRate.AllowDBNull = true;
            NatOdTaxRateIr13.AllowDBNull = true;
            NatOdTaxRateNoIr13.AllowDBNull = true;
            ApNetPayClearingAccount.AllowDBNull = true;
            NatEffectiveDate.AllowDBNull = true;
            NatAcIdContpriceGl.AllowDBNull = true;
            NatAcIdNetpayGl.AllowDBNull = true;
            NatAcIdAccrualbalanceGl.AllowDBNull = true;
            NatPbuCodePostaxGl.AllowDBNull = true;
            NatPbuCodeWhtaxGl.AllowDBNull = true;
            NatPbuCodeGstGl.AllowDBNull = true;
            NatPbuCodeNetpayGl.AllowDBNull = true;

        }

        public NationalHistoryChangesDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<NationalHistoryChanges> datas = dataSource as Metex.Core.EntityBindingList<NationalHistoryChanges>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(NationalHistoryChanges data)
        {
            DataRow row = this.NewRow();
            row["NatAcIdGstGl"] = GetFieldValue(data.NatAcIdGstGl);
            row["RENatAcIdGstGl"] = GetFieldValue(data.RENatAcIdGstGl);
            row["NatAcIdWhtaxGl"] = GetFieldValue(data.NatAcIdWhtaxGl);
            row["RENatAcIdWhtaxGl"] = GetFieldValue(data.RENatAcIdWhtaxGl);
            row["NatAcIdPostaxAdjGl"] = GetFieldValue(data.NatAcIdPostaxAdjGl);
            row["RENatAcIdPostaxAdjGl"] = GetFieldValue(data.RENatAcIdPostaxAdjGl);
            row["NatRuralPostGstNo"] = GetFieldValue(data.NatRuralPostGstNo);
            row["NatGstRate"] = GetFieldValue(data.NatGstRate);
            row["RENatGstRate"] = GetFieldValue(data.RENatGstRate);
            row["NatIrdNo"] = GetFieldValue(data.NatIrdNo);
            row["NatRuralPostAddress"] = GetFieldValue(data.NatRuralPostAddress);
            row["NatRuralPostPayerName"] = GetFieldValue(data.NatRuralPostPayerName);
            row["NatAccPercentage"] = GetFieldValue(data.NatAccPercentage);
            row["RENatAccPercentage"] = GetFieldValue(data.RENatAccPercentage);
            row["NatStandardTaxRate"] = GetFieldValue(data.NatStandardTaxRate);
            row["RENatStandardTaxRate"] = GetFieldValue(data.RENatStandardTaxRate);
            row["NatDayOfMonth"] = GetFieldValue(data.NatDayOfMonth);
            row["RENatDayOfMonth"] = GetFieldValue(data.RENatDayOfMonth);
            row["NatMessageForInvoice"] = GetFieldValue(data.NatMessageForInvoice);
            row["NatNetPctChangeWarn"] = GetFieldValue(data.NatNetPctChangeWarn);
            row["RENatNetPctChangeWarn"] = GetFieldValue(data.RENatNetPctChangeWarn);
            row["NatSeqNoForKeys"] = GetFieldValue(data.NatSeqNoForKeys);
            row["RENatSeqNoForKeys"] = GetFieldValue(data.RENatSeqNoForKeys);
            row["NatOdStandardGstRate"] = GetFieldValue(data.NatOdStandardGstRate);
            row["RENatOdStandardGstRate"] = GetFieldValue(data.RENatOdStandardGstRate);
            row["NatOdTaxRateIr13"] = GetFieldValue(data.NatOdTaxRateIr13);
            row["RENatOdTaxRateIr13"] = GetFieldValue(data.RENatOdTaxRateIr13);
            row["NatOdTaxRateNoIr13"] = GetFieldValue(data.NatOdTaxRateNoIr13);
            row["RENatOdTaxRateNoIr13"] = GetFieldValue(data.RENatOdTaxRateNoIr13);
            row["ApNetPayClearingAccount"] = GetFieldValue(data.ApNetPayClearingAccount);
            row["REApNetPayClearingAccount"] = GetFieldValue(data.REApNetPayClearingAccount);
            row["NatEffectiveDate"] = GetFieldValue(data.NatEffectiveDate);
            row["RENatEffectiveDate"] = GetFieldValue(data.RENatEffectiveDate);
            row["NatAcIdContpriceGl"] = GetFieldValue(data.NatAcIdContpriceGl);
            row["RENatAcIdContpriceGl"] = GetFieldValue(data.RENatAcIdContpriceGl);
            row["NatAcIdNetpayGl"] = GetFieldValue(data.NatAcIdNetpayGl);
            row["RENatAcIdNetpayGl"] = GetFieldValue(data.RENatAcIdNetpayGl);
            row["NatAcIdAccrualbalanceGl"] = GetFieldValue(data.NatAcIdAccrualbalanceGl);
            row["RENatAcIdAccrualbalanceGl"] = GetFieldValue(data.RENatAcIdAccrualbalanceGl);
            row["NatPbuCodePostaxGl"] = GetFieldValue(data.NatPbuCodePostaxGl);
            row["RENatPbuCodePostaxGl"] = GetFieldValue(data.RENatPbuCodePostaxGl);
            row["NatPbuCodeWhtaxGl"] = GetFieldValue(data.NatPbuCodeWhtaxGl);
            row["RENatPbuCodeWhtaxGl"] = GetFieldValue(data.RENatPbuCodeWhtaxGl);
            row["NatPbuCodeGstGl"] = GetFieldValue(data.NatPbuCodeGstGl);
            row["RENatPbuCodeGstGl"] = GetFieldValue(data.RENatPbuCodeGstGl);
            row["NatPbuCodeNetpayGl"] = GetFieldValue(data.NatPbuCodeNetpayGl);
            row["RENatPbuCodeNetpayGl"] = GetFieldValue(data.RENatPbuCodeNetpayGl);
            row["NatInvoiceNumberPrefix"] = GetFieldValue(data.NatInvoiceNumberPrefix);
            return row;
        }
    }
}

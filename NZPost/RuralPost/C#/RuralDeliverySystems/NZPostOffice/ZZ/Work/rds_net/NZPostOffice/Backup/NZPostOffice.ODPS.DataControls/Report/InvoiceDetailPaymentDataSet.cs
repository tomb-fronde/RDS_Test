using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsInvoice;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RInvoiceDetailPayment
    {
        public decimal MStandard
        {
            get
            {
                return 0;
            }
        }
        public decimal REMStandard
        {
            get
            {
                return 0;
            }
        }
        public decimal MAllowance
        {
            get
            {
                return 0;
            }
        }
        public decimal REMAllowance
        {
            get
            {
                return 0;
            }
        }
        public decimal MTaxableAdjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal REMTaxableAdjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal MGstRate
        {
            get
            {
                return 0;
            }
        }
        public decimal REMGstRate
        {
            get
            {
                return 0;
            }
        }
        public decimal MGstValue
        {
            get
            {
                return 0;
            }
        }
        public decimal REMGstValue
        {
            get
            {
                return 0;
            }
        }
        public decimal MWtaxRate
        {
            get
            {
                return 0;
            }
        }
        public decimal REMWtaxRate
        {
            get
            {
                return 0;
            }
        }
        public decimal MWtaxValue
        {
            get
            {
                return 0;
            }
        }
        public decimal REMWtaxValue
        {
            get
            {
                return 0;
            }
        }
        public decimal MAdjNotax
        {
            get
            {
                return 0;
            }
        }
        public decimal REMAdjNotax
        {
            get
            {
                return 0;
            }
        }
        public decimal YStandard
        {
            get
            {
                return 0;
            }
        }
        public decimal REYStandard
        {
            get
            {
                return 0;
            }
        }
        public decimal YAllowance
        {
            get
            {
                return 0;
            }
        }
        public decimal REYAllowance
        {
            get
            {
                return 0;
            }
        }
        public decimal YTaxableAdjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal REYTaxableAdjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal YGstValue
        {
            get
            {
                return 0;
            }
        }
        public decimal REYGstValue
        {
            get
            {
                return 0;
            }
        }
        public decimal YWtaxValue
        {
            get
            {
                return 0;
            }
        }
        public decimal REYWtaxValue
        {
            get
            {
                return 0;
            }
        }
        public decimal YAdjNotax
        {
            get
            {
                return 0;
            }
        }
        public decimal REYAdjNotax
        {
            get
            {
                return 0;
            }
        }
        public decimal MTotalBeforeTax
        {
            get
            {
                return 0;
            }
        }
        public decimal REMTotalBeforeTax
        {
            get
            {
                return 0;
            }
        }
        public decimal YTotalBeforeTax
        {
            get
            {
                return 0;
            }
        }
        public decimal REYTotalBeforeTax
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute1
        {
            get
            {
                return 0;
            }
        }
        public decimal RECompute1
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute2
        {
            get
            {
                return 0;
            }
        }
        public decimal RECompute2
        {
            get
            {
                return 0;
            }
        }
        public int InvoiceId
        {
            get
            {
                return 0;
            }
        }
        public int ContractNo
        {
            get { return 0; }
        }
        public int ContractorNo
        {
            get { return 0; }
        }
    }
    public class InvoiceDetailPaymentDataSet : ReportDataSet<InvoiceDetailPayment>
    {

        public DataColumn MStandard = new DataColumn("MStandard", typeof(decimal));

        public DataColumn REMStandard = new DataColumn("REMStandard", typeof(decimal));

        public DataColumn MAllowance = new DataColumn("MAllowance", typeof(decimal));

        public DataColumn REMAllowance = new DataColumn("REMAllowance", typeof(decimal));

        public DataColumn MTaxableAdjustments = new DataColumn("MTaxableAdjustments", typeof(decimal));

        public DataColumn REMTaxableAdjustments = new DataColumn("REMTaxableAdjustments", typeof(decimal));

        public DataColumn MGstRate = new DataColumn("MGstRate", typeof(decimal));

        public DataColumn REMGstRate = new DataColumn("REMGstRate", typeof(decimal));

        public DataColumn MGstValue = new DataColumn("MGstValue", typeof(decimal));

        public DataColumn REMGstValue = new DataColumn("REMGstValue", typeof(decimal));

        public DataColumn MWtaxRate = new DataColumn("MWtaxRate", typeof(decimal));

        public DataColumn REMWtaxRate = new DataColumn("REMWtaxRate", typeof(decimal));

        public DataColumn MWtaxValue = new DataColumn("MWtaxValue", typeof(decimal));

        public DataColumn REMWtaxValue = new DataColumn("REMWtaxValue", typeof(decimal));

        public DataColumn MAdjNotax = new DataColumn("MAdjNotax", typeof(decimal));

        public DataColumn REMAdjNotax = new DataColumn("REMAdjNotax", typeof(decimal));

        public DataColumn YStandard = new DataColumn("YStandard", typeof(decimal));

        public DataColumn REYStandard = new DataColumn("REYStandard", typeof(decimal));

        public DataColumn YAllowance = new DataColumn("YAllowance", typeof(decimal));

        public DataColumn REYAllowance = new DataColumn("REYAllowance", typeof(decimal));

        public DataColumn YTaxableAdjustments = new DataColumn("YTaxableAdjustments", typeof(decimal));

        public DataColumn REYTaxableAdjustments = new DataColumn("REYTaxableAdjustments", typeof(decimal));

        public DataColumn YGstValue = new DataColumn("YGstValue", typeof(decimal));

        public DataColumn REYGstValue = new DataColumn("REYGstValue", typeof(decimal));

        public DataColumn YWtaxValue = new DataColumn("YWtaxValue", typeof(decimal));

        public DataColumn REYWtaxValue = new DataColumn("REYWtaxValue", typeof(decimal));

        public DataColumn YAdjNotax = new DataColumn("YAdjNotax", typeof(decimal));

        public DataColumn REYAdjNotax = new DataColumn("REYAdjNotax", typeof(decimal));

        public DataColumn MTotalBeforeTax = new DataColumn("MTotalBeforeTax", typeof(decimal));

        public DataColumn REMTotalBeforeTax = new DataColumn("REMTotalBeforeTax", typeof(decimal));

        public DataColumn YTotalBeforeTax = new DataColumn("YTotalBeforeTax", typeof(decimal));

        public DataColumn REYTotalBeforeTax = new DataColumn("REYTotalBeforeTax", typeof(decimal));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(decimal));

        public DataColumn RECompute1 = new DataColumn("RECompute1", typeof(decimal));

        public DataColumn Compute2 = new DataColumn("Compute2", typeof(decimal));

        public DataColumn RECompute2 = new DataColumn("RECompute2", typeof(decimal));

        public DataColumn InvoiceId = new DataColumn("InvoiceId", typeof(int));
        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));
        public DataColumn ContractorNo = new DataColumn("ContractorNo", typeof(int));

        public InvoiceDetailPaymentDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				MStandard,REMStandard,MAllowance,REMAllowance,MTaxableAdjustments,REMTaxableAdjustments,MGstRate,REMGstRate,MGstValue,REMGstValue,MWtaxRate,REMWtaxRate,MWtaxValue,REMWtaxValue,MAdjNotax,REMAdjNotax,YStandard,REYStandard,YAllowance,REYAllowance,YTaxableAdjustments,REYTaxableAdjustments,YGstValue,REYGstValue,YWtaxValue,REYWtaxValue,YAdjNotax,REYAdjNotax,MTotalBeforeTax,REMTotalBeforeTax,YTotalBeforeTax,REYTotalBeforeTax,Compute1,RECompute1,Compute2,RECompute2,ContractNo,ContractorNo,InvoiceId
				});
            MStandard.AllowDBNull = true;
            MAllowance.AllowDBNull = true;
            MTaxableAdjustments.AllowDBNull = true;
            MGstRate.AllowDBNull = true;
            MGstValue.AllowDBNull = true;
            MWtaxRate.AllowDBNull = true;
            MWtaxValue.AllowDBNull = true;
            MAdjNotax.AllowDBNull = true;
            YStandard.AllowDBNull = true;
            YAllowance.AllowDBNull = true;
            YTaxableAdjustments.AllowDBNull = true;
            YGstValue.AllowDBNull = true;
            YWtaxValue.AllowDBNull = true;
            YAdjNotax.AllowDBNull = true;
            MTotalBeforeTax.AllowDBNull = true;
            YTotalBeforeTax.AllowDBNull = true;
            Compute1.AllowDBNull = true;
            Compute2.AllowDBNull = true;

        }

        public InvoiceDetailPaymentDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<InvoiceDetailPayment> datas = dataSource as Metex.Core.EntityBindingList<InvoiceDetailPayment>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(InvoiceDetailPayment data)
        {
            DataRow row = this.NewRow();
            row["MStandard"] = GetFieldValue(data.MStandard);
            row["REMStandard"] = GetFieldValue(data.REMStandard);
            row["MAllowance"] = GetFieldValue(data.MAllowance);
            row["REMAllowance"] = GetFieldValue(data.REMAllowance);
            row["MTaxableAdjustments"] = GetFieldValue(data.MTaxableAdjustments);
            row["REMTaxableAdjustments"] = GetFieldValue(data.REMTaxableAdjustments);
            row["MGstRate"] = GetFieldValue(data.MGstRate);
            row["REMGstRate"] = GetFieldValue(data.REMGstRate);
            row["MGstValue"] = GetFieldValue(data.MGstValue);
            row["REMGstValue"] = GetFieldValue(data.REMGstValue);
            row["MWtaxRate"] = GetFieldValue(data.MWtaxRate);
            row["REMWtaxRate"] = GetFieldValue(data.REMWtaxRate);
            row["MWtaxValue"] = GetFieldValue(data.MWtaxValue);
            row["REMWtaxValue"] = GetFieldValue(data.REMWtaxValue);
            row["MAdjNotax"] = GetFieldValue(data.MAdjNotax);
            row["REMAdjNotax"] = GetFieldValue(data.REMAdjNotax);
            row["YStandard"] = GetFieldValue(data.YStandard);
            row["REYStandard"] = GetFieldValue(data.REYStandard);
            row["YAllowance"] = GetFieldValue(data.YAllowance);
            row["REYAllowance"] = GetFieldValue(data.REYAllowance);
            row["YTaxableAdjustments"] = GetFieldValue(data.YTaxableAdjustments);
            row["REYTaxableAdjustments"] = GetFieldValue(data.REYTaxableAdjustments);
            row["YGstValue"] = GetFieldValue(data.YGstValue);
            row["REYGstValue"] = GetFieldValue(data.REYGstValue);
            row["YWtaxValue"] = GetFieldValue(data.YWtaxValue);
            row["REYWtaxValue"] = GetFieldValue(data.REYWtaxValue);
            row["YAdjNotax"] = GetFieldValue(data.YAdjNotax);
            row["REYAdjNotax"] = GetFieldValue(data.REYAdjNotax);
            row["MTotalBeforeTax"] = GetFieldValue(data.MTotalBeforeTax);
            row["REMTotalBeforeTax"] = GetFieldValue(data.REMTotalBeforeTax);
            row["YTotalBeforeTax"] = GetFieldValue(data.YTotalBeforeTax);
            row["REYTotalBeforeTax"] = GetFieldValue(data.REYTotalBeforeTax);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["RECompute1"] = GetFieldValue(data.RECompute1);
            row["Compute2"] = GetFieldValue(data.Compute2);
            row["RECompute2"] = GetFieldValue(data.RECompute2);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractorNo"] = GetFieldValue(data.ContractorNo);
            row["InvoiceId"] = GetFieldValue(data.InvoiceId);
            return row;
        }
    }
}

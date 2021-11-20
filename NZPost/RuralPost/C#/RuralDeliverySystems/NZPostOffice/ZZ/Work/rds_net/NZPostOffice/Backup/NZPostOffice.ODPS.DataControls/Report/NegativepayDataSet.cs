using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RNegativepay
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int REContractNo
        {
            get
            {
                return 0;
            }
        }
        public string CSurnameCompany
        {
            get
            {
                return string.Empty;
            }
        }
        public string CFirstNames
        {
            get
            {
                return string.Empty;
            }
        }
        public string CInitials
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal GrossPay
        {
            get
            {
                return 0;
            }
        }
        public decimal REGrossPay
        {
            get
            {
                return 0;
            }
        }
        public decimal Gst
        {
            get
            {
                return 0;
            }
        }
        public decimal REGst
        {
            get
            {
                return 0;
            }
        }
        public decimal Tax
        {
            get
            {
                return 0;
            }
        }
        public decimal RETax
        {
            get
            {
                return 0;
            }
        }
        public decimal PostTaxAdjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal REPostTaxAdjustments
        {
            get
            {
                return 0;
            }
        }
        public decimal NetPay
        {
            get
            {
                return 0;
            }
        }
        public decimal RENetPay
        {
            get
            {
                return 0;
            }
        }
    }
    public class NegativepayDataSet : ReportDataSet<Negativepay>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn CInitials = new DataColumn("CInitials", typeof(string));

        public DataColumn GrossPay = new DataColumn("GrossPay", typeof(decimal));

        public DataColumn REGrossPay = new DataColumn("REGrossPay", typeof(decimal));

        public DataColumn Gst = new DataColumn("Gst", typeof(decimal));

        public DataColumn REGst = new DataColumn("REGst", typeof(decimal));

        public DataColumn Tax = new DataColumn("Tax", typeof(decimal));

        public DataColumn RETax = new DataColumn("RETax", typeof(decimal));

        public DataColumn PostTaxAdjustments = new DataColumn("PostTaxAdjustments", typeof(decimal));

        public DataColumn REPostTaxAdjustments = new DataColumn("REPostTaxAdjustments", typeof(decimal));

        public DataColumn NetPay = new DataColumn("NetPay", typeof(decimal));

        public DataColumn RENetPay = new DataColumn("RENetPay", typeof(decimal));


        public NegativepayDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,CSurnameCompany,CFirstNames,CInitials,GrossPay,REGrossPay,Gst,REGst,Tax,RETax,PostTaxAdjustments,REPostTaxAdjustments,NetPay,RENetPay
				});
            ContractNo.AllowDBNull = true;
            GrossPay.AllowDBNull = true;
            Gst.AllowDBNull = true;
            Tax.AllowDBNull = true;
            PostTaxAdjustments.AllowDBNull = true;
            NetPay.AllowDBNull = true;

        }

        public NegativepayDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Negativepay> datas = dataSource as Metex.Core.EntityBindingList<Negativepay>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Negativepay data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["CInitials"] = GetFieldValue(data.CInitials);
            row["GrossPay"] = GetFieldValue(data.GrossPay);
            row["REGrossPay"] = GetFieldValue(data.REGrossPay);
            row["Gst"] = GetFieldValue(data.Gst);
            row["REGst"] = GetFieldValue(data.REGst);
            row["Tax"] = GetFieldValue(data.Tax);
            row["RETax"] = GetFieldValue(data.RETax);
            row["PostTaxAdjustments"] = GetFieldValue(data.PostTaxAdjustments);
            row["REPostTaxAdjustments"] = GetFieldValue(data.REPostTaxAdjustments);
            row["NetPay"] = GetFieldValue(data.NetPay);
            row["RENetPay"] = GetFieldValue(data.RENetPay);
            return row;
        }
    }
}

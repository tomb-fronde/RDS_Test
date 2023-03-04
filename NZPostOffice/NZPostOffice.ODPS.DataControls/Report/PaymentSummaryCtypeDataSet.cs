using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RPaymentSummaryCtype
    {
        public string Region
        {
            get
            {
                return string.Empty;
            }
        }
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
        public string Name
        {
            get
            {
                return string.Empty;
            }
        }
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
        public decimal MExtension
        {
            get
            {
                return 0;
            }
        }
        public decimal REMExtension
        {
            get
            {
                return 0;
            }
        }
        public decimal MContractAdjustment
        {
            get
            {
                return 0;
            }
        }
        public decimal REMContractAdjustment
        {
            get
            {
                return 0;
            }
        }
        public decimal MAdpost
        {
            get
            {
                return 0;
            }
        }
        public decimal REMAdpost
        {
            get
            {
                return 0;
            }
        }
        public decimal MCourierpost
        {
            get
            {
                return 0;
            }
        }
        public decimal REMCourierpost
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
        public string ContractType
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal MParcelpost
        {
            get
            {
                return 0;
            }
        }
        public decimal REMParcelpost
        {
            get
            {
                return 0;
            }
        }
        public decimal MSkyroad
        {
            get
            {
                return 0;
            }
        }
        public decimal REMSkyroad
        {
            get
            {
                return 0;
            }
        }
    }
    public class PaymentSummaryCtypeDataSet : ReportDataSet<PaymentSummaryCtype>
    {

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Name = new DataColumn("Name", typeof(string));

        public DataColumn MStandard = new DataColumn("MStandard", typeof(decimal));

        public DataColumn REMStandard = new DataColumn("REMStandard", typeof(decimal));

        public DataColumn MAllowance = new DataColumn("MAllowance", typeof(decimal));

        public DataColumn REMAllowance = new DataColumn("REMAllowance", typeof(decimal));

        public DataColumn MExtension = new DataColumn("MExtension", typeof(decimal));

        public DataColumn REMExtension = new DataColumn("REMExtension", typeof(decimal));

        public DataColumn MContractAdjustment = new DataColumn("MContractAdjustment", typeof(decimal));

        public DataColumn REMContractAdjustment = new DataColumn("REMContractAdjustment", typeof(decimal));

        public DataColumn MAdpost = new DataColumn("MAdpost", typeof(decimal));

        public DataColumn REMAdpost = new DataColumn("REMAdpost", typeof(decimal));

        public DataColumn MCourierpost = new DataColumn("MCourierpost", typeof(decimal));

        public DataColumn REMCourierpost = new DataColumn("REMCourierpost", typeof(decimal));

        public DataColumn MGstValue = new DataColumn("MGstValue", typeof(decimal));

        public DataColumn REMGstValue = new DataColumn("REMGstValue", typeof(decimal));

        public DataColumn MWtaxValue = new DataColumn("MWtaxValue", typeof(decimal));

        public DataColumn REMWtaxValue = new DataColumn("REMWtaxValue", typeof(decimal));

        public DataColumn MAdjNotax = new DataColumn("MAdjNotax", typeof(decimal));

        public DataColumn REMAdjNotax = new DataColumn("REMAdjNotax", typeof(decimal));

        public DataColumn ContractType = new DataColumn("ContractType", typeof(string));

        public DataColumn MParcelpost = new DataColumn("MParcelpost", typeof(decimal));

        public DataColumn REMParcelpost = new DataColumn("REMParcelpost", typeof(decimal));

        public DataColumn MSkyroad = new DataColumn("MSkyroad", typeof(decimal));

        public DataColumn REMSkyroad = new DataColumn("REMSkyroad", typeof(decimal));


        public PaymentSummaryCtypeDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Region,ContractNo,REContractNo,Name,MStandard,REMStandard,MAllowance,REMAllowance,MExtension,REMExtension,MContractAdjustment,REMContractAdjustment,MAdpost,REMAdpost,MCourierpost,REMCourierpost,MGstValue,REMGstValue,MWtaxValue,REMWtaxValue,MAdjNotax,REMAdjNotax,ContractType,MParcelpost,REMParcelpost,MSkyroad,REMSkyroad
				});
            ContractNo.AllowDBNull = true;
            MStandard.AllowDBNull = true;
            MAllowance.AllowDBNull = true;
            MExtension.AllowDBNull = true;
            MContractAdjustment.AllowDBNull = true;
            MAdpost.AllowDBNull = true;
            MCourierpost.AllowDBNull = true;
            MGstValue.AllowDBNull = true;
            MWtaxValue.AllowDBNull = true;
            MAdjNotax.AllowDBNull = true;
            MParcelpost.AllowDBNull = true;
            MSkyroad.AllowDBNull = true;

        }

        public PaymentSummaryCtypeDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PaymentSummaryCtype> datas = dataSource as Metex.Core.EntityBindingList<PaymentSummaryCtype>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(PaymentSummaryCtype data)
        {
            DataRow row = this.NewRow();
            row["Region"] = GetFieldValue(data.Region);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["Name"] = GetFieldValue(data.Name);
            row["MStandard"] = GetFieldValue(data.MStandard);
            row["REMStandard"] = GetFieldValue(data.REMStandard);
            row["MAllowance"] = GetFieldValue(data.MAllowance);
            row["REMAllowance"] = GetFieldValue(data.REMAllowance);
            row["MExtension"] = GetFieldValue(data.MExtension);
            row["REMExtension"] = GetFieldValue(data.REMExtension);
            row["MContractAdjustment"] = GetFieldValue(data.MContractAdjustment);
            row["REMContractAdjustment"] = GetFieldValue(data.REMContractAdjustment);
            row["MAdpost"] = GetFieldValue(data.MAdpost);
            row["REMAdpost"] = GetFieldValue(data.REMAdpost);
            row["MCourierpost"] = GetFieldValue(data.MCourierpost);
            row["REMCourierpost"] = GetFieldValue(data.REMCourierpost);
            row["MGstValue"] = GetFieldValue(data.MGstValue);
            row["REMGstValue"] = GetFieldValue(data.REMGstValue);
            row["MWtaxValue"] = GetFieldValue(data.MWtaxValue);
            row["REMWtaxValue"] = GetFieldValue(data.REMWtaxValue);
            row["MAdjNotax"] = GetFieldValue(data.MAdjNotax);
            row["REMAdjNotax"] = GetFieldValue(data.REMAdjNotax);
            row["ContractType"] = GetFieldValue(data.ContractType);
            row["MParcelpost"] = GetFieldValue(data.MParcelpost);
            row["REMParcelpost"] = GetFieldValue(data.REMParcelpost);
            row["MSkyroad"] = GetFieldValue(data.MSkyroad);
            row["REMSkyroad"] = GetFieldValue(data.REMSkyroad);
            return row;
        }
    }
}

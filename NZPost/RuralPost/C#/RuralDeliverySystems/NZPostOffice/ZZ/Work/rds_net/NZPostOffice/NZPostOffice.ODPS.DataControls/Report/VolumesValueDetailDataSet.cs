using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RVolumesValueDetail
    {
        public string RgnName
        {
            get
            {
                return string.Empty;
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
        public string PrsDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string PrtDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public int PcprVolume
        {
            get
            {
                return 0;
            }
        }
        public int REPcprVolume
        {
            get
            {
                return 0;
            }
        }
        public decimal PcprValue
        {
            get
            {
                return 0;
            }
        }
        public decimal REPcprValue
        {
            get
            {
                return 0;
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
        public string Conttype
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class VolumesValueDetailDataSet : ReportDataSet<VolumesValueDetail>
    {

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn CFirstNames = new DataColumn("CFirstNames", typeof(string));

        public DataColumn PrsDescription = new DataColumn("PrsDescription", typeof(string));

        public DataColumn PrtDescription = new DataColumn("PrtDescription", typeof(string));

        public DataColumn PcprVolume = new DataColumn("PcprVolume", typeof(int));

        public DataColumn REPcprVolume = new DataColumn("REPcprVolume", typeof(int));

        public DataColumn PcprValue = new DataColumn("PcprValue", typeof(decimal));

        public DataColumn REPcprValue = new DataColumn("REPcprValue", typeof(decimal));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Conttype = new DataColumn("Conttype", typeof(string));


        public VolumesValueDetailDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RgnName,CSurnameCompany,CFirstNames,PrsDescription,PrtDescription,PcprVolume,REPcprVolume,PcprValue,REPcprValue,ContractNo,REContractNo,Conttype
				});
            PcprVolume.AllowDBNull = true;
            PcprValue.AllowDBNull = true;
            ContractNo.AllowDBNull = true;

        }

        public VolumesValueDetailDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VolumesValueDetail> datas = dataSource as Metex.Core.EntityBindingList<VolumesValueDetail>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VolumesValueDetail data)
        {
            DataRow row = this.NewRow();
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["CFirstNames"] = GetFieldValue(data.CFirstNames);
            row["PrsDescription"] = GetFieldValue(data.PrsDescription);
            row["PrtDescription"] = GetFieldValue(data.PrtDescription);
            row["PcprVolume"] = GetFieldValue(data.PcprVolume);
            row["REPcprVolume"] = GetFieldValue(data.REPcprVolume);
            row["PcprValue"] = GetFieldValue(data.PcprValue);
            row["REPcprValue"] = GetFieldValue(data.REPcprValue);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["Conttype"] = GetFieldValue(data.Conttype);
            return row;
        }
    }
}

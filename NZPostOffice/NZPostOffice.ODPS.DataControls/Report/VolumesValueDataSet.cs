using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RVolumesValue
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
        public string Region
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
        public decimal Adpostvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal REAdpostvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal Adpostvalue
        {
            get
            {
                return 0;
            }
        }
        public decimal REAdpostvalue
        {
            get
            {
                return 0;
            }
        }
        public decimal Courierpostvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal RECourierpostvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal Courierpostvalue
        {
            get
            {
                return 0;
            }
        }
        public decimal RECourierpostvalue
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
    public class VolumesValueDataSet : ReportDataSet<VolumesValue>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn Adpostvolume = new DataColumn("Adpostvolume", typeof(decimal));

        public DataColumn REAdpostvolume = new DataColumn("REAdpostvolume", typeof(decimal));

        public DataColumn Adpostvalue = new DataColumn("Adpostvalue", typeof(decimal));

        public DataColumn REAdpostvalue = new DataColumn("REAdpostvalue", typeof(decimal));

        public DataColumn Courierpostvolume = new DataColumn("Courierpostvolume", typeof(decimal));

        public DataColumn RECourierpostvolume = new DataColumn("RECourierpostvolume", typeof(decimal));

        public DataColumn Courierpostvalue = new DataColumn("Courierpostvalue", typeof(decimal));

        public DataColumn RECourierpostvalue = new DataColumn("RECourierpostvalue", typeof(decimal));

        public DataColumn Conttype = new DataColumn("Conttype", typeof(string));


        public VolumesValueDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,REContractNo,Region,CSurnameCompany,Adpostvolume,REAdpostvolume,Adpostvalue,REAdpostvalue,Courierpostvolume,RECourierpostvolume,Courierpostvalue,RECourierpostvalue,Conttype
				});
            ContractNo.AllowDBNull = true;
            Adpostvolume.AllowDBNull = true;
            Adpostvalue.AllowDBNull = true;
            Courierpostvolume.AllowDBNull = true;
            Courierpostvalue.AllowDBNull = true;

        }

        public VolumesValueDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VolumesValue> datas = dataSource as Metex.Core.EntityBindingList<VolumesValue>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VolumesValue data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["Region"] = GetFieldValue(data.Region);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["Adpostvolume"] = GetFieldValue(data.Adpostvolume);
            row["REAdpostvolume"] = GetFieldValue(data.REAdpostvolume);
            row["Adpostvalue"] = GetFieldValue(data.Adpostvalue);
            row["REAdpostvalue"] = GetFieldValue(data.REAdpostvalue);
            row["Courierpostvolume"] = GetFieldValue(data.Courierpostvolume);
            row["RECourierpostvolume"] = GetFieldValue(data.RECourierpostvolume);
            row["Courierpostvalue"] = GetFieldValue(data.Courierpostvalue);
            row["RECourierpostvalue"] = GetFieldValue(data.RECourierpostvalue);
            row["Conttype"] = GetFieldValue(data.Conttype);
            return row;
        }
    }
}

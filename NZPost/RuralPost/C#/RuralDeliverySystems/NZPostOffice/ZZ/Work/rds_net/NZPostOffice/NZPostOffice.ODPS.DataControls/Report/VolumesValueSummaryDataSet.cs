using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RVolumesValueSummary
    {
        public int ContractNo
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
        public decimal Adpostvalue
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
        public decimal Courierpostvalue
        {
            get
            {
                return 0;
            }
        }
        public decimal Xpvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal Xpvalue
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
        public decimal Parcelpostvolume
        {
            get
            {
                return 0;
            }
        }
        public decimal Parcelpostvalue
        {
            get
            {
                return 0;
            }
        }
    }
    public class VolumesValueSummaryDataSet : ReportDataSet<VolumesValueSummary>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn CSurnameCompany = new DataColumn("CSurnameCompany", typeof(string));

        public DataColumn Adpostvolume = new DataColumn("Adpostvolume", typeof(decimal));

        public DataColumn Adpostvalue = new DataColumn("Adpostvalue", typeof(decimal));

        public DataColumn Courierpostvolume = new DataColumn("Courierpostvolume", typeof(decimal));

        public DataColumn Courierpostvalue = new DataColumn("Courierpostvalue", typeof(decimal));

        public DataColumn Xpvolume = new DataColumn("Xpvolume", typeof(decimal));

        public DataColumn Xpvalue = new DataColumn("Xpvalue", typeof(decimal));

        public DataColumn Conttype = new DataColumn("Conttype", typeof(string));

        public DataColumn Parcelpostvolume = new DataColumn("Parcelpostvolume", typeof(decimal));

        public DataColumn Parcelpostvalue = new DataColumn("Parcelpostvalue", typeof(decimal));


        public VolumesValueSummaryDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,Region,CSurnameCompany,Adpostvolume,Adpostvalue,Courierpostvolume,Courierpostvalue,Xpvolume,Xpvalue,Conttype,Parcelpostvolume,Parcelpostvalue
				});
            ContractNo.AllowDBNull = true;
            Adpostvolume.AllowDBNull = true;
            Adpostvalue.AllowDBNull = true;
            Courierpostvolume.AllowDBNull = true;
            Courierpostvalue.AllowDBNull = true;
            Xpvolume.AllowDBNull = true;
            Xpvalue.AllowDBNull = true;
            Parcelpostvolume.AllowDBNull = true;
            Parcelpostvalue.AllowDBNull = true;

        }

        public VolumesValueSummaryDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<VolumesValueSummary> datas = dataSource as Metex.Core.EntityBindingList<VolumesValueSummary>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(VolumesValueSummary data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["Region"] = GetFieldValue(data.Region);
            row["CSurnameCompany"] = GetFieldValue(data.CSurnameCompany);
            row["Adpostvolume"] = GetFieldValue(data.Adpostvolume);
            row["Adpostvalue"] = GetFieldValue(data.Adpostvalue);
            row["Courierpostvolume"] = GetFieldValue(data.Courierpostvolume);
            row["Courierpostvalue"] = GetFieldValue(data.Courierpostvalue);
            row["Xpvolume"] = GetFieldValue(data.Xpvolume);
            row["Xpvalue"] = GetFieldValue(data.Xpvalue);
            row["Conttype"] = GetFieldValue(data.Conttype);
            row["Parcelpostvolume"] = GetFieldValue(data.Parcelpostvolume);
            row["Parcelpostvalue"] = GetFieldValue(data.Parcelpostvalue);
            return row;
        }
    }
}

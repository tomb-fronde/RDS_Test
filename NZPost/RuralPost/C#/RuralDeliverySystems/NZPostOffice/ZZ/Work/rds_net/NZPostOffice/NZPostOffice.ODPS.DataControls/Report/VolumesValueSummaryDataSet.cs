using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{
    // TJB  RPCR_059  Jan-2014
    // Added Prs[1-4]name, Prs5name, Prs5volume, Prs5value
    // Changed Adpost..., Courierpost..., Skyroad..., Parcelpost... to Prs[1-4]... 

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
        public string Conttype
        {
            get
            {
                return string.Empty;
            }
        }
        public string Prs1name
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Prs1volume
        {
            get
            {
                return 0;
            }
        }
        public decimal Prs1value
        {
            get
            {
                return 0;
            }
        }
        public string Prs2name
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Prs2volume
        {
            get
            {
                return 0;
            }
        }
        public decimal Prs2value
        {
            get
            {
                return 0;
            }
        }
        public string Prs3name
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Prs3volume
        {
            get
            {
                return 0;
            }
        }
        public decimal Prs3value
        {
            get
            {
                return 0;
            }
        }
        public string Prs4name
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Prs4volume
        {
            get
            {
                return 0;
            }
        }
        public decimal Prs4value
        {
            get
            {
                return 0;
            }
        }
        public string Prs5name
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Prs5volume
        {
            get
            {
                return 0;
            }
        }
        public decimal Prs5value
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

        public DataColumn Conttype = new DataColumn("Conttype", typeof(string));

        public DataColumn Prs1name = new DataColumn("Prs1name", typeof(string));

        public DataColumn Prs1volume = new DataColumn("Prs1volume", typeof(decimal));

        public DataColumn Prs1value = new DataColumn("Prs1value", typeof(decimal));

        public DataColumn Prs2name = new DataColumn("Prs2name", typeof(string));

        public DataColumn Prs2volume = new DataColumn("Prs2volume", typeof(decimal));

        public DataColumn Prs2value = new DataColumn("Prs2value", typeof(decimal));

        public DataColumn Prs3name = new DataColumn("Prs3name", typeof(string));

        public DataColumn Prs3volume = new DataColumn("Prs3volume", typeof(decimal));

        public DataColumn Prs3value = new DataColumn("Prs3value", typeof(decimal));

        public DataColumn Prs4name = new DataColumn("Prs4name", typeof(string));

        public DataColumn Prs4volume = new DataColumn("Prs4volume", typeof(decimal));

        public DataColumn Prs4value = new DataColumn("Prs4value", typeof(decimal));

        public DataColumn Prs5name = new DataColumn("Prs5name", typeof(string));

        public DataColumn Prs5volume = new DataColumn("Prs5volume", typeof(decimal));

        public DataColumn Prs5value = new DataColumn("Prs5value", typeof(decimal));

        public VolumesValueSummaryDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,Region,CSurnameCompany,Conttype,
                Prs1name,Prs1volume,Prs1value,
                Prs2name,Prs2volume,Prs2value,
                Prs3name,Prs3volume,Prs3value,
                Prs4name,Prs4volume,Prs4value,
                Prs5name,Prs5volume,Prs5value,
				});
            ContractNo.AllowDBNull = true;
            Prs1name.AllowDBNull = true;
            Prs1volume.AllowDBNull = true;
            Prs1value.AllowDBNull = true;
            Prs2name.AllowDBNull = true;
            Prs2volume.AllowDBNull = true;
            Prs2value.AllowDBNull = true;
            Prs3name.AllowDBNull = true;
            Prs3volume.AllowDBNull = true;
            Prs3value.AllowDBNull = true;
            Prs4name.AllowDBNull = true;
            Prs4volume.AllowDBNull = true;
            Prs4value.AllowDBNull = true;
            Prs5name.AllowDBNull = true;
            Prs5volume.AllowDBNull = true;
            Prs5value.AllowDBNull = true;
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
            row["Conttype"] = GetFieldValue(data.Conttype);
            row["Prs1name"] = GetFieldValue(data.Prs1name);
            row["Prs1volume"] = GetFieldValue(data.Prs1volume);
            row["Prs1value"] = GetFieldValue(data.Prs1value);
            row["Prs2name"] = GetFieldValue(data.Prs2name);
            row["Prs2volume"] = GetFieldValue(data.Prs2volume);
            row["Prs2value"] = GetFieldValue(data.Prs2value);
            row["Prs3name"] = GetFieldValue(data.Prs3name);
            row["Prs3volume"] = GetFieldValue(data.Prs3volume);
            row["Prs3value"] = GetFieldValue(data.Prs3value);
            row["Prs4name"] = GetFieldValue(data.Prs4name);
            row["Prs4volume"] = GetFieldValue(data.Prs4volume);
            row["Prs4value"] = GetFieldValue(data.Prs4value);
            row["Prs5name"] = GetFieldValue(data.Prs5name);
            row["Prs5volume"] = GetFieldValue(data.Prs5volume);
            row["Prs5value"] = GetFieldValue(data.Prs5value);
            return row;
        }
    }
}

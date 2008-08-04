using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryVolume
    {
        public int Sortorder
        {
            get
            {
                return 0;
            }
        }
        public string Description
        {
            get
            {
                return string.Empty;
            }
        }
        public string Dispdecs
        {
            get
            {
                return string.Empty;
            }
        }
        public string Displine
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal MediumEnv
        {
            get
            {
                return 0;
            }
        }
        public decimal OtherEnv
        {
            get
            {
                return 0;
            }
        }
        public decimal SmallPar
        {
            get
            {
                return 0;
            }
        }
        public decimal LargePar
        {
            get
            {
                return 0;
            }
        }
        public decimal TotalVol
        {
            get
            {
                return 0;
            }
        }
    }
    public class ContractSummaryVolumeDataSet : ReportDataSet<ContractSummaryVolume>
    {

        public DataColumn Sortorder = new DataColumn("Sortorder", typeof(int));

        public DataColumn Description = new DataColumn("Description", typeof(string));

        public DataColumn Dispdecs = new DataColumn("Dispdecs", typeof(string));

        public DataColumn Displine = new DataColumn("Displine", typeof(string));

        public DataColumn MediumEnv = new DataColumn("MediumEnv", typeof(decimal));

        public DataColumn OtherEnv = new DataColumn("OtherEnv", typeof(decimal));

        public DataColumn SmallPar = new DataColumn("SmallPar", typeof(decimal));

        public DataColumn LargePar = new DataColumn("LargePar", typeof(decimal));

        public DataColumn TotalVol = new DataColumn("TotalVol", typeof(decimal));


        public ContractSummaryVolumeDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Sortorder,Description,Dispdecs,Displine,MediumEnv,OtherEnv,SmallPar,LargePar,TotalVol
				});
            Sortorder.AllowDBNull = true;
            MediumEnv.AllowDBNull = true;
            OtherEnv.AllowDBNull = true;
            SmallPar.AllowDBNull = true;
            LargePar.AllowDBNull = true;
            TotalVol.AllowDBNull = true;

        }

        public ContractSummaryVolumeDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryVolume> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryVolume>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryVolumeDataSet(ContractSummaryVolume obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryVolume> list = new Metex.Core.EntityBindingList<ContractSummaryVolume>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryVolumeDataSet(ContractSummaryVolume[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryVolume> list = new Metex.Core.EntityBindingList<ContractSummaryVolume>();
            foreach (ContractSummaryVolume d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryVolume data)
        {
            DataRow row = this.NewRow();
            row["Sortorder"] = GetFieldValue(data.Sortorder);
            row["Description"] = GetFieldValue(data.Description);
            row["Dispdecs"] = GetFieldValue(data.Dispdecs);
            row["Displine"] = GetFieldValue(data.Displine);
            row["MediumEnv"] = GetFieldValue(data.MediumEnv);
            row["OtherEnv"] = GetFieldValue(data.OtherEnv);
            row["SmallPar"] = GetFieldValue(data.SmallPar);
            row["LargePar"] = GetFieldValue(data.LargePar);
            row["TotalVol"] = GetFieldValue(data.TotalVol);
            return row;
        }
    }
}

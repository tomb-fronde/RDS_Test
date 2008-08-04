using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryPieceRates
    {
        public string PrsDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Mo1
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo2
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo3
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo4
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo5
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo6
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo7
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo8
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo9
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo10
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo11
        {
            get
            {
                return 0;
            }
        }
        public decimal Mo12
        {
            get
            {
                return 0;
            }
        }
    }
    public class ContractSummaryPieceRatesDataSet : ReportDataSet<ContractSummaryPieceRates>
    {

        public DataColumn PrsDescription = new DataColumn("PrsDescription", typeof(string));

        public DataColumn Mo1 = new DataColumn("Mo1", typeof(decimal));

        public DataColumn Mo2 = new DataColumn("Mo2", typeof(decimal));

        public DataColumn Mo3 = new DataColumn("Mo3", typeof(decimal));

        public DataColumn Mo4 = new DataColumn("Mo4", typeof(decimal));

        public DataColumn Mo5 = new DataColumn("Mo5", typeof(decimal));

        public DataColumn Mo6 = new DataColumn("Mo6", typeof(decimal));

        public DataColumn Mo7 = new DataColumn("Mo7", typeof(decimal));

        public DataColumn Mo8 = new DataColumn("Mo8", typeof(decimal));

        public DataColumn Mo9 = new DataColumn("Mo9", typeof(decimal));

        public DataColumn Mo10 = new DataColumn("Mo10", typeof(decimal));

        public DataColumn Mo11 = new DataColumn("Mo11", typeof(decimal));

        public DataColumn Mo12 = new DataColumn("Mo12", typeof(decimal));


        public ContractSummaryPieceRatesDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				PrsDescription,Mo1,Mo2,Mo3,Mo4,Mo5,Mo6,Mo7,Mo8,Mo9,Mo10,Mo11,Mo12
				});
            Mo1.AllowDBNull = true;
            Mo2.AllowDBNull = true;
            Mo3.AllowDBNull = true;
            Mo4.AllowDBNull = true;
            Mo5.AllowDBNull = true;
            Mo6.AllowDBNull = true;
            Mo7.AllowDBNull = true;
            Mo8.AllowDBNull = true;
            Mo9.AllowDBNull = true;
            Mo10.AllowDBNull = true;
            Mo11.AllowDBNull = true;
            Mo12.AllowDBNull = true;

        }

        public ContractSummaryPieceRatesDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryPieceRates> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryPieceRates>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryPieceRatesDataSet(ContractSummaryPieceRates obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryPieceRates> list = new Metex.Core.EntityBindingList<ContractSummaryPieceRates>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryPieceRatesDataSet(ContractSummaryPieceRates[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryPieceRates> list = new Metex.Core.EntityBindingList<ContractSummaryPieceRates>();
            foreach (ContractSummaryPieceRates d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryPieceRates data)
        {
            DataRow row = this.NewRow();
            row["PrsDescription"] = GetFieldValue(data.PrsDescription);
            row["Mo1"] = GetFieldValue(data.Mo1);
            row["Mo2"] = GetFieldValue(data.Mo2);
            row["Mo3"] = GetFieldValue(data.Mo3);
            row["Mo4"] = GetFieldValue(data.Mo4);
            row["Mo5"] = GetFieldValue(data.Mo5);
            row["Mo6"] = GetFieldValue(data.Mo6);
            row["Mo7"] = GetFieldValue(data.Mo7);
            row["Mo8"] = GetFieldValue(data.Mo8);
            row["Mo9"] = GetFieldValue(data.Mo9);
            row["Mo10"] = GetFieldValue(data.Mo10);
            row["Mo11"] = GetFieldValue(data.Mo11);
            row["Mo12"] = GetFieldValue(data.Mo12);
            return row;
        }
    }
}

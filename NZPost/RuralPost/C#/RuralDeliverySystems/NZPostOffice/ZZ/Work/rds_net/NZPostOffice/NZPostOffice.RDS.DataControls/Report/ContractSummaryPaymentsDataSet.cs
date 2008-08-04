using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryPayments
    {
        public decimal Camount
        {
            get
            {
                return 0;
            }
        }
        public string Ctype
        {
            get
            {
                return string.Empty;
            }
        }
        public int CSort
        {
            get
            {
                return 0;
            }
        }
    }
    public class ContractSummaryPaymentsDataSet : ReportDataSet<ContractSummaryPayments>
    {

        public DataColumn Camount = new DataColumn("Camount", typeof(decimal));

        public DataColumn Ctype = new DataColumn("Ctype", typeof(string));

        public DataColumn CSort = new DataColumn("CSort", typeof(int));


        public ContractSummaryPaymentsDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Camount,Ctype,CSort
				});
            Camount.AllowDBNull = true;
            CSort.AllowDBNull = true;

        }

        public ContractSummaryPaymentsDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryPayments> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryPayments>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryPaymentsDataSet(ContractSummaryPayments obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryPayments> list = new Metex.Core.EntityBindingList<ContractSummaryPayments>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryPaymentsDataSet(ContractSummaryPayments[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryPayments> list = new Metex.Core.EntityBindingList<ContractSummaryPayments>();
            foreach (ContractSummaryPayments d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryPayments data)
        {
            DataRow row = this.NewRow();
            row["Camount"] = GetFieldValue(data.Camount);
            row["Ctype"] = GetFieldValue(data.Ctype);
            row["CSort"] = GetFieldValue(data.CSort);
            return row;
        }
    }
}

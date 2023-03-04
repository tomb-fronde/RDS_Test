using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryOwnerDriver
    {
        public string Surname
        {
            get
            {
                return string.Empty;
            }
        }
        public string Firstname
        {
            get
            {
                return string.Empty;
            }
        }
        public string Address
        {
            get
            {
                return string.Empty;
            }
        }
        public string Nightphone
        {
            get
            {
                return string.Empty;
            }
        }
        public string Dayphone
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class ContractSummaryOwnerDriverDataSet : ReportDataSet<ContractSummaryOwnerDriver>
    {

        public DataColumn Surname = new DataColumn("Surname", typeof(string));

        public DataColumn Firstname = new DataColumn("Firstname", typeof(string));

        public DataColumn Address = new DataColumn("Address", typeof(string));

        public DataColumn Nightphone = new DataColumn("Nightphone", typeof(string));

        public DataColumn Dayphone = new DataColumn("Dayphone", typeof(string));


        public ContractSummaryOwnerDriverDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Surname,Firstname,Address,Nightphone,Dayphone
				});

        }

        public ContractSummaryOwnerDriverDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryOwnerDriver> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryOwnerDriver>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryOwnerDriverDataSet(ContractSummaryOwnerDriver obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryOwnerDriver> list = new Metex.Core.EntityBindingList<ContractSummaryOwnerDriver>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryOwnerDriverDataSet(ContractSummaryOwnerDriver[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryOwnerDriver> list = new Metex.Core.EntityBindingList<ContractSummaryOwnerDriver>();
            foreach (ContractSummaryOwnerDriver d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryOwnerDriver data)
        {
            DataRow row = this.NewRow();
            row["Surname"] = GetFieldValue(data.Surname);
            row["Firstname"] = GetFieldValue(data.Firstname);
            row["Address"] = GetFieldValue(data.Address);
            row["Nightphone"] = GetFieldValue(data.Nightphone);
            row["Dayphone"] = GetFieldValue(data.Dayphone);
            return row;
        }
    }
}

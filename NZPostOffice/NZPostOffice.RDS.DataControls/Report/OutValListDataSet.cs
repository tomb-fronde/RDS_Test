using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class ROutValList
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
        public string OwnerDriver
        {
            get
            {
                return string.Empty;
            }
        }
        public string DayPhone
        {
            get
            {
                return string.Empty;
            }
        }
        public string NightPhone
        {
            get
            {
                return string.Empty;
            }
        }
        public string CellPhone
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime ListPrinted
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REListPrinted
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime ListUpdated
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime REListUpdated
        {
            get
            {
                return DateTime.MinValue;
            }
        }
    }
    public class OutValListDataSet : ReportDataSet<OutValList>
    {

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn OwnerDriver = new DataColumn("OwnerDriver", typeof(string));

        public DataColumn DayPhone = new DataColumn("DayPhone", typeof(string));

        public DataColumn NightPhone = new DataColumn("NightPhone", typeof(string));

        public DataColumn CellPhone = new DataColumn("CellPhone", typeof(string));

        public DataColumn ListPrinted = new DataColumn("ListPrinted", typeof(DateTime));

        public DataColumn REListPrinted = new DataColumn("REListPrinted", typeof(DateTime));

        public DataColumn ListUpdated = new DataColumn("ListUpdated", typeof(DateTime));

        public DataColumn REListUpdated = new DataColumn("REListUpdated", typeof(DateTime));


        public OutValListDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Region,ContractNo,REContractNo,OwnerDriver,DayPhone,NightPhone,CellPhone,ListPrinted,REListPrinted,ListUpdated,REListUpdated
				});
            ContractNo.AllowDBNull = true;
            REContractNo.AllowDBNull = true;
            ListPrinted.AllowDBNull = true;
            REListPrinted.AllowDBNull = true;
            ListUpdated.AllowDBNull = true;
            REListUpdated.AllowDBNull = true;

        }

        public OutValListDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<OutValList> datas = dataSource as Metex.Core.EntityBindingList<OutValList>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(OutValList data)
        {
            DataRow row = this.NewRow();
            row["Region"] = GetFieldValue(data.Region);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["OwnerDriver"] = GetFieldValue(data.OwnerDriver);
            row["DayPhone"] = GetFieldValue(data.DayPhone);
            row["NightPhone"] = GetFieldValue(data.NightPhone);
            row["CellPhone"] = GetFieldValue(data.CellPhone);
            row["ListPrinted"] = GetFieldValue(data.ListPrinted);
            row["REListPrinted"] = GetFieldValue(data.REListPrinted);
            row["ListUpdated"] = GetFieldValue(data.ListUpdated);
            row["REListUpdated"] = GetFieldValue(data.REListUpdated);
            return row;
        }
    }
}

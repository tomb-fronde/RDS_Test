using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.RDS.Entity.Ruralrpt;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RAllowanceDetail
    {
        public string RgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string AllowanceTypeAltDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractAllowanceCaAnnualAmount
        {
            get
            {
                return 0;
            }
        }
    }
    public class AllowanceDetailDataSet : ReportDataSet<AllowanceDetail>
    {

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn AllowanceTypeAltDescription = new DataColumn("AllowanceTypeAltDescription", typeof(string));

        public DataColumn ContractAllowanceCaAnnualAmount = new DataColumn("ContractAllowanceCaAnnualAmount", typeof(decimal));


        public AllowanceDetailDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RgnName,AllowanceTypeAltDescription,ContractAllowanceCaAnnualAmount
				});
            ContractAllowanceCaAnnualAmount.AllowDBNull = true;

        }

        public AllowanceDetailDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<AllowanceDetail> datas = dataSource as Metex.Core.EntityBindingList<AllowanceDetail>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public AllowanceDetailDataSet(AllowanceDetail obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<AllowanceDetail> list = new Metex.Core.EntityBindingList<AllowanceDetail>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public AllowanceDetailDataSet(AllowanceDetail[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<AllowanceDetail> list = new Metex.Core.EntityBindingList<AllowanceDetail>();
            foreach(AllowanceDetail d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(AllowanceDetail data)
        {
            DataRow row = this.NewRow();
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["AllowanceTypeAltDescription"] = GetFieldValue(data.AllowanceTypeAltDescription);
            row["ContractAllowanceCaAnnualAmount"] = GetFieldValue(data.ContractAllowanceCaAnnualAmount);
            return row;
        }
    }
}

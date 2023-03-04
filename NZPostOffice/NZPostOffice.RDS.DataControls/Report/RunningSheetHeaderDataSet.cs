using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RRunningSheetHeader
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string ConOldMailServiceNo
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string RouteDescriptionRdDescriptionOfPoin
        {
            get
            {
                return string.Empty;
            }
        }
        public int RouteDescriptionRDSequence
        {
            get
            {
                return 0;
            }
        }
        public string AddressName
        {
            get
            {
                return string.Empty;
            }
        }
        public string Description
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class RunningSheetHeaderDataSet : ReportDataSet<RunningSheetHeader>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ConOldMailServiceNo = new DataColumn("ConOldMailServiceNo", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn RouteDescriptionRdDescriptionOfPoin = new DataColumn("RouteDescriptionRdDescriptionOfPoin", typeof(string));

        public DataColumn RouteDescriptionRDSequence = new DataColumn("RouteDescriptionRDSequence", typeof(int));

        public DataColumn AddressName = new DataColumn("AddressName", typeof(string));

        public DataColumn Description = new DataColumn("Description", typeof(string));


        public RunningSheetHeaderDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,ConOldMailServiceNo,ConTitle,RouteDescriptionRdDescriptionOfPoin,RouteDescriptionRDSequence,AddressName,Description
				});
            ContractNo.AllowDBNull = true;
            RouteDescriptionRDSequence.AllowDBNull = true;

        }

        public RunningSheetHeaderDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<RunningSheetHeader> datas = dataSource as Metex.Core.EntityBindingList<RunningSheetHeader>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(RunningSheetHeader data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ConOldMailServiceNo"] = GetFieldValue(data.ConOldMailServiceNo);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["RouteDescriptionRdDescriptionOfPoin"] = GetFieldValue(data.RouteDescriptionRdDescriptionOfPoin);
            row["RouteDescriptionRDSequence"] = GetFieldValue(data.RouteDescriptionRDSequence);
            row["AddressName"] = GetFieldValue(data.AddressName);
            row["Description"] = GetFieldValue(data.Description);
            return row;
        }
    }
}

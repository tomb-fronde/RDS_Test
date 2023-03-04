using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustOccupationStat
    {
        public string Region
        {
            get
            {
                return string.Empty;
            }
        }
        public string Interest
        {
            get
            {
                return string.Empty;
            }
        }
        public int Interestcount
        {
            get
            {
                return 0;
            }
        }
        public int REInterestcount
        {
            get
            {
                return 0;
            }
        }
    }
    public class CustOccupationStatDataSet : ReportDataSet<CustOccupationStat>
    {

        public DataColumn Region = new DataColumn("Region", typeof(string));

        public DataColumn Interest = new DataColumn("Interest", typeof(string));

        public DataColumn Interestcount = new DataColumn("Interestcount", typeof(int));

        public DataColumn REInterestcount = new DataColumn("REInterestcount", typeof(int));


        public CustOccupationStatDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				Region,Interest,Interestcount,REInterestcount
				});
            Interestcount.AllowDBNull = true;
            REInterestcount.AllowDBNull = true;

        }

        public CustOccupationStatDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustOccupationStat> datas = dataSource as Metex.Core.EntityBindingList<CustOccupationStat>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustOccupationStat data)
        {
            DataRow row = this.NewRow();
            row["Region"] = GetFieldValue(data.Region);
            row["Interest"] = GetFieldValue(data.Interest);
            row["Interestcount"] = GetFieldValue(data.Interestcount);
            row["REInterestcount"] = GetFieldValue(data.REInterestcount);
            return row;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RBenchmarkReportFrequencies
    {
        public string StandardFrequencySfDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string RouteFrequencyRfDeliveryDays
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal RouteFrequencyRfDistance
        {
            get
            {
                return 0;
            }
        }
    }
    public class BenchmarkReportFrequenciesDataSet : ReportDataSet<BenchmarkReportFrequencies>
    {

        public DataColumn StandardFrequencySfDescription = new DataColumn("StandardFrequencySfDescription", typeof(string));

        public DataColumn RouteFrequencyRfDeliveryDays = new DataColumn("RouteFrequencyRfDeliveryDays", typeof(string));

        public DataColumn RouteFrequencyRfDistance = new DataColumn("RouteFrequencyRfDistance", typeof(decimal));


        public BenchmarkReportFrequenciesDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				StandardFrequencySfDescription,RouteFrequencyRfDeliveryDays,RouteFrequencyRfDistance
				});
            RouteFrequencyRfDistance.AllowDBNull = true;

        }

        public BenchmarkReportFrequenciesDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<BenchmarkReportFrequencies> datas = dataSource as Metex.Core.EntityBindingList<BenchmarkReportFrequencies>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public BenchmarkReportFrequenciesDataSet(BenchmarkReportFrequencies obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<BenchmarkReportFrequencies> list = new Metex.Core.EntityBindingList<BenchmarkReportFrequencies>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public BenchmarkReportFrequenciesDataSet(BenchmarkReportFrequencies[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<BenchmarkReportFrequencies> list = new Metex.Core.EntityBindingList<BenchmarkReportFrequencies>();
            foreach (BenchmarkReportFrequencies d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(BenchmarkReportFrequencies data)
        {
            DataRow row = this.NewRow();
            row["StandardFrequencySfDescription"] = GetFieldValue(data.StandardFrequencySfDescription);
            row["RouteFrequencyRfDeliveryDays"] = GetFieldValue(data.RouteFrequencyRfDeliveryDays);
            row["RouteFrequencyRfDistance"] = GetFieldValue(data.RouteFrequencyRfDistance);
            return row;
        }
    }
}

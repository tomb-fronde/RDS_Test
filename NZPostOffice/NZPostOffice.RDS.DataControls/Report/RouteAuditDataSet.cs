using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RRouteAudit
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int RaDayOfCheck
        {
            get
            {
                return 0;
            }
        }
        public DateTime RaDateOfCheck
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeStartedSort
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeFinishedSort
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeLeftBase
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeReturned
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaTimeDeparted
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal RaFinishOdometer
        {
            get
            {
                return 0;
            }
        }
        public decimal RaStartOdometer
        {
            get
            {
                return 0;
            }
        }
        public DateTime RaMealBreaks
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaExtraTime
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal RaExtraDistance
        {
            get
            {
                return 0;
            }
        }
        public DateTime RaOthrGdsBefore
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaOthrGdsDuring
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaOthrGdsAfter
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaPrBefore
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaPrDuring
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime RaPrAfter
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public double Delseconds
        {
            get
            {
                return 0;
            }
        }
        public TimeSpan Compute1
        {
            get
            {
                return TimeSpan.MinValue;
            }
        }
    }
    public class RouteAuditDataSet : ReportDataSet<RouteAudit>
    {

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn RaDayOfCheck = new DataColumn("RaDayOfCheck", typeof(int));

        public DataColumn RaDateOfCheck = new DataColumn("RaDateOfCheck", typeof(DateTime));

        public DataColumn RaTimeStartedSort = new DataColumn("RaTimeStartedSort", typeof(DateTime));

        public DataColumn RaTimeFinishedSort = new DataColumn("RaTimeFinishedSort", typeof(DateTime));

        public DataColumn RaTimeLeftBase = new DataColumn("RaTimeLeftBase", typeof(DateTime));

        public DataColumn RaTimeReturned = new DataColumn("RaTimeReturned", typeof(DateTime));

        public DataColumn RaTimeDeparted = new DataColumn("RaTimeDeparted", typeof(DateTime));

        public DataColumn RaFinishOdometer = new DataColumn("RaFinishOdometer", typeof(decimal));

        public DataColumn RaStartOdometer = new DataColumn("RaStartOdometer", typeof(decimal));

        public DataColumn RaMealBreaks = new DataColumn("RaMealBreaks", typeof(DateTime));

        public DataColumn RaExtraTime = new DataColumn("RaExtraTime", typeof(DateTime));

        public DataColumn RaExtraDistance = new DataColumn("RaExtraDistance", typeof(decimal));

        public DataColumn RaOthrGdsBefore = new DataColumn("RaOthrGdsBefore", typeof(DateTime));

        public DataColumn RaOthrGdsDuring = new DataColumn("RaOthrGdsDuring", typeof(DateTime));

        public DataColumn RaOthrGdsAfter = new DataColumn("RaOthrGdsAfter", typeof(DateTime));

        public DataColumn RaPrBefore = new DataColumn("RaPrBefore", typeof(DateTime));

        public DataColumn RaPrDuring = new DataColumn("RaPrDuring", typeof(DateTime));

        public DataColumn RaPrAfter = new DataColumn("RaPrAfter", typeof(DateTime));

        public DataColumn Delseconds = new DataColumn("Delseconds", typeof(double));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(TimeSpan));


        public RouteAuditDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				ContractNo,RaDayOfCheck,RaDateOfCheck,RaTimeStartedSort,RaTimeFinishedSort,RaTimeLeftBase,RaTimeReturned,RaTimeDeparted,RaFinishOdometer,RaStartOdometer,RaMealBreaks,RaExtraTime,RaExtraDistance,RaOthrGdsBefore,RaOthrGdsDuring,RaOthrGdsAfter,RaPrBefore,RaPrDuring,RaPrAfter,Delseconds,Compute1
				});
            ContractNo.AllowDBNull = true;
            RaDayOfCheck.AllowDBNull = true;
            RaDateOfCheck.AllowDBNull = true;
            RaTimeStartedSort.AllowDBNull = true;
            RaTimeFinishedSort.AllowDBNull = true;
            RaTimeLeftBase.AllowDBNull = true;
            RaTimeReturned.AllowDBNull = true;
            RaTimeDeparted.AllowDBNull = true;
            RaFinishOdometer.AllowDBNull = true;
            RaStartOdometer.AllowDBNull = true;
            RaMealBreaks.AllowDBNull = true;
            RaExtraTime.AllowDBNull = true;
            RaExtraDistance.AllowDBNull = true;
            RaOthrGdsBefore.AllowDBNull = true;
            RaOthrGdsDuring.AllowDBNull = true;
            RaOthrGdsAfter.AllowDBNull = true;
            RaPrBefore.AllowDBNull = true;
            RaPrDuring.AllowDBNull = true;
            RaPrAfter.AllowDBNull = true;
            Delseconds.AllowDBNull = true;

        }

        public RouteAuditDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<RouteAudit> datas = dataSource as Metex.Core.EntityBindingList<RouteAudit>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(RouteAudit data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["RaDayOfCheck"] = GetFieldValue(data.RaDayOfCheck);
            row["RaDateOfCheck"] = GetFieldValue(data.RaDateOfCheck);
            row["RaTimeStartedSort"] = GetFieldValue(data.RaTimeStartedSort);
            row["RaTimeFinishedSort"] = GetFieldValue(data.RaTimeFinishedSort);
            row["RaTimeLeftBase"] = GetFieldValue(data.RaTimeLeftBase);
            row["RaTimeReturned"] = GetFieldValue(data.RaTimeReturned);
            row["RaTimeDeparted"] = GetFieldValue(data.RaTimeDeparted);
            row["RaFinishOdometer"] = GetFieldValue(data.RaFinishOdometer);
            row["RaStartOdometer"] = GetFieldValue(data.RaStartOdometer);
            row["RaMealBreaks"] = GetFieldValue(data.RaMealBreaks);
            row["RaExtraTime"] = GetFieldValue(data.RaExtraTime);
            row["RaExtraDistance"] = GetFieldValue(data.RaExtraDistance);
            row["RaOthrGdsBefore"] = GetFieldValue(data.RaOthrGdsBefore);
            row["RaOthrGdsDuring"] = GetFieldValue(data.RaOthrGdsDuring);
            row["RaOthrGdsAfter"] = GetFieldValue(data.RaOthrGdsAfter);
            row["RaPrBefore"] = GetFieldValue(data.RaPrBefore);
            row["RaPrDuring"] = GetFieldValue(data.RaPrDuring);
            row["RaPrAfter"] = GetFieldValue(data.RaPrAfter);
            row["Delseconds"] = GetFieldValue(data.Delseconds);
            row["Compute1"] = GetFieldValue(data.Compute1);
            return row;
        }
    }
}

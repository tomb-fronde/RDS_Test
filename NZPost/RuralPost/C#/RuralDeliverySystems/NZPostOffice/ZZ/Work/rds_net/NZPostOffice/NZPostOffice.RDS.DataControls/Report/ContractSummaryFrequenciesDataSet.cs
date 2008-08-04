using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RContractSummaryFrequencies
    {
        public int SfKey
        {
            get
            {
                return 0;
            }
        }
        public string SfDescription
        {
            get
            {
                return string.Empty;
            }
        }
        public string RfDeliveryDays
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal RfDistance
        {
            get
            {
                return 0;
            }
        }
        public DateTime FdEffectiveDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal FdDistance
        {
            get
            {
                return 0;
            }
        }
        public int FdNoOfBoxes
        {
            get
            {
                return 0;
            }
        }
        public int FdNoRuralBags
        {
            get
            {
                return 0;
            }
        }
        public int FdNoOtherBags
        {
            get
            {
                return 0;
            }
        }
        public int FdNoPrivateBags
        {
            get
            {
                return 0;
            }
        }
        public int FdNoPostOffices
        {
            get
            {
                return 0;
            }
        }
        public int FdNoCmbs
        {
            get
            {
                return 0;
            }
        }
        public int FdNoCmbCustomers
        {
            get
            {
                return 0;
            }
        }
        public int FdVolume
        {
            get
            {
                return 0;
            }
        }
        public decimal FdDeliveryHrsPerWeek
        {
            get
            {
                return 0;
            }
        }
        public decimal FdProcessingHrsWeek
        {
            get
            {
                return 0;
            }
        }
        public int RtdDaysPerAnnum
        {
            get
            {
                return 0;
            }
        }
    }
    public class ContractSummaryFrequenciesDataSet : ReportDataSet<ContractSummaryFrequencies>
    {

        public DataColumn SfKey = new DataColumn("SfKey", typeof(int));

        public DataColumn SfDescription = new DataColumn("SfDescription", typeof(string));

        public DataColumn RfDeliveryDays = new DataColumn("RfDeliveryDays", typeof(string));

        public DataColumn RfDistance = new DataColumn("RfDistance", typeof(decimal));

        public DataColumn FdEffectiveDate = new DataColumn("FdEffectiveDate", typeof(DateTime));

        public DataColumn FdDistance = new DataColumn("FdDistance", typeof(decimal));

        public DataColumn FdNoOfBoxes = new DataColumn("FdNoOfBoxes", typeof(int));

        public DataColumn FdNoRuralBags = new DataColumn("FdNoRuralBags", typeof(int));

        public DataColumn FdNoOtherBags = new DataColumn("FdNoOtherBags", typeof(int));

        public DataColumn FdNoPrivateBags = new DataColumn("FdNoPrivateBags", typeof(int));

        public DataColumn FdNoPostOffices = new DataColumn("FdNoPostOffices", typeof(int));

        public DataColumn FdNoCmbs = new DataColumn("FdNoCmbs", typeof(int));

        public DataColumn FdNoCmbCustomers = new DataColumn("FdNoCmbCustomers", typeof(int));

        public DataColumn FdVolume = new DataColumn("FdVolume", typeof(int));

        public DataColumn FdDeliveryHrsPerWeek = new DataColumn("FdDeliveryHrsPerWeek", typeof(decimal));

        public DataColumn FdProcessingHrsWeek = new DataColumn("FdProcessingHrsWeek", typeof(decimal));

        public DataColumn RtdDaysPerAnnum = new DataColumn("RtdDaysPerAnnum", typeof(int));


        public ContractSummaryFrequenciesDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				SfKey,SfDescription,RfDeliveryDays,RfDistance,FdEffectiveDate,FdDistance,FdNoOfBoxes,FdNoRuralBags,FdNoOtherBags,FdNoPrivateBags,FdNoPostOffices,FdNoCmbs,FdNoCmbCustomers,FdVolume,FdDeliveryHrsPerWeek,FdProcessingHrsWeek,RtdDaysPerAnnum
				});
            SfKey.AllowDBNull = true;
            RfDistance.AllowDBNull = true;
            FdEffectiveDate.AllowDBNull = true;
            FdDistance.AllowDBNull = true;
            FdNoOfBoxes.AllowDBNull = true;
            FdNoRuralBags.AllowDBNull = true;
            FdNoOtherBags.AllowDBNull = true;
            FdNoPrivateBags.AllowDBNull = true;
            FdNoPostOffices.AllowDBNull = true;
            FdNoCmbs.AllowDBNull = true;
            FdNoCmbCustomers.AllowDBNull = true;
            FdVolume.AllowDBNull = true;
            FdDeliveryHrsPerWeek.AllowDBNull = true;
            FdProcessingHrsWeek.AllowDBNull = true;
            RtdDaysPerAnnum.AllowDBNull = true;

        }

        public ContractSummaryFrequenciesDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryFrequencies> datas = dataSource as Metex.Core.EntityBindingList<ContractSummaryFrequencies>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public ContractSummaryFrequenciesDataSet(ContractSummaryFrequencies obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<ContractSummaryFrequencies> list = new Metex.Core.EntityBindingList<ContractSummaryFrequencies>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public ContractSummaryFrequenciesDataSet(ContractSummaryFrequencies[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<ContractSummaryFrequencies> list = new Metex.Core.EntityBindingList<ContractSummaryFrequencies>();
            foreach (ContractSummaryFrequencies d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(ContractSummaryFrequencies data)
        {
            DataRow row = this.NewRow();
            row["SfKey"] = GetFieldValue(data.SfKey);
            row["SfDescription"] = GetFieldValue(data.SfDescription);
            row["RfDeliveryDays"] = GetFieldValue(data.RfDeliveryDays);
            row["RfDistance"] = GetFieldValue(data.RfDistance);
            row["FdEffectiveDate"] = GetFieldValue(data.FdEffectiveDate);
            row["FdDistance"] = GetFieldValue(data.FdDistance);
            row["FdNoOfBoxes"] = GetFieldValue(data.FdNoOfBoxes);
            row["FdNoRuralBags"] = GetFieldValue(data.FdNoRuralBags);
            row["FdNoOtherBags"] = GetFieldValue(data.FdNoOtherBags);
            row["FdNoPrivateBags"] = GetFieldValue(data.FdNoPrivateBags);
            row["FdNoPostOffices"] = GetFieldValue(data.FdNoPostOffices);
            row["FdNoCmbs"] = GetFieldValue(data.FdNoCmbs);
            row["FdNoCmbCustomers"] = GetFieldValue(data.FdNoCmbCustomers);
            row["FdVolume"] = GetFieldValue(data.FdVolume);
            row["FdDeliveryHrsPerWeek"] = GetFieldValue(data.FdDeliveryHrsPerWeek);
            row["FdProcessingHrsWeek"] = GetFieldValue(data.FdProcessingHrsWeek);
            row["RtdDaysPerAnnum"] = GetFieldValue(data.RtdDaysPerAnnum);
            return row;
        }
    }
}

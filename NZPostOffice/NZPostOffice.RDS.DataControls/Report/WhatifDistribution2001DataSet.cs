using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Report
{

    public class RWhatifDistribution2001
    {
        public double From
        {
            get
            {
                return 0;
            }
        }
        public double REFrom
        {
            get
            {
                return 0;
            }
        }
        public double To
        {
            get
            {
                return 0;
            }
        }
        public double RETo
        {
            get
            {
                return 0;
            }
        }
        public int Contracts
        {
            get
            {
                return 0;
            }
        }
        public int REContracts
        {
            get
            {
                return 0;
            }
        }
        public int Sort
        {
            get
            {
                return 0;
            }
        }
        public int RESort
        {
            get
            {
                return 0;
            }
        }
        public int Percent
        {
            get
            {
                return 0;
            }
        }
        public int REPercent
        {
            get
            {
                return 0;
            }
        }
        public int Sumcontracts
        {
            get
            {
                return 0;
            }
        }
        public int RESumcontracts
        {
            get
            {
                return 0;
            }
        }
        public string PercentSumcontracts
        {
            get
            {
                return string.Empty;
            }
        }
        public string Rangefrom
        {
            get
            {
                return string.Empty;
            }
        }
        public string Rangeto
        {
            get
            {
                return string.Empty;
            }
        }
        public string PercentContracts
        {
            get
            {
                return string.Empty;
            }
        }
        public string Compute4
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class WhatifDistribution2001DataSet : ReportDataSet<WhatifDistribution2001>
    {

        public DataColumn From = new DataColumn("From", typeof(double));

        public DataColumn REFrom = new DataColumn("REFrom", typeof(double));

        public DataColumn To = new DataColumn("To", typeof(double));

        public DataColumn RETo = new DataColumn("RETo", typeof(double));

        public DataColumn Contracts = new DataColumn("Contracts", typeof(int));

        public DataColumn REContracts = new DataColumn("REContracts", typeof(int));

        public DataColumn Sort = new DataColumn("Sort", typeof(int));

        public DataColumn RESort = new DataColumn("RESort", typeof(int));

        public DataColumn Percent = new DataColumn("Percent", typeof(int));

        public DataColumn REPercent = new DataColumn("REPercent", typeof(int));

        public DataColumn Sumcontracts = new DataColumn("Sumcontracts", typeof(int));

        public DataColumn RESumcontracts = new DataColumn("RESumcontracts", typeof(int));

        public DataColumn PercentSumcontracts = new DataColumn("PercentSumcontracts", typeof(string));

        public DataColumn Rangefrom = new DataColumn("Rangefrom", typeof(string));

        public DataColumn Rangeto = new DataColumn("Rangeto", typeof(string));

        public DataColumn PercentContracts = new DataColumn("PercentContracts", typeof(string));

        public DataColumn Compute4 = new DataColumn("Compute4", typeof(string));


        public WhatifDistribution2001DataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				From,REFrom,To,RETo,Contracts,REContracts,Sort,RESort,Percent,REPercent,Sumcontracts,RESumcontracts,PercentSumcontracts,Rangefrom,Rangeto,PercentContracts,Compute4
				});
            From.AllowDBNull = true;
            REFrom.AllowDBNull = true;
            To.AllowDBNull = true;
            RETo.AllowDBNull = true;
            Contracts.AllowDBNull = true;
            REContracts.AllowDBNull = true;
            Sort.AllowDBNull = true;
            RESort.AllowDBNull = true;
            Percent.AllowDBNull = true;
            REPercent.AllowDBNull = true;
            Sumcontracts.AllowDBNull = true;
            RESumcontracts.AllowDBNull = true;

        }

        public WhatifDistribution2001DataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<WhatifDistribution2001> datas = dataSource as Metex.Core.EntityBindingList<WhatifDistribution2001>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(WhatifDistribution2001 data)
        {
            DataRow row = this.NewRow();
            row["From"] = GetFieldValue(data.From);
            row["REFrom"] = GetFieldValue(data.REFrom);
            row["To"] = GetFieldValue(data.To);
            row["RETo"] = GetFieldValue(data.RETo);
            row["Contracts"] = GetFieldValue(data.Contracts);
            row["REContracts"] = GetFieldValue(data.REContracts);
            row["Sort"] = GetFieldValue(data.Sort);
            row["RESort"] = GetFieldValue(data.RESort);
            row["Percent"] = GetFieldValue(data.Percent);
            row["REPercent"] = GetFieldValue(data.REPercent);
            row["Sumcontracts"] = GetFieldValue(data.Sumcontracts);
            row["RESumcontracts"] = GetFieldValue(data.RESumcontracts);
            row["PercentSumcontracts"] = GetFieldValue(data.PercentSumcontracts);
            row["Rangefrom"] = GetFieldValue(data.Rangefrom);
            row["Rangeto"] = GetFieldValue(data.Rangeto);
            row["PercentContracts"] = GetFieldValue(data.PercentContracts);
            row["Compute4"] = GetFieldValue(data.Compute4);
            return row;
        }
    }
}

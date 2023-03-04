using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RGlAccrualsAudit
    {
        public string PbuCode
        {
            get
            {
                return string.Empty;
            }
        }
        public string AccountCode
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal TransactionAmount
        {
            get
            {
                return 0;
            }
        }
        public int RETransactionAmount
        {
            get
            {
                return 0;
            }
        }
        public string Description
        {
            get
            {
                return string.Empty;
            }
        }
        public string Drcr
        {
            get
            {
                return string.Empty;
            }
        }
        public int Trans1
        {
            get
            {
                return 0;
            }
        }
        public int RETrans1
        {
            get
            {
                return 0;
            }
        }
        public int Trans2
        {
            get
            {
                return 0;
            }
        }
        public int RETrans2
        {
            get
            {
                return 0;
            }
        }
    }
    public class GlAccrualsAuditDataSet : ReportDataSet<GlAccrualsAudit>
    {

        public DataColumn PbuCode = new DataColumn("PbuCode", typeof(string));

        public DataColumn AccountCode = new DataColumn("AccountCode", typeof(string));

        public DataColumn TransactionAmount = new DataColumn("TransactionAmount", typeof(decimal));

        public DataColumn RETransactionAmount = new DataColumn("RETransactionAmount", typeof(int));

        public DataColumn Description = new DataColumn("Description", typeof(string));

        public DataColumn Drcr = new DataColumn("Drcr", typeof(string));

        public DataColumn Trans1 = new DataColumn("Trans1", typeof(int));

        public DataColumn RETrans1 = new DataColumn("RETrans1", typeof(int));

        public DataColumn Trans2 = new DataColumn("Trans2", typeof(int));

        public DataColumn RETrans2 = new DataColumn("RETrans2", typeof(int));


        public GlAccrualsAuditDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				PbuCode,AccountCode,TransactionAmount,RETransactionAmount,Description,Drcr,Trans1,RETrans1,Trans2,RETrans2
				});
            TransactionAmount.AllowDBNull = true;
            Trans1.AllowDBNull = true;
            Trans2.AllowDBNull = true;

        }

        public GlAccrualsAuditDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<GlAccrualsAudit> datas = dataSource as Metex.Core.EntityBindingList<GlAccrualsAudit>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(GlAccrualsAudit data)
        {
            DataRow row = this.NewRow();
            row["PbuCode"] = GetFieldValue(data.PbuCode);
            row["AccountCode"] = GetFieldValue(data.AccountCode);
            row["TransactionAmount"] = GetFieldValue(data.TransactionAmount);
            row["RETransactionAmount"] = GetFieldValue(data.RETransactionAmount);
            row["Description"] = GetFieldValue(data.Description);
            row["Drcr"] = GetFieldValue(data.Drcr);
            row["Trans1"] = GetFieldValue(data.Trans1);
            row["RETrans1"] = GetFieldValue(data.RETrans1);
            row["Trans2"] = GetFieldValue(data.Trans1);
            row["RETrans2"] = GetFieldValue(data.RETrans1);
            return row;
        }
    }
}

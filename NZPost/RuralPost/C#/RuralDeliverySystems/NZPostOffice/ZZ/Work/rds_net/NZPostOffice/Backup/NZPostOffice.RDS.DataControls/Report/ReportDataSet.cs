using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace NZPostOffice.RDS.DataControls.Report
{
    public class ReportDataSet<T> : DataTable where T : Metex.Core.Entity<T>
    {
        public ReportDataSet()
        { }

        protected virtual int ApplyRows(Metex.Core.EntityBindingList<T> datas)
        {
            if (datas != null)
            {
                foreach (T item in datas)
                {
                    DataRow row = ApplyRow(item);
                    this.Rows.Add(row);
                }
            }
            //if (this.Rows.Count == 0)
            //{
            //    this.Rows.Add(this.NewRow());
            //    return 0;
            //}
            return this.Rows.Count;
        }

        protected virtual object GetFieldValue(object obj)
        {
            if (obj == null)
                return DBNull.Value;
            return obj;
        }

        protected virtual DataRow ApplyRow(T data)
        {
            return null;
        }
    }
}

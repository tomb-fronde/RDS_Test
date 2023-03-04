using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.ODPS.Entity.Odps;

namespace NZPostOffice.ODPS.DataControls.Report
{
    public class RPostIrdNo
    {
        public virtual string NatIrdNo
        {
            get
            {
                return string.Empty;
            }
        }
    }

    public class PostIrdNoDataSet : ReportDataSet<PostIrdNo>
    {

        public DataColumn NatIrdNo = new DataColumn("NatIrdNo", typeof(string));


        public PostIrdNoDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				NatIrdNo
				});
        }

        public PostIrdNoDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<PostIrdNo> datas = dataSource as Metex.Core.EntityBindingList<PostIrdNo>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        public PostIrdNoDataSet(PostIrdNo obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<PostIrdNo> list = new Metex.Core.EntityBindingList<PostIrdNo>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public PostIrdNoDataSet(PostIrdNo[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<PostIrdNo> list = new Metex.Core.EntityBindingList<PostIrdNo>();
            foreach (PostIrdNo d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }

        protected override DataRow ApplyRow(PostIrdNo data)
        {
            DataRow row = this.NewRow();
            row["NatIrdNo"] = GetFieldValue(data.NatIrdNo);
            return row;
        }
    }
}

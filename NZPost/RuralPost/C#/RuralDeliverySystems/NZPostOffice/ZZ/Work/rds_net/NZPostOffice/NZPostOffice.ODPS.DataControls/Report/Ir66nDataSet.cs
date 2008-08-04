using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.ODPS.Entity.OdpsRep;
using System.Data;

namespace NZPostOffice.ODPS.DataControls.Report
{

    public class RIr66n
    {
        public decimal Grossearnings
        {
            get
            {
                return 0;
            }
        }
        //public decimal REGrossearnings
        //{
        //    get
        //    {
        //        return 0;
        //    }
        //}
        public decimal Payedeductions
        {
            get
            {
                return 0;
            }
        }
        //public decimal REPayedeductions
        //{
        //    get
        //    {
        //        return 0;
        //    }
        //}
    }
    public class Ir66nDataSet : ReportDataSet<Ir66n>
    {

        public DataColumn Grossearnings = new DataColumn("Grossearnings", typeof(decimal));

        //public DataColumn REGrossearnings = new DataColumn("REGrossearnings", typeof(decimal));

        public DataColumn Payedeductions = new DataColumn("Payedeductions", typeof(decimal));

        //public DataColumn REPayedeductions = new DataColumn("REPayedeductions", typeof(decimal));

        public Ir66nDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
                Grossearnings,Payedeductions
                });
            Grossearnings.AllowDBNull = true;
            Payedeductions.AllowDBNull = true;
        }

        public Ir66nDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<Ir66n> datas = dataSource as Metex.Core.EntityBindingList<Ir66n>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(Ir66n data)
        {
            DataRow row = this.NewRow();
            row["Grossearnings"] = GetFieldValue(data.Grossearnings);
            //row["REGrossearnings"] = GetFieldValue(data.REGrossearnings);
            row["Payedeductions"] = GetFieldValue(data.Payedeductions);
            //row["REPayedeductions"] = GetFieldValue(data.REPayedeductions);
            return row;
        }
    }
}

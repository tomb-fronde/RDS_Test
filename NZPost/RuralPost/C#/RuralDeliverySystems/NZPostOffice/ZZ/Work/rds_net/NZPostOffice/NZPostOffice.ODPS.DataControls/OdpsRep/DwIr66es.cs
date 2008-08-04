using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.ODPS.Entity.OdpsRep;

namespace NZPostOffice.ODPS.DataControls.OdpsRep
{
    public partial class DwIr66es : Metex.Windows.DataUserControl
    {
        public DwIr66es()
        {
            InitializeComponent();
        }

        public int Retrieve(DateTime? sdate, DateTime? edate)
        {
            this.eDate = edate;
            int ret = RetrieveCore<Ir66es>(new List<Ir66es>
                (Ir66es.GetAllIr66es(sdate, edate)));

            if (this.RowCount != 0)
            {
                DataTable table2 = new NZPostOffice.ODPS.DataControls.Report.PostIrdNoDataSet(NZPostOffice.ODPS.Entity.Odps.PostIrdNo.GetAllPostIrdNo(edate));
                this.reDwIr66es.Subreports["REDwPostIrdNo.rpt"].SetDataSource(table2);
            }

            viewer.RefreshReport();

            return ret;
        }

        private int Sorter(Ir66es s1, Ir66es s2)
        {
            int cIrdNo = string.Compare(s1.CIrdNo, s2.CIrdNo);
            if (cIrdNo != 0)
            {
                return cIrdNo;
            }
            else
            {
                int cSurnameCompany = string.Compare(s1.CSurnameCompany, s2.CSurnameCompany);
                if (cSurnameCompany != 0)
                {
                    return cSurnameCompany;
                }
                else
                {
                    int cFirstNames = string.Compare(s1.CFirstNames, s2.CFirstNames);
                    if (cFirstNames != 0)
                    {
                        return cFirstNames;
                    }
                    else
                    {
                        int startdate = DateTime.Compare(s1.Startdate.GetValueOrDefault(), s2.Startdate.GetValueOrDefault());
                        if (startdate != 0)
                        {
                            return startdate;
                        }
                        else
                        {
                            int taxcategory = string.Compare(s1.Taxcategory, s2.Taxcategory);
                            if (taxcategory != 0)
                            {
                                return taxcategory;
                            }
                            else
                            {
                                int enddate = DateTime.Compare(s1.Enddate.GetValueOrDefault(), s2.Enddate.GetValueOrDefault());
                                return enddate;
                            }
                        }
                    }
                }
            }
        }
    }
}

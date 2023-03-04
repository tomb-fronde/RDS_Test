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
    public partial class DwPostTaxAdjustments : Metex.Windows.DataUserControl
    {
        public DwPostTaxAdjustments()
        {
            InitializeComponent();
        }

        private DateTime ui_sdate = DateTime.MinValue;
        private DateTime ui_edate = DateTime.MinValue;
        public int Retrieve(DateTime? sdate, DateTime? edate)
        {
            ui_sdate = sdate.GetValueOrDefault();
            ui_edate = edate.GetValueOrDefault();
            int ret = RetrieveCore<PostTaxAdjustments>(new List<PostTaxAdjustments>
                (PostTaxAdjustments.GetAllPostTaxAdjustments(sdate, edate)));
            this.viewer.RefreshReport();
            //this.Sort();
            return ret;
        }

        public void Sort()
        {
            SortOnce<PostTaxAdjustments>(new Comparison<PostTaxAdjustments>(this.defaultSorter));
        }

        private int defaultSorter(PostTaxAdjustments s1, PostTaxAdjustments s2)
        {
            return string.Compare(s1.CSurnameCompany, s2.CSurnameCompany);
        }
    }
}

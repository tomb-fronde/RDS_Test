using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Ruralrpt
{
	public partial class RSummaryCustList : Metex.Windows.DataUserControl
	{
		public RSummaryCustList()
		{
			InitializeComponent();
		}

        public override int Retrieve()
        {
            return RetrieveCore<SummaryCustList>(new List<SummaryCustList>
                (SummaryCustList.GetAllSummaryCustList()));
        }
        //public int Retrieve(int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder)
        //{
        //    //try
        //    //{
        //    //RERSummaryCustListHdr.rpt
        //    RSummaryCustListHdr hdr = new RSummaryCustListHdr();
        //    hdr.Retrieve(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder);
        //    DataTable dtHdr = new NZPostOffice.RDS.DataControls.Report.SummaryCustListHdrDataSet(hdr.BindingSource.DataSource);
        //    NZPostOffice.RDS.Entity.Report.RERSummaryCustListCust r = new NZPostOffice.RDS.DataControls.Report.RERSummaryCustListCust();
        //    r.SetDataSource(dtHdr);

        //    //reRSummaryCustList.Subreports["RERSummaryCustListHdr"].SetDataSource(dtHdr);

        //    //    //RERSummaryCustListSeq.rpt
        //    //    RSummaryCustListSeq seq = new RSummaryCustListSeq();
        //    //    seq.Retrieve(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder);
        //    //    DataTable dtSeq = new NZPostOffice.RDS.DataControls.Report.SummaryCustListSeqDataSet(seq.BindingSource.DataSource);
        //    //    reRSummaryCustList.Subreports["RERSummaryCustListSeq"].SetDataSource(dtSeq);

        //    //    //RERSummaryCustListUnseq.rpt
        //    //    RSummaryCustListUnseq unseq = new RSummaryCustListUnseq();
        //    //    unseq.Retrieve(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder);
        //    //    DataTable dtUnseq = new NZPostOffice.RDS.DataControls.Report.SummaryCustListUnseqDataSet(unseq.BindingSource.DataSource);
        //    //    reRSummaryCustList.Subreports["RERSummaryCustListUnseq"].SetDataSource(dtUnseq);

                
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    string a = e.Message;
        //    //}
        //    return 0;
        //    //return RetrieveCore<SummaryCustList>(new List<SummaryCustList>
        //    //         (SummaryCustList.GetAllSummaryCustList()));
        //}
	}
}

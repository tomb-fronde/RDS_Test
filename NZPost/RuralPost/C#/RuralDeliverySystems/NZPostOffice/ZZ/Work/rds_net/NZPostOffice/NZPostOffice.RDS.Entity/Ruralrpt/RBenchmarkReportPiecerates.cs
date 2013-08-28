using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // TJB  Release 7.1.10 fixup  Aug-2013
    // Modified fetch to get all data in t_bm_piecerates
    //
    // TJB  RPCR_054  Aug-2013: NEW
    // Retrieve piece rates for Benchmark report
    //
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("prs_key", "_prs_key", "")]
    [MapInfo("prs_description", "_prs_description", "")]
    [MapInfo("ytd_paid", "_ytd_paid", "")]
	[System.Serializable()]

    public class BenchmarkReportPiecerates : Entity<BenchmarkReportPiecerates>
	{
		#region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _prs_key;

        [DBField()]
        private string _prs_description;

        [DBField()]
		private decimal?  _ytd_paid;


        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty("ContractNo", true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty("ContractNo", true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PrsKey
        {
            get
            {
                CanReadProperty("PrsKey", true);
                return _prs_key;
            }
            set
            {
                CanWriteProperty("PrsKey", true);
                if (_prs_key != value)
                {
                    _prs_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrsDescription
        {
            get
            {
                CanReadProperty("PrsDescription", true);
                return _prs_description;
            }
            set
            {
                CanWriteProperty("PrsDescription", true);
                if (_prs_description != value)
                {
                    _prs_description = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? YtdPaid
		{
			get
			{
                CanReadProperty("YtdPaid", true);
                if (_ytd_paid == null)
                {
                    return 0;
                }
				return _ytd_paid;
			}
			set
			{
                CanWriteProperty("YtdPaid", true);
				if ( _ytd_paid != value )
				{
					_ytd_paid = value;
					PropertyHasChanged();
				}
			}
		}

        private int _sqldbcode = -1;
        public int SQLDBCode
        {
            get
            {
                return _sqldbcode;
            }
        }

        private string _sqlerrtext = "";
        public string SQLErrText
        {
            get
            {
                return _sqlerrtext;
            }
        }

        protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
        public static BenchmarkReportPiecerates NewBenchmarkReportPiecerates(int? lContract)
		{
			return Create(lContract);
		}

		//public static BenchmarkReportPiecerates[] GetAllBenchmarkReportPiecerates( int? lContract, int? lRegion, int? lOutlet, DateTime? dPrMonth )
        public static BenchmarkReportPiecerates[] GetAllBenchmarkReportPiecerates(int? lContract)
		{
			return Fetch(lContract).list;
		}

		#endregion

		#region Data Access
		[ServerMethod]
        private void FetchEntity(int? lContract)
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT contract_no, prs_key, prs_description, ytd_paid "
                                   + "  FROM t_bm_piecerates ";
                    // TJB  Release 7.1.10 fixup  Aug-2013
                    // Return all values from t_bm_piecerates.  It now accumulates
                    // data for all contracts, though they're added to one contract at a time
                    // (there's probably a better way to do this).
                                   //+ " WHERE contract_no = :lContract ";
					ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "lContract", lContract);

                    List<BenchmarkReportPiecerates> _list = new List<BenchmarkReportPiecerates>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        try
                        {
                            while (dr.Read())
                            {
                                BenchmarkReportPiecerates instance = new BenchmarkReportPiecerates();
                                instance._contract_no = GetValueFromReader<int?>(dr, 0);
                                instance._prs_key = GetValueFromReader<int?>(dr, 1);
                                instance._prs_description = GetValueFromReader<string>(dr, 2);
                                instance._ytd_paid = GetValueFromReader<decimal?>(dr, 3);
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                            _sqldbcode = 0;
                        }
                        catch (Exception e)
                        {
                            _sqlerrtext = e.Message;
                            _sqldbcode = -1;
                        }
                    }
				}
			}
		}

		#endregion

		[ServerMethod()]
        private void CreateEntity(int? lContract)
		{
            _contract_no = lContract;
		}
	}
}

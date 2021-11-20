using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("seq_num", "_seq_num", "")]
	[MapInfo("adr_no", "_adr_no", "")]
	[MapInfo("road_name", "_road_name", "")]
	[MapInfo("rt_name", "_rt_name", "")]
	[MapInfo("sl_name", "_locality", "")]
	[MapInfo("cust_title", "_cust_title", "")]
	[MapInfo("cust_surname_company", "_cust_surname_company", "")]
	[MapInfo("cust_initials", "_cust_initials", "")]
	[MapInfo("adr_alpha", "_adr_alpha", "")]
	[System.Serializable()]

	public class SummaryCustListUnseq : Entity<SummaryCustListUnseq>
	{
		#region Business Methods
		[DBField()]
		private int?  _seq_num;

		[DBField()]
		private string  _adr_no;

		[DBField()]
		private string  _road_name;

		[DBField()]
		private string  _rt_name;

		[DBField()]
		private string  _locality;

		[DBField()]
		private string  _cust_title;

		[DBField()]
		private string  _cust_surname_company;

		[DBField()]
		private string  _cust_initials;

		[DBField()]
		private string  _adr_alpha;


		public virtual int? SeqNum
		{
			get
			{
                CanReadProperty("SeqNum", true);
				return _seq_num;
			}
			set
			{
                CanWriteProperty("SeqNum", true);
				if ( _seq_num != value )
				{
					_seq_num = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrNo
		{
			get
			{
                CanReadProperty("AdrNo", true);
				return _adr_no;
			}
			set
			{
                CanWriteProperty("AdrNo", true);
				if ( _adr_no != value )
				{
					_adr_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RoadName
		{
			get
			{
                CanReadProperty("RoadName", true);
				return _road_name;
			}
			set
			{
                CanWriteProperty("RoadName", true);
				if ( _road_name != value )
				{
					_road_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RtName
		{
			get
			{
                CanReadProperty("RtName", true);
				return _rt_name;
			}
			set
			{
                CanWriteProperty("RtName", true);
				if ( _rt_name != value )
				{
					_rt_name = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Locality
		{
			get
			{
                CanReadProperty("Locality", true);
				return _locality;
			}
			set
			{
                CanWriteProperty("Locality", true);
				if ( _locality != value )
				{
					_locality = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustTitle
		{
			get
			{
                CanReadProperty("CustTitle", true);
				return _cust_title;
			}
			set
			{
                CanWriteProperty("CustTitle", true);
				if ( _cust_title != value )
				{
					_cust_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustSurnameCompany
		{
			get
			{
                CanReadProperty("CustSurnameCompany", true);
				return _cust_surname_company;
			}
			set
			{
                CanWriteProperty("CustSurnameCompany", true);
				if ( _cust_surname_company != value )
				{
					_cust_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CustInitials
		{
			get
			{
                CanReadProperty("CustInitials", true);
				return _cust_initials;
			}
			set
			{
                CanWriteProperty("CustInitials", true);
				if ( _cust_initials != value )
				{
					_cust_initials = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string AdrAlpha
		{
			get
			{
                CanReadProperty("AdrAlpha", true);
				return _adr_alpha;
			}
			set
			{
                CanWriteProperty("AdrAlpha", true);
				if ( _adr_alpha != value )
				{
					_adr_alpha = value;
					PropertyHasChanged();
				}
			}
		}
			// needs to implement compute expression manually:
			// compute control name=[street_address]
			/*?if( isnull( road_name ),'', if(isnull( adr_no ), if(isnull( adr_alpha ),'', adr_alpha+' '), adr_no + if(isnull( adr_alpha ),' ',adr_alpha+' ')) + road_name + if( isnull( rt_name ), '',' '+rt_name ) )

			// needs to implement compute expression manually:
			// compute control name=[cust_name]
			Trim(if(isnull( cust_title ), '', cust_title) + ' ' + if(isnull(  cust_initials  ), '',  cust_initials ) +' '+ if(isnull(   cust_surname_company ), '',   cust_surname_company ))

			// needs to implement compute expression manually:
			// compute control name=[seq_num]
			if( seq_num  = 99999, '', string( seq_num ) )*/


		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static SummaryCustListUnseq NewSummaryCustListUnseq( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
		{
			return Create(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder);
		}

		public static SummaryCustListUnseq[] GetAllSummaryCustListUnseq( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
		{
			return Fetch(in_contract_no, in_sf_key, in_rd_del_days, in_sortorder).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? in_contract_no, int? in_sf_key, string in_rd_del_days, string in_sortorder )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_summary_cust_list_unseq";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "in_contract_no", in_contract_no);
					pList.Add(cm, "in_sf_key", in_sf_key);
					pList.Add(cm, "in_rd_del_days", in_rd_del_days);
					pList.Add(cm, "in_sortorder", in_sortorder);

					List<SummaryCustListUnseq> _list = new List<SummaryCustListUnseq>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							SummaryCustListUnseq instance = new SummaryCustListUnseq();
                            instance._seq_num = GetValueFromReader<int?>(dr,0);
                            instance._adr_no = GetValueFromReader<string>(dr,1);
                            instance._road_name = GetValueFromReader<string>(dr,2);
                            instance._rt_name = GetValueFromReader<string>(dr,3);
                            instance._locality = GetValueFromReader<string>(dr,4);
                            instance._cust_title = GetValueFromReader<string>(dr,5);
                            instance._cust_surname_company = GetValueFromReader<string>(dr,6);
                            instance._cust_initials = GetValueFromReader<string>(dr,7);
                            instance._adr_alpha = GetValueFromReader<string>(dr,8);
							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}

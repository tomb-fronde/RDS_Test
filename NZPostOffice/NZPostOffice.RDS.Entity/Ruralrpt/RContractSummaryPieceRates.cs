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
	[MapInfo("prs_description", "_prs_description", "")]
	[MapInfo("mo1", "_mo1", "")]
	[MapInfo("mo2", "_mo2", "")]
	[MapInfo("mo3", "_mo3", "")]
	[MapInfo("mo4", "_mo4", "")]
	[MapInfo("mo5", "_mo5", "")]
	[MapInfo("mo6", "_mo6", "")]
	[MapInfo("mo7", "_mo7", "")]
	[MapInfo("mo8", "_mo8", "")]
	[MapInfo("mo9", "_mo9", "")]
	[MapInfo("mo10", "_mo10", "")]
	[MapInfo("mo11", "_mo11", "")]
	[MapInfo("mo12", "_mo12", "")]
	[System.Serializable()]

	public class ContractSummaryPieceRates : Entity<ContractSummaryPieceRates>
	{
		#region Business Methods
		[DBField()]
		private string  _prs_description;

		[DBField()]
		private decimal?  _mo1;

		[DBField()]
		private decimal?  _mo2;

		[DBField()]
		private decimal?  _mo3;

		[DBField()]
		private decimal?  _mo4;

		[DBField()]
		private decimal?  _mo5;

		[DBField()]
		private decimal?  _mo6;

		[DBField()]
		private decimal?  _mo7;

		[DBField()]
		private decimal?  _mo8;

		[DBField()]
		private decimal?  _mo9;

		[DBField()]
		private decimal?  _mo10;

		[DBField()]
		private decimal?  _mo11;

		[DBField()]
		private decimal?  _mo12;


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
				if ( _prs_description != value )
				{
					_prs_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo1
		{
			get
			{
                CanReadProperty("Mo1", true);
				return _mo1;
			}
			set
			{
                CanWriteProperty("Mo1", true);
				if ( _mo1 != value )
				{
					_mo1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo2
		{
			get
			{
                CanReadProperty("Mo2", true);
				return _mo2;
			}
			set
			{
                CanWriteProperty("Mo2", true);
				if ( _mo2 != value )
				{
					_mo2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo3
		{
			get
			{
                CanReadProperty("Mo3", true);
				return _mo3;
			}
			set
			{
                CanWriteProperty("Mo3", true);
				if ( _mo3 != value )
				{
					_mo3 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo4
		{
			get
			{
                CanReadProperty("Mo4", true);
				return _mo4;
			}
			set
			{
                CanWriteProperty("Mo4", true);
				if ( _mo4 != value )
				{
					_mo4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo5
		{
			get
			{
                CanReadProperty("Mo5", true);
				return _mo5;
			}
			set
			{
                CanWriteProperty("Mo5", true);
				if ( _mo5 != value )
				{
					_mo5 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo6
		{
			get
			{
                CanReadProperty("Mo6", true);
				return _mo6;
			}
			set
			{
                CanWriteProperty("Mo6", true);
				if ( _mo6 != value )
				{
					_mo6 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo7
		{
			get
			{
                CanReadProperty("Mo7", true);
				return _mo7;
			}
			set
			{
                CanWriteProperty("Mo7", true);
				if ( _mo7 != value )
				{
					_mo7 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo8
		{
			get
			{
                CanReadProperty("Mo8", true);
				return _mo8;
			}
			set
			{
                CanWriteProperty("Mo8", true);
				if ( _mo8 != value )
				{
					_mo8 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo9
		{
			get
			{
                CanReadProperty("Mo9", true);
				return _mo9;
			}
			set
			{
                CanWriteProperty("Mo9", true);
				if ( _mo9 != value )
				{
					_mo9 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo10
		{
			get
			{
                CanReadProperty("Mo10", true);
				return _mo10;
			}
			set
			{
                CanWriteProperty("Mo10", true);
				if ( _mo10 != value )
				{
					_mo10 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo11
		{
			get
			{
                CanReadProperty("Mo11", true);
				return _mo11;
			}
			set
			{
                CanWriteProperty("Mo11", true);
				if ( _mo11 != value )
				{
					_mo11 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Mo12
		{
			get
			{
                CanReadProperty("Mo12", true);
				return _mo12;
			}
			set
			{
                CanWriteProperty("Mo12", true);
				if ( _mo12 != value )
				{
					_mo12 = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractSummaryPieceRates NewContractSummaryPieceRates( int? inContract, int? mo, int? yr )
		{
			return Create(inContract, mo, yr);
		}

		public static ContractSummaryPieceRates[] GetAllContractSummaryPieceRates( int? inContract, int? mo, int? yr )
		{
			return Fetch(inContract, mo, yr).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? mo, int? yr )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_contractsummarypiecerates";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "mo", mo);
					pList.Add(cm, "yr", yr);

					List<ContractSummaryPieceRates> _list = new List<ContractSummaryPieceRates>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryPieceRates instance = new ContractSummaryPieceRates();
                            instance._prs_description = GetValueFromReader<string>(dr,0);
                            instance._mo1 = GetValueFromReader<decimal?>(dr,1);
                            instance._mo2 = GetValueFromReader<decimal?>(dr,2);
                            instance._mo3 = GetValueFromReader<decimal?>(dr,3);
                            instance._mo4 = GetValueFromReader<decimal?>(dr,4);
                            instance._mo5 = GetValueFromReader<decimal?>(dr,5);
                            instance._mo6 = GetValueFromReader<decimal?>(dr,6);
                            instance._mo7 = GetValueFromReader<decimal?>(dr,7);
                            instance._mo8 = GetValueFromReader<decimal?>(dr,8);
                            instance._mo9 = GetValueFromReader<decimal?>(dr,9);
                            instance._mo10 = GetValueFromReader<decimal?>(dr,10);
                            instance._mo11 = GetValueFromReader<decimal?>(dr,11);
                            instance._mo12 = GetValueFromReader<decimal?>(dr,12);
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

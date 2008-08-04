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
	[MapInfo("sortorder", "_sortorder", "")]
	[MapInfo("description", "_description", "")]
	[MapInfo("dispdecs", "_dispdecs", "")]
	[MapInfo("displine", "_displine", "")]
	[MapInfo("medium_env", "_medium_env", "")]
	[MapInfo("other_env", "_other_env", "")]
	[MapInfo("small_par", "_small_par", "")]
	[MapInfo("large_par", "_large_par", "")]
	[MapInfo("total_vol", "_total_vol", "")]
	[System.Serializable()]

	public class ContractSummaryVolume : Entity<ContractSummaryVolume>
	{
		#region Business Methods
		[DBField()]
		private int?  _sortorder;

		[DBField()]
		private string  _description;

		[DBField()]
		private string  _dispdecs;

		[DBField()]
		private string  _displine;

		[DBField()]
		private decimal?  _medium_env;

		[DBField()]
		private decimal?  _other_env;

		[DBField()]
		private decimal?  _small_par;

		[DBField()]
		private decimal?  _large_par;

		[DBField()]
		private decimal?  _total_vol;


		public virtual int? Sortorder
		{
			get
			{
                CanReadProperty("Sortorder", true);
				return _sortorder;
			}
			set
			{
                CanWriteProperty("Sortorder", true);
				if ( _sortorder != value )
				{
					_sortorder = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Description
		{
			get
			{
                CanReadProperty("Description", true);
				return _description;
			}
			set
			{
                CanWriteProperty("Description", true);
				if ( _description != value )
				{
					_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Dispdecs
		{
			get
			{
                CanReadProperty("Dispdecs", true);
				return _dispdecs;
			}
			set
			{
                CanWriteProperty("Dispdecs", true);
				if ( _dispdecs != value )
				{
					_dispdecs = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Displine
		{
			get
			{
                CanReadProperty("Displine", true);
				return _displine;
			}
			set
			{
                CanWriteProperty("Displine", true);
				if ( _displine != value )
				{
					_displine = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? MediumEnv
		{
			get
			{
                CanReadProperty("MediumEnv", true);
				return _medium_env;
			}
			set
			{
                CanWriteProperty("MediumEnv", true);
				if ( _medium_env != value )
				{
					_medium_env = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? OtherEnv
		{
			get
			{
                CanReadProperty("OtherEnv", true);
				return _other_env;
			}
			set
			{
                CanWriteProperty("OtherEnv", true);
				if ( _other_env != value )
				{
					_other_env = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? SmallPar
		{
			get
			{
                CanReadProperty("SmallPar", true);
				return _small_par;
			}
			set
			{
                CanWriteProperty("SmallPar", true);
				if ( _small_par != value )
				{
					_small_par = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? LargePar
		{
			get
			{
                CanReadProperty("LargePar", true);
				return _large_par;
			}
			set
			{
                CanWriteProperty("LargePar", true);
				if ( _large_par != value )
				{
					_large_par = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? TotalVol
		{
			get
			{
                CanReadProperty("TotalVol", true);
				return _total_vol;
			}
			set
			{
                CanWriteProperty("TotalVol", true);
				if ( _total_vol != value )
				{
					_total_vol = value;
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
		public static ContractSummaryVolume NewContractSummaryVolume( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static ContractSummaryVolume[] GetAllContractSummaryVolume( int? inContract, int? inSequence )
		{
			return Fetch(inContract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "rd.sp_contract_voldetails32v2";
                    cm.CommandText = "rd.sp_contract_voldetails";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<ContractSummaryVolume> _list = new List<ContractSummaryVolume>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ContractSummaryVolume instance = new ContractSummaryVolume();
                            instance._sortorder = GetValueFromReader<int?>(dr,0);
                            instance._description = GetValueFromReader<string>(dr,1);
                            instance._dispdecs = GetValueFromReader<string>(dr,2);
                            instance._displine = GetValueFromReader<string>(dr,3);
                            instance._medium_env = GetValueFromReader<decimal?>(dr,4);
                            instance._other_env = GetValueFromReader<decimal?>(dr,5);
                            instance._small_par = GetValueFromReader<decimal?>(dr,6);
                            instance._large_par = GetValueFromReader<decimal?>(dr,7);
                            instance._total_vol = GetValueFromReader<decimal?>(dr,8);
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

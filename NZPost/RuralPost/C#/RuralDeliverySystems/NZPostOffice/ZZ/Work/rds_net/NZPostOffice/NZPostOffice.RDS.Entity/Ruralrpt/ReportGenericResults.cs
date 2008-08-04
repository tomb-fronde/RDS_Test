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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("con_active_sequence", "_con_active_sequence", "")]
	[MapInfo("con_title", "_con_title", "")]
	[System.Serializable()]

	public class ReportGenericResults : Entity<ReportGenericResults>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _con_active_sequence;

		[DBField()]
		private string  _con_title;


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
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ConActiveSequence
		{
			get
			{
                CanReadProperty("ConActiveSequence", true);
				return _con_active_sequence;
			}
			set
			{
                CanWriteProperty("ConActiveSequence", true);
				if ( _con_active_sequence != value )
				{
					_con_active_sequence = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual string Compute1
        {
            get
            {
                CanWriteProperty("Compute1", true);
                if (_contract_no == 0)
                {
                    return null;
                }
                return _contract_no.ToString() + "/" + Convert.ToString(_con_active_sequence == null ? 0 : _con_active_sequence);
            }
        }

		public virtual string ConTitle
		{
			get
			{
                CanReadProperty("ConTitle", true);
				return _con_title;
			}
			set
			{
                CanWriteProperty("ConTitle", true);
				if ( _con_title != value )
				{
					_con_title = value;
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
		public static ReportGenericResults NewReportGenericResults( int? inRegion, int? inOutlet, int? inRGCode, int? inSFKey, int? inCTKey )
		{
			return Create(inRegion, inOutlet, inRGCode, inSFKey, inCTKey);
		}

		public static ReportGenericResults[] GetAllReportGenericResults( int? inRegion, int? inOutlet, int? inRGCode, int? inSFKey, int? inCTKey )
		{
			return Fetch(inRegion, inOutlet, inRGCode, inSFKey, inCTKey).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inRegion, int? inOutlet, int? inRGCode, int? inSFKey, int? inCTKey )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "rd.sp_report_search";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inRegion", inRegion);
					pList.Add(cm, "inOutlet", inOutlet);
					pList.Add(cm, "inRGCode", inRGCode);
					pList.Add(cm, "inSFKey", inSFKey);
					pList.Add(cm, "inCTKey", inCTKey);

					List<ReportGenericResults> _list = new List<ReportGenericResults>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							ReportGenericResults instance = new ReportGenericResults();
                            instance._contract_no = GetValueFromReader<int?>(dr,0);
	                        instance._con_active_sequence = GetValueFromReader<int?>(dr,1);
                            instance._con_title = GetValueFromReader<string>(dr,2);
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

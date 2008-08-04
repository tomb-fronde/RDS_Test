using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("rf_annotation", "_rf_annotation", "route_frequency")]
	[MapInfo("rf_annotation_print", "_rf_annotation_print", "route_frequency")]
	[MapInfo("contract_no", "_contract_no", "route_frequency")]
	[MapInfo("sf_key", "_sf_key", "route_frequency")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "route_frequency")]
	[System.Serializable()]

	public class FrequencyAnnotation : Entity<FrequencyAnnotation>
	{
		#region Business Methods
		[DBField()]
		private string  _rf_annotation;

		[DBField()]
		private string  _rf_annotation_print;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;


		public virtual string RfAnnotation
		{
			get
			{
                CanReadProperty("RfAnnotation", true);
				return _rf_annotation;
			}
			set
			{
                CanWriteProperty("RfAnnotation", true);
				if ( _rf_annotation != value )
				{
					_rf_annotation = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual bool RfAnnotationPrint
		{
			get
			{
                CanReadProperty("RfAnnotationPrint", true);
				return _rf_annotation_print == "Y";
			}
			set
			{
                CanWriteProperty("RfAnnotationPrint", true);
                string new_value = value ? "Y" : "N";
                if (_rf_annotation_print != new_value)
				{
                    _rf_annotation_print = new_value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual int? SfKey
		{
			get
			{
                CanReadProperty("SfKey", true);
				return _sf_key;
			}
			set
			{
                CanWriteProperty("SfKey", true);
				if ( _sf_key != value )
				{
					_sf_key = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RfDeliveryDays
		{
			get
			{
                CanReadProperty("RfDeliveryDays", true);
				return _rf_delivery_days;
			}
			set
			{
                CanWriteProperty("RfDeliveryDays", true);
				if ( _rf_delivery_days != value )
				{
					_rf_delivery_days = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}/{2}", _contract_no,_sf_key,_rf_delivery_days );
		}
		#endregion

		#region Factory Methods
		public static FrequencyAnnotation NewFrequencyAnnotation( int? contractno, int? sfkey, string rf_deliverydays )
		{
			return Create(contractno, sfkey, rf_deliverydays);
		}

		public static FrequencyAnnotation[] GetAllFrequencyAnnotation( int? contractno, int? sfkey, string rf_deliverydays )
		{
			return Fetch(contractno, sfkey, rf_deliverydays).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? contractno, int? sfkey, string rf_deliverydays )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "contractno", contractno);
					pList.Add(cm, "sfkey", sfkey);
					pList.Add(cm, "rf_deliverydays", rf_deliverydays);
                    cm.CommandText = @"SELECT route_frequency.rf_annotation,   
                                             route_frequency.rf_annotation_print,   
                                             route_frequency.contract_no,   
                                             route_frequency.sf_key,   
                                             route_frequency.rf_delivery_days  
                                        FROM route_frequency  
                                       WHERE ( route_frequency.contract_no = @contractno ) AND  
                                             ( route_frequency.sf_key = @sfkey ) AND  
                                             ( route_frequency.rf_delivery_days = @rf_deliverydays ) ";
                   
					List<FrequencyAnnotation> _list = new List<FrequencyAnnotation>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							FrequencyAnnotation instance = new FrequencyAnnotation();
                            instance._rf_annotation = GetValueFromReader<String>(dr,0);
                            instance._rf_annotation_print = GetValueFromReader<String>(dr,1);
                            instance._contract_no = GetValueFromReader<Int32?>(dr,2);
                            instance._sf_key = GetValueFromReader<Int32?>(dr,3);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr,4);

							instance.MarkOld();
                            instance.StoreInitialValues();
							_list.Add(instance);
						}
						list = _list.ToArray();
					}
				}
			}
		}

		[ServerMethod()]
		private void UpdateEntity()
		{
			using ( DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "route_frequency", ref pList))
				{
                    cm.CommandText += " WHERE  route_frequency.contract_no = @contract_no AND " +
                        "route_frequency.sf_key = @sf_key and route_frequency.rf_delivery_days = @rf_delivery_days";

                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));
                    DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "route_frequency", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
			using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
						ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"contract_no", GetInitialValue("_contract_no"));
					pList.Add(cm,"sf_key", GetInitialValue("_sf_key"));
					pList.Add(cm,"rf_delivery_days", GetInitialValue("_rf_delivery_days"));
						cm.CommandText = "DELETE FROM route_frequency WHERE " +
						"route_frequency.contract_no = @contract_no AND " + 
						"route_frequency.sf_key = @sf_key AND " + 
						"route_frequency.rf_delivery_days = @rf_delivery_days ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? contract_no, int? sf_key, string rf_delivery_days )
		{
			_contract_no = contract_no;
			_sf_key = sf_key;
			_rf_delivery_days = rf_delivery_days;
		}
	}
}

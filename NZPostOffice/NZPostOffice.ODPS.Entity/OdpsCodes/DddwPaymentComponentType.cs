//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsCodes
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("pct_id", "_pct_id", "")]
    [MapInfo("pct_description", "_pct_description", "")]
	[System.Serializable()]

	public class PaymentComponentType : Entity<PaymentComponentType>
	{
		#region Business Methods
		[DBField()]
		private int?  _pct_id;

		[DBField()]
		private string  _pct_description;

		public virtual int? PctId
		{
			get
			{
				CanReadProperty("PctId",true);
				return _pct_id;
			}
			set
			{
				CanWriteProperty("PctId",true);
				if ( _pct_id != value )
				{
					_pct_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PctDescription
		{
			get
			{
				CanReadProperty("PctDescription",true);
				return _pct_description;
			}
			set
			{
				CanWriteProperty("PctDescription",true);
				if ( _pct_description != value )
				{
					_pct_description = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
            return _pct_id.ToString();
		}

		#endregion

		#region Factory Methods
		public static PaymentComponentType NewPaymentComponentType(  )
		{
			return Create();
		}

		public static PaymentComponentType[] GetAllPaymentComponentType(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_cts_paymentcomponenttype";
					ParameterCollection pList = new ParameterCollection();

					List<PaymentComponentType> _list = new List<PaymentComponentType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PaymentComponentType instance = new PaymentComponentType();
                            instance.PctId = GetValueFromReader<Int32?>(dr,0);
                            instance.PctDescription = GetValueFromReader<string>(dr,1);
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

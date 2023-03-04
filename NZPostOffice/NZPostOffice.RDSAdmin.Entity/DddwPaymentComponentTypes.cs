using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  RPCR_054  July-2013: NEW
    // Retrieval query for DDddwPaymentComponentTypes

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("pct_id", "_pct_id", "odps.payment_component_type")]
    [MapInfo("pct_description", "_pct_description", "odps.payment_component_type")]
    [System.Serializable()]

    public class PaymentComponentTypes : Entity<PaymentComponentTypes>
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
				CanReadProperty(true);
                return _pct_id;
			}
			set
			{
				CanWriteProperty(true);
                if (_pct_id != value)
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
				CanReadProperty(true);
				return _pct_description;
			}
			set
			{
				CanWriteProperty(true);
				if ( _pct_description != value )
				{
					_pct_description = value;
					PropertyHasChanged();
				}
			}
		}
        private PaymentComponentTypes[] dataList;

		protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static PaymentComponentTypes NewDddwPaymentComponentTypes(  )
		{
			return Create();
		}

		public static PaymentComponentTypes[] GetAllDddwPaymentComponentTypes(  )
		{
			return Fetch().dataList;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity(  )
		{
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.Text;
                    GenerateSelectCommandText(cm, "odps.payment_component_type");
					ParameterCollection pList = new ParameterCollection();

					List<PaymentComponentTypes> list = new List<PaymentComponentTypes>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PaymentComponentTypes instance = new PaymentComponentTypes();
                            instance.StoreFieldValues(dr, "odps.payment_component_type");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new PaymentComponentTypes[list.Count];
						list.CopyTo(dataList);
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

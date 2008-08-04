//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("cust_id", "_cust_id", "rd.recipient")]
	[MapInfo("recipient_id", "_recipient_id", "rd.recipient")]
	[MapInfo("rc_surname_company", "_rc_surname_company", "rd.recipient")]
	[MapInfo("rc_first_names", "_rc_first_names", "rd.recipient")]
	[System.Serializable()]

	public class Test : Entity<Test>
	{
		#region Business Methods
		[DBField()]
		private int?  _cust_id;

		[DBField()]
		private int?  _recipient_id;

		[DBField()]
		private string  _rc_surname_company;

		[DBField()]
		private string  _rc_first_names;


		public virtual int? CustId
		{
			get
			{
				CanReadProperty("CustId",true);
				return _cust_id;
			}
			set
			{
				CanWriteProperty("CustId",true);
				if ( _cust_id != value )
				{
					_cust_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? RecipientId
		{
			get
			{
				CanReadProperty("RecipientId",true);
				return _recipient_id;
			}
			set
			{
				CanWriteProperty("RecipientId",true);
				if ( _recipient_id != value )
				{
					_recipient_id = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcSurnameCompany
		{
			get
			{
				CanReadProperty("RcSurnameCompany",true);
				return _rc_surname_company;
			}
			set
			{
                CanWriteProperty("RcSurnameCompany", true);
				if ( _rc_surname_company != value )
				{
					_rc_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string RcFirstNames
		{
			get
			{
				CanReadProperty("RcFirstNames",true);
				return _rc_first_names;
			}
			set
			{
                CanWriteProperty("RcFirstNames", true);
				if ( _rc_first_names != value )
				{
					_rc_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return string.Format( "{0}/{1}", _cust_id,_recipient_id );
		}
		#endregion

		#region Factory Methods
		public static Test NewTest(  )
		{
			return Create();
		}

		public static Test[] GetAllTest(  )
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
					cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "rd.recipient");
                    cm.CommandText = "SELECT recipient.cust_id , recipient.recipient_id ,recipient.rc_surname_company , recipient.rc_first_names  FROM rd.recipient";
					List<Test> _list = new List<Test>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							Test instance = new Test();
                            //instance.StoreFieldValues(dr, "rd.recipient");
                            instance.CustId = GetValueFromReader<Int32?>(dr,0);
                            instance.RecipientId = GetValueFromReader<Int32?>(dr,1);
                            instance.RcSurnameCompany = GetValueFromReader<string>(dr,2);
                            instance.RcFirstNames = GetValueFromReader<string>(dr,3);
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
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateUpdateCommandText(cm, "rd.recipient", ref pList))
				{
					cm.CommandText += " WHERE  rd.recipient.cust_id = @cust_id AND " + 
						"rd.recipient.recipient_id = @recipient_id ";

					pList.Add(cm, "cust_id", GetInitialValue("_cust_id"));
					pList.Add(cm, "recipient_id", GetInitialValue("_recipient_id"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "rd.recipient", pList))
				{
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void DeleteEntity()
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbTransaction tr = cn.BeginTransaction())
				{
					DbCommand cm=cn.CreateCommand();
					cm.Transaction = tr;
					cm.CommandType = CommandType.Text;
						ParameterCollection pList = new ParameterCollection();
					pList.Add(cm,"cust_id", GetInitialValue("_cust_id"));
					pList.Add(cm,"recipient_id", GetInitialValue("_recipient_id"));
						cm.CommandText = "DELETE FROM rd.recipient WHERE " +
						"rd.recipient.cust_id = @cust_id AND " + 
						"rd.recipient.recipient_id = @recipient_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? cust_id, int? recipient_id )
		{
			_cust_id = cust_id;
			_recipient_id = recipient_id;
		}
	}
}

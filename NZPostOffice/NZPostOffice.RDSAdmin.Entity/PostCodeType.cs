using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;using Metex.Core;using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE

    // TJB  RD7_CR001  Nov-2009
    //    Added contract_no (here and below)
    //    [Dec-2009] Also added RdNo
	[MapInfo("post_mail_town", "_post_mail_town", "post_code")]
	[MapInfo("post_district", "_post_district", "post_code")]
	[MapInfo("post_code", "_post_code", "post_code")]
	[MapInfo("post_code_id", "_post_code_id", "post_code",true)]
    [MapInfo("rd_no", "_rd_no", "post_code")]
    [MapInfo("contract_no", "_contract_no", "post_code")]
    [System.Serializable()]

	public class PostCodeType : Entity<PostCodeType>
	{
		#region Business Methods
		[DBField()]
		private string  _post_mail_town;

		[DBField()]
		private string  _post_district;

		[DBField()]
		private string  _post_code;

        [DBField()]
        private int? _post_code_id;

        [DBField()]
        private string _rd_no;

        [DBField()]
        private int? _contract_no;

		public virtual string PostMailTown
		{
			get
			{
				CanReadProperty(true);
				return _post_mail_town;
			}
			set
			{
				CanWriteProperty(true);
				if ( _post_mail_town != value )
				{
					_post_mail_town = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PostDistrict
		{
			get
			{
				CanReadProperty(true);
				return _post_district;
			}
			set
			{
				CanWriteProperty(true);
				if ( _post_district != value )
				{
					_post_district = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PostCode
		{
			get
			{
				CanReadProperty(true);
				return _post_code;
			}
			set
			{
				CanWriteProperty(true);
				if ( _post_code != value )
				{
					_post_code = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual int? PostCodeId
        {
            get
            {
                CanReadProperty(true);
                return _post_code_id;
            }
            set
            {
                CanWriteProperty(true);
                if (_post_code_id != value)
                {
                    _post_code_id = value;
                    PropertyHasChanged();
                }
            }
        }

        // TJB  RD7_CR001  Nov-2009: Added
        public virtual int? ContractNo
        {
            get
            {
                CanReadProperty(true);
                return _contract_no;
            }
            set
            {
                CanWriteProperty(true);
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        // TJB  RD7_CR001  Dec-2009: Added
        public virtual string RdNo
        {
            get
            {
                CanReadProperty(true);
                return _rd_no;
            }
            set
            {
                CanWriteProperty(true);
                if (_rd_no != value)
                {
                    _rd_no = value;
                    PropertyHasChanged();
                }
            }
        }

        private PostCodeType[] dataList;

		protected override object GetIdValue()
		{
			return string.Format( "{0}", _post_code_id );
		}
		#endregion

		#region Factory Methods
        public static PostCodeType NewPostCodeType(int? post_code_id)
		{
            return Create(post_code_id);
		}

		public static PostCodeType[] GetAllPostCodeType(  )
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
					cm.CommandText = "SELECT post_code.post_mail_town" 
                                   +      ", post_code.post_district"
                                   +      ", post_code.post_code"
                                   +      ", post_code.post_code_id"
                                   +      ", post_code.rd_no"
                                   +      ", post_code.contract_no"
                                   + " FROM post_code ";
					ParameterCollection pList = new ParameterCollection();

					List<PostCodeType> list = new List<PostCodeType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PostCodeType instance = new PostCodeType();
                            instance.StoreFieldValues(dr, "post_code");
							instance.MarkOld();
							list.Add(instance);
						}
						dataList = new PostCodeType[list.Count];
						list.CopyTo(dataList);
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
				if (GenerateUpdateCommandText(cm, "post_code", ref pList))
				{
					cm.CommandText += " WHERE post_code.post_mail_town = @post_mail_town " 
						               + "AND post_code.post_district = @post_district " 
						               + "AND post_code.post_code = @post_code ";
					pList.Add(cm, "post_mail_town", GetInitialValue("_post_mail_town"));
					pList.Add(cm, "post_district", GetInitialValue("_post_district"));
					pList.Add(cm, "post_code", GetInitialValue("_post_code"));
					DBHelper.ExecuteNonQuery(cm, pList);
				}
				// reinitialize original key/value list
				StoreInitialValues();
			}
		}
		[ServerMethod()]
		private void InsertEntity()
		{
			using (DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO" ))
			{
				DbCommand cm = cn.CreateCommand();
				cm.CommandType = CommandType.Text;
					ParameterCollection pList = new ParameterCollection();
				if (GenerateInsertCommandText(cm, "post_code", pList))
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
					pList.Add(cm,"post_code_id", GetInitialValue("_post_code_id"));
						cm.CommandText = "DELETE FROM post_code " 
                                        + "WHERE post_code.post_code_id = @post_code_id ";
					DBHelper.ExecuteNonQuery(cm, pList);
					tr.Commit();
				}
			}
		}
		#endregion

		[ServerMethod()]
		private void CreateEntity( int? post_code_id )
		{
			_post_code_id = post_code_id;
		}
	}
}

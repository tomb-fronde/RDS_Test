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
	[MapInfo("nat_ird_no", "_nat_ird_no", "national")]
	[System.Serializable()]

	public class PostIrdNo : Entity<PostIrdNo>
	{
		#region Business Methods
		[DBField()]
		private string  _nat_ird_no;

		public virtual string NatIrdNo
		{
			get
			{
				CanReadProperty(true);
				return _nat_ird_no;
			}
			set
			{
				CanWriteProperty(true);
				if ( _nat_ird_no != value )
				{
					_nat_ird_no = value;
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
		public static PostIrdNo NewPostIrdNo( DateTime? edate )
		{
			return Create(edate);
		}

		public static PostIrdNo[] GetAllPostIrdNo( DateTime? edate )
		{
			return Fetch(edate).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? edate )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "edate", edate);
                    //GenerateSelectCommandText(cm, "national");
                    cm.CommandText = @"SELECT odps.[national].nat_ird_no FROM odps.[national] WHERE ( odps.[national].nat_id = odps.od_blf_getwhichnational(:edate) )   ";

                    List<PostIrdNo> _list = new List<PostIrdNo>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PostIrdNo instance = new PostIrdNo();
                            //instance.StoreFieldValues(dr, "national");
                            instance._nat_ird_no = GetValueFromReader<string>(dr,0);
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDSAdmin.Entity.Security
{
    // TJB  Allowances  17-Apr-2021: New
    // Data for dropdown list for Allowance Calc Types

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
    [MapInfo("alct_id", "_alct_id", "allowance_calc_type")]
    [MapInfo("alct_description", "_alct_description", "allowance_calc_type")]
	[System.Serializable()]

	public class DddwAllowanceCalcType : Entity<DddwAllowanceCalcType>
	{
		#region Business Methods
		[DBField()]
        private int? _alct_id;

		[DBField()]
        private string _alct_description;


		public virtual int? AlctId
		{
			get
			{
				CanReadProperty(true);
                return _alct_id;
			}
			set
			{
				CanWriteProperty(true);
                if (_alct_id != value)
				{
                    _alct_id = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual string AlctDescription
		{
			get
			{
				CanReadProperty(true);
                return _alct_description;
			}
			set
			{
				CanWriteProperty(true);
                if (_alct_description != value)
				{
                    _alct_description = value;
					PropertyHasChanged();
				}
			}
		}
		private DddwAllowanceCalcType[] dataList;

		protected override object GetIdValue()
		{
            return string.Format("{0}", _alct_id);
		}
		#endregion

		#region Factory Methods
		public static DddwAllowanceCalcType NewDddwAllowanceCalcType(  )
		{
			return Create();
		}

		public static DddwAllowanceCalcType[] GetAllDddwAllowanceCalcType(  )
		{
			return Fetch().dataList;
            //return Fetch().list;
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
					ParameterCollection pList = new ParameterCollection();
                    GenerateSelectCommandText(cm, "allowance_calc_type");

					List<DddwAllowanceCalcType> list = new List<DddwAllowanceCalcType>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							DddwAllowanceCalcType instance = new DddwAllowanceCalcType();
                            instance.StoreFieldValues(dr, "allowance_calc_type");
							list.Add(instance);
						}
						dataList = new DddwAllowanceCalcType[list.Count];
						list.CopyTo(dataList);
					}
				}
			}
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? alct_id)
		{
            _alct_id = alct_id;
		}
	}
}

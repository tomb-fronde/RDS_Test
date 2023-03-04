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
	[MapInfo("code", "_code", "")]
	[MapInfo("Desc", "_desc", "")]
	[System.Serializable()]

	public class DddwMailCategoryFixed : Entity<DddwMailCategoryFixed>
	{
		#region Business Methods
		[DBField()]
		private string  _code;

		[DBField()]
		private string  _desc;


		public virtual string Code
		{
			get
			{
                CanReadProperty("Code", true);
				return _code;
			}
			set
			{
                CanWriteProperty("Code", true);
				if ( _code != value )
				{
					_code = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Desc
		{
			get
			{
                CanReadProperty("Desc", true);
				return _desc;
			}
			set
			{
                CanWriteProperty("Desc", true);
				if ( _desc != value )
				{
					_desc = value;
					PropertyHasChanged();
				}
			}
		}

		protected override object GetIdValue()
		{
			return _code + "";
		}
		#endregion

		#region Factory Methods
		public static DddwMailCategoryFixed NewDddwMailCategoryFixed(  )
		{
			return Create();
		}

		public static DddwMailCategoryFixed[] GetAllDddwMailCategoryFixed(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
        //Exterior Data
        [ServerMethod]
        private void FetchEntity()
        {
            //data("A","<All Customer Categories>","B","Business","R","Rural Residential","F","Rural Farmer",) 
            List<DddwMailCategoryFixed> _list = new List<DddwMailCategoryFixed>();
            DddwMailCategoryFixed instance = new DddwMailCategoryFixed();
            instance._code = "A";
            instance._desc = "<All Customer Categories>";
            instance.MarkOld();
            _list.Add(instance);

            instance = new DddwMailCategoryFixed();
            instance._code = "B";
            instance._desc = "Business";
            instance.MarkOld();
            _list.Add(instance);

            instance = new DddwMailCategoryFixed();
            instance._code = "R";
            instance._desc = "Rural Residential";
            instance.MarkOld();
            _list.Add(instance);

            instance = new DddwMailCategoryFixed();
            instance._code = "F";
            instance._desc = "Rural Farmer";
            instance.MarkOld();
            _list.Add(instance);
            list = _list.ToArray();
        }

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}

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
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("sf_key", "_sf_key", "")]
	[MapInfo("rf_delivery_days", "_rf_delivery_days", "")]
	[System.Serializable()]

	public class ContractNoEntry2001 : Entity<ContractNoEntry2001>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _sf_key;

		[DBField()]
		private string  _rf_delivery_days;

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

        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                if (_rf_delivery_days == null)
                    return "";

                char symbol = (char)((byte)(0xFC));

                return (_rf_delivery_days.Substring(0, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        public virtual string Compute2
        {
            get
            {
                CanReadProperty("Compute2", true); 
                if (_rf_delivery_days == null)
                    return "";

                //PP! used CharacterCode instead of hardcoding the character as it depends on character set of the client machine
                char symbol = (char)((byte)(0xFC));

                //!return (_rf_delivery_days.Substring(1, 1) == "Y" ? "จน" : "");
                return (_rf_delivery_days.Substring(1, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        public virtual string Compute3
        {
            get
            {
                CanReadProperty("Compute3", true);
                if (_rf_delivery_days == null)
                    return "";

                char symbol = (char)((byte)(0xFC));

                return (_rf_delivery_days.Substring(2, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        public virtual string Compute4
        {
            get
            {
                CanReadProperty("Compute4", true);
                if (_rf_delivery_days == null)
                    return "";

                char symbol = (char)((byte)(0xFC));

                return (_rf_delivery_days.Substring(3, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        public virtual string Compute5
        {
            get
            {
                CanReadProperty("Compute5", true);
                if (_rf_delivery_days == null)
                    return "";

                char symbol = (char)((byte)(0xFC));

                return (_rf_delivery_days.Substring(4, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        public virtual string Compute6
        {
            get
            {
                CanReadProperty("Compute6", true);
                if (_rf_delivery_days == null)
                    return "";

                char symbol = (char)((byte)(0xFC));


                return (_rf_delivery_days.Substring(5, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        public virtual string Compute7
        {
            get
            {
                CanReadProperty("Compute7", true);
                if (_rf_delivery_days == null)
                    return "";

                char symbol = (char)((byte)(0xFC));

                return (_rf_delivery_days.Substring(6, 1) == "Y" ? new string(new char[] { symbol }) : "");
            }
        }

        protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static ContractNoEntry2001 NewContractNoEntry2001(  )
		{
			return Create();
		}

		public static ContractNoEntry2001[] GetAllContractNoEntry2001(  )
		{
			return Fetch().list;
		}
		#endregion

		#region Data Access
        //Exterior
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<ContractNoEntry2001> _list = new List<ContractNoEntry2001>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    ContractNoEntry2001 instance = new ContractNoEntry2001();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

		#endregion

		[ServerMethod()]
		private void CreateEntity(  )
		{
		}
	}
}

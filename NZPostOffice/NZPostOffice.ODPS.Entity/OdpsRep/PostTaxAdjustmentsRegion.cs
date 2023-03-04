using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("pcd_amount", "_pcd_amount", "")]
	[MapInfo("ded_description", "_ded_description", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("region", "_region", "")]
	[System.Serializable()]

	public class PostTaxAdjustmentsRegion : Entity<PostTaxAdjustmentsRegion>
	{
		#region Business Methods
		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private decimal?  _pcd_amount;

		[DBField()]
		private string  _ded_description;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _region;

		public virtual string CSurnameCompany
		{
			get
			{
				CanReadProperty("CSurnameCompany",true);
				return _c_surname_company;
			}
			set
			{
				CanWriteProperty("CSurnameCompany",true);
				if ( _c_surname_company != value )
				{
					_c_surname_company = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string CFirstNames
		{
			get
			{
				CanReadProperty("CFirstNames",true);
				return _c_first_names;
			}
			set
			{
				CanWriteProperty("CFirstNames",true);
				if ( _c_first_names != value )
				{
					_c_first_names = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? PcdAmount
		{
			get
			{
				CanReadProperty("PcdAmount",true);
				return _pcd_amount;
			}
			set
			{
				CanWriteProperty("PcdAmount",true);
				if ( _pcd_amount != value )
				{
					_pcd_amount = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REPcdAmount
        {
            get
            {
                return (decimal)_pcd_amount;
            }
        }

		public virtual string DedDescription
		{
			get
			{
				CanReadProperty("DedDescription",true);
				return _ded_description;
			}
			set
			{
				CanWriteProperty("DedDescription",true);
				if ( _ded_description != value )
				{
					_ded_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? ContractNo
		{
			get
			{
				CanReadProperty("ContractNo",true);
				return _contract_no;
			}
			set
			{
				CanWriteProperty("ContractNo",true);
				if ( _contract_no != value )
				{
					_contract_no = value;
					PropertyHasChanged();
				}
			}
		}

        public int REContractNo
        {
            get
            {
                return (int)_contract_no;
            }
        }

		public virtual string Region
		{
			get
			{
				CanReadProperty("Region",true);
				return _region;
			}
			set
			{
				CanWriteProperty("Region",true);
				if ( _region != value )
				{
					_region = value;
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
		public static PostTaxAdjustmentsRegion NewPostTaxAdjustmentsRegion( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static PostTaxAdjustmentsRegion[] GetAllPostTaxAdjustmentsRegion( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Fetch(sdate, edate, inregion).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( DateTime? sdate, DateTime? edate, int? inregion )
		{
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_posttaxadjustments_region";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<PostTaxAdjustmentsRegion> _list = new List<PostTaxAdjustmentsRegion>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							PostTaxAdjustmentsRegion instance = new PostTaxAdjustmentsRegion();
                            instance._c_surname_company = GetValueFromReader<string>(dr, 0);
                            instance._c_first_names = GetValueFromReader<string>(dr, 1);
                            instance._pcd_amount = GetValueFromReader<decimal?>(dr, 2);
                            instance._ded_description = GetValueFromReader<string>(dr, 3);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 4);
                            instance._region = GetValueFromReader<string>(dr, 5);
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

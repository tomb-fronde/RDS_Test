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
	[MapInfo("rgn_name", "_rgn_name", "")]
	[MapInfo("c_surname_company", "_c_surname_company", "")]
	[MapInfo("c_first_names", "_c_first_names", "")]
	[MapInfo("prs_description", "_prs_description", "")]
	[MapInfo("prt_description", "_prt_description", "")]
	[MapInfo("pcpr_volume", "_pcpr_volume", "")]
	[MapInfo("pcpr_value", "_pcpr_value", "")]
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("conttype", "_conttype", "")]
	[System.Serializable()]

	public class VolumesValueDetail : Entity<VolumesValueDetail>
	{
		#region Business Methods
		[DBField()]
		private string  _rgn_name;

		[DBField()]
		private string  _c_surname_company;

		[DBField()]
		private string  _c_first_names;

		[DBField()]
		private string  _prs_description;

		[DBField()]
		private string  _prt_description;

		[DBField()]
		private int?  _pcpr_volume;

		[DBField()]
		private decimal?  _pcpr_value;

		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _conttype;

		public virtual string RgnName
		{
			get
			{
				CanReadProperty("RgnName",true);
				return _rgn_name;
			}
			set
			{
				CanWriteProperty("RgnName",true);
				if ( _rgn_name != value )
				{
					_rgn_name = value;
					PropertyHasChanged();
				}
			}
		}

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

		public virtual string PrsDescription
		{
			get
			{
				CanReadProperty("PrsDescription",true);
				return _prs_description;
			}
			set
			{
				CanWriteProperty("PrsDescription",true);
				if ( _prs_description != value )
				{
					_prs_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrtDescription
		{
			get
			{
				CanReadProperty("PrtDescription",true);
				return _prt_description;
			}
			set
			{
				CanWriteProperty("PrtDescription",true);
				if ( _prt_description != value )
				{
					_prt_description = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? PcprVolume
		{
			get
			{
				CanReadProperty("PcprVolume",true);
				return _pcpr_volume;
			}
			set
			{
				CanWriteProperty("PcprVolume",true);
				if ( _pcpr_volume != value )
				{
					_pcpr_volume = value;
					PropertyHasChanged();
				}
			}
		}

        public int REPcprVolume
        {
            get
            {
                return (int)_pcpr_volume;
            }
        }

		public virtual decimal? PcprValue
		{
			get
			{
				CanReadProperty("PcprValue",true);
				return _pcpr_value;
			}
			set
			{
				CanWriteProperty("PcprValue",true);
				if ( _pcpr_value != value )
				{
					_pcpr_value = value;
					PropertyHasChanged();
				}
			}
		}

        public decimal REPcprValue
        {
            get
            {
                return (decimal)_pcpr_value;
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

		public virtual string Conttype
		{
			get
			{
				CanReadProperty("Conttype",true);
				return _conttype;
			}
			set
			{
				CanWriteProperty("Conttype",true);
				if ( _conttype != value )
				{
					_conttype = value;
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
		public static VolumesValueDetail NewVolumesValueDetail( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static VolumesValueDetail[] GetAllVolumesValueDetail( DateTime? sdate, DateTime? edate, int? inregion )
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
                    cm.CommandText = "odps.od_rps_volumesvalues_detailv2";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<VolumesValueDetail> _list = new List<VolumesValueDetail>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VolumesValueDetail instance = new VolumesValueDetail();
                            instance._rgn_name = GetValueFromReader<string>(dr, 0);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 1);
                            instance._c_first_names = GetValueFromReader<string>(dr, 2);
                            instance._prs_description = GetValueFromReader<string>(dr, 3);
                            instance._prt_description = GetValueFromReader<string>(dr, 4);
                            instance._pcpr_volume = GetValueFromReader<Int32?>(dr, 5);
                            instance._pcpr_value = GetValueFromReader<decimal?>(dr, 6);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 7);
                            instance._conttype = GetValueFromReader<string>(dr, 8);
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // TJB  RPCR_059  Jan-2014
    // Added Prs5name, Prs5volume, Prs5Value
    // Removed Adpost, Courierpost, Skyroad, Parcelpost volumes and values
    // replaced with Prs<n> volume & value
    // Added Prs[1-4]name
    // Moved Conttype to follow Name
    // See OD_RPS_VolumesValues_Summary.sql
    
    // Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("region",     "_region", "")]
	[MapInfo("name",       "_c_surname_company", "")]
    [MapInfo("conttype",   "_conttype", "")]
    [MapInfo("prs1name",   "_prs1name", "")]
    [MapInfo("prs1volume", "_prs1volume", "")]
    [MapInfo("prs1value",  "_prs1value", "")]
    [MapInfo("prs2name",   "_prs2name", "")]
    [MapInfo("prs2volume", "_prs2volume", "")]
    [MapInfo("prs2value",  "_prs2value", "")]
    [MapInfo("prs3name",   "_prs3name", "")]
    [MapInfo("prs3volume", "_prs3volume", "")]
    [MapInfo("prs3value",  "_prs3value", "")]
    [MapInfo("prs4name",   "_prs4name", "")]
    [MapInfo("prs4volume", "_prs4volume", "")]
    [MapInfo("prs4value",  "_prs4value", "")]
    [MapInfo("prs5name",   "_prs5name", "")]
    [MapInfo("prs5volume", "_prs5volume", "")]
    [MapInfo("prs5value",  "_prs5value", "")]
    
    [System.Serializable()]

	public class VolumesValueSummary : Entity<VolumesValueSummary>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private string  _region;

		[DBField()]
		private string  _c_surname_company;

        [DBField()]
        private string _conttype;

        [DBField()]
        private string _prs1name;

        [DBField()]
		private decimal?  _prs1volume;

		[DBField()]
        private decimal? _prs1value;

        [DBField()]
        private string _prs2name;

        [DBField()]
        private decimal? _prs2volume;

        [DBField()]
        private decimal? _prs2value;

        [DBField()]
        private string _prs3name;

        [DBField()]
        private decimal? _prs3volume;

        [DBField()]
        private decimal? _prs3value;

        [DBField()]
        private string _prs4name;

        [DBField()]
        private decimal? _prs4volume;

        [DBField()]
        private decimal? _prs4value;

        [DBField()]
        private string _prs5name;

        [DBField()]
        private decimal? _prs5volume;

        [DBField()]
        private decimal? _prs5value;

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

        public virtual string Conttype
        {
            get
            {
                CanReadProperty("Conttype", true);
                return _conttype;
            }
            set
            {
                CanWriteProperty("Conttype", true);
                if (_conttype != value)
                {
                    _conttype = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Prs1name
        {
            get
            {
                CanReadProperty("Prs1name", true);
                return _prs1name;
            }
            set
            {
                CanWriteProperty("Prs1name", true);
                if (_prs1name != value)
                {
                    _prs1name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs1volume
        {
            get
            {
                CanReadProperty("Prs1volume", true);
                return _prs1volume;
            }
            set
            {
                CanWriteProperty("Prs1volume", true);
                if (_prs1volume != value)
                {
                    _prs1volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs1value
        {
            get
            {
                CanReadProperty("Prs1value", true);
                return _prs1value;
            }
            set
            {
                CanWriteProperty("Prs1value", true);
                if (_prs1value != value)
                {
                    _prs1value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Prs2name
        {
            get
            {
                CanReadProperty("Prs2name", true);
                return _prs2name;
            }
            set
            {
                CanWriteProperty("Prs2name", true);
                if (_prs2name != value)
                {
                    _prs2name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs2volume
        {
            get
            {
                CanReadProperty("Prs2volume", true);
                return _prs2volume;
            }
            set
            {
                CanWriteProperty("Prs2volume", true);
                if (_prs2volume != value)
                {
                    _prs2volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs2value
        {
            get
            {
                CanReadProperty("Prs2value", true);
                return _prs2value;
            }
            set
            {
                CanWriteProperty("Prs2value", true);
                if (_prs2value != value)
                {
                    _prs2value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Prs3name
        {
            get
            {
                CanReadProperty("Prs3name", true);
                return _prs3name;
            }
            set
            {
                CanWriteProperty("Prs3name", true);
                if (_prs3name != value)
                {
                    _prs3name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs3volume
        {
            get
            {
                CanReadProperty("Prs3volume", true);
                return _prs3volume;
            }
            set
            {
                CanWriteProperty("Prs3volume", true);
                if (_prs3volume != value)
                {
                    _prs3volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs3value
        {
            get
            {
                CanReadProperty("Prs3value", true);
                return _prs3value;
            }
            set
            {
                CanWriteProperty("Prs3value", true);
                if (_prs3value != value)
                {
                    _prs3value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Prs4name
        {
            get
            {
                CanReadProperty("Prs4name", true);
                return _prs4name;
            }
            set
            {
                CanWriteProperty("Prs4name", true);
                if (_prs4name != value)
                {
                    _prs4name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs4volume
        {
            get
            {
                CanReadProperty("Prs4volume", true);
                return _prs4volume;
            }
            set
            {
                CanWriteProperty("Prs4volume", true);
                if (_prs4volume != value)
                {
                    _prs4volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs4value
        {
            get
            {
                CanReadProperty("Prs4value", true);
                return _prs4value;
            }
            set
            {
                CanWriteProperty("Prs4value", true);
                if (_prs4value != value)
                {
                    _prs4value = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Prs5name
        {
            get
            {
                CanReadProperty("Prs5name", true);
                return _prs5name;
            }
            set
            {
                CanWriteProperty("Prs5name", true);
                if (_prs5name != value)
                {
                    _prs5name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs5volume
        {
            get
            {
                CanReadProperty("Prs5volume", true);
                return _prs5volume;
            }
            set
            {
                CanWriteProperty("Prs5volume", true);
                if (_prs5volume != value)
                {
                    _prs5volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Prs5value
        {
            get
            {
                CanReadProperty("Prs5value", true);
                return _prs5value;
            }
            set
            {
                CanWriteProperty("Prs5value", true);
                if (_prs5value != value)
                {
                    _prs5value = value;
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
		public static VolumesValueSummary NewVolumesValueSummary( DateTime? sdate, DateTime? edate, int? inregion )
		{
			return Create(sdate, edate, inregion);
		}

		public static VolumesValueSummary[] GetAllVolumesValueSummary( DateTime? sdate, DateTime? edate, int? inregion )
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
                    cm.CommandText = "odps.OD_RPS_VolumesValues_Summary";
					ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "sdate", sdate);
					pList.Add(cm, "edate", edate);
					pList.Add(cm, "inregion", inregion);

					List<VolumesValueSummary> _list = new List<VolumesValueSummary>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
						while (dr.Read())
						{
							VolumesValueSummary instance = new VolumesValueSummary();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._region = GetValueFromReader<string>(dr, 1);
                            instance._c_surname_company = GetValueFromReader<string>(dr, 2);
                            instance._conttype = GetValueFromReader<string>(dr, 3);
                            instance._prs1name = GetValueFromReader<string>(dr, 4);
                            instance._prs1volume = GetValueFromReader<decimal?>(dr, 5);
                            instance._prs1value = GetValueFromReader<decimal?>(dr, 6);
                            instance._prs2name = GetValueFromReader<string>(dr, 7);
                            instance._prs2volume = GetValueFromReader<decimal?>(dr, 8);
                            instance._prs2value = GetValueFromReader<decimal?>(dr, 9);
                            instance._prs3name = GetValueFromReader<string>(dr, 10);
                            instance._prs3volume = GetValueFromReader<decimal?>(dr, 11);
                            instance._prs3value = GetValueFromReader<decimal?>(dr, 12);
                            instance._prs4name = GetValueFromReader<string>(dr, 13);
                            instance._prs4volume = GetValueFromReader<decimal?>(dr, 14);
                            instance._prs4value = GetValueFromReader<decimal?>(dr, 15);
                            instance._prs5name = GetValueFromReader<string>(dr, 16);
                            instance._prs5volume = GetValueFromReader<decimal?>(dr, 17);
                            instance._prs5value = GetValueFromReader<decimal?>(dr, 18);
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

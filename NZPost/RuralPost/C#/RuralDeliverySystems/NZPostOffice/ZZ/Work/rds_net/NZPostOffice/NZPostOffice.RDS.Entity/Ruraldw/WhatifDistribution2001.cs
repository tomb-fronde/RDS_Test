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
    [MapInfo("from", "_from", "")]
    [MapInfo("to", "_to", "")]
    [MapInfo("contracts", "_contracts", "")]
    [MapInfo("sort", "_sort", "")]
    [MapInfo("percent", "_percent", "")]
    [MapInfo("sumcontracts", "_sumcontracts", "")]
    [System.Serializable()]

    public class WhatifDistribution2001 : Entity<WhatifDistribution2001>
    {
        #region Business Methods
        [DBField()]
        private double? _from;

        [DBField()]
        private double? _to;

        [DBField()]
        private int? _contracts;

        [DBField()]
        private int? _sort;

        [DBField()]
        private int? _percent;

        [DBField()]
        private int? _sumcontracts;

        public virtual double? From
        {
            get
            {
                CanReadProperty("From", true);
                return _from;
            }
            set
            {
                CanWriteProperty("From", true);
                if (_from != value)
                {
                    _from = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual double? REFrom
        {
            get
            {
                return _from;
            }
        }

        public virtual double? To
        {
            get
            {
                CanReadProperty("To", true);
                return _to;
            }
            set
            {
                CanWriteProperty("To", true);
                if (_to != value)
                {
                    _to = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual double? RETo
        {
            get
            {
                return _to;
            }
        }

        public virtual int? Contracts
        {
            get
            {
                CanReadProperty("Contracts", true);
                return _contracts;
            }
            set
            {
                CanWriteProperty("Contracts", true);
                if (_contracts != value)
                {
                    _contracts = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? REContracts
        {
            get
            {
                return _contracts;
            }

        }

        public virtual int? Sort
        {
            get
            {
                CanReadProperty("Sort", true);
                return _sort;
            }
            set
            {
                CanWriteProperty("Sort", true);
                if (_sort != value)
                {
                    _sort = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RESort
        {
            get
            {
                return _sort;
            }
        }

        public virtual int? Percent
        {
            get
            {
                CanReadProperty("Percent", true);
                return _percent;
            }
            set
            {
                CanWriteProperty("Percent", true);
                if (_percent != value)
                {
                    _percent = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? REPercent
        {
            get
            {
                return _percent;
            }
        }

        public virtual int? Sumcontracts
        {
            get
            {
                CanReadProperty("Sumcontracts", true);
                return _sumcontracts;
            }
            set
            {
                CanWriteProperty("Sumcontracts", true);
                if (_sumcontracts != value)
                {
                    _sumcontracts = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RESumcontracts
        {
            get
            {
                return _sumcontracts;
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[percent_sumcontracts]
        //string((  sumcontracts  / 100 )* (100 / sum(contracts)), '##0%')
        public virtual string PercentSumcontracts
        {
            get
            {
                CanReadProperty("PercentSumcontracts", true);
                return "";//return ((_sumcontracts  / 100 )* (100 / sum(contracts)), '##0%');
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[rangefrom]
        //if(from = -11000 ,'<;(10000)',if(from = -0.001,'',if(from=0.001,'0',string(from,'#####;(#####)'))))
        public virtual string Rangefrom
        {
            get
            {
                CanReadProperty("Rangefrom", true);
                return (_from == -11000 ? "<(10000)" : (_from == -0.001 ? "" : (_from == 0.001 ? "0" : _from.GetValueOrDefault().ToString("#####;(#####)"))));
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[rangeto]
        //if(to >; 10000 ,'>;10000',if(to=0.000,'0',if(to=-0.001,'0',string(to,'#####;(#####)'))))
        public virtual string Rangeto
        {
            get
            {
                CanReadProperty("Rangeto", true);
                return (_to > 10000 ? ">10000" : (_to == 0.000 ? "0" : (_to == -0.001 ? "0" : _to.GetValueOrDefault().ToString("#####;(#####)"))));
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[percent_contracts]
        //string(( contracts / 100 )* (100 / sum(contracts)),'##0%')
        public virtual string PercentContracts
        {
            get
            {
                CanReadProperty("PercentContracts", true);
                return "";//return string(( contracts / 100 )* (100 / sum(contracts)),'##0%');
            }
        }

        public virtual string Compute4
        {
            get
            {
                CanReadProperty("Compute4", true);
                return DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static WhatifDistribution2001 NewWhatifDistribution2001()
        {
            return Create();
        }

        public static WhatifDistribution2001[] GetAllWhatifDistribution2001()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<WhatifDistribution2001> _list = new List<WhatifDistribution2001>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    WhatifDistribution2001 instance = new WhatifDistribution2001();
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
        private void CreateEntity()
        {
        }
    }
}

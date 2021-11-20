using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("name_of_organisation", "_name_of_organisation", "")]
    [MapInfo("trading_name", "_trading_name", "")]
    [MapInfo("type_of_service", "_type_of_service", "")]

    [MapInfo("gst", "_gst", "")]
    [MapInfo("rural_post_gst_number", "_rural_post_gst_number", "")]
    [MapInfo("rural_post_address", "_rural_post_address", "")]

    [MapInfo("name_of_payer", "_name_of_payer", "")]
    [MapInfo("date_of_printing", "_date_of_printing", "")]
    [MapInfoIndex(new string[] { 
        "name_of_organisation", "trading_name", "type_of_service", 
        "gst", "rural_post_gst_number", "rural_post_address",
        "name_of_payer", "date_of_printing"})]
    [System.Serializable()]

    public class Ir13InterfaceHeader : Entity<Ir13InterfaceHeader>
    {
        #region Business Methods
        [DBField()]
        private string _name_of_organisation;

        [DBField()]
        private string _trading_name;

        [DBField()]
        private string _type_of_service;

        [DBField()]
        private string _gst;

        [DBField()]
        private string _rural_post_gst_number;

        [DBField()]
        private string _rural_post_address;

        [DBField()]
        private string _name_of_payer;

        [DBField()]
        private DateTime? _date_of_printing;

        public virtual string NameOfOrganisation
        {
            get
            {
                CanReadProperty("NameOfOrganisation", true);
                return _name_of_organisation;
            }
            set
            {
                CanWriteProperty("NameOfOrganisation", true);
                if (_name_of_organisation != value)
                {
                    _name_of_organisation = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TradingName
        {
            get
            {
                CanReadProperty("TradingName", true);
                return _trading_name;
            }
            set
            {
                CanWriteProperty("TradingName", true);
                if (_trading_name != value)
                {
                    _trading_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TypeOfService
        {
            get
            {
                CanReadProperty("TypeOfService", true);
                return _type_of_service;
            }
            set
            {
                CanWriteProperty("TypeOfService", true);
                if (_type_of_service != value)
                {
                    _type_of_service = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Gst
        {
            get
            {
                CanReadProperty("Gst", true);
                return _gst;
            }
            set
            {
                CanWriteProperty("Gst", true);
                if (_gst != value)
                {
                    _gst = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RuralPostGstNumber
        {
            get
            {
                CanReadProperty("RuralPostGstNumber", true);
                return _rural_post_gst_number;
            }
            set
            {
                CanWriteProperty("RuralPostGstNumber", true);
                if (_rural_post_gst_number != value)
                {
                    _rural_post_gst_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RuralPostAddress
        {
            get
            {
                CanReadProperty("RuralPostAddress", true);
                return _rural_post_address;
            }
            set
            {
                CanWriteProperty("RuralPostAddress", true);
                if (_rural_post_address != value)
                {
                    _rural_post_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NameOfPayer
        {
            get
            {
                CanReadProperty("NameOfPayer", true);
                return _name_of_payer;
            }
            set
            {
                CanWriteProperty("NameOfPayer", true);
                if (_name_of_payer != value)
                {
                    _name_of_payer = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? DateOfPrinting
        {
            get
            {
                CanReadProperty("DateOfPrinting", true);
                return _date_of_printing;
            }
            set
            {
                CanWriteProperty("DateOfPrinting", true);
                if (_date_of_printing != value)
                {
                    _date_of_printing = value;
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
        public static Ir13InterfaceHeader NewIr13InterfaceHeader(DateTime? Procdate)
        {
            return Create(Procdate);
        }

        public static Ir13InterfaceHeader[] GetAllIr13InterfaceHeader(DateTime? Procdate)
        {
            return Fetch(Procdate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? Procdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_ir13_interface_header";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "Procdate", Procdate);

                    List<Ir13InterfaceHeader> _list = new List<Ir13InterfaceHeader>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            Ir13InterfaceHeader instance = new Ir13InterfaceHeader();
                            instance.NameOfOrganisation = GetValueFromReader<string>(dr, 0);
                            instance.TradingName = GetValueFromReader<string>(dr, 1);
                            instance.TypeOfService = GetValueFromReader<string>(dr, 2);
                            instance.Gst = GetValueFromReader<string>(dr, 3);
                            instance.RuralPostGstNumber = GetValueFromReader<string>(dr, 4);
                            instance.RuralPostAddress = GetValueFromReader<string>(dr, 5);
                            instance.NameOfPayer = GetValueFromReader<string>(dr, 6);
                            instance.DateOfPrinting = GetValueFromReader<DateTime?>(dr, 7);
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
        private void CreateEntity()
        {
        }
    }
}

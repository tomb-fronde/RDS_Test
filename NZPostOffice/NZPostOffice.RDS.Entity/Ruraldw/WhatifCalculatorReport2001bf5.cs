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
    [MapInfo("contract_seq_number", "_contract_seq_number", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("nominalvehical", "_nominalvehical", "")]
    [MapInfo("wagehourlyrate", "_wagehourlyrate", "")]
    [MapInfo("repairsmaint", "_repairsmaint", "")]
    [MapInfo("tyrestubes", "_tyrestubes", "")]
    [MapInfo("vehicalallow", "_vehicalallow", "")]
    [MapInfo("vehicalinsure", "_vehicalinsure", "")]
    [MapInfo("publiclia", "_publiclia", "")]
    [MapInfo("carrierrisk", "_carrierrisk", "")]
    [MapInfo("accrate", "_accrate", "")]
    [MapInfo("licence", "_licence", "")]
    [MapInfo("rateofreturn", "_rateofreturn", "")]
    [MapInfo("salvageratio", "_salvageratio", "")]
    [MapInfo("itemshour", "_itemshour", "")]
    [MapInfo("fuel", "_fuel", "")]
    [MapInfo("consumption", "_consumption", "")]
    [MapInfo("routedistance", "_routedistance", "")]
    [MapInfo("deliveryhours", "_deliveryhours", "")]
    [MapInfo("processinghours", "_processinghours", "")]
    [MapInfo("volume", "_volume", "")]
    [MapInfo("deliverydays", "_deliverydays", "")]
    [MapInfo("maxdeliverydays", "_maxdeliverydays", "")]
    [MapInfo("numberboxholders", "_numberboxholders", "")]
    [MapInfo("routedistanceperday", "_routedistanceperday", "")]
    [MapInfo("vehicledepreciation", "_vehicledepreciation", "")]
    [MapInfo("fuelcostperannum", "_fuelcostperannum", "")]
    [MapInfo("repairsperannum", "_repairsperannum", "")]
    [MapInfo("tyrestubesperannum", "_tyrestubesperannum", "")]
    [MapInfo("deliverycost", "_deliverycost", "")]
    [MapInfo("processingcost", "_processingcost", "")]
    [MapInfo("publicliabilitycost", "_publicliabilitycost", "")]
    [MapInfo("accperannum", "_accperannum", "")]
    [MapInfo("vehicleinsurance", "_vehicleinsurance", "")]
    [MapInfo("licensing", "_licensing", "")]
    [MapInfo("carrierriskrate", "_carrierriskrate", "")]
    [MapInfo("benchmark", "_benchmark", "")]
    [MapInfo("rateofreturnll", "_rateofreturn_1", "")]
    [MapInfo("finalbenchmark", "_finalbenchmark", "")]
    [MapInfo("retainedallowances", "_retainedallowances", "")]
    [MapInfo("currentpayment", "_currentpayment", "")]
    [MapInfo("sf_key", "_sf_key", "")]
    [MapInfo("rf_distance", "_rf_distance", "")]
    [MapInfo("rf_deliverydays", "_rf_deliverydays", "")]
    [MapInfo("rf_daysyear", "_rf_daysyear", "")]
    [MapInfo("rf_daysweek", "_rf_daysweek", "")]
    [MapInfo("itemspercust", "_itemspercust", "")]
    [MapInfo("rf_active", "_rf_active", "")]
    [MapInfo("firstrow", "_firstrow", "")]
    [MapInfo("currentbenchmark", "_currentbenchmark", "")]
    [MapInfo("Accounting", "_accounting", "")]
    [MapInfo("Telephone", "_telephone", "")]
    [MapInfo("Sundries", "_sundries", "")]
    [MapInfo("RUC", "_ruc", "")]
    [MapInfo("rrrate_nomvehicle", "_rrrate_nomvehicle", "")]
    [MapInfo("rrrate_wage", "_rrrate_wage", "")]
    [MapInfo("rrrate_repairsmaint", "_rrrate_repairsmaint", "")]
    [MapInfo("rrrate_tyretubes", "_rrrate_tyretubes", "")]
    [MapInfo("rrrate_vehallow", "_rrrate_vehallow", "")]
    [MapInfo("rrrate_vehinsurance", "_rrrate_vehinsurance", "")]
    [MapInfo("rrrate_publiclia", "_rrrate_publiclia", "")]
    [MapInfo("rrrate_carrierrisk", "_rrrate_carrierrisk", "")]
    [MapInfo("rrrate_acc", "_rrrate_acc", "")]
    [MapInfo("rrrate_license", "_rrrate_license", "")]
    [MapInfo("rrrate_vehrateofreturn", "_rrrate_vehrateofreturn", "")]
    [MapInfo("rrrate_salvageratio", "_rrrate_salvageratio", "")]
    [MapInfo("rrrate_itemprocrate", "_rrrate_itemprocrate", "")]
    [MapInfo("rrrate_ruc", "_rrrate_ruc", "")]
    [MapInfo("rrrate_accounting", "_rrrate_accounting", "")]
    [MapInfo("rrrate_telephone", "_rrrate_telephone", "")]
    [MapInfo("rrrate_sundries", "_rrrate_sundries", "")]
    [MapInfo("rrrate_sundriesK", "_rrrate_sundriesk", "")]
    [MapInfo("SundriesK", "_sundriesk", "")]
    [MapInfo("nMultiplier", "_nmultiplier", "")]
    [MapInfo("nInsurancePct", "_ninsurancepct", "")]
    [MapInfo("nLivery", "_nlivery", "")]
    [MapInfo("nUniform", "_nuniform", "")]
    [MapInfo("nACCAmount", "_naccamount", "")]
    [MapInfo("nVtKey", "_nvtkey", "")]
    [System.Serializable()]

    public class WhatifCalculatorReport2001bf5 : Entity<WhatifCalculatorReport2001bf5>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private int? _contract_seq_number;

        [DBField()]
        private string _con_title;

        [DBField()]
        private decimal? _nominalvehical;

        [DBField()]
        private decimal? _wagehourlyrate;

        [DBField()]
        private decimal? _repairsmaint;

        [DBField()]
        private decimal? _tyrestubes;

        [DBField()]
        private decimal? _vehicalallow;

        [DBField()]
        private decimal? _vehicalinsure;

        [DBField()]
        private decimal? _publiclia;

        [DBField()]
        private decimal? _carrierrisk;

        [DBField()]
        private decimal? _accrate;

        [DBField()]
        private decimal? _licence;

        [DBField()]
        private decimal? _rateofreturn;

        [DBField()]
        private decimal? _salvageratio;

        [DBField()]
        private decimal? _itemshour;

        [DBField()]
        private decimal? _fuel;

        [DBField()]
        private decimal? _consumption;

        [DBField()]
        private decimal? _routedistance;

        [DBField()]
        private decimal? _deliveryhours;

        [DBField()]
        private decimal? _processinghours;

        [DBField()]
        private decimal? _volume;

        [DBField()]
        private decimal? _deliverydays;

        [DBField()]
        private decimal? _maxdeliverydays;

        [DBField()]
        private int? _numberboxholders;

        [DBField()]
        private int? _routedistanceperday;

        [DBField()]
        private int? _vehicledepreciation;

        [DBField()]
        private int? _fuelcostperannum;

        [DBField()]
        private int? _repairsperannum;

        [DBField()]
        private int? _tyrestubesperannum;

        [DBField()]
        private int? _deliverycost;

        [DBField()]
        private int? _processingcost;

        [DBField()]
        private int? _publicliabilitycost;

        [DBField()]
        private int? _accperannum;

        [DBField()]
        private int? _vehicleinsurance;

        [DBField()]
        private int? _licensing;

        [DBField()]
        private int? _carrierriskrate;

        [DBField()]
        private int? _benchmark;

        [DBField()]
        private int? _rateofreturn_1;

        [DBField()]
        private int? _finalbenchmark;

        [DBField()]
        private decimal? _retainedallowances;

        [DBField()]
        private decimal? _currentpayment;

        [DBField()]
        private int? _sf_key;

        [DBField()]
        private decimal? _rf_distance;

        [DBField()]
        private string _rf_deliverydays;

        [DBField()]
        private int? _rf_daysyear;

        [DBField()]
        private int? _rf_daysweek;

        [DBField()]
        private decimal? _itemspercust;

        [DBField()]
        private string _rf_active;

        [DBField()]
        private string _firstrow;

        [DBField()]
        private decimal? _currentbenchmark;

        [DBField()]
        private decimal? _accounting;

        [DBField()]
        private decimal? _telephone;

        [DBField()]
        private decimal? _sundries;

        [DBField()]
        private decimal? _ruc;

        [DBField()]
        private decimal? _rrrate_nomvehicle;

        [DBField()]
        private decimal? _rrrate_wage;

        [DBField()]
        private decimal? _rrrate_repairsmaint;

        [DBField()]
        private decimal? _rrrate_tyretubes;

        [DBField()]
        private decimal? _rrrate_vehallow;

        [DBField()]
        private decimal? _rrrate_vehinsurance;

        [DBField()]
        private decimal? _rrrate_publiclia;

        [DBField()]
        private decimal? _rrrate_carrierrisk;

        [DBField()]
        private decimal? _rrrate_acc;

        [DBField()]
        private decimal? _rrrate_license;

        [DBField()]
        private decimal? _rrrate_vehrateofreturn;

        [DBField()]
        private decimal? _rrrate_salvageratio;

        [DBField()]
        private decimal? _rrrate_itemprocrate;

        [DBField()]
        private decimal? _rrrate_ruc;

        [DBField()]
        private decimal? _rrrate_accounting;

        [DBField()]
        private decimal? _rrrate_telephone;

        [DBField()]
        private decimal? _rrrate_sundries;

        [DBField()]
        private decimal? _rrrate_sundriesk;

        [DBField()]
        private decimal? _sundriesk;

        [DBField()]
        private int? _nmultiplier;

        [DBField()]
        private decimal? _ninsurancepct;

        [DBField()]
        private decimal? _nlivery;

        [DBField()]
        private decimal? _nuniform;

        [DBField()]
        private decimal? _naccamount;

        [DBField()]
        private int? _nvtkey;

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
                if (_contract_no != value)
                {
                    _contract_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ContractSeqNumber
        {
            get
            {
                CanReadProperty("ContractSeqNumber", true);
                return _contract_seq_number;
            }
            set
            {
                CanWriteProperty("ContractSeqNumber", true);
                if (_contract_seq_number != value)
                {
                    _contract_seq_number = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConTitle
        {
            get
            {
                CanReadProperty("ConTitle", true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle", true);
                if (_con_title != value)
                {
                    _con_title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Nominalvehical
        {
            get
            {
                CanReadProperty("Nominalvehical", true);
                return _nominalvehical;
            }
            set
            {
                CanWriteProperty("Nominalvehical", true);
                if (_nominalvehical != value)
                {
                    _nominalvehical = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Wagehourlyrate
        {
            get
            {
                CanReadProperty("Wagehourlyrate", true);
                return _wagehourlyrate;
            }
            set
            {
                CanWriteProperty("Wagehourlyrate", true);
                if (_wagehourlyrate != value)
                {
                    _wagehourlyrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Repairsmaint
        {
            get
            {
                CanReadProperty("Repairsmaint", true);
                return _repairsmaint;
            }
            set
            {
                CanWriteProperty("Repairsmaint", true);
                if (_repairsmaint != value)
                {
                    _repairsmaint = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Tyrestubes
        {
            get
            {
                CanReadProperty("Tyrestubes", true);
                return _tyrestubes;
            }
            set
            {
                CanWriteProperty("Tyrestubes", true);
                if (_tyrestubes != value)
                {
                    _tyrestubes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Vehicalallow
        {
            get
            {
                CanReadProperty("Vehicalallow", true);
                return _vehicalallow;
            }
            set
            {
                CanWriteProperty("Vehicalallow", true);
                if (_vehicalallow != value)
                {
                    _vehicalallow = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Vehicalinsure
        {
            get
            {
                CanReadProperty("Vehicalinsure", true);
                return _vehicalinsure;
            }
            set
            {
                CanWriteProperty("Vehicalinsure", true);
                if (_vehicalinsure != value)
                {
                    _vehicalinsure = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Publiclia
        {
            get
            {
                CanReadProperty("Publiclia", true);
                return _publiclia;
            }
            set
            {
                CanWriteProperty("Publiclia", true);
                if (_publiclia != value)
                {
                    _publiclia = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Carrierrisk
        {
            get
            {
                CanReadProperty("Carrierrisk", true);
                return _carrierrisk;
            }
            set
            {
                CanWriteProperty("Carrierrisk", true);
                if (_carrierrisk != value)
                {
                    _carrierrisk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Accrate
        {
            get
            {
                CanReadProperty("Accrate", true);
                return _accrate;
            }
            set
            {
                CanWriteProperty("Accrate", true);
                if (_accrate != value)
                {
                    _accrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Licence
        {
            get
            {
                CanReadProperty("Licence", true);
                return _licence;
            }
            set
            {
                CanWriteProperty("Licence", true);
                if (_licence != value)
                {
                    _licence = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Rateofreturn
        {
            get
            {
                CanReadProperty("Rateofreturn", true);
                return _rateofreturn;
            }
            set
            {
                CanWriteProperty("Rateofreturn", true);
                if (_rateofreturn != value)
                {
                    _rateofreturn = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Salvageratio
        {
            get
            {
                CanReadProperty("Salvageratio", true);
                return _salvageratio;
            }
            set
            {
                CanWriteProperty("Salvageratio", true);
                if (_salvageratio != value)
                {
                    _salvageratio = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Itemshour
        {
            get
            {
                CanReadProperty("Itemshour", true);
                return _itemshour;
            }
            set
            {
                CanWriteProperty("Itemshour", true);
                if (_itemshour != value)
                {
                    _itemshour = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Fuel
        {
            get
            {
                CanReadProperty("Fuel", true);
                return _fuel;
            }
            set
            {
                CanWriteProperty("Fuel", true);
                if (_fuel != value)
                {
                    _fuel = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Consumption
        {
            get
            {
                CanReadProperty("Consumption", true);
                return _consumption;
            }
            set
            {
                CanWriteProperty("Consumption", true);
                if (_consumption != value)
                {
                    _consumption = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Routedistance
        {
            get
            {
                CanReadProperty("Routedistance", true);
                return _routedistance;
            }
            set
            {
                CanWriteProperty("Routedistance", true);
                if (_routedistance != value)
                {
                    _routedistance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Deliveryhours
        {
            get
            {
                CanReadProperty("Deliveryhours", true);
                return _deliveryhours;
            }
            set
            {
                CanWriteProperty("Deliveryhours", true);
                if (_deliveryhours != value)
                {
                    _deliveryhours = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Processinghours
        {
            get
            {
                CanReadProperty("Processinghours", true);
                return _processinghours;
            }
            set
            {
                CanWriteProperty("Processinghours", true);
                if (_processinghours != value)
                {
                    _processinghours = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Volume
        {
            get
            {
                CanReadProperty("Volume", true);
                return _volume;
            }
            set
            {
                CanWriteProperty("Volume", true);
                if (_volume != value)
                {
                    _volume = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Deliverydays
        {
            get
            {
                CanReadProperty("Deliverydays", true);
                return _deliverydays;
            }
            set
            {
                CanWriteProperty("Deliverydays", true);
                if (_deliverydays != value)
                {
                    _deliverydays = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Maxdeliverydays
        {
            get
            {
                CanReadProperty("Maxdeliverydays", true);
                return _maxdeliverydays;
            }
            set
            {
                CanWriteProperty("Maxdeliverydays", true);
                if (_maxdeliverydays != value)
                {
                    _maxdeliverydays = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Numberboxholders
        {
            get
            {
                CanReadProperty("Numberboxholders", true);
                return _numberboxholders;
            }
            set
            {
                CanWriteProperty("Numberboxholders", true);
                if (_numberboxholders != value)
                {
                    _numberboxholders = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Routedistanceperday
        {
            get
            {
                CanReadProperty("Routedistanceperday", true);
                return _routedistanceperday;
            }
            set
            {
                CanWriteProperty("Routedistanceperday", true);
                if (_routedistanceperday != value)
                {
                    _routedistanceperday = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Vehicledepreciation
        {
            get
            {
                CanReadProperty("Vehicledepreciation", true);
                return _vehicledepreciation;
            }
            set
            {
                CanWriteProperty("Vehicledepreciation", true);
                if (_vehicledepreciation != value)
                {
                    _vehicledepreciation = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Fuelcostperannum
        {
            get
            {
                CanReadProperty("Fuelcostperannum", true);
                return _fuelcostperannum;
            }
            set
            {
                CanWriteProperty("Fuelcostperannum", true);
                if (_fuelcostperannum != value)
                {
                    _fuelcostperannum = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Repairsperannum
        {
            get
            {
                CanReadProperty("Repairsperannum", true);
                return _repairsperannum;
            }
            set
            {
                CanWriteProperty("Repairsperannum", true);
                if (_repairsperannum != value)
                {
                    _repairsperannum = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Tyrestubesperannum
        {
            get
            {
                CanReadProperty("Tyrestubesperannum", true);
                return _tyrestubesperannum;
            }
            set
            {
                CanWriteProperty("Tyrestubesperannum", true);
                if (_tyrestubesperannum != value)
                {
                    _tyrestubesperannum = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Deliverycost
        {
            get
            {
                CanReadProperty("Deliverycost", true);
                return _deliverycost;
            }
            set
            {
                CanWriteProperty("Deliverycost", true);
                if (_deliverycost != value)
                {
                    _deliverycost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Processingcost
        {
            get
            {
                CanReadProperty("Processingcost", true);
                return _processingcost;
            }
            set
            {
                CanWriteProperty("Processingcost", true);
                if (_processingcost != value)
                {
                    _processingcost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Publicliabilitycost
        {
            get
            {
                CanReadProperty("Publicliabilitycost", true);
                return _publicliabilitycost;
            }
            set
            {
                CanWriteProperty("Publicliabilitycost", true);
                if (_publicliabilitycost != value)
                {
                    _publicliabilitycost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Accperannum
        {
            get
            {
                CanReadProperty("Accperannum", true);
                return _accperannum;
            }
            set
            {
                CanWriteProperty("Accperannum", true);
                if (_accperannum != value)
                {
                    _accperannum = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Vehicleinsurance
        {
            get
            {
                CanReadProperty("Vehicleinsurance", true);
                return _vehicleinsurance;
            }
            set
            {
                CanWriteProperty("Vehicleinsurance", true);
                if (_vehicleinsurance != value)
                {
                    _vehicleinsurance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Licensing
        {
            get
            {
                CanReadProperty("Licensing", true);
                return _licensing;
            }
            set
            {
                CanWriteProperty("Licensing", true);
                if (_licensing != value)
                {
                    _licensing = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Carrierriskrate
        {
            get
            {
                CanReadProperty("Carrierriskrate", true);
                return _carrierriskrate;
            }
            set
            {
                CanWriteProperty("Carrierriskrate", true);
                if (_carrierriskrate != value)
                {
                    _carrierriskrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Benchmark
        {
            get
            {
                CanReadProperty("Benchmark", true);
                return _benchmark;
            }
            set
            {
                CanWriteProperty("Benchmark", true);
                if (_benchmark != value)
                {
                    _benchmark = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Rateofreturn1
        {
            get
            {
                CanReadProperty("Rateofreturn1", true);
                return _rateofreturn_1;
            }
            set
            {
                CanWriteProperty("Rateofreturn1", true);
                if (_rateofreturn_1 != value)
                {
                    _rateofreturn_1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Finalbenchmark
        {
            get
            {
                CanReadProperty("Finalbenchmark", true);
                return _finalbenchmark;
            }
            set
            {
                CanWriteProperty("Finalbenchmark", true);
                if (_finalbenchmark != value)
                {
                    _finalbenchmark = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Retainedallowances
        {
            get
            {
                CanReadProperty("Retainedallowances", true);
                return _retainedallowances;
            }
            set
            {
                CanWriteProperty("Retainedallowances", true);
                if (_retainedallowances != value)
                {
                    _retainedallowances = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Currentpayment
        {
            get
            {
                CanReadProperty("Currentpayment", true);
                return _currentpayment;
            }
            set
            {
                CanWriteProperty("Currentpayment", true);
                if (_currentpayment != value)
                {
                    _currentpayment = value;
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
                if (_sf_key != value)
                {
                    _sf_key = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RfDistance
        {
            get
            {
                CanReadProperty("RfDistance", true);
                return _rf_distance;
            }
            set
            {
                CanWriteProperty("RfDistance", true);
                if (_rf_distance != value)
                {
                    _rf_distance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfDeliverydays
        {
            get
            {
                CanReadProperty("RfDeliverydays", true);
                return _rf_deliverydays;
            }
            set
            {
                CanWriteProperty("RfDeliverydays", true);
                if (_rf_deliverydays != value)
                {
                    _rf_deliverydays = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RfDaysyear
        {
            get
            {
                CanReadProperty("RfDaysyear", true);
                return _rf_daysyear;
            }
            set
            {
                CanWriteProperty("RfDaysyear", true);
                if (_rf_daysyear != value)
                {
                    _rf_daysyear = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RfDaysweek
        {
            get
            {
                CanReadProperty("RfDaysweek", true);
                return _rf_daysweek;
            }
            set
            {
                CanWriteProperty("RfDaysweek", true);
                if (_rf_daysweek != value)
                {
                    _rf_daysweek = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Itemspercust
        {
            get
            {
                CanReadProperty("Itemspercust", true);
                return _itemspercust;
            }
            set
            {
                CanWriteProperty("Itemspercust", true);
                if (_itemspercust != value)
                {
                    _itemspercust = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfActive
        {
            get
            {
                CanReadProperty("RfActive", true);
                return _rf_active;
            }
            set
            {
                CanWriteProperty("RfActive", true);
                if (_rf_active != value)
                {
                    _rf_active = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Firstrow
        {
            get
            {
                CanReadProperty("Firstrow", true);
                return _firstrow;
            }
            set
            {
                CanWriteProperty("Firstrow", true);
                if (_firstrow != value)
                {
                    _firstrow = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Currentbenchmark
        {
            get
            {
                CanReadProperty("Currentbenchmark", true);
                return _currentbenchmark;
            }
            set
            {
                CanWriteProperty("Currentbenchmark", true);
                if (_currentbenchmark != value)
                {
                    _currentbenchmark = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Accounting
        {
            get
            {
                CanReadProperty("Accounting", true);
                return _accounting;
            }
            set
            {
                CanWriteProperty("Accounting", true);
                if (_accounting != value)
                {
                    _accounting = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Telephone
        {
            get
            {
                CanReadProperty("Telephone", true);
                return _telephone;
            }
            set
            {
                CanWriteProperty("Telephone", true);
                if (_telephone != value)
                {
                    _telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Sundries
        {
            get
            {
                CanReadProperty("Sundries", true);
                return _sundries;
            }
            set
            {
                CanWriteProperty("Sundries", true);
                if (_sundries != value)
                {
                    _sundries = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Ruc
        {
            get
            {
                CanReadProperty("Ruc", true);
                return _ruc;
            }
            set
            {
                CanWriteProperty("Ruc", true);
                if (_ruc != value)
                {
                    _ruc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateNomvehicle
        {
            get
            {
                CanReadProperty("RrrateNomvehicle", true);
                return _rrrate_nomvehicle;
            }
            set
            {
                CanWriteProperty("RrrateNomvehicle", true);
                if (_rrrate_nomvehicle != value)
                {
                    _rrrate_nomvehicle = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateWage
        {
            get
            {
                CanReadProperty("RrrateWage", true);
                return _rrrate_wage;
            }
            set
            {
                CanWriteProperty("RrrateWage", true);
                if (_rrrate_wage != value)
                {
                    _rrrate_wage = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateRepairsmaint
        {
            get
            {
                CanReadProperty("RrrateRepairsmaint", true);
                return _rrrate_repairsmaint;
            }
            set
            {
                CanWriteProperty("RrrateRepairsmaint", true);
                if (_rrrate_repairsmaint != value)
                {
                    _rrrate_repairsmaint = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateTyretubes
        {
            get
            {
                CanReadProperty("RrrateTyretubes", true);
                return _rrrate_tyretubes;
            }
            set
            {
                CanWriteProperty("RrrateTyretubes", true);
                if (_rrrate_tyretubes != value)
                {
                    _rrrate_tyretubes = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateVehallow
        {
            get
            {
                CanReadProperty("RrrateVehallow", true);
                return _rrrate_vehallow;
            }
            set
            {
                CanWriteProperty("RrrateVehallow", true);
                if (_rrrate_vehallow != value)
                {
                    _rrrate_vehallow = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateVehinsurance
        {
            get
            {
                CanReadProperty("RrrateVehinsurance", true);
                return _rrrate_vehinsurance;
            }
            set
            {
                CanWriteProperty("RrrateVehinsurance", true);
                if (_rrrate_vehinsurance != value)
                {
                    _rrrate_vehinsurance = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrratePubliclia
        {
            get
            {
                CanReadProperty("RrratePubliclia", true);
                return _rrrate_publiclia;
            }
            set
            {
                CanWriteProperty("RrratePubliclia", true);
                if (_rrrate_publiclia != value)
                {
                    _rrrate_publiclia = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateCarrierrisk
        {
            get
            {
                CanReadProperty("RrrateCarrierrisk", true);
                return _rrrate_carrierrisk;
            }
            set
            {
                CanWriteProperty("RrrateCarrierrisk", true);
                if (_rrrate_carrierrisk != value)
                {
                    _rrrate_carrierrisk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateAcc
        {
            get
            {
                CanReadProperty("RrrateAcc", true);
                return _rrrate_acc;
            }
            set
            {
                CanWriteProperty("RrrateAcc", true);
                if (_rrrate_acc != value)
                {
                    _rrrate_acc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateLicense
        {
            get
            {
                CanReadProperty("RrrateLicense", true);
                return _rrrate_license;
            }
            set
            {
                CanWriteProperty("RrrateLicense", true);
                if (_rrrate_license != value)
                {
                    _rrrate_license = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateVehrateofreturn
        {
            get
            {
                CanReadProperty("RrrateVehrateofreturn", true);
                return _rrrate_vehrateofreturn;
            }
            set
            {
                CanWriteProperty("RrrateVehrateofreturn", true);
                if (_rrrate_vehrateofreturn != value)
                {
                    _rrrate_vehrateofreturn = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateSalvageratio
        {
            get
            {
                CanReadProperty("RrrateSalvageratio", true);
                return _rrrate_salvageratio;
            }
            set
            {
                CanWriteProperty("RrrateSalvageratio", true);
                if (_rrrate_salvageratio != value)
                {
                    _rrrate_salvageratio = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateItemprocrate
        {
            get
            {
                CanReadProperty("RrrateItemprocrate", true);
                return _rrrate_itemprocrate;
            }
            set
            {
                CanWriteProperty("RrrateItemprocrate", true);
                if (_rrrate_itemprocrate != value)
                {
                    _rrrate_itemprocrate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateRuc
        {
            get
            {
                CanReadProperty("RrrateRuc", true);
                return _rrrate_ruc;
            }
            set
            {
                CanWriteProperty("RrrateRuc", true);
                if (_rrrate_ruc != value)
                {
                    _rrrate_ruc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateAccounting
        {
            get
            {
                CanReadProperty("RrrateAccounting", true);
                return _rrrate_accounting;
            }
            set
            {
                CanWriteProperty("RrrateAccounting", true);
                if (_rrrate_accounting != value)
                {
                    _rrrate_accounting = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateTelephone
        {
            get
            {
                CanReadProperty("RrrateTelephone", true);
                return _rrrate_telephone;
            }
            set
            {
                CanWriteProperty("RrrateTelephone", true);
                if (_rrrate_telephone != value)
                {
                    _rrrate_telephone = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateSundries
        {
            get
            {
                CanReadProperty("RrrateSundries", true);
                return _rrrate_sundries;
            }
            set
            {
                CanWriteProperty("RrrateSundries", true);
                if (_rrrate_sundries != value)
                {
                    _rrrate_sundries = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateSundriesk
        {
            get
            {
                CanReadProperty("RrrateSundriesk", true);
                return _rrrate_sundriesk;
            }
            set
            {
                CanWriteProperty("RrrateSundriesk", true);
                if (_rrrate_sundriesk != value)
                {
                    _rrrate_sundriesk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Sundriesk
        {
            get
            {
                CanReadProperty("Sundriesk", true);
                return _sundriesk;
            }
            set
            {
                CanWriteProperty("Sundriesk", true);
                if (_sundriesk != value)
                {
                    _sundriesk = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Nmultiplier
        {
            get
            {
                CanReadProperty("Nmultiplier", true);
                return _nmultiplier;
            }
            set
            {
                CanWriteProperty("Nmultiplier", true);
                if (_nmultiplier != value)
                {
                    _nmultiplier = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Ninsurancepct
        {
            get
            {
                CanReadProperty("Ninsurancepct", true);
                return _ninsurancepct;
            }
            set
            {
                CanWriteProperty("Ninsurancepct", true);
                if (_ninsurancepct != value)
                {
                    _ninsurancepct = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Nlivery
        {
            get
            {
                CanReadProperty("Nlivery", true);
                return _nlivery;
            }
            set
            {
                CanWriteProperty("Nlivery", true);
                if (_nlivery != value)
                {
                    _nlivery = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Nuniform
        {
            get
            {
                CanReadProperty("Nuniform", true);
                return _nuniform;
            }
            set
            {
                CanWriteProperty("Nuniform", true);
                if (_nuniform != value)
                {
                    _nuniform = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Naccamount
        {
            get
            {
                CanReadProperty("Naccamount", true);
                return _naccamount;
            }
            set
            {
                CanWriteProperty("Naccamount", true);
                if (_naccamount != value)
                {
                    _naccamount = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Nvtkey
        {
            get
            {
                CanReadProperty("Nvtkey", true);
                return _nvtkey;
            }
            set
            {
                CanWriteProperty("Nvtkey", true);
                if (_nvtkey != value)
                {
                    _nvtkey = value;
                    PropertyHasChanged();
                }
            }
        }

        // needs to implement compute expression manually:
        // compute control name=[proccosts]
        //(((   if(isnull(calcvolume),0,calcvolume)  /  if(isnull(itemshour),0,itemshour) ) / 365) * 7) * 56) *  if(isnull(wagehourlyrate),0,wagehourlyrate

        // needs to implement compute expression manually:
        // compute control name=[delcosts]
        //if(isnull(calcdelhours),0,calcdelhours) * 56) *  if(isnull(wagehourlyrate),0,wagehourlyrate

        // needs to implement compute expression manually:
        // compute control name=[acccost]
        //if(isnull(( if(isNull(accrate),0,accrate)  / 100) * ((( if(isnull(calcdelhours),0,calcdelhours) * 56) *  if(isnull(wagehourlyrate),0,wagehourlyrate) ) + ((((( if(isnull(calcvolume),0,calcvolume) /  if(isnull(itemshour),0,itemshour) ) / 365) * 7) * 56) *  if(isnull(wagehourlyrate),0,wagehourlyrate)) ) ),0,( if(isNull(accrate),0,accrate)  / 100) * ((( if(isnull(calcdelhours),0,calcdelhours) * 56) *  if(isnull(wagehourlyrate),0,wagehourlyrate) ) + ((((( if(isnull(calcvolume),0,calcvolume) /  if(isnull(itemshour),0,itemshour) ) / 365) * 7) * 56) *  if(isnull(wagehourlyrate),0,wagehourlyrate)) ) ) +  if(isNull(naccamount ), 0,naccamount)
        public virtual string Compute1
        {
            get
            {
                CanReadProperty("Compute1", true);
                return (_contract_no.GetValueOrDefault().ToString()) + "/" + (_contract_seq_number.GetValueOrDefault().ToString()) + " " + _con_title;
            }
        }

        public virtual decimal? Proccosts
        {
            get
            {
                CanReadProperty("Proccosts", true);
                return (((((Calcvolume == null ? 0 : Calcvolume) / (_itemshour == null ? 0 : _itemshour)) / 365) * 7) * 56) * (_wagehourlyrate == null ? 0 : _wagehourlyrate);
            }
        }

        public virtual decimal? Delcosts
        {
            get
            {
                CanReadProperty("Delcosts", true);
                return ((Calcdelhours == null ? 0 : Calcdelhours) * 56) * (_wagehourlyrate == null ? 0 : _wagehourlyrate);
            }
        }

        public virtual decimal? Acccost
        {
            get
            {
                CanReadProperty("Acccost", true);
                return (((_accrate == null ? 0 : _accrate) / 100) * ((((Calcdelhours == null ? 0 : Calcdelhours) * 56) * (_wagehourlyrate == null ? 0 : _wagehourlyrate)) + ((((((Calcvolume == null ? 0 : Calcvolume) / (_itemshour == null ? 0 : _itemshour)) / 365) * 7) * 56) * (_wagehourlyrate == null ? 0 : _wagehourlyrate))) == null ? 0 : ((_accrate == null ? 0 : _accrate) / 100) * ((((Calcdelhours == null ? 0 : Calcdelhours) * 56) * (_wagehourlyrate == null ? 0 : _wagehourlyrate)) + ((((((Calcvolume == null ? 0 : Calcvolume) / (_itemshour == null ? 0 : _itemshour)) / 365) * 7) * 56) * (_wagehourlyrate == null ? 0 : _wagehourlyrate)))) + (_naccamount == null ? 0 : _naccamount);
            }
        }

        public virtual string Contract
        {
            get
            {
                CanReadProperty("Contract", true);
                return (_contract_no.GetValueOrDefault().ToString()) + "/" + (_contract_seq_number.GetValueOrDefault().ToString());
            }
        }

        public virtual decimal? Calcroutedistance
        {
            get
            {
                CanReadProperty("Calcroutedistance", true);
                //return sum( (rf_active== "Y" ?( rf_distance  *  rf_daysyear  ):0) for group 1 );
                return 0;
            }
        }

        public virtual decimal? Calcdelhours
        {
            get
            {
                CanReadProperty("Calcdelhours", true);
                return _deliveryhours;
            }
        }

        public virtual decimal? Calcbenchmark
        {
            get
            {
                CanReadProperty("Calcbenchmark", true);
                return (Calcvd + Calcfc + Calcrep + Calctt + Calcdc + Calcpc + Calcacc + Calcvi + Calclic + Calccrr + _rateofreturn_1);
            }
        }

        public virtual decimal? Benchdiff
        {
            get
            {
                CanReadProperty("Benchdiff", true);
                return System.Convert.ToDecimal(_finalbenchmark.GetValueOrDefault()) - Math.Round(Calcbenchmark.GetValueOrDefault(), 0);
            }
        }

        public virtual decimal? Calcvd
        {
            get
            {
                CanReadProperty("Calcvd", true);
                return Calcroutedistance * (_vehicalallow / 1000);
            }
        }

        public virtual decimal? Calcfc
        {
            get
            {
                CanReadProperty("Calcfc", true);
                return (_consumption / 100) * (_fuel / 100) * Calcroutedistance;
            }
        }

        public virtual decimal? Calcrep
        {
            get
            {
                CanReadProperty("Calcrep", true);
                return Calcroutedistance * _repairsmaint / 1000;
            }
        }

        public virtual decimal? Calctt
        {
            get
            {
                CanReadProperty("Calctt", true);
                return _tyrestubes * (Calcroutedistance / 1000);
            }
        }

        public virtual decimal? Calcdc
        {
            get
            {
                CanReadProperty("Calcdc", true);
                return (Calcdelhours * 56) * _wagehourlyrate;
            }
        }

        public virtual decimal? Calcvolume
        {
            get
            {
                CanReadProperty("Calcvolume", true);
                return _numberboxholders * _itemspercust;
            }
        }

        public virtual decimal? Calcpc
        {
            get
            {
                CanReadProperty("Calcpc", true);
                return ((((Calcvolume / _itemshour) / 365) * 7) * 56) * _wagehourlyrate;
            }
        }

        public virtual decimal? Calcpl
        {
            get
            {
                CanReadProperty("Calcpl", true);
                return _publiclia * (_deliverydays / _maxdeliverydays);
            }
        }

        public virtual decimal? Calcacc
        {
            get
            {
                CanReadProperty("Calcacc", true);
                return (_accrate / 100) * (Calcdc + Calcpc);
            }
        }

        public virtual decimal? Calcvi
        {
            get
            {
                CanReadProperty("Calcvi", true);
                return _vehicalinsure * (_deliverydays / _maxdeliverydays);
            }
        }

        public virtual decimal? Calclic
        {
            get
            {
                CanReadProperty("Calclic", true);
                return _licence * (_deliverydays / _maxdeliverydays);
            }
        }

        public virtual decimal? Compute2
        {
            get
            {
                CanReadProperty("Compute2", true);
                return _volume;
            }
        }

        public virtual decimal? Publiclia2
        {
            get
            {
                CanReadProperty("Publiclia2", true);
                return 0;//return sum( (_   publiclia == null ? 0 : _   publiclia )for group 1) / count(  publiclia for group 1);
            }
        }

        public virtual decimal? Numcustsforcontract
        {
            get
            {
                CanReadProperty("Numcustsforcontract", true);
                return 0;//return sum( numberboxholders for group 1) / count(numberboxholders for group 1);
            }
        }

        public virtual decimal? Sruc
        {
            get
            {
                CanReadProperty("Sruc", true);
                return 0;//return sum( (_ruc== null ? 0 : _ruc) for group 1) / count( ruc for group 1);
            }
        }

        public virtual decimal? Saccounting
        {
            get
            {
                CanReadProperty("Saccounting", true);
                return 0;//return sum( (_ accounting == null ? 0 : _accounting) for group 1) / count( accounting for group 1);
            }
        }

        public virtual decimal? Ssundries
        {
            get
            {
                CanReadProperty("Ssundries", true);
                return 0;//return sum( (_ sundries == null ? 0 : _sundries)for group 1) / count( sundries for group 1);
            }
        }

        public virtual decimal? Stelephone
        {
            get
            {
                CanReadProperty("Stelephone", true);
                return 0;//return sum( (_telephone == null ? 0 : _telephone)for group 1) / count( telephone for group 1);
            }
        }

        public virtual decimal? Compute3
        {
            get
            {
                CanReadProperty("Compute3", true);
                return _rf_distance;
            }
        }

        public virtual decimal? Compute4
        {
            get
            {
                CanReadProperty("Compute4", true);
                return _rf_daysyear;
            }
        }

        public virtual decimal? Calccrr
        {
            get
            {
                CanReadProperty("Calccrr", true);
                return _carrierrisk * (_deliverydays / _maxdeliverydays);
            }
        }

        public virtual decimal? Kmsyear
        {
            get
            {
                CanReadProperty("Kmsyear", true);
                return 0;//return sum( (_rf_active=="Y"?( rf_distance  *  rf_daysyear  ):0) for all );
            }
        }

        public virtual decimal? Totvol
        {
            get
            {
                CanReadProperty("Totvol", true);
                return 0;//return sum( (firstrow=="Y"?numberboxholders  *  itemspercust:0) for all);
            }
        }

        public virtual decimal? Compute5
        {
            get
            {
                CanReadProperty("Compute5", true);
                return 0;//return sum(if(firstrow=="Y"?numberboxholders:0) for all);
            }
        }

        public virtual decimal? Totdelhrs
        {
            get
            {
                CanReadProperty("Totdelhrs", true);
                return 0;//return sum(if(firstrow=="Y"?deliveryhours:0) for all);
            }
        }

        public virtual decimal? Compute6
        {
            get
            {
                CanReadProperty("Compute6", true);
                return 0;//return sum( if(firstrow == "Y"?routedistanceperday: 0) for all );
            }
        }

        public virtual decimal? Totprochrs
        {
            get
            {
                CanReadProperty("Totprochrs", true);
                return Totvol / _itemshour / (365 / 7);
            }
        }

        public virtual decimal? Maxdaysallcontracts
        {
            get
            {
                CanReadProperty("Maxdaysallcontracts", true);
                return 0;//return max(maxdeliverydays);
            }
        }

        public virtual decimal? Oldacc
        {
            get
            {
                CanReadProperty("Oldacc", true);
                return 0;//return round(   (( (_totdelhrs== null ? 0 : _totdelhrs) + (_totprochrs== null ? 0 : _totprochrs) ) * (_wagehourlyrate== null ? 0 : _wagehourlyrate) * 56)  * ( (_accrate== null ? 0 : _accrate) / 100),2) + sum( (_naccamount== null ? 0 : _naccamount )  for all distinct contract_no   );
            }
        }

        public virtual decimal? Oldtotwd
        {
            get
            {
                CanReadProperty("Oldtotwd", true);
                return Math.Round(((Totdelhrs == null ? 0 : Totdelhrs) * (_wagehourlyrate == null ? 0 : _wagehourlyrate) * 56).GetValueOrDefault(), 2);
            }
        }

        public virtual decimal? Oldtotwp
        {
            get
            {
                CanReadProperty("Oldtotwp", true);
                return Math.Round(((Totprochrs == null ? 0 : Totprochrs) * (_wagehourlyrate == null ? 0 : _wagehourlyrate) * 56).GetValueOrDefault(), 2);
            }
        }

        public virtual decimal? Totfuel
        {
            get
            {
                CanReadProperty("Totfuel", true);
                return 0;//return Math.Round(sum((rf_active=="Y"?(( (_consumption== null ? 0 : _consumption)  /100)*(  (_fuel== null ? 0 : _fuel ) /100))*(rf_distance* rf_daysyear ):0) for all),2);
            }
        }

        public virtual decimal? Truc
        {
            get
            {
                CanReadProperty("Truc", true);
                return 0;//return Math.Round(sum((rf_active=="Y"?(  nmultiplier * ruc * ((rf_distance* rf_daysyear)/1000) ):0) for all),2);
            }
        }

        public virtual decimal? Totrm
        {
            get
            {
                CanReadProperty("Totrm", true);
                return 0;//return Math.Round(sum((rf_active=="Y"?(repairsmaint * ((rf_distance* rf_daysyear)/1000) ):0) for all),2);
            }
        }

        public virtual decimal? Tsundriesk
        {
            get
            {
                CanReadProperty("Tsundriesk", true);
                return 0;// return Math.Round(sum(if(rf_active='Y',(  sundriesk * ((rf_distance* rf_daysyear)/1000) ),0) for all),2);
            }
        }

        public virtual decimal? Tottt
        {
            get
            {
                CanReadProperty("Tottt", true);
                return 0;//return Math.Round(sum((rf_active== "Y",(tyrestubes * ((rf_distance* rf_daysyear)/1000) ):0) for all),2);
            }
        }

        public virtual decimal? Totva
        {
            get
            {
                CanReadProperty("Totva", true);
                return 0;//return Math.Round(sum((rf_active=="Y"?( (_ vehicalallow == null ? 0 : _ vehicalallow )*((rf_distance*rf_daysyear)/1000) ) :0)  for all ),2)
                ;
            }
        }

        public virtual decimal? Totvi
        {
            get
            {
                CanReadProperty("Totvi", true);
                return 0;//return  Math.Round(sum( ( firstrow =="Y"? (vehicalinsure * ( deliverydays /  maxdeliverydays ) ): 0) for all),2) ;
            }
        }

        public virtual decimal? Totpl
        {
            get
            {
                CanReadProperty("Totpl", true);
                return 0;//return Math.Round(sum( if(firstrow='Y',publiclia * ( deliverydays  /  maxdeliverydays ),0) for all),2);
            }
        }

        public virtual decimal? Totcr
        {
            get
            {
                CanReadProperty("Totcr", true);
                return 0;//return Math.Round(sum( if(firstrow='Y',carrierrisk * ( deliverydays  /  maxdeliverydays ),0) for all),2);
            }
        }

        public virtual decimal? Totacc
        {
            get
            {
                CanReadProperty("Totacc", true);
                return 0;//return sum( (_acccost== null ? 0 : _ acccost)  for all distinct contract_no   );
            }
        }

        public virtual decimal? Totrel
        {
            get
            {
                CanReadProperty("Totrel", true);
                return 0;//return Math.Round(sum(if(firstrow='Y',licence * ( deliverydays  /  maxdeliverydays ),0) for all),2);
            }
        }

        public virtual decimal? Taccounting
        {
            get
            {
                CanReadProperty("Taccounting", true);
                return 0;//return Math.Round(sum(if(firstrow='Y',  accounting * ( deliverydays  /  maxdeliverydays ),0) for all),2);
            }
        }

        public virtual decimal? Ttelephone
        {
            get
            {
                CanReadProperty("Ttelephone", true);
                return 0;//return Math.Round(sum(if(firstrow='Y',  stelephone * ( deliverydays  /  maxdeliverydays ),0) for all),2);
            }
        }

        public virtual decimal? Tsundries
        {
            get
            {
                CanReadProperty("Tsundries", true);
                return 0;// return Math.Round(sum(if(firstrow='Y',  ssundries * ( deliverydays  /  maxdeliverydays ),0) for all),2);
            }
        }

        public virtual decimal? Totwd
        {
            get
            {
                CanReadProperty("Totwd", true);
                return 0;//return sum( (_ delcosts== null ? 0 : _ delcosts )  for all distinct contract_no   );
            }
        }

        public virtual decimal? Totwp
        {
            get
            {
                CanReadProperty("Totwp", true);
                return 0;//return sum( (_ proccosts == null ? 0 : _ proccosts )  for all distinct contract_no   );
            }
        }

        public virtual decimal? Totbm
        {
            get
            {
                CanReadProperty("Totbm", true);
                return Totfuel + Totrm + Tottt + Totva + Totvi + Totpl + Totcr + Totacc + Totrel + Totwd + Totwp + Truc + Tsundries + Taccounting + Ttelephone + Tsundriesk;
            }
        }

        public virtual decimal Totror
        {
            get
            {
                CanReadProperty("Totror", true);
                return 0;//return Math.Round(sum( if(firstrow="Y",rateofreturn_1,0) for all ),2);
            }
        }

        public virtual decimal? Totalfloor
        {
            get
            {
                CanReadProperty("Totalfloor", true);
                return Math.Round((Totbm + Totror + ((decimal)0.5)).GetValueOrDefault(), 0);
            }
        }

        public virtual decimal? Totalcurrent
        {
            get
            {
                CanReadProperty("Totalcurrent", true);
                return 0;//return sum(if(firstrow="Y",currentpayment, 0) for all);
            }
        }

        public virtual decimal? Compute8
        {
            get
            {
                CanReadProperty("Compute8", true);
                return Totalfloor - Totalcurrent;
            }
        }

        public virtual decimal? Compute9
        {
            get
            {
                CanReadProperty("Compute9", true);
                return list[0]._rrrate_publiclia;
            }
        }

        public virtual decimal? Compute10
        {
            get
            {
                CanReadProperty("Compute10", true);
                return list[0]._rrrate_carrierrisk;
            }
        }

        public virtual decimal? Compute11
        {
            get
            {
                CanReadProperty("Compute11", true);
                return list[0]._rrrate_acc;
            }
        }

        public virtual decimal? Compute12
        {
            get
            {
                CanReadProperty("Compute12", true);
                return list[0]._naccamount;
            }
        }

        public virtual decimal? Compute14
        {
            get
            {
                CanReadProperty("Compute14", true);
                return list[0]._rrrate_accounting;
            }
        }

        public virtual decimal? Compute15
        {
            get
            {
                CanReadProperty("Compute15", true);
                return list[0]._rrrate_telephone;
            }
        }

        public virtual decimal? Compute16
        {
            get
            {
                CanReadProperty("Compute16", true);
                return list[0]._rrrate_sundries;
            }
        }

        public virtual string Compute17
        {
            get
            {
                CanReadProperty("Compute17", true);
                return DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm:ss");
            }
        }

        public virtual decimal? Compute18
        {
            get
            {
                CanReadProperty("Compute18", true);
                return 0;//return "Page " + page() + " of " + pageCount();
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }

        #endregion

        #region Factory Methods
        public static WhatifCalculatorReport2001bf5 NewWhatifCalculatorReport2001bf5(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
        {
            return Create(inContract, inSequence, inRGCode, inEffectDate, inVolumeSource);
        }

        public static WhatifCalculatorReport2001bf5[] GetAllWhatifCalculatorReport2001bf5(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
        {
            return Fetch(inContract, inSequence, inRGCode, inEffectDate, inVolumeSource).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContract", inContract);
                    pList.Add(cm, "inSequence", inSequence);
                    pList.Add(cm, "inRGCode", inRGCode);
                    pList.Add(cm, "inEffectDate", inEffectDate);
                    pList.Add(cm, "inVolumeSource", inVolumeSource);
                    cm.CommandText = "rd.sp_getwhatifcalc2001c";

                    List<WhatifCalculatorReport2001bf5> _list = new List<WhatifCalculatorReport2001bf5>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            WhatifCalculatorReport2001bf5 instance = new WhatifCalculatorReport2001bf5();
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_seq_number = GetValueFromReader<Int32?>(dr, 1);
                            instance._con_title = GetValueFromReader<String>(dr, 2);
                            instance._nominalvehical = GetValueFromReader<Decimal?>(dr, 3);
                            instance._wagehourlyrate = GetValueFromReader<Decimal?>(dr, 4);
                            instance._repairsmaint = GetValueFromReader<Decimal?>(dr, 5);
                            instance._tyrestubes = GetValueFromReader<Decimal?>(dr, 6);
                            instance._vehicalallow = GetValueFromReader<Decimal?>(dr, 7);
                            instance._vehicalinsure = GetValueFromReader<Decimal?>(dr, 8);
                            instance._publiclia = GetValueFromReader<Decimal?>(dr, 9);
                            instance._carrierrisk = GetValueFromReader<Decimal?>(dr, 10);
                            instance._accrate = GetValueFromReader<Decimal?>(dr, 11);
                            instance._licence = GetValueFromReader<Decimal?>(dr, 12);
                            instance._rateofreturn = GetValueFromReader<Decimal?>(dr, 13);
                            instance._salvageratio = GetValueFromReader<Decimal?>(dr, 14);
                            instance._itemshour = GetValueFromReader<Decimal?>(dr, 15);
                            instance._fuel = GetValueFromReader<Decimal?>(dr, 16);
                            instance._consumption = GetValueFromReader<Decimal?>(dr, 17);
                            instance._routedistance = GetValueFromReader<Decimal?>(dr, 18);
                            instance._deliveryhours = GetValueFromReader<Decimal?>(dr, 19);
                            instance._processinghours = GetValueFromReader<Decimal?>(dr, 20);
                            instance._volume = GetValueFromReader<Decimal?>(dr, 21);
                            instance._deliverydays = GetValueFromReader<Decimal?>(dr, 22);
                            instance._maxdeliverydays = GetValueFromReader<Decimal?>(dr, 23);
                            instance._numberboxholders = GetValueFromReader<Int32?>(dr, 24);
                            instance._routedistanceperday = GetValueFromReader<Int32?>(dr, 25);
                            instance._vehicledepreciation = GetValueFromReader<Int32?>(dr, 26);
                            instance._fuelcostperannum = GetValueFromReader<Int32?>(dr, 27);
                            instance._repairsperannum = GetValueFromReader<Int32?>(dr, 28);
                            instance._tyrestubesperannum = GetValueFromReader<Int32?>(dr, 29);
                            instance._deliverycost = GetValueFromReader<Int32?>(dr, 30);
                            instance._processingcost = GetValueFromReader<Int32?>(dr, 31);
                            instance._publicliabilitycost = GetValueFromReader<Int32?>(dr, 32);
                            instance._accperannum = GetValueFromReader<Int32?>(dr, 33);
                            instance._vehicleinsurance = GetValueFromReader<Int32?>(dr, 34);
                            instance._licensing = GetValueFromReader<Int32?>(dr, 35);
                            instance._carrierriskrate = GetValueFromReader<Int32?>(dr, 36);
                            instance._benchmark = GetValueFromReader<Int32?>(dr, 37);
                            instance._rateofreturn_1 = GetValueFromReader<Int32?>(dr, 38);
                            instance._finalbenchmark = GetValueFromReader<Int32?>(dr, 39);
                            instance._retainedallowances = GetValueFromReader<Decimal?>(dr, 40);
                            instance._currentpayment = GetValueFromReader<Decimal?>(dr, 41);
                            instance._sf_key = GetValueFromReader<Int32?>(dr, 42);
                            instance._rf_distance = GetValueFromReader<Decimal?>(dr, 43);
                            instance._rf_deliverydays = GetValueFromReader<String>(dr, 44);
                            instance._rf_daysyear = GetValueFromReader<Int32?>(dr, 45);
                            instance._rf_daysweek = GetValueFromReader<Int32?>(dr, 46);
                            instance._itemspercust = GetValueFromReader<Decimal?>(dr, 47);
                            instance._rf_active = GetValueFromReader<String>(dr, 48);
                            instance._firstrow = GetValueFromReader<String>(dr, 49);
                            instance._currentbenchmark = GetValueFromReader<Decimal?>(dr, 50);
                            instance._accounting = GetValueFromReader<Decimal?>(dr, 51);
                            instance._telephone = GetValueFromReader<Decimal?>(dr, 52);
                            instance._sundries = GetValueFromReader<Decimal?>(dr, 53);
                            instance._ruc = GetValueFromReader<Decimal?>(dr, 54);
                            instance._rrrate_nomvehicle = GetValueFromReader<Decimal?>(dr, 55);
                            instance._rrrate_wage = GetValueFromReader<Decimal?>(dr, 56);
                            instance._rrrate_repairsmaint = GetValueFromReader<Decimal?>(dr, 57);
                            instance._rrrate_tyretubes = GetValueFromReader<Decimal?>(dr, 58);
                            instance._rrrate_vehallow = GetValueFromReader<Decimal?>(dr, 59);
                            instance._rrrate_vehinsurance = GetValueFromReader<Decimal?>(dr, 60);
                            instance._rrrate_publiclia = GetValueFromReader<Decimal?>(dr, 61);
                            instance._rrrate_carrierrisk = GetValueFromReader<Decimal?>(dr, 62);
                            instance._rrrate_acc = GetValueFromReader<Decimal?>(dr, 63);
                            instance._rrrate_license = GetValueFromReader<Decimal?>(dr, 64);
                            instance._rrrate_vehrateofreturn = GetValueFromReader<Decimal?>(dr, 65);
                            instance._rrrate_salvageratio = GetValueFromReader<Decimal?>(dr, 66);
                            instance._rrrate_itemprocrate = GetValueFromReader<Decimal?>(dr, 67);
                            instance._rrrate_ruc = GetValueFromReader<Decimal?>(dr, 68);
                            instance._rrrate_accounting = GetValueFromReader<Decimal?>(dr, 69);
                            instance._rrrate_telephone = GetValueFromReader<Decimal?>(dr, 70);
                            instance._rrrate_sundries = GetValueFromReader<Decimal?>(dr, 71);
                            instance._rrrate_sundriesk = GetValueFromReader<Decimal?>(dr, 72);
                            instance._sundriesk = GetValueFromReader<Decimal?>(dr, 73);
                            instance._nmultiplier = GetValueFromReader<Int32?>(dr, 74);
                            instance._ninsurancepct = GetValueFromReader<Decimal?>(dr, 75);
                            instance._nlivery = GetValueFromReader<Decimal?>(dr, 76);
                            instance._nuniform = GetValueFromReader<Decimal?>(dr, 77);
                            instance._naccamount = GetValueFromReader<Decimal?>(dr, 78);
                            instance._nvtkey = GetValueFromReader<Int32?>(dr, 79);
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

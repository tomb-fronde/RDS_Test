using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralwin2
{
    // TJB Frequencies & Vehicles 1-Mar-2021
    // Added vt_list
    //
    // TJB Frequencies & Vehicles Jan-2021
    // Changed sp_GetWhatIfCalc2005 to sp_GetWhatIfCalc2021
    //
    // TJB RPCR_148 May-2020 Added
    // Added uniform allowance to opcost
    //
    // TJB  RPCR_133 July-2019 Replace activity ratio with 100%
    // Implemented by removing (DeliveryDays/MaxDeliveryDays) scaling
    // 
    // TJB Release 7.1.10 Aug-2013 Hack/Workaround
    // Trying to get ReliefWeeks into WhatifReport
    // Try using _rrrate_itemprocrate (appears unused)
    //
    // TJB  RPCR_041  Nov-2012
    // Changed relief_weeks, delivery_cost, processing_cost and relief_cost to decimal

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("contract_seq_number", "_contract_seq_number", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("nominalvehical", "_nominalvehical", "")]
    [MapInfo("delwagerate", "_delwagerate", "")]
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
    [MapInfo("accounting", "_accounting", "")]
    [MapInfo("telephone", "_telephone", "")]
    [MapInfo("sundries", "_sundries", "")]
    [MapInfo("RUC", "_ruc", "")]
    [MapInfo("rrrate_nomvehicle", "_rrrate_nomvehicle", "")]
    [MapInfo("rrrate_del_wage", "_rrrate_del_wage", "")]
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
    [MapInfo("sundriesK", "_sundriesk", "")]
    [MapInfo("nMultiplier", "_nmultiplier", "")]
    [MapInfo("nInsurancePct", "_ninsurancepct", "")]
    [MapInfo("nLivery", "_nlivery", "")]
    [MapInfo("nUniform", "_nuniform", "")]
    [MapInfo("nACCAmount", "_naccamount", "")]
    [MapInfo("nVtKey", "_nvtkey", "")]
    [MapInfo("reliefcost", "_reliefcost", "")]
    [MapInfo("procwagerate", "_procwagerate", "")]
    [MapInfo("rrrate_proc_wage", "_rrrate_proc_wage", "")]
    [MapInfo("relief_weeks", "_relief_weeks", "")]
    [MapInfo("vt_list", "_vt_list", "")]
    [System.Serializable()]

    public class WhatifCalulator2005 : Entity<WhatifCalulator2005>
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
        private decimal? _delwagerate;

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
        private decimal? _vehicledepreciation;

        [DBField()]
        private decimal? _fuelcostperannum;

        [DBField()]
        private decimal? _repairsperannum;

        [DBField()]
        private decimal? _tyrestubesperannum;

        [DBField()]
        private decimal? _deliverycost;

        [DBField()]
        private decimal? _processingcost;

        [DBField()]
        private int? _publicliabilitycost;

        [DBField()]
        private decimal? _accperannum;

        [DBField()]
        private int? _vehicleinsurance;

        [DBField()]
        private decimal? _licensing;

        [DBField()]
        private int? _carrierriskrate;

        [DBField()]
        private int? _benchmark;

        [DBField()]
        private decimal? _rateofreturn_1;

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
        private string _firstrow="N";  //added by jlwang

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
        private decimal? _rrrate_del_wage;

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

        [DBField()]
        private decimal? _reliefcost;

        [DBField()]
        private decimal? _procwagerate;

        [DBField()]
        private decimal? _rrrate_proc_wage;

        [DBField()]
        private decimal? _relief_weeks;

        [DBField()]
        private string _vt_list;

        /*****************************************************************************/
        public virtual decimal? ReliefWeeks
        {
            get
            {
                CanReadProperty("ReliefWeeks", true);
                return _relief_weeks;
            }
            set
            {
                CanWriteProperty("ReliefWeeks", true);
                if (_relief_weeks != value)
                {
                    _relief_weeks = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual decimal? Delwagerate
        {
            get
            {
                CanReadProperty("Delwagerate", true);
                return _delwagerate;
            }
            set
            {
                CanWriteProperty("Delwagerate", true);
                if (_delwagerate != value)
                {
                    _delwagerate = value;
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

        public virtual decimal? Vehicledepreciation
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

        public virtual decimal? Fuelcostperannum
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

        public virtual decimal? Repairsperannum
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

        public virtual decimal? Tyrestubesperannum
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

        public virtual decimal? Deliverycost
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

        public virtual decimal? Processingcost   //public virtual int? Processingcost
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

        public virtual decimal? Accperannum
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

        public virtual decimal? Licensing
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

        public virtual decimal? Rateofreturn1
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

        public virtual decimal? RrrateDelWage
        {
            get
            {
                CanReadProperty("RrrateDelWage", true);
                return _rrrate_del_wage;
            }
            set
            {
                CanWriteProperty("RrrateDelWage", true);
                if (_rrrate_del_wage != value)
                {
                    _rrrate_del_wage = value;
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

        public virtual decimal? Reliefcost
        {
            get
            {
                CanReadProperty("Reliefcost", true);
                return _reliefcost;
            }
            set
            {
                CanWriteProperty("Reliefcost", true);
                if (_reliefcost != value)
                {
                    _reliefcost = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Procwagerate
        {
            get
            {
                CanReadProperty("Procwagerate", true);
                return _procwagerate;
            }
            set
            {
                CanWriteProperty("Procwagerate", true);
                if (_procwagerate != value)
                {
                    _procwagerate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? RrrateProcWage
        {
            get
            {
                CanReadProperty("RrrateProcWage", true);
                return _rrrate_proc_wage;
            }
            set
            {
                CanWriteProperty("RrrateProcWage", true);
                if (_rrrate_proc_wage != value)
                {
                    _rrrate_proc_wage = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string VtList
        {
            get
            {
                CanReadProperty("VtList", true);
                return _vt_list;
            }
            set
            {
                CanWriteProperty("VtList", true);
                if (_vt_list != value)
                {
                    _vt_list = value;
                    PropertyHasChanged();
                }
            }
        }

/**************************************************************************/
        //compute column
        public virtual decimal? Calcdelhours
        {
            get
            {
                CanReadProperty(true);
                return _deliveryhours;
            }
        }

        public virtual string Contract
        {
            get
            {
                CanReadProperty(true);
                //string(contract_no) + "/" + string( contract_seq_number )
                return _contract_no.ToString() + "/" + _contract_seq_number.ToString();
            }
        }

        public virtual decimal Opcost
        {
            get
            {
                CanReadProperty(true);
                //round( if(isNull(calcvd),0,calcvd) + if(isNull(calcfc),0,calcfc) + if(isNull(calcrep),0,calcrep ) + if(isNull(calctt),0,calctt) + 
                //if(isNull(calcdc),0,calcdc ) + if(isNull(calcpc),0,calcpc) + if(isNull(calcpc),0,calcrc) + if(isNull(calcacc),0,calcacc ) + if(isNull(calcvi),0,calcvi ) + if(isNull(calclic),0,calclic ) + if(IsNull(calccrr ),0,calccrr ) + calcpl +
                //if(isnull(sundries ),0,sundries )+  if(isnull(calctel ),0,calctel)+  if(isnull(ruc),0,calcruc* nmultiplier ) + if(isnull(caclacct),0,caclacct) +  
                //if(IsNull(sundriesk),0,sundriesk) * If(IsNull(calcroutedistance ),0,calcroutedistance / 1000) + if(IsNull(rateofreturn_1),0,rateofreturn_1) + 0.5, 0)
                decimal ruc_value;
                if (Ruc == null)
                    ruc_value = 0;
                else
                    ruc_value = Convert.ToDecimal(Calcruc * Nmultiplier);
                //    return decimal.Round((Convert.ToDecimal(Calcvd) + Convert.ToDecimal(Calcfc) + Convert.ToDecimal(Calcrep) + Convert.ToDecimal(Calctt)
                //        + Convert.ToDecimal(Calcdc) + Convert.ToDecimal(Calcpc) + Convert.ToDecimal(Calcrc) + Convert.ToDecimal(Calcacc) + Convert.ToDecimal(Calcvi) + Convert.ToDecimal(Calclic) + Convert.ToDecimal(Calccrr) + Calcpl
                //        + Convert.ToDecimal(Sundries) + Convert.ToDecimal(Calctel) + d_value + Convert.ToDecimal(Caclacct)
                //        + Convert.ToDecimal(Sundriesk) + Convert.ToDecimal(Calcroutedistance / 1000) + Convert.ToDecimal(Rateofreturn1) + Convert.ToDecimal(0.5)), 0);
                decimal dResult = decimal.Round((Calcvd.GetValueOrDefault() 
                                      + Calcfc.GetValueOrDefault() 
                                      + Calcrep.GetValueOrDefault()
                                      + Calctt.GetValueOrDefault() 
                                      + Calcdc.GetValueOrDefault() 
                                      + Calcpc.GetValueOrDefault()   //  + (Calcpc == null ? 0: Calcrc.GetValueOrDefault()) 
                                      + Calcrc.GetValueOrDefault() 
                                      + Calcacc.GetValueOrDefault() 
                                      + Calcvi.GetValueOrDefault()
                                      + Calclic.GetValueOrDefault() 
                                      + Calccrr.GetValueOrDefault() 
                                      + Calcpl.GetValueOrDefault()
                                      + Sundries.GetValueOrDefault() 
                                      + Calctel.GetValueOrDefault()
                                      + ruc_value 
                                      + Caclacct.GetValueOrDefault()
                                      + Sundriesk.GetValueOrDefault() 
                                              * (Calcroutedistance.GetValueOrDefault() / 1000)
                                      + Nuniform.GetValueOrDefault()  // TJB RPCR_148 May-2020 Added
                                      + Rateofreturn1.GetValueOrDefault()
                                      + Convert.ToDecimal(0.5)
                                     ), 0);
                return dResult; 
            }
        }

        private decimal? _calcroutedistance;
        public virtual decimal? Calcroutedistance
        {
            get
            {
                CanReadProperty(true);
                //sum( if(rf_active='Y',( rf_distance  *  rf_daysyear  ),0) for group 1 )
                return _calcroutedistance;
            }
            set
            {
                _calcroutedistance = value;
            }
        }

        public virtual decimal? Calcacc
        {
            get
            {
                CanReadProperty(true);
                //(accrate / 100) * (calcdc + calcpc + calcrc)  +  if(isNull(naccamount ), 0,naccamount)
                return (Accrate / 100) * (Calcdc + Calcpc + Calcrc) + Convert.ToDecimal(Naccamount);
            }
        }

        public virtual decimal? Calcdc
        {
            get
            {
                CanReadProperty(true);
                //(calcdelhours * 52) *  delwagerate
                return Calcdelhours * 52 * _delwagerate;
            }
        }

        public virtual decimal? Calcpc
        {
            get
            {
                CanReadProperty(true);
                //((((calcvolume / itemshour ) / 365) * 7) * 52) * procwagerate
                if (Itemshour.GetValueOrDefault() == 0)
                    return 0;
                else
                    return ((((Calcvolume / Itemshour) / 365) * 7) * 52) * Procwagerate;
            }
        }

        public virtual decimal? Calcrc
        {
            get
            {
                CanReadProperty(true);
                //(calcdelhours * 4) *  delwagerate + ((((calcvolume /  itemshour ) / 365) * 7) * 4) * procwagerate
                
                if (Itemshour == 0)
                    return 0;
                else
                    // TJB  RD7_0036  Aug2009
                    //    Changed calculation to use reliefweeks (currently 5) instead of hard-coded 4 weeks
                    return ((Calcdelhours * _relief_weeks) * Delwagerate)
                                       + (((((Calcvolume / Itemshour) / 365) * 7) * _relief_weeks) * Procwagerate);
                    //return (Calcdelhours * 4) * Delwagerate + ((((Calcvolume / Itemshour) / 365) * 7) * 4) * Procwagerate;
            }
        }

        public virtual decimal? Calcvd
        {
            get
            {
                CanReadProperty(true);
                //round( if(rf_active='Y',(if(isnull(vehicalallow),0,vehicalallow) * calcroutedistance/1000) ,0), 2)                
                decimal re_value;
                if (RfActive == "Y")
                {
                    re_value = Convert.ToDecimal(Vehicalallow * Calcroutedistance / 1000);
                }
                else
                {
                    re_value = 0;
                }
                return decimal.Round(re_value, 2);
            }
        }

        public virtual decimal? Calcfc
        {
            get
            {
                CanReadProperty(true);
                //if(isNull(( consumption / 100 ) * ( fuel / 100 )  * calcroutedistance),0,( consumption / 100 ) * ( fuel / 100 )  * calcroutedistance)
                return Convert.ToDecimal((Consumption / 100) * (Fuel / 100) * Calcroutedistance);
            }
        }

        public virtual decimal? Calcrep
        {
            get
            {
                CanReadProperty(true);
                //if(isNull(calcroutedistance *  repairsmaint / 1000),0,calcroutedistance *  repairsmaint / 1000)
                return Convert.ToDecimal(Calcroutedistance * Repairsmaint / 1000);
            }
        }

        public virtual decimal? Calctt
        {
            get
            {
                CanReadProperty(true);
                //if(IsNull(tyrestubes * (calcroutedistance / 1000) ),0,tyrestubes * (calcroutedistance / 1000) )
                return Convert.ToDecimal(Tyrestubes * (Calcroutedistance / 1000)); ;
            }
        }

        public virtual decimal? Calcruc
        {
            get
            {
                CanReadProperty(true);
                //if( isNull(calcroutedistance) or isNull(ruc), 0, calcroutedistance *  ruc / 1000 )
                return Convert.ToDecimal(Calcroutedistance * Ruc / 1000);
            }
        }

        public virtual decimal? Calcpl
        {
            get
            {
                CanReadProperty(true);
                if (Maxdeliverydays == 0)
                    return 0;
                else   // TJB  RPCR_133  July-2019 Remove activity ratio
                    //return Convert.ToDecimal(Publiclia * (Deliverydays / Maxdeliverydays));
                    return Publiclia;
            }
        }

        public virtual decimal? Calcvi
        {
            get
            {
                CanReadProperty(true);
                if (Maxdeliverydays == 0)
                    return 0;
                else  // TJB  RPCR_133  July-2019 Remove activity ratio
                    //return Convert.ToDecimal(Vehicalinsure * (Deliverydays / Maxdeliverydays));
                    return Vehicalinsure;
            }
        }

        public virtual decimal? Calclic
        {
            get
            {
                CanReadProperty(true);
                if (Maxdeliverydays == 0)
                    return 0;
                else  // TJB  RPCR_133  July-2019 Remove activity ratio
                    //return Convert.ToDecimal(Licence * (Deliverydays / Maxdeliverydays));
                    return Licence;
            }
        }

        public virtual decimal? Calccrr
        {
            get
            {
                CanReadProperty(true);
                if (Maxdeliverydays == 0)
                    return 0;
                else  // TJB  RPCR_133  July-2019 Remove activity ratio
                    //return Convert.ToDecimal(Carrierrisk * (Deliverydays / Maxdeliverydays));
                    return Carrierrisk;
            }
        }

        public virtual decimal? Calctel
        {
            get
            {
                CanReadProperty(true);
                if (Maxdeliverydays == 0)
                    return 0;
                else  // TJB  RPCR_133  July-2019 Remove activity ratio
                    //return Convert.ToDecimal(Telephone * (Deliverydays / Maxdeliverydays));
                    return Telephone;
            }
        }

        public virtual decimal? Caclacct
        {
            get
            {
                CanReadProperty(true);
                if (Maxdeliverydays == 0)
                    return 0;
                else  // TJB  RPCR_133  July-2019 Remove activity ratio
                    //return Convert.ToDecimal(Accounting * (Deliverydays / Maxdeliverydays));
                    return Accounting;
            }
        }

        public virtual decimal? Calcbenchmark
        {
            get
            {
                CanReadProperty(true);
                //calcvd + calcfc + calcrep + calctt + calcdc + calcpc + calcrc + calcacc 
                //+ calcvi + calclic + calccrr  + calcpl + if( isnull(sundries),0,sundries)
                //+ if(isnull(telephone),0,telephone)+  if(isnull(ruc),0,ruc* nmultiplier) 
                //+ if(isnull(accounting),0,accounting) + if(isnull(rateofreturn_1),0,rateofreturn_1)
                return Calcvd + Calcfc + Calcrep + Calctt + Calcdc + Calcpc + Calcrc 
                     + Calcacc + Calcvi + Calclic + Calccrr + Calcpl 
                     + Convert.ToDecimal(Sundries) + Convert.ToDecimal(Telephone) 
                     + Convert.ToDecimal(Ruc) * Nmultiplier + Convert.ToDecimal(Accounting) 
                     + Convert.ToDecimal(Rateofreturn1);
            }
        }

        public virtual decimal? Variance
        {
            get
            {
                CanReadProperty(true);
                //finalbenchmark - opcost                
                return Finalbenchmark - Opcost;
            }
        }

        public virtual decimal? Benchdiff
        {
            get
            {
                CanReadProperty(true);
                //round( finalbenchmark, 0)  - round(calcbenchmark, 0)
                return Finalbenchmark - decimal.Round(Convert.ToDecimal(Calcbenchmark), 0);
            }
        }

        public virtual decimal? Calcvolume
        {
            get
            {
                CanReadProperty(true);
                //numberboxholders * itemspercust            
                return Numberboxholders * Itemspercust;
            }
        }

        public virtual decimal? Vardist
        {
            get
            {
                CanReadProperty(true);
                //round( opcost - currentpayment, 2 )         
                return decimal.Round((Convert.ToDecimal(Opcost) - Convert.ToDecimal(_currentpayment)), 2);
            }
        }

        public virtual decimal? Calcrel
        {
            get
            {
                CanReadProperty(true);
                //round(sum(if(firstrow='Y',licence * ( deliverydays  /  maxdeliverydays ),0) for all),2)             
                return null;
            }
        }

        public virtual decimal? Taccounting
        {
            get
            {
                CanReadProperty(true);
                //round(sum(if(firstrow='Y',  accounting * ( deliverydays  /  maxdeliverydays ),0) for all),2)     
                return null;
            }
        }

        public virtual decimal? Maxdaysallcontracts
        {
            get
            {
                CanReadProperty(true);
                //max( maxdeliverydays )        
                return _deliveryhours;
            }
        }

        protected override object GetIdValue()
        {
            return ContractNo.ToString() + "/" + SfKey.ToString();
        }
        #endregion

        #region Factory Methods
        public static WhatifCalulator2005 NewWhatifCalulator2005(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
        {
            return Create(inContract, inSequence, inRGCode, inEffectDate, inVolumeSource);
        }

        public static WhatifCalulator2005[] GetAllWhatifCalulator2005(int? inContract, int? inSequence, int? inRGCode, DateTime? inEffectDate, string inVolumeSource)
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
                    //cm.CommandText = "rd.sp_GetWhatIfCalc2005";
                    cm.CommandText = "rd.sp_GetWhatIfCalc2021";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContract", inContract);
                    pList.Add(cm, "inSequence", inSequence);
                    pList.Add(cm, "inRGCode", inRGCode);
                    pList.Add(cm, "inEffectDate", inEffectDate);
                    pList.Add(cm, "inVolumeSource", inVolumeSource);

                    List<WhatifCalulator2005> _list = new List<WhatifCalulator2005>();

                    try
                    {
                        using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                        {
                            while (dr.Read())
                            {
                                WhatifCalulator2005 instance = new WhatifCalulator2005();
                                instance._contract_no = GetValueFromReader<int?>(dr, 0);
                                instance._contract_seq_number = GetValueFromReader<int?>(dr, 1);
                                instance._con_title = GetValueFromReader<string>(dr, 2);
                                instance._nominalvehical = GetValueFromReader<decimal?>(dr, 3);
                                instance._delwagerate = GetValueFromReader<decimal?>(dr, 4);
                                instance._repairsmaint = GetValueFromReader<decimal?>(dr, 5);
                                instance._tyrestubes = GetValueFromReader<decimal?>(dr, 6);
                                instance._vehicalallow = GetValueFromReader<decimal?>(dr, 7);
                                instance._vehicalinsure = GetValueFromReader<decimal?>(dr, 8);
                                instance._publiclia = GetValueFromReader<decimal?>(dr, 9);
                                instance._carrierrisk = GetValueFromReader<decimal?>(dr, 10);
                                instance._accrate = GetValueFromReader<decimal?>(dr, 11);
                                instance._licence = GetValueFromReader<decimal?>(dr, 12);
                                instance._rateofreturn = GetValueFromReader<decimal?>(dr, 13);
                                instance._salvageratio = GetValueFromReader<decimal?>(dr, 14);
                                instance._itemshour = GetValueFromReader<decimal?>(dr, 15);
                                instance._fuel = GetValueFromReader<decimal?>(dr, 16);
                                instance._consumption = GetValueFromReader<decimal?>(dr, 17);
                                instance._routedistance = GetValueFromReader<decimal?>(dr, 18);
                                instance._deliveryhours = GetValueFromReader<decimal?>(dr, 19);
                                instance._processinghours = GetValueFromReader<decimal?>(dr, 20);
                                instance._volume = GetValueFromReader<decimal?>(dr, 21);
                                instance._deliverydays = GetValueFromReader<decimal?>(dr, 22);
                                instance._maxdeliverydays = GetValueFromReader<decimal?>(dr, 23);
                                instance._numberboxholders = GetValueFromReader<int?>(dr, 24);
                                instance._routedistanceperday = GetValueFromReader<int?>(dr, 25);
                                instance._vehicledepreciation = GetValueFromReader<decimal?>(dr, 26);
                                instance._fuelcostperannum = GetValueFromReader<decimal?>(dr, 27);
                                instance._repairsperannum = GetValueFromReader<decimal?>(dr, 28);
                                instance._tyrestubesperannum = GetValueFromReader<decimal?>(dr, 29);
                                instance._deliverycost = GetValueFromReader<decimal?>(dr, 30);
                                instance._processingcost = GetValueFromReader<decimal?>(dr, 31);
                                instance._publicliabilitycost = GetValueFromReader<int?>(dr, 32);
                                instance._accperannum = GetValueFromReader<decimal?>(dr, 33);
                                instance._vehicleinsurance = GetValueFromReader<int?>(dr, 34);
                                instance._licensing = GetValueFromReader<decimal?>(dr, 35);
                                instance._carrierriskrate = GetValueFromReader<int?>(dr, 36);
                                instance._benchmark = GetValueFromReader<int?>(dr, 37);
                                instance._rateofreturn_1 = GetValueFromReader<decimal?>(dr, 38);
                                instance._finalbenchmark = GetValueFromReader<int?>(dr, 39);
                                instance._retainedallowances = GetValueFromReader<decimal?>(dr, 40);
                                instance._currentpayment = GetValueFromReader<decimal?>(dr, 41);
                                instance._sf_key = GetValueFromReader<int?>(dr, 42);
                                instance._rf_distance = GetValueFromReader<decimal?>(dr, 43);
                                instance._rf_deliverydays = GetValueFromReader<string>(dr, 44);
                                instance._rf_daysyear = GetValueFromReader<int?>(dr, 45);
                                instance._rf_daysweek = GetValueFromReader<int?>(dr, 46);
                                instance._itemspercust = GetValueFromReader<decimal?>(dr, 47);
                                instance._rf_active = GetValueFromReader<string>(dr, 48);
                                instance._firstrow = GetValueFromReader<string>(dr, 49);
                                instance._currentbenchmark = GetValueFromReader<decimal?>(dr, 50);
                                instance._accounting = GetValueFromReader<decimal?>(dr, 51);
                                instance._telephone = GetValueFromReader<decimal?>(dr, 52);
                                instance._sundries = GetValueFromReader<decimal?>(dr, 53);
                                instance._ruc = GetValueFromReader<decimal?>(dr, 54);
                                instance._rrrate_nomvehicle = GetValueFromReader<decimal?>(dr, 55);
                                instance._rrrate_del_wage = GetValueFromReader<decimal?>(dr, 56);
                                instance._rrrate_repairsmaint = GetValueFromReader<decimal?>(dr, 57);
                                instance._rrrate_tyretubes = GetValueFromReader<decimal?>(dr, 58);
                                instance._rrrate_vehallow = GetValueFromReader<decimal?>(dr, 59);
                                instance._rrrate_vehinsurance = GetValueFromReader<decimal?>(dr, 60);
                                instance._rrrate_publiclia = GetValueFromReader<decimal?>(dr, 61);
                                instance._rrrate_carrierrisk = GetValueFromReader<decimal?>(dr, 62);
                                instance._rrrate_acc = GetValueFromReader<decimal?>(dr, 63);
                                instance._rrrate_license = GetValueFromReader<decimal?>(dr, 64);
                                instance._rrrate_vehrateofreturn = GetValueFromReader<decimal?>(dr, 65);
                                instance._rrrate_salvageratio = GetValueFromReader<decimal?>(dr, 66);
                                instance._rrrate_itemprocrate = GetValueFromReader<decimal?>(dr, 67);
                                instance._rrrate_ruc = GetValueFromReader<decimal?>(dr, 68);
                                instance._rrrate_accounting = GetValueFromReader<decimal?>(dr, 69);
                                instance._rrrate_telephone = GetValueFromReader<decimal?>(dr, 70);
                                instance._rrrate_sundries = GetValueFromReader<decimal?>(dr, 71);
                                instance._rrrate_sundriesk = GetValueFromReader<decimal?>(dr, 72);
                                instance._sundriesk = GetValueFromReader<decimal?>(dr, 73);
                                instance._nmultiplier = GetValueFromReader<int?>(dr, 74);
                                instance._ninsurancepct = GetValueFromReader<decimal?>(dr, 75);
                                instance._nlivery = GetValueFromReader<decimal?>(dr, 76);
                                instance._nuniform = GetValueFromReader<decimal?>(dr, 77);
                                instance._naccamount = GetValueFromReader<decimal?>(dr, 78);
                                instance._nvtkey = GetValueFromReader<int?>(dr, 79);
                                instance._reliefcost = GetValueFromReader<decimal?>(dr, 80);
                                instance._procwagerate = GetValueFromReader<decimal?>(dr, 81);
                                instance._rrrate_proc_wage = GetValueFromReader<decimal?>(dr, 82);
                                instance._relief_weeks = GetValueFromReader<decimal?>(dr, 83);
                                instance._vt_list = GetValueFromReader<string>(dr, 84);
                                // TJB Aug-2013 Hack
                                // Trying to get ReliefWeeks into WhatifReport
                                // Try using _rrrate_itemprocrate (appears unused)
                                instance._rrrate_itemprocrate = instance._relief_weeks;
                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
                            list = _list.ToArray();
                        }
                    }
                    catch (Exception e)
                    {
                        sqlCode = -1;
                        sqlErrText = e.Message;
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

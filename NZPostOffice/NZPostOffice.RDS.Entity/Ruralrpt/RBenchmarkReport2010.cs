using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // TJB Frequencies & Vehicles 17-Feb-2021
    // Updated stored proc to sp_GetBenchmarkRpt2021
    //
    // TJB RPCR_147  May-2020
    // Changed stored procedure called
    // Added freqdesc, freqdays,freqdist 6 - 12
    //
    // TJB RPCR_054  July-2013
    // Changed stored proc name to reflect change in piece rate handling
    // 
    // TJB Oct-2010 Changed prcedure name and added frequency info

	// Mapping info for object fields to DB
	// Mapping fieldname, entity fieldname, database table name, form name
	// Application Form Name : BE
	[MapInfo("contract_no", "_contract_no", "")]
	[MapInfo("contract_seq_number", "_contract_seq_number", "")]
	[MapInfo("con_title", "_con_title", "")]
	[MapInfo("rdfile", "_rdfile", "")]
	[MapInfo("rcmfile", "_rcmfile", "")]
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
	[MapInfo("numbercustomers", "_numbercustomers", "")]
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
	[MapInfo("rateofreturncost", "_rateofreturncost", "")]
	[MapInfo("finalbenchmark", "_finalbenchmark", "")]
	[MapInfo("retainedallowances", "_retainedallowances", "")]
	[MapInfo("currentpayment", "_currentpayment", "")]
	[MapInfo("prs_supplier1", "_prs_supplier1", "")]
	[MapInfo("prs_cost1", "_prs_cost1", "")]
	[MapInfo("prs_supplier2", "_prs_supplier2", "")]
	[MapInfo("prs_cost2", "_prs_cost2", "")]
	[MapInfo("prs_supplier3", "_prs_supplier3", "")]
	[MapInfo("prs_cost3", "_prs_cost3", "")]
	[MapInfo("prs_supplier4", "_prs_supplier4", "")]
	[MapInfo("prs_cost4", "_prs_cost4", "")]
	[MapInfo("prs_supplier5", "_prs_supplier5", "")]
	[MapInfo("prs_cost5", "_prs_cost5", "")]
	[MapInfo("renewalgroup", "_renewalgroup", "")]
	[MapInfo("renewaldate", "_renewaldate", "")]
	[MapInfo("accounting", "_accounting", "")]
	[MapInfo("telephone", "_telephone", "")]
	[MapInfo("sundries", "_sundries", "")]
	[MapInfo("RUC", "_ruc", "")]
	[MapInfo("sundriesk", "_sundriesk", "")]
	[MapInfo("nLiveryPerAnnum", "_nliveryperannum", "")]
	[MapInfo("nUniformPerAnnum", "_nuniformperannum", "")]
	[MapInfo("deliverydaysforreport", "_deliverydaysforreport", "")]
	[MapInfo("reliefcost", "_reliefcost", "")]
	[MapInfo("dStartDate", "_dstartdate", "")]
	[MapInfo("dEndDate", "_denddate", "")]
	[MapInfo("PRStartDate", "_prstartdate", "")]
	[MapInfo("PREndDate", "_prenddate", "")]

    // TJB Sept-2010 ----------- Added --------------------
    [MapInfo("FreqDesc1", "_freqdesc1", "")]
    [MapInfo("FreqDays1", "_freqdays1", "")]
    [MapInfo("FreqDist1", "_freqdist1", "")]
    [MapInfo("FreqDesc2", "_freqdesc2", "")]
    [MapInfo("FreqDays2", "_freqdays2", "")]
    [MapInfo("FreqDist2", "_freqdist2", "")]
    [MapInfo("FreqDesc3", "_freqdesc3", "")]
    [MapInfo("FreqDays3", "_freqdays3", "")]
    [MapInfo("FreqDist3", "_freqdist3", "")]
    [MapInfo("FreqDesc4", "_freqdesc4", "")]
    [MapInfo("FreqDays4", "_freqdays4", "")]
    [MapInfo("FreqDist4", "_freqdist4", "")]
    [MapInfo("FreqDesc5", "_freqdesc5", "")]
    [MapInfo("FreqDays5", "_freqdays5", "")]
    [MapInfo("FreqDist5", "_freqdist5", "")]
    // TJB Sept-2010 ----------- Add end ------------------
    // TJB May-2020  -----------  Added  ------------------
    [MapInfo("FreqDesc6", "_freqdesc6", "")]
    [MapInfo("FreqDays6", "_freqdays6", "")]
    [MapInfo("FreqDist6", "_freqdist6", "")]
    [MapInfo("FreqDesc7", "_freqdesc7", "")]
    [MapInfo("FreqDays7", "_freqdays7", "")]
    [MapInfo("FreqDist7", "_freqdist7", "")]
    [MapInfo("FreqDesc8", "_freqdesc8", "")]
    [MapInfo("FreqDays8", "_freqdays8", "")]
    [MapInfo("FreqDist8", "_freqdist8", "")]
    [MapInfo("FreqDesc9", "_freqdesc9", "")]
    [MapInfo("FreqDays9", "_freqdays9", "")]
    [MapInfo("FreqDist9", "_freqdist9", "")]
    [MapInfo("FreqDesc10", "_freqdesc10", "")]
    [MapInfo("FreqDays10", "_freqdays10", "")]
    [MapInfo("FreqDist10", "_freqdist10", "")]
    [MapInfo("FreqDesc11", "_freqdesc11", "")]
    [MapInfo("FreqDays11", "_freqdays11", "")]
    [MapInfo("FreqDist11", "_freqdist11", "")]
    [MapInfo("FreqDesc12", "_freqdesc12", "")]
    [MapInfo("FreqDays12", "_freqdays12", "")]
    [MapInfo("FreqDist12", "_freqdist12", "")]
    // TJB May-2020  ----------- Add end ------------------
    
    [System.Serializable()]

	public class BenchmarkReport2010 : Entity<BenchmarkReport2010>
	{
		#region Business Methods
		[DBField()]
		private int?  _contract_no;

		[DBField()]
		private int?  _contract_seq_number;

		[DBField()]
		private string  _con_title;

		[DBField()]
		private string  _rdfile;

		[DBField()]
		private string  _rcmfile;

		[DBField()]
		private decimal?  _nominalvehical;

		[DBField()]
		private decimal?  _wagehourlyrate;

		[DBField()]
		private decimal?  _repairsmaint;

		[DBField()]
		private decimal?  _tyrestubes;

		[DBField()]
		private decimal?  _vehicalallow;

		[DBField()]
		private decimal?  _vehicalinsure;

		[DBField()]
		private decimal?  _publiclia;

		[DBField()]
		private decimal?  _carrierrisk;

		[DBField()]
		private decimal?  _accrate;

		[DBField()]
		private decimal?  _licence;

		[DBField()]
		private decimal?  _rateofreturn;

		[DBField()]
		private decimal?  _salvageratio;

		[DBField()]
		private decimal?  _itemshour;

		[DBField()]
		private decimal?  _fuel;

		[DBField()]
		private decimal?  _consumption;

		[DBField()]
		private decimal?  _routedistance;

		[DBField()]
		private decimal?  _deliveryhours;

		[DBField()]
		private decimal?  _processinghours;

		[DBField()]
		private decimal?  _volume;

		[DBField()]
		private decimal?  _deliverydays;

		[DBField()]
		private decimal?  _maxdeliverydays;

		[DBField()]
		private int?  _numbercustomers;

		[DBField()]
		private decimal?  _routedistanceperday;

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
        private decimal? _publicliabilitycost;

		[DBField()]
        private decimal? _accperannum;

		[DBField()]
        private decimal? _vehicleinsurance;

		[DBField()]
        private decimal? _licensing;

		[DBField()]
        private decimal? _carrierriskrate;

		[DBField()]
        private decimal? _benchmark;

		[DBField()]
        private decimal? _rateofreturncost;

		[DBField()]
        private decimal? _finalbenchmark;

		[DBField()]
		private decimal?  _retainedallowances;

		[DBField()]
		private decimal?  _currentpayment;

		[DBField()]
		private string  _prs_supplier1;

		[DBField()]
        private decimal? _prs_cost1;

		[DBField()]
		private string  _prs_supplier2;

		[DBField()]
        private decimal? _prs_cost2;

		[DBField()]
		private string  _prs_supplier3;

		[DBField()]
        private decimal? _prs_cost3;

		[DBField()]
		private string  _prs_supplier4;

		[DBField()]
        private decimal? _prs_cost4;

		[DBField()]
		private string  _prs_supplier5;

		[DBField()]
        private decimal? _prs_cost5;

		[DBField()]
		private string  _renewalgroup;

		[DBField()]
		private DateTime?  _renewaldate;

		[DBField()]
		private decimal?  _accounting;

		[DBField()]
		private decimal?  _telephone;

		[DBField()]
		private decimal?  _sundries;

		[DBField()]
		private decimal?  _ruc;

		[DBField()]
		private decimal?  _sundriesk;

		[DBField()]
		private decimal?  _nliveryperannum;

		[DBField()]
		private decimal?  _nuniformperannum;

		[DBField()]
		private decimal?  _deliverydaysforreport;

		[DBField()]
        private decimal? _reliefcost;

		[DBField()]
		private DateTime?  _dstartdate;

		[DBField()]
		private DateTime?  _denddate;

		[DBField()]
		private DateTime?  _prstartdate;

		[DBField()]
		private DateTime?  _prenddate;

        [DBField()]
        private DateTime? _dexpirydate;

        // TJB Sept-2010 ----------- Added --------------------
        [DBField()]
        private string _freqdesc1;

        [DBField()]
        private string _freqdays1;

        [DBField()]
        private decimal? _freqdist1;

        [DBField()]
        private string _freqdesc2;

        [DBField()]
        private string _freqdays2;

        [DBField()]
        private decimal? _freqdist2;

        [DBField()]
        private string _freqdesc3;

        [DBField()]
        private string _freqdays3;

        [DBField()]
        private decimal? _freqdist3;

        [DBField()]
        private string _freqdesc4;

        [DBField()]
        private string _freqdays4;

        [DBField()]
        private decimal? _freqdist4;

        [DBField()]
        private string _freqdesc5;

        [DBField()]
        private string _freqdays5;

        [DBField()]
        private decimal? _freqdist5;
        // TJB Sept-2010 ----------- Add end ------------------
        // TJB May-2020  -----------  Added  ------------------
        [DBField()]
        private string _freqdesc6;

        [DBField()]
        private string _freqdays6;

        [DBField()]
        private decimal? _freqdist6;

        [DBField()]
        private string _freqdesc7;

        [DBField()]
        private string _freqdays7;

        [DBField()]
        private decimal? _freqdist7;

        [DBField()]
        private string _freqdesc8;

        [DBField()]
        private string _freqdays8;

        [DBField()]
        private decimal? _freqdist8;

        [DBField()]
        private string _freqdesc9;

        [DBField()]
        private string _freqdays9;

        [DBField()]
        private decimal? _freqdist9;

        [DBField()]
        private string _freqdesc10;

        [DBField()]
        private string _freqdays10;

        [DBField()]
        private decimal? _freqdist10;

        [DBField()]
        private string _freqdesc11;

        [DBField()]
        private string _freqdays11;

        [DBField()]
        private decimal? _freqdist11;

        [DBField()]
        private string _freqdesc12;

        [DBField()]
        private string _freqdays12;

        [DBField()]
        private decimal? _freqdist12;
        // TJB May-2020  ----------- Add end ------------------

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
				if ( _contract_seq_number != value )
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
				if ( _con_title != value )
				{
					_con_title = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Rdfile
		{
			get
			{
                CanReadProperty("Rdfile", true);
				return _rdfile;
			}
			set
			{
                CanWriteProperty("Rdfile", true);
				if ( _rdfile != value )
				{
					_rdfile = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Rcmfile
		{
			get
			{
                CanReadProperty("Rcmfile", true);
				return _rcmfile;
			}
			set
			{
                CanWriteProperty("Rcmfile", true);
				if ( _rcmfile != value )
				{
					_rcmfile = value;
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
				if ( _nominalvehical != value )
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
				if ( _wagehourlyrate != value )
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
				if ( _repairsmaint != value )
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
				if ( _tyrestubes != value )
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
				if ( _vehicalallow != value )
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
				if ( _vehicalinsure != value )
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
				if ( _publiclia != value )
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
				if ( _carrierrisk != value )
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
				if ( _accrate != value )
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
				if ( _licence != value )
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
				if ( _rateofreturn != value )
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
				if ( _salvageratio != value )
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
				if ( _itemshour != value )
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
				if ( _fuel != value )
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
				if ( _consumption != value )
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
				if ( _routedistance != value )
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
				if ( _deliveryhours != value )
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
				if ( _processinghours != value )
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
				if ( _volume != value )
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
				if ( _deliverydays != value )
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
				if ( _maxdeliverydays != value )
				{
					_maxdeliverydays = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual int? Numbercustomers
		{
			get
			{
                CanReadProperty("Numbercustomers", true);
				return _numbercustomers;
			}
			set
			{
                CanWriteProperty("Numbercustomers", true);
				if ( _numbercustomers != value )
				{
					_numbercustomers = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Routedistanceperday
		{
			get
			{
                CanReadProperty("Routedistanceperday", true);
				return _routedistanceperday;
			}
			set
			{
                CanWriteProperty("Routedistanceperday", true);
				if ( _routedistanceperday != value )
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
				if ( _vehicledepreciation != value )
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
				if ( _fuelcostperannum != value )
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
				if ( _repairsperannum != value )
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
				if ( _tyrestubesperannum != value )
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
				if ( _deliverycost != value )
				{
					_deliverycost = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Processingcost
		{
			get
			{
                CanReadProperty("Processingcost", true);
				return _processingcost;
			}
			set
			{
                CanWriteProperty("Processingcost", true);
				if ( _processingcost != value )
				{
					_processingcost = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Publicliabilitycost
		{
			get
			{
                CanReadProperty("Publicliabilitycost", true);
				return _publicliabilitycost;
			}
			set
			{
                CanWriteProperty("Publicliabilitycost", true);
				if ( _publicliabilitycost != value )
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
				if ( _accperannum != value )
				{
					_accperannum = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Vehicleinsurance
		{
			get
			{
                CanReadProperty("Vehicleinsurance", true);
				return _vehicleinsurance;
			}
			set
			{
                CanWriteProperty("Vehicleinsurance", true);
				if ( _vehicleinsurance != value )
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
				if ( _licensing != value )
				{
					_licensing = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Carrierriskrate
		{
			get
			{
                CanReadProperty("Carrierriskrate", true);
				return _carrierriskrate;
			}
			set
			{
                CanWriteProperty("Carrierriskrate", true);
				if ( _carrierriskrate != value )
				{
					_carrierriskrate = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Benchmark
		{
			get
			{
                CanReadProperty("Benchmark", true);
				return _benchmark;
			}
			set
			{
                CanWriteProperty("Benchmark", true);
				if ( _benchmark != value )
				{
					_benchmark = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Rateofreturncost
		{
			get
			{
                CanReadProperty("Rateofreturncost", true);
				return _rateofreturncost;
			}
			set
			{
                CanWriteProperty("Rateofreturncost", true);
				if ( _rateofreturncost != value )
				{
					_rateofreturncost = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? Finalbenchmark
		{
			get
			{
                CanReadProperty("Finalbenchmark", true);
				return _finalbenchmark;
			}
			set
			{
                CanWriteProperty("Finalbenchmark", true);
				if ( _finalbenchmark != value )
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
				if ( _retainedallowances != value )
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
				if ( _currentpayment != value )
				{
					_currentpayment = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsSupplier1
		{
			get
			{
                CanReadProperty("PrsSupplier1", true);
				return _prs_supplier1;
			}
			set
			{
                CanWriteProperty("PrsSupplier1", true);
				if ( _prs_supplier1 != value )
				{
					_prs_supplier1 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? PrsCost1
		{
			get
			{
                CanReadProperty("PrsCost1", true);
				return _prs_cost1;
			}
			set
			{
                CanWriteProperty("PrsCost1", true);
				if ( _prs_cost1 != value )
				{
					_prs_cost1 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsSupplier2
		{
			get
			{
                CanReadProperty("PrsSupplier2", true);
				return _prs_supplier2;
			}
			set
			{
                CanWriteProperty("PrsSupplier2", true);
				if ( _prs_supplier2 != value )
				{
					_prs_supplier2 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? PrsCost2
		{
			get
			{
                CanReadProperty("PrsCost2", true);
				return _prs_cost2;
			}
			set
			{
                CanWriteProperty("PrsCost2", true);
				if ( _prs_cost2 != value )
				{
					_prs_cost2 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsSupplier3
		{
			get
			{
                CanReadProperty("PrsSupplier3", true);
				return _prs_supplier3;
			}
			set
			{
                CanWriteProperty("PrsSupplier3", true);
				if ( _prs_supplier3 != value )
				{
					_prs_supplier3 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? PrsCost3
		{
			get
			{
                CanReadProperty("PrsCost3", true);
				return _prs_cost3;
			}
			set
			{
                CanWriteProperty("PrsCost3", true);
				if ( _prs_cost3 != value )
				{
					_prs_cost3 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsSupplier4
		{
			get
			{
                CanReadProperty("PrsSupplier4", true);
				return _prs_supplier4;
			}
			set
			{
                CanWriteProperty("PrsSupplier4", true);
				if ( _prs_supplier4 != value )
				{
					_prs_supplier4 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? PrsCost4
		{
			get
			{
                CanReadProperty("PrsCost4", true);
				return _prs_cost4;
			}
			set
			{
                CanWriteProperty("PrsCost4", true);
				if ( _prs_cost4 != value )
				{
					_prs_cost4 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string PrsSupplier5
		{
			get
			{
                CanReadProperty("PrsSupplier5", true);
				return _prs_supplier5;
			}
			set
			{
                CanWriteProperty("PrsSupplier5", true);
				if ( _prs_supplier5 != value )
				{
					_prs_supplier5 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual decimal? PrsCost5
		{
			get
			{
                CanReadProperty("PrsCost5", true);
				return _prs_cost5;
			}
			set
			{
                CanWriteProperty("PrsCost5", true);
				if ( _prs_cost5 != value )
				{
					_prs_cost5 = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual string Renewalgroup
		{
			get
			{
                CanReadProperty("Renewalgroup", true);
				return _renewalgroup;
			}
			set
			{
                CanWriteProperty("Renewalgroup", true);
				if ( _renewalgroup != value )
				{
					_renewalgroup = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Renewaldate
		{
			get
			{
                CanReadProperty("Renewaldate", true);
				return _renewaldate;
			}
			set
			{
                CanWriteProperty("Renewaldate", true);
				if ( _renewaldate != value )
				{
					_renewaldate = value;
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
				if ( _accounting != value )
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
				if ( _telephone != value )
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
				if ( _sundries != value )
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
				if ( _ruc != value )
				{
					_ruc = value;
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
				if ( _sundriesk != value )
				{
					_sundriesk = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Nliveryperannum
		{
			get
			{
                CanReadProperty("Nliveryperannum", true);
				return _nliveryperannum;
			}
			set
			{
                CanWriteProperty("Nliveryperannum", true);
				if ( _nliveryperannum != value )
				{
					_nliveryperannum = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Nuniformperannum
		{
			get
			{
                CanReadProperty("Nuniformperannum", true);
				return _nuniformperannum;
			}
			set
			{
                CanWriteProperty("Nuniformperannum", true);
				if ( _nuniformperannum != value )
				{
					_nuniformperannum = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual decimal? Deliverydaysforreport
		{
			get
			{
                CanReadProperty("Deliverydaysforreport", true);
				return _deliverydaysforreport;
			}
			set
			{
                CanWriteProperty("Deliverydaysforreport", true);
				if ( _deliverydaysforreport != value )
				{
					_deliverydaysforreport = value;
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
				if ( _reliefcost != value )
				{
					_reliefcost = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Dstartdate
		{
			get
			{
                CanReadProperty("Dstartdate", true);
				return _dstartdate;
			}
			set
			{
                CanWriteProperty("Dstartdate", true);
				if ( _dstartdate != value )
				{
					_dstartdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Denddate
		{
			get
			{
                CanReadProperty("Denddate", true);
				return _denddate;
			}
			set
			{
                CanWriteProperty("Denddate", true);
				if ( _denddate != value )
				{
					_denddate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Prstartdate
		{
			get
			{
                CanReadProperty("Prstartdate", true);
				return _prstartdate;
			}
			set
			{
                CanWriteProperty("Prstartdate", true);
				if ( _prstartdate != value )
				{
					_prstartdate = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual DateTime? Prenddate
		{
			get
			{
                CanReadProperty("Prenddate", true);
				return _prenddate;
			}
			set
			{
                CanWriteProperty("Prenddate", true);
				if ( _prenddate != value )
				{
					_prenddate = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual DateTime? Dexpirydate
        {
            get
            {
                CanReadProperty("Dexpirydate", true);
                return _dexpirydate;
            }
            set
            {
                CanWriteProperty("Dexpirydate", true);
                if (_dexpirydate != value)
                {
                    _dexpirydate = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute1
        {
            get
            {
                CanReadProperty(true);
                return ContractNo.ToString() + "/" + ContractSeqNumber.ToString();
            }
        }

        public virtual Decimal? Compute3
        {
            get
            {
                CanReadProperty(true);
                if (Routedistance.GetValueOrDefault() != 0)
                {
                    return Finalbenchmark / Routedistance;
                }
                else {
                    return 0;//p! added to avoid division by 0 exception
                }
            }
        }

        public virtual Decimal? Prtotal
        {
            get
            {
                CanReadProperty(true);
                //if(isnull(prs_cost1),0,prs_cost1) + if(isnull(prs_cost2),0,prs_cost2) + if(isnull(prs_cost3),0,prs_cost3) + if(isnull(prs_cost4),0,prs_cost4) + if(isnull(prs_cost5),0,prs_cost5)
                return Convert.ToInt32(PrsCost1) + Convert.ToInt32(PrsCost2) + Convert.ToInt32(PrsCost3) + Convert.ToInt32(PrsCost4) + Convert.ToInt32(PrsCost5);
            }
        }

        public virtual Decimal? Totalfloor
        {
            get
            {
                CanReadProperty(true);
                //round( finalbenchmark + 0.5 ,0)
                return Decimal.Round(Convert.ToDecimal(Finalbenchmark + 0.5m), 0);
            }
        }

        public virtual Decimal? Compute4
        {
            get
            {
                CanReadProperty(true);
                //if(isnull( totalfloor ),0, totalfloor ) -if(isnull(currentpayment),0,currentpayment) 
                return Convert.ToDecimal(Totalfloor) - Convert.ToDecimal(Currentpayment);
            }
        }

        public virtual Decimal? Compute5
        {
            get
            {
                CanReadProperty(true);
                //prtotal +  if(isnull( totalfloor ),0, totalfloor )
                return Prtotal + Convert.ToDecimal(Totalfloor);
            }
        }

        public virtual Decimal? PprojectedHourlyRate
        {
            get
            {
                CanReadProperty(true);
                //?round(sum(prtotal + deliverycost + processingcost) /sum(deliveryhours / 7 * 365 + volume/500),2)
                return 0;
            }
        }

        public virtual DateTime? DEnddate
        {
            get
            {
                CanReadProperty(true);
                //if( isnull(denddate), relativedate(dstartdate,364), denddate) 
                if (_denddate == null)
                {
                   //? return relativedate(dstartdate,364);
                    return _dstartdate.GetValueOrDefault().AddDays(364);//Dstartdate;
                }
                else{
                    return _denddate;//DEnddate;
                }
            }
        }

        public virtual DateTime? Compute6
        {
            get
            {
                CanReadProperty(true);
                return DateTime.Today;
            }
        }

        // TJB Sept-2010 ----------- Added --------------------
        public virtual string FreqDesc1
        {
            get
            {
                CanReadProperty("FreqDesc1", true);
                return _freqdesc1;
            }
            set
            {
                CanWriteProperty("FreqDesc1", true);
                if (_freqdesc1 != value)
                {
                    _freqdesc1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string FreqDays1
        {
            get
            {
                CanReadProperty("FreqDays1", true);
                return _freqdays1;
            }
            set
            {
                CanWriteProperty("FreqDays1", true);
                if (_freqdays1 != value)
                {
                    _freqdays1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? FreqDist1
        {
            get
            {
                CanReadProperty("FreqDist1", true);
                return _freqdist1;
            }
            set
            {
                CanWriteProperty("FreqDist1", true);
                if (_freqdist1 != value)
                {
                    _freqdist1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string FreqDesc2
        {
            get
            {
                CanReadProperty("FreqDesc2", true);
                return _freqdesc2;
            }
        }

        public virtual string FreqDays2
        {
            get
            {
                CanReadProperty("FreqDays2", true);
                return _freqdays2;
            }
        }

        public virtual Decimal? FreqDist2
        {
            get
            {
                CanReadProperty("FreqDist2", true);
                return _freqdist2;
            }
        }

        public virtual string FreqDesc3
        {
            get
            {
                CanReadProperty("FreqDesc3", true);
                return _freqdesc3;
            }
        }

        public virtual string FreqDays3
        {
            get
            {
                CanReadProperty("FreqDays3", true);
                return _freqdays3;
            }
        }

        public virtual Decimal? FreqDist3
        {
            get
            {
                CanReadProperty("FreqDist3", true);
                return _freqdist3;
            }
        }

        public virtual string FreqDesc4
        {
            get
            {
                CanReadProperty("FreqDesc4", true);
                return _freqdesc4;
            }
        }

        public virtual string FreqDays4
        {
            get
            {
                CanReadProperty("FreqDays4", true);
                return _freqdays4;
            }
        }

        public virtual Decimal? FreqDist4
        {
            get
            {
                CanReadProperty("FreqDist4", true);
                return _freqdist4;
            }
        }

        public virtual string FreqDesc5
        {
            get
            {
                CanReadProperty("FreqDesc5", true);
                return _freqdesc5;
            }
        }

        public virtual string FreqDays5
        {
            get
            {
                CanReadProperty("FreqDays5", true);
                return _freqdays5;
            }
        }

        public virtual Decimal? FreqDist5
        {
            get
            {
                CanReadProperty("FreqDist5", true);
                return _freqdist5;
            }
        }

        // TJB Sept-2010 ----------- Add end ------------------
        // TJB May-2020  -----------  Added  ------------------
        public virtual string FreqDesc6
        {
            get
            {
                CanReadProperty("FreqDesc6", true);
                return _freqdesc6;
            }
        }

        public virtual string FreqDays6
        {
            get
            {
                CanReadProperty("FreqDays6", true);
                return _freqdays6;
            }
        }

        public virtual Decimal? FreqDist6
        {
            get
            {
                CanReadProperty("FreqDist6", true);
                return _freqdist6;
            }
        }

        public virtual string FreqDesc7
        {
            get
            {
                CanReadProperty("FreqDesc7", true);
                return _freqdesc7;
            }
        }

        public virtual string FreqDays7
        {
            get
            {
                CanReadProperty("FreqDays7", true);
                return _freqdays7;
            }
        }

        public virtual Decimal? FreqDist7
        {
            get
            {
                CanReadProperty("FreqDist7", true);
                return _freqdist7;
            }
        }

        public virtual string FreqDesc8
        {
            get
            {
                CanReadProperty("FreqDesc8", true);
                return _freqdesc8;
            }
        }

        public virtual string FreqDays8
        {
            get
            {
                CanReadProperty("FreqDays8", true);
                return _freqdays8;
            }
        }

        public virtual Decimal? FreqDist8
        {
            get
            {
                CanReadProperty("FreqDist8", true);
                return _freqdist8;
            }
        }

        public virtual string FreqDesc9
        {
            get
            {
                CanReadProperty("FreqDesc9", true);
                return _freqdesc9;
            }
        }

        public virtual string FreqDays9
        {
            get
            {
                CanReadProperty("FreqDays9", true);
                return _freqdays9;
            }
        }

        public virtual Decimal? FreqDist9
        {
            get
            {
                CanReadProperty("FreqDist9", true);
                return _freqdist9;
            }
        }

        public virtual string FreqDesc10
        {
            get
            {
                CanReadProperty("FreqDesc10", true);
                return _freqdesc10;
            }
        }

        public virtual string FreqDays10
        {
            get
            {
                CanReadProperty("FreqDays10", true);
                return _freqdays10;
            }
        }

        public virtual Decimal? FreqDist10
        {
            get
            {
                CanReadProperty("FreqDist10", true);
                return _freqdist10;
            }
        }

        public virtual string FreqDesc11
        {
            get
            {
                CanReadProperty("FreqDesc11", true);
                return _freqdesc11;
            }
        }

        public virtual string FreqDays11
        {
            get
            {
                CanReadProperty("FreqDays11", true);
                return _freqdays11;
            }
        }

        public virtual Decimal? FreqDist11
        {
            get
            {
                CanReadProperty("FreqDist11", true);
                return _freqdist11;
            }
        }

        public virtual string FreqDesc12
        {
            get
            {
                CanReadProperty("FreqDesc12", true);
                return _freqdesc12;
            }
        }

        public virtual string FreqDays12
        {
            get
            {
                CanReadProperty("FreqDays12", true);
                return _freqdays12;
            }
        }

        public virtual Decimal? FreqDist12
        {
            get
            {
                CanReadProperty("FreqDist12", true);
                return _freqdist12;
            }
        }
        // TJB May-2020  ----------- Add end ------------------

        // needs to implement compute expression manually:
			// compute control name=[compute_1]
        /*?	string(contract_no) + '/' + string(contract_seq_number)

            // needs to implement compute expression manually:
            // compute control name=[compute_3]
            finalbenchmark  /  routedistance

            // needs to implement compute expression manually:
            // compute control name=[prtotal]
            if(isnull(prs_cost1),0,prs_cost1) + if(isnull(prs_cost2),0,prs_cost2) + if(isnull(prs_cost3),0,prs_cost3) + if(isnull(prs_cost4),0,prs_cost4) + if(isnull(prs_cost5),0,prs_cost5)

            // needs to implement compute expression manually:
            // compute control name=[totalfloor]
            round( finalbenchmark + 0.5 ,0)

            // needs to implement compute expression manually:
            // compute control name=[compute_4]
            if(isnull( totalfloor ),0, totalfloor ) -if(isnull(currentpayment),0,currentpayment)

            // needs to implement compute expression manually:
            // compute control name=[compute_5]
            prtotal +  if(isnull( totalfloor ),0, totalfloor )

            // needs to implement compute expression manually:
            // compute control name=[pprojected_hourly_rate]
            round(sum(prtotal + deliverycost + processingcost) /sum(deliveryhours / 7 * 365 + volume/500),2)

            // needs to implement compute expression manually:
            // compute control name=[d_enddate]
            if( isnull(denddate), relativedate(dstartdate,364), denddate)
         */


                protected override object GetIdValue()
		{
			return "";
		}
		#endregion

		#region Factory Methods
		public static BenchmarkReport2010 NewBenchmarkReport2010( int? inContract, int? inSequence )
		{
			return Create(inContract, inSequence);
		}

		public static BenchmarkReport2010[] GetAllBenchmarkReport2010( int? inContract, int? inSequence )
		{
			return Fetch(inContract, inSequence).list;
		}
		#endregion

		#region Data Access
		[ServerMethod]
		private void FetchEntity( int? inContract, int? inSequence )
		{
            // TJB RPCR_147 May-2020 Changed prcedure name
            //     Added FreqDesc,FreqDays,FreqDist 6 - 12
            // TJB Sept-2010 Changed prcedure name
            // TJB RPCR_054  July-2013: Changed stored proc name
			using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
			{
				using (DbCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
                    // TJB May-2020 Changed prcedure name
                    // New proc includes frequency information (description, days and distance)
                    // for up to 12 frequencies per contract.
                    //cm.CommandText = "rd.sp_GetBenchmarkRpt2006";
                    //cm.CommandText = "rd.sp_GetBenchmarkRpt2010";
                    //cm.CommandText = "rd.sp_GetBenchmarkRpt2013";
                    //cm.CommandText = "rd.sp_GetBenchmarkRpt2020";
                    cm.CommandText = "rd.sp_GetBenchmarkRpt2021";
                    ParameterCollection pList = new ParameterCollection();
					pList.Add(cm, "inContract", inContract);
					pList.Add(cm, "inSequence", inSequence);

					List<BenchmarkReport2010> _list = new List<BenchmarkReport2010>();
					using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
					{
                        try 
                        {
                            while (dr.Read())
                            {
                                BenchmarkReport2010 instance = new BenchmarkReport2010();
                                instance._contract_no = GetValueFromReader<int?>(dr, 0);
                                instance._contract_seq_number = GetValueFromReader<int?>(dr, 1);
                                instance._con_title = GetValueFromReader<string>(dr, 2);
                                instance._rdfile = GetValueFromReader<string>(dr, 3);
                                instance._rcmfile = GetValueFromReader<string>(dr, 4);
                                instance._nominalvehical = GetValueFromReader<decimal?>(dr, 5);
                                instance._wagehourlyrate = GetValueFromReader<decimal?>(dr, 6);
                                instance._repairsmaint = GetValueFromReader<decimal?>(dr, 7);
                                instance._tyrestubes = GetValueFromReader<decimal?>(dr, 8);
                                instance._vehicalallow = GetValueFromReader<decimal?>(dr, 9);
                                instance._vehicalinsure = GetValueFromReader<decimal?>(dr, 10);
                                instance._publiclia = GetValueFromReader<decimal?>(dr, 11);
                                instance._carrierrisk = GetValueFromReader<decimal?>(dr, 12);
                                instance._accrate = GetValueFromReader<decimal?>(dr, 13);
                                instance._licence = GetValueFromReader<decimal?>(dr, 14);
                                instance._rateofreturn = GetValueFromReader<decimal?>(dr, 15);
                                instance._salvageratio = GetValueFromReader<decimal?>(dr, 16);
                                instance._itemshour = GetValueFromReader<decimal?>(dr, 17);
                                instance._fuel = GetValueFromReader<decimal?>(dr, 18);
                                instance._consumption = GetValueFromReader<decimal?>(dr, 19);
                                instance._routedistance = GetValueFromReader<decimal?>(dr, 20);
                                instance._deliveryhours = GetValueFromReader<decimal?>(dr, 21);
                                instance._processinghours = GetValueFromReader<decimal?>(dr, 22);
                                instance._volume = GetValueFromReader<decimal?>(dr, 23);
                                instance._deliverydays = GetValueFromReader<decimal?>(dr, 24);
                                instance._maxdeliverydays = GetValueFromReader<decimal?>(dr, 25);
                                instance._numbercustomers = GetValueFromReader<int?>(dr, 26);
                                instance._routedistanceperday = (decimal?)(dr.GetFloat(27));   //!GetValueFromReader<int?>(dr,27);
                                instance._vehicledepreciation = (decimal?)(dr.GetFloat(28));   //!GetValueFromReader<int?>(dr,28);
                                instance._fuelcostperannum = (decimal?)(dr.GetFloat(29));      //!GetValueFromReader<int?>(dr,29);
                                instance._repairsperannum = (decimal?)(dr.GetFloat(30));       //!GetValueFromReader<int?>(dr,30);
                                instance._tyrestubesperannum = (decimal?)(dr.GetFloat(31));    //!GetValueFromReader<int?>(dr,31);
                                instance._deliverycost = (decimal?)(dr.GetFloat(32));          //!GetValueFromReader<int?>(dr,32);
                                instance._processingcost = (decimal?)(dr.GetFloat(33));        //!GetValueFromReader<int?>(dr,33);
                                instance._publicliabilitycost = (decimal?)(dr.GetFloat(34));   //!GetValueFromReader<int?>(dr,34);
                                instance._accperannum = (decimal?)(dr.GetFloat(35));           //!GetValueFromReader<int?>(dr,35);
                                instance._vehicleinsurance = (decimal?)(dr.GetFloat(36));      //!GetValueFromReader<int?>(dr,36);
                                instance._licensing = (decimal?)(dr.GetFloat(37));             //!GetValueFromReader<int?>(dr,37);
                                instance._carrierriskrate = (decimal?)(dr.GetFloat(38));       //!GetValueFromReader<int?>(dr,38);
                                instance._benchmark = (decimal?)(dr.GetFloat(39));             //!GetValueFromReader<int?>(dr,39);
                                instance._rateofreturncost = (decimal?)(dr.GetFloat(40));      //!GetValueFromReader<int?>(dr,40);
                                instance._finalbenchmark = (decimal?)(dr.GetFloat(41));        //!GetValueFromReader<int?>(dr,41);
                                instance._retainedallowances = GetValueFromReader<decimal?>(dr, 42);
                                instance._currentpayment = GetValueFromReader<decimal?>(dr, 43);
                                instance._prs_supplier1 = GetValueFromReader<string>(dr, 44);
                                instance._prs_cost1 = dr.GetDecimal(45);//!GetValueFromReader<int?>(dr,45);
                                instance._prs_supplier2 = GetValueFromReader<string>(dr, 46);
                                instance._prs_cost2 = dr.GetDecimal(47);//!GetValueFromReader<int?>(dr,47);
                                instance._prs_supplier3 = GetValueFromReader<string>(dr, 48);
                                instance._prs_cost3 = dr.GetDecimal(49);//!GetValueFromReader<int?>(dr,49);
                                instance._prs_supplier4 = GetValueFromReader<string>(dr, 50);
                                instance._prs_cost4 = dr.GetDecimal(51);//!GetValueFromReader<int?>(dr,51);
                                instance._prs_supplier5 = GetValueFromReader<string>(dr, 52);
                                instance._prs_cost5 = dr.GetDecimal(53);//!GetValueFromReader<int?>(dr,53);
                                instance._renewalgroup = GetValueFromReader<string>(dr, 54);
                                instance._renewaldate = GetValueFromReader<DateTime?>(dr, 55);
                                instance._accounting = GetValueFromReader<decimal?>(dr, 56);
                                instance._telephone = GetValueFromReader<decimal?>(dr, 57);
                                instance._sundries = GetValueFromReader<decimal?>(dr, 58);
                                instance._ruc = GetValueFromReader<decimal?>(dr, 59);
                                instance._sundriesk = GetValueFromReader<decimal?>(dr, 60);
                                instance._nliveryperannum = GetValueFromReader<decimal?>(dr, 61);
                                instance._nuniformperannum = GetValueFromReader<decimal?>(dr, 62);
                                instance._deliverydaysforreport = GetValueFromReader<decimal?>(dr, 63);
                                instance._reliefcost = (decimal?)(dr.GetFloat(64));//!GetValueFromReader<int?>(dr,64);
                                instance._dstartdate = GetValueFromReader<DateTime?>(dr, 65);
                                instance._denddate = GetValueFromReader<DateTime?>(dr, 66);
                                instance._prstartdate = GetValueFromReader<DateTime?>(dr, 67);
                                instance._prenddate = GetValueFromReader<DateTime?>(dr, 68);
                                instance._dexpirydate = GetValueFromReader<DateTime?>(dr, 69);

                                // TJB Sept-2010 ----------- Added --------------------
                                instance._freqdesc1 = GetValueFromReader<string>(dr, 70);
                                instance._freqdays1 = GetValueFromReader<string>(dr, 71);
                                instance._freqdist1 = GetValueFromReader<decimal?>(dr, 72);
                                instance._freqdesc2 = GetValueFromReader<string>(dr, 73);
                                instance._freqdays2 = GetValueFromReader<string>(dr, 74);
                                instance._freqdist2 = GetValueFromReader<decimal?>(dr, 75);
                                instance._freqdesc3 = GetValueFromReader<string>(dr, 76);
                                instance._freqdays3 = GetValueFromReader<string>(dr, 77);
                                instance._freqdist3 = GetValueFromReader<decimal?>(dr, 78);
                                instance._freqdesc4 = GetValueFromReader<string>(dr, 79);
                                instance._freqdays4 = GetValueFromReader<string>(dr, 80);
                                instance._freqdist4 = GetValueFromReader<decimal?>(dr, 81);
                                instance._freqdesc5 = GetValueFromReader<string>(dr, 82);
                                instance._freqdays5 = GetValueFromReader<string>(dr, 83);
                                instance._freqdist5 = GetValueFromReader<decimal?>(dr, 84);
                                // TJB Sept-2010 ----------- Add end ------------------
                                // TJB May-2020  -----------  Added  ------------------
                                instance._freqdesc6 = GetValueFromReader<string>(dr, 85);
                                instance._freqdays6 = GetValueFromReader<string>(dr, 86);
                                instance._freqdist6 = GetValueFromReader<decimal?>(dr,87);
                                instance._freqdesc7 = GetValueFromReader<string>(dr, 88);
                                instance._freqdays7 = GetValueFromReader<string>(dr, 89);
                                instance._freqdist7 = GetValueFromReader<decimal?>(dr, 90);
                                instance._freqdesc8 = GetValueFromReader<string>(dr, 91);
                                instance._freqdays8 = GetValueFromReader<string>(dr, 92);
                                instance._freqdist8 = GetValueFromReader<decimal?>(dr, 93);
                                instance._freqdesc9 = GetValueFromReader<string>(dr, 94);
                                instance._freqdays9 = GetValueFromReader<string>(dr, 95);
                                instance._freqdist9 = GetValueFromReader<decimal?>(dr, 96);
                                instance._freqdesc10 = GetValueFromReader<string>(dr, 97);
                                instance._freqdays10 = GetValueFromReader<string>(dr, 98);
                                instance._freqdist10 = GetValueFromReader<decimal?>(dr, 99);
                                instance._freqdesc11 = GetValueFromReader<string>(dr, 100);
                                instance._freqdays11 = GetValueFromReader<string>(dr, 101);
                                instance._freqdist11 = GetValueFromReader<decimal?>(dr, 102);
                                instance._freqdesc12 = GetValueFromReader<string>(dr, 103);
                                instance._freqdays12 = GetValueFromReader<string>(dr, 104);
                                instance._freqdist12 = GetValueFromReader<decimal?>(dr, 105);
                                // TJB May-2020  ----------- Add end ------------------

                                instance.MarkOld();
                                instance.StoreInitialValues();
                                _list.Add(instance);
                            }
						}
                        catch ( Exception e)
                        {
                            string t = e.Message;
                            string s = t;
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

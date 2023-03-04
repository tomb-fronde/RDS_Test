using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;

namespace NZPostOffice.RDS.DataControls.Report
{
    // TJB RPCR_147  May-2020
    // Added freqdesc,freqdays,freqdist 6 - 12

    public class RBenchmarkReport2010
    {
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public int ContractSeqNumber
        {
            get
            {
                return 0;
            }
        }
        public string ConTitle
        {
            get
            {
                return string.Empty;
            }
        }
        public string Rdfile
        {
            get
            {
                return string.Empty;
            }
        }
        public string Rcmfile
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Nominalvehical
        {
            get
            {
                return 0;
            }
        }
        public decimal Wagehourlyrate
        {
            get
            {
                return 0;
            }
        }
        public decimal Repairsmaint
        {
            get
            {
                return 0;
            }
        }
        public decimal Tyrestubes
        {
            get
            {
                return 0;
            }
        }
        public decimal Vehicalallow
        {
            get
            {
                return 0;
            }
        }
        public decimal Vehicalinsure
        {
            get
            {
                return 0;
            }
        }
        public decimal Publiclia
        {
            get
            {
                return 0;
            }
        }
        public decimal Carrierrisk
        {
            get
            {
                return 0;
            }
        }
        public decimal Accrate
        {
            get
            {
                return 0;
            }
        }
        public decimal Licence
        {
            get
            {
                return 0;
            }
        }
        public decimal Rateofreturn
        {
            get
            {
                return 0;
            }
        }
        public decimal Salvageratio
        {
            get
            {
                return 0;
            }
        }
        public decimal Itemshour
        {
            get
            {
                return 0;
            }
        }
        public decimal Fuel
        {
            get
            {
                return 0;
            }
        }
        public decimal Consumption
        {
            get
            {
                return 0;
            }
        }
        public decimal Routedistance
        {
            get
            {
                return 0;
            }
        }
        public decimal Deliveryhours
        {
            get
            {
                return 0;
            }
        }
        public decimal Processinghours
        {
            get
            {
                return 0;
            }
        }
        public decimal Volume
        {
            get
            {
                return 0;
            }
        }
        public decimal Deliverydays
        {
            get
            {
                return 0;
            }
        }
        public decimal Maxdeliverydays
        {
            get
            {
                return 0;
            }
        }
        public int Numbercustomers
        {
            get
            {
                return 0;
            }
        }
        public int Routedistanceperday
        {
            get
            {
                return 0;
            }
        }
        public int Vehicledepreciation
        {
            get
            {
                return 0;
            }
        }
        public int Fuelcostperannum
        {
            get
            {
                return 0;
            }
        }
        public int Repairsperannum
        {
            get
            {
                return 0;
            }
        }
        public int Tyrestubesperannum
        {
            get
            {
                return 0;
            }
        }
        public int Deliverycost
        {
            get
            {
                return 0;
            }
        }
        public int Processingcost
        {
            get
            {
                return 0;
            }
        }
        public int Publicliabilitycost
        {
            get
            {
                return 0;
            }
        }
        public int Accperannum
        {
            get
            {
                return 0;
            }
        }
        public int Vehicleinsurance
        {
            get
            {
                return 0;
            }
        }
        public int Licensing
        {
            get
            {
                return 0;
            }
        }
        public int Carrierriskrate
        {
            get
            {
                return 0;
            }
        }
        public int Benchmark
        {
            get
            {
                return 0;
            }
        }
        public int Rateofreturncost
        {
            get
            {
                return 0;
            }
        }
        public int Finalbenchmark
        {
            get
            {
                return 0;
            }
        }
        public decimal Retainedallowances
        {
            get
            {
                return 0;
            }
        }
        public decimal Currentpayment
        {
            get
            {
                return 0;
            }
        }
        public string PrsSupplier1
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrsCost1
        {
            get
            {
                return 0;
            }
        }
        public string PrsSupplier2
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrsCost2
        {
            get
            {
                return 0;
            }
        }
        public string PrsSupplier3
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrsCost3
        {
            get
            {
                return 0;
            }
        }
        public string PrsSupplier4
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrsCost4
        {
            get
            {
                return 0;
            }
        }
        public string PrsSupplier5
        {
            get
            {
                return string.Empty;
            }
        }
        public int PrsCost5
        {
            get
            {
                return 0;
            }
        }
        public string Renewalgroup
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime Renewaldate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public decimal Accounting
        {
            get
            {
                return 0;
            }
        }
        public decimal Telephone
        {
            get
            {
                return 0;
            }
        }
        public decimal Sundries
        {
            get
            {
                return 0;
            }
        }
        public decimal Ruc
        {
            get
            {
                return 0;
            }
        }
        public decimal Sundriesk
        {
            get
            {
                return 0;
            }
        }
        public decimal Nliveryperannum
        {
            get
            {
                return 0;
            }
        }
        public decimal Nuniformperannum
        {
            get
            {
                return 0;
            }
        }
        public decimal Deliverydaysforreport
        {
            get
            {
                return 0;
            }
        }
        public int Reliefcost
        {
            get
            {
                return 0;
            }
        }
        public DateTime Dstartdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime Denddate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime Prstartdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime Prenddate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime Dexpirydate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string Compute1
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal Compute3
        {
            get
            {
                return 0;
            }
        }
        public decimal Prtotal
        {
            get
            {
                return 0;
            }
        }
        public decimal Totalfloor
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute4
        {
            get
            {
                return 0;
            }
        }
        public decimal Compute5
        {
            get
            {
                return 0;
            }
        }
        public decimal PprojectedHourlyRate
        {
            get
            {
                return 0;
            }
        }
        public DateTime DEnddate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime Compute6
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        // TJB Sept-2010 --------------- Added ----------------
        public string FreqDesc1
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays1
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist1
        {
            get
            {
                return 0;
            }
        }
        public string FreqDesc2
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays2
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist2
        {
            get
            {
                return 0;
            }
        }
        public string FreqDesc3
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays3
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist3
        {
            get
            {
                return 0;
            }
        }
        public string FreqDesc4
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays4
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist4
        {
            get
            {
                return 0;
            }
        }
        public string FreqDesc5
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays5
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist5
        {
            get
            {
                return 0;
            }
        }
        // TJB Sept-2010 -------------- Add end ---------------
        // TJB May-2020 ---------------  Added  ----------------
        public string FreqDesc6
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays6
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist6
        {
            get
            {
                return 0;
            }
        }

        public string FreqDesc7
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays7
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist7
        {
            get
            {
                return 0;
            }
        }

        public string FreqDesc8
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays8
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist8
        {
            get
            {
                return 0;
            }
        }

        public string FreqDesc9
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays9
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist9
        {
            get
            {
                return 0;
            }
        }

        public string FreqDesc10
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays10
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist10
        {
            get
            {
                return 0;
            }
        }

        public string FreqDesc11
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays11
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist11
        {
            get
            {
                return 0;
            }
        }

        public string FreqDesc12
        {
            get
            {
                return string.Empty;
            }
        }
        public string FreqDays12
        {
            get
            {
                return string.Empty;
            }
        }
        public decimal FreqDist12
        {
            get
            {
                return 0;
            }
        }
        // TJB May-2020 --------------- Add end ----------------
    }

    public class BenchmarkReport2010DataSet : ReportDataSet<BenchmarkReport2010>
    {
        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn ContractSeqNumber = new DataColumn("ContractSeqNumber", typeof(int));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn Rdfile = new DataColumn("Rdfile", typeof(string));

        public DataColumn Rcmfile = new DataColumn("Rcmfile", typeof(string));

        public DataColumn Nominalvehical = new DataColumn("Nominalvehical", typeof(decimal));

        public DataColumn Wagehourlyrate = new DataColumn("Wagehourlyrate", typeof(decimal));

        public DataColumn Repairsmaint = new DataColumn("Repairsmaint", typeof(decimal));

        public DataColumn Tyrestubes = new DataColumn("Tyrestubes", typeof(decimal));

        public DataColumn Vehicalallow = new DataColumn("Vehicalallow", typeof(decimal));

        public DataColumn Vehicalinsure = new DataColumn("Vehicalinsure", typeof(decimal));

        public DataColumn Publiclia = new DataColumn("Publiclia", typeof(decimal));

        public DataColumn Carrierrisk = new DataColumn("Carrierrisk", typeof(decimal));

        public DataColumn Accrate = new DataColumn("Accrate", typeof(decimal));

        public DataColumn Licence = new DataColumn("Licence", typeof(decimal));

        public DataColumn Rateofreturn = new DataColumn("Rateofreturn", typeof(decimal));

        public DataColumn Salvageratio = new DataColumn("Salvageratio", typeof(decimal));

        public DataColumn Itemshour = new DataColumn("Itemshour", typeof(decimal));

        public DataColumn Fuel = new DataColumn("Fuel", typeof(decimal));

        public DataColumn Consumption = new DataColumn("Consumption", typeof(decimal));

        public DataColumn Routedistance = new DataColumn("Routedistance", typeof(decimal));

        public DataColumn Deliveryhours = new DataColumn("Deliveryhours", typeof(decimal));

        public DataColumn Processinghours = new DataColumn("Processinghours", typeof(decimal));

        public DataColumn Volume = new DataColumn("Volume", typeof(decimal));

        public DataColumn Deliverydays = new DataColumn("Deliverydays", typeof(decimal));

        public DataColumn Maxdeliverydays = new DataColumn("Maxdeliverydays", typeof(decimal));

        public DataColumn Numbercustomers = new DataColumn("Numbercustomers", typeof(int));

        public DataColumn Routedistanceperday = new DataColumn("Routedistanceperday", typeof(decimal));

        public DataColumn Vehicledepreciation = new DataColumn("Vehicledepreciation", typeof(decimal));

        public DataColumn Fuelcostperannum = new DataColumn("Fuelcostperannum", typeof(decimal));

        public DataColumn Repairsperannum = new DataColumn("Repairsperannum", typeof(decimal));

        public DataColumn Tyrestubesperannum = new DataColumn("Tyrestubesperannum", typeof(decimal));

        public DataColumn Deliverycost = new DataColumn("Deliverycost", typeof(decimal));

        public DataColumn Processingcost = new DataColumn("Processingcost", typeof(decimal));

        public DataColumn Publicliabilitycost = new DataColumn("Publicliabilitycost", typeof(decimal));

        public DataColumn Accperannum = new DataColumn("Accperannum", typeof(decimal));

        public DataColumn Vehicleinsurance = new DataColumn("Vehicleinsurance", typeof(decimal));

        public DataColumn Licensing = new DataColumn("Licensing", typeof(decimal));

        public DataColumn Carrierriskrate = new DataColumn("Carrierriskrate", typeof(decimal));

        public DataColumn Benchmark = new DataColumn("Benchmark", typeof(decimal));

        public DataColumn Rateofreturncost = new DataColumn("Rateofreturncost", typeof(decimal));

        public DataColumn Finalbenchmark = new DataColumn("Finalbenchmark", typeof(decimal));

        public DataColumn Retainedallowances = new DataColumn("Retainedallowances", typeof(decimal));

        public DataColumn Currentpayment = new DataColumn("Currentpayment", typeof(decimal));

        public DataColumn PrsSupplier1 = new DataColumn("PrsSupplier1", typeof(string));

        public DataColumn PrsCost1 = new DataColumn("PrsCost1", typeof(decimal));

        public DataColumn PrsSupplier2 = new DataColumn("PrsSupplier2", typeof(string));

        public DataColumn PrsCost2 = new DataColumn("PrsCost2", typeof(decimal));

        public DataColumn PrsSupplier3 = new DataColumn("PrsSupplier3", typeof(string));

        public DataColumn PrsCost3 = new DataColumn("PrsCost3", typeof(decimal));

        public DataColumn PrsSupplier4 = new DataColumn("PrsSupplier4", typeof(string));

        public DataColumn PrsCost4 = new DataColumn("PrsCost4", typeof(decimal));

        public DataColumn PrsSupplier5 = new DataColumn("PrsSupplier5", typeof(string));

        public DataColumn PrsCost5 = new DataColumn("PrsCost5", typeof(decimal));

        public DataColumn Renewalgroup = new DataColumn("Renewalgroup", typeof(string));

        public DataColumn Renewaldate = new DataColumn("Renewaldate", typeof(DateTime));

        public DataColumn Accounting = new DataColumn("Accounting", typeof(decimal));

        public DataColumn Telephone = new DataColumn("Telephone", typeof(decimal));

        public DataColumn Sundries = new DataColumn("Sundries", typeof(decimal));

        public DataColumn Ruc = new DataColumn("Ruc", typeof(decimal));

        public DataColumn Sundriesk = new DataColumn("Sundriesk", typeof(decimal));

        public DataColumn Nliveryperannum = new DataColumn("Nliveryperannum", typeof(decimal));

        public DataColumn Nuniformperannum = new DataColumn("Nuniformperannum", typeof(decimal));

        public DataColumn Deliverydaysforreport = new DataColumn("Deliverydaysforreport", typeof(decimal));

        public DataColumn Reliefcost = new DataColumn("Reliefcost", typeof(decimal));

        public DataColumn Dstartdate = new DataColumn("Dstartdate", typeof(DateTime));

        public DataColumn Denddate = new DataColumn("Denddate", typeof(DateTime));

        public DataColumn Prstartdate = new DataColumn("Prstartdate", typeof(DateTime));

        public DataColumn Prenddate = new DataColumn("Prenddate", typeof(DateTime));

        public DataColumn Dexpirydate = new DataColumn("Dexpirydate", typeof(DateTime));

        public DataColumn Compute1 = new DataColumn("Compute1", typeof(string));

        public DataColumn Compute3 = new DataColumn("Compute3", typeof(decimal));

        public DataColumn Prtotal = new DataColumn("Prtotal", typeof(decimal));

        public DataColumn Totalfloor = new DataColumn("Totalfloor", typeof(decimal));

        public DataColumn Compute4 = new DataColumn("Compute4", typeof(decimal));

        public DataColumn Compute5 = new DataColumn("Compute5", typeof(decimal));

        public DataColumn PprojectedHourlyRate = new DataColumn("PprojectedHourlyRate", typeof(decimal));

        public DataColumn DEnddate = new DataColumn("DEnddate", typeof(DateTime));

        public DataColumn Compute6 = new DataColumn("Compute6", typeof(DateTime));

    // TJB Sept-2010 --------------- Added ----------------
        public DataColumn FreqDesc1 = new DataColumn("FreqDesc1", typeof(string));

        public DataColumn FreqDays1 = new DataColumn("FreqDays1", typeof(string));

        public DataColumn FreqDist1 = new DataColumn("FreqDist1", typeof(decimal));

        public DataColumn FreqDesc2 = new DataColumn("FreqDesc2", typeof(string));

        public DataColumn FreqDays2 = new DataColumn("FreqDays2", typeof(string));

        public DataColumn FreqDist2 = new DataColumn("FreqDist2", typeof(decimal));

        public DataColumn FreqDesc3 = new DataColumn("FreqDesc3", typeof(string));

        public DataColumn FreqDays3 = new DataColumn("FreqDays3", typeof(string));

        public DataColumn FreqDist3 = new DataColumn("FreqDist3", typeof(decimal));

        public DataColumn FreqDesc4 = new DataColumn("FreqDesc4", typeof(string));

        public DataColumn FreqDays4 = new DataColumn("FreqDays4", typeof(string));

        public DataColumn FreqDist4 = new DataColumn("FreqDist4", typeof(decimal));

        public DataColumn FreqDesc5 = new DataColumn("FreqDesc5", typeof(string));

        public DataColumn FreqDays5 = new DataColumn("FreqDays5", typeof(string));

        public DataColumn FreqDist5 = new DataColumn("FreqDist5", typeof(decimal));
    // TJB Sept-2010 -------------- Add end ---------------
    // TJB May-2020  --------------  Added  ---------------
        public DataColumn FreqDesc6 = new DataColumn("FreqDesc6", typeof(string));

        public DataColumn FreqDays6 = new DataColumn("FreqDays6", typeof(string));

        public DataColumn FreqDist6 = new DataColumn("FreqDist6", typeof(decimal));

        public DataColumn FreqDesc7 = new DataColumn("FreqDesc7", typeof(string));

        public DataColumn FreqDays7 = new DataColumn("FreqDays7", typeof(string));

        public DataColumn FreqDist7 = new DataColumn("FreqDist7", typeof(decimal));

        public DataColumn FreqDesc8 = new DataColumn("FreqDesc8", typeof(string));

        public DataColumn FreqDays8 = new DataColumn("FreqDays8", typeof(string));

        public DataColumn FreqDist8 = new DataColumn("FreqDist8", typeof(decimal));

        public DataColumn FreqDesc9 = new DataColumn("FreqDesc9", typeof(string));

        public DataColumn FreqDays9 = new DataColumn("FreqDays9", typeof(string));

        public DataColumn FreqDist9 = new DataColumn("FreqDist9", typeof(decimal));

        public DataColumn FreqDesc10 = new DataColumn("FreqDesc10", typeof(string));

        public DataColumn FreqDays10 = new DataColumn("FreqDays10", typeof(string));

        public DataColumn FreqDist10 = new DataColumn("FreqDist10", typeof(decimal));

        public DataColumn FreqDesc11 = new DataColumn("FreqDesc11", typeof(string));

        public DataColumn FreqDays11 = new DataColumn("FreqDays11", typeof(string));

        public DataColumn FreqDist11 = new DataColumn("FreqDist11", typeof(decimal));

        public DataColumn FreqDesc12 = new DataColumn("FreqDesc12", typeof(string));

        public DataColumn FreqDays12 = new DataColumn("FreqDays12", typeof(string));

        public DataColumn FreqDist12 = new DataColumn("FreqDist12", typeof(decimal));

        // TJB May-2020  -------------- Add end ---------------

        public BenchmarkReport2010DataSet()
        {
    // TJB Sept-2010 --------------- Changed ----------------
        //  this.Columns.AddRange(new DataColumn[]{
	//			ContractNo,ContractSeqNumber,ConTitle,Rdfile,Rcmfile,Nominalvehical,Wagehourlyrate,Repairsmaint,Tyrestubes,Vehicalallow,Vehicalinsure,Publiclia,Carrierrisk,Accrate,Licence,Rateofreturn,Salvageratio,Itemshour,Fuel,Consumption,Routedistance,Deliveryhours,Processinghours,Volume,Deliverydays,Maxdeliverydays,Numbercustomers,Routedistanceperday,Vehicledepreciation,Fuelcostperannum,Repairsperannum,Tyrestubesperannum,Deliverycost,Processingcost,Publicliabilitycost,Accperannum,Vehicleinsurance,Licensing,Carrierriskrate,Benchmark,Rateofreturncost,Finalbenchmark,Retainedallowances,Currentpayment,PrsSupplier1,PrsCost1,PrsSupplier2,PrsCost2,PrsSupplier3,PrsCost3,PrsSupplier4,PrsCost4,PrsSupplier5,PrsCost5,Renewalgroup,Renewaldate,Accounting,Telephone,Sundries,Ruc,Sundriesk,Nliveryperannum,Nuniformperannum,Deliverydaysforreport,Reliefcost,Dstartdate,Denddate,Prstartdate,Prenddate,Dexpirydate,Compute1,Compute3,Prtotal,Totalfloor,Compute4,Compute5,PprojectedHourlyRate,DEnddate,Compute6
	//			});

            this.Columns.AddRange(new DataColumn[]{
                 ContractNo,ContractSeqNumber,ConTitle,Rdfile,Rcmfile,Nominalvehical
                ,Wagehourlyrate,Repairsmaint,Tyrestubes,Vehicalallow,Vehicalinsure
                ,Publiclia,Carrierrisk,Accrate,Licence,Rateofreturn,Salvageratio
                ,Itemshour,Fuel,Consumption,Routedistance,Deliveryhours,Processinghours
                ,Volume,Deliverydays,Maxdeliverydays,Numbercustomers,Routedistanceperday
                ,Vehicledepreciation,Fuelcostperannum,Repairsperannum,Tyrestubesperannum
                ,Deliverycost,Processingcost,Publicliabilitycost,Accperannum,Vehicleinsurance
                ,Licensing,Carrierriskrate,Benchmark,Rateofreturncost,Finalbenchmark
                ,Retainedallowances,Currentpayment,PrsSupplier1,PrsCost1,PrsSupplier2
                ,PrsCost2,PrsSupplier3,PrsCost3,PrsSupplier4,PrsCost4,PrsSupplier5
                ,PrsCost5,Renewalgroup,Renewaldate,Accounting,Telephone,Sundries,Ruc
                ,Sundriesk,Nliveryperannum,Nuniformperannum,Deliverydaysforreport
                ,Reliefcost,Dstartdate,Denddate,Prstartdate,Prenddate,Dexpirydate
                ,Compute1,Compute3,Prtotal,Totalfloor,Compute4,Compute5,PprojectedHourlyRate
                ,DEnddate,Compute6,FreqDesc1,FreqDays1,FreqDist1,FreqDesc2,FreqDays2
                ,FreqDist2,FreqDesc3,FreqDays3,FreqDist3,FreqDesc4,FreqDays4,FreqDist4
                ,FreqDesc5,FreqDays5,FreqDist5
         // TJB MAY-2020 Added FreqDesc, FreqDays, FreqDist 6 - 12
                ,FreqDesc6,FreqDays6,FreqDist6,FreqDesc7,FreqDays7,FreqDist7
                ,FreqDesc8,FreqDays8,FreqDist8,FreqDesc9,FreqDays9,FreqDist9
                ,FreqDesc10,FreqDays10,FreqDist10,FreqDesc11,FreqDays11,FreqDist11
                ,FreqDesc12,FreqDays12,FreqDist12
                });
    // TJB Sept-2010 -------------- Change end ---------------

            ContractNo.AllowDBNull = true;
            ContractSeqNumber.AllowDBNull = true;
            Nominalvehical.AllowDBNull = true;
            Wagehourlyrate.AllowDBNull = true;
            Repairsmaint.AllowDBNull = true;
            Tyrestubes.AllowDBNull = true;
            Vehicalallow.AllowDBNull = true;
            Vehicalinsure.AllowDBNull = true;
            Publiclia.AllowDBNull = true;
            Carrierrisk.AllowDBNull = true;
            Accrate.AllowDBNull = true;
            Licence.AllowDBNull = true;
            Rateofreturn.AllowDBNull = true;
            Salvageratio.AllowDBNull = true;
            Itemshour.AllowDBNull = true;
            Fuel.AllowDBNull = true;
            Consumption.AllowDBNull = true;
            Routedistance.AllowDBNull = true;
            Deliveryhours.AllowDBNull = true;
            Processinghours.AllowDBNull = true;
            Volume.AllowDBNull = true;
            Deliverydays.AllowDBNull = true;
            Maxdeliverydays.AllowDBNull = true;
            Numbercustomers.AllowDBNull = true;
            Routedistanceperday.AllowDBNull = true;
            Vehicledepreciation.AllowDBNull = true;
            Fuelcostperannum.AllowDBNull = true;
            Repairsperannum.AllowDBNull = true;
            Tyrestubesperannum.AllowDBNull = true;
            Deliverycost.AllowDBNull = true;
            Processingcost.AllowDBNull = true;
            Publicliabilitycost.AllowDBNull = true;
            Accperannum.AllowDBNull = true;
            Vehicleinsurance.AllowDBNull = true;
            Licensing.AllowDBNull = true;
            Carrierriskrate.AllowDBNull = true;
            Benchmark.AllowDBNull = true;
            Rateofreturncost.AllowDBNull = true;
            Finalbenchmark.AllowDBNull = true;
            Retainedallowances.AllowDBNull = true;
            Currentpayment.AllowDBNull = true;
            PrsCost1.AllowDBNull = true;
            PrsCost2.AllowDBNull = true;
            PrsCost3.AllowDBNull = true;
            PrsCost4.AllowDBNull = true;
            PrsCost5.AllowDBNull = true;
            Renewaldate.AllowDBNull = true;
            Accounting.AllowDBNull = true;
            Telephone.AllowDBNull = true;
            Sundries.AllowDBNull = true;
            Ruc.AllowDBNull = true;
            Sundriesk.AllowDBNull = true;
            Nliveryperannum.AllowDBNull = true;
            Nuniformperannum.AllowDBNull = true;
            Deliverydaysforreport.AllowDBNull = true;
            Reliefcost.AllowDBNull = true;
            Dstartdate.AllowDBNull = true;
            Denddate.AllowDBNull = true;
            Prstartdate.AllowDBNull = true;
            Prenddate.AllowDBNull = true;
            Dexpirydate.AllowDBNull = true;
            Compute3.AllowDBNull = true;
            Prtotal.AllowDBNull = true;
            Totalfloor.AllowDBNull = true;
            Compute4.AllowDBNull = true;
            Compute5.AllowDBNull = true;
            PprojectedHourlyRate.AllowDBNull = true;
            DEnddate.AllowDBNull = true;
            Compute6.AllowDBNull = true;
    // TJB Sept-2010 --------------- Added ----------------
            FreqDesc1.AllowDBNull = true;
            FreqDays1.AllowDBNull = true;
            FreqDist1.AllowDBNull = true;
            FreqDesc2.AllowDBNull = true;
            FreqDays2.AllowDBNull = true;
            FreqDist2.AllowDBNull = true;
            FreqDesc3.AllowDBNull = true;
            FreqDays3.AllowDBNull = true;
            FreqDist3.AllowDBNull = true;
            FreqDesc4.AllowDBNull = true;
            FreqDays4.AllowDBNull = true;
            FreqDist4.AllowDBNull = true;
            FreqDesc5.AllowDBNull = true;
            FreqDays5.AllowDBNull = true;
            FreqDist5.AllowDBNull = true;
    // TJB Sept-2010 -------------- Add end ---------------
    // TJB May-2020  --------------  Added  ---------------
            FreqDesc6.AllowDBNull = true;
            FreqDays6.AllowDBNull = true;
            FreqDist6.AllowDBNull = true;
            FreqDesc7.AllowDBNull = true;
            FreqDays7.AllowDBNull = true;
            FreqDist7.AllowDBNull = true;
            FreqDesc8.AllowDBNull = true;
            FreqDays8.AllowDBNull = true;
            FreqDist8.AllowDBNull = true;
            FreqDesc9.AllowDBNull = true;
            FreqDays9.AllowDBNull = true;
            FreqDist9.AllowDBNull = true;
            FreqDesc10.AllowDBNull = true;
            FreqDays10.AllowDBNull = true;
            FreqDist10.AllowDBNull = true;
            FreqDesc11.AllowDBNull = true;
            FreqDays11.AllowDBNull = true;
            FreqDist11.AllowDBNull = true;
            FreqDesc12.AllowDBNull = true;
            FreqDays12.AllowDBNull = true;
            FreqDist12.AllowDBNull = true;
            // TJB May-2020  -------------- Add end ---------------
        }

        public BenchmarkReport2010DataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<BenchmarkReport2010> datas = dataSource as Metex.Core.EntityBindingList<BenchmarkReport2010>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }
        public BenchmarkReport2010DataSet(BenchmarkReport2010 obj)
            : this()
        {
            if (obj != null && this.Columns.Count != 0)
            {
                Metex.Core.EntityBindingList<BenchmarkReport2010> list = new Metex.Core.EntityBindingList<BenchmarkReport2010>();
                list.Add(obj);
                ApplyRows(list);
            }
        }
        public BenchmarkReport2010DataSet(BenchmarkReport2010[] objs)
            : this()
        {
            Metex.Core.EntityBindingList<BenchmarkReport2010> list = new Metex.Core.EntityBindingList<BenchmarkReport2010>();
            foreach (BenchmarkReport2010 d in objs)
            {
                list.Add(d);
            }
            ApplyRows(list);
        }
        protected override DataRow ApplyRow(BenchmarkReport2010 data)
        {
            DataRow row = this.NewRow();
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["ContractSeqNumber"] = GetFieldValue(data.ContractSeqNumber);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["Rdfile"] = GetFieldValue(data.Rdfile);
            row["Rcmfile"] = GetFieldValue(data.Rcmfile);
            row["Nominalvehical"] = GetFieldValue(data.Nominalvehical);
            row["Wagehourlyrate"] = GetFieldValue(data.Wagehourlyrate);
            row["Repairsmaint"] = GetFieldValue(data.Repairsmaint);
            row["Tyrestubes"] = GetFieldValue(data.Tyrestubes);
            row["Vehicalallow"] = GetFieldValue(data.Vehicalallow);
            row["Vehicalinsure"] = GetFieldValue(data.Vehicalinsure);
            row["Publiclia"] = GetFieldValue(data.Publiclia);
            row["Carrierrisk"] = GetFieldValue(data.Carrierrisk);
            row["Accrate"] = GetFieldValue(data.Accrate);
            row["Licence"] = GetFieldValue(data.Licence);
            row["Rateofreturn"] = GetFieldValue(data.Rateofreturn);
            row["Salvageratio"] = GetFieldValue(data.Salvageratio);
            row["Itemshour"] = GetFieldValue(data.Itemshour);
            row["Fuel"] = GetFieldValue(data.Fuel);
            row["Consumption"] = GetFieldValue(data.Consumption);
            row["Routedistance"] = GetFieldValue(data.Routedistance);
            row["Deliveryhours"] = GetFieldValue(data.Deliveryhours);
            row["Processinghours"] = GetFieldValue(data.Processinghours);
            row["Volume"] = GetFieldValue(data.Volume);
            row["Deliverydays"] = GetFieldValue(data.Deliverydays);
            row["Maxdeliverydays"] = GetFieldValue(data.Maxdeliverydays);
            row["Numbercustomers"] = GetFieldValue(data.Numbercustomers);
            row["Routedistanceperday"] = GetFieldValue(data.Routedistanceperday);
            row["Vehicledepreciation"] = GetFieldValue(data.Vehicledepreciation);
            row["Fuelcostperannum"] = GetFieldValue(data.Fuelcostperannum);
            row["Repairsperannum"] = GetFieldValue(data.Repairsperannum);
            row["Tyrestubesperannum"] = GetFieldValue(data.Tyrestubesperannum);
            row["Deliverycost"] = GetFieldValue(data.Deliverycost);
            row["Processingcost"] = GetFieldValue(data.Processingcost);
            row["Publicliabilitycost"] = GetFieldValue(data.Publicliabilitycost);
            row["Accperannum"] = GetFieldValue(data.Accperannum);
            row["Vehicleinsurance"] = GetFieldValue(data.Vehicleinsurance);
            row["Licensing"] = GetFieldValue(data.Licensing);
            row["Carrierriskrate"] = GetFieldValue(data.Carrierriskrate);
            row["Benchmark"] = GetFieldValue(data.Benchmark);
            row["Rateofreturncost"] = GetFieldValue(data.Rateofreturncost);
            row["Finalbenchmark"] = GetFieldValue(data.Finalbenchmark);
            row["Retainedallowances"] = GetFieldValue(data.Retainedallowances);
            row["Currentpayment"] = GetFieldValue(data.Currentpayment);
            row["PrsSupplier1"] = GetFieldValue(data.PrsSupplier1);
            row["PrsCost1"] = GetFieldValue(data.PrsCost1);
            row["PrsSupplier2"] = GetFieldValue(data.PrsSupplier2);
            row["PrsCost2"] = GetFieldValue(data.PrsCost2);
            row["PrsSupplier3"] = GetFieldValue(data.PrsSupplier3);
            row["PrsCost3"] = GetFieldValue(data.PrsCost3);
            row["PrsSupplier4"] = GetFieldValue(data.PrsSupplier4);
            row["PrsCost4"] = GetFieldValue(data.PrsCost4);
            row["PrsSupplier5"] = GetFieldValue(data.PrsSupplier5);
            row["PrsCost5"] = GetFieldValue(data.PrsCost5);
            row["Renewalgroup"] = GetFieldValue(data.Renewalgroup);
            row["Renewaldate"] = GetFieldValue(data.Renewaldate);
            row["Accounting"] = GetFieldValue(data.Accounting);
            row["Telephone"] = GetFieldValue(data.Telephone);
            row["Sundries"] =( data.Sundries == null ?"0":GetFieldValue(data.Sundries));
            row["Ruc"] = GetFieldValue(data.Ruc);
            row["Sundriesk"] = GetFieldValue(data.Sundriesk);
            row["Nliveryperannum"] = GetFieldValue(data.Nliveryperannum);
            row["Nuniformperannum"] = GetFieldValue(data.Nuniformperannum);
            row["Deliverydaysforreport"] = GetFieldValue(data.Deliverydaysforreport);
            row["Reliefcost"] = GetFieldValue(data.Reliefcost);
            row["Dstartdate"] = GetFieldValue(data.Dstartdate);
            row["Denddate"] = GetFieldValue(data.Denddate);
            row["Prstartdate"] = GetFieldValue(data.Prstartdate);
            row["Prenddate"] = GetFieldValue(data.Prenddate);
            row["Dexpirydate"] = GetFieldValue(data.Dexpirydate);
            row["Compute1"] = GetFieldValue(data.Compute1);
            row["Compute3"] = GetFieldValue(data.Compute3);
            row["Prtotal"] = GetFieldValue(data.Prtotal);
            row["Totalfloor"] = GetFieldValue(data.Totalfloor);
            row["Compute4"] = GetFieldValue(data.Compute4);
            row["Compute5"] = GetFieldValue(data.Compute5);
            row["PprojectedHourlyRate"] = GetFieldValue(data.PprojectedHourlyRate);
            row["DEnddate"] = GetFieldValue(data.DEnddate);
            row["Compute6"] = GetFieldValue(data.Compute6);
    // TJB Sept-2010 --------------- Added ----------------
            row["FreqDesc1"] = GetFieldValue(data.FreqDesc1);
            row["FreqDays1"] = GetFieldValue(data.FreqDays1);
            row["FreqDist1"] = GetFieldValue(data.FreqDist1);
            row["FreqDesc2"] = GetFieldValue(data.FreqDesc2);
            row["FreqDays2"] = GetFieldValue(data.FreqDays2);
            row["FreqDist2"] = GetFieldValue(data.FreqDist2);
            row["FreqDesc3"] = GetFieldValue(data.FreqDesc3);
            row["FreqDays3"] = GetFieldValue(data.FreqDays3);
            row["FreqDist3"] = GetFieldValue(data.FreqDist3);
            row["FreqDesc4"] = GetFieldValue(data.FreqDesc4);
            row["FreqDays4"] = GetFieldValue(data.FreqDays4);
            row["FreqDist4"] = GetFieldValue(data.FreqDist4);
            row["FreqDesc5"] = GetFieldValue(data.FreqDesc5);
            row["FreqDays5"] = GetFieldValue(data.FreqDays5);
            row["FreqDist5"] = GetFieldValue(data.FreqDist5);
    // TJB Sept-2010 -------------- Add end ---------------
    // TJB May-2020  --------------  Added  ---------------
            row["FreqDesc6"] = GetFieldValue(data.FreqDesc6);
            row["FreqDays6"] = GetFieldValue(data.FreqDays6);
            row["FreqDist6"] = GetFieldValue(data.FreqDist6);
            row["FreqDesc7"] = GetFieldValue(data.FreqDesc7);
            row["FreqDays7"] = GetFieldValue(data.FreqDays7);
            row["FreqDist7"] = GetFieldValue(data.FreqDist7);
            row["FreqDesc8"] = GetFieldValue(data.FreqDesc8);
            row["FreqDays8"] = GetFieldValue(data.FreqDays8);
            row["FreqDist8"] = GetFieldValue(data.FreqDist8);
            row["FreqDesc9"] = GetFieldValue(data.FreqDesc9);
            row["FreqDays9"] = GetFieldValue(data.FreqDays9);
            row["FreqDist9"] = GetFieldValue(data.FreqDist9);
            row["FreqDesc10"] = GetFieldValue(data.FreqDesc10);
            row["FreqDays10"] = GetFieldValue(data.FreqDays10);
            row["FreqDist10"] = GetFieldValue(data.FreqDist10);
            row["FreqDesc11"] = GetFieldValue(data.FreqDesc11);
            row["FreqDays11"] = GetFieldValue(data.FreqDays11);
            row["FreqDist11"] = GetFieldValue(data.FreqDist11);
            row["FreqDesc12"] = GetFieldValue(data.FreqDesc12);
            row["FreqDays12"] = GetFieldValue(data.FreqDays12);
            row["FreqDist12"] = GetFieldValue(data.FreqDist12);
            // TJB May-2020  -------------- Add end ---------------
            return row;
        }
    }
}

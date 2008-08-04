using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustCriteriaDeldays
    {
        public int RegionId
        {
            get
            {
                return 0;
            }
        }
        public int OutletId
        {
            get
            {
                return 0;
            }
        }
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public int OutletPicklist
        {
            get
            {
                return 0;
            }
        }
        public string MailCategory
        {
            get
            {
                return string.Empty;
            }
        }
        public int DelDaysWeek
        {
            get
            {
                return 0;
            }
        }
        public string DelMon
        {
            get
            {
                return string.Empty;
            }
        }
        public string DelTue
        {
            get
            {
                return string.Empty;
            }
        }
        public string DeWed
        {
            get
            {
                return string.Empty;
            }
        }
        public string DelThur
        {
            get
            {
                return string.Empty;
            }
        }
        public string DelFri
        {
            get
            {
                return string.Empty;
            }
        }
        public string DelSat
        {
            get
            {
                return string.Empty;
            }
        }
        public string DelSun
        {
            get
            {
                return string.Empty;
            }
        }
        public bool DelMon1
        {
            get
            {
                return false;
            }
        }
        public bool DelTue1
        {
            get
            {
                return false;
            }
        }
        public bool DeWed1
        {
            get
            {
                return false;
            }
        }
        public bool DelThur1
        {
            get
            {
                return false;
            }
        }
        public bool DelFri1
        {
            get
            {
                return false;
            }
        }
        public bool DelSat1
        {
            get
            {
                return false;
            }
        }
        public bool DelSun1
        {
            get
            {
                return false;
            }
        }
        public string DelDaysCondition
        {
            get
            {
                return string.Empty;
            }
        }
        public bool DelDaysCondition1
        {
            get
            {
                return false;
            }
        }
        public bool DelDaysCondition2
        {
            get
            {
                return false;
            }
        }
        public string DirectoryListing
        {
            get
            {
                return string.Empty;
            }
        }
        public bool DirectoryListing1
        {
            get
            {
                return false;
            }
        }
        public bool DirectoryListing2
        {
            get
            {
                return false;
            }
        }
        public bool DirectoryListing3
        {
            get
            {
                return false;
            }
        }
        public string CustDeType
        {
            get
            {
                return string.Empty;
            }
        }
        public DateTime DateStart
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime DateEnd
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public string PrintRecipients
        {
            get
            {
                return string.Empty;
            }
        }
        public bool PrintRecipients1
        {
            get
            {
                return false;
            }
        }
        public string SortOrder
        {
            get
            {
                return string.Empty;
            }
        }
        public int CustomerCount
        {
            get
            {
                return 0;
            }
        }
        public int RecipientCount
        {
            get
            {
                return 0;
            }
        }
        public string DetailedReport
        {
            get
            {
                return string.Empty;
            }
        }
        public bool DetailedReport1
        {
            get
            {
                return false;
            }
        }
        public bool DetailedReport2
        {
            get
            {
                return false;
            }
        }
        public bool DetailedReport3
        {
            get
            {
                return false;
            }
        }
        public int RandomNumber
        {
            get
            {
                return 0;
            }
        }
        public DateTime PrintedonFromdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime PrintedonTodate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int CtKey
        {
            get
            {
                return 0;
            }
        }
        public DateTime LoadedFromdate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public DateTime LoadedTodate
        {
            get
            {
                return DateTime.MinValue;
            }
        }
        public int RgCode
        {
            get
            {
                return 0;
            }
        }
        public string UsePrintedon
        {
            get
            {
                return string.Empty;
            }
        }
        public bool UsePrintedon1
        {
            get
            {
                return false;
            }
        }
        public bool Updateafterprint1
        {
            get
            {
                return false;
            }
        }
        public string Updateafterprint
        {
            get
            {
                return string.Empty;
            }
        }
        public int ContractNo
        {
            get
            {
                return 0;
            }
        }
        public string AnyDays
        {
            get
            {
                return string.Empty;
            }
        }
        public string OnlyDays
        {
            get
            {
                return string.Empty;
            }
        }
        public string AnyDaysOld
        {
            get
            {
                return string.Empty;
            }
        }
        public string StRecipient
        {
            get
            {
                return string.Empty;
            }
        }
        public string StCounter
        {
            get
            {
                return string.Empty;
            }
        }
    }
    public class CustCriteriaDeldaysDataSet : ReportDataSet<CustCriteriaDeldays>
    {

        public DataColumn RegionId = new DataColumn("RegionId", typeof(int));

        public DataColumn OutletId = new DataColumn("OutletId", typeof(int));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn OutletPicklist = new DataColumn("OutletPicklist", typeof(int));

        public DataColumn MailCategory = new DataColumn("MailCategory", typeof(string));

        public DataColumn DelDaysWeek = new DataColumn("DelDaysWeek", typeof(int));

        public DataColumn DelMon = new DataColumn("DelMon", typeof(string));

        public DataColumn DelTue = new DataColumn("DelTue", typeof(string));

        public DataColumn DeWed = new DataColumn("DeWed", typeof(string));

        public DataColumn DelThur = new DataColumn("DelThur", typeof(string));

        public DataColumn DelFri = new DataColumn("DelFri", typeof(string));

        public DataColumn DelSat = new DataColumn("DelSat", typeof(string));

        public DataColumn DelSun = new DataColumn("DelSun", typeof(string));

        public DataColumn DelMon1 = new DataColumn("DelMon1", typeof(bool));

        public DataColumn DelTue1 = new DataColumn("DelTue1", typeof(bool));

        public DataColumn DeWed1 = new DataColumn("DeWed1", typeof(bool));

        public DataColumn DelThur1 = new DataColumn("DelThur1", typeof(bool));

        public DataColumn DelFri1 = new DataColumn("DelFri1", typeof(bool));

        public DataColumn DelSat1 = new DataColumn("DelSat1", typeof(bool));

        public DataColumn DelSun1 = new DataColumn("DelSun1", typeof(bool));

        public DataColumn DelDaysCondition = new DataColumn("DelDaysCondition", typeof(string));

        public DataColumn DelDaysCondition1 = new DataColumn("DelDaysCondition1", typeof(bool));

        public DataColumn DelDaysCondition2 = new DataColumn("DelDaysCondition2", typeof(bool));

        public DataColumn DirectoryListing = new DataColumn("DirectoryListing", typeof(string));

        public DataColumn DirectoryListing1 = new DataColumn("DirectoryListing1", typeof(bool));

        public DataColumn DirectoryListing2 = new DataColumn("DirectoryListing2", typeof(bool));

        public DataColumn DirectoryListing3 = new DataColumn("DirectoryListing3", typeof(bool));

        public DataColumn CustDeType = new DataColumn("CustDeType", typeof(string));

        public DataColumn DateStart = new DataColumn("DateStart", typeof(DateTime));

        public DataColumn DateEnd = new DataColumn("DateEnd", typeof(DateTime));

        public DataColumn PrintRecipients = new DataColumn("PrintRecipients", typeof(string));

        public DataColumn PrintRecipients1 = new DataColumn("PrintRecipients1", typeof(bool));

        public DataColumn SortOrder = new DataColumn("SortOrder", typeof(string));

        public DataColumn CustomerCount = new DataColumn("CustomerCount", typeof(int));

        public DataColumn RecipientCount = new DataColumn("RecipientCount", typeof(int));

        public DataColumn DetailedReport = new DataColumn("DetailedReport", typeof(string));

        public DataColumn DetailedReport1 = new DataColumn("DetailedReport1", typeof(bool));

        public DataColumn DetailedReport2 = new DataColumn("DetailedReport2", typeof(bool));

        public DataColumn DetailedReport3 = new DataColumn("DetailedReport3", typeof(bool));

        public DataColumn RandomNumber = new DataColumn("RandomNumber", typeof(int));

        public DataColumn PrintedonFromdate = new DataColumn("PrintedonFromdate", typeof(DateTime));

        public DataColumn PrintedonTodate = new DataColumn("PrintedonTodate", typeof(DateTime));

        public DataColumn CtKey = new DataColumn("CtKey", typeof(int));

        public DataColumn LoadedFromdate = new DataColumn("LoadedFromdate", typeof(DateTime));

        public DataColumn LoadedTodate = new DataColumn("LoadedTodate", typeof(DateTime));

        public DataColumn RgCode = new DataColumn("RgCode", typeof(int));

        public DataColumn UsePrintedon = new DataColumn("UsePrintedon", typeof(string));

        public DataColumn UsePrintedon1 = new DataColumn("UsePrintedon1", typeof(bool));

        public DataColumn Updateafterprint1 = new DataColumn("Updateafterprint1", typeof(bool));

        public DataColumn Updateafterprint = new DataColumn("Updateafterprint", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn AnyDays = new DataColumn("AnyDays", typeof(string));

        public DataColumn OnlyDays = new DataColumn("OnlyDays", typeof(string));

        public DataColumn AnyDaysOld = new DataColumn("AnyDaysOld", typeof(string));

        public DataColumn StRecipient = new DataColumn("StRecipient", typeof(string));

        public DataColumn StCounter = new DataColumn("StCounter", typeof(string));


        public CustCriteriaDeldaysDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RegionId,OutletId,OName,OutletPicklist,MailCategory,DelDaysWeek,DelMon,DelTue,DeWed,DelThur,DelFri,DelSat,DelSun,DelMon1,DelTue1,DeWed1,DelThur1,DelFri1,DelSat1,DelSun1,DelDaysCondition,DelDaysCondition1,DelDaysCondition2,DirectoryListing,DirectoryListing1,DirectoryListing2,DirectoryListing3,CustDeType,DateStart,DateEnd,PrintRecipients,PrintRecipients1,SortOrder,CustomerCount,RecipientCount,DetailedReport,DetailedReport1,DetailedReport2,DetailedReport3,RandomNumber,PrintedonFromdate,PrintedonTodate,CtKey,LoadedFromdate,LoadedTodate,RgCode,UsePrintedon,UsePrintedon1,Updateafterprint1,Updateafterprint,ContractNo,AnyDays,OnlyDays,AnyDaysOld,StRecipient,StCounter
				});
            RegionId.AllowDBNull = true;
            OutletId.AllowDBNull = true;
            OutletPicklist.AllowDBNull = true;
            DelDaysWeek.AllowDBNull = true;
            DelMon1.AllowDBNull = true;
            DelTue1.AllowDBNull = true;
            DeWed1.AllowDBNull = true;
            DelThur1.AllowDBNull = true;
            DelFri1.AllowDBNull = true;
            DelSat1.AllowDBNull = true;
            DelSun1.AllowDBNull = true;
            DateStart.AllowDBNull = true;
            DateEnd.AllowDBNull = true;
            PrintRecipients1.AllowDBNull = true;
            CustomerCount.AllowDBNull = true;
            RecipientCount.AllowDBNull = true;
            RandomNumber.AllowDBNull = true;
            PrintedonFromdate.AllowDBNull = true;
            PrintedonTodate.AllowDBNull = true;
            CtKey.AllowDBNull = true;
            LoadedFromdate.AllowDBNull = true;
            LoadedTodate.AllowDBNull = true;
            RgCode.AllowDBNull = true;
            UsePrintedon1.AllowDBNull = true;
            Updateafterprint1.AllowDBNull = true;
            ContractNo.AllowDBNull = true;

        }

        public CustCriteriaDeldaysDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustCriteriaDeldays> datas = dataSource as Metex.Core.EntityBindingList<CustCriteriaDeldays>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustCriteriaDeldays data)
        {
            DataRow row = this.NewRow();
            row["RegionId"] = GetFieldValue(data.RegionId);
            row["OutletId"] = GetFieldValue(data.OutletId);
            row["OName"] = GetFieldValue(data.OName);
            row["OutletPicklist"] = GetFieldValue(data.OutletPicklist);
            row["MailCategory"] = GetFieldValue(data.MailCategory);
            row["DelDaysWeek"] = GetFieldValue(data.DelDaysWeek);
            row["DelMon"] = GetFieldValue(data.DelMon);
            row["DelTue"] = GetFieldValue(data.DelTue);
            row["DeWed"] = GetFieldValue(data.DeWed);
            row["DelThur"] = GetFieldValue(data.DelThur);
            row["DelFri"] = GetFieldValue(data.DelFri);
            row["DelSat"] = GetFieldValue(data.DelSat);
            row["DelSun"] = GetFieldValue(data.DelSun);
            row["DelMon1"] = GetFieldValue(data.DelMon1);
            row["DelTue1"] = GetFieldValue(data.DelTue1);
            row["DeWed1"] = GetFieldValue(data.DeWed1);
            row["DelThur1"] = GetFieldValue(data.DelThur1);
            row["DelFri1"] = GetFieldValue(data.DelFri1);
            row["DelSat1"] = GetFieldValue(data.DelSat1);
            row["DelSun1"] = GetFieldValue(data.DelSun1);
            row["DelDaysCondition"] = GetFieldValue(data.DelDaysCondition);
            row["DelDaysCondition1"] = GetFieldValue(data.DelDaysCondition1);
            row["DelDaysCondition2"] = GetFieldValue(data.DelDaysCondition2);
            row["DirectoryListing"] = GetFieldValue(data.DirectoryListing);
            row["DirectoryListing1"] = GetFieldValue(data.DirectoryListing1);
            row["DirectoryListing2"] = GetFieldValue(data.DirectoryListing2);
            row["DirectoryListing3"] = GetFieldValue(data.DirectoryListing3);
            row["CustDeType"] = GetFieldValue(data.CustDeType);
            row["DateStart"] = GetFieldValue(data.DateStart);
            row["DateEnd"] = GetFieldValue(data.DateEnd);
            row["PrintRecipients"] = GetFieldValue(data.PrintRecipients);
            row["PrintRecipients1"] = GetFieldValue(data.PrintRecipients1);
            row["SortOrder"] = GetFieldValue(data.SortOrder);
            row["CustomerCount"] = GetFieldValue(data.CustomerCount);
            row["RecipientCount"] = GetFieldValue(data.RecipientCount);
            row["DetailedReport"] = GetFieldValue(data.DetailedReport);
            row["DetailedReport1"] = GetFieldValue(data.DetailedReport1);
            row["DetailedReport2"] = GetFieldValue(data.DetailedReport2);
            row["DetailedReport3"] = GetFieldValue(data.DetailedReport3);
            row["RandomNumber"] = GetFieldValue(data.RandomNumber);
            row["PrintedonFromdate"] = GetFieldValue(data.PrintedonFromdate);
            row["PrintedonTodate"] = GetFieldValue(data.PrintedonTodate);
            row["CtKey"] = GetFieldValue(data.CtKey);
            row["LoadedFromdate"] = GetFieldValue(data.LoadedFromdate);
            row["LoadedTodate"] = GetFieldValue(data.LoadedTodate);
            row["RgCode"] = GetFieldValue(data.RgCode);
            row["UsePrintedon"] = GetFieldValue(data.UsePrintedon);
            row["UsePrintedon1"] = GetFieldValue(data.UsePrintedon1);
            row["Updateafterprint1"] = GetFieldValue(data.Updateafterprint1);
            row["Updateafterprint"] = GetFieldValue(data.Updateafterprint);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["AnyDays"] = GetFieldValue(data.AnyDays);
            row["OnlyDays"] = GetFieldValue(data.OnlyDays);
            row["AnyDaysOld"] = GetFieldValue(data.AnyDaysOld);
            row["StRecipient"] = GetFieldValue(data.StRecipient);
            row["StCounter"] = GetFieldValue(data.StCounter);
            return row;
        }
    }
}

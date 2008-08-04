using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NZPostOffice.RDS.Entity.Ruralrpt;
namespace NZPostOffice.RDS.DataControls.Report
{

    public class RCustCount
    {
        public string RgnName
        {
            get
            {
                return string.Empty;
            }
        }
        public string OName
        {
            get
            {
                return string.Empty;
            }
        }
        public string ConTitle
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
        public int REContractNo
        {
            get
            {
                return 0;
            }
        }
        public int Resident
        {
            get
            {
                return 0;
            }
        }
        public int REResident
        {
            get
            {
                return 0;
            }
        }
        public int Business
        {
            get
            {
                return 0;
            }
        }
        public int REBusiness
        {
            get
            {
                return 0;
            }
        }
        public int Farmer
        {
            get
            {
                return 0;
            }
        }
        public int REFarmer
        {
            get
            {
                return 0;
            }
        }
        public int Unclassified
        {
            get
            {
                return 0;
            }
        }
        public int REUnclassified
        {
            get
            {
                return 0;
            }
        }
        public int Cmb
        {
            get
            {
                return 0;
            }
        }
        public int REmb
        {
            get
            {
                return 0;
            }
        }
    }
    public class CustCountDataSet : ReportDataSet<CustCount>
    {

        public DataColumn RgnName = new DataColumn("RgnName", typeof(string));

        public DataColumn OName = new DataColumn("OName", typeof(string));

        public DataColumn ConTitle = new DataColumn("ConTitle", typeof(string));

        public DataColumn ContractNo = new DataColumn("ContractNo", typeof(int));

        public DataColumn REContractNo = new DataColumn("REContractNo", typeof(int));

        public DataColumn Resident = new DataColumn("Resident", typeof(int));

        public DataColumn REResident = new DataColumn("REResident", typeof(int));

        public DataColumn Business = new DataColumn("Business", typeof(int));

        public DataColumn REBusiness = new DataColumn("REBusiness", typeof(int));

        public DataColumn Farmer = new DataColumn("Farmer", typeof(int));

        public DataColumn REFarmer = new DataColumn("REFarmer", typeof(int));

        public DataColumn Unclassified = new DataColumn("Unclassified", typeof(int));

        public DataColumn REUnclassified = new DataColumn("REUnclassified", typeof(int));

        public DataColumn Cmb = new DataColumn("Cmb", typeof(int));

        public DataColumn REmb = new DataColumn("REmb", typeof(int));


        public CustCountDataSet()
        {
            this.Columns.AddRange(new DataColumn[]{
				RgnName,OName,ConTitle,ContractNo,REContractNo,Resident,REResident,Business,REBusiness,Farmer,REFarmer,Unclassified,REUnclassified,Cmb,REmb
				});
            ContractNo.AllowDBNull = true;
            REContractNo.AllowDBNull = true;
            Resident.AllowDBNull = true;
            REResident.AllowDBNull = true;
            Business.AllowDBNull = true;
            REBusiness.AllowDBNull = true;
            Farmer.AllowDBNull = true;
            REFarmer.AllowDBNull = true;
            Unclassified.AllowDBNull = true;
            REUnclassified.AllowDBNull = true;
            Cmb.AllowDBNull = true;
            REmb.AllowDBNull = true;

        }

        public CustCountDataSet(object dataSource)
            : this()
        {
            Metex.Core.EntityBindingList<CustCount> datas = dataSource as Metex.Core.EntityBindingList<CustCount>;
            if (this.Columns.Count != 0)
            {
                ApplyRows(datas);
            }
        }

        protected override DataRow ApplyRow(CustCount data)
        {
            DataRow row = this.NewRow();
            row["RgnName"] = GetFieldValue(data.RgnName);
            row["OName"] = GetFieldValue(data.OName);
            row["ConTitle"] = GetFieldValue(data.ConTitle);
            row["ContractNo"] = GetFieldValue(data.ContractNo);
            row["REContractNo"] = GetFieldValue(data.REContractNo);
            row["Resident"] = GetFieldValue(data.Resident);
            row["REResident"] = GetFieldValue(data.REResident);
            row["Business"] = GetFieldValue(data.Business);
            row["REBusiness"] = GetFieldValue(data.REBusiness);
            row["Farmer"] = GetFieldValue(data.Farmer);
            row["REFarmer"] = GetFieldValue(data.REFarmer);
            row["Unclassified"] = GetFieldValue(data.Unclassified);
            row["REUnclassified"] = GetFieldValue(data.REUnclassified);
            row["Cmb"] = GetFieldValue(data.Cmb);
            row["REmb"] = GetFieldValue(data.REmb);
            return row;
        }
    }
}

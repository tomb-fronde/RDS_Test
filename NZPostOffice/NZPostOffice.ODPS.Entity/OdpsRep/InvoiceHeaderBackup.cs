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
    [MapInfo("contract_no", "_contract_no", "rd.contract")]
    [MapInfo("c_gst_number", "_c_gst_number", "rd.contractor")]
    [MapInfo("con_title", "_con_title", "rd.contract")]
    [MapInfo("c_surname_company", "_c_surname_company", "rd.contractor")]
    [MapInfo("c_first_names", "_c_first_names", "rd.contractor")]
    [MapInfo("c_address", "_c_address", "rd.contractor")]
    [MapInfo("invoice_no", "_cinvoice_no", "payment")]
    [MapInfo("ds_no", "_ds_no", "payment")]
    [MapInfo("invoice_id", "_payment_invoice_id", "payment")]
    [MapInfo("contractor_supplier_no", "_contractor_contractor_supplier_no", "rd.contractor")]
    [MapInfo("compute_0011", "_compute_0011", "payment")]
    [MapInfo("compute_0012", "_piece_rate_count", "payment")]
    [System.Serializable()]

    public class InvoiceHeaderBackup : Entity<InvoiceHeaderBackup>
    {
        #region Business Methods
        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _c_gst_number;

        [DBField()]
        private string _con_title;

        [DBField()]
        private string _c_surname_company;

        [DBField()]
        private string _c_first_names;

        [DBField()]
        private string _c_address;

        [DBField()]
        private string _cinvoice_no;

        [DBField()]
        private string _ds_no;

        [DBField()]
        private int? _payment_invoice_id;

        [DBField()]
        private int? _contractor_contractor_supplier_no;

        [DBField()]
        private string _compute_0011;

        [DBField()]
        private int? _piece_rate_count;

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

        public int REContractNo
        {
            get
            {
                return (int)_contract_no;
            }
        }

        public virtual string CGstNumber
        {
            get
            {
                CanReadProperty("CGstNumber", true);
                return _c_gst_number;
            }
            set
            {
                CanWriteProperty("CGstNumber", true);
                if (_c_gst_number != value)
                {
                    _c_gst_number = value;
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

        public virtual string CSurnameCompany
        {
            get
            {
                CanReadProperty("CSurnameCompany", true);
                return _c_surname_company;
            }
            set
            {
                CanWriteProperty("CSurnameCompany", true);
                if (_c_surname_company != value)
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
                CanReadProperty("CFirstNames", true);
                return _c_first_names;
            }
            set
            {
                CanWriteProperty("CFirstNames", true);
                if (_c_first_names != value)
                {
                    _c_first_names = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CAddress
        {
            get
            {
                CanReadProperty("CAddress", true);
                return _c_address;
            }
            set
            {
                CanWriteProperty("CAddress", true);
                if (_c_address != value)
                {
                    _c_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CinvoiceNo
        {
            get
            {
                CanReadProperty("CinvoiceNo", true);
                return _cinvoice_no;
            }
            set
            {
                CanWriteProperty("CinvoiceNo", true);
                if (_cinvoice_no != value)
                {
                    _cinvoice_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string DsNo
        {
            get
            {
                CanReadProperty("DsNo", true);
                return _ds_no;
            }
            set
            {
                CanWriteProperty("DsNo", true);
                if (_ds_no != value)
                {
                    _ds_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PaymentInvoiceId
        {
            get
            {
                CanReadProperty("PaymentInvoiceId", true);
                return _payment_invoice_id;
            }
            set
            {
                CanWriteProperty("PaymentInvoiceId", true);
                if (_payment_invoice_id != value)
                {
                    _payment_invoice_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REPaymentInvoiceId
        {
            get
            {
                return (int)_payment_invoice_id;
            }
        }

        public virtual int? ContractorContractorSupplierNo
        {
            get
            {
                CanReadProperty("ContractorContractorSupplierNo", true);
                return _contractor_contractor_supplier_no;
            }
            set
            {
                CanWriteProperty("ContractorContractorSupplierNo", true);
                if (_contractor_contractor_supplier_no != value)
                {
                    _contractor_contractor_supplier_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REContractorContractorSupplierNo
        {
            get
            {
                return (int)_contractor_contractor_supplier_no;
            }
        }

        public virtual string Compute0011
        {
            get
            {
                CanReadProperty("Compute0011", true);
                return _compute_0011;
            }
            set
            {
                CanWriteProperty("Compute0011", true);
                if (_compute_0011 != value)
                {
                    _compute_0011 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PieceRateCount
        {
            get
            {
                CanReadProperty(true);
                return _piece_rate_count;
            }
            set
            {
                CanWriteProperty(true);
                if (_piece_rate_count != value)
                {
                    _piece_rate_count = value;
                    PropertyHasChanged();
                }
            }
        }

        public int REPieceRateCount
        {
            get
            {
                return (int)_piece_rate_count;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static InvoiceHeaderBackup NewInvoiceHeaderBackup(DateTime? end_date, int? contractor, int? contract, int? region, string cname)
        {
            return Create(end_date, contractor, contract, region, cname);
        }

        public static InvoiceHeaderBackup[] GetAllInvoiceHeaderBackup(DateTime? end_date, int? contractor, int? contract, int? region, string cname)
        {
            return Fetch(end_date, contractor, contract, region, cname).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? end_date, int? contractor, int? contract, int? region, string cname)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT  rd.contract.contract_no ," +
                                        "rd.contractor.c_gst_number ," +
                                        "rd.contract.con_title ," +
                                        "rd.contractor.c_surname_company ," +
                                        "rd.contractor.c_first_names ," +
                                        "rd.contractor.c_address ," +
                                        "OD_MiscF_Get_Invoicenumber(invoice_no,:end_date) as invoice_no," +
                                        "(SELECT min(ifnull(cd_old_ds_no,string(contractor_ds.contractor_supplier_no),cd_old_ds_no)) " +
                                    "FROM rd.contractor_ds" +
                                    "WHERE contractor_ds.contractor_supplier_no = contractor.contractor_supplier_no ) as DS_NO," +
                                            "payment.invoice_id ," +
                                            "rd.contractor.contractor_supplier_no ," +
                                            "(isnull(message_for_invoice ,(select nat_message_for_invoice from national where nat_id=od_blf_getwhichnational( :end_date ) )  ))," +
                                            "(select count(*) from payment_component_piece_rates ,payment_component " +
                                            "where payment_component.pc_id=payment_component_piece_rates.pc_id and payment_component.invoice_id=payment.invoice_id) FROM payment ,rd.contract ," +
                                            "rd.contractor ,rd.outlet WHERE ( payment.contract_no = rd.contract.contract_no ) and ( payment.contractor_supplier_no = rd.contractor.contractor_supplier_no ) and ( rd.contract.con_base_office = rd.outlet.outlet_id ) and ((payment.contractor_supplier_no = :contractor and ( :contractor > 0) ) or (:contractor = 0 and ( payment.contract_no = :contract ) and ( :contract > 0) ) or :contractor = 0 and :contract = 0)) ) and  payment.invoice_date = :end_date ) and ((rd.outlet.region_id = :region and ( :region <> 0) ) or(:region = 0)) and ((rd.contractor.c_surname_company like :cname||'%' and length(:cname) > 0) ) or length(:cname) = 0))  " +
                                    "ORDER BY rd.contract.contract_no ASC";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "end_date", end_date);
                    pList.Add(cm, "contractor", contractor);
                    pList.Add(cm, "contract", contract);
                    pList.Add(cm, "region", region);
                    pList.Add(cm, "cname", cname);
                    //GenerateSelectCommandText(cm, "payment");
                    //GenerateSelectCommandText(cm, "rd.contract");
                    //GenerateSelectCommandText(cm, "rd.contractor");
                    //GenerateSelectCommandText(cm, "rd.outlet");
                    //cm.CommandText += "ORDER BY rd.contract.contract_no ASC";

                    List<InvoiceHeaderBackup> _list = new List<InvoiceHeaderBackup>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceHeaderBackup instance = new InvoiceHeaderBackup();
                            //instance.StoreFieldValues(dr, "payment");
                            //instance.StoreFieldValues(dr, "rd.contract");
                            //instance.StoreFieldValues(dr, "rd.contractor");
                            //instance.StoreFieldValues(dr, "rd.outlet");
                            instance.MarkOld();
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

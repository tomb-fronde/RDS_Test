using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsInvoice
{
    // TJB RPCR_111 28-Jun-2018
    // Added CEmailAddress (and _c_email_address) to values retreived

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("start_date", "_contract_start_date", "contract")]
    [MapInfo("contract_no", "_contract_no", "contract")]
    [MapInfo("contractor_supplier_no", "_contractor_contractor_supplier_no", "contractor")]
    [MapInfo("c_gst_number", "_c_gst_number", "contractor")]
    [MapInfo("con_title", "_con_title", "contract")]
    [MapInfo("c_surname_company", "_c_surname_company", "contractor")]
    [MapInfo("c_first_names", "_c_first_names", "contractor")]
    [MapInfo("c_address", "_c_address", "contractor")]
    [MapInfo("c_email_address", "_c_email_address", "contractor")]
    [MapInfo("invoice_no", "_cinvoice_no", "odps.national")]
    [MapInfo("invoice_id", "_payment_invoice_id", "payment")]
    [MapInfo("compute_0011", "_prc", "odps.national")]
    [MapInfo("compute_0012", "_compute_0012", "odps.national")]
    [MapInfo("ds_no", "_ds_no", "odps.national")]
    [MapInfo("invmessage", "_cinvmessage", "odps.national")]
    [MapInfo("xpc", "_cxpc", "odps.national")]
    [System.Serializable()]

    public class InvoiceHeaderOnly : Entity<InvoiceHeaderOnly>
    {
        #region Business Methods
        [DBField()]
        private string _contract_start_date;

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
        private int? _payment_invoice_id;

        [DBField()]
        private int? _contractor_contractor_supplier_no;

        [DBField()]
        private string _c_email_address;

        [DBField()]
        private string _prc;

        [DBField()]
        private int? _compute_0012;

        [DBField()]
        private string _ds_no;

        [DBField()]
        private string _cinvmessage;

        [DBField()]
        private int? _cxpc;

        public virtual string ContractStartDate
        {
            get
            {
                CanReadProperty("ContractStartDate",true);
                return _contract_start_date;
            }
            set
            {
                CanWriteProperty("ContractStartDate",true);
                if (_contract_start_date != value)
                {
                    _contract_start_date = value;
                    PropertyHasChanged();
                }
            }
        }

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
                CanReadProperty("CGstNumber",true);
                return _c_gst_number;
            }
            set
            {
                CanWriteProperty("CGstNumber",true);
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
                CanReadProperty("ConTitle",true);
                return _con_title;
            }
            set
            {
                CanWriteProperty("ConTitle",true);
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
                CanReadProperty("CSurnameCompany",true);
                return _c_surname_company;
            }
            set
            {
                CanWriteProperty("CSurnameCompany",true);
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
                CanReadProperty("CFirstNames",true);
                return _c_first_names;
            }
            set
            {
                CanWriteProperty("CFirstNames",true);
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
                CanReadProperty("CAddress",true);
                return _c_address;
            }
            set
            {
                CanWriteProperty("CAddress",true);
                if (_c_address != value)
                {
                    _c_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CEmailAddress
        {
            get
            {
                CanReadProperty("CEmailAddress", true);
                return _c_email_address;
            }
            set
            {
                CanWriteProperty("CEmailAddress", true);
                if (_c_email_address != value)
                {
                    _c_email_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string CinvoiceNo
        {
            get
            {
                CanReadProperty("CinvoiceNo",true);
                return _cinvoice_no;
            }
            set
            {
                CanWriteProperty("CinvoiceNo",true);
                if (_cinvoice_no != value)
                {
                    _cinvoice_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PaymentInvoiceId
        {
            get
            {
                CanReadProperty("PaymentInvoiceId",true);
                return _payment_invoice_id;
            }
            set
            {
                CanWriteProperty("PaymentInvoiceId",true);
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
                CanReadProperty("ContractorContractorSupplierNo",true);
                return _contractor_contractor_supplier_no;
            }
            set
            {
                CanWriteProperty("ContractorContractorSupplierNo",true);
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

        public virtual string Prc
        {
            get
            {
                CanReadProperty("Prc",true);
                return _prc;
            }
            set
            {
                CanWriteProperty("Prc",true);
                if (_prc != value)
                {
                    _prc = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Compute0012
        {
            get
            {
                CanReadProperty("Compute0012",true);
                return _compute_0012;
            }
            set
            {
                CanWriteProperty("Compute0012",true);
                if (_compute_0012 != value)
                {
                    _compute_0012 = value;
                    PropertyHasChanged();
                }
            }
        }

        public int RECompute0012
        {
            get
            {
                return (int)_compute_0012;
            }
        }

        public virtual string DsNo
        {
            get
            {
                CanReadProperty("DsNo",true);
                return _ds_no;
            }
            set
            {
                CanWriteProperty("DsNo",true);
                if (_ds_no != value)
                {
                    _ds_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Cinvmessage
        {
            get
            {
                CanReadProperty("Cinvmessage",true);
                return _cinvmessage;
            }
            set
            {
                CanWriteProperty("Cinvmessage",true);
                if (_cinvmessage != value)
                {
                    _cinvmessage = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Cxpc
        {
            get
            {
                CanReadProperty("Cxpc",true);
                return _cxpc;
            }
            set
            {
                CanWriteProperty("Cxpc",true);
                if (_cxpc != value)
                {
                    _cxpc = value;
                    PropertyHasChanged();
                }
            }
        }

        public string Compute4
        {
            get
            {

                return (_c_first_names == null ? "" : _c_first_names + " ") + _c_surname_company;
            }
        }

        public int RECxpc
        {
            get
            {
                return (int)_cxpc;
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }

        #endregion

        #region Factory Methods
        public static InvoiceHeaderOnly NewInvoiceHeaderOnly(DateTime? start_date, DateTime? end_date, int? contractor, int? contract, int? region, string cname, int? ctKey)
        {
            return Create(start_date, end_date, contractor, contract, region, cname, ctKey);
        }

        public static InvoiceHeaderOnly[] GetAllInvoiceHeaderOnly(DateTime? start_date, DateTime? end_date, int? contractor, int? contract, int? region, string cname, int? ctKey)
        {
            return Fetch(start_date, end_date, contractor, contract, region, cname, ctKey).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? start_date, DateTime? end_date, int? contractor, int? contract, int? region, string cname, int? ctKey)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = @"  SELECT :start_date as start_date,
                                         [contract].contract_no,   
                                         contractor.c_gst_number,   
                                         [contract].con_title,   
                                         contractor.c_surname_company,   
                                         contractor.c_first_names,   
                                         contractor.c_address,   
                                         odps.OD_MiscF_Get_Invoicenumber(invoice_no,:end_date) as invoice_no,   
                                         payment.invoice_id,   
                                         contractor.contractor_supplier_no,  
                                         (isnull(message_for_invoice , (select nat_message_for_invoice from odps.[national] where nat_id=odps.od_blf_getwhichnational(:end_date) )  )),   
                                         (select count(*) from odps.payment_component_piece_rates, odps.payment_component where payment_component.pc_id=payment_component_piece_rates.pc_id and payment_component.invoice_id=payment.invoice_id),   
                                         isnull((SELECT max( 
                                                        case when cd_old_ds_no= Null 
                                                        then 'RD0'+convert(varchar(20),contractor_ds.contractor_supplier_no)
                                                        else cd_old_ds_no
                                                        end) FROM rd.contractor_ds  WHERE contractor_ds.contractor_supplier_no = contractor.contractor_supplier_no ),'RD0'+convert(varchar(20),contractor.contractor_supplier_no)) as DS_NO,   
                                         (isnull(message_for_invoice , (select nat_message_for_invoice from odps.[national] where nat_id=odps.od_blf_getwhichnational(:end_date)))) as  invmessage,   
                                         (select count(*) from odps.payment_component_piece_rates, odps.payment_component, odps.payment_component_type  where payment_component_type.pct_id= payment_component.pct_id and pct_description like 'XP%' and payment_component.pc_id=payment_component_piece_rates.pc_id and payment_component.invoice_id=payment.invoice_id) xpc
                                        ,contractor.c_email_address
                                    FROM odps.payment,   
                                         rd.[contract],   
                                         rd.contractor,   
                                         rd.outlet,
			                             rd.types_for_contract
                                   WHERE payment.contract_no = [contract].contract_no 
                                     AND payment.contractor_supplier_no = contractor.contractor_supplier_no 
                                     AND [contract].con_base_office = outlet.outlet_id 
                                     AND payment.invoice_date = :end_date 
                                     AND (  (:contractor > 0 AND :contract > 0 
                                                             AND payment.contractor_supplier_no = :contractor
                                                             AND payment.contract_no = :contract)
                                         OR (:contractor > 0 AND :contract = 0 
                                                             AND payment.contractor_supplier_no = :contractor) 
                                         OR (:contractor = 0 AND :contract > 0
                                                             AND payment.contract_no = :contract)
                                         OR (:contractor = 0 AND :contract = 0) ) 
                                     AND ( (outlet.region_id = :region AND :region <> 0) OR :region = 0 ) 
                                     AND ( (contractor.c_surname_company like :cname+'%' AND len(:cname) > 0) 
                                            OR len(:cname) = 0 )
                                     AND ( (types_for_contract.ct_key = :ctKey AND :ctKey <> 0) OR :ctKey = 0 ) 
                                     AND types_for_contract.contract_no = [contract].contract_no
                                   ORDER BY [contract].contract_no ASC   ";

                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "start_date", start_date);
                    pList.Add(cm, "end_date", end_date);
                    pList.Add(cm, "contractor", contractor);
                    pList.Add(cm, "contract", contract);
                    pList.Add(cm, "region", region);
                    pList.Add(cm, "cname", cname);
                    pList.Add(cm, "ctKey", ctKey);

                    List<InvoiceHeaderOnly> _list = new List<InvoiceHeaderOnly>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceHeaderOnly instance = new InvoiceHeaderOnly();
                            instance._contract_start_date = GetValueFromReader<string>(dr,0); ;
                            instance._contract_no = GetValueFromReader<Int32?>(dr,1); ;
                            instance._c_gst_number = GetValueFromReader<string>(dr,2);
                            instance._con_title = GetValueFromReader<string>(dr,3);
                            instance._c_surname_company = GetValueFromReader<string>(dr,4);
                            instance._c_first_names = GetValueFromReader<string>(dr,5);
                            instance._c_address = GetValueFromReader<string>(dr,6);
                            instance._cinvoice_no = GetValueFromReader<string>(dr,7);
                            instance._payment_invoice_id = GetValueFromReader<Int32?>(dr,8);
                            instance._contractor_contractor_supplier_no = GetValueFromReader<Int32?>(dr,9);
                            instance._prc = GetValueFromReader<string>(dr,10);
                            instance._compute_0012 = GetValueFromReader<Int32?>(dr,11);
                            instance._ds_no = GetValueFromReader<string>(dr,12);
                            instance._cinvmessage = GetValueFromReader<string>(dr,13);
                            instance._cxpc = GetValueFromReader<Int32?>(dr,14);
                            instance._c_email_address = GetValueFromReader<string>(dr, 15);
                            //instance.StoreFieldValues(dr, "odps.national");
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

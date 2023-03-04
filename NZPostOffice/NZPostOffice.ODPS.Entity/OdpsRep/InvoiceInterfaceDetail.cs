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
    [MapInfo("invoice_no_1", "_invoice_no_1", "")]
    [MapInfo("ownerdriver_name_2", "_ownerdriver_name_2", "")]
    [MapInfo("address_3", "_address_3", "")]
    [MapInfo("gst_number_4", "_gst_number_4", "")]
    [MapInfo("message_5", "_message_5", "")]
    [MapInfo("basic_pay_6", "_basic_pay_6", "")]
    [MapInfo("allowance_7", "_allowance_7", "")]
    [MapInfo("pre_tax_adj_8", "_pre_tax_adj_8", "")]
    [MapInfo("courier_post_vol_9", "_courier_post_vol_9", "")]
    [MapInfo("courier_post_value_10", "_courier_post_value_10", "")]
    [MapInfo("adpost_vol_11", "_adpost_vol_11", "")]
    [MapInfo("adpost_value_12", "_adpost_value_12", "")]
    [MapInfo("gross_pay13", "_gross_pay13", "")]
    [MapInfo("gst_14", "_gst_14", "")]
    [MapInfo("tax_15", "_tax_15", "")]
    [MapInfo("post_tax_description_16", "_post_tax_description_16", "")]
    [MapInfo("total_post_tax_value_17", "_total_post_tax_value_17", "")]
    [System.Serializable()]

    public class InvoiceInterfaceDetail : Entity<InvoiceInterfaceDetail>
    {
        #region Business Methods
        [DBField()]
        private string _invoice_no_1;

        [DBField()]
        private string _ownerdriver_name_2;

        [DBField()]
        private string _address_3;

        [DBField()]
        private string _gst_number_4;

        [DBField()]
        private string _message_5;

        [DBField()]
        private int? _basic_pay_6;

        [DBField()]
        private int? _allowance_7;

        [DBField()]
        private int? _pre_tax_adj_8;

        [DBField()]
        private int? _courier_post_vol_9;

        [DBField()]
        private decimal? _courier_post_value_10;

        [DBField()]
        private int? _adpost_vol_11;

        [DBField()]
        private int? _adpost_value_12;

        [DBField()]
        private int? _gross_pay13;

        [DBField()]
        private int? _gst_14;

        [DBField()]
        private int? _tax_15;

        [DBField()]
        private string _post_tax_description_16;

        [DBField()]
        private int? _total_post_tax_value_17;

        public virtual string InvoiceNo1
        {
            get
            {
                CanReadProperty("InvoiceNo1",true);
                return _invoice_no_1;
            }
            set
            {
                CanWriteProperty("InvoiceNo1",true);
                if (_invoice_no_1 != value)
                {
                    _invoice_no_1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string OwnerdriverName2
        {
            get
            {
                CanReadProperty("OwnerdriverName2",true);
                return _ownerdriver_name_2;
            }
            set
            {
                CanWriteProperty("OwnerdriverName2",true);
                if (_ownerdriver_name_2 != value)
                {
                    _ownerdriver_name_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Address3
        {
            get
            {
                CanReadProperty("Address3",true);
                return _address_3;
            }
            set
            {
                CanWriteProperty("Address3",true);
                if (_address_3 != value)
                {
                    _address_3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string GstNumber4
        {
            get
            {
                CanReadProperty("GstNumber4",true);
                return _gst_number_4;
            }
            set
            {
                CanWriteProperty("GstNumber4",true);
                if (_gst_number_4 != value)
                {
                    _gst_number_4 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Message5
        {
            get
            {
                CanReadProperty("Message5",true);
                return _message_5;
            }
            set
            {
                CanWriteProperty("Message5",true);
                if (_message_5 != value)
                {
                    _message_5 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? BasicPay6
        {
            get
            {
                CanReadProperty("BasicPay6",true);
                return _basic_pay_6;
            }
            set
            {
                CanWriteProperty("BasicPay6",true);
                if (_basic_pay_6 != value)
                {
                    _basic_pay_6 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Allowance7
        {
            get
            {
                CanReadProperty("Allowance7",true);
                return _allowance_7;
            }
            set
            {
                CanWriteProperty("Allowance7",true);
                if (_allowance_7 != value)
                {
                    _allowance_7 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? PreTaxAdj8
        {
            get
            {
                CanReadProperty("PreTaxAdj8",true);
                return _pre_tax_adj_8;
            }
            set
            {
                CanWriteProperty("PreTaxAdj8",true);
                if (_pre_tax_adj_8 != value)
                {
                    _pre_tax_adj_8 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CourierPostVol9
        {
            get
            {
                CanReadProperty("CourierPostVol9",true);
                return _courier_post_vol_9;
            }
            set
            {
                CanWriteProperty("CourierPostVol9",true);
                if (_courier_post_vol_9 != value)
                {
                    _courier_post_vol_9 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? CourierPostValue10
        {
            get
            {
                CanReadProperty("CourierPostValue10",true);
                return _courier_post_value_10;
            }
            set
            {
                CanWriteProperty("CourierPostValue10",true);
                if (_courier_post_value_10 != value)
                {
                    _courier_post_value_10 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AdpostVol11
        {
            get
            {
                CanReadProperty("AdpostVol11",true);
                return _adpost_vol_11;
            }
            set
            {
                CanWriteProperty("AdpostVol11",true);
                if (_adpost_vol_11 != value)
                {
                    _adpost_vol_11 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AdpostValue12
        {
            get
            {
                CanReadProperty("AdpostValue12",true);
                return _adpost_value_12;
            }
            set
            {
                CanWriteProperty("AdpostValue12",true);
                if (_adpost_value_12 != value)
                {
                    _adpost_value_12 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? GrossPay13
        {
            get
            {
                CanReadProperty("GrossPay13",true);
                return _gross_pay13;
            }
            set
            {
                CanWriteProperty("GrossPay13",true);
                if (_gross_pay13 != value)
                {
                    _gross_pay13 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Gst14
        {
            get
            {
                CanReadProperty("Gst14",true);
                return _gst_14;
            }
            set
            {
                CanWriteProperty("Gst14",true);
                if (_gst_14 != value)
                {
                    _gst_14 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Tax15
        {
            get
            {
                CanReadProperty("Tax15",true);
                return _tax_15;
            }
            set
            {
                CanWriteProperty("Tax15",true);
                if (_tax_15 != value)
                {
                    _tax_15 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PostTaxDescription16
        {
            get
            {
                CanReadProperty("PostTaxDescription16",true);
                return _post_tax_description_16;
            }
            set
            {
                CanWriteProperty("PostTaxDescription16",true);
                if (_post_tax_description_16 != value)
                {
                    _post_tax_description_16 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? TotalPostTaxValue17
        {
            get
            {
                CanReadProperty("TotalPostTaxValue17",true);
                return _total_post_tax_value_17;
            }
            set
            {
                CanWriteProperty("TotalPostTaxValue17",true);
                if (_total_post_tax_value_17 != value)
                {
                    _total_post_tax_value_17 = value;
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
        public static InvoiceInterfaceDetail NewInvoiceInterfaceDetail(DateTime? inStartDate, DateTime? inEndDate)
        {
            return Create(inStartDate, inEndDate);
        }

        public static InvoiceInterfaceDetail[] GetAllInvoiceInterfaceDetail(DateTime? inStartDate, DateTime? inEndDate)
        {
            return Fetch(inStartDate, inEndDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? inStartDate, DateTime? inEndDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoicemailing_interface_detail";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inStartDate", inStartDate);
                    pList.Add(cm, "inEndDate", inEndDate);

                    List<InvoiceInterfaceDetail> _list = new List<InvoiceInterfaceDetail>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceInterfaceDetail instance = new InvoiceInterfaceDetail();
                            instance.InvoiceNo1 = GetValueFromReader<string>(dr,0);
                            instance.OwnerdriverName2 = GetValueFromReader<string>(dr,1);
                            instance.Address3 = GetValueFromReader<string>(dr,2);
                            instance.GstNumber4 = GetValueFromReader<string>(dr,3);
                            instance.Message5 = GetValueFromReader<string>(dr,4);
                            instance.BasicPay6 = GetValueFromReader<Int32?>(dr,5);
                            instance.Allowance7 = GetValueFromReader<Int32?>(dr,6);
                            instance.PreTaxAdj8 = GetValueFromReader<Int32?>(dr,7);
                            instance.CourierPostVol9 = GetValueFromReader<Int32?>(dr,8);
                            instance.CourierPostValue10 = GetValueFromReader<decimal?>(dr,9);
                            instance.AdpostVol11 = GetValueFromReader<Int32?>(dr,10);
                            instance.AdpostValue12 = GetValueFromReader<Int32?>(dr,11);
                            instance.GrossPay13 = GetValueFromReader<Int32?>(dr,12);
                            instance.Gst14 = GetValueFromReader<Int32?>(dr,13);
                            instance.Tax15 = GetValueFromReader<Int32?>(dr,14);
                            instance.PostTaxDescription16 = GetValueFromReader<string>(dr,15);
                            instance.TotalPostTaxValue17 = GetValueFromReader<Int32?>(dr,16);
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

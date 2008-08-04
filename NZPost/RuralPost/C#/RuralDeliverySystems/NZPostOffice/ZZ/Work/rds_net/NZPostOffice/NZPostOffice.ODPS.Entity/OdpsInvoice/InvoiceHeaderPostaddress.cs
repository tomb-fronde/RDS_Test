//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsInvoice
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("nat_rural_post_address", "_nat_rural_post_address", "national")]
    [MapInfo("nat_rural_post_gst_no", "_nat_rural_post_gst_no", "national")]
    [System.Serializable()]

    public class InvoiceHeaderPostaddress : Entity<InvoiceHeaderPostaddress>
    {
        #region Business Methods
        [DBField()]
        private string _nat_rural_post_address;

        [DBField()]
        private string _nat_rural_post_gst_no;

        public virtual string NatRuralPostAddress
        {
            get
            {
                CanReadProperty("NatRuralPostAddress",true);
                return _nat_rural_post_address;
            }
            set
            {
                CanWriteProperty("NatRuralPostAddress",true);
                if (_nat_rural_post_address != value)
                {
                    _nat_rural_post_address = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string NatRuralPostGstNo
        {
            get
            {
                CanReadProperty("NatRuralPostGstNo",true);
                return _nat_rural_post_gst_no;
            }
            set
            {
                CanWriteProperty("NatRuralPostGstNo",true);
                if (_nat_rural_post_gst_no != value)
                {
                    _nat_rural_post_gst_no = value;
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
        public static InvoiceHeaderPostaddress NewInvoiceHeaderPostaddress(DateTime? enddate)
        {
            return Create(enddate);
        }

        public static InvoiceHeaderPostaddress[] GetAllInvoiceHeaderPostaddress(DateTime? enddate)
        {
            return Fetch(enddate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? enddate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "enddate", enddate);
                    //GenerateSelectCommandText(cm, "[national]");
                    cm.CommandText = "SELECT  nat_rural_post_address ,"
                                   + "nat_rural_post_gst_no  FROM odps.[national]  "
                                   + "WHERE (nat_id = odps.od_blf_getwhichnational(:enddate) ) ";
                    List<InvoiceHeaderPostaddress> _list = new List<InvoiceHeaderPostaddress>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceHeaderPostaddress instance = new InvoiceHeaderPostaddress();
                            //instance.StoreFieldValues(dr, "national");
                            instance._nat_rural_post_address = GetValueFromReader<string>(dr,0);
                            instance._nat_rural_post_gst_no = GetValueFromReader<string>(dr,1);
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

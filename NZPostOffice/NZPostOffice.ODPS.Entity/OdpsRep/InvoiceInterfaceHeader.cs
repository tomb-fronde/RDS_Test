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
    [MapInfo("procdate", "_procdate", "")]
    [MapInfo("nat_rural_post_gst_no", "_nat_rural_post_gst_no", "")]
    [System.Serializable()]

    public class InvoiceInterfaceHeader : Entity<InvoiceInterfaceHeader>
    {
        #region Business Methods
        [DBField()]
        private DateTime? _procdate;

        [DBField()]
        private string _nat_rural_post_gst_no;

        public virtual DateTime? Procdate
        {
            get
            {
                CanReadProperty("Procdate",true);
                return _procdate;
            }
            set
            {
                CanWriteProperty("Procdate",true);
                if (_procdate != value)
                {
                    _procdate = value;
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
        public static InvoiceInterfaceHeader NewInvoiceInterfaceHeader(DateTime? Procdate)
        {
            return Create(Procdate);
        }

        public static InvoiceInterfaceHeader[] GetAllInvoiceInterfaceHeader(DateTime? Procdate)
        {
            return Fetch(Procdate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? Procdate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoicemailing_interface_header";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "Procdate", Procdate);

                    List<InvoiceInterfaceHeader> _list = new List<InvoiceInterfaceHeader>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceInterfaceHeader instance = new InvoiceInterfaceHeader();
                            instance.Procdate = GetValueFromReader<DateTime?>(dr,0);
                            instance.NatRuralPostGstNo = GetValueFromReader<string>(dr,1);
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

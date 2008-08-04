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
    [MapInfo("out_message", "_out_message", "")]
    [System.Serializable()]

    public class InvoiceDetailPaymentPrMessage : Entity<InvoiceDetailPaymentPrMessage>
    {
        #region Business Methods
        [DBField()]
        private string _out_message;

        public virtual string OutMessage
        {
            get
            {
                CanReadProperty("OutMessage",true);
                return _out_message;
            }
            set
            {
                CanWriteProperty("OutMessage",true);
                if (_out_message != value)
                {
                    _out_message = value;
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
        public static InvoiceDetailPaymentPrMessage NewInvoiceDetailPaymentPrMessage(string in_message)
        {
            return Create(in_message);
        }

        public static InvoiceDetailPaymentPrMessage[] GetAllInvoiceDetailPaymentPrMessage(string in_message)
        {
            return Fetch(in_message).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string in_message)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_invoice_message";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "in_message", in_message);

                    List<InvoiceDetailPaymentPrMessage> _list = new List<InvoiceDetailPaymentPrMessage>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            InvoiceDetailPaymentPrMessage instance = new InvoiceDetailPaymentPrMessage();
                            instance.OutMessage = GetValueFromReader<string>(dr, 0);
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

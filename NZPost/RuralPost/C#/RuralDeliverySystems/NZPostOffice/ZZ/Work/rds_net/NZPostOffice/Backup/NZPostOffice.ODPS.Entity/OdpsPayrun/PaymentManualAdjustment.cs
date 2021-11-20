//qtdong
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsPayrun
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("ded_id", "_ded_id", "t_posttax_deductions_not_applied")]
    [MapInfo("comments", "_comments", "t_posttax_deductions_not_applied")]
    [MapInfo("name", "_cname", "t_posttax_deductions_not_applied")]
    [System.Serializable()]

    public class PaymentManualAdjustment : Entity<PaymentManualAdjustment>
    {

        #region Business Methods
        [DBField()]
        private int? _ded_id;

        [DBField()]
        private string _comments;

        [DBField()]
        private string _cname;

        public virtual int? DedId
        {
            get
            {
                CanReadProperty("DedId", true);
                return _ded_id;
            }
            set
            {
                CanWriteProperty("DedId", true);
                if (_ded_id != value)
                {
                    _ded_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Comments
        {
            get
            {
                CanReadProperty("Comments", true);
                return _comments;
            }
            set
            {
                CanWriteProperty("Comments", true);
                if (_comments != value)
                {
                    _comments = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Cname
        {
            get
            {
                CanReadProperty("Cname", true);
                return _cname;
            }
            set
            {
                CanWriteProperty("Cname", true);
                if (_cname != value)
                {
                    _cname = value;
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
        public static PaymentManualAdjustment NewPaymentManualAdjustment()
        {
            return Create();
        }

        public static PaymentManualAdjustment[] GetAllPaymentManualAdjustment()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = " SELECT t_posttax_deductions_not_applied.ded_id," +
                                     "t_posttax_deductions_not_applied.comments," +
                                     "c_surname_company+isnull(c_first_names,'') name " +
                                     "FROM odps.t_posttax_deductions_not_applied," +
                                     "rd.contractor " +
                                     "WHERE ( odps.t_posttax_deductions_not_applied.contractor_supplier_no = rd.contractor.contractor_supplier_no )";
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "t_posttax_deductions_not_applied");
                    //GenerateSelectCommandText(cm, "rd.contractor");

                    List<PaymentManualAdjustment> _list = new List<PaymentManualAdjustment>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            PaymentManualAdjustment instance = new PaymentManualAdjustment();
                            instance._ded_id = GetValueFromReader<Int32?>(dr, 0);
                            instance._comments = GetValueFromReader<string>(dr, 1);
                            instance._cname = GetValueFromReader<string>(dr, 2);
                            //instance.StoreFieldValues(dr, "t_posttax_deductions_not_applied");
                            //instance.StoreFieldValues(dr, "rd.contractor");
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("region_id", "_region_id", "")]
    [MapInfo("contract_no", "_contract_no", "")]
    [MapInfo("con_title", "_con_title", "")]
    [MapInfo("con_last_service_review_1", "_con_last_service_review_1", "")]
    [MapInfo("con_last_service_review_2", "_con_last_service_review_2", "")]
    [MapInfo("con_last_delivery_check_1", "_con_last_delivery_check_1", "")]
    [MapInfo("con_last_delivery_check_2", "_con_last_delivery_check_2", "")]
    [MapInfo("con_last_work_msr_1", "_con_last_work_msr_1", "")]
    [MapInfo("con_last_work_msr_2", "_con_last_work_msr_2", "")]
    [MapInfo("con_old_mail_service_no", "_con_old_mail_service_no", "")]
    [MapInfo("ct_key", "_ct_key", "")]
    [System.Serializable()]

    public class ContractSearch : Entity<ContractSearch>
    {
        #region Business Methods
        [DBField()]
        private int? _region_id;

        [DBField()]
        private int? _contract_no;

        [DBField()]
        private string _con_title;

        [DBField()]
        private DateTime? _con_last_service_review_1;

        [DBField()]
        private DateTime? _con_last_service_review_2;

        [DBField()]
        private DateTime? _con_last_delivery_check_1;

        [DBField()]
        private DateTime? _con_last_delivery_check_2;

        [DBField()]
        private DateTime? _con_last_work_msr_1;

        [DBField()]
        private DateTime? _con_last_work_msr_2;

        [DBField()]
        private string _con_old_mail_service_no;

        [DBField()]
        private int? _ct_key;

        public virtual int? RegionId
        {
            get
            {
                CanReadProperty("RegionId", true);
                return _region_id;
            }
            set
            {
                CanWriteProperty("RegionId", true);
                if (_region_id != value)
                {
                    _region_id = value;
                    PropertyHasChanged();
                }
            }
        }

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

        public virtual DateTime? ConLastServiceReview1
        {
            get
            {
                CanReadProperty("ConLastServiceReview1", true);
                if (_con_last_service_review_1.GetValueOrDefault().ToShortDateString() == "01/01/0001")
                {
                    _con_last_service_review_1 = null;
                }
                return _con_last_service_review_1;
            }
            set
            {
                CanWriteProperty("ConLastServiceReview1", true);
                if (_con_last_service_review_1 != value)
                {
                    _con_last_service_review_1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastServiceReview2
        {
            get
            {
                CanReadProperty("ConLastServiceReview2", true);
                if (_con_last_service_review_2.GetValueOrDefault().ToShortDateString() == "01/01/0001")
                {
                    _con_last_service_review_2 = null;
                }
                return _con_last_service_review_2;
            }
            set
            {
                CanWriteProperty("ConLastServiceReview2", true);
                if (_con_last_service_review_2 != value)
                {
                    _con_last_service_review_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastDeliveryCheck1
        {
            get
            {
                CanReadProperty("ConLastDeliveryCheck1", true);
                if (_con_last_delivery_check_1.GetValueOrDefault().ToShortDateString() == "01/01/0001")
                {
                    _con_last_delivery_check_1 = null;
                }
                return _con_last_delivery_check_1;
            }
            set
            {
                CanWriteProperty("ConLastDeliveryCheck1", true);
                if (_con_last_delivery_check_1 != value)
                {
                    _con_last_delivery_check_1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastDeliveryCheck2
        {
            get
            {
                CanReadProperty("ConLastDeliveryCheck2", true);
                if (_con_last_delivery_check_2.GetValueOrDefault().ToShortDateString() == "01/01/0001")
                {
                    _con_last_delivery_check_2 = null;
                }
                return _con_last_delivery_check_2;
            }
            set
            {
                CanWriteProperty("ConLastDeliveryCheck2", true);
                if (_con_last_delivery_check_2 != value)
                {
                    _con_last_delivery_check_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastWorkMsr1
        {
            get
            {
                CanReadProperty("ConLastWorkMsr1", true);
                if (_con_last_work_msr_1.GetValueOrDefault().ToShortDateString() == "01/01/0001")
                {
                    _con_last_work_msr_1 = null;
                }
                return _con_last_work_msr_1;
            }
            set
            {
                CanWriteProperty("ConLastWorkMsr1", true);
                if (_con_last_work_msr_1 != value)
                {
                    _con_last_work_msr_1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? ConLastWorkMsr2
        {
            get
            {
                CanReadProperty("ConLastWorkMsr2", true);
                if (_con_last_work_msr_2.GetValueOrDefault().ToShortDateString() == "01/01/0001")
                {
                    _con_last_work_msr_2 = null;
                }
                return _con_last_work_msr_2;
            }
            set
            {
                CanWriteProperty("ConLastWorkMsr2", true);
                if (_con_last_work_msr_2 != value)
                {
                    _con_last_work_msr_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ConOldMailServiceNo
        {
            get
            {
                CanReadProperty("ConOldMailServiceNo", true);
                return _con_old_mail_service_no;
            }
            set
            {
                CanWriteProperty("ConOldMailServiceNo", true);
                if (_con_old_mail_service_no != value)
                {
                    _con_old_mail_service_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CtKey
        {
            get
            {
                CanReadProperty("CtKey", true);
                return _ct_key;
            }
            set
            {
                CanWriteProperty("CtKey", true);
                if (_ct_key != value)
                {
                    _ct_key = value;
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
        public static ContractSearch NewContractSearch()
        {
            return Create();
        }

        public static ContractSearch[] GetAllContractSearch()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( "NZPO"))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<ContractSearch> _list = new List<ContractSearch>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    ContractSearch instance = new ContractSearch();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}

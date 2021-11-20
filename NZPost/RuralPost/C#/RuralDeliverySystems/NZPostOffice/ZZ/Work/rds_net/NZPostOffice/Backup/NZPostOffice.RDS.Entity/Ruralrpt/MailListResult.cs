using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruralrpt
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("cust_id", "_customer_id", "")]
    [MapInfo("title", "_title", "")]
    [MapInfo("initials", "_initials", "")]
    [MapInfo("last_name", "_last_company_name", "")]
    [MapInfo("adr_no", "_road_no", "")]
    [MapInfo("road_name", "_road_name", "")]
    [MapInfo("locality", "_locality", "")]
    [MapInfo("rd_no", "_rd_no", "")]
    [MapInfo("mail_town", "_town_postcode", "")]
    [MapInfo("Post_Town", "_post_town", "")]
    [MapInfo("Postcode", "_postcode", "")]
    [MapInfo("dp_id", "_dp_id", "")]
    [System.Serializable()]

    public class MailListResult : Entity<MailListResult>
    {
        #region Business Methods
        [DBField()]
        private int? _customer_id;

        [DBField()]
        private string _title;

        [DBField()]
        private string _initials;

        [DBField()]
        private string _last_company_name;

        [DBField()]
        private string _road_no;

        [DBField()]
        private string _road_name;

        [DBField()]
        private string _locality;

        [DBField()]
        private string _rd_no;

        [DBField()]
        private string _town_postcode;

        [DBField()]
        private string _post_town;

        [DBField()]
        private string _postcode;

        [DBField()]
        private long _dp_id;


        public virtual int? CustomerId
        {
            get
            {
                CanReadProperty("CustomerId", true);
                return _customer_id;
            }
            set
            {
                CanWriteProperty("CustomerId", true);
                if (_customer_id != value)
                {
                    _customer_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Title
        {
            get
            {
                CanReadProperty("Title", true);
                return _title;
            }
            set
            {
                CanWriteProperty("Title", true);
                if (_title != value)
                {
                    _title = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Initials
        {
            get
            {
                CanReadProperty("Initials", true);
                return _initials;
            }
            set
            {
                CanWriteProperty("Initials", true);
                if (_initials != value)
                {
                    _initials = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string LastCompanyName
        {
            get
            {
                CanReadProperty("LastCompanyName", true);
                return _last_company_name;
            }
            set
            {
                CanWriteProperty("LastCompanyName", true);
                if (_last_company_name != value)
                {
                    _last_company_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RoadNo
        {
            get
            {
                CanReadProperty("RoadNo", true);
                return _road_no;
            }
            set
            {
                CanWriteProperty("RoadNo", true);
                if (_road_no != value)
                {
                    _road_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RoadName
        {
            get
            {
                CanReadProperty("RoadName", true);
                return _road_name;
            }
            set
            {
                CanWriteProperty("RoadName", true);
                if (_road_name != value)
                {
                    _road_name = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Locality
        {
            get
            {
                CanReadProperty("Locality", true);
                return _locality;
            }
            set
            {
                CanWriteProperty("Locality", true);
                if (_locality != value)
                {
                    _locality = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdNo
        {
            get
            {
                CanReadProperty("RdNo", true);
                return _rd_no;
            }
            set
            {
                CanWriteProperty("RdNo", true);
                if (_rd_no != value)
                {
                    _rd_no = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string TownPostcode
        {
            get
            {
                CanReadProperty("TownPostcode", true);
                return _town_postcode;
            }
            set
            {
                CanWriteProperty("TownPostcode", true);
                if (_town_postcode != value)
                {
                    _town_postcode = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PostTown
        {
            get
            {
                CanReadProperty("PostTown", true);
                return _post_town;
            }
            set
            {
                CanWriteProperty("PostTown", true);
                if (_post_town != value)
                {
                    _post_town = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Postcode
        {
            get
            {
                CanReadProperty("Postcode", true);
                return _postcode;
            }
            set
            {
                CanWriteProperty("Postcode", true);
                if (_postcode != value)
                {
                    _postcode = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual long DpId
        {
            get
            {
                CanReadProperty("DpId", true);
                return _dp_id;
            }
            set
            {
                CanWriteProperty("DpId", true);
                if (_dp_id != value)
                {
                    _dp_id = value;
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
        public static MailListResult NewMailListResult(string inPost, string inOcc, string inInterest, DateTime? inDate1, DateTime? inDate2,int? ll_or )
        {
            return Create(inPost, inOcc, inInterest, inDate1, inDate2,ll_or);
        }

        public static MailListResult[] GetAllMailListResult(string inPost, string inOcc, string inInterest, DateTime? inDate1, DateTime? inDate2,int? ll_or )
        {
            return Fetch(inPost, inOcc, inInterest, inDate1, inDate2,ll_or).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(string inPost, string inOcc, string inInterest, DateTime? inDate1, DateTime? inDate2,int? ll_or)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_cust_list_variable";
                    cm.CommandTimeout = 600;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inPost", inPost);
                    pList.Add(cm, "inOcc", inOcc);
                    pList.Add(cm, "inInterest", inInterest);
                    pList.Add(cm, "inDate1", inDate1);
                    pList.Add(cm, "inDate2", inDate2);
                    pList.Add(cm, "in_orFlag", ll_or);

                    List<MailListResult> _list = new List<MailListResult>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            MailListResult instance = new MailListResult();
                            instance._customer_id = GetValueFromReader<int?>(dr, 0);
                            instance._title = GetValueFromReader<string>(dr, 1);
                            instance._initials = GetValueFromReader<string>(dr, 2);
                            instance._last_company_name = GetValueFromReader<string>(dr, 3);
                            instance._road_no = GetValueFromReader<string>(dr, 4);
                            instance._road_name = GetValueFromReader<string>(dr, 5);
                            instance._locality = GetValueFromReader<string>(dr, 6);
                            instance._rd_no = GetValueFromReader<string>(dr, 7);
                            instance._town_postcode = GetValueFromReader<string>(dr, 8);
                            instance._post_town = GetValueFromReader<string>(dr, 9);
                            instance._postcode = GetValueFromReader<string>(dr, 10);
                            if (dr.GetValue(11) != null && dr.GetValue(11) != DBNull.Value)
                            {
                                instance._dp_id = Convert.ToInt64(dr.GetValue(11));
                            }
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

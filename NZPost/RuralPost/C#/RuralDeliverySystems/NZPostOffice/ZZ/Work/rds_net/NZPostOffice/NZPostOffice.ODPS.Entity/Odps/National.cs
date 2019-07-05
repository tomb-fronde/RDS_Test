using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.Odps
{
    // This gets the data for the 'National' tab in odps.WCodeTableMaintenance
    //
    // TJB  RPCR_129 July-2019
    // Reformatted fetch query and sorted with newest first

    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("nat_id", "_nat_id", "odps.national")]
    [MapInfo("ac_id", "_ac_id", "odps.national")]
    [MapInfo("nat_effective_date", "_nat_effective_date", "odps.national")]
    [MapInfo("nat_ird_no", "_nat_ird_no", "odps.national")]
    [System.Serializable()]

    public class National : Entity<National>
    {
        #region Business Methods
        [DBField()]
        private int? _nat_id;

        [DBField()]
        private int? _ac_id;

        [DBField()]
        private DateTime? _nat_effective_date;

        [DBField()]
        private string _nat_ird_no;

        public virtual int? NatId
        {
            get
            {
                CanReadProperty("NatId", true);
                return _nat_id;
            }
            set
            {
                CanWriteProperty("NatId", true);
                if (_nat_id != value)
                {
                    _nat_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? RENatId
        {
            get
            {
                return (int)_nat_id;
            }
        }

        public virtual int? AcId
        {
            get
            {
                CanReadProperty("AcId", true);
                return _ac_id;
            }
            set
            {
                CanWriteProperty("AcId", true);
                if (_ac_id != value)
                {
                    _ac_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public int? REAcId
        {
            get
            {
                return (int)_ac_id;
            }
        }

        public virtual DateTime? NatEffectiveDate
        {
            get
            {
                CanReadProperty("NatEffectiveDate", true);
                return _nat_effective_date;
            }
            set
            {
                CanWriteProperty("NatEffectiveDate", true);
                if (_nat_effective_date != value)
                {
                    _nat_effective_date = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime? RENatEffectiveDate
        {
            get
            {
                return (DateTime)_nat_effective_date;
            }
        }

        public virtual string NatIrdNo
        {
            get
            {
                CanReadProperty("NatIrdNo", true);
                return _nat_ird_no;
            }
            set
            {
                CanWriteProperty("NatIrdNo", true);
                if (_nat_ird_no != value)
                {
                    _nat_ird_no = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}", _nat_id);
        }

        #endregion

        #region Factory Methods
        public static National NewNational()
        {
            return Create();
        }

        public static National[] GetAllNational()
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
                    ParameterCollection pList = new ParameterCollection();
                    //GenerateSelectCommandText(cm, "odps.national");
                    cm.CommandText = "SELECT nat_id"
                                   + "     , ac_id"
                                   + "     , nat_ird_no"
                                   + "     , nat_effective_date " 
                                   + "  FROM odps.[national]"
                                   + " ORDER BY nat_id desc";

                    List<National> _list = new List<National>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            National instance = new National();
                            instance._nat_id = GetValueFromReader<Int32?>(dr, 0); ;
                            instance._ac_id = GetValueFromReader<Int32?>(dr, 1);
                            instance._nat_ird_no = GetValueFromReader<string>(dr, 2);
                            instance._nat_effective_date = GetValueFromReader<DateTime?>(dr, 3);
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

        [ServerMethod()]
        private void UpdateEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateUpdateCommandText(cm, "national", ref pList))
                {
                    cm.CommandText += " WHERE  national.nat_id = @nat_id ";
                    pList.Add(cm, "nat_id", GetInitialValue("_nat_id"));
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                // reinitialize original key/value list
                StoreInitialValues();
            }
        }

        [ServerMethod()]
        private void InsertEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();
                if (GenerateInsertCommandText(cm, "national", pList))
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                        this.sqlCode = -1;
                        this.sqlErrText = ex.Message.ToString();
                    }
                }
                StoreInitialValues();
            }
        }

        [ServerMethod()]
        private void DeleteEntity()
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "nat_id", GetInitialValue("_nat_id"));
                    cm.CommandText = "DELETE FROM national WHERE national.nat_id = @nat_id ";
                    DBHelper.ExecuteNonQuery(cm, pList);
                    tr.Commit();
                }
            }
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? nat_id)
        {
            _nat_id = nat_id;
        }
    }
}

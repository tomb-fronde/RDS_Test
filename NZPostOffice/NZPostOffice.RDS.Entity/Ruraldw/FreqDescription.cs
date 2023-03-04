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
    [MapInfo("sf_key", "_sf_key", "route_description")]
    [MapInfo("contract_no", "_contract_no", "route_description")]
    [MapInfo("rd_sequence", "_rd_sequence", "route_description")]
    [MapInfo("rf_delivery_days", "_rf_delivery_days", "route_description")]
    [MapInfo("rd_description_of_point", "_rd_description_of_point", "route_description")]
    [MapInfo("rd_time_at_point", "_rd_time_at_point", "route_description")]
    [MapInfo("rfv_id", "_rfv_id", "route_description")]
    // [MapInfo("rfpd_id", "_test", "route_description")]
    [MapInfo("rfpd_id", "_rfpd_id", "route_description")]
    [MapInfo("point_type", "_point_type", "")]
    [MapInfo("rf_distance_of_leg", "_rf_distance_of_leg", "route_description")]
    [MapInfo("rf_running_total", "_rf_running_total", "route_description")]
    [MapInfo("rfv_id_2", "_rfv_id_2", "route_description")]
    [MapInfo("cust_id", "_cust_id", "route_description")]
    [MapInfo("question_down", "_question_down", "")]
    [MapInfo("show_question", "_show_question", "")]
    [MapInfo("adr_id", "_adr_id", "route_description")]    

    [System.Serializable()]

    public class FreqDescription : Entity<FreqDescription>
    {
        #region Business Methods
        [DBField()]
        private int? _sf_key=1;

        [DBField()]
        private int? _contract_no=5000;

        [DBField()]
        private int? _rd_sequence;

        [DBField()]
        private string _rf_delivery_days="YYYYYYN";

        [DBField()]
        private string _rd_description_of_point;

        [DBField()]
        private DateTime? _rd_time_at_point;

        [DBField()]
        private int? _rfv_id;

        // [DBField()]
        // private int? _test;

        [DBField()]
        private int? _rfpd_id;

        [DBField()]
        private string _point_type;

        [DBField()]
        private Decimal? _rf_distance_of_leg;

        [DBField()]
        private Decimal? _rf_running_total=0;

        [DBField()]
        private int? _rfv_id_2;

        [DBField()]
        private int? _cust_id;

        [DBField()]
        private int? _question_down;

        [DBField()]
        private int? _show_question;

        [DBField()]
        private int? _adr_id;

        public virtual int? SfKey
        {
            get
            {
                CanReadProperty("SfKey", true);
                return _sf_key;
            }
            set
            {
                CanWriteProperty("SfKey", true);
                if (_sf_key != value)
                {
                    _sf_key = value;
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

        public virtual int? RDSequence
        {
            get
            {
                CanReadProperty("RDSequence", true);
                return _rd_sequence;
            }
            set
            {
                CanWriteProperty("RDSequence", true);
                if (_rd_sequence != value)
                {
                    _rd_sequence = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RfDeliveryDays
        {
            get
            {
                CanReadProperty("RfDeliveryDays", true);
                return _rf_delivery_days;
            }
            set
            {
                CanWriteProperty("RfDeliveryDays", true);
                if (_rf_delivery_days != value)
                {
                    _rf_delivery_days = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RdDescriptionOfPoint
        {
            get
            {
                CanReadProperty("RdDescriptionOfPoint", true);
                return _rd_description_of_point;
            }
            set
            {
                CanWriteProperty("RdDescriptionOfPoint", true);
                if (_rd_description_of_point != value)
                {
                    _rd_description_of_point = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime? RdTimeAtPoint
        {
            get
            {
                CanReadProperty("RdTimeAtPoint", true);
                return _rd_time_at_point;
            }
            set
            {
                CanWriteProperty("RdTimeAtPoint", true);
                if (_rd_time_at_point != value)
                {
                    _rd_time_at_point = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RfvId
        {
            get
            {
                CanReadProperty("RfvId", true);
                return _rfv_id;
            }
            set
            {
                CanWriteProperty("RfvId", true);
                if (_rfv_id != value)
                {
                    _rfv_id = value;
                    PropertyHasChanged();
                }
            }
        }
        // rfpd_id
        public virtual int? Test
        {
            get
            {
                CanReadProperty("Test", true);
                //return _test;
                return _rfpd_id;
            }
            set
            {
                CanWriteProperty("Test", true);
                //if (_test != value)
                //{
                //    _test = value;
                //    PropertyHasChanged();
                //}
                if (_rfpd_id != value)
                {
                    _rfpd_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Rfpdid
        {
            get
            {
                CanReadProperty("Rfpdid", true);
                return _rfpd_id;
            }
            set
            {
                CanWriteProperty("Rfpdid", true);
                if (_rfpd_id != value)
                {
                    _rfpd_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PointType
        {
            get
            {
                CanReadProperty("PointType", true);
                return _point_type;
            }
            set
            {
                CanWriteProperty("PointType", true);
                if (_point_type != value)
                {
                    _point_type = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? RfDistanceOfLeg
        {
            get
            {
                CanReadProperty("RfDistanceOfLeg", true);
                return _rf_distance_of_leg;
            }
            set
            {
                CanWriteProperty("RfDistanceOfLeg", true);
                if (_rf_distance_of_leg != value)
                {
                    _rf_distance_of_leg = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual Decimal? RfRunningTotal
        {
            get
            {
                CanReadProperty("RfRunningTotal", true);
                return _rf_running_total;
            }
            set
            {
                CanWriteProperty("RfRunningTotal", true);
                if (_rf_running_total != value)
                {
                    _rf_running_total = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? RfvId2
        {
            get
            {
                CanReadProperty("RfvId2", true);
                return _rfv_id_2;
            }
            set
            {
                CanWriteProperty("RfvId2", true);
                if (_rfv_id_2 != value)
                {
                    _rfv_id_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? CustId
        {
            get
            {
                CanReadProperty("CustId", true);
                return _cust_id;
            }
            set
            {
                CanWriteProperty("CustId", true);
                if (_cust_id != value)
                {
                    _cust_id = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? QuestionDown
        {
            get
            {
                CanReadProperty("QuestionDown", true);
                return _question_down;
            }
            set
            {
                CanWriteProperty("QuestionDown", true);
                if (_question_down != value)
                {
                    _question_down = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? ShowQuestion
        {
            get
            {
                CanReadProperty("ShowQuestion", true);
                return _show_question;
            }
            set
            {
                CanWriteProperty("ShowQuestion", true);
                if (_show_question != value)
                {
                    _show_question = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? AdrId
        {
            get
            {
                CanReadProperty("AdrId", true);
                return _adr_id;
            }
            set
            {
                CanWriteProperty("AdrId", true);
                if (_adr_id != value)
                {
                    _adr_id = value;
                    PropertyHasChanged();
                }
            }
        }      


        // needs to implement compute expression manually:
        // compute control name=[compute_1]
        //?getrow()

        protected override object GetIdValue()
        {
            return string.Format("{0}/{1}/{2}/{3}", _sf_key, _contract_no, _rd_sequence, _rf_delivery_days);
        }
        #endregion

        #region Factory Methods
        public static FreqDescription NewFreqDescription(int? inContract, int? inSFKey, string inDelDays)
        {
            return Create(inContract, inSFKey, inDelDays);
        }

        public static FreqDescription[] GetAllFreqDescription(int? inContract, int? inSFKey, string inDelDays)
        {
            return Fetch(inContract, inSFKey, inDelDays).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(int? inContract, int? inSFKey, string inDelDays)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "inContract", inContract);
                    pList.Add(cm, "inSFKey", inSFKey);
                    pList.Add(cm, "inDelDays", inDelDays);
                    cm.CommandText = "rd.sp_getroutedescription_2002";

                    List<FreqDescription> _list = new List<FreqDescription>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            FreqDescription instance = new FreqDescription();
                            instance._sf_key = GetValueFromReader<Int32?>(dr, 0);
                            instance._contract_no = GetValueFromReader<Int32?>(dr, 1);
                            instance._rd_sequence = GetValueFromReader<Int32?>(dr, 2);
                            instance._rf_delivery_days = GetValueFromReader<String>(dr, 3);
                            instance._rd_description_of_point = GetValueFromReader<String>(dr, 4);
                            instance._rd_time_at_point = GetValueFromReader<DateTime>(dr, 5);
                            instance._rfv_id = GetValueFromReader<Int32?>(dr, 6);
                            //instance._test = GetValueFromReader<Int32?>(dr, 7);
                            instance._rfpd_id = GetValueFromReader<Int32?>(dr, 7);
                            instance._point_type = GetValueFromReader<String>(dr, 8);
                            instance._rf_distance_of_leg = GetValueFromReader<Decimal?>(dr, 9);
                            instance._rf_running_total = GetValueFromReader<Decimal?>(dr, 10);
                            instance._rfv_id_2 = GetValueFromReader<Int32?>(dr, 11);
                            instance._cust_id = GetValueFromReader<Int32?>(dr, 12);
                            instance._question_down = GetValueFromReader<Int32?>(dr, 13);
                            instance._show_question = GetValueFromReader<Int32?>(dr, 14);
                            instance._adr_id = GetValueFromReader<Int32?>(dr, 15);
                            instance.MarkOld();
                            instance.StoreInitialValues();
                            _list.Add(instance);
                        }
                        list = _list.ToArray();
                    }
                }
            }
        }

        //pp! changed the way of Insert and Update - in PB this data window uses 'Delete and then Insert' - and the keys are changed also
        [ServerMethod()]
        private void UpdateEntity()
        {
            // TJB  RD7_0039  Sept2009:  Added
            // Code the UpdateEntity separately from InsertEntity
            // Updates now actually update rather than detele/insert if rd_sequence hasn't changed.

            // This is mostly for debugging ...
            int? sf_key_prev, contract_no_prev, rd_sequence_prev, i;
            int? rd_sequence_now;
            string rd_description_prev, rf_delivery_days_prev, s;
            string rd_description_now;

            sf_key_prev = (int?)GetInitialValue("_sf_key");
            contract_no_prev = (int?)GetInitialValue("_contract_no");
            rd_sequence_prev = (int?)GetInitialValue("_rd_sequence");
            rf_delivery_days_prev = (string)GetInitialValue("_rf_delivery_days");
            rd_description_prev = (string)GetInitialValue("_rd_description_of_point");
            i = sf_key_prev; i = contract_no_prev; i = rd_sequence_prev;
            s = rd_description_prev; s = rf_delivery_days_prev;
            rd_sequence_now = _rd_sequence;
            rd_description_now  = _rd_description_of_point;
            s = rd_description_now;  i = rd_sequence_now;
            //private void UpdateEntity()

            // If the sequence number hasn't changed we can do an update
            // If the sequence number has changed, we need to do a delete-insert
            if (rd_sequence_prev != null && rd_sequence_prev == _rd_sequence)
            {
                using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "UPDATE route_description"
                                     + " SET route_description.sf_key = @sf_key"
                                        + ", route_description.contract_no = @contract_no"
                                        + ", route_description.rd_sequence = @rd_sequence"
                                        + ", route_description.rf_delivery_days = @rf_delivery_days"
                                        + ", route_description.rd_description_of_point = @rd_description_of_point"
                                        + ", route_description.rd_time_at_point = @rd_time_at_point"
                                        + ", route_description.rfv_id = @rfv_id"
                                        + ", route_description.rfpd_id = @rfpd_id"
                                        + ", route_description.rf_distance_of_leg = @rf_distance_of_leg"
                                        + ", route_description.rf_running_total = @rf_running_total"
                                        + ", route_description.rfv_id_2 = @rfv_id_2"
                                        + ", route_description.cust_id = @cust_id"
                                        + ", route_description.adr_id = @adr_id"
                                        ;

                    cm.CommandText += " WHERE route_description.sf_key = @sf_key_prev"
                                     + "  and route_description.contract_no = @contract_no_prev"
                                     + "  and route_description.rd_sequence = @rd_sequence_prev"
                                     + "  and route_description.rf_delivery_days = @rf_delivery_days_prev"
                                     ;

                    pList.Add(cm, "sf_key_prev", sf_key_prev);
                    pList.Add(cm, "contract_no_prev", contract_no_prev);
                    pList.Add(cm, "rd_sequence_prev", rd_sequence_prev);
                    pList.Add(cm, "rf_delivery_days_prev", rf_delivery_days_prev);

                    pList.Add(cm, "sf_key", _sf_key);
                    pList.Add(cm, "contract_no", _contract_no);
                    pList.Add(cm, "rd_sequence", _rd_sequence);
                    pList.Add(cm, "rf_delivery_days", _rf_delivery_days);
                    pList.Add(cm, "rd_description_of_point", _rd_description_of_point);
                    pList.Add(cm, "rd_time_at_point", _rd_time_at_point);
                    pList.Add(cm, "rfv_id", _rfv_id);
                    pList.Add(cm, "rfpd_id", _rfpd_id);
                    pList.Add(cm, "rf_distance_of_leg", _rf_distance_of_leg);
                    pList.Add(cm, "rf_running_total", _rf_running_total);
                    pList.Add(cm, "rfv_id_2", _rfv_id_2);
                    pList.Add(cm, "cust_id", _cust_id);
                    pList.Add(cm, "adr_id", _adr_id);

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                    }
                    StoreInitialValues();
                }
            }
            else
            {
                InsertEntity();
            }
        }

        //pp! changed the way of Insert and Update 
        //    - in PB this data window uses 'Delete and then Insert' 
        //    - and the keys are changed also
        [ServerMethod()]
        private void InsertEntity()
        {
            // TJB  RD7_0039  Sept2009:  Added
            // Added the try ... catch around the ExecuteNonQuery's primarily for debugging,
            // but alse to catch errors where rows are deleted that don't actually exist.
            int? sf_key_prev, contract_no_prev, rd_sequence_prev, i;
            int? rd_sequence_now;
            string rd_description_prev, rf_delivery_days_prev, s;
            string rd_description_now;

            // This is mostly for debugging ...
            sf_key_prev = (int?)GetInitialValue("_sf_key");
            contract_no_prev = (int?)GetInitialValue("_contract_no");
            rd_sequence_prev = (int?)GetInitialValue("_rd_sequence");
            rf_delivery_days_prev = (string)GetInitialValue("_rf_delivery_days");
            rd_description_prev = (string)GetInitialValue("_rd_description_of_point");
            i = sf_key_prev; i = contract_no_prev; i = rd_sequence_prev;
            s = rd_description_prev; s = rf_delivery_days_prev;
            rd_sequence_now = _rd_sequence;
            rd_description_now = _rd_description_of_point;
            s = rd_description_now;  i = rd_sequence_now;
            //private void InsertEntity()

            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                DbCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.Text;
                ParameterCollection pList = new ParameterCollection();

                cm.CommandText += "Delete from route_description"
                                + " WHERE route_description.sf_key = @sf_key"
                                 + "  and  route_description.contract_no = @contract_no"
                                 + "  and route_description.rd_sequence = @rd_sequence"
                                 + "  and route_description.rf_delivery_days = @rf_delivery_days"
                                 ;

                pList.Add(cm, "sf_key", _sf_key);
                pList.Add(cm, "contract_no", _contract_no);
                pList.Add(cm, "rd_sequence", _rd_sequence);
                pList.Add(cm, "rf_delivery_days", _rf_delivery_days);

                try
                {
                    DBHelper.ExecuteNonQuery(cm, pList);
                }
                catch (Exception ex)
                {
                }
              
                //if (GenerateInsertCommandText(cm, "route_description", pList))
                bool GenerateInsertCommand = GenerateInsertCommandText(cm, "route_description", pList);
                if (GenerateInsertCommand)
                {
                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                StoreInitialValues();
            }
        }

        [ServerMethod()]
        private void DeleteEntity()
        {
            // TJB  RD7_0039  Sept2009:  Added
            // Disabled the delete functionality.
            // The datawindow Save procedure first did any updates then the deletes.
            // If the row deleted was 'in the middle', rows with higher sequence numbers
            // would effectively be 'moved up' over the deleted row, then the delete 
            // would remove the 'moved up' row (thus effectively removing both the row
            // that was intended to be deleted and the one after it).  Disabling this 
            // delete avoids deleting the second row.
            // This 'shift up' leaves dangling rows at the 'top' that are deleted by the
            // CleanupFDRows method (in NZPostOffice.RDS.DataControls) 
            int? sf_key_prev, contract_no_prev, rd_sequence_prev, i;
            int? rd_sequence_now;
            string rd_description_prev, rf_delivery_days_prev, s;
            string rd_description_now;

            // This is mostly for debugging ...
            sf_key_prev = (int?)GetInitialValue("_sf_key");
            contract_no_prev = (int?)GetInitialValue("_contract_no");
            rd_sequence_prev = (int?)GetInitialValue("_rd_sequence");
            rf_delivery_days_prev = (string)GetInitialValue("_rf_delivery_days");
            rd_description_prev = (string)GetInitialValue("_rd_description_of_point");
            i = sf_key_prev; i = contract_no_prev; i = rd_sequence_prev;
            s = rd_description_prev; s = rf_delivery_days_prev;
            rd_sequence_now = _rd_sequence;
            rd_description_now = _rd_description_of_point;
            s = rd_description_now; i = rd_sequence_now;
            //private void DeleteEntity()
/*
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {

                using (DbTransaction tr = cn.BeginTransaction())
                {
                    DbCommand cm = cn.CreateCommand();
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    ParameterCollection pList = new ParameterCollection();

                    cm.CommandText = "DELETE FROM route_description"
                                   + " WHERE route_description.sf_key = @sf_key"
                                     + " and route_description.contract_no = @contract_no"
                                     + " and route_description.rd_sequence = @rd_sequence "
                                     + " and route_description.rf_delivery_days = @rf_delivery_days ";

                    pList.Add(cm, "sf_key", GetInitialValue("_sf_key"));
                    pList.Add(cm, "contract_no", GetInitialValue("_contract_no"));
                    pList.Add(cm, "rd_sequence", GetInitialValue("_rd_sequence"));
                    pList.Add(cm, "rf_delivery_days", GetInitialValue("_rf_delivery_days"));

                    try
                    {
                        DBHelper.ExecuteNonQuery(cm, pList);
                        tr.Commit();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                    }
                }
            }
*/
        }
        #endregion

        [ServerMethod()]
        private void CreateEntity(int? sf_key, int? contract_no, int? rd_sequence, string rf_delivery_days)
        {
            _sf_key = sf_key;
            _contract_no = contract_no;
            _rd_sequence = rd_sequence;
            _rf_delivery_days = rf_delivery_days;
        }
    }
}

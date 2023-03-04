using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.ODPS.Entity.OdpsLib
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("null", "_null", "t_shell_import")]
    [MapInfo("compute_0002", "_compute_0002", "contract")]
    [MapInfo("compute_0003", "_compute_0003", "contract")]
    [MapInfo("compute_0004", "_compute_0004", "contract")]
    [MapInfo("compute_0005", "_compute_0005", "contract")]
    [MapInfo("compute_0006", "_compute_0006", "contract")]
    [MapInfo("null", "_null_1", "t_shell_import")]
    [MapInfo("null", "_null_2", "t_shell_import")]
    [MapInfo("null", "_null_3", "t_shell_import")]
    [MapInfo("compute_0010", "_compute_0010", "contract")]
    [MapInfo("null", "_null_4", "t_shell_import")]
    [MapInfo("null", "_null_5", "t_shell_import")]
    [MapInfo("compute_0013", "_compute_0013", "contract")]
    [MapInfo("compute_0014", "_compute_0014", "contract")]
    [MapInfo("compute_0015", "_compute_0015", "contract")]
    [MapInfo("contractor", "_contractor", "contract")]
    [MapInfo("compute_0017", "_compute_0017", "contract")]
    [System.Serializable()]

    public class ShellImportProcessed : Entity<ShellImportProcessed>
    {
        #region Business Methods
        [DBField()]
        private int? _null;

        [DBField()]
        private string _compute_0002;

        [DBField()]
        private int? _compute_0003;

        [DBField()]
        private int? _compute_0004;

        [DBField()]
        private string _compute_0005;

        [DBField()]
        private string _compute_0006;

        [DBField()]
        private int? _null_1;

        [DBField()]
        private int? _null_2;

        [DBField()]
        private int? _null_3;

        [DBField()]
        private decimal? _compute_0010;

        [DBField()]
        private int? _null_4;

        [DBField()]
        private int? _null_5;

        [DBField()]
        private decimal? _compute_0013;

        [DBField()]
        private decimal? _compute_0014;

        [DBField()]
        private decimal? _compute_0015;

        [DBField()]
        private int? _contractor;

        [DBField()]
        private int? _compute_0017;

        public virtual int? Null
        {
            get
            {
                CanReadProperty("Null",true);
                return _null;
            }
            set
            {
                CanWriteProperty("Null", true);
                if (_null != value)
                {
                    _null = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute0002
        {
            get
            {
                CanReadProperty("Compute0002",true);
                return _compute_0002;
            }
            set
            {
                CanWriteProperty("Compute0002",true);
                if (_compute_0002 != value)
                {
                    _compute_0002 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Compute0003
        {
            get
            {
                CanReadProperty("Compute0003",true);
                return _compute_0003;
            }
            set
            {
                CanWriteProperty("Compute0003",true);
                if (_compute_0003 != value)
                {
                    _compute_0003 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Compute0004
        {
            get
            {
                CanReadProperty("Compute0004",true);
                return _compute_0004;
            }
            set
            {
                CanWriteProperty("Compute0004",true);
                if (_compute_0004 != value)
                {
                    _compute_0004 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute0005
        {
            get
            {
                CanReadProperty("Compute0005",true);
                return _compute_0005;
            }
            set
            {
                CanWriteProperty("Compute0005",true);
                if (_compute_0005 != value)
                {
                    _compute_0005 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Compute0006
        {
            get
            {
                CanReadProperty("Compute0006",true);
                return _compute_0006;
            }
            set
            {
                CanWriteProperty("Compute0006",true);
                if (_compute_0006 != value)
                {
                    _compute_0006 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Null1
        {
            get
            {
                CanReadProperty("Null1",true);
                return _null_1;
            }
            set
            {
                CanWriteProperty("Null1",true);
                if (_null_1 != value)
                {
                    _null_1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Null2
        {
            get
            {
                CanReadProperty("Null2",true);
                return _null_2;
            }
            set
            {
                CanWriteProperty("Null2",true);
                if (_null_2 != value)
                {
                    _null_2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Null3
        {
            get
            {
                CanReadProperty("Null3",true);
                return _null_3;
            }
            set
            {
                CanWriteProperty("Null3",true);
                if (_null_3 != value)
                {
                    _null_3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0010
        {
            get
            {
                CanReadProperty("Compute0010", true);
                return _compute_0010;
            }
            set
            {
                CanWriteProperty("Compute0010",true);
                if (_compute_0010 != value)
                {
                    _compute_0010 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Null4
        {
            get
            {
                CanReadProperty("Null4",true);
                return _null_4;
            }
            set
            {
                CanWriteProperty("Null4",true);
                if (_null_4 != value)
                {
                    _null_4 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Null5
        {
            get
            {
                CanReadProperty("Null5",true);
                return _null_5;
            }
            set
            {
                CanWriteProperty("Null5",true);
                if (_null_5 != value)
                {
                    _null_5 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0013
        {
            get
            {
                CanReadProperty("Compute0013",true);
                return _compute_0013;
            }
            set
            {
                CanWriteProperty("Compute0013",true);
                if (_compute_0013 != value)
                {
                    _compute_0013 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0014
        {
            get
            {
                CanReadProperty("Compute0014",true);
                return _compute_0014;
            }
            set
            {
                CanWriteProperty("Compute0014",true);
                if (_compute_0014 != value)
                {
                    _compute_0014 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? Compute0015
        {
            get
            {
                CanReadProperty("Compute0015",true);
                return _compute_0015;
            }
            set
            {
                CanWriteProperty("Compute0015",true);
                if (_compute_0015 != value)
                {
                    _compute_0015 = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Contractor
        {
            get
            {
                CanReadProperty("Contractor",true);
                return _contractor;
            }
            set
            {
                CanWriteProperty("Contractor",true);
                if (_contractor != value)
                {
                    _contractor = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? Compute0017
        {
            get
            {
                CanReadProperty("Compute0017",true);
                return _compute_0017;
            }
            set
            {
                CanWriteProperty("Compute0017",true);
                if (_compute_0017 != value)
                {
                    _compute_0017 = value;
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
        public static ShellImportProcessed NewShellImportProcessed()
        {
            return Create();
        }

        public static ShellImportProcessed[] GetAllShellImportProcessed()
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
                    cm.CommandText = "SELECT null,  'Shell Deduction Month' + '' + str(Month(getdate()-30)),  1,  6,  'Shell Deductions imported on' + CONVERT(varchar, getdate(),111),  'M',  null,  null,  null,  sum(total_deduction),  null,  null,  sum(total_deduction),  sum(total_deduction),  sum(total_deduction),  ( SELECT rd.contractor_renewals.contractor_supplier_no  FROM rd.contract,  rd.contract_renewals,  rd.contractor_renewals  WHERE rd.contract_renewals.contract_no = rd.contract.contract_no and  rd.contract.con_active_sequence = rd.contract_renewals.contract_seq_number  and  rd.contractor_renewals.contract_no = rd.contract_renewals.contract_no  and  rd.contractor_renewals.contract_seq_number = rd.contract_renewals.contract_seq_number  and  rd.contractor_renewals.cr_effective_date =  (select max(cr_effective_date)  from   rd.contractor_renewals cr  where  cr.contract_no         = contract_renewals.contract_no  and    cr.contract_seq_number = contract_renewals.contract_seq_number  and    cr_effective_date      <= getdate() )  and contract.contract_no = t_shell_import.contract_no) as contractor,  0  from odps.t_shell_import  group by contract_no, contractor  ";
                    ParameterCollection pList = new ParameterCollection();

                    List<ShellImportProcessed> _list = new List<ShellImportProcessed>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            ShellImportProcessed instance = new ShellImportProcessed();
                            instance.Null = GetValueFromReader<Int32?>(dr,0);
                            instance.Compute0002 = GetValueFromReader<string>(dr,1);
                            instance.Compute0003 = GetValueFromReader<Int32?>(dr,2);
                            instance.Compute0004 = GetValueFromReader<Int32?>(dr,3);
                            instance.Compute0005 = GetValueFromReader<string>(dr,4);
                            instance.Compute0006 = GetValueFromReader<string>(dr,5);
                            instance.Null1 = GetValueFromReader<Int32?>(dr,6);
                            instance.Null2 = GetValueFromReader<Int32?>(dr,7);
                            instance.Null3 = GetValueFromReader<Int32?>(dr,8);
                            instance.Compute0010 = GetValueFromReader<decimal?>(dr,9);
                            instance.Null4 = GetValueFromReader<Int32?>(dr,10);
                            instance.Null5 = GetValueFromReader<Int32?>(dr,11);
                            instance.Compute0013 = GetValueFromReader<decimal?>(dr,12);
                            instance.Compute0014 = GetValueFromReader<decimal?>(dr,13);
                            instance.Compute0015 = GetValueFromReader<decimal?>(dr,14);
                            instance.Contractor = GetValueFromReader<Int32?>(dr,15);
                            instance.Compute0017 = GetValueFromReader<Int32?>(dr,16);
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

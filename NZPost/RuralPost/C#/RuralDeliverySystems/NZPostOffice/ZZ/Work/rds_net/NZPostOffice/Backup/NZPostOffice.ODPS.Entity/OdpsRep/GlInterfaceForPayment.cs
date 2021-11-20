using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;
using NZPostOffice.Shared.LogicUnits;

namespace NZPostOffice.ODPS.Entity.OdpsRep
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("ldr_entity_id", "_ldr_entity_id","")]          //"_entity_id_1", "")]
    [MapInfo("jrnl_id", "_jrnl_id","")]                      //"_journal_id_2", "")]
    [MapInfo("eff_date", "_eff_date","")]                    //"_effective_date_3", "")]

    [MapInfo("jrnl_seq_nbr", "_jrnl_seq_nbr","")]            //"_journal_sequence_4", "")]
    [MapInfo("jrnl_line_nbr", "_jrnl_line_nbr","")]          //"_journal_line_number_5", "")]
    [MapInfo("line_ldr_entity_id","_line_ldr_entity_id","")] // "_line_entity_id_6", "")]

    [MapInfo("rc","_rc","")]                                 // "_rc_number_7", "")]
    [MapInfo("account","_account","")]                       // "_account_number_8", "")]
    [MapInfo("product","_product","")]                       // "_product_code_9", "")]

    [MapInfo("analysis", "_analysis","")]                    //"_analysis_code_10", "")]
    [MapInfo("prim_dr_cr_code", "_prim_dr_cr_code","")]      //"_primary_dr_cr_code_11", "")]
    [MapInfo("trans_amt","_trans_amt","")]                   // "_transaction_amount_12", "")]

    [MapInfo("misc_dr_cr_code", "_misc_dr_cr_code","")]      //"_misc_cr_dr_code_13", "")]
    [MapInfo("misc_amt", "_misc_amt", "")]                   //"_misc_amount_14", "")]              
    [MapInfo("jrnl_user_alpha_fld_1","_jrnl_user_alpha_fld_1","")] // "_jrnl_user_alpha_fld_15", "")]

    [MapInfo("date_created","_date_created","")]             // "_date_created_16", "")]
    [MapInfo("descp", "_descp","")]                          // "_description_17", "")]

    [MapInfoIndex(new string[]{ "ldr_entity_id", "jrnl_id", "eff_date", "jrnl_seq_nbr", "jrnl_line_nbr", "line_ldr_entity_id", "rc", "account", "product", "analysis", "prim_dr_cr_code", "trans_amt","misc_dr_cr_code", "misc_amt", "jrnl_user_alpha_fld_1", "date_created", "descp" })]
    [System.Serializable()]

    public class GlInterfaceForPayment : Entity<GlInterfaceForPayment>
    {
        #region Business Methods
        [DBField()]
        private string _ldr_entity_id /*_entity_id_1*/;

        [DBField()]
        private string _jrnl_id/*_journal_id_2*/;

        [DBField()]
        private DateTime? _eff_date/*_effective_date_3*/;

        [DBField()]
        private int? _jrnl_seq_nbr/*_journal_sequence_4*/;

        [DBField()]
        private int? _jrnl_line_nbr/*_journal_line_number_5*/;

        [DBField()]
        private string _line_ldr_entity_id/*_line_entity_id_6*/;

        [DBField()]
        private string _rc/*_rc_number_7*/;

        [DBField()]
        private string _account/*_account_number_8*/;

        [DBField()]
        private string _product/*_product_code_9*/;

        [DBField()]
        private string _analysis/*_analysis_code_10*/;

        [DBField()]
        private string _prim_dr_cr_code/*_primary_dr_cr_code_11*/;

        [DBField()]
        private decimal? _trans_amt/*_transaction_amount_12*/;

        [DBField()]
        private string _misc_dr_cr_code/*_misc_cr_dr_code_13*/;

        [DBField()]
        private int? _misc_amt/*_misc_amount_14*/;

        [DBField()]
        private string _jrnl_user_alpha_fld_1/*_jrnl_user_alpha_fld_15*/;

        [DBField()]
        private DateTime? _date_created/*_date_created_16*/;

        [DBField()]
        private string _descp/*_description_17*/;

        public virtual string EntityId1
        {
            get
            {
                CanReadProperty("EntityId1",true);
                return _ldr_entity_id /*_entity_id_1*/;
            }
            set
            {
                CanWriteProperty("EntityId1",true);
                if (_ldr_entity_id /*_entity_id_1*/ != value)
                {
                    _ldr_entity_id /*_entity_id_1*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string JournalId2
        {
            get
            {
                CanReadProperty("JournalId2",true);
                return _jrnl_id/*_journal_id_2*/;
            }
            set
            {
                CanWriteProperty("JournalId2",true);
                if (_jrnl_id/*_journal_id_2*/ != value)
                {
                    _jrnl_id/*_journal_id_2*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? EffectiveDate3
        {
            get
            {
                CanReadProperty("EffectiveDate3",true);
                return _eff_date/*_effective_date_3*/;
            }
            set
            {
                CanWriteProperty("EffectiveDate3",true);
                if (_eff_date/*_effective_date_3*/ != value)
                {
                    _eff_date/*_effective_date_3*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? JournalSequence4
        {
            get
            {
                CanReadProperty("JournalSequence4",true);
                return _jrnl_seq_nbr/*_journal_sequence_4*/;
            }
            set
            {
                CanWriteProperty("JournalSequence4",true);
                if (_jrnl_seq_nbr/*_journal_sequence_4*/ != value)
                {
                    _jrnl_seq_nbr/*_journal_sequence_4*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? JournalLineNumber5
        {
            get
            {
                CanReadProperty("JournalLineNumber5",true);
                return _jrnl_line_nbr/*_journal_line_number_5*/;
            }
            set
            {
                CanWriteProperty("JournalLineNumber5",true);
                if (_jrnl_line_nbr/*_journal_line_number_5*/ != value)
                {
                    _jrnl_line_nbr/*_journal_line_number_5*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string LineEntityId6
        {
            get
            {
                CanReadProperty("LineEntityId6",true);
                return _line_ldr_entity_id/*_line_entity_id_6*/;
            }
            set
            {
                CanWriteProperty("LineEntityId6",true);
                if (_line_ldr_entity_id/*_line_entity_id_6*/ != value)
                {
                    _line_ldr_entity_id/*_line_entity_id_6*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string RcNumber7
        {
            get
            {
                CanReadProperty("RcNumber7",true);
                return _rc/*_rc_number_7*/;
            }
            set
            {
                CanWriteProperty("RcNumber7",true);
                if (_rc/*_rc_number_7*/ != value)
                {
                    _rc/*_rc_number_7*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AccountNumber8
        {
            get
            {
                CanReadProperty("AccountNumber8",true);
                return _account/*_account_number_8*/;
            }
            set
            {
                CanWriteProperty("AccountNumber8",true);
                if (_account/*_account_number_8*/ != value)
                {
                    _account/*_account_number_8*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string ProductCode9
        {
            get
            {
                CanReadProperty("ProductCode9",true);
                return _product/*_product_code_9*/;
            }
            set
            {
                CanWriteProperty("ProductCode9",true);
                if (_product/*_product_code_9*/ != value)
                {
                    _product/*_product_code_9*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string AnalysisCode10
        {
            get
            {
                CanReadProperty("AnalysisCode10",true);
                return _analysis/*_analysis_code_10*/;
            }
            set
            {
                CanWriteProperty("AnalysisCode10",true);
                if (_analysis/*_analysis_code_10*/ != value)
                {
                    _analysis/*_analysis_code_10*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string PrimaryDrCrCode11
        {
            get
            {
                CanReadProperty("PrimaryDrCrCode11",true);
                return _prim_dr_cr_code/*_primary_dr_cr_code_11*/;
            }
            set
            {
                CanWriteProperty("PrimaryDrCrCode11",true);
                if (_prim_dr_cr_code/*_primary_dr_cr_code_11*/ != value)
                {
                    _prim_dr_cr_code/*_primary_dr_cr_code_11*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual decimal? TransactionAmount12
        {
            get
            {
                CanReadProperty("TransactionAmount12",true);
                return _trans_amt/*_transaction_amount_12*/;
            }
            set
            {
                CanWriteProperty("TransactionAmount12",true);
                if (_trans_amt/*_transaction_amount_12*/ != value)
                {
                    _trans_amt/*_transaction_amount_12*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string MiscCrDrCode13
        {
            get
            {
                CanReadProperty("MiscCrDrCode13",true);
                return _misc_dr_cr_code/*_misc_cr_dr_code_13*/;
            }
            set
            {
                CanWriteProperty("MiscCrDrCode13",true);
                if (_misc_dr_cr_code/*_misc_cr_dr_code_13*/ != value)
                {
                    _misc_dr_cr_code/*_misc_cr_dr_code_13*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual int? MiscAmount14
        {
            get
            {
                CanReadProperty("MiscAmount14",true);
                return _misc_amt/*_misc_amount_14*/;
            }
            set
            {
                CanWriteProperty("MiscAmount14",true);
                if (_misc_amt/*_misc_amount_14*/ != value)
                {
                    _misc_amt/*_misc_amount_14*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string JrnlUserAlphaFld15
        {
            get
            {
                CanReadProperty("JrnlUserAlphaFld15",true);
                return _jrnl_user_alpha_fld_1/*_jrnl_user_alpha_fld_15*/;
            }
            set
            {
                CanWriteProperty("JrnlUserAlphaFld15",true);
                if (_jrnl_user_alpha_fld_1/*_jrnl_user_alpha_fld_15*/ != value)
                {
                    _jrnl_user_alpha_fld_1/*_jrnl_user_alpha_fld_15*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual DateTime? DateCreated16
        {
            get
            {
                CanReadProperty("DateCreated16",true);
                return _date_created/*_date_created_16*/;
            }
            set
            {
                CanWriteProperty("DateCreated16",true);
                if (_date_created/*_date_created_16*/ != value)
                {
                    _date_created/*_date_created_16*/ = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual string Description17
        {
            get
            {
                CanReadProperty("Description17",true);
                return _descp/*_description_17*/;
            }
            set
            {
                CanWriteProperty("Description17",true);
                if (_descp/*_description_17*/ != value)
                {
                    _descp/*_description_17*/ = value;
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
        public static GlInterfaceForPayment NewGlInterfaceForPayment(DateTime? ProcDate)
        {
            return Create(ProcDate);
        }

        public static GlInterfaceForPayment[] GetAllGlInterfaceForPayment(DateTime? ProcDate)
        {
            return Fetch(ProcDate).list;
        }
        #endregion

        #region Data Access
        [ServerMethod]
        private void FetchEntity(DateTime? ProcDate)
        {
            using (DbConnection cn = DbConnectionFactory.RequestNextAvaliableSessionDbConnection("NZPO"))
            {
                using (DbCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "odps.od_rps_gl_interface_for_payment";
                    ParameterCollection pList = new ParameterCollection();
                    pList.Add(cm, "ProcDate", ProcDate);

                    List<GlInterfaceForPayment> _list = new List<GlInterfaceForPayment>();
                    using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
                    {
                        while (dr.Read())
                        {
                            GlInterfaceForPayment instance = new GlInterfaceForPayment();
                            instance.EntityId1 = GetValueFromReader<string>(dr, 0);
                            instance.JournalId2 = GetValueFromReader<string>(dr,1);
                            instance.EffectiveDate3 = GetValueFromReader<DateTime?>(dr,2);
                            instance.JournalSequence4 = GetValueFromReader<Int32?>(dr,3);
                            instance.JournalLineNumber5 = GetValueFromReader<Int32?>(dr,4);
                            instance.LineEntityId6 = GetValueFromReader<string>(dr,5);
                            instance.RcNumber7 = GetValueFromReader<string>(dr,6);
                            instance.AccountNumber8 = GetValueFromReader<string>(dr,7);
                            instance.ProductCode9 = GetValueFromReader<string>(dr,8);
                            instance.AnalysisCode10 = GetValueFromReader<string>(dr,9);
                            instance.PrimaryDrCrCode11 = GetValueFromReader<string>(dr,10);
                            instance.TransactionAmount12 = GetValueFromReader<decimal?>(dr,11);
                            instance.MiscCrDrCode13 = GetValueFromReader<string>(dr,12);
                            instance.MiscAmount14 = GetValueFromReader<Int16?>(dr,13);
                            instance.JrnlUserAlphaFld15 = GetValueFromReader<string>(dr,14);
                            instance.DateCreated16 = GetValueFromReader<DateTime?>(dr,15);
                            instance.Description17 = GetValueFromReader<string>(dr,16);
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

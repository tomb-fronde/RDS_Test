using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.Shared;
using System.Windows.Forms;
using Metex.Core;
using Metex.Windows;
using System.IO;
using NZPostOffice.DataControls;

namespace NZPostOffice.ODPS.Controls
{
    // TJB  RPCR_128 June-2019: AppendToCSV new
    // Coded specifically for csv files, but could easily be modified
    // to append to text files.  Adapted from SaveAs().
    // Cleaned out some very large commented-out blocks.
    //
    // TJB  July 2018
    // Removed some long commented-out sections of code
    //
    // TJB  30-Oct-2013
    // Removed long commented-out section from SaveAs(string filename, string saveastype)

    // Declare  delegates.
    public delegate void EventDelegate(object send, EventArgs e);
    public delegate void UserEventDelegate();

    public class URdsDw : UDw
    {
        // TJB  RPI_005  June 2010
        // Changed ValidateExportValue to allow " " strings to pass untrimmed

        public string is_Componentname = String.Empty;

        //public const int SUCCESS = 1;

        # region delegate

        public UserEventDelegate Constructor;
        public EventDelegate URdsDwItemFocuschanged;

        #endregion

        public URdsDw()
        {
            InitializeComponent();
            InitializeEventDelegate();
        }

        #region Initialize Delegate

        private void InitializeEventDelegate()
        {
            Constructor = new UserEventDelegate(constructor);

            this.DataObjectChanged += new EventHandler(URdsDw_DataObjectChanged);
            this.DataObjectChanged += new EventHandler(AttachEvents);
        }

        private void AttachEvents(object sender, EventArgs e)
        {
            if (DataObject != null)
            {
                //this.DataObject.EditChanged += new EventHandler(URdsDwEditChanged);
                //this.DataObject.RetrieveEnd += new EventHandler(URdsDwRetrieveEnd);

                foreach (Control c in DataObject.Controls)
                {
                    c.Enter += new EventHandler(DoTriggerItemFocusChanged);
                }
            }
        }

        private void DoTriggerItemFocusChanged(object sender, EventArgs e)
        {
            OnItemFocusChanged(e);
        }

        protected void OnItemFocusChanged(EventArgs e)
        {
            if (URdsDwItemFocuschanged != null)
            {
                URdsDwItemFocuschanged(this, e);
            }
        }

        private bool _fireConstructor = false;

        public bool FireConstructor
        {
            get
            {
                return _fireConstructor;
            }
            set
            {
                if (value == true && _fireConstructor != value)
                {
                    _fireConstructor = value;
                    OnConstructor();
                }
            }
        }

        private void OnConstructor()
        {
            if (Constructor != null)
            {
                Constructor();
            }
        }

        #endregion

        public virtual void ue_deleteitem()
        {
            // allow del key to clear column
            string sName;
            int lRow;
            int? lNull;
            string sNull;
            DateTime? dNull;
            lNull = null;
            sNull = null;
            dNull = null;
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyDelete))
            {
                sName = this.GetColumnName();
                // if contract type and user has no full rights
                if (sName.ToLower() == "ct_key")
                {
                    if (!(StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_isnationaluser()))
                    {
                        if (StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types().RowCount != StaticVariables.gnv_app.of_gettotalcontracttypes())
                        {
                            return;
                        }
                    }
                }
                if (sName.ToLower() == "region_id")
                {
                    if (!(StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_isnationaluser()))
                    {
                        return;
                    }
                }
                /*? if(Trim(this.Describe(sName + ".dddw.name")) != '?') 
                   {
                       // PowerBuilder 'Choose Case' statement converted into 'if' statement
                   unknown TestExpr = Upper(Left(this.Describe(sName + ".coltype"), 4));
                       if (TestExpr == "CHAR")
                       {
                           // this.SetItem(this.GetRow(), sName, sNull);
                           this.SetValue(this.GetRow(), sName, sNull);
                       }
                       else if (TestExpr == "NUMB" || TestExpr == "DECI")
                       {
                           //this.SetItem(this.GetRow(), sName, lNull);
                           this.SetValue(this.GetRow(), sName, lNull);
                       }
                       else if (TestExpr == "DATE")
                       {
                           //this.SetItem(this.GetRow(), sName, dNull);
                           this.SetValue(this.GetRow(), sName, dNull);
                       }
                   }*/
            }
        }

        //?public virtual void ue_saveas()
        //{
        //    SaveAs();
        //}

        //?public virtual void editchanged()
        //{
        //    // enable autocomplete
        //    string sText;
        //    sText = this.GetText();
        //    if (Left(this.GetText(), 1) == ' ')
        //    {
        //        this.SetText(Mid(sText, 2));
        //    }
        //}

        public virtual void URdsDw_RetrieveEnd(object sender, EventArgs e)
        {
            //?base.retrieveend();
            this.of_filter();
        }

        public virtual void URdsDw_DoubleClick(object sender, EventArgs e)
        {
            //?if (row == 0)
            //{
            //    return;
            //}

            // Process backdoor entry columns
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyShift) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyAlt))
            {
                if (MessageBox.Show("Are you sure you want to unlock all columns?\r\nUse this facility only when you c" + "annot access data \r\nthat needs to be changed.", "Unlock columns", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    of_unprotectColumns();
                    //this.of_setupdateable(true);
                    this.of_SetUpdateable(true);
                    MessageBox.Show("All columns have been unprotected.", "Unlock columns", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public virtual void constructor()
        {
            // Set up transaction object
            ib_RegionColumnFound = this.of_hascolumn("region_id");
            ids_UserComponentRegions = new DataUserControlContainer();
            ids_UserComponentRegions.DataObject = new DUserComponentRegionlist();
        }


        public virtual int of_set_filter_ContractTypes(bool ab_filter)
        {
            //?  ib_Filter_ContractTypes = ab_filter;
            return 1;
        }

        public virtual int of_set_regionid(int al_id)
        {
            //? il_Regionid = al_regionId;
            return SUCCESS;
        }

        public virtual int of_get_regionid()
        {
            return 0;//?il_Regionid;
        }

        public virtual int of_set_readpriv(bool ab_priv)
        {
            ib_AllowRead = ab_priv;
            return SUCCESS;
        }

        public virtual int of_set_createpriv(bool ab_priv)
        {
            ib_AllowCreate = ab_priv;
            return SUCCESS;
        }

        public virtual int of_set_modifypriv(bool ab_priv)
        {
            ib_AllowModify = ab_priv;
            return SUCCESS;
        }

        public virtual int of_set_deletepriv(bool ab_priv)
        {
            ib_AllowDelete = ab_priv;
            return SUCCESS;
        }

        public virtual bool of_get_readpriv()
        {
            return ib_AllowRead;
        }

        public virtual bool of_get_createpriv()
        {
            return ib_AllowCreate;
        }

        public virtual bool of_get_modifypriv()
        {
            return ib_AllowModify;
        }

        public virtual bool of_get_deletepriv()
        {
            return ib_AllowDelete;
        }


        public virtual bool of_hascolumn(string as_columnname)
        {
            // Purpose: 	Filter the user's default region
            // Author: 	Rex Bustria
            // Date:	 	Feb 19, 2002
            string ls_ObjectList;
            string ls_Object;
            string ls_Coltype;
            string ls_Filter;
            string ls_TabCharacter = "";
            // Get Objects list
            /*?   ls_ObjectList = this.Describe("Datawindow.Objects");
               while ( ls_ObjectList.Len() > 0) {
                   // Extract an object name
                   if (Pos(ls_ObjectList, ls_TabCharacter) > 0) {
                       ls_Object =  TextUtil.Left(ls_ObjectList, TextUtil.Pos (ls_ObjectList, ls_TabCharacter) - 1);
                       ls_ObjectList =  TextUtil.Mid (ls_ObjectList, TextUtil.Pos (ls_ObjectList, ls_TabCharacter) + 1);
                   }
                   else {
                       ls_Object = ls_ObjectList;
                       ls_ObjectList = "";
                   }
                   // Is column found?
                   if (Lower( ls_Object).Trim() == Lower( as_columnname)).Trim() {
                       return true;
                   }
                   else {
                       continue;
                   }
               }*/
            return false;
        }

        public virtual string of_get_componentname()
        {
            return is_Componentname;
        }

        public virtual int of_set_componentname()
        {
            string as_Componentname;
            //?is_Componentname = as_Componentname;
            return 1;
        }

        #region DataUserControl function

        public virtual Control GetControlByName(string name)
        {
            return DataObject.GetControlByName(name);
        }

        public virtual string GetColumnName()
        {
            return DataObject.GetColumnName();
        }

        public virtual void ShareData(Metex.Windows.DataUserControl toControl)
        {
            DataObject.ShareData(toControl);
        }

        public virtual void ShareData(URdsDw toControl)
        {
            DataObject.ShareData(toControl.DataObject);
        }

        public virtual T GetItem<T>() where T : IEntity
        {
            return DataObject.GetItem<T>();
        }

        public virtual T GetItem<T>(int idx) where T : IEntity
        {
            return DataObject.GetItem<T>(idx);
        }

        public virtual void GetItem<T>(int idx, out T entity) where T : IEntity
        {
            DataObject.GetItem<T>(idx, out entity);
        }

        public virtual object GetValue(int idx, string propName)
        {
            return DataObject.GetValue(idx, propName);
        }

        public int Find(string propName, object key)
        {
            return DataObject.Find(propName, key);
        }

        public int Find(params System.Collections.Generic.KeyValuePair<string, object>[] findPair)
        {
            return DataObject.Find(findPair);
        }

        public virtual int ResetUpdate()
        {
            return DataObject.ResetUpdate();
        }

        public virtual int Retrieve()
        {
            return DataObject.Retrieve();
        }

        public void Sort<T>() where T : IEntity
        {
            DataObject.Sort<T>();
        }

        public override T InsertItem<T>(int idx)
        {
            if (idx == -1)
                idx = this.DataObject.RowCount;
            return DataObject.InsertItem<T>(idx);
        }

        public override void InsertItem<T>(int idx, T entity)
        {
            DataObject.InsertItem<T>(idx, entity);
        }

        public virtual bool AcceptText()
        {
            if (DataObject != null)
            {
                return DataObject.AcceptText();
            }
            else
            {
                return false;
            }
        }

        public DataUserControl GetChild(string name)
        {
            if (DataObject != null)
            {
                return DataObject.GetChild(name);
            }
            else
            {
                return null;
            }
        }

        public void DeleteItemAt(int idx)
        {
            DataObject.DeleteItemAt(idx);
        }

        private string _sql_select = "";

        public string GetSqlSelect()
        {
            return _sql_select;
        }

        public void SetSqlSelect(string as_sql)
        {
            this._sql_select = as_sql;
        }

        private Type EntityType;
        private System.Collections.Generic.List<string> column_name_list = new System.Collections.Generic.List<string>();

        protected virtual void URdsDw_DataObjectChanged(object sender, EventArgs e)
        {
            this.DataObject.Dock = DockStyle.Fill;
            string name = this.DataObject.GetType().AssemblyQualifiedName;
            this.column_name_list.Clear();
            try
            {
                string entity_typename = name.Replace("DataControls", "Entity");
                char[] test_array = entity_typename.ToCharArray();
                int pos_dot = -1;
                for (int i = 0; i < test_array.Length; i++)
                {
                    if (test_array[i] == '.')
                        pos_dot = i;
                    else if (test_array[i] == ',')
                        break;
                }
                if (char.IsLower(test_array[pos_dot + 2]))
                    entity_typename = entity_typename.Substring(0, pos_dot + 1) + entity_typename.Substring(pos_dot + 3);
                else
                    entity_typename = entity_typename.Substring(0, pos_dot + 1) + entity_typename.Substring(pos_dot + 2);
                this.EntityType = Type.GetType(entity_typename);
                NZPostOffice.Shared.LogicUnits.MapInfoIndex[] map_info_indexes = (NZPostOffice.Shared.LogicUnits.MapInfoIndex[])this.EntityType.GetCustomAttributes(typeof(NZPostOffice.Shared.LogicUnits.MapInfoIndex), false);

                if (map_info_indexes.Length > 0)
                    column_name_list.AddRange(map_info_indexes[0].GetIndex());
            }
            catch (Exception)
            {
                this.EntityType = null;
            }
        }

        public int InsertRow(int row)
        {
            if (row < 0)
                row = this.RowCount;

            if (this.EntityType != null)
            {
                return InsertRow(row, (EntityBase)Activator.CreateInstance(EntityType));
            }
            else
                throw new NotSupportedException("Can not determine the entity type of this data control");
        }

        private int InsertRow(int row, EntityBase entity)
        {
            if (row < 0)
                row = this.RowCount;
            if (this.DataObject.BindingSource.List == null)
            {
                this.DataObject.BindingSource.DataSource = Activator.CreateInstance(typeof(Metex.Core.EntityBindingList<>).MakeGenericType(EntityType));
                this.DataObject.BindingSource.Add(entity);
                row = 0;
            }
            else
            {
                this.DataObject.BindingSource.List.Insert(row, entity);
            }
            entity.MarkClean();
            return row;
        }

        public virtual int Save()
        {
            this.ProcessDialogKey(Keys.Tab); //added by jlwang:for fix the focus bug

            if (this.ModifiedCount() > 0 || this.DataObject.DeletedCount > 0)//? ||this.NewCount() > 0)
            {
                try
                {
                    this.DataObject.Save();
                    return 1;
                }
                catch
                {
                    return -1;
                }
            }
            return 1;
        }

        public int GetSelectedRow(int row)
        {
            if (GetControlByName("grid") == null || row < 0 || row > DataObject.RowCount || ((DataEntityGrid)GetControlByName("grid")).RowCount <= 0)
            {
                return -1;
            }

            for (int i = row; i < DataObject.RowCount; i++)
            {
                if (((DataEntityGrid)GetControlByName("grid")).Rows[i].Selected)
                    return i;
            }
            return -1;
        }

        public int SelectRow(int row, bool isSelected)
        {
            if (GetControlByName("grid") == null || row < 0 || row > DataObject.RowCount || ((DataEntityGrid)GetControlByName("grid")).RowCount <= 0)
            {
                return -1;
            }
            if (row == 0)
            {
                for (int i = 0; i < DataObject.RowCount; i++)
                {
                    ((DataEntityGrid)GetControlByName("grid")).Rows[i].Selected = isSelected;
                }
            }
            else
            {
                ((DataEntityGrid)GetControlByName("grid")).Rows[row - 1].Selected = isSelected;
            }
            return 1;
        }

        #endregion

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Height = 139;
            this.Width = 162;
            this.ResumeLayout();
        }

        public struct us_instance
        {
            public int first_column;

            public DateTime last_updated;

            public int security_access_level;

            public int security_group;
        }

        // Data Export
        public virtual int ImportFile(string path)
        {
            int ret_value = 0;
            int input_type = path.ToLower().EndsWith(".csv") ? 1 : (path.ToLower().EndsWith(".txt") ? 2 : 0);
            if (input_type != 0)
            {
                try
                {
                    // get field info from entity type
                    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                    for (int i = 0; i < column_name_list.Count; i++)
                    {
                        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    }
                    // read and parse csv file

                    //get the rowcount of file
                    int rowCount = 0;
                    using (StreamReader str = new StreamReader(path))
                    {
                        while (str.Read() > 0)
                        {
                            str.ReadLine();
                            rowCount++;
                        }
                    }
                    GC.Collect();

                    StreamReader sr = new StreamReader(path);

                    string line;
                    if (sr.Peek() == 0)
                        ret_value = -2;
                    if (sr.Peek() > 0)
                    {
                        char sep = (input_type == 1) ? ',' : '\t';
                        System.Collections.Generic.IEnumerator<string[]> iterator = this.ParseStringAsCSV(sr, sep);
                        int currRow = 0;
                        while (iterator.MoveNext())
                        {
                            currRow++;

                            string[] fields = iterator.Current;
                            // create the new object
                            EntityBase entity = (EntityBase)Activator.CreateInstance(EntityType);
                            for (int i = 0; i < fields.Length; i++)
                            {
                                object real_value;
                                if (column_fields[i].FieldType == typeof(int?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        int result = 0;
                                        int.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(decimal?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        decimal result = 0;
                                        decimal.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(double?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        double result = 0;
                                        double.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(DateTime?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        DateTime result = DateTime.MinValue;

                                        if (!DateTime.TryParse(fields[i].Trim(), out result))
                                        {
                                            MessageBox.Show("Item " + "'" + fields[i].Trim() + "'" + " does not pass validation test.", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            if (MessageBox.Show("Item validation error on IMPORT.Continue IMPORT?", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                            {
                                                return ret_value;
                                            }
                                        }
                                        real_value = result;
                                    }
                                }
                                else
                                    real_value = fields[i];
                                column_fields[i].SetValue(entity, real_value);
                            }
                            // append the new object
                            this.InsertRow(-1, entity);
                            ret_value++;

                            ((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Processing row " + ret_value + " of " + rowCount.ToString();
                            ((WOdpsMdiframe)StaticVariables.MainMDI).Refresh();
                        }
                    }
                    sr.Close();
                    ((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Ready";
                }
                catch (ArgumentException)
                {
                    ret_value = -3;
                }
                catch (FileNotFoundException)
                {
                    ret_value = -5;
                }
                catch (IOException)
                {
                    ret_value = -7;
                }
                catch (Exception)
                {
                    ret_value = -4;
                }
            }
            else
                ret_value = -8;

            return ret_value;
        }

        public virtual int ImportFile(string path, int startrow)
        {
            int ret_value = 0;
            int input_type = path.ToLower().EndsWith(".csv") ? 1 : (path.ToLower().EndsWith(".txt") ? 2 : 0);
            if (input_type != 0)
            {
                try
                {
                    // get field info from entity type
                    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                    for (int i = 0; i < column_name_list.Count; i++)
                    {
                        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                    }
                    // read and parse csv file

                    //get the rowcount of file
                    int rowCount = 0;
                    using (StreamReader str = new StreamReader(path))
                    {
                        while (str.Read() > 0)
                        {
                            str.ReadLine();
                            rowCount++;
                        }
                    }
                    GC.Collect();

                    if (rowCount == 0)
                    {
                        ret_value = -1;
                    }
                    if (startrow >= rowCount)
                    {
                        ret_value = -1;
                    }

                    StreamReader sr = new StreamReader(path);

                    for (int i = 0; i < startrow; i++)//added by ylwang
                    {
                        sr.ReadLine();
                    }

                    string line;
                    if (sr.Peek() == 0)
                        ret_value = -2;
                    if (sr.Peek() > 0)
                    {
                        char sep = (input_type == 1) ? ',' : '\t';
                        System.Collections.Generic.IEnumerator<string[]> iterator = this.ParseStringAsCSV(sr, sep);
                        int currRow = 0;
                        while (iterator.MoveNext())
                        {
                            currRow++;

                            string[] fields = iterator.Current;
                            // create the new object
                            EntityBase entity = (EntityBase)Activator.CreateInstance(EntityType);
                            for (int i = 0; i <column_fields.Length ;i++)// fields.Length; i++)
                            {
                                object real_value;
                                if (column_fields[i].FieldType == typeof(int?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        int result = 0;
                                        int.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(decimal?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        decimal result = 0;
                                        decimal.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(double?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        double result = 0;
                                        double.TryParse(fields[i].Trim(), out result);
                                        real_value = result;
                                    }
                                }
                                else if (column_fields[i].FieldType == typeof(DateTime?))
                                {
                                    if (fields[i].Trim().Length == 0)
                                        real_value = null;
                                    else
                                    {
                                        DateTime result = DateTime.MinValue;

                                        if (!DateTime.TryParse(fields[i].Trim(), out result))
                                        {
                                            MessageBox.Show("Item " + "'" + fields[i].Trim() + "'" + " does not pass validation test.", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            if (MessageBox.Show("Item validation error on IMPORT.Continue IMPORT?", "Rural Delivery System with NPAD Extensions", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                                            {
                                                return ret_value;
                                            }
                                        }
                                        real_value = result;
                                    }
                                }
                                else
                                {
                                    real_value = fields[i];
                                }

                                column_fields[i].SetValue(entity, real_value);
                            }
                            // append the new object
                            this.InsertRow(-1, entity);
                            ret_value++;

                            //?((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Processing row " + ret_value + " of " + rowCount.ToString();
                            //?((WOdpsMdiframe)StaticVariables.MainMDI).Refresh();
                        }
                    }
                    sr.Close();
                    //?this.DataObject.BindingSource.CurrencyManager.Refresh(); //jlwang 10082007

                    //?((WOdpsMdiframe)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Ready";
                }
                catch (ArgumentException)
                {
                    ret_value = -3;
                }
                catch (FileNotFoundException)
                {
                    ret_value = -5;
                }
                catch (IOException)
                {
                    ret_value = -7;
                }
                catch (Exception e)
                {
                    string str = e.Message.ToString();
                    ret_value = -4;
                }
            }
            else
                ret_value = -8;

            return ret_value;
        }

        private System.Collections.Generic.IEnumerator<string[]> ParseStringAsCSV(StreamReader sr, char separator)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            bool dquote_state = false;
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            bool skip_read = false;
            char current = ' ';
            while (sr.Peek() > 0)
            {
                if (skip_read)
                    skip_read = false;
                else
                    current = (char)sr.Read();
                if (current == '"')
                {
                    if (!dquote_state)
                        dquote_state = true;
                    else
                    {
                        current = (char)sr.Read();
                        if (current == '"')
                            builder.Append('"');
                        else
                        {
                            skip_read = true;
                            dquote_state = false;
                        }
                    }
                }
                else if (current == separator)
                {
                    if (!dquote_state)
                    {
                        result.Add(builder.ToString());
                        builder.Remove(0, builder.Length);
                    }
                    else
                        builder.Append(separator);
                }
                else if (current == '\r' || current == '\n')
                {
                    if (builder.Length > 0)
                    {
                        result.Add(builder.ToString());
                        builder.Remove(0, builder.Length);
                    }
                    if (result.Count > 0)
                    {
                        yield return result.ToArray();
                        result.Clear();
                    }
                }
                else
                {
                    builder.Append(current);
                }
            }
            if (builder.Length > 0)
                result.Add(builder.ToString());
            if (result.Count > 0)
                yield return result.ToArray();
        }

        public int SaveAs(string filename, string saveastype)
        {
            return this.SaveAs(filename, saveastype, true);
        }

        public int SaveAs(string filename, string saveastype, bool headline)
        {
            try
            {
                if (filename.Length > 0)
                {
                }
                else
                {
                    SaveFileDialog savedlg = new SaveFileDialog();
                    savedlg.Title = "Export to file...";
                    savedlg.Filter = "Excel files  ( *.xls)| *.xls |CSV files  ( *.csv)| *.csv";
                    if (savedlg.ShowDialog() == DialogResult.OK)
                    {
                        filename = savedlg.FileName;
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (filename.Substring(filename.Length - 3).ToLower() == "xls")
                {
                    throw new Exception("Save As type XLS not implemented.");

                }
                else
                {
                    StreamWriter sw = null;
                    try
                    {
                        // set separator charatcer
                        string sep;
                        if (saveastype.ToLower() == "text")
                            sep = "\t";
                        else if (saveastype.ToLower() == "csv")
                            sep = ",";
                        else if (saveastype.ToLower() == "fixed")
                            sep = "";
                        else
                            throw new Exception("Unsupported save as type.");

                        // get field info from entity type
                        System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                        for (int i = 0; i < column_name_list.Count; i++)
                        {
                            column_fields[i] = EntityType.GetField("_" + column_name_list[i],
                                System.Reflection.BindingFlags.GetField |
                                System.Reflection.BindingFlags.SetField |
                                System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic);
                        }


                        sw = new StreamWriter(filename);
                        if (headline)
                        {
                            for (int i = 0; i < column_name_list.Count; i++)
                            {
                                sw.Write(column_name_list[i] + sep);
                            }
                            sw.Write("\r\n");
                        }
                        for (int r = 0; r < DataObject.RowCount; r++)
                        {
                            for (int i = 0; i < column_fields.Length; i++)
                            {
                                //sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
                                string field_value = ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r]));
                                sw.Write(field_value);
                                if (i != column_fields.Length - 1)
                                    sw.Write(sep);
                            }
                            if (r != DataObject.RowCount - 1)
                                sw.Write("\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        GC.Collect();
                        return -1;
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                    GC.Collect();
                    return DataObject.RowCount;
                }
                return 1;
            }
            catch
            {
                return -1;
            }
            GC.Collect();
            return 0;
            //GC.Collect();
            //return DataObject.RowCount;
        }

        // TJB  RPCR_128 June-2019: AppendToCSV new
        // Coded specifically for csv files, but could easily be modified
        // to append to text files.
        public int AppendToCSV(string filename, bool headline)
        {
            // TJB  RPCR_128 June-2019
            // Append additional data to a file (assumed to be a CSV file)
            try
            {
                // If we weren't given a filename, ask for one
                if (filename.Length <= 0)
                {
                    SaveFileDialog savedlg = new SaveFileDialog();
                    savedlg.Title = "Append to CSV file...";
                    savedlg.Filter = "CSV files (*.csv)| *.csv";
                    if (savedlg.ShowDialog() == DialogResult.OK)
                    {
                        filename = savedlg.FileName;
                    }
                    else
                    {
                        return -1;
                    }
                }
                string filetype = filename.Substring(filename.Length - 3);
                if (filetype.ToLower() != "csv")
                {
                    throw new Exception("Can only append to CSV format files.");
                }
                else
                {
                    StreamWriter sw = null;
                    try
                    {
                        // set separator charatcer
                        string sep;
                        if (filetype.ToLower() == "text")
                            sep = "\t";
                        else if (filetype.ToLower() == "csv")
                            sep = ",";
                        else if (filetype.ToLower() == "fixed")
                            sep = "";
                        else
                            throw new Exception("Unsupported save as type.");

                        // get field info from entity type
                        System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                        for (int i = 0; i < column_name_list.Count; i++)
                        {
                            column_fields[i] = EntityType.GetField("_" + column_name_list[i],
                                System.Reflection.BindingFlags.GetField |
                                System.Reflection.BindingFlags.SetField |
                                System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic);
                        }

                        sw = new StreamWriter(filename, true);
                        sw.WriteLine();
                        if (headline)
                        {
                            for (int i = 0; i < column_name_list.Count; i++)
                            {
                                sw.Write(column_name_list[i] + sep);
                            }
                            sw.Write("\r\n");
                        }
                        for (int r = 0; r < DataObject.RowCount; r++)
                        {
                            for (int i = 0; i < column_fields.Length; i++)
                            {
                                //sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
                                string field_value = ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r]));
                                sw.Write(field_value);
                                if (i != column_fields.Length - 1)
                                    sw.Write(sep);
                            }
                            if (r != DataObject.RowCount - 1)
                                sw.Write("\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        GC.Collect();
                        return -1;
                    }
                    finally
                    {
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                    GC.Collect();
                    return DataObject.RowCount;
                }
                return 1;
            }
            catch
            {
                return -1;
            }
            GC.Collect();
            return 0;
        }

        private string ValidateExportValue(object value)
        {
            // TJB  RPI_005  June 2010
            // Changed to allow " " strings to pass untrimmed

            System.Text.RegularExpressions.Regex rx 
                = new System.Text.RegularExpressions.Regex("[,\"\\t\\r\\n]");
            if (value == null)
            {
                return "";
            }
            else if (value is DateTime)
            {
                return ((DateTime)value).ToShortDateString();
            }
            else if (value is decimal)  //format 2 decimal
            {
                return string.Format("{0:F2}", value);
            }
            else if (!(value is string))
            {
                return value.ToString();
            }
            else
            {
                if (rx.Match((string)value).Success)
                    return '"' + ((string)value).Replace("\"", "\"\"") + '"';

                // TJB RPI_005 June-2010: Added length condition so " " would be untrimmed
                if (((string)value).Length > 1)
                    return ((string)value).Trim();
                else
                    return ((string)value);
            }
        }
    }
}

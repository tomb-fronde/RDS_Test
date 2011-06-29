using System;
using System.Windows.Forms;
using Metex.Windows;
using NZPostOffice.Shared.Security;
using NZPostOffice.Shared;
using Metex.Core;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.RDS.Menus;
using NZPostOffice.RDS.Windows.Ruralwin;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.RDS.Controls
{
    //declare  delegates.
    public delegate void EventDelegate(object send, EventArgs e);
    public delegate void UserEventDelegate();
    public delegate int  UserEventDelegate1(); //added by jlwang
    public delegate bool UserEventDelegate2(); //added by jlwang

    public class URdsDw : UDw
    {
        // TJB  Release 7.1.3 fixups Aug 2010
        // Added of_set_insertmodify and showUpdateToolButton
        // to add Update button (m_modify) when working with Allowancws

        #region event delegate

        //added by wjtang for  the delegate
        public EventDelegate URdsDwEditChanged;
        public EventDelegate URdsDwRetrieveEnd;
        public EventDelegate URdsDwItemFocuschanged;
        public UserEventDelegate Constructor;

        //pfc event
        //declare event base on the delegate 

        //Insert 
        public UserEventDelegate1 PfcPreInsertRow;
        public UserEventDelegate PfcInsertRow;

        // TJB  Release 7.1.3 fixups Aug 2010: Added
        public UserEventDelegate PfcModify;

        public UserEventDelegate PfcPreRmbMenu;
        public UserEventDelegate PfcSelectall;

        //Delete
        public UserEventDelegate1 PfcPreDeleteRow;
        public UserEventDelegate PfcDeleteRow;

        //Update  
        public UserEventDelegate2 WinValidate; //added by jlwang for windows level validate 
        public UserEventDelegate1 UpdateStart;
        public UserEventDelegate1 PfcValidation;
        public UserEventDelegate1 PfcPreUpdate;
        public UserEventDelegate PfcPostUpdate;
        public UserEventDelegate1 PfcUpdate;
        public UserEventDelegate UpdateEnd;

        public UserEventDelegate1 WinPfcSave;//ttjin
        #endregion

        private MRdsDw mRdsDw;

        public URdsDw()
        {
            InitializeComponent();
            mRdsDw = new MRdsDw(this);
            this.ContextMenuStrip = mRdsDw;
            
            InitializeEventDelegate();
            this.GotFocus += new EventHandler(URdsDw_GetFocus);
        }

        #region initialize event delegate
        protected virtual void InitializeEventDelegate()
        {
            URdsDwEditChanged = new EventDelegate(URdsDw_EditChanged);
            URdsDwRetrieveEnd = new EventDelegate(URdsDw_RetrieveEnd);
            Constructor = new UserEventDelegate(constructor);

            //Insert
            PfcPreInsertRow = new UserEventDelegate1(pfc_preinsertrow);
            PfcInsertRow = new UserEventDelegate(pfc_insertrow);

            // TJB  Release 7.1.3 fixups Aug 2010: Added
            //Modify 
            PfcModify = new UserEventDelegate(pfc_modify);

            //Delete
            PfcPreDeleteRow = new UserEventDelegate1(pfc_predeleterow);
            PfcDeleteRow = new UserEventDelegate(pfc_deletetrow);//added by jlwang

            //Update
            PfcPreUpdate = new UserEventDelegate1(pfc_preupdate);
            PfcPostUpdate = new UserEventDelegate(pfc_postupdate); //added by jlwang


            PfcPreRmbMenu = new UserEventDelegate(pfc_prermbmenu);
            PfcSelectall = new UserEventDelegate(pfc_selectall);

            PfcUpdate = new UserEventDelegate1(pfc_update);

            UpdateStart = new  UserEventDelegate1(updatestart);

            WinValidate = new UserEventDelegate2(winvalidate); //added by jlwang
            PfcValidation = new UserEventDelegate1(pfc_validation);
            WinPfcSave = new UserEventDelegate1(winPfcSave);
            this.DataObjectChanged += new EventHandler(URdsDw_DataObjectChanged);
            this.DataObjectChanged += new EventHandler(AttachEvents);
        }

        private void AttachEvents(object sender, EventArgs e)
        {
            if (DataObject != null)
            {
                this.DataObject.EditChanged += new EventHandler(URdsDwEditChanged);
                this.DataObject.RetrieveEnd += new EventHandler(URdsDwRetrieveEnd);

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
        #endregion

        #region By Default, create an OnXXXX Method, to call the Event

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

        public void OnPfcInsertRow()
        {
            if (PfcInsertRow != null)
            {
                PfcInsertRow();
            }
        }

        // TJB  Release 7.1.3 fixups Aug 2010: Added
        public void OnPfcModify()
        {
            if (PfcModify != null)
            {
                PfcModify();
            }
        }

        private void OnPfcPreUpdate()
        {
            if (PfcPreUpdate != null)
            {
                PfcPreUpdate();
            }
        }

        private void OnPfcPreRmbMenu()
        {
            if (PfcPreRmbMenu != null)
            {
                PfcPreRmbMenu();
            }
        }

        private void OnPfcSelectall()
        {
            if (PfcSelectall != null)
            {
                PfcSelectall();
            }
        }

        public void OnPfcPreInsertRow()
        {
            if (PfcPreInsertRow != null)
            {
                PfcPreInsertRow();
            }
        }

        public void OnPfcPreDeleteRow()
        {
            if (PfcPreDeleteRow != null)
            {
                PfcPreDeleteRow();
            }
        }

        public void OnPfcDeleteRow()
        {
            if (PfcDeleteRow != null)
            {
                PfcDeleteRow();
            }
        }

        public void OnPfcPostUpdate()
        {
            if (PfcPostUpdate != null)
            {
                PfcPostUpdate();
            }
        }

        public void OnPfcVaidation()
        {
            if (PfcValidation != null)
            {
                PfcValidation();
            }
        }

        private void OnUpdateStart()
        {
            if (UpdateStart != null)
            {
                UpdateStart();
            }
        }

        private void OnUpdateEnd()
        {
            if (UpdateEnd != null)
            {
                UpdateEnd();
            }
        }

        private void OnPfcUpdate()
        {
            if (PfcUpdate != null)
            {
                PfcUpdate();
            }
        }

        protected void OnItemFocusChanged(EventArgs e)
        {
            if (URdsDwItemFocuschanged != null)
            {
                URdsDwItemFocuschanged(this, e);
            }
        }

        #endregion

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

        public virtual object GetValue(int idx, int fieldIdx)
        {
            if (this.column_name_list.Count == 0)
                throw new Exception("Entity does not support get/set value by index");
            if (fieldIdx >= this.column_name_list.Count)
                return null;
            return DataObject.GetValue(idx, this.column_name_list[fieldIdx]);
        }

        public virtual void SetValue(int idx, int fieldIdx, object value)
        {
            if (this.column_name_list.Count == 0)
                throw new Exception("Entity does not support get/set value by index");
            if (fieldIdx >= this.column_name_list.Count)
                return;
            DataObject.SetValue(idx, this.column_name_list[fieldIdx], value);
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
            //return DataObject.ResetUpdate();
            for (int i = 0; i < DataObject.RowCount; i++)
            {
                DataObject.GetItem<Metex.Core.EntityBase>(i).MarkClean();
            }
            StaticFunctions.ClearDeleteBuffer(DataObject);
            return 1;
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
            if (idx >= 0)
            {
                try
                {
                if (((Metex.Core.EntityBase)(((Metex.Core.IEntity)DataObject.BindingSource.List[0]))).IsNew == true)//ttjin.PB will not add the row with new state to deleteBuffer when delete.
                {
                    DataObject.BindingSource.List.RemoveAt(idx);
                }
                   
                else
                {
                    DataObject.DeleteItemAt(idx);
                }
                    }
                catch(Exception e)
                {
                
                }
            }
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

        #region datawindow service methods

        public int FindIf<T>(Predicate<T> finder) where T : Metex.Core.IEntity
        {
            for (int i = 0; i < this.DataObject.RowCount; i++)
            {
                if (finder(this.GetItem<T>(i)))
                    return i;
            }
            return -1;
        }

        //pp! PB help statement for the following functions: GetNextModified reports rows with the status NewModified! and DataModified!
        public virtual int GetNextModified(int row)
        {
            for (++row; row < this.DataObject.RowCount; row++)
            {
                //pp! added IsNew check, entity can has IsNew = true and IsDirty = false, to be verified
                if (((Metex.Core.EntityBase)this.DataObject.BindingSource.List[row]).IsDirty
                    || ((Metex.Core.EntityBase)this.DataObject.BindingSource.List[row]).IsNew
                    )
                    return row;
            }
            return -1;
        }

        public override int Retrieve(object[] args)
        {
            // eliminate null reference exception in DataUserControlContainer.Retrieve
            if (args == null)
                return base.Retrieve(args);
            int i = 0;
            for (; i < args.Length; i++)
                if (args[i] == null)
                    break;
            if (i == args.Length)
                return base.Retrieve(args);
            if (this.DataObject != null)
            {
                MethodInfo method;
                Type type = this.DataObject.GetType();
                method = type.GetMethod("Retrieve", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (method != null)
                {
                    return (int)method.Invoke(this.DataObject, args);
                }
            }
            return 0;
        }

        public virtual int Save()
        {
            int thisNewCount = this.NewCount();
            int thisModifiedCount = this.ModifiedCount();
            int thisDeletedCount = this.DataObject.DeletedCount;
            // if (this.NewCount() > 0 || this.ModifiedCount() > 0)
/*
            if (this.DataObject.DeletedCount==0 || this.NewCount() >0 ||
                (this.DataObject.DeletedCount >0 && this.ModifiedCount()>0) ||
                (this.DataObject.DeletedCount >0 && this.NewCount()>0))
*/
            if (thisDeletedCount == 0 || thisNewCount > 0 ||
                (thisDeletedCount > 0 && thisModifiedCount > 0) ||
                (thisDeletedCount > 0 && thisNewCount > 0))
            {
                this.ProcessDialogKey(Keys.Tab ); //added by jlwang:for fix the focus bug
                this.URdsDw_GetFocus(null, null); //added by jlwang for fix tab key change the focus
            }
            int rst = 1;
            if (this.ModifiedCount() > 0 || this.DataObject.DeletedCount > 0)//? ||this.NewCount() > 0)
            {
                rst = -1;
                if (UpdateStart != null && UpdateStart() == 0)
                {
                    if (WinValidate != null && WinValidate())
                    {
                        if (PfcValidation != null && PfcValidation() == 1)
                        {
                            if (PfcPreUpdate != null && PfcPreUpdate() == 1)
                            {
                                rst = PfcUpdate();// this.DataObject.Save();
                                if (rst == 1)
                                    PfcPostUpdate();
                                OnUpdateEnd();
                            }
                        }
                    }
                }
            }
            if (WinPfcSave != null)
                WinPfcSave();

            //added by jlwang for fix tab key change the focus
            this.URdsDw_GetFocus(null, null); 
            return rst;// 0;
        }
        protected virtual int pfc_update()
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

        protected virtual int pfc_validation()
        {
            //int li_checkcolumn = 1;
            //int li_rc;
            //int ll_checkrow = 1;
            //string ls_checkcolname = "";
            //bool lb_updateonly = true;

            //li_rc = of_CheckRequired(this, ref ll_checkrow, ref li_checkcolumn, ref ls_checkcolname, lb_updateonly);
            //if (li_rc < 0 || ll_checkrow > 0)
            //{
            //    return FAILURE;
            //}
            return SUCCESS;
        }

        private Type EntityType;
        private System.Collections.Generic.List<string> column_name_list = new System.Collections.Generic.List<string>();
        protected virtual void URdsDw_DataObjectChanged(object sender, EventArgs e)
        {
            //if (this.DataObject != null)
            //    Console.WriteLine("++++ URdsDw_DataObjectChanged: " + this.DataObject.ToString());

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

        public bool RowsDiscard(int startIdx, int endIdx)
        {
            return this.DataObject.RowsDiscard(startIdx, endIdx);
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

        // Data Import
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
                            int i_temp = fields.Length < column_fields.Length ? fields.Length : column_fields.Length;
                            for (int i = 0; i < i_temp;i++)// column_fields.Length; i++)
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
                                            MessageBox.Show("Item " + "'" + fields[i].Trim() + "'" + " does not pass validation test."
                                                          , "Rural Delivery System with NPAD Extensions"
                                                          , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            if (MessageBox.Show("Item validation error on IMPORT.Continue IMPORT?"
                                                              , "Rural Delivery System with NPAD Extensions"
                                                              , MessageBoxButtons.YesNo, MessageBoxIcon.Information) 
                                                == DialogResult.No)
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

                            ((WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Processing row " + ret_value + " of " + rowCount.ToString();
                            ((WMainMdi)StaticVariables.MainMDI).Refresh();
                        }
                    }
                    sr.Close();
                    ((WMainMdi)StaticVariables.MainMDI).toolStripStatusLabel1.Text = "Ready";
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
                catch (Exception )
                {
                    ret_value = -4;
                }
            }
            else
                ret_value = -8;

            return ret_value;
        }

        private System.Collections.Generic.IEnumerator<string[]> ParseStringAsCSV(StreamReader sr, char separator)
        {
            List<string> result = new List<string>();
            bool dquote_state = false;
            StringBuilder builder = new StringBuilder();
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
                else if (current == separator )//|| current==System.Convert.ToChar(32))  //jlwang:for support ''
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

        // Data Export
        public int SaveAs(string filename, string saveastype)
        {
            try
            {
                if (filename.Length > 0)
                {
                }
                else
                {
                    SaveFileDialog savedlg = new SaveFileDialog();
                    //?savedlg.Title = "Export to file...";
                    savedlg.Filter = "Excel files  ( *.xls)| *.xls |CSV with headers  ( *.csv)| *.csv |Text (*.txt) |*.txt";//filter string
                    savedlg.DefaultExt = saveastype;
                    if (savedlg.ShowDialog() == DialogResult.OK)
                    {
                        filename = savedlg.FileName.Trim();
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (filename.Substring(filename.Length - 3) == "xls")
                {
                    Microsoft.Office.Interop.Excel.Application m_Excel = new Microsoft.Office.Interop.Excel.Application();
                    m_Excel.SheetsInNewWorkbook = 1;
                    Microsoft.Office.Interop.Excel._Workbook m_Book = (Microsoft.Office.Interop.Excel._Workbook)(m_Excel.Workbooks.Add(Missing.Value));
                    Microsoft.Office.Interop.Excel._Worksheet m_Sheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_Book.Worksheets.get_Item(1));
                    m_Sheet.Name = EntityType.Name;
                    Dictionary<string, string> dict = translateColName(EntityType);
                    int j = 0;
                    foreach (PropertyInfo p in this.EntityType.GetProperties())
                    {
                        j++;
                        if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
                        {
                        }
                        else
                        {
                            m_Sheet.Cells[1, j] = dict[p.Name.ToLower()];
                        }
                    }

                    for (int i = 0; i < this.RowCount; i++)
                    {
                        j = 0;
                        EntityBase sResult = this.GetItem<EntityBase>(i);
                        foreach (PropertyInfo p in sResult.GetType().GetProperties())
                        {
                            if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
                            {
                            }
                            else
                            {
                                j++;
                                if (p.PropertyType == typeof(string))
                                {
                                    m_Sheet.Cells[2 + i, j] = "'" + p.GetValue(sResult, null);
                                }
                                else
                                {
                                    if (p.PropertyType == typeof(Int64))//pp! seems long values throw exception - convert to int32
                                    {
                                        m_Sheet.Cells[2 + i, j] = Convert.ToInt32(p.GetValue(sResult, null));
                                    }
                                    else
                                    {
                                        m_Sheet.Cells[2 + i, j] = p.GetValue(sResult, null);
                                    }
                                }
                            }
                        }
                    }
                    m_Sheet.Cells.WrapText = false;
                    m_Book.SaveAs(
                        filename, 
                        Missing.Value,
                        Missing.Value, 
                        Missing.Value, 
                        Missing.Value,
                        Missing.Value, 
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        Missing.Value, 
                        Missing.Value,
                        Missing.Value,
                        Missing.Value,
                        Missing.Value);

                    m_Book.Close(false, Missing.Value, Missing.Value);
                    m_Excel.Quit();
                    m_Book = null;
                    m_Sheet = null;
                    m_Excel = null;
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(filename))//null;
                    {
                        // set separator charatcer
                        char sep;
                        if (saveastype.ToLower() == "text")
                        {
                            sep = '\t';
                        }
                        else if (saveastype.ToLower() == "csv")
                        {
                            sep = ',';
                        }
                        else
                        {
                            throw new Exception("Unsupported save as type.");
                        }
                        if (saveastype.ToLower() == "csv")
                        {
                            int j = 0;
                            Microsoft.Office.Interop.Excel.Application m_Excel = new Microsoft.Office.Interop.Excel.Application();
                            m_Excel.SheetsInNewWorkbook = 1;
                            Microsoft.Office.Interop.Excel._Workbook m_Book = (Microsoft.Office.Interop.Excel._Workbook)(m_Excel.Workbooks.Add(Missing.Value));
                            Microsoft.Office.Interop.Excel._Worksheet m_Sheet = (Microsoft.Office.Interop.Excel._Worksheet)(m_Book.Worksheets.get_Item(1));
                            m_Sheet.Name = EntityType.Name;
                            foreach (PropertyInfo p in this.EntityType.GetProperties())
                            {
                                j++;
                                if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
                                {
                                }
                                else
                                {
                                    m_Sheet.Cells[1, j] = reversemigrateName(p.Name);
                                }
                            }

                            for (int i = 0; i < this.RowCount; i++)
                            {
                                j = 0;
                                EntityBase sResult = this.GetItem<EntityBase>(i);
                                foreach (PropertyInfo p in sResult.GetType().GetProperties())
                                {
                                    if (p.Name == "SQLCode" || p.Name == "SQLErrText" || p.Name == "IsNew" || p.Name == "IsDeleted" || p.Name == "IsDirty" || p.Name == "IsSavable")
                                    {
                                    }
                                    else
                                    {
                                        j++;
                                        if (p.PropertyType == typeof(string))
                                        {
                                            m_Sheet.Cells[2 + i, j] = "'" + p.GetValue(sResult, null);
                                        }
                                        else
                                        {
                                            m_Sheet.Cells[2 + i, j] = p.GetValue(sResult, null);
                                        }
                                    }
                                }
                            }
                            m_Sheet.Cells.WrapText = false;
                            m_Book.SaveAs(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                            m_Book.Close(false, Missing.Value, Missing.Value);
                            m_Excel.Quit();
                            m_Book = null;
                            m_Sheet = null;
                            m_Excel = null;
                        }
                        else
                        {
                            // get field info from entity type
                            System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
                            for (int i = 0; i < column_name_list.Count; i++)
                            {
                                column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                            }

                           
                            //sw = new StreamWriter(filename);
                            for (int r = 0; r < DataObject.RowCount; r++)
                            {

                                for (int i = 0; i < column_fields.Length; i++)
                                {
                                    sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
                                    if (i != column_fields.Length - 1)
                                        sw.Write(sep);
                                }
                                if (r != DataObject.RowCount - 1)
                                    sw.Write("\r\n");
                                return DataObject.RowCount;
                            }
                        }
                        if (sw != null)
                        {
                            sw.Close();
                        }
                    }
                    GC.Collect();
                }
                return 1;
            }
            catch(Exception ex)
            {
                return -1;
            }
            GC.Collect();
            return 0;
            //if (filename == null || filename == "")
            //{
            //    DialogResult i_return;
            //    SaveFileDialog file_dia = new SaveFileDialog();
            //    file_dia.Title = "Save As";
            //    file_dia.DefaultExt = "txt";
            //    file_dia.Filter = "Text|*.txt|CSV|*.csv";
            //    i_return = file_dia.ShowDialog();
            //    if (i_return == DialogResult.Cancel)
            //        return 0;
            //    filename = file_dia.FileName;
            //}
            //StreamWriter sw = null;
            //try
            //{
            //    // set separator charatcer
            //    char sep;
            //    if (saveastype.ToLower() == "text")
            //        sep = '\t';
            //    else if (saveastype.ToLower() == "csv")
            //        sep = ',';
            //    else
            //        throw new Exception("Unsupported save as type.");
            //    // get field info from entity type
            //    System.Reflection.FieldInfo[] column_fields = new System.Reflection.FieldInfo[this.column_name_list.Count];
            //    for (int i = 0; i < column_name_list.Count; i++)
            //    {
            //        column_fields[i] = EntityType.GetField("_" + column_name_list[i], System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.SetField | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //    }

            //    sw = new StreamWriter(filename);
            //    for (int r = 0; r < DataObject.RowCount; r++)
            //    {

            //        for (int i = 0; i < column_fields.Length; i++)
            //        {
            //            sw.Write(ValidateExportValue(column_fields[i].GetValue(DataObject.BindingSource.List[r])));
            //            if (i != column_fields.Length - 1)
            //                sw.Write(sep);
            //        }
            //        if (r != DataObject.RowCount - 1)
            //            sw.Write("\r\n");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return -1;
            //}
            //finally
            //{
            //    if (sw != null)
            //    {
            //        sw.Close();
            //    }
            //}
            //GC.Collect();
            //return DataObject.RowCount;
        }

        private string ValidateExportValue(object value)
        {
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("[,\"\\t\\r\\n]");
            if (value == null)
                return "";
            else if (!(value is string))
                return value.ToString();
            else
            {
                if (rx.Match((string)value).Success)
                    return '"' + ((string)value).Replace("\"", "\"\"") + '"';
                else
                    return (string)value;
            }
        }

        #endregion

        #region URdsDw events

        public virtual int winPfcSave()
        {
            return 1;
        }

        public virtual void ue_deleteitem()
        {
            // allow del key to clear column
            string sName;
            int? lRow;
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
                /*? if (sName.ToLower() == "ct_key") {
                    if (!(StaticVariables.securitymanager.of_get_user().of_isnationaluser()))
                    {
                        if (StaticVariables.securitymanager.of_get_user().of_get_contract_types().RowCount() != StaticVariables.gnv_app.of_gettotalcontracttypes())
                        {
                            return;
                        }
                    }
                }
                if (sName.ToLower() == "region_id") {
                    if (!(StaticVariables.securitymanager.of_get_user().of_isnationaluser()))
                    {
                        return;
                    }
                } */
                if (this.DataObject.GetChild(sName) != null)
                {
                    // PowerBuilder 'Choose Case' statement converted into 'if' statement
                    /*?
                    unknown TestExpr = Upper(Left(this.Describe(sName + ".coltype"), 4));
                    if (TestExpr == "CHAR") {
                        this.SetItem(this.GetRow(), sName, sNull);
                    }
                    else if (TestExpr == "NUMB" || TestExpr == "DECI") {
                        this.SetItem(this.GetRow(), sName, lNull);
                    }
                    else if (TestExpr == "DATE") {
                        this.SetItem(this.GetRow(), sName, dNull);
                    }
                     */
                }
            }
        }

        public virtual void ue_saveas()
        {
            //?SaveAs();
        }

        public virtual void URdsDw_EditChanged(object sender, EventArgs args)
        {
            // enable autocomplete
            string sText;
            //if (this.DataObject != null)
            //    Console.WriteLine("++++ URdsDw_EditChanged: " + this.DataObject.ToString());

            //Control control = this.DataObject.GetControlByName(this.GetColumnName());
            string this_ColumnName = this.GetColumnName();
            Control control = this.DataObject.GetControlByName(this_ColumnName);
            if (control != null) // panel tyoe
            {
                sText = control.Text;
                if (sText.Length > 1 && sText.Substring(0, 1) == " ")
                    control.Text = sText.Substring(1);
            }
            else // grid type
            {
                DataGridView grid = (DataGridView)this.DataObject.GetControlByName("grid");
                DataGridViewCell cell = grid.Rows[this.GetRow()].Cells[this.GetColumnName()];
                if (cell is DataGridViewTextBoxCell)
                {
                    sText = (string)cell.Value;
                    if (sText.Substring(0, 1) == " ")
                        cell.Value = sText.Substring(1);
                }
            }
        }

        public virtual void URdsDw_RetrieveEnd(object sender, EventArgs e)
        {
            if (ib_autoinsert && this.RowCount == 0 && ib_AllowCreate)
            {
                this.InsertRow(-1);
            }
            this.of_filter();
        }

        public virtual void URdsDw_DoubleClick(object sender, EventArgs e)
        {
            int row = this.GetRow();
            if (row < 0)
            {
                return;
            }
            // Process backdoor entry columns
            if (StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyCtrl) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyShift) && StaticFunctions.KeyDown(StaticFunctions.KeyIndexes.KeyAlt))
            {
                if (MessageBox.Show("Are you sure you want to unlock all columns?\r\n" 
                                     + "Use this facility only when you cannot access data \r\n" + "that needs to be changed.", "Unlock columns"
                                   , MessageBoxButtons.YesNo
                                   , MessageBoxIcon.Exclamation
                                   , MessageBoxDefaultButton.Button2) 
                    == DialogResult.Yes)
                {
                    of_unprotectColumns();
                    this.of_SetUpdateable(true);
                    MessageBox.Show("All columns have been unprotected."
                                     , "Unlock columns"
                                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public virtual void constructor()
        {
            // Set up transaction object
            ib_RegionColumnFound = this.of_hascolumn("region_id");
            ids_UserComponentRegions = new DataUserControlContainer();
            ids_UserComponentRegions.DataObject = new NZPostOffice.RDS.DataControls.Ruralsec.DUserComponentRegionlist();
        }

        public virtual void URdsDw_Itemchanged(object sender, EventArgs e)
        {
            //if (this.DataObject != null)
            //    Console.WriteLine("++++ URdsDw_ItemChanged: " + this.DataObject.ToString());

            //?this.ue_PostItemChanged(row, dwo, data);
        }

        public virtual void URdsDw_Clicked(object sender, EventArgs e)
        {
            // Make sure we have a place to process post-clicks
            //?this.ue_postclicked(xpos, ypos, row, dwo);
        }

        protected virtual void pfc_insertrow()
        {
            if (PfcPreInsertRow != null && PfcPreInsertRow() == 1)
            {
                int ll_Row = this.GetRow();
                ll_Row = this.InsertRow(ll_Row);
                this.DataObject.SetCurrent(ll_Row);
                //?this.of_filter();
            }
        }

        protected virtual void pfc_modify()
        {
            int ll_Row = this.GetRow();
            this.DataObject.SetCurrent(ll_Row);
        }

        protected virtual void pfc_deletetrow()
        {
            if (PfcPreDeleteRow != null && PfcPreDeleteRow() == 1)
            {
                int nRow = this.GetRow();
                //nRow = this.InsertRow(nRow);
                this.DeleteItemAt(nRow);
                //this.DataObject.SetCurrent(ll_Row);
                //this.of_filter();
            }
        }

        //added by jlwang
        protected virtual bool winvalidate()
        {
            return true;
        }

        protected virtual int pfc_preupdate()
        {
            //?base.pfc_preupdate();
            //int lActionCode = 0;
            //ilRow = this.GetNextModified(-1);
            //while (ilRow >= 0)
            //{
            //    isErrorColumn = "";
            //    StaticMessage.WordParm = 0;
            //    StaticMessage.LongParm = ilRow;
            //    this.ue_validate();
            //     if (IsValid(inv_AuditManager) && StaticVariables.gnv_app.of_isempty(isErrorColumn) && ib_audittoggle) {
            //        inv_AuditManager.of_registerdw(this);
            //        inv_AuditManager.of_setdata(inv_AuditAttrib);
            //        inv_AuditManager.of_writeaudit(ilRow, this.isTag);
            //    } 
            //    if (!(StaticFunctions.f_isempty(isErrorColumn)))
            //    {
            //        this.SetCurrent(ilRow);
            //        this.SetColumn(isErrorColumn);
            //        lActionCode = 1;
            //        ilRow = 0;
            //    }
            //    else
            //    {
            //        ilRow = this.GetNextModified(ilRow);
            //    }
            //}
            return 1;
        }

        protected virtual void pfc_postupdate()
        {
        }

        protected virtual void pfc_prermbmenu()
        {
            MMainMenu lm_SheetMenu;
            MMainMenu lm_FrameMenu;
            MRdsDw lm_Dw;
            int ll_Temp;
            lm_Dw = this.mRdsDw;  

            lm_SheetMenu = ((WMaster)this.Parent.FindForm()).m_sheet;  

            // Process frame menu
            lm_FrameMenu = ((WMainMdi)StaticVariables.MainMDI).m_main_menu; 
            if (lm_FrameMenu != null)
            {
                lm_FrameMenu.of_set_editoff();
            }
            // Turn off sheet menuitems
            if (lm_SheetMenu != null)
            {
                lm_SheetMenu.of_set_editoff();
            }
            // Turn off rmb menu items

            lm_Dw.m_insert.Enabled = false; 
            lm_Dw.m_insert.Visible = false;
            lm_Dw.m_modify.Enabled = false;
            lm_Dw.m_modify.Visible = false;
            lm_Dw.m_delete.Enabled = false; 
            lm_Dw.m_delete.Visible = false;  
            lm_Dw.m_savechangestodatabase.Enabled = false; 
            lm_Dw.m_savechangestodatabase.Visible = false; 

            // Process the rmb menuitems
            if (this.of_GetUpdateable())
            {
                if (this.of_get_createpriv())
                {
                    if (lm_SheetMenu != null)
                    {
                        lm_SheetMenu.of_set_insertrow();
                    }

                    lm_Dw.m_insert.Enabled = true; 
                    lm_Dw.m_insert.Visible = true; 
                    lm_Dw.m_savechangestodatabase.Enabled = true; 
                    lm_Dw.m_savechangestodatabase.Visible = true; 
                }
                if (this.of_get_modifypriv())
                {
                    if (lm_SheetMenu != null)
                    {
                        lm_SheetMenu.of_set_update();
                    }

                    lm_Dw.m_savechangestodatabase.Enabled = true; 
                    lm_Dw.m_savechangestodatabase.Visible = true; 

                }
                if (this.of_get_deletepriv())
                {
                    if (lm_SheetMenu != null)
                    {
                        lm_SheetMenu.of_set_deleterow();
                    }

                    lm_Dw.m_delete.Enabled = true;
                    lm_Dw.m_delete.Visible = true;
                    lm_Dw.m_savechangestodatabase.Enabled = true;
                    lm_Dw.m_savechangestodatabase.Visible = true;
                }
            }
            /*?
            if (inv_RowSelect != null)
            {
                if (inv_RowSelect.of_GetStyle() == 1 || inv_RowSelect.of_GetStyle() == 2)
                {
                    if (IsValid(lm_SheetMenu))
                    {
                        lm_SheetMenu.m_Edit.m_SelectAll.Enabled = true;
                    }
                    if (IsValid(lm_SheetMenu))
                    {
                        lm_SheetMenu.m_Edit.m_SelectAll.visible = true;
                    }
                    lm_Dw.m_table.m_SelectAll.Enabled = true;
                    lm_Dw.m_table.m_SelectAll.Visible = true;
                }
            }
            // Don't forget to assign current dw as parent
            lm_Dw.of_setparent(this);
            am_dw = lm_Dw;
             */
        }

        public bool showUpdateToolButton = false;

        public virtual void URdsDw_GetFocus(object sender, EventArgs e)
        {
            MSheet lm_SheetMenu = null;
            MMainMenu lm_FrameMenu = null;
            MRdsDw lm_Dw = null;
            //if (this.DataObject != null)
            //    Console.WriteLine("++++ URdsDw_GetFocus: " + this.DataObject.ToString());

            lm_Dw = this.mRdsDw;
            if (this.Visible)
                lm_SheetMenu = ((WMaster)this.Parent.FindForm()).m_sheet;
            else
                return;
            // Process frame menu
            if (StaticVariables.gnv_app.of_getframe() != null)
            {
                lm_FrameMenu = ((WMainMdi)StaticVariables.MainMDI).m_main_menu;
            }
            if (lm_FrameMenu != null)
            {
                lm_FrameMenu.of_set_editoff();
            }
            if (lm_SheetMenu == null)
            {
                //added by jlwang for window that without menu

                if (this.DataObject != null)
                {
                    if (this.of_GetStyle() == 1 || this.of_GetStyle() == 2)
                    {
                        lm_Dw.m_cut.Enabled = true;
                        lm_Dw.m_cut.Visible = true;
                        lm_Dw.m_copy.Enabled = true;
                        lm_Dw.m_copy.Visible = true;
                        lm_Dw.m_paste.Enabled = true;
                        lm_Dw.m_paste.Visible = true;
                        lm_Dw.m_dash11.Visible = true;

                        lm_Dw.m_selectall.Enabled = true;
                        lm_Dw.m_selectall.Visible = true;
                    }
                    else
                    {
                        lm_Dw.m_selectall.Visible = false;
                        lm_Dw.m_selectall.Enabled = false;
                    }
                }

                lm_Dw.m_insert.Enabled = false;
                lm_Dw.m_insert.Visible = false;
                lm_Dw.m_modify.Enabled = false;
                lm_Dw.m_modify.Visible = false;
                lm_Dw.m_delete.Enabled = false;
                lm_Dw.m_delete.Visible = false;

                lm_Dw.m_savechangestodatabase.Enabled = false;
                lm_Dw.m_savechangestodatabase.Visible = false;

                if (this.of_GetUpdateable())
                {
                    if (this.of_get_createpriv())
                    {
                        lm_Dw.m_insert.Enabled = true;
                        lm_Dw.m_insert.Visible = true;
                        lm_Dw.m_savechangestodatabase.Enabled = true;
                        lm_Dw.m_savechangestodatabase.Visible = true;
                    }
                    if (this.of_get_modifypriv())
                    {
                        lm_Dw.m_savechangestodatabase.Enabled = true;
                        lm_Dw.m_savechangestodatabase.Visible = true;
                    }
                    if (this.of_get_deletepriv())
                    {
                        lm_Dw.m_delete.Enabled = true;
                        lm_Dw.m_delete.Visible = true;
                        lm_Dw.m_savechangestodatabase.Enabled = true;
                        lm_Dw.m_savechangestodatabase.Visible = true;
                    }
                }
                return;
            }

            // Turn off sheet menuitems
            lm_SheetMenu.of_set_editoff();


            //?if (inv_RowSelect != null)
            //{
            //    if (inv_RowSelect.of_GetStyle() == 1 || inv_RowSelect.of_GetStyle() == 2)
            //    {
            //        lm_SheetMenu.m_selectall.Enabled = true; //lm_SheetMenu.m_Edit.m_SelectAll.Enabled = true;
            //        lm_SheetMenu.m_selectall.Visible = true; //lm_SheetMenu.m_Edit.m_SelectAll.visible = true;
            //    }
            //}
            if (this.DataObject != null)
            {
                if (this.of_GetStyle() == 1 || this.of_GetStyle() == 2)
                {
                    lm_Dw.m_cut.Enabled = true;
                    lm_Dw.m_cut.Visible = true;
                    lm_Dw.m_copy.Enabled = true;
                    lm_Dw.m_copy.Visible = true;
                    lm_Dw.m_paste.Enabled = true;
                    lm_Dw.m_paste.Visible = true;
                    lm_Dw.m_dash11.Visible = true;
                    lm_Dw.m_selectall.Enabled = true;
                    lm_Dw.m_selectall.Visible = true;
                }
                else
                {
                    lm_Dw.m_selectall.Visible = false;
                    lm_Dw.m_selectall.Enabled = false;
                }
            }

            // Turn off rmb menu items
            lm_Dw.m_insert.Enabled = false;
            lm_Dw.m_insert.Visible = false;
            lm_Dw.m_modify.Enabled = false;
            lm_Dw.m_modify.Visible = false;
            lm_Dw.m_delete.Enabled = false;
            lm_Dw.m_delete.Visible = false;

            lm_Dw.m_savechangestodatabase.Enabled = false;
            lm_Dw.m_savechangestodatabase.Visible = false;

            // Process the rmb menuitems
            if (this.of_GetUpdateable())
            {
                if (this.of_get_createpriv())
                {
                    // TJB  Release 7.1.3 fixups Aug 2010
                    // Added of_set_insertmodify and showUpdateToolButton
                    // to add Update button (m_modify).
                    // Currently only used when working with AddAllowances
                    StaticVariables.URdsDwName = this;
                    if (!showUpdateToolButton)
                    {
                        lm_SheetMenu.of_set_insertrow();
                    }
                    else
                    {
                        // This turns on the toolbar button
                        lm_SheetMenu.of_set_insertmodify();
                        // These turn on the dropdown menu item
                        lm_Dw.m_modify.Enabled = true;
                        lm_Dw.m_modify.Visible = true;
                    }

                    lm_Dw.m_insert.Enabled = true; // lm_Dw.m_table.m_Insert.enabled = true;
                    lm_Dw.m_insert.Visible = true; // lm_Dw.m_table.m_Insert.visible = true;
                    lm_Dw.m_savechangestodatabase.Enabled = true; // lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
                    lm_Dw.m_savechangestodatabase.Visible = true; // lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
                }
                if (this.of_get_modifypriv())
                {
                    StaticVariables.URdsDwName = this;
                    lm_SheetMenu.of_set_update();

                    lm_Dw.m_savechangestodatabase.Enabled = true; // lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
                    lm_Dw.m_savechangestodatabase.Visible = true; // lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
                }
                if (this.of_get_deletepriv())
                {
                    StaticVariables.URdsDwName = this;
                    lm_SheetMenu.of_set_deleterow();

                    lm_Dw.m_delete.Enabled = true; // lm_Dw.m_table.m_Delete.Enabled = true;
                    lm_Dw.m_delete.Visible = true;// lm_Dw.m_table.m_Delete.Visible = true;
                    lm_Dw.m_savechangestodatabase.Enabled = true; // lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
                    lm_Dw.m_savechangestodatabase.Visible = true; // lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
                }
            }
        }

        //protected virtual void rbuttondown()
        //{
        //    /*? base.rbuttondown();
        //    il_RightClicked = row; */
        //}

        public virtual int updatestart()
        {
            /*?int lActionCode = 0;
            ilRow = this.GetNextModified(-1);
            while (ilRow >= 0)
            {
                isErrorColumn = "";
                StaticMessage.WordParm = 0;
                StaticMessage.LongParm = ilRow;
                 this.ue_validate();
                if (IsValid(inv_AuditManager) && !( isErrorColumn.Len() > 0) && ib_audittoggle) {
                    inv_AuditManager.of_registerdw(this);
                    // iu_auditmanager.of_writeaudit ( ilrow,this,this.istag,ist_audit)
                } 
                if (isErrorColumn.Length > 0)
                {
                    this.SetCurrent(ilRow);
                    this.SetColumn(isErrorColumn);
                    lActionCode = 1;
                    ilRow = 0;
                }
                else
                {
                    ilRow = this.GetNextModified(ilRow);
                }
            }
            return lActionCode;*/
            return 0;
        }

        protected virtual void pfc_selectall()
        {
            this.SelectRow(0, true);
            //?return 1;
        }

        protected virtual int pfc_preinsertrow()
        {;
            if (!ib_AllowCreate)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        protected virtual int pfc_predeleterow()
        {
            if (!ib_AllowDelete)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public virtual int uf_setrowsecurity()
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            // long lRow
            // 
            // 
            // 
            // if This.RowCount > 0 then
            // 	lRow = This.GetRow ( )
            // 	if This.GetItemStatus ( lRow, 0, Primary!) = New! or This.GetItemStatus ( lRow, 0, Primary!) = NewModified! then
            // 
            // 		if ist_Instance.Security_Access_Level = 0 or	&
            // 			ist_Instance.Security_Access_Level = 1 or &
            // 			ist_Instance.Security_Access_Level = 3 then 
            // 
            // 			This.Modify ( "datawindow.readonly=yes")
            // 		else
            // 			This.Modify ( "datawindow.readonly=no")
            // 		end if
            // 
            // 	else //not modifying
            // 
            // 		if ist_Instance.Security_Access_Level = 0 & 
            // 			or ist_Instance.Security_Access_Level = 1 & 
            // 			or ist_Instance.Security_Access_Level = 3 & 
            // 			or ist_Instance.Security_Access_Level = 5 then 
            // 			This.Modify ( "datawindow.readonly=yes")
            // 		else
            // 			This.Modify ( "datawindow.readonly=no")
            // 		end if
            // 
            // 	end if //if new
            // 
            // end if //if rowcount
            // 
            return 0;
        }

        public virtual int uf_insertrow()
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            // Date:	 	Feb 19, 2002
            int iReturnValue = 0;
            StaticMessage.ReturnValue = 0;
            //?TriggerEvent("ue_InsertStart");
            if (StaticMessage.ReturnValue == 0)
            {
                iReturnValue = this.InsertRow(-1);
                this.SetCurrent(iReturnValue);
                /*? if (il_First_Column > 0) {
                    this.SetColumn(il_First_Column);
                } */
                //?this.TriggerEvent("ue_InsertEnd");
            }
            StaticMessage.ReturnValue = 0;
            return iReturnValue;
        }

        public virtual int uf_deleterow()
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            int iReturnValue = 1;
            StaticMessage.ReturnValue = 0;
            //?this.TriggerEvent("ue_DeleteStart");
            if (StaticMessage.ReturnValue == 0)
            {
                // audit it
                /*? if (IsValid(inv_AuditManager) && ib_audittoggle) {
                    inv_AuditManager.of_registerdw(this);
                    inv_AuditManager.of_setdata(inv_AuditAttrib);
                    inv_AuditManager.of_writeaudit_delete(GetRow(), this.isTag);
                } */
                this.DataObject.DeleteItemAt(this.GetRow());
                iReturnValue = 0; // DeleteItemAt
                //?this.TriggerEvent("ue_DeleteEnd");
                if (StaticMessage.ReturnValue == 0)
                {
                    if (this.RowCount == 0)
                    {
                        this.uf_insertrow();
                    }
                }
            }
            StaticMessage.ReturnValue = 0;
            return iReturnValue;
        }

        //public virtual int uf_initialise(string[] non_editable_columns, int security_group) {
        //    // Purpose: 	Mostly unused. Migrated from old code
        //    // Author: 	NOT Rex Bustria
        //    int lUpperBound;
        //    int lLoop;
        //    lUpperBound = non_editable_columns.UpperBound;
        //    if (lUpperBound > 0) {
        //        for (lLoop = 1; lLoop <= lUpperBound; lLoop++) {
        //            this.Modify(Non_Editable_Columns[lLoop] + ".Protect=\"0~tif ( isRowNew ( ),0,1)\"");
        //        }
        //    }
        //    return 0;
        //}

        public virtual int uf_resetrows()
        {
            this.DataObject.Reset();
            if (this.RowCount == 0)
            {
                this.uf_insertrow();
            }
            return 0;
        }

        /*!skip these mostly unused code
        public virtual string uf_getchildwhere(string acolumns) {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            int lColumnCount;
            int lLoop;
            string sPrimaryDBName;
            string sChildDBName;
            string sWhere = "";
            lColumnCount = Metex.Common.Convert.ToInt32(this.Describe("Datawindow.Column.Count"));
            for (lLoop = 1; lLoop <= lColumnCount; lLoop++) {
                sPrimaryDBName = this.Describe('#' + lLoop.ToString() + ".dbname");
                sPrimaryDBName =  TextUtil.Mid (sPrimaryDBName, TextUtil.Pos (sPrimaryDBName, '.') + 1);
                if (Pos(acolumns, sPrimaryDBName) > 0) {
                    sChildDBName =  TextUtil.Left(acolumns, TextUtil.Pos (acolumns, " IS " + sPrimaryDBName) - 1);
                    while (Pos(sChildDBName, ',') > 0) {
                        sChildDBName =  TextUtil.Mid (sChildDBName, TextUtil.Pos (sChildDBName, ',') + 1);
                    }
                    if ( sWhere.Len() > 0) {
                        sWhere = sWhere + " and " + sChildDBName + " = ";
                    }
                    else {
                        sWhere = " where " + sChildDBName + " = ";
                    }
                    // PowerBuilder 'Choose Case' statement converted into 'if' statement
                    unknown TestExpr = Upper(Left(this.Describe('#' + lLoop.ToString() + ".ColType"), 4));
                    if (TestExpr == "CHAR") {
                        sWhere = sWhere + '\'' + this.GetItemString(this.GetRow(), lLoop, primary!, true) + '\'';
                    }
                    else if (TestExpr == "NUMB" || TestExpr == "NUME" || TestExpr == "DECI") {
                        sWhere = sWhere + String(this.GetItemSystem.Conver.ToDouble ( this.GetRow( ), lLoop, primary!, true));
                    }
                    else if (TestExpr == "DATE") {
                        sWhere = sWhere + '\'' + this.GetItemDateTime(this.GetRow(.ToString().Date, lLoop, primary!, true), "yyyy-mm-dd") + '\'';
                    }
                }
            }
            return sWhere;
        } */

        public virtual bool uf_not_unique(int arow, string acolumn, string amessage)
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            bool bReturn = false;
            string sFindString = "Not Valid";
            string sSQLWhere;
            string sSQLTable;
            string sString;
            int lRow;
            int lRowCount;
            //sSQLTable = this.Describe("datawindow.table.updatetable");
            //unknown TestExpr = Upper(Left(this.Describe(acolumn + ".coltype"), 4));
            //if (TestExpr == "CHAR") {
            //    sString = this.GetItemString(arow, acolumn);
            //    if (!(StaticVariables.gnv_app.of_isempty(sString))) {
            //        if (Pos(sString, '\'') == 0) {
            //            sFindString = acolumn + " = \'" + this.GetItemString(arow, acolumn) + '\'';
            //        }
            //        else if (Pos(sString, '\"') == 0) {
            //            sFindString = acolumn + " = \"" + this.GetItemString(arow, acolumn) + '\"';
            //        }
            //        sSQLWhere = this.Describe(acolumn + ".dbName") + "= \'" + this.GetItemString(arow, acolumn) + '\'';
            //    }
            //}
            //else if (TestExpr == "NUME" || TestExpr == "NUMB" || TestExpr == "DECI") {
            //    if (!(f_nEmpty(this.GetItemNumber(arow, acolumn)))) {
            //        sFindString = acolumn + " = " + String(this.GetItemNumber(arow, acolumn));
            //        sSQLWhere = this.Describe(acolumn + ".dbName") + "= " + String(this.GetItemNumber(arow, acolumn));
            //    }
            //}
            //else if (TestExpr == "DATE") {
            //    if (!(IsNull(this.GetItemDateTime(arow, acolumn).Date))) {
            //        sFindString = acolumn + " = date ( \'" + String(this.GetItemDateTime(arow, acolumn).Date, "YYYY-MM-DD") + "\')";
            //        sSQLWhere = this.Describe(acolumn + ".dbName") + "= \'" + String(this.GetItemDateTime(arow, acolumn).Date, "YYYY-MM-DD") + '\'';
            //    }
            //}
            //if (sFindString != "Not Valid") {
            //    lRowCount = this.RowCount;
            //    lRow = this.Find( sFindString ).Length;
            //    if (lRow < arow) {
            //        bReturn = true;
            //    }
            //    else if (lRowCount > arow) {
            //        lRow = this.Find( sFindString ).Length;
            //        if (lRow > 0) {
            //            bReturn = true;
            //        }
            //    }
            //}
            //if (bReturn) {
            //    f_StdMessage("duplicate", StaticVariables.gnv_app.of_get_activesheet().Title, amessage, "", ok!);
            //}
            //return bReturn;
            if (this.GetValue(arow, acolumn) != null)
            {
                lRowCount = this.RowCount;
                //lRow = this.Find(acolumn, this.GetValue(arow, acolumn));
                lRow = this.FindWithStartRow(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>(acolumn, this.GetValue(arow, acolumn)) }, false, 0, this.RowCount);
                if (lRow < arow)
                {
                    bReturn = true;
                }
                else if (lRowCount > arow + 1)
                {
                    //lRow = this.Find(acolumn, this.GetValue(arow, acolumn));
                    lRow = this.FindWithStartRow(new KeyValuePair<string, object>[] { new KeyValuePair<string, object>(acolumn, this.GetValue(arow, acolumn)) }, false, arow + 1, this.RowCount);
                    if (lRow > arow)// -1)
                    {
                        bReturn = true;
                    }
                }
            }
            if (bReturn)
            {
                StaticFunctions.f_stdmessage("duplicate", NZPostOffice.Shared.StaticVariables.MainMDI.ActiveMdiChild.Text/*StaticVariables.gnv_app.of_get_activesheet().Title*/, amessage, "", MessageBoxButtons.OK);
            }
            return bReturn;
        }

        public int FindWithStartRow(KeyValuePair<string, object>[] Pair, bool ignoreCase, int startrow, int endrow)
        {
            if (startrow < 0)
                startrow = 0;
            if (endrow > this.RowCount)
                endrow = this.RowCount;
            List<KeyValuePair<string, object>> findPair = new List<KeyValuePair<string, object>>(Pair);
            for (int i = startrow; i < endrow; i++)
            {
                bool flag = false;
                foreach (KeyValuePair<string, object> pair in findPair)
                {
                    object obj3 = this.GetValue(i, pair.Key);// obj2.GetType().GetProperty(this.migrateName(pair.Key).Trim()).GetValue(obj2, null);
                    if (((obj3 != null) && obj3.Equals(pair.Value)) || (obj3 == null && obj3 == pair.Value))
                    {
                        flag = true;
                        continue;
                    }
                    if ((obj3 != null) && pair.Value != null && (pair.Value.GetType() == typeof(string)))
                    {
                        string text = obj3.ToString();
                        string text2 = pair.Value.ToString();
                        if (ignoreCase)
                        {
                            text = text.ToLower();
                            text2 = text2.ToLower();
                        }
                        if (text == text2)
                        {
                            flag = true;
                            continue;
                        }
                        if (text2.StartsWith("%") && text2.EndsWith("%"))
                        {
                            if (text.IndexOf(text2) >= 0)
                            {
                                flag = true;
                            }
                            continue;
                        }
                        if (text2.StartsWith("%"))
                        {
                            if (text.EndsWith(text2.Trim(new char[] { '%' })))
                            {
                                flag = true;
                            }
                            continue;
                        }
                        if (text2.EndsWith("%"))
                        {
                            if (text.StartsWith(text2.Trim(new char[] { '%' })))
                            {
                                flag = true;
                            }
                            continue;
                        }
                        flag = false;
                    }
                    else
                    {
                        flag = false;
                    }
                    break;
                }
                if (flag)
                {
                    return i;
                }
            }
            return -1;
        }

        public string migrateName(string pbname)
        {
            while (pbname.IndexOf('_') >= 0)
            {
                pbname = pbname.Substring(0, 1).ToUpper() + pbname.Substring(1, pbname.IndexOf('_') - 1) + pbname.Substring(pbname.IndexOf('_') + 1, 1).ToUpper() + pbname.Substring(pbname.IndexOf('_') + 2).ToLower();
            }

            if (pbname.Length > 1)
                pbname = pbname.Substring(0, 1).ToUpper() + pbname.Substring(1, pbname.Length - 1);
            return pbname;
        }

        public string reversemigrateName(string cname)
        {
            string ls_return = "";
            for (int i = 0; i < cname.ToCharArray().GetLength(0); i++)
            {
                if (char.IsUpper(cname.ToCharArray()[i]))
                {
                    ls_return += "_" + cname.ToCharArray()[i].ToString().ToLower();
                }
                else
                {
                    ls_return += cname.ToCharArray()[i];
                }
            }
            if (ls_return.Length > 1)
            {
                ls_return = ls_return.Substring(1);
            }
            return ls_return;
        }

        public Dictionary<string, string> translateColName(Type type)
        {
            Dictionary<string, string> dict = new Dictionary<string,string>();
            object[] MapInfoList = type.GetCustomAttributes(typeof(MapInfo), false);
            foreach (MapInfo info in MapInfoList)
            {
                dict[info.objFieldName.Replace("_", "")] = info.DBFieldName;
            }
            return dict;
        }

        public virtual bool uf_not_entered(int arow, string acolumn, string amessage)
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            bool lReturn = false;
            acolumn = migrateName(acolumn);
            if (StaticFunctions.GetValueUsingReflection(this.DataObject, arow, acolumn) == null)
            {
                StaticFunctions.f_stdmessage("mandatory", this.ParentForm.Text, amessage, "", MessageBoxButtons.OK);
                lReturn = true;
            }
            return lReturn;
        }

        //add by mkwang
        public virtual bool uf_not_entered_deci(int arow, string acolumn, string amessage)
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            bool lReturn = false;
            acolumn = migrateName(acolumn);
            if (StaticFunctions.GetValueUsingReflectionDecmi(this.DataObject, arow, acolumn) == 0)
            {
                StaticFunctions.f_stdmessage("mandatory", this.ParentForm.Text, amessage, "", MessageBoxButtons.OK);
                lReturn = true;
            }
            return lReturn;
        }

        public virtual int uf_settag(string stag)
        {
            // Purpose: 	Mostly unused. Migrated from old code
            // Author: 	NOT Rex Bustria
            isTag = stag;
            return 0;
        }

        public virtual int uf_setauditcolumns(string a_column)
        {
            /*?
            int l_subscript;
            inv_AuditAttrib[inv_AuditAttrib.UpperBound + 1] = new n_audit_attrib();
            l_subscript = inv_AuditAttrib.UpperBound;
            inv_AuditAttrib[l_subscript].column_name = a_column;
            inv_AuditAttrib[l_subscript].column_datatype = Describe(a_column + ".coltype");
            inv_AuditAttrib[l_subscript].column_dbname = Describe(a_column + ".dbname");
            inv_AuditAttrib[l_subscript].table = Describe("datawindow.table.UpdateTable");
            // messagebox ( "Table:"+describe ( "datawindow.table.UpdateTable"),  ' subscr:'+l_subscript.ToString() + "Datatype:"+ist_audit[l_subscript].column_datatype +" dwcol:"+a_column+" db column:"+ist_audit[l_subscript].column_dbname)
             */
            return 0;
        }

        public virtual bool uf_toggle_audit(bool baudit)
        {
            // Purpose: 	Toggle auditing
            ib_audittoggle = baudit;
            return ib_audittoggle;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Height = 139;
            this.Width = 162;
            this.ResumeLayout();
        }

        #region MarkedCode
        //public virtual bool of_setautoinsert(bool ab_autoinsert)
        //{
        //    // Purpose: 	Set autoinsert property
        //    // 					-migrated from old code
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    ib_autoinsert = ab_autoinsert;
        //    return ib_autoinsert == ab_autoinsert;
        //}


        //public virtual int of_setup_calendar() {
        //    // Purpose: 	Set up dropdown calendar - PFC 6.5 version quite buggy
        //    // 					- therefore not used
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    string sObjectList;
        //    string sObject;
        //    string ls_Coltype;
        //    string sTab = '~';
        //    sObjectList = this.Describe("Datawindow.Objects");
        //    while ( sObjectList.Len() > 0) {
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        ls_Coltype = Describe(sObject + ".ColType");
        //        if (Pos(Upper(ls_Coltype), "DATE") > 0) {
        //            this.iuo_Calendar.of_register(sObject, this.iuo_Calendar.DDLB);
        //        }
        //    }
        //    return 1;
        //} 

        //public virtual int of_filter_contracttypes()
        //{
        //    string sObjectList;
        //    string sObject;
        //    string ls_Coltype;
        //    string sTab = "\\";
        //    int ll_Ret;
        //    DataUserControl lds_user_contract_types;
        //    DataUserControl dwc_contract_type;
        //    bool lbDefaulManaged = false;
        //    // See if bypassed
        //    if (ib_BypassContractTypeFilter)
        //    {
        //        return SUCCESS;
        //    }
        //    Control ct_key_control = this.DataObject.GetControlByName("ct_key");
        //    if(ct_key_control != null) // panel
        //    {
        //        if(ct_key_control is DataEntityCombo)
        //        {
        //            //  Only proceed the following check if the user contract types have
        //            //  not been filtered.
        //            // Retrieve cached contract types for the user
        //            lds_user_Contract_Types = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_contract_types();
        //            dwc_contract_type = this.DataObject.GetChild(sObject);
        //            if (lds_user_Contract_Types.RowCount() == StaticVariables.gnv_app.of_gettotalcontracttypes()) {
        //                // SR#4355 Only default the COntract TYpe to 'RD' when
        //                // the column does not have an assigned value
        //                if (this.RowCount > 0) {
        //                    ll_Ret = this.GetItemNumber(1, "ct_key");
        //                    if (IsNull(ll_Ret) || ll_Ret <= 0) {
        //                        this.SetItem(1, sObject, 1);
        //                    }
        //                    lbDefaulManaged = true;
        //                }
        //            }
        //            else {
        //                // Repopulate the datawindowchild based on the current user id
        //                dwc_contract_type.Reset();
        //                // ll_Ret = lds_user_Contract_Types.ShareData ( dwc_contract_type)
        //                //?lds_user_contract_types.RowCopy<>(1, lds_user_Contract_Types.RowCount, , dwc_contract_type, 1);
        //                dwc_contract_type.ResetUpdate();
        //                // SR#4355 Only default the COntract TYpe to 'RD' when
        //                // the column does not have an assigned value
        //                if (this.RowCount > 0) {
        //                    ll_Ret = this.GetItemNumber(1, "ct_key");
        //                    if (ll_Ret > 0) {
        //                        lbDefaulManaged = true;
        //                    }
        //                }
        //                if (lbDefaulManaged == false) {
        //                    //  THe datawindow does not have a row yet and
        //                    //  hence cannot manage the default
        //                    ll_Ret = dwc_contract_type.Find("ct_key", 1);
        //                    if (ll_Ret > 0) {
        //                        this.SetItem(1, sObject, 1);
        //                    }
        //                    else {
        //                        ll_Ret = dwc_contract_type.GetItemNumber(1, "ct_key");
        //                        // Protect column if no access
        //                        if (ll_Ret == -99) {
        //                            dwc_contract_type.FilterString = "ct_key = -99";
        //                            typeof(DataUserControl).GetMethod("Filter").MakeGenericMethod(new Type[] { this.EntityType }).Invoke(dwc_contract_type, new object[] {});
        //                            // Modify (  sObject + '.Protect="0~tif ( isRowNew ( ),1,1)"')
        //                            // Modify (  sObject + ".Background.Color='79216776'")
        //                            // Modify (  sObject + ".Background.Color='13160660'")
        //                        }
        //                        this.SetItem(1, sObject, ll_Ret);
        //                    }
        //                }
        //                if (dwc_contract_type.RowCount == 1) {
        //                    Modify(sObject + ".Protect=\"0~tif ( isRowNew ( ),1,1)\"");
        //                    Modify(sObject + ".Background.Color=\'79216776\'");
        //                }
        //            }
        //        }
        //    return 1;
        //}

        //public virtual int of_set_filter_ContractTypes(bool ab_filter)
        //{
        //    ib_Filter_ContractTypes = ab_filter;
        //    return 1;
        //}

        //public virtual int of_filter()
        //{
        //    if (this.ib_Filter_ContractTypes)
        //    {
        //        this.of_filter_contracttypes();
        //    }
        //    this.of_filter_regions();
        //    return 1;
        //}

        //public virtual int of_filter_regions()
        //{
        //    return of_filter_regions(this.of_get_componentname());
        //    // Purpose: 	Filter the user's default region
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    string sObjectList;
        //    string sObject;
        //    string ls_Coltype;
        //    string sTab = '~';
        //    int ll_Ret;
        //    int ll_DefaultRegion;
        //    DataControlBuilder dwc_contract_type;
        //    // Get the user's default region
        //    ll_DefaultRegion = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
        //    // Get Objects list
        //    sObjectList = this.Describe("Datawindow.Objects");
        //    while ( sObjectList.Len() > 0) {
        //        // Extract an object name
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        // Is it region id?
        //        if (Pos(sObject, "region_id") > 0) {
        //            // Determine if dddw 
        //            ls_Coltype = this.Describe(sObject + ".dddw.name");
        //            // If no, get next object name
        //            if (ls_Coltype == '!' || ls_Coltype == '?') {
        //                continue;
        //            }
        //            // Set the Region
        //            if (ll_DefaultRegion >= 0) {
        //                this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
        //                this.Modify("Region_Id.Protect=1");
        //                this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
        //                // 			This.Modify ( "Region_Id.Background.Color='13160660'")
        //            }
        //        }
        //    }
        //    return SUCCESS;
        //}

        //public virtual int of_protectcolumns()
        //{
        //    // Purpose: 	Protect all columns
        //    // Author: 	NOT Rex Bustria
        //    int ll_Ctr = 0;
        //    string ls_Coltype;
        //    string ls_Describe;
        //    string sObjectList;
        //    string sObject;
        //    string sTab = '~';
        //    string ls_Result;
        //    sObjectList = Describe("Datawindow.Objects");
        //    while ( sObjectList.Len() > 0) {
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        ls_Result = Describe(sObject + ".Background.Color");
        //        // 16776960
        //        // 79216776, 1073741824)
        //        // Modify (  sObject + ".Background.Color='79216776'")
        //        if (ls_Result == "16776960") {
        //            ls_Result = Modify(sObject + ".Background.Color=\'16776960~tIf ( IsRowNew ( ),16776960,79216776)\'");
        //        }
        //        else {
        //            ls_Result = Modify(sObject + ".Background.Color=\'79216776~tIf ( IsRowNew ( ),1073741824,79216776)\'");
        //        }
        //        ls_Describe = this.Describe(sObject + ".edit.name");
        //        if (ls_Describe != '!') {
        //            // This.Modify (  sObject + ".Edit.DisplayOnly=Yes")
        //        }
        //        ls_Describe = this.Describe(sObject + ".editmask.name");
        //        if (ls_Describe != '!') {
        //            this.Modify(sObject + ".EditMask.DisplayOnly=Yes");
        //        }
        //        ls_Result = this.Modify(sObject + ".Protect=\'1~tIf ( IsRowNew ( ),0,1)\'");
        //        // 	ls_Describe = This.Describe ( sObject+ ".dddw.DataColumn")
        //        // 	If ls_Describe <> '!' and ls_Describe <> '?' THEN
        //        // 		//This.Modify (  sObject + ".Tabsequence=0")
        //        // 	End if
        //    }
        //    return 0;
        //}

        //public virtual int of_unprotectColumns()
        //{
        //    // Purpose: 	Unprotect columns. Migrated from old code
        //    // Author: 	NOT Rex Bustria
        //    this.DataObject.Enaled = true;
        //    while ( sObjectList.Len() > 0) {
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        if (Modify(sObject + ".Protect=\"0~tif ( isRowNew ( ),0,0)\"") == "") {
        //            ll_Ctr++;
        //            SetTabOrder(sObject, ll_Ctr);
        //        }
        //    } 
        //    return 0;
        //}

        //public virtual int of_set_regionid(int al_regionId)
        //{
        //    il_RegionId = al_regionId;
        //    return SUCCESS;
        //}

        //public virtual int of_get_regionid()
        //{
        //    return il_RegionId;
        //}

        //public virtual int of_set_readpriv(bool ab_priv)
        //{
        //    ib_AllowRead = ab_priv;
        //    return SUCCESS;
        //}

        //public virtual int of_set_createpriv(bool ab_priv)
        //{
        //    ib_AllowCreate = ab_priv;
        //    return SUCCESS;
        //}

        //public virtual int of_set_modifypriv(bool ab_priv)
        //{
        //    ib_AllowModify = ab_priv;
        //    return SUCCESS;
        //}

        //public virtual int of_set_deletepriv(bool ab_priv)
        //{
        //    ib_AllowDelete = ab_priv;
        //    return SUCCESS;
        //}

        //public virtual bool of_get_readpriv()
        //{
        //    return ib_AllowRead;
        //}

        //public virtual bool of_get_createpriv()
        //{
        //    return ib_AllowCreate;
        //}

        //public virtual bool of_get_modifypriv()
        //{
        //    return ib_AllowModify;
        //}

        //public virtual bool of_get_deletepriv()
        //{
        //    return ib_AllowDelete;
        //}

        //public virtual bool uf_setaudit(bool ab_Audit)
        //{
        //    ib_setaudit = ab_Audit;
        //    if (ib_setaudit == true && !(IsValid(inv_AuditManager))) {
        //        inv_AuditManager = new URdsAuditmanager();
        //    }
        //    return ib_setaudit;
        //}

        //public virtual int of_bypasscontracttypefilter(bool ab_Bypass)
        //{
        //    ib_BypassContractTypeFilter = ab_Bypass;
        //    return SUCCESS;
        //}

        //public virtual int zof_filter_regions()
        //{
        //    // Purpose: 	Filter the user's default region
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    string sObjectList;
        //    string sObject;
        //    string ls_Coltype;
        //    string sTab = '~';
        //    int ll_Ret;
        //    int ll_DefaultRegion;
        //    DataControlBuilder dwc_contract_type;
        //    // Get the user's default region
        //    ll_DefaultRegion = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
        //    // Get Objects list
        //    sObjectList = this.Describe("Datawindow.Objects");
        //    while ( sObjectList.Len() > 0) {
        //        // Extract an object name
        //        if (Pos(sObjectList, sTab) > 0) {
        //            sObject =  TextUtil.Left(sObjectList, TextUtil.Pos (sObjectList, sTab) - 1);
        //            sObjectList =  TextUtil.Mid (sObjectList, TextUtil.Pos (sObjectList, sTab) + 1);
        //        }
        //        else {
        //            sObject = sObjectList;
        //            sObjectList = "";
        //        }
        //        // Is it region id?
        //        if (Pos(sObject, "region_id") > 0) {
        //            // Determine if dddw 
        //            ls_Coltype = this.Describe(sObject + ".dddw.name");
        //            // If no, get next object name
        //            if (ls_Coltype == '!' || ls_Coltype == '?') {
        //                continue;
        //            }
        //            // Set the Region
        //            if (ll_DefaultRegion >= 0) {
        //                this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
        //                this.Modify("Region_Id.Protect=1");
        //                this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
        //                // 			This.Modify ( "Region_Id.Background.Color='13160660'")
        //            }
        //        }
        //    }
        //    return SUCCESS;
        //}

        //public virtual int of_filter_regions(string as_componentname)
        //{
        //    // Purpose: 	Filter the user's default region
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    //  PBY 03/09/2002 SR#4450
        //    // /See if bypassed
        //    if (ib_BypassRegionFilter) {
        //        return SUCCESS;
        //    }
        //    // If not ib_RegionColumnFound Then
        //    if (!(this.of_hascolumn("region_id"))) {
        //        return SUCCESS;
        //    }
        //    bool lb_HasAccessToOwnRegion;
        //    string ls_Region = "";
        //    string ls_Filter;
        //    string ls_TabCharacter = '~';
        //    int ll_Ret;
        //    int ll_DefaultRegion;
        //    int ll_Region;
        //    int ll_Ctr;
        //    int ll_NumRegions = 0;
        //    DataControlBuilder ldwc;
        //    DataControlBuilder dwc_contract_type;
        //    // Get the user's default region
        //    ll_DefaultRegion = StaticVariables.gnv_app.of_get_securitymanager().of_get_user().of_get_regionid();
        //    // Get regions user is allowed to see for the component
        //    if (ids_UserComponentRegions.RowCount == 0) {
        //        ll_Ret = ids_UserComponentRegions.Retrieve(StaticVariables.gnv_app.of_getuserid(), as_componentname);
        //    }
        //    // Create filter expression
        //    // ls_Filter = " region_id in  ( " +ll_DefaultRegion.ToString()+','
        //    ls_filter = " region_id in  ( ";
        //    // Scan region ids to build regions list
        //    for (ll_ctr = 1; ll_ctr <= ids_UserComponentRegions.RowCount; ll_ctr++) {
        //        ll_region = ids_UserComponentRegions.GetItemNumber(ll_ctr, "region_id");
        //        ls_filter += ll_region.ToString() + ',';
        //        if (ll_region == 0 || ll_DefaultRegion == ll_region) {
        //            lb_hasaccesstoownregion = true;
        //        }
        //        ll_numregions++;
        //    }
        //    // Add user's own region
        //    if (lb_hasaccesstoownregion == true) {
        //        ls_filter += ll_DefaultRegion.ToString() + ',';
        //    }
        //    // Remove trailing commas
        //    if (Right(ls_filter, 1) == ',') {
        //        ls_filter =  TextUtil.Left(ls_filter,  ls_filter.Len() - 1);
        //    }
        //    // Add trailing )
        //    if ( ls_filter.Len() > 0) {
        //        ls_filter += ')';
        //    }
        //    // Final check for national users
        //    if (lb_hasaccesstoownregion && IsNull(ll_DefaultRegion)) {
        //        ls_filter = "region_id > 0";
        //    }
        //    this.GetChild("region_id", ldwc);
        //    if (ll_numregions > 0) {
        //        ldwc.SetFilter(ls_filter);
        //        ldwc.Filter();
        //        // Set the Region
        //        if (ll_numregions == 1 && ll_DefaultRegion > 0) {
        //            this.Modify("Region_Id.Protect=1");
        //            this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
        //        }
        //        if (lb_hasaccesstoownregion) {
        //            if (ll_DefaultRegion > 0) {
        //                this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
        //            }
        //        }
        //        else {
        //            ll_region = ids_UserComponentRegions.GetItemNumber(1, "region_id");
        //            this.Modify("region_id.initial=\'" + ll_region.ToString() + '\'');
        //        }
        //    }
        //    else if (lb_hasaccesstoownregion) {
        //        ls_filter = "region_id = " + ll_DefaultRegion.ToString();
        //        ldwc.SetFilter(ls_filter);
        //        ldwc.Filter();
        //        this.Modify("region_id.initial=\'" + ll_DefaultRegion.ToString() + '\'');
        //    }
        //    else {
        //        ls_filter = "region_id = -99";
        //        ldwc.SetFilter(ls_filter);
        //        ldwc.Filter();
        //        ldwc.InsertRow(0);
        //        ldwc.SetItem(1, "region_id", -(99));
        //        ldwc.SetItem(1, "rgn_Name", "<No Access>");
        //        this.Modify("Region_Id.Protect=1");
        //        this.(7)DataControl["Region_Id"].BackColor =\'79216776\'");
        //        this.Modify("region_id.initial=\'-99\'");
        //    }
        //    return SUCCESS;
        //}

        //public virtual bool of_hascolumn(string as_columnname)
        //{
        //    // Purpose: 	Filter the user's default region
        //    // Author: 	Rex Bustria
        //    // Date:	 	Feb 19, 2002
        //    if (this.DataObject == null)
        //        return false;
        //    if (this.DataObject.GetControlByName(as_columnname) != null)
        //        return true;
        //    else if (this.DataObject.GetControlByName("grid") != null)
        //        return ((DataEntityGrid)this.DataObject.GetControlByName("grid")).Columns.Contains(as_columnname);
        //    else
        //        return false;
        //}

        //public virtual int of_bypassregionfilter(bool ab_Bypass)
        //{
        //    ib_BypassRegionFilter = ab_Bypass;
        //    return SUCCESS;
        //}

        //public virtual void uf_settoolbar()
        //{
        //    //  TJB  Release 6.8.9 fixup  Nov 2005  NEW
        //    //  Set the toolbar according to the privileges set for
        //    //  this datawindow  ( via the of_set_xxxxxPriv functions)
        //    MMainMenu lm_SheetMenu;
        //    MMainMenu lm_FrameMenu;
        //    MRdsDw lm_Dw;
        //    WMaster lw_Master;
        //    lm_Dw = new MRdsDw();
        //    // Get sheet menu
        //    this.of_GetParentWindow(lw_Master);
        //    if (IsValid(lw_Master)) {
        //        lm_SheetMenu = lw_Master.MenuID;
        //    }
        //    else {
        //        return;
        //    }
        //    // Process frame menu
        //    if (IsValid(StaticVariables.gnv_app.of_getframe())) {
        //        lm_FrameMenu = StaticVariables.gnv_app.of_getframe().MenuID;
        //    }
        //    if (lm_FrameMenu != null) {
        //        lm_FrameMenu.of_set_editoff();
        //    }
        //    if (!(IsValid(lm_SheetMenu))) {
        //        return;
        //    }
        //    // Turn off sheet menuitems
        //    lm_SheetMenu.of_set_editoff();
        //    if (IsValid(inv_RowSelect)) {
        //        if (inv_RowSelect.of_GetStyle() == 1 || inv_RowSelect.of_GetStyle() == 2) {
        //            lm_SheetMenu.m_Edit.m_SelectAll.Enabled = true;
        //            lm_SheetMenu.m_Edit.m_SelectAll.visible = true;
        //        }
        //    }
        //    // Turn off rmb menu items
        //    lm_Dw.m_table.m_Insert.Enabled = false;
        //    lm_Dw.m_table.m_Insert.Visible = false;
        //    lm_Dw.m_table.m_Delete.Enabled = false;
        //    lm_Dw.m_table.m_Delete.Visible = false;
        //    lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = false;
        //    lm_Dw.m_table.m_SaveChangesToDatabase.Visible = false;
        //    // Process the rmb menuitems
        //    if (this.of_GetUpdateable()) {
        //        if (this.of_get_createpriv()) {
        //            lm_SheetMenu.of_set_insertrow();
        //            lm_Dw.m_table.m_Insert.enabled = true;
        //            lm_Dw.m_table.m_Insert.visible = true;
        //            lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
        //            lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
        //        }
        //        if (this.of_get_modifypriv()) {
        //            lm_SheetMenu.of_set_update();
        //            lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
        //            lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
        //        }
        //        if (this.of_get_deletepriv()) {
        //            lm_SheetMenu.of_set_deleterow();
        //            lm_Dw.m_table.m_Delete.Enabled = true;
        //            lm_Dw.m_table.m_Delete.Visible = true;
        //            lm_Dw.m_table.m_SaveChangesToDatabase.Enabled = true;
        //            lm_Dw.m_table.m_SaveChangesToDatabase.Visible = true;
        //        }
        //    }
        //}

        //public virtual int of_SetUpdateable(bool ab_isupdateable)//ybfan
        //{
        //    ib_IsUpdateable = ab_isupdateable;
        //    return SUCCESS;
        //}

        //public virtual int of_Reset()//ybfan
        //{
        //    int li_rc;
        //    //if (IsValid(inv_Linkage))
        //    //{
        //    //    li_rc = inv_Linkage.of_reset();
        //    //}
        //    //else
        //    //{
        //    //    li_rc = this.Reset();
        //    //}
        //    this.Reset();
        //    return 0;//return li_rc;
        //}

        //public virtual int of_SetRowSelect(bool ab_switch)
        //{
        //    if (ab_switch)
        //    {
        //        if (IsNull(inv_RowSelect) || !(IsValid(inv_RowSelect)))
        //        {
        //            inv_RowSelect = new n_cst_dwsrv_rowselection();
        //            inv_RowSelect.of_setrequestor(this);
        //            return SUCCESS;
        //        }
        //    }
        //    else if (IsValid(inv_RowSelect))
        //    {
        //        inv_RowSelect = null;
        //        return SUCCESS;
        //    }
        //    return NO_ACTION;
        //}

        //public virtual int of_SetResize(bool ab_switch)
        //{
        //    if (ab_switch)
        //    {
        //        if (IsNull(inv_Resize) || !(IsValid(inv_Resize)))
        //        {
        //            inv_Resize = new n_cst_dwsrv_resize();
        //            inv_Resize.of_setrequestor(this);
        //            inv_Resize.of_setorigsize(this.Width, this.Height);
        //            return SUCCESS;
        //        }
        //    }
        //    else if (IsValid(inv_Resize))
        //    {
        //        inv_Resize = null;
        //        return SUCCESS;
        //    }
        //    return NO_ACTION;
        //}

        //public virtual int ModifiedCount()
        //{
        //    int l_count = 0;
        //    for (int row = 0; row < this.DataObject.RowCount; row++)
        //    {
        //        if (((Metex.Core.EntityBase)this.DataObject.BindingSource.List[row]).IsDirty)
        //            l_count++;
        //    }
        //    return l_count;
        //}
        #endregion

        #endregion

   
        //added by jlwang for support selectall
        public const int SINGLE = 0;

        public const int MULTIPLE = 1;

        public const int EXTENDED = 2;

        public int? ii_style = 0;

        public virtual int of_SetStyle(int? ai_style)
        {
            if (ai_style == null)
                return -1;

            switch (ai_style)
            {
                case SINGLE:
                case MULTIPLE:
                case EXTENDED:
                    ii_style = ai_style;
                    return 1;
                    break;
            }
            return -1;
        }

        public virtual int? of_GetStyle()
        {
            return ii_style;
        }
    }

    public struct UsInstance
    {

        public int first_column;

        public DateTime last_updated;

        public int security_access_level;

        public int security_group;

    }
}

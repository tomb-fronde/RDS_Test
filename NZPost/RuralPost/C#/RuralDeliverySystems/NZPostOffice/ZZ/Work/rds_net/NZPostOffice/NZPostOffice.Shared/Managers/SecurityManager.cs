using System;
using System.Collections.Generic;
using System.Text;

using Metex.Core;
using Metex.Core.Security;
using Metex.Windows;

using NZPostOffice.Entity;
using NZPostOffice.DataControls;
using NZPostOffice.Shared.Ruralsec;
using System.Windows.Forms;
using NZPostOffice.Shared.VisualComponents;
using NZPostOffice.DataService;

namespace NZPostOffice.Shared.Security
{
    public class SecurityManager
    {
        private DUserDetails userDetail;
        private DUserGrouplist userGrouplist;
        private DGroupDetails groupDetailsList;
        private DUserGroupRights userGroupRightsList;
        private DDddwFilteredContractTypes filteredContractTypes;
        private DComponentlist componentlist;

        public NRdsUser inv_User;

        public SecurityManager()
        {
            componentlist = new DComponentlist();
            userGrouplist = new DUserGrouplist();
            groupDetailsList = new DGroupDetails();
            userGroupRightsList = new DUserGroupRights();
            filteredContractTypes = new DDddwFilteredContractTypes();
            userDetail = new DUserDetails();
        }

        public string Initialize()
        {
            componentlist.Retrieve();
            int k = userDetail.Retrieve(StaticVariables.LoginId);
            if (k != 1)
            {
                return "Sorry. Your user details have not been set up.";
            }
            // Get user's group memberships
            // No groups - no can do
            if (userGrouplist.Retrieve(StaticVariables.LoginId) <= 0)
            {
                return "Sorry. You are not a member of any user group";
            }
            // For each group membership, initialise a group object
            for (int i = 0; i < userGrouplist.RowCount; i++)
            {
                // Get the id of a group from the group list
                int groupId = userGrouplist.GetItem<UserGrouplist>(i).Id.GetValueOrDefault();
                // Initialise the group object
                groupDetailsList.Retrieve(groupId);
                if (userGroupRightsList.Retrieve(groupId) < 0)
                {
                    return "Failed to initialise group membership.";
                }
            }
            // Initialise Component list
            //!ids_ComponentList = new NRdsComponentlist();
            // Initialise Ds that contains the contract types that the user has access to
            if (filteredContractTypes.Retrieve(StaticVariables.userId) < 0)
            {
                return "Failed to contract type rights.";
            }
            if (filteredContractTypes.RowCount == 0)
            {
                FilteredContractTypes BE = FilteredContractTypes.NewDddwFilteredContractTypes();
                BE.CtKey = -99;
                BE.ContractType = "<No Access>";
                filteredContractTypes.InsertItem<FilteredContractTypes>(0, BE);
            }
            return "";
        }

        public bool CheckPrivilege(string componentName)
        {
            componentlist.FilterString = "Name = '" + componentName + "'";
            componentlist.Filter<Componentlist>();
            if (componentlist.RowCount > 0)
            {
                int componentId = componentlist.GetValue<int>(0, "Id");
                return HasPrivilege(componentId, "", "");
            }
            else
            {
                return false;
            }
        }

        private bool HasPrivilege(int componentId, string regionId, string privilege)
        {
            if (userGroupRightsList.RowCount == 0)
            {
                return false;
            }
            List<KeyValuePair<string, object>> findKeys = new List<KeyValuePair<string, object>>();
            findKeys.Add(new KeyValuePair<string, object>("RcId", componentId));
            if (!string.IsNullOrEmpty(regionId))
            {
                findKeys.Add(new KeyValuePair<string, object>("RegionId", int.Parse(regionId)));
            }
            if (!string.IsNullOrEmpty(privilege))
            {
                switch (privilege.ToUpper())
                {
                    case "READ":
                        findKeys.Add(new KeyValuePair<string, object>("RurRead", "Y"));
                        break;
                    case "CREATE":
                        findKeys.Add(new KeyValuePair<string, object>("RurCreate", "Y"));
                        break;
                    case "MODIFY":
                        findKeys.Add(new KeyValuePair<string, object>("RurModify", "Y"));
                        break;
                    case "DELETE":
                        findKeys.Add(new KeyValuePair<string, object>("RurDelete", "Y"));
                        break;
                }
            }
            return (userGroupRightsList.Find(findKeys) >= 0);
        }

        #region for RDS

        public readonly int SUCCESS = 1;
        public readonly int FAILURE = -1;
        public readonly int NO_ACTION = 0;
        public readonly int CONTINUE_ACTION = 1;
        public readonly int PREVENT_ACTION = 0;

        private NRdsComponentlist ids_ComponentList;

        public bool ib_SecurityOn = true;

        public bool ib_HasUpdateableColumns;

        public virtual NRdsUser of_get_user()
        {
            return inv_User;
        }

        public virtual int of_get_numcomponents()
        {
            return ids_ComponentList.RowCount;
        }

        public virtual int of_get_componentid(string as_componentname)
        {
            return ids_ComponentList.of_get_componentid(as_componentname);
        }

        public virtual bool of_enable_menuitem(ToolStripMenuItem am_menu, string as_menutext)
        {
            bool lb_Return = false;
            int ll_MaxMenuItem;
            int ll_MenuItem;
            string ls_ItemTag;
            string ls_ComponentFindString;
            string ls_AccessFindString;
            string TAGPREFIX1 = "ComponentName=";
            string TAGPREFIX2 = "ComponentPrivilege=";
            //?NCstString lnv_String;
            if (am_menu != null && am_menu.Text == "Renewal Process")
            {
            }

            if (am_menu == null)
            {
                return false;
            }

            if (am_menu.Tag != null && am_menu.Tag.ToString() == "Ignore;")
            {
                return true;
            }
            ls_ComponentFindString = TAGPREFIX1.ToUpper() + as_menutext.ToUpper().Trim() + ";";
            ls_AccessFindString = TAGPREFIX2.ToUpper() + as_menutext.ToUpper().ToUpper() + ";";
            ll_MaxMenuItem = am_menu.DropDownItems.Count;

            for (ll_MenuItem = 0; ll_MenuItem < ll_MaxMenuItem; ll_MenuItem++)
            {

                lb_Return = this.of_enable_menuitem(am_menu.DropDownItems[ll_MenuItem] as ToolStripMenuItem, as_menutext);//this.of_enable_menuitem(am_menu.Item[ll_MenuItem], as_menutext);
                if (lb_Return)
                {
                    if (am_menu.Text == "Renewal Process")
                    {
                    }
                    am_menu.Enabled = true;
                    am_menu.Visible = true;
                    showToolbar(am_menu.Text); ;
                }
            }
            ls_ItemTag = am_menu.Tag == null ? "" : am_menu.Tag.ToString().ToUpper().Trim();
            if ((ls_ItemTag.Length > 0) && (ls_ItemTag.IndexOf(ls_ComponentFindString, 0) > -1)
                || (ls_ItemTag.Length > 0) && (ls_ItemTag.IndexOf(ls_AccessFindString, 0) > -1)
                || as_menutext == "" || !ib_SecurityOn || lb_Return)
            {
                if (am_menu.Text == "Renewal Process")
                {
                }
                am_menu.Enabled = true;
                am_menu.Visible = true;
                showToolbar(am_menu.Text);
                lb_Return = true;
            }
            return lb_Return;
        }

        protected ToolStrip GetToolStripInControl(Control c)
        {
            if (c == null)
            {
                return null;
            }
            if ((c is ToolStrip) && !(c is StatusStrip))
            {
                return c as ToolStrip;
            }
            else
            {
                foreach (Control cc in c.Controls)
                {
                    ToolStrip t = GetToolStripInControl(cc);
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        public virtual void showToolbar(string menuName)
        {
            string toolStripName = string.Empty;
            ToolStrip curToolStrip = GetToolStripInControl(StaticVariables.MainMDI);
            //for RDS
            if (menuName == "&Owner Driver")
                curToolStrip.Items["_m_contractors"].Visible = true;
            if (menuName == "&Contracts")
                curToolStrip.Items["_m_contracts"].Visible = true;
            if (menuName == "&Addresses")
                curToolStrip.Items["_m_addresses"].Visible = true;

            //for ODPS
            if (menuName == "&Payment Run")
                curToolStrip.Items["_m_paymentrun"].Visible = true;
            if (menuName == "&Invoice PSR File")
                curToolStrip.Items["_m_invoicemailinginterface"].Visible = true;
        }

        public virtual int of_enable_component_menuitems(MenuStrip am_menu)// ToolStripMenuItem am_menu)
        {
            bool lb_HasPrivilege;
            int ll_Ctr;
            int ll_Ctr2;
            int ll_COmponentID;
            string ls_ComponentName;
            if (!(am_menu != null))
            {
                return 0;
            }
            for (ll_Ctr = 0; ll_Ctr < this.of_get_numcomponents(); ll_Ctr++)
            {
                ll_COmponentID = ids_ComponentList.DataObject.GetItem<Componentlist>(ll_Ctr).Id.GetValueOrDefault();//ids_ComponentList.Object.id[ll_Ctr];
                ls_ComponentName = ids_ComponentList.DataObject.GetItem<Componentlist>(ll_Ctr).Name;// ids_ComponentList.Object.Name[ll_Ctr];
                lb_HasPrivilege = false;
                for (ll_Ctr2 = 1; ll_Ctr2 <= of_get_user().of_get_numgroups(); ll_Ctr2++)
                {
                    if (of_get_user().of_get_group(ll_Ctr2).of_hasprivilege_menu(ll_COmponentID))
                    {
                        lb_HasPrivilege = true;
                        break;
                    }
                }
                if (lb_HasPrivilege || !ib_SecurityOn)
                {
                    for (int i = 0; i < am_menu.Items.Count; i++)
                    {
                        if (am_menu.Items[i].Text == "Reports")
                        {
                        }
                        this.of_enable_menuitem(am_menu.Items[i] as ToolStripMenuItem, ls_ComponentName);
                    }
                }
            }
            return 1;
        }

        //?public virtual int of_enable_component_menuitems()
        //{
        //    this.of_enable_component_menuitems(StaticVariables.gnv_app.of_getframe().MenuID);
        //    return 1;
        //}

        public virtual int of_initialise()
        {
            int ll_ret;
            ids_ComponentList = new NRdsComponentlist();
            inv_User = new NRdsUser();
            ll_ret = inv_User.of_initialise();
            if (ll_ret == FAILURE)
            {
                return FAILURE;
            }
            return SUCCESS;
        }

        public virtual int of_initialise(bool ab_secure)
        {
            ib_SecurityOn = ab_secure;
            return this.of_initialise();
        }

        //?public virtual string of_encrypt(string a_String) {
        //    string sOldCodes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ";
        //    string sNewCodes = "p31o6GWPNCnRfiTOvmSjUwJ4e528YHD0dlbIrgZM@VktFEu9hqKxQyXaBs7cLzA";
        //    int nPos;
        //    int nLoop;
        //    string sReturn = "";
        //    if (!(StaticVariables.gnv_app.of_isempty(a_String))) {
        //        for (nLoop = 1; nLoop <=  a_String.Len(); nLoop++) {
        //            nPos = TextUtil.Pos (sOldCodes,  TextUtil.Mid (a_String, nLoop, 1));
        //            if (nPos > 0) {
        //                nPos = nPos + nLoop;
        //                if (nPos >  sOldCodes).Len() {
        //                    nPos = nPos -  sOldCodes.Len();
        //                }
        //                sReturn = sReturn +  TextUtil.Mid (sNewCodes, nPos, 1);
        //            }
        //            else {
        //                sReturn = sReturn +  TextUtil.Mid (a_String, nLoop, 1);
        //            }
        //        }
        //    }
        //    return sReturn;
        //}

        //?public virtual string of_decrypt(string a_String)
        //{
        //    string sNewCodes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890 ";
        //    string sOldCodes = "p31o6GWPNCnRfiTOvmSjUwJ4e528YHD0dlbIrgZM@VktFEu9hqKxQyXaBs7cLzA";
        //    int lPos;
        //    int lLoop;
        //    string sReturn = "";
        //    if (!(StaticVariables.gnv_app.of_isempty(a_String)))
        //    {
        //        for (lLoop = 1; lLoop <= a_String.Len(); lLoop++)
        //        {
        //            lPos = TextUtil.Pos(sOldCodes, TextUtil.Mid(a_String, lLoop, 1));
        //            if (lPos > 0)
        //            {
        //                lPos = lPos - lLoop;
        //                if (lPos < 1)
        //                {
        //                    lPos = lPos + sOldCodes.Len();
        //                }
        //                sReturn = sReturn + TextUtil.Mid(sNewCodes, lPos, 1);
        //            }
        //            else
        //            {
        //                sReturn = sReturn + TextUtil.Mid(a_String, lLoop, 1);
        //            }
        //        }
        //    }
        //    return sReturn;
        //}

        public virtual string of_get_componentname(string as_tag)
        {
            string ls_ComponentName;
            string TAGPREFIX1 = "ComponentName=";
            if (as_tag == null || as_tag.Length == 0 || !ib_SecurityOn || as_tag.IndexOf(TAGPREFIX1) == -1)
            {
                return "";
            }
            int ll_start;
            int ll_end;
            ll_start = as_tag.IndexOf(TAGPREFIX1) + TAGPREFIX1.Length;
            ll_end = as_tag.IndexOf(';', ll_start);
            ls_ComponentName = as_tag.Substring(ll_start, ll_end - ll_start).Trim();
            return ls_ComponentName;
        }

        //?public virtual string of_get_componentprivilege(string as_tag)
        //{
        //    string ls_Privilege;
        //    string TAGPREFIX1 = "ComponentPrivilege=";
        //    if (as_tag.Len() == 0 || IsNull(as_tag) || !ib_SecurityOn || TextUtil.Pos(as_tag, TAGPREFIX1) == 0)
        //    {
        //        return "";
        //    }
        //    int ll_start;
        //    int ll_end;
        //    ll_start = TextUtil.Pos(as_tag, TAGPREFIX1) + TAGPREFIX1.Len();
        //    ll_end = TextUtil.Pos(as_tag, ';', ll_start);
        //    ls_Privilege = Trim(Mid(as_tag, ll_start, ll_end - ll_start));
        //    return ls_Privilege;
        //}

        //?public virtual bool of_isclassdefined(string as_ClassName)
        //{
        //    ClassDefinition cd_Po;
        //    cd_Po = FindClassDefinition(as_ClassName);
        //    if (IsValid(cd_Po))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //?public virtual bool of_isvariabledeclared(string as_classname, string as_varname)
        //{
        //    ClassDefinition cd_Po;
        //    Cl_VariableDefinitionArray vl_gnv_App = new Cl_VariableDefinitionArray();
        //    string ls_VarDefClass;
        //    bool lb_FoundSecurityManager;
        //    int ll_Ctr;
        //    cd_Po = FindClassDefinition(as_classname);
        //    if (IsValid(cd_Po))
        //    {
        //        vl_gnv_App = cd_Po.VariableList;
        //        for (ll_Ctr = 1; ll_Ctr <= vl_gnv_App.UpperBound; ll_Ctr++)
        //        {
        //            ls_VarDefClass = vl_gnv_App[ll_Ctr].ClassName();
        //            if (Lower(vl_gnv_App[ll_Ctr].Name) == as_varname)
        //            {
        //                lb_FoundSecurityManager = true;
        //                break;
        //            }
        //        }
        //    }
        //    if (lb_FoundSecurityManager)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //?public virtual bool of_isfunctionavailable(powerobject apo, string as_funcname, string[] as_args)
        //{
        //    ClassDefinition cd_Po;
        //    ScriptDefinition lsd;
        //    bool lb_FoundSecurityManager;
        //    cd_Po = apo.ClassDefinition;
        //    if (IsValid(cd_Po))
        //    {
        //        lsd = cd_Po.FindMatchingFunction(as_funcname, as_args);
        //        if (!(IsValid(lsd)))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //?public virtual bool of_isvariabledeclared(powerobject apo, string as_varname)
        //{
        //    ClassDefinition cd_Po;
        //    Cl_VariableDefinitionArray vl_gnv_App = new Cl_VariableDefinitionArray();
        //    string ls_VarDefClass;
        //    bool lb_FoundSecurityManager;
        //    int ll_Ctr;
        //    cd_Po = apo.ClassDefinition;
        //    if (IsValid(cd_Po))
        //    {
        //        vl_gnv_App = cd_Po.VariableList;
        //        for (ll_Ctr = 1; ll_Ctr <= vl_gnv_App.UpperBound; ll_Ctr++)
        //        {
        //            ls_VarDefClass = vl_gnv_App[ll_Ctr].ClassName();
        //            if (Lower(vl_gnv_App[ll_Ctr].Name) == as_varname)
        //            {
        //                lb_FoundSecurityManager = true;
        //                break;
        //            }
        //        }
        //    }
        //    if (lb_FoundSecurityManager)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //?public virtual bool of_isclassdefined(Powerobject apo)
        //{
        //    ClassDefinition cd_Po;
        //    cd_Po = apo.ClassDefinition;
        //    if (IsValid(cd_Po))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //?public virtual bool of_isfunctionavailable(string as_classname, string as_funcname, string[] as_args)
        //{
        //    ClassDefinition cd_Po;
        //    ScriptDefinition lsd;
        //    bool lb_FoundSecurityManager;
        //    cd_Po = FindClassDefinition(as_classname);
        //    if (IsValid(cd_Po))
        //    {
        //        lsd = cd_Po.FindMatchingFunction(as_funcname, as_args);
        //        if (!(IsValid(lsd)))
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //?public virtual bool of_get_componentprivilege(string as_tag, string as_priv)
        //{
        //    string ls_Privilege;
        //    string TAGPREFIX1 = "ComponentPrivilege=";
        //    if (as_tag.Len() == 0 || IsNull(as_tag) || !ib_SecurityOn || TextUtil.Pos(as_tag, TAGPREFIX1) == 0)
        //    {
        //        return true;
        //    }
        //    int ll_start;
        //    int ll_end;
        //    ll_start = TextUtil.Pos(as_tag, TAGPREFIX1) + TAGPREFIX1.Len();
        //    ll_end = TextUtil.Pos(as_tag, ';', ll_start);
        //    ls_Privilege = Trim(Mid(as_tag, ll_start, ll_end - ll_start));
        //    return Upper(ls_Privilege) == Upper(as_priv);
        //}

        public virtual bool of_iscomponentprivilegerequired(string as_tag)
        {
            string ls_Privilege;
            string TAGPREFIX1 = "ComponentPrivilege=";
            if (as_tag == null || as_tag.Length == 0 || !ib_SecurityOn || as_tag.IndexOf(TAGPREFIX1) == -1)
            {
                return false;
            }
            return as_tag.IndexOf(TAGPREFIX1) > -1;
        }

        public virtual bool of_iscomponentprivilegerequired(string as_tag, string as_priv)
        {
            string ls_Privilege;
            string TAGPREFIX1 = "ComponentPrivilege=";
            int ll_start;
            int ll_end;
            if (as_tag.Length == 0 || as_tag == null || !ib_SecurityOn || as_tag.IndexOf(TAGPREFIX1) == -1)
            {
                return true;
            }
            ll_start = as_tag.IndexOf(TAGPREFIX1) + TAGPREFIX1.Length;
            ll_end = as_tag.IndexOf(';', ll_start);
            ls_Privilege = as_tag.Substring(ll_start, ll_end - ll_start).Trim();
            return ls_Privilege.ToUpper() == as_priv.ToUpper();
        }

        public virtual bool of_hascomponentprivilege(string as_tag, int al_componentid)
        {
            int? ll_Null;
            ll_Null = null;
            return this.of_hascomponentprivilege(as_tag, al_componentid, ll_Null);
        }

        public virtual bool of_enable_controls(FormBase aw_control, Control ago_control, string as_parentcomponent)
        {
            bool lb_ObjectEnabled = false;
            Control TestExpr = ago_control;//.TypeOf();
            if (TestExpr is TabControl)
            {
                lb_ObjectEnabled = this.of_enable_tab((TabControl)ago_control, aw_control, as_parentcomponent);
            }
            else if (TestExpr is TabPage)//  userobject!) 
            {
                lb_ObjectEnabled = this.of_enable_userobject((Control)ago_control, aw_control, as_parentcomponent);
            }
            else if (TestExpr is Button)
            {
                lb_ObjectEnabled = this.of_enable_commandbutton((Button)ago_control, aw_control, as_parentcomponent);
            }
            else if (TestExpr is PictureBox)
            {
                lb_ObjectEnabled = this.of_enable_picturebutton((PictureBox)ago_control, aw_control, as_parentcomponent);
            }
            else if (TestExpr is UDw)
            {
                lb_ObjectEnabled = this.of_enable_datawindow((UDw)ago_control, aw_control, as_parentcomponent);
            }
            //else if (TestExpr is DataUserControlContainer)//  userobject!) 
            //{
            //    lb_ObjectEnabled = this.of_enable_userobject((Control)ago_control, aw_control, as_parentcomponent);
            //}
            if (ago_control.Tag != null && ago_control.Tag.ToString().IndexOf("ComponentName=Disabled;") > 0)
            {
                ago_control.Visible = false;
            }
            return lb_ObjectEnabled;
        }

        public virtual bool of_enable_controls(FormBase aw_control)
        {
            bool lb_ObjectEnabled;
            bool lb_HasComponentPrivilege;
            int ll_ctr;
            int ll_Ctr2;
            string ls_ComponentName;
            int ll_ComponentId;
            int ll_RegionId;
            bool lb_BypassSecurity;
            int ll_NumFirstTabEnabled = 0;
            int ll_NumTabsEnabled = 0;
            bool lb_isComponentPrivilegeRequired;
            for (ll_ctr = 0; ll_ctr < aw_control.Controls.Count; ll_ctr++)
            {
                Control TestExpr = aw_control.Controls[ll_ctr];
                if (TestExpr is Button)
                {
                    lb_ObjectEnabled = this.of_enable_commandbutton((Button)aw_control.Controls[ll_ctr], aw_control, aw_control.of_get_componentname());
                }
                else if (TestExpr is PictureBox)
                {
                    lb_ObjectEnabled = this.of_enable_picturebutton((PictureBox)aw_control.Controls[ll_ctr], aw_control, aw_control.of_get_componentname());
                }
                else if (TestExpr is TabControl)
                {
                    lb_ObjectEnabled = this.of_enable_tab((TabControl)aw_control.Controls[ll_ctr], aw_control, aw_control.of_get_componentname());
                }
                else if (TestExpr is TabPage)
                {
                    lb_ObjectEnabled = this.of_enable_tab((TabControl)aw_control.Controls[ll_ctr], aw_control, aw_control.of_get_componentname());
                }

                //else if (TestExpr is DataUserControlContainer)// userobject!) 
                //{
                //    lb_ObjectEnabled = this.of_enable_userobject((DataUserControlContainer)aw_control.Controls[ll_ctr], aw_control, aw_control.of_get_componentname());
                //}
                else if (TestExpr is UDw)
                {
                    lb_ObjectEnabled = this.of_enable_datawindow((UDw)aw_control.Controls[ll_ctr], aw_control, aw_control.of_get_componentname());
                }
                if (aw_control.Controls[ll_ctr].Tag != null && aw_control.Controls[ll_ctr].Tag.ToString().IndexOf("ComponentName=Disabled;") >= 0)
                {
                    aw_control.Controls[ll_ctr].Visible = false;
                }
            }
            return true;
        }

        public virtual bool of_enable_commandbutton(Button lcb_object, FormBase aw_control, string as_parentcomponentname)
        {
            bool lb_HasComponentPrivilege;
            string ls_ComponentName;
            int ll_ComponentId;
            bool lb_BypassSecurity;
            lb_BypassSecurity = aw_control.of_issecurity_bypassed();
            if (lb_BypassSecurity)
            {
                return true;
            }
            lb_BypassSecurity = lb_BypassSecurity || !ib_SecurityOn;
            ls_ComponentName = null;
            lb_HasComponentPrivilege = false;
            if (lcb_object.Tag == null)
                lcb_object.Tag = "";

            ls_ComponentName = this.of_get_componentname(lcb_object.Tag.ToString());

            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = as_parentcomponentname;
            }
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = aw_control.of_get_componentname();
            }
            ll_ComponentId = this.of_get_componentid(ls_ComponentName);

            if (this.of_iscomponentprivilegerequired(lcb_object.Tag.ToString()))
            {
                lb_HasComponentPrivilege = this.of_hascomponentprivilege(lcb_object.Tag.ToString(), ll_ComponentId);
            }
            else
            {
                lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(ll_ComponentId);
            }
            lb_HasComponentPrivilege = lb_HasComponentPrivilege || !ib_SecurityOn || lb_BypassSecurity;
            if (lb_HasComponentPrivilege)
            {
                lcb_object.Enabled = true;
                lcb_object.Visible = true;
                lcb_object.Enabled = true;
            }
            return lb_HasComponentPrivilege;
        }

        public virtual bool of_enable_datawindow(UDw ldw_object, FormBase aw_control, string as_parentcomponentname)
        {
            bool lb_HasComponentPrivilege;
            bool lb_AllowCreate;
            bool lb_AllowRead;
            bool lb_AllowModify;
            bool lb_AllowDelete;
            bool lb_ObjectEnabled;
            string ls_ComponentName;
            int ll_ComponentId;
            int? ll_RegionId;
            bool lb_BypassSecurity;
            string ls_Temp;
            lb_BypassSecurity = aw_control.of_issecurity_bypassed();
            if (lb_BypassSecurity)
            {
                return true;
            }
            lb_BypassSecurity = lb_BypassSecurity || !ib_SecurityOn;
            ls_ComponentName = null;
            lb_HasComponentPrivilege = false;

            if (ldw_object.Tag == null)
                ldw_object.Tag = "";

            ls_ComponentName = this.of_get_componentname(ldw_object.Tag.ToString());
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = as_parentcomponentname;
            }
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = aw_control.of_get_componentname();
            }
            ls_Temp = ldw_object.of_get_componentname();
            if (!(ls_Temp.Length > 0))
            {
                ldw_object.of_set_componentname(ls_ComponentName);
            }
            if (!(ldw_object.of_get_regionid() > 0))
            {
                ldw_object.of_set_regionid(aw_control.of_get_regionid());
            }
            ll_RegionId = ldw_object.of_get_regionid();
            ll_ComponentId = this.of_get_componentid(ls_ComponentName);

            if (this.of_iscomponentprivilegerequired(ldw_object.Tag.ToString()))
            {
                lb_HasComponentPrivilege = this.of_hascomponentprivilege(ldw_object.Tag.ToString(), ll_ComponentId);
            }
            else if (ll_RegionId > 0)
            {
                lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(ll_ComponentId, ll_RegionId);
            }
            else
            {
                lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(ll_ComponentId);
            }
            lb_HasComponentPrivilege = lb_HasComponentPrivilege || !ib_SecurityOn || lb_BypassSecurity;
            if (lb_HasComponentPrivilege)
            {
                ldw_object.Enabled = true;
                ldw_object.Visible = true;
            }
            if (ls_ComponentName.Length > 0)
            {
                ll_RegionId = aw_control.of_get_regionid();
                lb_AllowCreate = this.of_get_user().of_hasprivilege(ls_ComponentName, ll_RegionId, "C", false);
                lb_AllowRead = this.of_get_user().of_hasprivilege(ls_ComponentName, ll_RegionId, "R", false);
                lb_AllowModify = this.of_get_user().of_hasprivilege(ls_ComponentName, ll_RegionId, "M", false);
                lb_AllowDelete = this.of_get_user().of_hasprivilege(ls_ComponentName, ll_RegionId, "D", false);
                ldw_object.of_set_createpriv(lb_AllowCreate);
                ldw_object.of_set_readpriv(lb_AllowRead);
                ldw_object.of_set_modifypriv(lb_AllowModify);
                ldw_object.of_set_deletepriv(lb_AllowDelete);
                if (!(lb_AllowCreate || lb_AllowModify || lb_AllowDelete))
                {
                    ldw_object.of_SetUpdateable(false);
                }
                if (!lb_AllowModify)
                {
                    ldw_object.of_protectcolumns();
                }
            }
            ldw_object.of_filter();

            return lb_HasComponentPrivilege;
        }

        public virtual bool of_enable_picturebutton(PictureBox lpb_object, FormBase aw_control, string as_parentcomponentname)
        {
            bool lb_HasComponentPrivilege;
            string ls_ComponentName;
            int ll_ComponentId;
            bool lb_BypassSecurity;
            lb_BypassSecurity = aw_control.of_issecurity_bypassed();
            if (lb_BypassSecurity)
            {
                return true;
            }
            lb_BypassSecurity = lb_BypassSecurity || !ib_SecurityOn;
            ls_ComponentName = null;
            lb_HasComponentPrivilege = false;

            if (lpb_object.Tag == null)
                lpb_object.Tag = "";

            ls_ComponentName = this.of_get_componentname(lpb_object.Tag.ToString());
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = as_parentcomponentname;
            }
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = aw_control.of_get_componentname();
            }
            ll_ComponentId = this.of_get_componentid(ls_ComponentName);
            if (this.of_iscomponentprivilegerequired(lpb_object.Tag.ToString()))
            {
                lb_HasComponentPrivilege = this.of_hascomponentprivilege(lpb_object.Tag.ToString(), ll_ComponentId);
            }
            else
            {
                lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(ll_ComponentId);
            }
            lb_HasComponentPrivilege = lb_HasComponentPrivilege || !ib_SecurityOn || lb_BypassSecurity;
            if (lb_HasComponentPrivilege)
            {
                lpb_object.Enabled = true;
                lpb_object.Visible = true;
            }

            return lb_HasComponentPrivilege;
        }

        public virtual bool of_enable_tab(TabControl ltab_object, FormBase aw_control, string as_parentcomponentname)
        {
            bool lb_HasComponentPrivilege;
            bool lb_ObjectEnabled;
            string ls_ComponentName;
            int ll_ComponentId;
            int ll_NumFirstTabEnabled = -1;
            int ll_NumTabsEnabled = 0;
            int ll_Ctr;
            bool lb_BypassSecurity;
            string ls_Temp;
            lb_BypassSecurity = aw_control.of_issecurity_bypassed();

            if (lb_BypassSecurity)
            {
                return true;
            }
            lb_BypassSecurity = lb_BypassSecurity || !ib_SecurityOn;
            ls_ComponentName = null;
            lb_HasComponentPrivilege = false;
            ll_NumFirstTabEnabled = 0;
            ll_NumTabsEnabled = 0;

            if (ltab_object.Tag == null)
                ltab_object.Tag = "";

            ls_ComponentName = this.of_get_componentname(ltab_object.Tag.ToString());
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = as_parentcomponentname;
            }
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = aw_control.of_get_componentname();
            }
            ll_ComponentId = this.of_get_componentid(ls_ComponentName);
            lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(ll_ComponentId) || !ib_SecurityOn || lb_BypassSecurity;
            for (ll_Ctr = 0; ll_Ctr < ltab_object.Controls.Count; ll_Ctr++)
            {

                lb_ObjectEnabled = this.of_enable_controls(aw_control, ltab_object.Controls[ll_Ctr], ls_ComponentName);
                if (lb_ObjectEnabled)
                {
                    if (ll_NumFirstTabEnabled < 0)
                    {
                        ll_NumFirstTabEnabled = ll_Ctr;
                    }
                    ll_NumTabsEnabled++;
                }
            }

            //added by jlwang 
            for (int i = ltab_object.Controls.Count - 1; i >= 0; i--)
            {
                if (ltab_object.TabPages[i].Name == "")
                    ltab_object.TabPages.RemoveAt(i);

            }

            if (ll_NumTabsEnabled > 0 || lb_HasComponentPrivilege)
            {
                ltab_object.Enabled = true;
                ltab_object.Visible = true;
                if (ll_NumTabsEnabled < 5)
                {
                    //?ltab_object.RaggedRight = true;
                }
            }
            if (ll_NumFirstTabEnabled > 0)
            {
                ltab_object.SelectedIndex = ll_NumFirstTabEnabled;//.SelectTab(ll_NumFirstTabEnabled);
            }
            return ll_NumTabsEnabled > 0 || lb_HasComponentPrivilege;
        }

        public virtual bool of_enable_userobject(Control luo_object, FormBase aw_control, string as_parentcomponentname)
        {
            int? ll_RegionId;
            bool lb_HasComponentPrivilege;
            bool lb_ObjectEnabled = false;
            string ls_ComponentName;
            int ll_ComponentId;
            bool lb_BypassSecurity;
            int ll_Ctr;
            lb_BypassSecurity = aw_control.of_issecurity_bypassed();
            if (lb_BypassSecurity)
            {
                return true;
            }
            lb_BypassSecurity = lb_BypassSecurity || !ib_SecurityOn;
            ls_ComponentName = null;
            lb_HasComponentPrivilege = false;

            if (luo_object.Tag == null)
                luo_object.Tag = "";

            ls_ComponentName = this.of_get_componentname(luo_object.Tag.ToString());
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = as_parentcomponentname;
            }
            if (ls_ComponentName == "" || ls_ComponentName == null)
            {
                ls_ComponentName = aw_control.of_get_componentname();
            }
            ll_ComponentId = this.of_get_componentid(ls_ComponentName);
            ll_RegionId = aw_control.of_get_regionid();
            if (this.of_iscomponentprivilegerequired(luo_object.Tag.ToString()))
            {
                lb_HasComponentPrivilege = this.of_hascomponentprivilege(luo_object.Tag.ToString(), ll_ComponentId, ll_RegionId);
            }
            else
            {
                lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(ll_ComponentId, ll_RegionId == null ? 0 : ll_RegionId);
            }
            lb_HasComponentPrivilege = lb_HasComponentPrivilege || !ib_SecurityOn || lb_BypassSecurity;
            for (ll_Ctr = 0; ll_Ctr < luo_object.Controls.Count; ll_Ctr++)
            {
                if (this.of_enable_controls(aw_control, luo_object.Controls[ll_Ctr], ls_ComponentName))
                {
                    lb_ObjectEnabled = true;
                }
            }
            if (lb_ObjectEnabled || lb_HasComponentPrivilege)
            {
                luo_object.Visible = true;
                luo_object.Name = luo_object.Text;
                luo_object.Enabled = true;

                lb_ObjectEnabled = true;

            }
            return lb_ObjectEnabled || lb_HasComponentPrivilege;
        }

        public virtual bool zof_enable_controls(FormBase aw_control, Control ago_control, string as_parentcomponent)
        {
            bool lb_ControlSet = false;
            return lb_ControlSet;
        }

        public virtual bool of_hascomponentprivilege(string as_tag, int al_componentid, int? al_RegionId)
        {
            bool lb_isComponentPrivilegeRequired;
            bool lb_HasComponentPrivilege = false;
            lb_isComponentPrivilegeRequired = this.of_iscomponentprivilegerequired(as_tag);
            if (lb_isComponentPrivilegeRequired)
            {
                if (this.of_iscomponentprivilegerequired(as_tag, "C"))
                {
                    lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(al_componentid, al_RegionId, "C");
                }
                else if (this.of_iscomponentprivilegerequired(as_tag, "R"))
                {
                    lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(al_componentid, al_RegionId, "R");
                }
                else if (this.of_iscomponentprivilegerequired(as_tag, "M"))
                {
                    lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(al_componentid, al_RegionId, "M");
                }
                else if (this.of_iscomponentprivilegerequired(as_tag, "D"))
                {
                    lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(al_componentid, al_RegionId, "D");
                }
            }
            else
            {
                lb_HasComponentPrivilege = this.of_get_user().of_hasprivilege(al_componentid, al_RegionId);
            }
            return lb_HasComponentPrivilege;
        }

        public virtual bool of_getreadprivilege(string as_user_id, string as_component)
        {
            int li_priv_count;
            int sqlCode = -1;
            string sqlErrText = string.Empty;
            li_priv_count = 0;
            //select count ( *) into :li_priv_count from rds_user_rights rur, rds_user_id_group rui, rds_component rc, rds_user_id rid where rc.rc_name = :as_component and rid.ui_userid = :as_user_id and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and rur.rur_read = 'Y' and rur.ug_id = rui.ug_id using sqlca;

            li_priv_count = LoginService.GetRdsUserRightsMoreValue(as_component, as_user_id, ref sqlCode, ref sqlErrText);
            if (sqlCode == -1)// StaticVariables.sqlca.SQLCode != 0 && StaticVariables.sqlca.SQLCode != 100) 
            {
                return false;
            }
            if (li_priv_count < 1)
            {
                return false;
            }
            return true;
        }

        public virtual bool of_getmodifyprivilege(string as_user_id, string as_component)
        {
            int li_priv_count;
            li_priv_count = 0;
            int sqlCode = -1;
            string sqlErrText = string.Empty;
            //select count ( *) into :li_priv_count from rds_user_rights rur, rds_user_id_group rui, rds_component rc, rds_user_id rid where rc.rc_name = :as_component and rid.ui_userid = :as_user_id and rui.ui_id = rid.ui_id and rur.ug_id = rui.ug_id and rc.rc_id = rur.rc_id and rur.rur_modify = 'Y' and rur.ug_id = rui.ug_id using sqlca;
            li_priv_count = LoginService.GetRdsUserRightsMoreValue2(as_component, as_user_id, ref sqlCode, ref sqlErrText);

            if (sqlCode == -1) //(StaticVariables.sqlca.SQLCode != 0 && StaticVariables.sqlca.SQLCode != 100) 
            {
                return false;
            }
            if (li_priv_count < 1)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}

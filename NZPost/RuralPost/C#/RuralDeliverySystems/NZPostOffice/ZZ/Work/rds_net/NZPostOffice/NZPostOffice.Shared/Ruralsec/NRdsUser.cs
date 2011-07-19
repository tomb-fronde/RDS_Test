using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NZPostOffice.Entity;
using NZPostOffice.DataControls;

namespace NZPostOffice.Shared.Ruralsec
{
    public class NRdsUser
    {
        public readonly int SUCCESS = 1;
        public readonly int FAILURE = -1;
        public readonly int NO_ACTION = 0;
        public readonly int CONTINUE_ACTION = 1;
        public readonly int PREVENT_ACTION = 0;

        private Dictionary<int, NRdsUserGroups> inv_UserGroups = new Dictionary<int, NRdsUserGroups>(); //Cl_n_rds_user_groupsArray inv_UserGroups = new Cl_n_rds_user_groupsArray();

        public DUserDetails ids_UserDetails;

        public Metex.Windows.DataUserControl ids_GroupList;

        public Metex.Windows.DataUserControl ids_contract_types;

        public NRdsComponentlist ids_ComponentList;

        public NRdsUser()
        {
        }

        public virtual string of_get_username()
        {
            string ls_UserName;
            ls_UserName = ids_UserDetails.GetItem<UserDetails>(0).Name;
            return ls_UserName;
        }

        public virtual string of_get_location()
        {
            string ls_Location;
            ls_Location = ids_UserDetails.GetItem<UserDetails>(0).Location;
            return ls_Location;
        }

        public virtual string of_get_phone()
        {
            string ls_Phone;
            ls_Phone = ids_UserDetails.GetItem<UserDetails>(0).Phone;
            return ls_Phone;
        }

        public virtual string of_get_mobile()
        {
            string ls_Mobile;
            ls_Mobile = ids_UserDetails.GetItem<UserDetails>(0).Mobile;
            return ls_Mobile;
        }

        public virtual int? of_get_regionid()
        {
            int? ll_RegionId;
            ll_RegionId = ids_UserDetails.GetItem<UserDetails>(0).RegionId;
            if (ll_RegionId == -1)
            {
                ll_RegionId = null;
            }
            return ll_RegionId;
        }

        public virtual string of_get_userid()
        {
            string ls_userid;
            ls_userid = ids_UserDetails.GetItem<UserDetails>(0).UserId;
            return ls_userid;
        }

        public virtual string of_get_password()
        {
            string ls_Password;
            ls_Password = ids_UserDetails.GetItem<UserDetails>(0).Password;
            return ls_Password;
        }

        public virtual string of_get_createdby()
        {
            string ls_CreatedBy;
            ls_CreatedBy = ids_UserDetails.GetItem<UserDetails>(0).CreatedBy;
            return ls_CreatedBy;
        }

        public virtual string of_get_modifiedby()
        {
            string ls_ModifiedBy;
            ls_ModifiedBy = ids_UserDetails.GetItem<UserDetails>(0).ModifiedBy;
            return ls_ModifiedBy;
        }

        public virtual bool of_can_changepassword()
        {
            string ls_CanChangePwd;
            ls_CanChangePwd = ids_UserDetails.GetItem<UserDetails>(0).CanChangePassword;
            return ls_CanChangePwd.ToUpper() == "Y";
        }

        public virtual string of_get_regionname()
        {
            string ls_Region;
            ls_Region = ids_UserDetails.GetItem<UserDetails>(0).RegionName;
            return ls_Region;
        }

        public virtual int of_initialise()
        {
            int ll_Ctr;
            int ll_Ret;
            int ll_Rows;
            int ll_GroupId;

            ids_UserDetails = new DUserDetails();//ids_UserDetails = new  NDs();ids_UserDetails.DataObject = "d_user_details";
            ll_Rows = ((DUserDetails)ids_UserDetails).Retrieve(StaticVariables.LoginId);
            ll_Rows = ids_UserDetails.RowCount;
            if (ll_Rows != 1)
            {
                MessageBox.Show("Sorry. Your user details have not been set up.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
                return FAILURE;
            }
            ids_GroupList = new DUserGrouplist();//ids_GroupList = new NDs();ids_GroupList.DataObject = "d_user_grouplist";
            ll_Rows = ((DUserGrouplist)ids_GroupList).Retrieve(StaticVariables.LoginId);
            if (ll_Rows <= -1)
            {
                MessageBox.Show("Sorry. You are not a member of any user group", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(0);
                return FAILURE;
            }
            for (ll_Ctr = 0; ll_Ctr < ids_GroupList.RowCount; ll_Ctr++) //for (ll_Ctr = 1; ll_Ctr <= ids_GroupList.RowCount; ll_Ctr++)
            {
                ll_GroupId = ids_GroupList.GetItem<UserGrouplist>(ll_Ctr).Id.GetValueOrDefault(); ;//ids_GroupList.Object.id[ll_Ctr];
                inv_UserGroups[inv_UserGroups.Count + 1] = new NRdsUserGroups();//inv_UserGroups[inv_UserGroups.UpperBound + 1] = new NRdsUserGroups();
                ll_Ret = inv_UserGroups[inv_UserGroups.Count].of_initialise(ll_GroupId);
                if (ll_Ret == FAILURE)
                {
                    MessageBox.Show("Failed to initialise group membership.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Environment.Exit(0);
                }
            }

            ids_ComponentList = new NRdsComponentlist();
            ids_contract_types = new DDddwFilteredContractTypes();//ids_contract_types = new NDs();ids_contract_types.DataObject = "d_dddw_filtered_contract_types";
            ll_Ret = ((DDddwFilteredContractTypes)ids_contract_types).Retrieve(this.of_get_ui_id());
            if (ll_Ret == FAILURE)
            {
                MessageBox.Show("Failed to contract type rights.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return FAILURE;
            }
            if (ll_Ret == 0)
            {
                ids_contract_types.InsertItem<FilteredContractTypes>(0);//ids_contract_types.InsertRow(0);
                ids_contract_types.GetItem<FilteredContractTypes>(0).CtKey = -99;//ids_contract_types.SetItem(1, "ct_key", -(99));
                ids_contract_types.GetItem<FilteredContractTypes>(0).ContractType = "<No Access>";//ids_contract_types.SetItem(1, "contract_type", "<No Access>");
               
            }
            return SUCCESS;
        }

        //public virtual DateTime of_get_lastlogindate()
        //{
        //    DateTime ldt_Last_Login;
        //    ldt_Last_Login = ids_UserDetails.GetItem<UserDetails>(0).last_login_date;
        //    return ldt_Last_Login;
        //}

        //public virtual DateTime of_get_lastlogintime()
        //{
        //    DateTime lt_Last_Login;
        //    lt_Last_Login = ids_UserDetails.GetItem<UserDetails>(0).lt_Last_Login;
        //    return lt_Last_Login;
        //}

        //public virtual DateTime of_get_modifieddate()
        //{
        //    DateTime ldt_Last_Modified;
        //    ldt_Last_Modified = ids_UserDetails.GetItem<UserDetails>(0).modified_date;
        //    return ldt_Last_Modified;
        //}

        //public virtual DateTime of_get_createddate()
        //{
        //    DateTime ldt_Created;
        //    ldt_Created = ids_UserDetails.GetItem<UserDetails>(0).created_date;
        //    return ldt_Created;
        //}

        //public virtual DateTime of_get_passwordexpiry()
        //{
        //    DateTime ldt_Expiry;
        //    ldt_Expiry = ids_UserDetails.GetItem<UserDetails>(0).password_expiry;
        //    return ldt_Expiry;
        //}

        //public virtual int of_get_gracelogins()
        //{
        //    int ll_Grace_logins;
        //    ll_Grace_logins = ids_UserDetails.GetItem<UserDetails>(0).Grace_Logins;
        //    return ll_Grace_logins;
        //}

        //public virtual DateTime of_get_lockeddate()
        //{
        //    DateTime ldt_LockedDate;
        //    ldt_LockedDate = ids_UserDetails.GetItem<UserDetails>(0).Lcoked_Date;
        //    return ldt_LockedDate;
        //}

        public virtual bool of_ismember(string as_groupname)
        {
            // TJB  July-2011: Expanded for debugging
            int ll_Ctr;
            string as_groupname_upper = as_groupname.ToUpper().Trim();
            string test_groupname_upper = "";

            //for (ll_Ctr = 1; ll_Ctr <= this.of_get_numgroups(); ll_Ctr++)
            int nCtrls = this.of_get_numgroups();
            for (ll_Ctr = 1; ll_Ctr <= nCtrls; ll_Ctr++)
            {
                //if (inv_UserGroups[ll_Ctr].of_get_groupname().ToUpper().Trim() == as_groupname.ToUpper().Trim())
                test_groupname_upper = inv_UserGroups[ll_Ctr].of_get_groupname().ToUpper().Trim();
                if (test_groupname_upper == as_groupname_upper)
                {
                    return true;
                }
            }
            return false;
        }

        public virtual int of_get_numgroups()
        {
            return ids_GroupList.RowCount;
        }

        public virtual NRdsUserGroups of_get_group(int al_subscript)
        {
            return inv_UserGroups[al_subscript];
        }

        //public virtual bool of_ismember(int al_groupid)
        //{
        //    int ll_Ctr;
        //    for (ll_Ctr = 1; ll_Ctr <= this.of_get_numgroups(); ll_Ctr++)
        //    {
        //        if (this.of_get_group(ll_Ctr).of_get_groupid() == al_groupid)
        //        {
        //            return true;
        //        }
        //    }
        //    // No.
        //    return false;
        //}

        //public virtual int of_get_user_pkid()
        //{
        //    int ll_userid;
        //    ll_userid = ids_UserDetails.GetItem<UserDetails>(0).id;
        //    return ll_userid;
        //}

        //public virtual NRdsUserGroups of_get_usergroup(int al_groupid)
        //{
        //    NRdsUserGroups lnv_Group;
        //    int ll_Ctr;
        //    for (ll_Ctr = 1; ll_Ctr <= inv_UserGroups.UpperBound; ll_Ctr++)
        //    {
        //        if (inv_UserGroups[ll_Ctr].of_get_groupid() == al_groupid)
        //        {
        //            return inv_UserGroups[ll_Ctr];
        //        }
        //    }
        //    return lnv_Group;
        //}

        //public virtual int of_get_userpkid()
        //{
        //    int ll_Id;
        //    ll_Id = ids_UserDetails.GetItem<UserDetails>(0).Id;
        //    return ll_Id;
        //}

        public virtual bool of_hasprivilege_contract(int al_contract_type)
        {
            int ll_Row;
            ll_Row = ids_contract_types.Find("Ct_Key=", al_contract_type);//ll_Row = ids_contract_types.Find( "Ct_Key=" + al_contract_type).ToString().Length);
            return ll_Row > 0;
        }

        public virtual bool of_hasprivilege(int? al_componentid)
        {
            int? ll_Null;
            ll_Null = null;
            return this.of_hasprivilege(al_componentid, ll_Null);
        }

        public virtual bool of_hasprivilege(int? al_componentid, int? al_regionid)
        {
            string ls_null;
            ls_null = null;
            return this.of_hasprivilege(al_componentid, al_regionid, ls_null);
        }

        public virtual bool of_hasprivilege(int? al_componentid, int? al_regionid, string as_privilege)
        {
            bool lb_National;
            int ll_Ctr;
            int ll_Ctr2;
            int ll_UserRegionId;
            NRdsUserGroups lnv_Groups;
            return this.of_hasprivilege(al_componentid, al_regionid, as_privilege, false);
        }

        //public virtual bool of_hasprivilege(int al_componentid, string as_privilege)
        //{
        //    int ll_Null;
        //    ll_Null = null;
        //    return this.of_hasprivilege(al_componentid, ll_Null, as_privilege);
        //}

        public virtual Metex.Windows.DataUserControl of_get_contract_types()
        {
            return ids_contract_types;
        }

        public virtual bool of_get_privacyoverride()
        {
            int ll_Ctr;
            for (ll_Ctr = 1; ll_Ctr <= inv_UserGroups.Count; ll_Ctr++)
            {
                if (inv_UserGroups[ll_Ctr].of_get_privacyoverride())
                {
                    return true;
                }
            }
            return false;
        }

        public virtual bool of_isnationaluser()
        {
            return this.of_get_regionid() == null;
        }

        public virtual bool of_hasprivilege(int? al_componentid, int? al_regionid, string as_privilege, bool ab_checkeditprivsonly)
        {
            int ll_Ctr;
            int ll_Ctr2;
            int? ll_RequiredRegionId;
            Dictionary<int, string> ls_AccessRights = new Dictionary<int, string>();
            bool lb_National;
            //?NRdsConstant lnv_Constant;
            NRdsUserGroups lnv_Groups;
            int? ll_UserRegionId;
            ll_RequiredRegionId = al_regionid;
            ls_AccessRights[1] = "C";
            ls_AccessRights[2] = "M";
            ls_AccessRights[3] = "D";
            lb_National = this.of_isnationaluser();
            ll_UserRegionId = this.of_get_regionid();//.GetValueOrDefault();
            if (lb_National)
            {
                al_regionid = ll_UserRegionId;
            }
            if ((al_regionid == null) || ll_UserRegionId == ll_RequiredRegionId)
            {
                al_regionid = 0;
            }
            for (ll_Ctr = 1; ll_Ctr <= this.of_get_numgroups(); ll_Ctr++)
            {
                lnv_Groups = this.of_get_group(ll_Ctr);
                if (ab_checkeditprivsonly || (as_privilege != null && as_privilege.Length == 0))
                {
                    for (ll_Ctr2 = 1; ll_Ctr2 <= ls_AccessRights.Count; ll_Ctr2++)
                    {
                        if (lnv_Groups.of_hasprivilege(al_componentid, al_regionid, ls_AccessRights[ll_Ctr2]))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (lnv_Groups.of_hasprivilege(al_componentid, al_regionid, as_privilege))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual bool of_hasprivilege(string as_componentname, int? al_regionid, string as_privilege, bool ab_checkeditprivsonly)
        {
            int ll_componentid;
            ll_componentid = ids_ComponentList.of_get_componentid(as_componentname);
            return this.of_hasprivilege(ll_componentid, al_regionid, as_privilege, ab_checkeditprivsonly);
        }

        public virtual int of_get_ui_id()
        {
            int ll_userid;
            ll_userid = ids_UserDetails.GetItem<UserDetails>(0).UiId.GetValueOrDefault();//ll_userid = ids_UserDetails.GetItem<UserDetails>(0).ui_id;
            return ll_userid;
        }

        public virtual bool of_ismemberof_list(string as_group_list)
        {
            bool lb_result;
            int li_sep;
            int li_start;
            string ls_group;
            lb_result = false;
            li_start = 0;
            li_sep = as_group_list.IndexOf(',', li_start);
            while (!(li_sep < 1))
            {
                ls_group = as_group_list.Substring(li_start, li_sep - li_start).Trim();
                lb_result = of_ismember(ls_group) || lb_result;
                li_start = li_sep + 1;
                li_sep = as_group_list.IndexOf(',', li_start);
            }
            if (as_group_list.Length > li_start)
            {
                ls_group = as_group_list.Substring(li_start).Trim();
                lb_result = of_ismember(ls_group) || lb_result;
            }
            return lb_result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using NZPostOffice.DataControls;
using NZPostOffice.Entity;

namespace NZPostOffice.Shared.Ruralsec
{
    public class NRdsUserGroups
    {
        public Metex.Windows.DataUserControl ids_User_Groups;

        public Metex.Windows.DataUserControl ids_User_Group_Rights;//NDs ids_User_Group_Rights;

        //public NRdsConstant inv_Constant;

        public NRdsUserGroups()
        {
        }

        //public virtual string of_get_createdby()
        //{
        //    return ids_User_Groups.Object.created_by[1];
        //}

        //public virtual DateTime of_get_createddate()
        //{
        //    return ids_User_Groups.Object.created_date[1];
        //}

        //public virtual string of_get_groupdescription()
        //{
        //    return ids_User_Groups.Object.group_description[1];
        //}

        //public virtual int of_get_groupid()
        //{
        //    return ids_User_Groups.Object.group_id[1];
        //}

        public virtual string of_get_groupname()
        {
            return ids_User_Groups.GetValue<string>(0, "name");//.Object.name[1];
        }

        //public virtual DateTime of_get_modifieddate()
        //{
        //    return ids_User_Groups.Object.modified_date[1];
        //}

        public virtual bool of_get_privacyoverride()
        {
            return ids_User_Groups.GetItem<GroupDetails>(0).PrivacyOverride == "Y";//ids_User_Groups.Object.privacy_override[1] == 'Y';
        }

        public virtual int of_initialise(int al_groupid)
        {
            int ll_Ret;
            int ll_Ctr;
            ids_User_Groups = new DGroupDetails();//ids_User_Groups = new NDs();ids_User_Groups.DataObject = "d_group_details";
            ((DGroupDetails)ids_User_Groups).Retrieve(al_groupid);//ll_Ret = ids_User_Groups.Retrieve(al_groupid);\
            ll_Ret = ids_User_Groups.RowCount;
            ids_User_Group_Rights = new DUserGroupRights();//ids_User_Group_Rights = new NDs();ids_User_Group_Rights.DataObject = "d_user_group_rights";
            ((DUserGroupRights)ids_User_Group_Rights).Retrieve(al_groupid);//ll_Ret = ids_User_Group_Rights.Retrieve(al_groupid);
            ll_Ret = ids_User_Group_Rights.RowCount;
            return ll_Ret;
        }

        //public virtual bool of_hasprivilege(int al_componentid)
        //{
        //    int ll_Null;
        //    ll_Null = null;
        //    return this.of_hasprivilege(al_componentid, ll_Null);
        //}

        //public virtual bool of_hasprivilege(int al_componentid, int al_regionid)
        //{
        //    string ls_Null;
        //    ls_null = null;
        //    return this.of_hasprivilege(al_componentid, al_regionid, ls_null);
        //}

        //public virtual bool of_hasprivilege(int al_componentid, string as_privilege)
        //{
        //    int ll_Null;
        //    ll_Null = null;
        //    return this.of_hasprivilege(al_componentid, ll_Null, as_privilege);
        //}

        //public virtual string of_get_privilege(int al_componentid, int al_regionid, string as_privilege) {
        //    int ll_Row;
        //    string ls_FindString;
        //    if (ids_User_Group_Rights.RowCount == 0) {
        //        return "";
        //    }
        //    ls_FindString = "rc_id=" + al_componentid.ToString() + " and  ( region_id=" + al_regionid.ToString() + " or region_id=0) and ";
        //    string TestExpr = as_privilege;
        //    if (TestExpr == inv_Constant.is_READ) {
        //        ls_FindString += "rur_read=\'Y\'";
        //    }
        //    else if (TestExpr == inv_Constant.is_CREATE) {
        //        ls_FindString += "rur_create=\'Y\'";
        //    }
        //    else if (TestExpr == inv_Constant.is_MODIFY) {
        //        ls_FindString += "rur_modify=\'Y\'";
        //    }
        //    else if (TestExpr == inv_Constant.is_DELETE) {
        //        ls_FindString += "rur_delete=\'Y\'";
        //    }
        //    ll_Row = ids_User_Group_Rights.Find( ls_FindString ).Length);
        //    return "";
        //}

        public virtual bool of_hasprivilege(int? al_componentid, int? al_regionid, string as_privilege)
        {
            int ll_Row;
            string ls_FindString;
            List<KeyValuePair<string, object>> l_find = new List<KeyValuePair<string, object>>();
            if (ids_User_Group_Rights.RowCount == 0)
            {
                return false;
            }
            l_find.Add(new KeyValuePair<string, object>("rc_id", al_componentid));//ls_findstring = "rc_id=" + al_componentid.ToString() + " and ";
            if (!((al_regionid == null)))
            {
                l_find.Add(new KeyValuePair<string, object>("region_id", al_regionid));//ls_findstring += " ( region_id=" + al_regionid.ToString() + " ) and ";
            }
            if (as_privilege != null && as_privilege.Length > 0)
            {
                string TestExpr = as_privilege;
                if (TestExpr == "R")
                {
                    l_find.Add(new KeyValuePair<string, object>("rur_read", "Y"));//ls_findstring += "rur_read=\'Y\'";
                }
                else if (TestExpr == "C")
                {
                    l_find.Add(new KeyValuePair<string, object>("rur_create", "Y"));//ls_findstring += "rur_create=\'Y\'";
                }
                else if (TestExpr == "M")
                {
                    l_find.Add(new KeyValuePair<string, object>("rur_modify", "Y"));//ls_findstring += "rur_modify=\'Y\'";
                }
                else if (TestExpr == "D")
                {
                    l_find.Add(new KeyValuePair<string, object>("rur_delete", "Y"));//ls_findstring += "rur_delete=\'Y\'";
                }
            }
            else
            {
                //?ls_findstring += " (  rur_read=\'Y\' or ";
                //ls_findstring += "rur_create=\'Y\' or ";
                //ls_findstring += "rur_modify=\'Y\' or ";
                //ls_findstring += "rur_delete=\'Y\' )";
            }
            //if (Right(ls_findstring, 5) == " and ") {
            //    ls_findstring =  TextUtil.Left(ls_findstring,  ls_findstring.Len() - 4);
            //}
            ll_Row = ids_User_Group_Rights.Find(l_find);//ll_row = ids_User_Group_Rights.Find( ls_findstring ).Length);
            return ll_Row >= 0;
        }

        public virtual bool of_hasprivilege_menu(int al_componentid)
        {
            int ll_Row;
            string ls_FindString;
            if (ids_User_Group_Rights.RowCount == 0)
            {
                return false;
            }
            ls_FindString = "rc_id=" + al_componentid.ToString();
            ll_Row = ids_User_Group_Rights.Find("rc_id", al_componentid);//ids_User_Group_Rights.Find( ls_FindString);
            return ll_Row > -1;
        }
    }
}

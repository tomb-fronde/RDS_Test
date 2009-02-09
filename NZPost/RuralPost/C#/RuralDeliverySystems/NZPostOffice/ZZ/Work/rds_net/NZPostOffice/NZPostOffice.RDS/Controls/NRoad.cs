using System;
using NZPostOffice.RDS.DataControls.Ruraldw;
using NZPostOffice.RDS.DataControls.Ruralwin;
using NZPostOffice.Shared;
using System.Collections.Generic;
using NZPostOffice.RDS.Entity.Ruraldw;
using NZPostOffice.RDS.Entity.Ruralwin;
using Metex.Windows;
using NZPostOffice.RDS.Windows.Ruralwin;
using System.Text.RegularExpressions;

namespace NZPostOffice.RDS.Controls
{

    public class NRoad
    {

        public Metex.Windows.DataUserControl ids_road_map;

        public Metex.Windows.DataUserControl ids_road_suburb_map;

        public Metex.Windows.DataUserControl ids_road_town_map;

        public Metex.Windows.DataUserControl ids_town_suburb_map;

        public Metex.Windows.DataUserControl ids_dwc_road_type;

        public Metex.Windows.DataUserControl ids_dwc_suburb;

        public Metex.Windows.DataUserControl ids_dwc_town;

        public Metex.Windows.DataUserControl ids_dwc_road_suffix;

        public Metex.Windows.DataUserControl ids_road_list;

        public NRoad()
        {
            this.constructor();
        }    
     
        public virtual void constructor()
        {
            //?base.constructor();
            //ids_road_map = new n_ds();
            //ids_road_map.DataObject = "d_road_map_v2";
            //ids_road_map.of_settransobject(StaticVariables.sqlca);
            ids_road_map = new DRoadMapV2();

            ((DRoadMapV2)ids_road_map).Retrieve();        //ids_road_map.Retrieve();

            //ids_road_list.DataObject = "d_road_list";
            //ids_road_list.of_settransobject(StaticVariables.sqlca);
            ids_road_list = new DRoadList();
            ((DRoadList)ids_road_list).Retrieve();        //ids_road_list.Retrieve();

            //ids_dwc_road_type.DataObject = "d_dddw_road_type";
            //ids_dwc_road_type.of_settransobject(StaticVariables.sqlca);
            ids_dwc_road_type = new DDddwRoadType();
            ((DDddwRoadType)ids_dwc_road_type).Retrieve();//ids_dwc_road_type.Retrieve();

            //ids_dwc_road_suffix.DataObject = "d_dddw_road_suffix";
            //ids_dwc_road_suffix.of_settransobject(StaticVariables.sqlca);
            ids_dwc_road_suffix = new DDddwRoadSuffix();
            ((DDddwRoadSuffix)ids_dwc_road_suffix).Retrieve(); //ids_dwc_road_suffix.Retrieve();
        }

        public virtual string of_getnextmatch(string as_partial)
        {
            int ll_found = 0;
            string ls_found;
            //?ids_road_map.FilterString = "";
            //?ids_road_map.Filter<RoadMapV2>();
            as_partial = as_partial.ToLower().Trim();
            if (as_partial.Substring(as_partial.Length - 1) != "%")
            {
                as_partial = as_partial + "%";
            }
            ll_found = ids_road_map.Find(true, new KeyValuePair<string, object>("road_name", as_partial));//ll_found = ids_road_map.Find( "lower ( road_name) like \"" + as_partial + '\"') .Length);
            if (ll_found > 0)
            {
                ls_found = ids_road_map.GetValue<string>(ll_found, "road_name");
                return ls_found;
            }
            else
            {
                return "";
            }
        }
     
        //public virtual bool of_validate_keypress() {
        //    bool lb_return = false;
        //    if (KeyDown(key0!) || KeyDown(key1!) || KeyDown(key2!) || KeyDown(key3!) || KeyDown(key4!) || KeyDown(key5!) || KeyDown(key6!) || KeyDown(key7!) || KeyDown(key8!) || KeyDown(key9!) || KeyDown(keya!) || KeyDown(keyb!) || KeyDown(keyc!) || KeyDown(keyd!) || KeyDown(keye!) || KeyDown(keyf!) || KeyDown(keyg!) || KeyDown(keyh!) || KeyDown(keyi!) || KeyDown(keyj!) || KeyDown(keyk!) || KeyDown(keyl!) || KeyDown(keym!) || KeyDown(keyn!) || KeyDown(keyo!) || KeyDown(keyp!) || KeyDown(keyq!) || KeyDown(keyr!) || KeyDown(keys!) || KeyDown(keyt!) || KeyDown(keyu!) || KeyDown(keyv!) || KeyDown(keyw!) || KeyDown(keyx!) || KeyDown(keyy!) || KeyDown(keyz!)) {
        //        lb_return = true;
        //    }
        //    return lb_return;
        //}

        //! //ids_road_map.SetFilter("lower ( road_name)=\"" + Lower( as_road_name).Trim() + '\"');
        private bool FilterRoadName(RoadMapV2 item)
        {
            if (!string.IsNullOrEmpty(RoadName) && !string.IsNullOrEmpty(item.RoadName) && 
                item.RoadName.Trim().ToLower() == RoadName.Trim().ToLower())
            {
                return true;
            }

            return false;
        }

        private string RoadName = null;
        List<int?> id = null;
        public virtual bool of_filterroadtype(string as_road_name, ref Metex.Windows.DataUserControl adwc_data)
        {
            int ll_x = 0;
            string ls_filter = "";
            string ls_filter_null_clause = "";
            bool lb_rt_it_exist = false;
            bool ib_continue = true;
            adwc_data.FilterString = "";
            //adwc_data.Filter();
            id = new List<int?>();
            RoadName = as_road_name;

            if (adwc_data is DDddwRoadType)
            {
                if (adwc_data.FilterString == "")
                adwc_data.FilterOnce<DddwRoadType>(EmptyFilter);
                else
                adwc_data.Filter<DddwRoadType>();
            }
            if ((as_road_name == null) || as_road_name.Trim().Length == 0)//if (IsNull(as_road_name) ||  as_road_name).Trim(.Len() == 0)
            {
                ib_continue = false;
            }
            if (ib_continue)
            {
                //ids_road_map.SetFilter("lower ( road_name)=\"" + Lower( as_road_name).Trim() + '\"');
                ids_road_map.FilterString = "lower ( road_name)=\"" + as_road_name.ToLower().Trim() + "\"";
                //ids_road_map.Filter();
                ids_road_map.FilterOnce<RoadMapV2>(FilterRoadName);
                if (ids_road_map.RowCount <= 0)
                {
                    ib_continue = false;
                }
            }
            if (ib_continue)
            {
                for (ll_x = 0; ll_x < ids_road_map.RowCount; ll_x++)
                {
                    lb_rt_it_exist = true;
                    if ((ids_road_map.GetItem<RoadMapV2>(ll_x).RtId == null)) //if (IsNull(ids_road_map.GetItemNumber(ll_x, "rt_id")))
                    {
                        ls_filter_null_clause = " or isNull ( rt_id)";
                        id.Add(ids_road_map.GetItem<RoadMapV2>(ll_x).RtId);
                    }
                    else
                    {
                        if (ls_filter.Length > 0) //if (ls_filter.Len() > 0)
                        {
                            ls_filter = ls_filter + ", ";
                        }
                        ls_filter = ls_filter + ids_road_map.GetItem<RoadMapV2>(ll_x).RtId.GetValueOrDefault().ToString();//ls_filter = ls_filter + String(ids_road_map.GetItemNumber(ll_x, "rt_id"));
                        id.Add(ids_road_map.GetItem<RoadMapV2>(ll_x).RtId);
                    }
                }
                ls_filter = "rt_id in  (" + ls_filter + ')' + ls_filter_null_clause;
                if (lb_rt_it_exist == false || (ls_filter == null))
                {
                    ls_filter = "IsNull ( rt_id)";
                }
                adwc_data.FilterString = ls_filter;//adwc_data.SetFilter(ls_filter);
                //adwc_data.Filter();
                if (adwc_data is DDddwRoadType)
                {
                    adwc_data.FilterOnce<DddwRoadType>(filterRoadType);
                }
            }
            ids_road_map.FilterString = "";
            ids_road_map.FilterOnce<RoadMapV2>(EmptyFilter);//ids_road_map.Filter();
            return ib_continue;
        }      

        private bool filterRoadType(DddwRoadType item)
        {
            foreach (int? rt_id in id)
            {
                if (rt_id == item.RtId || rt_id == -100)//! allow empty record pass filter criteria
                {
                    return true;
                }
            }
            return false;
        }

        //public virtual bool of_filtersuburbtype(int al_road_id, ref DataControlBuilder adwc_data) {
        //    int ll_x = 0;
        //    string ls_filter = "";
        //    bool lb_continue = true;
        //    adwc_data.FilterString = "";
        //    adwc_data.Filter();
        //    if (IsNull(al_road_id)) {
        //        lb_continue = false;
        //    }
        //    if (lb_continue) {
        //        ids_road_suburb_map.SetFilter("road_id=" + al_road_id).ToString();
        //        ids_road_suburb_map.Filter();
        //        if (ids_road_suburb_map.RowCount <= 0) {
        //            lb_continue = false;
        //        }
        //    }
        //    if (lb_continue) {
        //        ls_filter = "sl_id in  ( ";
        //        for (ll_x = 1; ll_x <= ids_road_suburb_map.RowCount; ll_x++) {
        //            ls_filter = ls_filter + String(ids_road_suburb_map.GetItemNumber(ll_x, "sl_id"));
        //            if (ll_x < ids_road_suburb_map.RowCount) {
        //                ls_filter = ls_filter + ", ";
        //            }
        //        }
        //        ls_filter = ls_filter + ')';
        //        adwc_data.SetFilter(ls_filter);
        //        adwc_data.Filter();
        //    }
        //    ids_road_suburb_map.FilterString = "";
        //    ids_road_suburb_map.Filter();
        //    return lb_continue;
        //}

        //public virtual bool of_filtertownbysuburb(int al_sl_id, ref DataControlBuilder adwc_data) {
        //    int ll_x = 0;
        //    string ls_filter = "";
        //    bool ib_continue = true;
        //    adwc_data.FilterString = "";
        //    adwc_data.Filter();
        //    if (IsNull(al_sl_id)) {
        //        ib_continue = false;
        //    }
        //    if (ib_continue) {
        //        ids_town_suburb_map.SetFilter("sl_id=" + al_sl_id).ToString();
        //        ids_town_suburb_map.Filter();
        //        if (ids_town_suburb_map.RowCount <= 0) {
        //            ib_continue = false;
        //        }
        //    }
        //    if (ib_continue) {
        //        ls_filter = "tc_id in  ( ";
        //        for (ll_x = 1; ll_x <= ids_town_suburb_map.RowCount; ll_x++) {
        //            ls_filter = ls_filter + String(ids_town_suburb_map.GetItemNumber(ll_x, "tc_id"));
        //            if (ll_x < ids_town_suburb_map.RowCount) {
        //                ls_filter = ls_filter + ", ";
        //            }
        //        }
        //        ls_filter = ls_filter + ')';
        //        adwc_data.SetFilter(ls_filter);
        //        adwc_data.Filter();
        //    }
        //    ids_town_suburb_map.FilterString = "";
        //    ids_town_suburb_map.Filter();
        //    return ib_continue;
        //}

        public virtual bool of_filtertowntype(int? al_road_id, ref DataUserControl adwc_data)
        {
            int ll_x = 0;
            string ls_filter = "";
            int? ll_rtid;
            int? ll_rsid;
            int ll_row;
            string ls_road_name;
            string ls_searcharg;
            bool ib_continue = true;
            adwc_data.FilterString = "";
            //adwc_data.Filter();
            if (adwc_data is DRoadMapV2)
            {
                adwc_data.Filter<RoadMapV2>();
            }
            if (al_road_id == null)
            {
                ib_continue = false;
            }
            if (ib_continue)
            {
                ids_road_map.FilterString = "";
                ids_road_map.Filter<RoadMapV2>();
                ll_row = ids_road_map.Find("road_id = ", al_road_id.ToString());
                if (ll_row > 0)
                {
                    ls_road_name = ids_road_map.GetValue<string>(ll_row, "road_name");
                    ll_rtid = ids_road_map.GetValue<int?>(ll_row, "rt_id");
                    ll_rsid = ids_road_map.GetValue<int?>(ll_row, "rs_id");
                    ls_searcharg = "road_name = \'" + ls_road_name + '\'';
                    if (!(ll_rtid == null) && ll_rtid > 0)
                    {
                        ls_searcharg += " and rt_id = " + ll_rtid.ToString();
                    }
                    if (!(ll_rsid == null) && ll_rsid > 0)
                    {
                        ls_searcharg += " and rs_id = " + ll_rsid.ToString();
                    }
                    ids_road_town_map.FilterString = ls_searcharg;//.SetFilter(ls_searcharg);
                    //?ids_road_town_map.Filter();
                    if (adwc_data is DRoadMapV2)
                    {
                        adwc_data.Filter<RoadMapV2>();
                    }
                }
                else
                {
                    ids_road_town_map.FilterString = "road_id = 0";
                    //?ids_road_town_map.Filter();
                }
                if (ids_road_town_map.RowCount <= 0)
                {
                    ib_continue = false;
                }
            }
            if (ib_continue)
            {
                ls_filter = "tc_id in  ( ";
                for (ll_x = 0; ll_x < ids_road_town_map.RowCount; ll_x++)
                {
                    ls_filter = ls_filter + ids_road_town_map.GetValue<string>(ll_x, "tc_id");
                    if (ll_x < ids_road_town_map.RowCount)
                    {
                        ls_filter = ls_filter + ", ";
                    }
                }
                ls_filter = ls_filter + ")";
                adwc_data.FilterString = ls_filter;//.SetFilter(ls_filter);
                //?adwc_data.Filter();
            }
            ids_road_town_map.FilterString = "";
            //?ids_road_town_map.Filter();
            if (adwc_data is DRoadMapV2)
            {
                adwc_data.Filter<RoadMapV2>();
            }
            return ib_continue;
        }

        //public virtual int of_findsuburbbyroad(int al_road_id, int al_suburb_id) {
        //    int ll_found = 0;
        //    ll_found = ids_road_suburb_map.Find( "road_id=" + al_road_id.ToString() + " AND sl_id = " + al_suburb_id).ToString().Length);
        //    return ll_found;
        //}

        //public virtual int of_findtownbyroad(int al_road_id, int al_tc_id) {
        //    int ll_found = 0;
        //    ll_found = ids_road_town_map.Find( "road_id=" + al_road_id.ToString() + " AND tc_id = " + al_tc_id).ToString().Length);
        //    return ll_found;
        //}

        //public virtual int of_findtownbysuburb(int al_sl_id, int al_tc_id) {
        //    int ll_found = 0;
        //    ll_found = ids_town_suburb_map.RowCount;
        //    ll_found = ids_town_suburb_map.Find( "sl_id=" + al_sl_id.ToString() + " AND tc_id = " + al_tc_id).ToString().Length);
        //    return ll_found;
        //}

        //public virtual bool of_filtersuburbbytown(int al_tc_id, ref DataControlBuilder adwc_data) {
        //    int ll_x = 0;
        //    string ls_filter = "";
        //    bool ib_continue = true;
        //    adwc_data.FilterString = "";
        //    adwc_data.Filter();
        //    if (IsNull(al_tc_id)) {
        //        ib_continue = false;
        //    }
        //    if (ib_continue) {
        //        ids_town_suburb_map.SetFilter("tc_id=" + al_tc_id).ToString();
        //        ids_town_suburb_map.Filter();
        //        if (ids_town_suburb_map.RowCount <= 0) {
        //            ib_continue = false;
        //        }
        //    }
        //    if (ib_continue) {
        //        ls_filter = "sl_id in  ( ";
        //        for (ll_x = 1; ll_x <= ids_town_suburb_map.RowCount; ll_x++) {
        //            ls_filter = ls_filter + String(ids_town_suburb_map.GetItemNumber(ll_x, "sl_id"));
        //            if (ll_x < ids_town_suburb_map.RowCount) {
        //                ls_filter = ls_filter + ", ";
        //            }
        //        }
        //        ls_filter = ls_filter + ')';
        //        adwc_data.SetFilter(ls_filter);
        //        adwc_data.Filter();
        //    }
        //    ids_town_suburb_map.FilterString = "";
        //    ids_town_suburb_map.Filter();
        //    return ib_continue;
        //}

        //public virtual bool of_filtertownbysuburbandroad(int al_sl_id, int al_road_id, ref DataControlBuilder adwc_data) {
        //    int ll_x = 0;
        //    int ll_y = 0;
        //    string ls_filter = "";
        //    bool ib_continue = true;
        //    int ll_town_sub_count;
        //    int ll_town_road_count;
        //    int ll_null;
        //    string ls_null;
        //    ll_null = null;
        //    ls_null = null;
        //    adwc_data.FilterString = "";
        //    adwc_data.Filter();
        //    if (IsNull(al_sl_id)) {
        //        ib_continue = false;
        //    }
        //    if (ib_continue) {
        //        ids_town_suburb_map.FilterString = "";
        //        if (!(IsNull(al_sl_id)) && al_sl_id != 0) {
        //            ids_town_suburb_map.SetFilter("sl_id=" + al_sl_id).ToString();
        //        }
        //        ids_town_suburb_map.Filter();
        //        if (ids_town_suburb_map.RowCount <= 0) {
        //            ib_continue = false;
        //        }
        //        ids_road_town_map.FilterString = "";
        //        if (!(IsNull(al_road_id)) && al_road_id != 0) {
        //            ids_road_town_map.SetFilter("road_id=" + al_road_id).ToString();
        //        }
        //        ids_road_town_map.Filter();
        //        if (ids_road_town_map.RowCount <= 0) {
        //            ib_continue = false;
        //        }
        //    }
        //    if (ib_continue) {
        //        ls_filter = "tc_id in  ( ";
        //        ll_town_sub_count = ids_town_suburb_map.RowCount;
        //        ll_town_road_count = ids_road_town_map.RowCount;
        //        for (ll_x = 1; ll_x <= ll_town_sub_count; ll_x++) {
        //            int ll_sl_tc;
        //            ll_sl_tc = ids_town_suburb_map.GetItemNumber(ll_x, "tc_id");
        //            if (!(IsNull(al_road_id)) && al_road_id != 0) {
        //                for (ll_y = 1; ll_y <= ll_town_road_count; ll_y++) {
        //                    int ll_tc_rd;
        //                    ll_tc_rd = ids_road_town_map.GetItemNumber(ll_y, "tc_id");
        //                    if (ll_sl_tc == ll_tc_rd) {
        //                        ls_filter = ls_filter + ll_tc_rd.ToString();
        //                        if (ll_x < ll_town_sub_count && ll_y < ll_town_road_count) {
        //                            ls_filter = ls_filter + ", ";
        //                        }
        //                    }
        //                }
        //            }
        //            else {
        //                ls_filter = ls_filter + ll_sl_tc.ToString();
        //                if (ll_x < ll_town_sub_count) {
        //                    ls_filter = ls_filter + ", ";
        //                }
        //            }
        //        }
        //        if (Pos(ls_filter, ',',  ls_filter.Len() - 2) != 0) {
        //            ls_filter = Replace(ls_filter,  ls_filter.Len() - 1, 2, ' ');
        //            ls_filter =  ls_filter.Trim();
        //        }
        //        ls_filter = ls_filter + ')';
        //        if (ls_filter == "tc_id in  ( )") {
        //            ls_filter = "tc_id = -1";
        //        }
        //        adwc_data.SetFilter(ls_filter);
        //        adwc_data.Filter();
        //    }
        //    ids_town_suburb_map.FilterString = "";
        //    ids_town_suburb_map.Filter();
        //    ids_road_town_map.FilterString = "";
        //    ids_road_town_map.Filter();
        //    return ib_continue;
        //}

        //public virtual string of_gettownmatch(string as_partial) {
        //    int ll_found = 0;
        //    ids_road_town_map.FilterString = "";
        //    ids_road_town_map.Filter();
        //    as_partial = Lower( as_partial).Trim();
        //    if (Mid(as_partial,  as_partial).Len() != '%') {
        //        as_partial = as_partial + '%';
        //    }
        //    ll_found = ids_road_town_map.Find( "lower ( town_name) like \"" + as_partial + '\"' ).Length);
        //    if (ll_found > 0) {
        //        return ids_road_town_map.GetItemString(ll_found, "town_name");
        //    }
        //    else {
        //        return "";
        //    }
        //}

        public virtual bool of_split_string(string as_source, ref string as_number, ref string as_alpha, ref string as_unit)
        {
            string ls_number = "";
            string ls_alpha = "";
            string ls_unit = "";
            string ls_char = "";
            string ls_source = null;
            int li_x;
            int li_y;
            if (as_source != null)
            {
                ls_source = as_source.Trim();
                //if (Match(ls_source, "[^A-Za-z0-9]"))
                Regex l_reg = new Regex("[^A-Za-z0-9]");
                if (l_reg.Match(ls_source).Value != "")
                {
                    li_x = ls_source.IndexOf('/');//TextUtil.Pos(ls_source, '/');
                    li_y = ls_source.IndexOf('-');//TextUtil.Pos(ls_source, '-');
                    if (li_y < 0)
                    {
                        //?li_x = li_x;
                    }
                    else if (li_x < 0)
                    {
                        li_x = li_y;
                    }
                    else
                    {
                        li_x = Math.Min(li_x, li_y);
                    }
                    if (li_x > 0)
                    {
                        ls_unit = ls_source.Substring(0, li_x);//TextUtil.Left(ls_source, li_x - 1);
                        ls_source = ls_source.Substring(ls_source.Length - li_x);//TextUtil.Right(ls_source, ls_source.Len() - li_x);
                    }
                }
                //if (Match(ls_source, "[^A-Za-z0-9]"))
                l_reg = new Regex("[^A-Za-z0-9]");
                if (l_reg.Match(ls_source).Value != "")
                {
                    return false;
                }
                //if (Match(ls_source, "[^A-Za-z]"))
                l_reg = new Regex("[^A-Za-z]");
                if (l_reg.Match(ls_source).Value != "")
                {
                    for (li_x = 0; li_x < ls_source.Length; li_x++)
                    {
                        ls_char = ls_source.Substring(li_x, 1);
                        if (char.IsDigit(ls_char[0]))
                        {
                            ls_number = ls_number + ls_char;
                        }
                        else
                        {
                            ls_alpha = ls_source.Substring(li_x).TrimStart().ToUpper();
                            break;
                        }
                    }
                }
                else
                {
                    ls_number = ls_source;
                }
            }
            if (ls_number == "")
            {
                as_number = null;
            }
            else
            {
                as_number = ls_number;
            }
            if (ls_alpha == "")
            {
                as_alpha = null;
            }
            else
            {
                as_alpha = ls_alpha.ToUpper();
            }
            if (ls_unit == "")
            {
                as_unit = null;
            }
            else
            {
                as_unit = ls_unit.ToUpper();
            }
            return true;
        }

        //public virtual int of_createroad(string as_road_name, int al_rt_id, int al_sl_id, int al_tc_id, int al_rs_id) {
        //    int ll_row;
        //    int ll_road_id;
        //    int li_rc;
        //    bool lb_continue = true;
        //    ll_road_id = null;
        //    if (IsNull(as_road_name) ||  as_road_name).Trim(.Len() <= 0) {
        //        return ll_road_id;
        //    }
        //    ll_road_id = StaticVariables.gnv_app.of_get_nextsequence("Road");
        //    ll_row = ids_road_map.InsertRow(1);
        //    ids_road_map.SetItem(ll_row, "road_id", ll_road_id);
        //    ids_road_map.SetItem(ll_row, "road_name", as_road_name);
        //    ids_road_map.SetItem(ll_row, "rt_id", al_rt_id);
        //    ids_road_map.SetItem(ll_row, "rs_id", al_rs_id);
        //    if (al_tc_id > 0) {
        //        ll_row = ids_road_town_map.InsertRow(1);
        //        ids_road_town_map.SetItem(ll_row, "tc_id", al_tc_id);
        //        ids_road_town_map.SetItem(ll_row, "road_id", ll_road_id);
        //    }
        //    EXECUTE IMMEDIATE 'BEGIN TRANSACTION';
        //    li_rc = ids_road_map.Update(true, false);
        //    if (li_rc == FAILURE) {
        //        lb_continue = false;
        //    }
        //    if (lb_continue == true) {
        //        li_rc = ids_road_town_map.Update(true, false);
        //        if (li_rc == FAILURE) {
        //            lb_continue = false;
        //        }
        //    }
        //    if (lb_continue == true) {
        //        EXECUTE IMMEDIATE 'COMMIT';
        //    }
        //    else {
        //        EXECUTE IMMEDIATE 'ROLLBACK';
        //    }
        //    EXECUTE IMMEDIATE 'END TRANSACTION';
        //    ids_road_map.ResetUpdate();
        //    ids_road_town_map.ResetUpdate();
        //    if (lb_continue == false) {
        //        ll_road_id = null;
        //    }
        //    return ll_road_id;
        //}

        public virtual int? of_getroadid(string as_roadname, int? al_roadtype, int? al_roadsuffix)
        {
            int ll_found = 0;
            int? ll_road_id;
            string ls_find = "";
            ll_road_id = null;
            //ls_find = "lower ( road_name)= \"" +  as_roadname.ToLower().Trim() + "\"";

            List<KeyValuePair<string, object>> l_find = new List<KeyValuePair<string, object>>();
            l_find.Add(new KeyValuePair<string, object>("road_name", as_roadname.Trim()));

            if (al_roadtype == null || al_roadtype <= 0)
            {
                //ls_find = ls_find + " AND IsNull ( rt_id)";
                l_find.Add(new KeyValuePair<string, object>("rt_id", null));
            }
            else
            {
                //ls_find = ls_find + " AND rt_id = " + al_roadtype.ToString();
                l_find.Add(new KeyValuePair<string, object>("rt_id", al_roadtype.ToString()));
            }
            if (al_roadsuffix == null || al_roadsuffix <= 0)
            {
                //ls_find = ls_find + " AND IsNull ( rs_id)";
                l_find.Add(new KeyValuePair<string, object>("rs_id", null));
            }
            else
            {
                //ls_find = ls_find + " AND rs_id = " + al_roadsuffix.ToString();
                l_find.Add(new KeyValuePair<string, object>("rs_id", al_roadsuffix.ToString()));
            }
            ll_found = ids_road_map.Find(l_find, true);//).Length;
            if (ll_found > 0)
            {
                ll_road_id = ids_road_map.GetValue<int>(ll_found, "road_id");
            }
            return ll_road_id;
        }


        //! ls_filter = "lower ( road_name)=\"" + Lower(as_road_name).Trim() + '\"';
        //! if (!((al_rt_id == null)) && al_rt_id > 0)
        //!        {
        //!            ls_filter = ls_filter + " AND rt_id = " + al_rt_id.ToString();
        //!        }    
        bool FilterRoadMap(RoadMapV2 item) 
        {
            if (!string.IsNullOrEmpty(AsRoadName) && !string.IsNullOrEmpty(item.RoadName) &&
                item.RoadName.ToLower() == AsRoadName.ToLower() &&
                AlRtId > 0 && item.RtId == AlRtId
                )
            {
                return true;
            }
            return false;
        }

        bool EmptyFilter(Metex.Core.IEntity item)
        {            
            return true;         
        }

        bool ComplexFilter(DddwRoadSuffix record) 
        {
            return true;
        }      

        int? AlRtId = null;
        string AsRoadName = string.Empty;
        public virtual bool of_filterroadsuffix(string as_road_name, int? al_rt_id, ref Metex.Windows.DataUserControl adwc_data)
        {
            int ll_x;
            int? ll_rs_id;
            string ls_filter;
            string ls_filter_null_clause;
            bool lb_rs_it_exist;
            bool ib_continue;
            adwc_data.FilterString = "";

            //! added to be used for filtering
            AlRtId = al_rt_id;
            AsRoadName = as_road_name;

            //adwc_data.Filter();
            if (adwc_data is DDddwRoadSuffix)
            {
                adwc_data.Filter<DddwRoadSuffix>();
            }
            ib_continue = true;
            if ((as_road_name == null) || as_road_name.Trim().Length == 0) //if (IsNull(as_road_name) ||  as_road_name).Trim(.Len() == 0) {
            {
                ib_continue = false;
            }
            if (ib_continue)
            {
                ls_filter = "lower ( road_name)=\"" + as_road_name.ToLower().Trim() + "\""; //ls_filter = "lower ( road_name)=\"" + Lower(as_road_name).Trim() + '\"';
                if (!((al_rt_id == null)) && al_rt_id > 0)
                {
                    ls_filter = ls_filter + " AND rt_id = " + al_rt_id.ToString();
                }
                ids_road_map.FilterString = ls_filter;//ids_road_map.SetFilter(ls_filter);
                ids_road_map.FilterOnce<RoadMapV2>(FilterRoadMap);//ids_road_map.Filter();
                if (ids_road_map.RowCount <= 0)
                {
                    //  no road with that name and type
                    ib_continue = false;
                }
            }
            ls_filter = "";
            ls_filter_null_clause = "";
            lb_rs_it_exist = false;
            if (ib_continue)
            {
                for (ll_x = 0; ll_x < ids_road_map.RowCount; ll_x++)
                {
                    lb_rs_it_exist = true;
                    ll_rs_id = ids_road_map.GetItem<RoadMapV2>(ll_x).RsId; //ll_rs_id = ids_road_map.GetItemNumber(ll_x, "rs_id");
                    if ((ll_rs_id == null))
                    {
                        ls_filter_null_clause = " isNull ( rs_id)";
                    }
                    else if (ls_filter.Length < 1)
                    {
                        ls_filter = ll_rs_id.ToString();
                    }
                    else
                    {
                        ls_filter = ls_filter + ", " + ll_rs_id.ToString();
                    }
                }
                if (ls_filter == "")
                {
                    ls_filter = ls_filter_null_clause;
                }
                else
                {
                    ls_filter = "rs_id in  ( " + ls_filter + ")";
                    if (!(ls_filter_null_clause == ""))
                    {
                        ls_filter = ls_filter + " or " + ls_filter_null_clause;
                    }
                }
                if (lb_rs_it_exist == false || ls_filter == "")
                {
                    ls_filter = "IsNull ( rt_id)";
                }
                adwc_data.FilterString = ls_filter;//adwc_data.SetFilter(ls_filter);
                //adwc_data.Filter();
                if (adwc_data is DDddwRoadSuffix)
                {
                    adwc_data.FilterOnce<DddwRoadSuffix>(ComplexFilter);
                }
            }
            ids_road_map.FilterString = "";
            ids_road_map.FilterOnce<RoadMapV2>(EmptyFilter);//ids_road_map.Filter();
            return ib_continue;
        }
     

        //public virtual int of_findroad(string as_roadname, int al_roadtype, int al_roadsuffix) {
        //    int ll_found = 0;
        //    ll_found = ids_road_map.Find( "lower ( road_name)= \"" + Lower( as_roadname).Trim() + '\"' + " AND rt_id = " + al_roadtype.ToString() + " AND rs_id = " + al_roadsuffix.ToString() + '\"' ).Length);
        //    return ll_found;
        //}

        //public virtual bool of_filtersuburbbytownandroad(int al_road_id, int al_tc_id, ref DataControlBuilder adwc_data) {
        //    int ll_sl_tc;
        //    int ll_sl_rd;
        //    int ll_x = 0;
        //    int ll_y = 0;
        //    string ls_filter;
        //    bool ib_continue = true;
        //    int ll_town_sub_count;
        //    int ll_sub_road_count;
        //    int ll_null;
        //    ll_null = null;
        //    adwc_data.FilterString = "";
        //    adwc_data.Filter();
        //    if (IsNull(al_tc_id)) {
        //        ib_continue = false;
        //    }
        //    if (ib_continue) {
        //        ids_town_suburb_map.FilterString = "";
        //        if (!(IsNull(al_tc_id)) && al_tc_id != 0) {
        //            ids_town_suburb_map.SetFilter("tc_id=" + al_tc_id).ToString();
        //        }
        //        ids_town_suburb_map.Filter();
        //        if (ids_town_suburb_map.RowCount <= 0) {
        //            ib_continue = false;
        //        }
        //        ids_road_suburb_map.FilterString = "";
        //        if (!(IsNull(al_road_id)) && al_road_id != 0) {
        //            ids_road_suburb_map.SetFilter("road_id=" + al_road_id).ToString();
        //        }
        //        ids_road_suburb_map.Filter();
        //        if (ids_road_suburb_map.RowCount <= 0) {
        //            ib_continue = false;
        //        }
        //    }
        //    if (ib_continue) {
        //        ls_filter = "";
        //        ll_town_sub_count = ids_town_suburb_map.RowCount;
        //        ll_sub_road_count = ids_road_suburb_map.RowCount;
        //        if (!(IsNull(al_road_id)) && al_road_id != 0) {
        //            for (ll_x = 1; ll_x <= ll_town_sub_count; ll_x++) {
        //                ll_sl_tc = ids_town_suburb_map.GetItemNumber(ll_x, "sl_id");
        //                for (ll_y = 1; ll_y <= ll_sub_road_count; ll_y++) {
        //                    ll_sl_rd = ids_road_suburb_map.GetItemNumber(ll_y, "sl_id");
        //                    if (ll_sl_tc == ll_sl_rd) {
        //                        ls_filter = ls_filter + ", " + ll_sl_rd.ToString();
        //                    }
        //                }
        //            }
        //        }
        //        else {
        //            for (ll_x = 1; ll_x <= ll_town_sub_count; ll_x++) {
        //                ll_sl_tc = ids_town_suburb_map.GetItemNumber(ll_x, "sl_id");
        //                ls_filter = ls_filter + ", " + ll_sl_tc.ToString();
        //            }
        //        }
        //        if ( ls_filter.Len() > 0) {
        //            ls_filter = "sl_id in  ( " +  TextUtil.Right(ls_filter,  ls_filter.Len() - 2) + ')';
        //        }
        //        else {
        //            ls_filter = "sl_id < 0";
        //        }
        //        adwc_data.SetFilter(ls_filter);
        //        adwc_data.Filter();
        //    }
        //    ids_town_suburb_map.FilterString = "";
        //    ids_town_suburb_map.Filter();
        //    ids_road_town_map.FilterString = "";
        //    ids_road_town_map.Filter();
        //    return ib_continue;
        //}

        public virtual int? of_getroadid(string as_roadname, int? al_roadtype, int? al_roadsuffix, int? al_mailtown)
        {
            int ll_found = 0;
            int? ll_road_id;
            //string ls_find = "";
            ll_road_id = 0;
            List<KeyValuePair<string, object>> l_find = new List<KeyValuePair<string, object>>();
            l_find.Add(new KeyValuePair<string, object>("road_name", as_roadname.Trim()));//ls_find = "lower ( road_name)= \"" + Lower( as_roadname).Trim() + '\"';

            if ((al_roadtype == null) || al_roadtype <= 0)
            {
                l_find.Add(new KeyValuePair<string, object>("rt_id", null));//ls_find = ls_find + " AND IsNull ( rt_id)";
            }
            else
            {
                l_find.Add(new KeyValuePair<string, object>("rt_id", al_roadtype));//ls_find = ls_find + " AND rt_id = " + al_roadtype.ToString();
            }
            if ((al_roadsuffix == null) || al_roadsuffix <= 0)
            {
                l_find.Add(new KeyValuePair<string, object>("rs_id", null));//ls_find = ls_find + " AND IsNull ( rs_id)";
            }
            else
            {
                l_find.Add(new KeyValuePair<string, object>("rs_id", al_roadsuffix));//ls_find = ls_find + " AND rs_id = " + al_roadsuffix.ToString();
            }
            if ((al_mailtown == null) || al_mailtown <= 0)
            {
            }
            else
            {
                l_find.Add(new KeyValuePair<string, object>("tc_id", al_mailtown));//ls_find = ls_find + " AND tc_id = " + al_mailtown.ToString();
            }
            ll_found = ids_road_map.Find(l_find, true);//ll_found = ids_road_map.Find( ls_find ).Length);
            if (ll_found >= 0)
            {
                ll_road_id = ids_road_map.GetItem<RoadMapV2>(ll_found).RoadId; //ll_road_id = ids_road_map.GetItemNumber(ll_found, "road_id");
            }
            return ll_road_id;
        }

        public virtual bool of_filtertowntype(string as_road_name, int? al_rtid, int? al_rsid, Metex.Windows.DataUserControl adwc_data)
        {
            int ll_x = 0;
            int ll_row;
            string ls_filter = "";
            bool ib_continue = true;
            adwc_data.FilterString = "";
            //adwc_data.Filter();
            if (adwc_data is DDddwTownOnly)
            {
                adwc_data.Filter<DddwTownOnly>();
            }
            if (ib_continue)
            {
                ids_road_map.FilterString = "";
                ids_road_map.Filter<RoadMapV2>(); //ids_road_map.Filter();
                if (!((as_road_name == null)))
                {
                    ls_filter = "road_name = \'" + as_road_name + "\'";
                    if (!((al_rtid == null)) && al_rtid > 0)
                    {
                        ls_filter += " and rt_id = " + al_rtid.ToString();
                    }
                    if (!((al_rsid == null)) && al_rsid > 0)
                    {
                        ls_filter += " and rs_id = " + al_rsid.ToString();
                    }
                    ids_road_town_map.FilterString = ls_filter;//ids_road_town_map.SetFilter(ls_filter);
                    //?ids_road_town_map.Filter();
                }
                else
                {
                    ids_road_town_map.FilterString = "road_id = 0";
                    //?ids_road_town_map.Filter();
                }
                if (ids_road_town_map.RowCount <= 0)
                {
                    ib_continue = false;
                }
            }
            if (ib_continue)
            {
                ls_filter = "tc_id in  ( ";
                for (ll_x = 1; ll_x <= ids_road_town_map.RowCount; ll_x++)
                {
                    //?ls_filter = ls_filter + String(ids_road_town_map.GetItemNumber(ll_x, "tc_id"));
                    if (ll_x < ids_road_town_map.RowCount)
                    {
                        ls_filter = ls_filter + ", ";
                    }
                }
                ls_filter = ls_filter + ")";
                adwc_data.FilterString = ls_filter;//adwc_data.SetFilter(ls_filter);
                //adwc_data.Filter();
                if (adwc_data is DDddwTownOnly)
                {
                    adwc_data.Filter<DddwTownOnly>();
                }
            }
            ids_road_town_map.FilterString = "";
            //?ids_road_town_map.Filter();
            return ib_continue;
        }

        //public virtual bool of_filtersuburbtype(string as_roadname, int al_rtid, int al_rsid, DataControlBuilder adwc_data) {
        //    int ll_x;
        //    int ll_i;
        //    int ll_slid;
        //    string ls_filter;
        //    bool lb_continue;
        //    lb_continue = true;
        //    adwc_data.FilterString = "";
        //    adwc_data.Filter();
        //    if (!(IsNull(as_roadname))) {
        //        ls_filter = "road_name = \'" + as_roadname + '\'';
        //        if (!(IsNull(al_rtid))) {
        //            ls_filter += " and rt_id = " + al_rtid.ToString();
        //        }
        //        if (!(IsNull(al_rsid))) {
        //            ls_filter += " and rs_id = " + al_rsid.ToString();
        //        }
        //        ids_road_suburb_map.SetFilter(ls_filter);
        //        ids_road_suburb_map.Filter();
        //        if (ids_road_suburb_map.RowCount <= 0) {
        //            lb_continue = false;
        //        }
        //    }
        //    if (lb_continue) {
        //        ll_i = 0;
        //        for (ll_x = 1; ll_x <= ids_road_suburb_map.RowCount; ll_x++) {
        //            ll_slid = ids_road_suburb_map.GetItemNumber(ll_x, "sl_id");
        //            if (!(IsNull(ll_slid))) {
        //                ll_i++;
        //                if (ll_i < 2) {
        //                    ls_filter += ll_slid.ToString();
        //                }
        //                else {
        //                    ls_filter += ", " + ll_slid.ToString();
        //                }
        //            }
        //        }
        //        if (ll_i > 0) {
        //            ls_filter = "sl_id in  ( " + ls_filter + ')';
        //            adwc_data.SetFilter(ls_filter);
        //            adwc_data.Filter();
        //        }
        //    }
        //    ids_road_suburb_map.FilterString = "";
        //    ids_road_suburb_map.Filter();
        //    return lb_continue;
        //}

        private int? il_tcid;
        private bool PredicateTcId(RoadList entity)
        {
            return entity.TcId == il_tcid;
        }

        private bool FilterRoadList(RoadList item) 
        {
            if (string.IsNullOrEmpty(AsRoadname) &&
                (!AlRtid.HasValue || AlRtid <= 0) &&
                (!AlRsid.HasValue || AlRsid <= 0) &&
                (!AlTcid.HasValue || AlTcid <= 0))
            {
                //! return "";
                return true;
            }

            
            //ls_search = "";
            if (!string.IsNullOrEmpty(AsRoadname))
            {
                //!ls_search = "road_name=\"" + as_roadname + '\"';
                if (item.RoadName != AsRoadname)
                {
                    return false;
                }
                
            }
            if (AlRtid > 0)
            {
                //!if (ls_search == "")
                //{
                //    ls_search = "rt_id=" + al_rtid.ToString();
                //}
                //else
                //{
                //    ls_search += " and rt_id=" + al_rtid.ToString();
                //!}
                if (item.RtId != AlRtid)
                {
                    return false;
                }
            }
            if (AlRsid > 0)
            {
                //!if (ls_search == "")
                //{
                //    ls_search = "rs_id=" + al_rsid.ToString();
                //}
                //else
                //{
                //    ls_search += " and rs_id=" + al_rsid.ToString();
                //!}
                if (item.RsId != AlRsid)
                {
                    return false;
                }
            }
            if (AlTcid > 0)
            {
                //!if (ls_search == "")
                //{
                //    ls_search = "tc_id=" + al_tcid.ToString();
                //}
                //else
                //{
                //    ls_search += " and tc_id=" + al_tcid.ToString();
                //!}
                if (item.TcId != AlTcid)
                {
                    return false;
                }
            }

            return true;
        }

        //! class variables for filtering support
        string AsRoadname = string.Empty;
        int? AlRtid, AlRsid, AlTcid;
        public virtual string of_getsuburblist(string as_roadname, int? al_rtid, int? al_rsid, int? al_tcid)
        {
            int ll_row;
            int ll_rows;
            string ls_filter;
            string ls_temp;
            string ls_search;

            AsRoadname = as_roadname;
            AlRtid = al_rtid;
            AlRsid = al_rsid;
            AlTcid = al_tcid;

            if (string.IsNullOrEmpty(as_roadname) && 
                (!al_rtid.HasValue || al_rtid <= 0) && 
                (!al_rsid.HasValue || al_rsid <= 0) && 
                (!al_tcid.HasValue || al_tcid <= 0))
            {
                return "";
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((al_tcid == null) || al_tcid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "tc_id=" + al_tcid.ToString();
                }
                else
                {
                    ls_search += " and tc_id=" + al_tcid.ToString();
                }
            }

            // Filter the road_list            
            ids_road_list.FilterString = ls_search;
            ids_road_list.FilterOnce<RoadList>(FilterRoadList);
            /*!
            if (ls_search.IndexOf("tc_id=") >= 0)
            {
                //! temporary workaround for tc_id
                il_tcid = al_tcid;
                ids_road_list.FilterOnce<RoadList>(new Predicate<RoadList>(PredicateTcId));
            }
            else
            {
                ids_road_list.Filter<RoadList>();
            }
             */ 

            // Build a list of the suburbs found
            // If none, ll_rows will be 0 and ls_filter will be ''
            ls_filter = "";
            ll_rows = ids_road_list.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ls_temp = ids_road_list.GetItem<RoadList>(ll_row).SlName;//.GetItemString(ll_row, "sl_name");
                if (!((ls_temp == null)))
                {
                    if (ls_filter == "")
                    {
                        //!ls_filter = '\"' + ls_temp + '\"';
                        ls_filter = ls_temp;
                    }
                    else
                    {
                        //!ls_filter += ", \"" + ls_temp + '\"';
                        ls_filter += ", " + ls_temp + "";
                    }
                }
            }
            ids_road_list.FilterString = "";
            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter == "")
            {
                ls_filter = "\"xxxxxx\"";
            }
            return ls_filter;
        }     

        public virtual System.Collections.Generic.Dictionary<string, int> of_getsuburblist_asdict(string as_roadname, int? al_rtid, int? al_rsid, int? al_tcid)
        {
            int ll_row;
            int ll_rows;
            System.Collections.Generic.Dictionary<string, int> ls_filter = new Dictionary<string, int>();
            string ls_temp;
            string ls_search;
            if (((as_roadname == null) || as_roadname == "") && ((al_rtid == null) || al_rtid <= 0) && ((al_rsid == null) || al_rsid <= 0) && ((al_tcid == null) || al_tcid <= 0))
            {
                return ls_filter;
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((al_tcid == null) || al_tcid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "tc_id=" + al_tcid.ToString();
                }
                else
                {
                    ls_search += " and tc_id=" + al_tcid.ToString();
                }
            }
            //ids_road_list.SetFilter(ls_search);
            ids_road_list.FilterString = ls_search;
            //ids_road_list.Filter();
            if (ls_search.IndexOf("tc_id=") >= 0)
            {
                //! temporary workaround for tc_id
                il_tcid = al_tcid;
                ids_road_list.FilterOnce<RoadList>(new Predicate<RoadList>(PredicateTcId));
            }
            else
            {
                ids_road_list.Filter<RoadList>();
            }
            ll_rows = ids_road_list.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ls_temp = ids_road_list.GetItem<RoadList>(ll_row).SlName;//.GetItemString(ll_row, "sl_name");
                if (!((ls_temp == null)))
                {
                    if (!ls_filter.ContainsKey(ls_temp))
                        ls_filter.Add(ls_temp, 0);
                }
            }
            ids_road_list.FilterString = "";
            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter.Count == 0)
            {
                ls_filter.Add("xxxxxx", 0);
            }
            return ls_filter;
        }

        private bool FilterTown(RoadList item)
        {
            int found = 0;
            if (string.IsNullOrEmpty(AsRoadName) && 
                (AlRtid <= 0) && (AlRsid <= 0) && 
                string.IsNullOrEmpty(AsSlName)
                )
            {
                //!return "";
                return true;
            }

            //!ls_search = "";
            if (!string.IsNullOrEmpty(AsRoadName))
            {
                //!ls_search = "road_name=\"" + as_roadname + '\"';
                if (item.RoadName != AsRoadname)
                {
                    return false;
                }
                else
                {
                    found++;
                }
            }
            if (AlRtid > 0)
            {
                //!if (ls_search == "")
                //{
                //    ls_search = "rt_id=" + al_rtid.ToString();
                //}
                //else
                //{
                //    ls_search += " and rt_id=" + al_rtid.ToString();
                //!}
                if (item.RtId != AlRtid)
                {
                    return false;
                }
                else {
                    found++;
                }
            }
            if (AlRsid > 0)
            {
                //!if (ls_search == "")
                //{
                //    ls_search = "rs_id=" + al_rsid.ToString();
                //}
                //else
                //{
                //    ls_search += " and rs_id=" + al_rsid.ToString();
                //!}
                if (item.RsId != AlRsid)
                {
                    return false;
                }
                else
                {
                    found++;
                }
            }
            if (!string.IsNullOrEmpty(AsSlName) && !(AsSlName == " "))
            {
                //!if (ls_search == "")
                //{
                //    ls_search = "sl_name=\"" + as_slname + '\"';
                //}
                //else
                //{
                //    ls_search += " and sl_name=\"" + as_slname + '\"';
                //!}
                if (item.SlName != AsSlName)
                {
                    return false;
                }
                else {
                    found++;
                }
            }

            if (found > 0)//! in case of match accept the recod
            {
                found = 0;
                return true;
            }
            else {
                return false;
            }

           
        }

        string AsSlName = string.Empty; //! added to support filtering
        public virtual string of_gettownlist(string as_roadname, int? al_rtid, int? al_rsid, string as_slname)
        {
            int ll_row;
            int ll_rows;
            string ls_filter;
            string ls_temp;
            string ls_search;

            AsRoadName = as_roadname; 
            AlRtid = al_rtid;
            AlRsid = al_rsid;
            AsSlName = as_slname;

            if (((as_roadname == null) || as_roadname == "") && ((al_rtid == null) || al_rtid <= 0) &&
                ((al_rsid == null) || al_rsid <= 0) && ((as_slname == null) || as_slname == ""))
            {
                return "";
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((as_slname == null) || as_slname == ""))
            {
                if (ls_search == "")
                {
                    ls_search = "sl_name=\"" + as_slname + '\"';
                }
                else
                {
                    ls_search += " and sl_name=\"" + as_slname + '\"';
                }
            }
            ids_road_list.FilterString = ls_search;//ids_road_list.SetFilter(ls_search);
            ids_road_list.FilterOnce<RoadList>(FilterTown);//ids_road_list.Filter();
            ll_rows = ids_road_list.RowCount;
            ls_filter = "";
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ls_temp = ids_road_list.GetItem<RoadList>(ll_row).TcId.ToString();//ls_temp = String(ids_road_list.GetItemNumber(ll_row, "tc_id"));
                if (!((ls_temp == null)))
                {
                    if (ls_filter == "")
                    {
                        ls_filter = ls_temp;
                    }
                    else
                    {
                        ls_filter += ", " + ls_temp;
                    }
                }
            }
            ids_road_list.FilterString = "";
            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter == "")
            {
                ls_filter = "-1";
            }
            return ls_filter;
        }      

        public virtual Dictionary<int, int> of_gettownlist_asdict(string as_roadname, int? al_rtid, int? al_rsid, string as_slname)
        {
            int ll_row;
            int ll_rows;
            Dictionary<int, int> ls_filter = new Dictionary<int, int>();
            int? li_temp;
            string ls_search;
            if (((as_roadname == null) || as_roadname == "") && ((al_rtid == null) || al_rtid <= 0) && 
                ((al_rsid == null) || al_rsid <= 0) && ((as_slname == null) || as_slname == ""))
            {
                return ls_filter;
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((as_slname == null) || as_slname == "" || as_slname == " "))
            {
                if (ls_search == "")
                {
                    ls_search = "sl_name=\"" + as_slname + '\"';
                }
                else
                {
                    ls_search += " and sl_name=\"" + as_slname + '\"';
                }
            }
            ids_road_list.FilterString = ls_search;//ids_road_list.SetFilter(ls_search);
            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            ll_rows = ids_road_list.RowCount;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                li_temp = ids_road_list.GetItem<RoadList>(ll_row).TcId;//ls_temp = String(ids_road_list.GetItemNumber(ll_row, "tc_id"));
                if (!((li_temp == null)))
                {
                    if (!ls_filter.ContainsKey((int)li_temp))
                        ls_filter.Add((int)li_temp, 0);
                }
            }
            ids_road_list.FilterString = "";
            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter.Count == 0)
            {
                ls_filter.Add(-1, 0);
            }
            return ls_filter;
        }

        //public virtual int of_lookup_suburbid(string as_slname, int al_tcid) {
        //    int ll_slid;
        //    int ll_rows;
        //    string ls_search;
        //    if (IsNull(as_slname) || as_slname == "" || IsNull(al_tcid) || al_tcid <= 0) {
        //        return 0;
        //    }
        //    ls_search = "sl_name = " + as_slname + " and tc_id = " + al_tcid.ToString();
        //    ids_road_list.SetFilter(ls_search);
        //    ids_road_list.Filter();
        //    ll_rows = ids_road_list.RowCount;
        //    if (ll_rows > 0) {
        //        ll_slid = ids_road_list.GetItemNumber(1, "sl_id");
        //    }
        //    else {
        //        ll_slid = 0;
        //    }
        //    ids_road_list.FilterString = "";
        //    ids_road_list.Filter();
        //    return ll_slid;
        //}

        //public virtual void of_updatemappings(int al_road_id, int al_sl_id, int al_tc_id) {
        //    int ll_row;
        //    int li_rc;
        //    bool lb_continue = true;
        //    if (al_tc_id > 0) {
        //        if (of_findtownbyroad(al_road_id, al_tc_id) <= 0) {
        //            ll_row = ids_road_town_map.InsertRow(1);
        //            ids_road_town_map.SetItem(ll_row, "tc_id", al_tc_id);
        //            ids_road_town_map.SetItem(ll_row, "road_id", al_road_id);
        //        }
        //    }
        //    EXECUTE IMMEDIATE 'BEGIN TRANSACTION';
        //    if (li_rc == FAILURE) {
        //        lb_continue = false;
        //    }
        //    if (lb_continue == true) {
        //        li_rc = ids_road_town_map.Update(true, false);
        //        if (li_rc == FAILURE) {
        //            lb_continue = false;
        //        }
        //    }
        //    if (lb_continue == true) {
        //        EXECUTE IMMEDIATE 'COMMIT';
        //    }
        //    else {
        //        EXECUTE IMMEDIATE 'ROLLBACK';
        //    }
        //    EXECUTE IMMEDIATE 'END TRANSACTION';
        //    ids_road_town_map.ResetUpdate();
        //}

        //public virtual void of_open_address(int al_adr_id, int al_cust_id) {
        //    int ll_null;
        //    string ls_Title;
        //    string ls_null;
        //    n_criteria lnv_Criteria;
        //    n_rds_msg lnv_msg;
        //    //?WMaintainAddress lw_maintain;
        //    ll_null = null;
        //    ls_null = null;
        //    lnv_Criteria = new n_criteria();
        //    lnv_msg = new n_rds_msg();
        //    ls_Title = "Address  ( " + al_adr_id.ToString() + ')';
        //    lnv_Criteria.of_addcriteria("adr_id", al_adr_id);
        //    lnv_Criteria.of_addcriteria("cust_id", al_cust_id);
        //    lnv_Criteria.of_addcriteria("title", ls_null);
        //    lnv_Criteria.of_addcriteria("adr_no", ls_null);
        //    lnv_Criteria.of_addcriteria("road_name", ls_null);
        //    lnv_Criteria.of_addcriteria("rt_id", ll_null);
        //    lnv_Criteria.of_addcriteria("rs_id", ll_null);
        //    lnv_Criteria.of_addcriteria("sl_id", ll_null);
        //    lnv_Criteria.of_addcriteria("tc_id", ll_null);
        //    lnv_Criteria.of_addcriteria("adr_rd_no", ls_null);
        //    lnv_msg.of_addcriteria(lnv_Criteria);
        //    if (!(IsValid(StaticVariables.gnv_app.of_findwindow_partial(ls_Title, "w_maintain_address")))) {
        //        OpenSheetWithParm(lw_maintain, lnv_msg, w_main_mdi, 0, original!);
        //    }
        //}

        public virtual void of_open_address(int? al_adr_id, int? al_cust_id, int? al_rdcontractselect)
        {
            int? ll_null;
            string ls_null;
            string ls_Title;
            NRdsMsg lnv_msg;
            NCriteria lnv_Criteria;
            //?WMaintainAddress lw_maintain;
            ll_null = null;
            ls_null = null;
            lnv_Criteria = new NCriteria();
            lnv_msg = new NRdsMsg();
            ls_Title = "Address  ( " + al_adr_id.ToString() + ")";
            lnv_Criteria.of_addcriteria("adr_id", al_adr_id);
            lnv_Criteria.of_addcriteria("cust_id", al_cust_id);
            lnv_Criteria.of_addcriteria("title", ls_null);
            lnv_Criteria.of_addcriteria("adr_no", ls_null);
            lnv_Criteria.of_addcriteria("road_name", ls_null);
            lnv_Criteria.of_addcriteria("rt_id", ll_null);
            lnv_Criteria.of_addcriteria("rs_id", ll_null);
            lnv_Criteria.of_addcriteria("sl_id", ll_null);
            lnv_Criteria.of_addcriteria("tc_id", ll_null);
            lnv_Criteria.of_addcriteria("adr_rd_no", ls_null);
            lnv_Criteria.of_addcriteria("rd_Contract_Select", al_rdcontractselect);
            lnv_msg.of_addcriteria(lnv_Criteria);
            if (true/*?StaticVariables.gnv_app.of_findwindow_partial(ls_Title, "w_maintain_address") == null*/)
            {
                // OpenSheetWithParm(lw_maintain, lnv_msg, w_main_mdi, 0, original!);
                StaticMessage.PowerObjectParm = lnv_msg;
                WMaintainAddress w_maintan_address = new WMaintainAddress();
                w_maintan_address.MdiParent = StaticVariables.MainMDI;
                w_maintan_address.Show();
            //   NZPostOffice.Shared.VisualComponents.FormBase.OpenSheet<NZPostOffice.RDS.Windows.Ruralwin.WMaintainAddress>(StaticVariables.MainMDI);
            }
        }

        //PP!############################ Following functions and constructor added to make WAddressSearch performance better, ##################
        //!############################ the approach is to replace DataWindows with Lists of business entites ###################################
        List<RoadMapV2> ids_road_mapList = new List<RoadMapV2>();
        List<RoadList> ids_road_listList = new List<RoadList>();
        List<DddwRoadType> ids_dwc_road_typeList = new List<DddwRoadType>();
        List<DddwRoadSuffix> ids_dwc_road_suffixList = new List<DddwRoadSuffix>();

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public NRoad(string arraysUsed)
        {
            this.constructor1();
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual void constructor1()
        {
            //?base.constructor();
            //ids_road_map = new n_ds();
            //ids_road_map.DataObject = "d_road_map_v2";
            //ids_road_map.of_settransobject(StaticVariables.sqlca);
            //!ids_road_map = new DRoadMapV2();

            //!((DRoadMapV2)ids_road_map).Retrieve();        //ids_road_map.Retrieve();
            ids_road_mapList = RoadMapV2.GetAllRoadMapV2();

            //ids_road_list.DataObject = "d_road_list";
            //ids_road_list.of_settransobject(StaticVariables.sqlca);
            //!ids_road_list = new DRoadList();
            //!((DRoadList)ids_road_list).Retrieve();        //ids_road_list.Retrieve();
            ids_road_listList = RoadList.GetAllRoadList();

            //ids_dwc_road_type.DataObject = "d_dddw_road_type";
            //ids_dwc_road_type.of_settransobject(StaticVariables.sqlca);
            //!ids_dwc_road_type = new DDddwRoadType();
            //!((DDddwRoadType)ids_dwc_road_type).Retrieve();//ids_dwc_road_type.Retrieve();
            ids_dwc_road_typeList = new List<DddwRoadType>(DddwRoadType.GetAllDddwRoadType());

            //ids_dwc_road_suffix.DataObject = "d_dddw_road_suffix";
            //ids_dwc_road_suffix.of_settransobject(StaticVariables.sqlca);
            //!ids_dwc_road_suffix = new DDddwRoadSuffix();
            //!((DDddwRoadSuffix)ids_dwc_road_suffix).Retrieve(); //ids_dwc_road_suffix.Retrieve();
            ids_dwc_road_suffixList = new List<DddwRoadSuffix>(DddwRoadSuffix.GetAllDddwRoadSuffix());
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual string of_getnextmatch1(string as_partial)
        {
            int ll_found = -1;
            string ls_found;
            //?ids_road_map.FilterString = "";
            //?ids_road_map.Filter<RoadMapV2>();
            as_partial = as_partial.ToLower().Trim();
            if (as_partial.Substring(as_partial.Length - 1) != "%")
            {
//!                as_partial = as_partial + "%";
            }

            //!ll_found = ids_road_map.Find(true, new KeyValuePair<string, object>("road_name", as_partial));//ll_found = ids_road_map.Find( "lower ( road_name) like \"" + as_partial + '\"') .Length);
            for (int i = 0; i < ids_road_mapList.Count; i++)
            {
                if (!string.IsNullOrEmpty(ids_road_mapList[i].RoadName) && !string.IsNullOrEmpty(as_partial) &&
                    ids_road_mapList[i].RoadName.ToLower().StartsWith(as_partial.ToLower()))
                {
                    ll_found = i;
                    break;
                }
            }

            if (ll_found >= 0)
            {
                //!ls_found = ids_road_map.GetValue<string>(ll_found, "road_name");
                ls_found = ids_road_mapList[ll_found].RoadName;
                return ls_found;
            }
            else
            {
                return "";
            }
        }

        //! WSearchAddress - added new function trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual bool of_filterroadtype1(string as_road_name, ref Metex.Windows.DataUserControl adwc_data)
        {
            int ll_x = 0;
            string ls_filter = "";
            string ls_filter_null_clause = "";
            bool lb_rt_it_exist = false;
            bool ib_continue = true;
            adwc_data.FilterString = "";
            //adwc_data.Filter();
            id = new List<int?>();
            RoadName = as_road_name;
            List<RoadMapV2> ids_road_mapFilteredList = new List<RoadMapV2>();

            adwc_data.FilterString = "";
            adwc_data.FilterOnce<DddwRoadType>(EmptyFilter);

            if (string.IsNullOrEmpty(as_road_name))//if (IsNull(as_road_name) ||  as_road_name).Trim(.Len() == 0)
            {
                ib_continue = false;
            }
            if (ib_continue)
            {
                //ids_road_map.SetFilter("lower ( road_name)=\"" + Lower( as_road_name).Trim() + '\"');
//!                ids_road_map.FilterString = "lower ( road_name)=\"" + as_road_name.ToLower().Trim() + "\"";

                //ids_road_map.Filter();
                //!ids_road_map.FilterOnce<RoadMapV2>(FilterRoadName);                
                foreach (RoadMapV2 item in ids_road_mapList)
                {
                    if (!string.IsNullOrEmpty(item.RoadName) && item.RoadName.ToLower() == as_road_name.ToLower())
                    {
                        bool found = false;
                        foreach (RoadMapV2 filteredItem in ids_road_mapFilteredList)
                        {
                            if (filteredItem.RtId == item.RtId)//! avoid repetitions                            
                            {
                                found = true;
                                break;
                            }                            
                        }
                        if (!found)
                        {
                            ids_road_mapFilteredList.Add(item);
                        }
                    }
                }


                //!if (ids_road_map.RowCount <= 0)
                if (ids_road_mapFilteredList.Count <= 0)
                {
                    ib_continue = false;
                }
            }
            if (ib_continue)
            {
                //!for (ll_x = 0; ll_x < ids_road_map.RowCount; ll_x++)
                for (ll_x = 0; ll_x < ids_road_mapFilteredList.Count; ll_x++)
                {
                    lb_rt_it_exist = true;
                    //!if ((ids_road_map.GetItem<RoadMapV2>(ll_x).RtId == null)) //if (IsNull(ids_road_map.GetItemNumber(ll_x, "rt_id")))
                    if (!ids_road_mapFilteredList[ll_x].RtId.HasValue)
                    {
                        ls_filter_null_clause = " or isNull ( rt_id)";
                        //!id.Add(ids_road_map.GetItem<RoadMapV2>(ll_x).RtId);
                        id.Add(ids_road_mapFilteredList[ll_x].RtId);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ls_filter)) //if (ls_filter.Len() > 0)
                        {
                            ls_filter = ls_filter + ", ";
                        }
                        //!ls_filter = ls_filter + ids_road_map.GetItem<RoadMapV2>(ll_x).RtId.GetValueOrDefault().ToString();//ls_filter = ls_filter + String(ids_road_map.GetItemNumber(ll_x, "rt_id"));
                        ls_filter = ls_filter + ids_road_mapFilteredList[ll_x].RtId.GetValueOrDefault().ToString();
                        //!id.Add(ids_road_map.GetItem<RoadMapV2>(ll_x).RtId);
                        id.Add(ids_road_mapFilteredList[ll_x].RtId);
                    }
                }
                ls_filter = "rt_id in  (" + ls_filter + ')' + ls_filter_null_clause;
                if (lb_rt_it_exist == false || (ls_filter == null))
                {
                    ls_filter = "IsNull ( rt_id)";
                }
                adwc_data.FilterString = ls_filter;//adwc_data.SetFilter(ls_filter);
                //adwc_data.Filter();
                if (adwc_data is DDddwRoadType)
                {
                    adwc_data.FilterOnce<DddwRoadType>(filterRoadType);
                }
            }

            //! not used
            //!            ids_road_map.FilterString = "";
            //!            ids_road_map.FilterOnce<RoadMapV2>(EmptyFilter);//ids_road_map.Filter();

            return ib_continue;
        }

        bool ComplexFilter1(DddwRoadSuffix record)
        {
            foreach (int? item in rsIdList)
            {
                if (item == record.RsId)
                {
                    return true;
                }
            }
            return false;
        }

        List<int?> rsIdList = new List<int?>();
        bool isRtIdNull = false;
        //! WSearchAddress - added new function trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual bool of_filterroadsuffix1(string as_road_name, int? al_rt_id, ref Metex.Windows.DataUserControl adwc_data)
        {
            int ll_x;
            int? ll_rs_id;
            string ls_filter;
            string ls_filter_null_clause;
            bool lb_rs_id_exist;
            bool ib_continue;
            adwc_data.FilterString = "";

            //! added to be used for filtering
            AlRtId = al_rt_id;
            AsRoadName = as_road_name;
            // TJB  RD7_0021  Feb 2009
            // Added line to empty the rsIdList before starting.  
            // Was repopulated with each call adding on to previous results.
            rsIdList.Clear();

            //adwc_data.Filter();
            //if (adwc_data is DDddwRoadSuffix)
            //{
            //    adwc_data.Filter<DddwRoadSuffix>();
            //}
            if (adwc_data is DDddwRoadSuffix)
            {
                if (adwc_data.FilterString == "" )
                    adwc_data.FilterOnce<DddwRoadSuffix>(EmptyFilter);
                else
                    adwc_data.Filter<DddwRoadSuffix>();
            }

            ib_continue = true;
            if (string.IsNullOrEmpty(as_road_name)) //if (IsNull(as_road_name) ||  as_road_name).Trim(.Len() == 0) {
            {
                ib_continue = false;
            }

            List<RoadMapV2> ids_road_mapListFiltered = new List<RoadMapV2>();
            if (ib_continue)
            {
                ls_filter = "lower ( road_name)=\"" + as_road_name.ToLower().Trim() + "\""; //ls_filter = "lower ( road_name)=\"" + Lower(as_road_name).Trim() + '\"';
                if (!((al_rt_id == null)) && al_rt_id > 0)
                {
                    ls_filter = ls_filter + " AND rt_id = " + al_rt_id.ToString();
                }

                //!ids_road_map.FilterString = ls_filter;//ids_road_map.SetFilter(ls_filter);
//!                ids_road_map.FilterOnce<RoadMapV2>(FilterRoadMap);//ids_road_map.Filter();                
                foreach (RoadMapV2 item in ids_road_mapList)
                {
                    if (!string.IsNullOrEmpty(AsRoadName) && !string.IsNullOrEmpty(item.RoadName) &&
                                item.RoadName.ToLower() == AsRoadName.ToLower() &&
                                AlRtId > 0 && item.RtId == AlRtId)
                    {
                        ids_road_mapListFiltered.Add(item);
                    }
                }


                //!if (ids_road_map.RowCount <= 0)
                if (ids_road_mapListFiltered.Count <= 0)
                {
                    //  no road with that name and type
                    ib_continue = false;
                }
            }
            ls_filter = "";
            ls_filter_null_clause = "";
            lb_rs_id_exist = false;
            if (ib_continue)
            {
                //!for (ll_x = 0; ll_x < ids_road_map.RowCount; ll_x++)
                for (ll_x = 0; ll_x < ids_road_mapListFiltered.Count; ll_x++)
                {
                    lb_rs_id_exist = true;
                    //!ll_rs_id = ids_road_map.GetItem<RoadMapV2>(ll_x).RsId; //ll_rs_id = ids_road_map.GetItemNumber(ll_x, "rs_id");
                    ll_rs_id = ids_road_mapListFiltered[ll_x].RsId;
                    if (!ll_rs_id.HasValue)
                    {
                        ls_filter_null_clause = " isNull ( rs_id)";
                        rsIdList.Add(null);
                    }
                    else if (string.IsNullOrEmpty(ls_filter) || ls_filter.Length < 1)
                    {
                        ls_filter = ll_rs_id.ToString();
                        rsIdList.Add(ll_rs_id);
                    }
                    else
                    {
                        ls_filter = ls_filter + ", " + ll_rs_id.ToString();
                        rsIdList.Add(ll_rs_id);
                    }
                }
                if (ls_filter == "")
                {
                    ls_filter = ls_filter_null_clause;
                }
                else
                {
                    ls_filter = "rs_id in  ( " + ls_filter + ")";
                    if (!(ls_filter_null_clause == ""))
                    {
                        ls_filter = ls_filter + " or " + ls_filter_null_clause;
                    }
                }

                if (lb_rs_id_exist == false || ls_filter == "")
                {
                    ls_filter = "IsNull ( rt_id)";
                    isRtIdNull = true;
                }
                adwc_data.FilterString = ls_filter;//adwc_data.SetFilter(ls_filter);
                //adwc_data.Filter();
                if (adwc_data is DDddwRoadSuffix)
                {
                    adwc_data.FilterOnce<DddwRoadSuffix>(ComplexFilter1);
                }
            }

            //! not used
            //!            ids_road_map.FilterString = "";
            //!            ids_road_map.FilterOnce<RoadMapV2>(EmptyFilter);//ids_road_map.Filter();
            return ib_continue;
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual string of_getsuburblist1(string as_roadname, int? al_rtid, int? al_rsid, int? al_tcid)
        {
            int ll_row;
            int ll_rows;
            string ls_filter;
            string ls_temp;
            string ls_search;

            AsRoadname = as_roadname;
            AlRtid = al_rtid;
            AlRsid = al_rsid;
            AlTcid = al_tcid;

            if (string.IsNullOrEmpty(as_roadname) &&
                (!al_rtid.HasValue || al_rtid <= 0) &&
                (!al_rsid.HasValue || al_rsid <= 0) &&
                (!al_tcid.HasValue || al_tcid <= 0))
            {
                return "";
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((al_tcid == null) || al_tcid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "tc_id=" + al_tcid.ToString();
                }
                else
                {
                    ls_search += " and tc_id=" + al_tcid.ToString();
                }
            }

            List<RoadList> ids_road_listListFiltered = new List<RoadList>();
            // Filter the road_list            
            //!ids_road_list.FilterString = ls_search;
            //!ids_road_list.FilterOnce<RoadList>(FilterRoadList);
            foreach (RoadList item in ids_road_listList)
            {
                if (string.IsNullOrEmpty(AsRoadname) &&
               (!AlRtid.HasValue || AlRtid <= 0) &&
               (!AlRsid.HasValue || AlRsid <= 0) &&
               (!AlTcid.HasValue || AlTcid <= 0))
                {
                    //!return true;
                    ids_road_listListFiltered.Add(item);
                }

                if (!string.IsNullOrEmpty(AsRoadname))
                {
                    //!ls_search = "road_name=\"" + as_roadname + '\"';
                    if (item.RoadName != AsRoadname)
                    {
                        //!return false;
                        continue;
                    }

                }
                if (AlRtid > 0)
                {
                    if (item.RtId != AlRtid)
                    {
                        //!return false;
                        continue;
                    }
                }
                if (AlRsid > 0)
                {
                    if (item.RsId != AlRsid)
                    {
                        //!return false;
                        continue;
                    }
                }
                if (AlTcid > 0)
                {
                    if (item.TcId != AlTcid)
                    {
                        //!return false;
                        continue;
                    }
                }
                //!return true;
                ids_road_listListFiltered.Add(item);
            }



            // Build a list of the suburbs found
            // If none, ll_rows will be 0 and ls_filter will be ''
            ls_filter = "";

            //!ll_rows = ids_road_list.RowCount;
            ll_rows = ids_road_listListFiltered.Count;

            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //!ls_temp = ids_road_list.GetItem<RoadList>(ll_row).SlName;//.GetItemString(ll_row, "sl_name");
                ls_temp = ids_road_listListFiltered[ll_row].SlName;//.GetItemString(ll_row, "sl_name");
                //!if (!((ls_temp == null)))
                if (!string.IsNullOrEmpty(ls_temp))
                {
                    if (ls_filter == "")
                    {
                        //!ls_filter = '\"' + ls_temp + '\"';
                        ls_filter = ls_temp;
                    }
                    else
                    {
                        //!ls_filter += ", \"" + ls_temp + '\"';
                        if (ls_filter.IndexOf(ls_temp) == -1) //! avoids adding same string more than one time
                        {
                            ls_filter += ", " + ls_temp + "";
                        }
                    }
                }
            }

            //! not used
            //!            ids_road_list.FilterString = "";
            //!            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();

            if (ls_filter == "")
            {
                ls_filter = "\"xxxxxx\"";
            }
            return ls_filter;
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual string of_gettownlist1(string as_roadname, int? al_rtid, int? al_rsid, string as_slname)
        {
            int ll_row;
            int ll_rows;
            string ls_filter;
            string ls_temp;
            string ls_search;

            AsRoadName = as_roadname;
            AlRtid = al_rtid;
            AlRsid = al_rsid;
            AsSlName = as_slname;

            if (((as_roadname == null) || as_roadname == "") && ((al_rtid == null) || al_rtid <= 0) &&
                ((al_rsid == null) || al_rsid <= 0) && ((as_slname == null) || as_slname == ""))
            {
                return "";
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((as_slname == null) || as_slname == ""))
            {
                if (ls_search == "")
                {
                    ls_search = "sl_name=\"" + as_slname + '\"';
                }
                else
                {
                    ls_search += " and sl_name=\"" + as_slname + '\"';
                }
            }

            List<RoadList> ids_road_listFilteredList = new List<RoadList>();
            //!ids_road_list.FilterString = ls_search;//ids_road_list.SetFilter(ls_search);
            //!ids_road_list.FilterOnce<RoadList>(FilterTown);//ids_road_list.Filter();
            foreach (RoadList item in ids_road_listList)
            {
                int found = 0;
                if (string.IsNullOrEmpty(AsRoadName) &&
                    (AlRtid <= 0) && (AlRsid <= 0) &&
                    string.IsNullOrEmpty(AsSlName)
                    )
                {
                    ids_road_listFilteredList.Add(item);
                }

                if (!string.IsNullOrEmpty(AsRoadName))
                {
                    if (item.RoadName != AsRoadName)
                    {
                        //!return false; 
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }
                if (AlRtid > 0)
                {
                    if (item.RtId != AlRtid)
                    {
                        //!return false;
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }
                if (AlRsid > 0)
                {
                    if (item.RsId != AlRsid)
                    {
                        //!return false;
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }
                if (!string.IsNullOrEmpty(AsSlName) && !(AsSlName == " "))
                {
                    if (item.SlName != AsSlName)
                    {
                        //!return false;
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }

                if (found > 0)//! in case of match accept the recod
                {
                    found = 0;
                    //!return true;
                    ids_road_listFilteredList.Add(item);
                }
                else
                {
                    //!return false;
                    continue;
                }
            }


            //!ll_rows = ids_road_list.RowCount;
            ll_rows = ids_road_listFilteredList.Count;
            ls_filter = "";
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //!ls_temp = ids_road_list.GetItem<RoadList>(ll_row).TcId.ToString();//ls_temp = String(ids_road_list.GetItemNumber(ll_row, "tc_id"));
                ls_temp = ids_road_listFilteredList[ll_row].TcId.ToString();
                if (!((ls_temp == null)))
                {
                    if (ls_filter == "")
                    {
                        ls_filter = ls_temp;
                    }
                    else
                    {
                        ls_filter += ", " + ls_temp;
                    }
                }
            }

            //!not used
            //!            ids_road_list.FilterString = "";
            //!            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter == "")
            {
                ls_filter = "-1";
            }
            return ls_filter;
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual Dictionary<int, int> of_gettownlist_asdict1(string as_roadname, int? al_rtid, int? al_rsid, string as_slname)
        {
            int ll_row;
            int ll_rows;
            Dictionary<int, int> ls_filter = new Dictionary<int, int>();
            int? li_temp;
            string ls_search;
            if (((as_roadname == null) || as_roadname == "") && ((al_rtid == null) || al_rtid <= 0) &&
                ((al_rsid == null) || al_rsid <= 0) && ((as_slname == null) || as_slname == ""))
            {
                return ls_filter;
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((as_slname == null) || as_slname == "" || as_slname == " "))
            {
                if (ls_search == "")
                {
                    ls_search = "sl_name=\"" + as_slname + '\"';
                }
                else
                {
                    ls_search += " and sl_name=\"" + as_slname + '\"';
                }
            }


//!            ids_road_list.FilterString = ls_search;//ids_road_list.SetFilter(ls_search);
//!            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();

            ll_rows = ids_road_listList.Count;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //!li_temp = ids_road_list.GetItem<RoadList>(ll_row).TcId;//ls_temp = String(ids_road_list.GetItemNumber(ll_row, "tc_id"));
                li_temp = ids_road_listList[ll_row].TcId;
                if (!((li_temp == null)))
                {
                    if (!ls_filter.ContainsKey((int)li_temp))
                        ls_filter.Add((int)li_temp, 0);
                }
            }
//!            ids_road_list.FilterString = "";
//!            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter.Count == 0)
            {
                ls_filter.Add(-1, 0);
            }
            return ls_filter;
        }

        public virtual System.Collections.Generic.Dictionary<string, int> of_getsuburblist_asdict1(string as_roadname, 
            int? al_rtid, int? al_rsid, int? al_tcid)
        {
            int ll_row;
            int ll_rows;
            System.Collections.Generic.Dictionary<string, int> ls_filter = new Dictionary<string, int>();
            string ls_temp;
            string ls_search;
            if (((as_roadname == null) || as_roadname == "") && ((al_rtid == null) || al_rtid <= 0) && 
                ((al_rsid == null) || al_rsid <= 0) && ((al_tcid == null) || al_tcid <= 0))
            {
                return ls_filter;
            }
            ls_search = "";
            if (!((as_roadname == null) || as_roadname == ""))
            {
                ls_search = "road_name=\"" + as_roadname + '\"';
            }
            if (!((al_rtid == null) || al_rtid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rt_id=" + al_rtid.ToString();
                }
                else
                {
                    ls_search += " and rt_id=" + al_rtid.ToString();
                }
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "rs_id=" + al_rsid.ToString();
                }
                else
                {
                    ls_search += " and rs_id=" + al_rsid.ToString();
                }
            }
            if (!((al_tcid == null) || al_tcid <= 0))
            {
                if (ls_search == "")
                {
                    ls_search = "tc_id=" + al_tcid.ToString();
                }
                else
                {
                    ls_search += " and tc_id=" + al_tcid.ToString();
                }
            }
            //ids_road_list.SetFilter(ls_search);
//!            ids_road_list.FilterString = ls_search;
            //ids_road_list.Filter();
//!            if (ls_search.IndexOf("tc_id=") >= 0)
            //{
            //    //! temporary workaround for tc_id
            //    il_tcid = al_tcid;
            //    ids_road_list.FilterOnce<RoadList>(new Predicate<RoadList>(PredicateTcId));
            //}
            //else
            //{
            //    ids_road_list.Filter<RoadList>();
//!            }
            string AsRoadName = as_roadname;
            int? AlRtid = al_rtid;
            int? AlRsid = al_rsid;
            int? AlTcid = al_tcid;

            List<RoadList> ids_road_listFilteredList = new List<RoadList>();
            //!ids_road_list.FilterString = ls_search;//ids_road_list.SetFilter(ls_search);
            //!ids_road_list.FilterOnce<RoadList>(FilterTown);//ids_road_list.Filter();
            foreach (RoadList item in ids_road_listList)
            {
                int found = 0;
                if (string.IsNullOrEmpty(AsRoadName) &&
                    (AlRtid <= 0) && (AlRsid <= 0) &&
                    AlTcid <= 0
                    )
                {
                    ids_road_listFilteredList.Add(item);
                }

                if (!string.IsNullOrEmpty(AsRoadName))
                {
                    if (item.RoadName != AsRoadname)
                    {
                        //!return false; 
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }
                if (AlRtid > 0)
                {
                    if (item.RtId != AlRtid)
                    {
                        //!return false;
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }
                if (AlRsid > 0)
                {
                    if (item.RsId != AlRsid)
                    {
                        //!return false;
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }
                if (AlRsid > 0)
                {
                    if (item.TcId != AlTcid)
                    {
                        //!return false;
                        continue;
                    }
                    else
                    {
                        found++;
                    }
                }

                if (found > 0)//! in case of match accept the recod
                {
                    found = 0;
                    //!return true;
                    ids_road_listFilteredList.Add(item);
                }
                else
                {
                    //!return false;
                    continue;
                }
            }



            ll_rows = ids_road_listFilteredList.Count;


            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                ls_temp = ids_road_listFilteredList[ll_row].SlName;//.GetItemString(ll_row, "sl_name");
                if (!((ls_temp == null)))
                {
                    if (!ls_filter.ContainsKey(ls_temp))
                        ls_filter.Add(ls_temp, 0);
                }
            }
//!            ids_road_list.FilterString = "";
//!            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();
            if (ls_filter.Count == 0)
            {
                ls_filter.Add("xxxxxx", 0);
            }
            return ls_filter;
        }
        //!########################################################################################################################
    }
}



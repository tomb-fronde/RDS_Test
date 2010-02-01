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

        //public virtual bool of_validate_keypress() {
        //    bool lb_return = false;
        //    if (KeyDown(key0!) || KeyDown(key1!) || KeyDown(key2!) || KeyDown(key3!) || KeyDown(key4!) || KeyDown(key5!) || KeyDown(key6!) || KeyDown(key7!) || KeyDown(key8!) || KeyDown(key9!) || KeyDown(keya!) || KeyDown(keyb!) || KeyDown(keyc!) || KeyDown(keyd!) || KeyDown(keye!) || KeyDown(keyf!) || KeyDown(keyg!) || KeyDown(keyh!) || KeyDown(keyi!) || KeyDown(keyj!) || KeyDown(keyk!) || KeyDown(keyl!) || KeyDown(keym!) || KeyDown(keyn!) || KeyDown(keyo!) || KeyDown(keyp!) || KeyDown(keyq!) || KeyDown(keyr!) || KeyDown(keys!) || KeyDown(keyt!) || KeyDown(keyu!) || KeyDown(keyv!) || KeyDown(keyw!) || KeyDown(keyx!) || KeyDown(keyy!) || KeyDown(keyz!)) {
        //        lb_return = true;
        //    }
        //    return lb_return;
        //}

        // TJB: collected these from scattered places; added some 'Private ' qualifiers
        //! class variables for filtering support
        private int? AlRtId = null;
        private int? AlRtid;
        private int? AlRsid;
        private int? AlTcid;
        private int? il_tcid;
        private string RoadName = null;
        private string AsRoadName = string.Empty;
        private string AsRoadname = string.Empty;
        private string AsSlName = string.Empty;
        private List<int?> id = null;
        private List<int?> rsIdList = new List<int?>();

        // TJB  RD7_0042 Jan-2010: Added inv_road.of_clear_fields
        public virtual void of_clear_fields()
        {
            id = null;
            rsIdList.Clear();
            AlRtId = null;
            AlRtid = null;
            AlRsid = null;
            AlTcid = null;
            il_tcid = null;
            RoadName = null;
            AsRoadName = string.Empty;
            AsRoadname = string.Empty;
            AsSlName = string.Empty;
        }

        //! //ids_road_map.SetFilter("lower(road_name)=\"" + Lower(as_road_name).Trim() + '\"');
        private bool FilterRoadName(RoadMapV2 item)
        {
            if (!string.IsNullOrEmpty(RoadName) 
                && !string.IsNullOrEmpty(item.RoadName) 
                && item.RoadName.Trim().ToLower() == RoadName.Trim().ToLower())
            {
                return true;
            }
            return false;
        }

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
                    ids_road_town_map.FilterString = ls_searcharg;
                    if (adwc_data is DRoadMapV2)
                    {
                        adwc_data.Filter<RoadMapV2>();
                    }
                }
                else
                {
                    ids_road_town_map.FilterString = "road_id = 0";
                }
                if (ids_road_town_map.RowCount <= 0)
                {
                    ib_continue = false;
                }
            }
            if (ib_continue)
            {
                ls_filter = "tc_id in (";
                for (ll_x = 0; ll_x < ids_road_town_map.RowCount; ll_x++)
                {
                    ls_filter = ls_filter + ids_road_town_map.GetValue<string>(ll_x, "tc_id");
                    if (ll_x < ids_road_town_map.RowCount)
                    {
                        ls_filter = ls_filter + ", ";
                    }
                }
                ls_filter = ls_filter + ")";
                adwc_data.FilterString = ls_filter;
            }
            ids_road_town_map.FilterString = "";
            if (adwc_data is DRoadMapV2)
            {
                adwc_data.Filter<RoadMapV2>();
            }
            return ib_continue;
        }

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
                    li_x = ls_source.IndexOf('/');
                    li_y = ls_source.IndexOf('-');
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
                        ls_unit = ls_source.Substring(0, li_x);
                        ls_source = ls_source.Substring(ls_source.Length - li_x);
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

        public virtual int? of_getroadid(string as_roadname, int? al_roadtype, int? al_roadsuffix)
        {
            int ll_found = 0;
            int? ll_road_id;
            string ls_find = "";
            ll_road_id = null;
            //ls_find = "lower(road_name)= \"" + as_roadname.ToLower().Trim() + "\"";

            List<KeyValuePair<string, object>> l_find = new List<KeyValuePair<string, object>>();
            l_find.Add(new KeyValuePair<string, object>("road_name", as_roadname.Trim()));

            if (al_roadtype == null || al_roadtype <= 0)
            {
                //ls_find = ls_find + " AND IsNull(rt_id)";
                l_find.Add(new KeyValuePair<string, object>("rt_id", null));
            }
            else
            {
                //ls_find = ls_find + " AND rt_id = " + al_roadtype.ToString();
                l_find.Add(new KeyValuePair<string, object>("rt_id", al_roadtype.ToString()));
            }
            if (al_roadsuffix == null || al_roadsuffix <= 0)
            {
                //ls_find = ls_find + " AND IsNull(rs_id)";
                l_find.Add(new KeyValuePair<string, object>("rs_id", null));
            }
            else
            {
                //ls_find = ls_find + " AND rs_id = " + al_roadsuffix.ToString();
                l_find.Add(new KeyValuePair<string, object>("rs_id", al_roadsuffix.ToString()));
            }
            ll_found = ids_road_map.Find(l_find, true);
            if (ll_found > 0)
            {
                ll_road_id = ids_road_map.GetValue<int>(ll_found, "road_id");
            }
            return ll_road_id;
        }

        //! ls_filter = "lower(road_name)=\"" + Lower(as_road_name).Trim() + '\"';
        //! if (!((al_rt_id == null)) && al_rt_id > 0)
        //!        {
        //!            ls_filter = ls_filter + " AND rt_id = " + al_rt_id.ToString();
        //!        }    
        bool FilterRoadMap(RoadMapV2 item) 
        {
            if (!string.IsNullOrEmpty(AsRoadName) && !string.IsNullOrEmpty(item.RoadName) 
                && item.RoadName.ToLower() == AsRoadName.ToLower() 
                && AlRtId > 0 && item.RtId == AlRtId
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

        bool FilterRoadSuffix(DddwRoadSuffix record) 
        {
            return true;
        }      

        public virtual int? of_getroadid(string as_roadname, int? al_roadtype, int? al_roadsuffix, int? al_mailtown)
        {
            int ll_found = 0;
            int? ll_road_id;
            ll_road_id = 0;

            List<KeyValuePair<string, object>> l_find = new List<KeyValuePair<string, object>>();
            //ls_find = "lower(road_name)= \"" + Lower(as_roadname).Trim() + '\"';
            l_find.Add(new KeyValuePair<string, object>("road_name", as_roadname.Trim()));

            if ((al_roadtype == null) || al_roadtype <= 0)
            {
                //ls_find = ls_find + " AND IsNull(rt_id)";
                l_find.Add(new KeyValuePair<string, object>("rt_id", null));
            }
            else
            {
                //ls_find = ls_find + " AND rt_id = " + al_roadtype.ToString();
                l_find.Add(new KeyValuePair<string, object>("rt_id", al_roadtype));
            }
            if ((al_roadsuffix == null) || al_roadsuffix <= 0)
            {
                //ls_find = ls_find + " AND IsNull(rs_id)";
                l_find.Add(new KeyValuePair<string, object>("rs_id", null));
            }
            else
            {
                //ls_find = ls_find + " AND rs_id = " + al_roadsuffix.ToString();
                l_find.Add(new KeyValuePair<string, object>("rs_id", al_roadsuffix));
            }
            if ((al_mailtown == null) || al_mailtown <= 0)
            {
            }
            else
            {
                //ls_find = ls_find + " AND tc_id = " + al_mailtown.ToString();
                l_find.Add(new KeyValuePair<string, object>("tc_id", al_mailtown));
            }
            //ll_found = ids_road_map.Find(ls_find).Length);
            ll_found = ids_road_map.Find(l_find, true);
            if (ll_found >= 0)
            {
                //ll_road_id = ids_road_map.GetItemNumber(ll_found, "road_id");
                ll_road_id = ids_road_map.GetItem<RoadMapV2>(ll_found).RoadId; 
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
            if (adwc_data is DDddwTownOnly)
            {
                adwc_data.Filter<DddwTownOnly>();
            }
            if (ib_continue)
            {
                ids_road_map.FilterString = "";
                ids_road_map.Filter<RoadMapV2>();
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
                    ids_road_town_map.FilterString = ls_filter;
                }
                else
                {
                    ids_road_town_map.FilterString = "road_id = 0";
                }
                if (ids_road_town_map.RowCount <= 0)
                {
                    ib_continue = false;
                }
            }
            if (ib_continue)
            {
                ls_filter = "tc_id in (";
                for (ll_x = 1; ll_x <= ids_road_town_map.RowCount; ll_x++)
                {
                    //?ls_filter = ls_filter + String(ids_road_town_map.GetItemNumber(ll_x, "tc_id"));
                    if (ll_x < ids_road_town_map.RowCount)
                    {
                        ls_filter = ls_filter + ", ";
                    }
                }
                ls_filter = ls_filter + ")";
                adwc_data.FilterString = ls_filter;
                if (adwc_data is DDddwTownOnly)
                {
                    adwc_data.Filter<DddwTownOnly>();
                }
            }
            ids_road_town_map.FilterString = "";
            //?ids_road_town_map.Filter();
            return ib_continue;
        }

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
                return true;
            }

            if (!string.IsNullOrEmpty(AsRoadname))
            {
                if (item.RoadName != AsRoadname)
                    return false;
            }
            if (AlRtid > 0)
            {
                //!if (ls_search == "")
                //!    ls_search = "rt_id=" + al_rtid.ToString();
                //!else
                //!    ls_search += " and rt_id=" + al_rtid.ToString();
                if (item.RtId != AlRtid)
                    return false;
            }
            if (AlRsid > 0)
            {
                //!if (ls_search == "")
                //!    ls_search = "rs_id=" + al_rsid.ToString();
                //!else
                //!    ls_search += " and rs_id=" + al_rsid.ToString();
                if (item.RsId != AlRsid)
                    return false;
            }
            if (AlTcid > 0)
            {
                //!if (ls_search == "")
                //    ls_search = "tc_id=" + al_tcid.ToString();
                //else
                //    ls_search += " and tc_id=" + al_tcid.ToString();
                if (item.TcId != AlTcid)
                    return false;
            }
            return true;
        }

        private bool FilterTown(RoadList item)
        {
            int found = 0;
            if (string.IsNullOrEmpty(AsRoadName) && 
                (AlRtid <= 0) && (AlRsid <= 0) && 
                string.IsNullOrEmpty(AsSlName)
                )
            {
                return true;
            }

            if (!string.IsNullOrEmpty(AsRoadName))
            {
                if (item.RoadName != AsRoadname)
                    return false;
                else
                    found++;
            }
            if (AlRtid > 0)
            {
                //!if (ls_search == "")
                //    ls_search = "rt_id=" + al_rtid.ToString();
                //else
                //    ls_search += " and rt_id=" + al_rtid.ToString();
                if (item.RtId != AlRtid)
                    return false;
                else
                    found++;
            }
            if (AlRsid > 0)
            {
                //!if (ls_search == "")
                //    ls_search = "rs_id=" + al_rsid.ToString();
                //else
                //    ls_search += " and rs_id=" + al_rsid.ToString();
                if (item.RsId != AlRsid)
                    return false;
                else
                    found++;
            }
            if (!string.IsNullOrEmpty(AsSlName) && !(AsSlName == " "))
            {
                //!if (ls_search == "")
                //    ls_search = "sl_name=\"" + as_slname + '\"';
                //else
                //    ls_search += " and sl_name=\"" + as_slname + '\"';
                if (item.SlName != AsSlName)
                    return false;
                else
                    found++;
            }

            //! in case of match accept the recod
            if (found > 0)
            {
                found = 0;
                return true;
            }
            else
                return false;
        }

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

            /*?if (StaticVariables.gnv_app.of_findwindow_partial(ls_Title, "w_maintain_address") == null)*/
            // OpenSheetWithParm(lw_maintain, lnv_msg, w_main_mdi, 0, original!);
            StaticMessage.PowerObjectParm = lnv_msg;
            WMaintainAddress w_maintan_address = new WMaintainAddress();
            w_maintan_address.MdiParent = StaticVariables.MainMDI;
            w_maintan_address.Show();
            // NZPostOffice.Shared.VisualComponents.FormBase.OpenSheet<NZPostOffice.RDS.Windows.Ruralwin.WMaintainAddress>(StaticVariables.MainMDI);
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
        // Match roadnames.  As the user types in a roadname, check 
        // to see what roads exist beginning with that first part.
        public virtual string of_getnextmatch1(string as_partial)
        {
            int ll_found = -1;
            string ls_found;
            //as_partial = as_partial.ToLower().Trim();
            as_partial = as_partial.ToLower();
//!            if (as_partial.Substring(as_partial.Length - 1) != "%")
//!            {
//!                as_partial = as_partial + "%";
//!            }
            // TJB  RD7_0042  Nov-2009
            // Change to a binary search
            string ls_roadname, ls_roadname_partial;
            int compare_partial;
            int j, k, l, l1, l2, m, n;
            n = 0;
            m = ids_road_mapList.Count;
            l1 = as_partial.Length;
            ll_found = -1;
            while ((m - n) > 8)
            {
                j = ((m - n) / 2) + n;
                ls_roadname = ids_road_mapList[j].RoadName.ToLower();
                l2 = ls_roadname.Length;
                l = (l1 > l2) ? l2 : l1;
                //ls_roadname_partial = ls_roadname.Trim().Substring(0, l);
                ls_roadname_partial = ls_roadname.Substring(0, l);
                compare_partial = String.Compare(ls_roadname_partial, as_partial);
                if (compare_partial == 0)
                {
                    ll_found = j;
                    break;
                }
                if (compare_partial < 0)
                    n = j;
                else
                    m = j;
            }
            if (ll_found < 0)
            {
                for (j = n; j <= m; j++)
                {
                    ls_roadname = ids_road_mapList[j].RoadName.ToLower();
                    l2 = ls_roadname.Length;
                    l = (l1 > l2) ? l2 : l1;
                    //ls_roadname_partial = ls_roadname.Trim().Substring(0, l);
                    ls_roadname_partial = ls_roadname.Substring(0, l);
                    compare_partial = String.Compare(ls_roadname_partial, as_partial);
                    if (compare_partial == 0)
                    {
                        ll_found = j;
                        break;
                    }
                }
            }
//            
//            //!ll_found = ids_road_map.Find(true, new KeyValuePair<string, object>("road_name", as_partial));//ll_found = ids_road_map.Find( "lower ( road_name) like \"" + as_partial + '\"') .Length);
//            for (int i = 0; i < ids_road_mapList.Count; i++)
//            {
//                if (!string.IsNullOrEmpty(ids_road_mapList[i].RoadName) && !string.IsNullOrEmpty(as_partial) &&
//                    ids_road_mapList[i].RoadName.ToLower().StartsWith(as_partial.ToLower()))
//                {
//                    ll_found = i;
//                    break;
//                }
//            }

            // Return the first road found, or "" if none found.
            ls_found = "";
            if (ll_found >= 0)
                ls_found = ids_road_mapList[ll_found].RoadName;

            return ls_found;
        }

        // Filter process for road types
        // This filter process is called once for each element in the road_type dropdown list
        // 'item' is the element being processed.
        // 'id' is the list of road types being searched for
        // The filter returns TRUE if one of the 'id' items matches the 'item'
        // otherwise the filter returns FALSE
        // The FilterOnce method (which calls this filter) marks the relevant rows as selected 
        // when TRUE is returned.
        private bool filterRoadType(DddwRoadType item)
        {
            //! allow empty record pass filter criteria
            foreach (int? rt_id in id)
            {
                if (rt_id == item.RtId)
                    return true;
            }
            return false;
        }

        //! WSearchAddress - added new function trying to replace data windows with BEntity lists, as they are retrieving very slowly
        // TJB  RD7_0042  Jan 2010:  Re-wrote function to simplify
        // Given a road name, filter the road type to list only those that exist for that road name.
        public virtual bool of_filterroadtype1(string as_road_name, ref Metex.Windows.DataUserControl adwc_data)
        {
            // If we aren't given a road name, we can't find anything; 
            //       exit saying we didn't find anything.
            //if (IsNull(as_road_name) || as_road_name).Trim(.Len() == 0)
            if (string.IsNullOrEmpty(as_road_name))
                return false;

            int ll_x = 0;
            string ls_filter = "";
            string ls_filter_null_clause = "";
            string road_name_lowered;

            //adwc_data.Filter();
            id = new List<int?>();
            int id_count = 0;
            RoadName = as_road_name;

            adwc_data.FilterString = "";
            adwc_data.FilterOnce<DddwRoadType>(EmptyFilter);

            // TJB  Dec-2009:  Add null entry to filtered list
            road_name_lowered = as_road_name.ToLower();
            //ids_road_map.SetFilter("lower(road_name)=\"" + Lower(as_road_name).Trim() + '\"');
            //!ids_road_map.FilterString = "lower(road_name)=\"" + as_road_name.ToLower().Trim() + "\"";

            //ids_road_map.Filter();
            //!ids_road_map.FilterOnce<RoadMapV2>(FilterRoadName);                
            foreach (RoadMapV2 item in ids_road_mapList)
            {
                // Search the ids_road_mapList for a matching road name
                if (!string.IsNullOrEmpty(item.RoadName) 
                    && item.RoadName.ToLower() == road_name_lowered)
                {
                    // Add the rt_id to the ids_road_mapFilteredList unless it's already there
                    bool lb_found = false;
                    int? this_RtId = item.RtId;

                    // Scan the list of found rt_id's 
                    foreach (int? filtered_RtId in id)
                    {
                        //! avoid repetitions
                        // If this rt_id matches one already in the list, exit this loop
                        // with the ib_found flag set.
                        if (filtered_RtId == this_RtId)
                        {
                            lb_found = true;
                            break;
                        }
                    }
                    // If we didn't find the rt_id already in the list, add it now.
                    if (!lb_found)
                    {
                        id_count++;
                        if (this_RtId.HasValue)
                        {
                            id.Add(this_RtId);
                            if (ls_filter == "")
                                ls_filter = this_RtId.ToString();
                            else
                                ls_filter = ls_filter + "," + this_RtId.ToString();
                        }
                        else
                            ls_filter_null_clause = "isNull(rt_id)";
                    }
                }
            }

            // If no roadname matches found, return FALSE
            if (id_count <= 0)
                return false;

            // Finalise the filter string.
            if (ls_filter == "")
                ls_filter = ls_filter_null_clause;
            else
            {
                ls_filter = " in (" + ls_filter + ")";
                if (ls_filter_null_clause != "")
                    ls_filter = ls_filter + " or " + ls_filter_null_clause;
            }

            // Add the filter to the rt_id dropdown list
            //adwc_data.SetFilter(ls_filter);
            adwc_data.FilterString = ls_filter;
            //adwc_data.Filter();
            // Apply the filter to the rt_id dropdown list
            if (adwc_data is DDddwRoadType)
                adwc_data.FilterOnce<DddwRoadType>(filterRoadType);

            return true;
        }

        // Filter process for road suffixes
        // This filter process is called once for each element in the road_suffix dropdown list
        // 'record' is the element being processed.
        // 'rsIdList' is the list of road suffixes being searched for
        // The filter returns TRUE if one of the 'rsIdList' items matches the 'record'
        // otherwise the filter returns FALSE.
        // The FilterOnce method (which calls this filter) marks the relevant rows as selected 
        // when TRUE is returned.
        bool FilterRoadSuffix1(DddwRoadSuffix record)
        {
            foreach (int? item in rsIdList)
            {
                if (item == record.RsId)
                    return true;
            }
            return false;
        }

        //! WSearchAddress - added new function trying to replace data windows with BEntity lists, as they are retrieving very slowly
        // TJB  RD7_0042  Jan 2010: Rewrote to simplify
        public virtual bool of_filterroadsuffix1(string as_road_name, int? al_rt_id, ref Metex.Windows.DataUserControl adwc_data)
        {
            // Need a road name to filter on (??)
            //if (string.IsNullOrEmpty(as_road_name))
            //{
            //    AsRoadName = "";
            //    return false;
            //}

            // If the road name is empty and there's no selected road type
            // return without doing anything
            if (string.IsNullOrEmpty(as_road_name) && (! al_rt_id.HasValue))
            {
                return false;
            }

            string ls_filter = "";
            string ls_filter_null_clause = "";
            int rsIdList_count;

            //! added to be used for filtering
            AlRtId = al_rt_id;
            //AsRoadName = as_road_name;
            if (string.IsNullOrEmpty(as_road_name))
                AsRoadName = "";
            else
                AsRoadName = as_road_name.ToLower();    //.Trim();

            // TJB  RD7_0021  Feb 2009
            // Added line to empty the rsIdList before starting.  
            // Was repopulated with each call adding on to previous results.
            rsIdList.Clear();
            rsIdList_count = 0;

            adwc_data.FilterString = "";
            adwc_data.FilterOnce<DddwRoadSuffix>(EmptyFilter);

            ls_filter = "";
            foreach (RoadMapV2 item in ids_road_mapList)
            {
                // Skip this item if there's no roadname
                if (string.IsNullOrEmpty(item.RoadName))
                    continue;

                string itemRoadName = item.RoadName.ToLower();   //.Trim();
                // TJB  Jan 2010
                // Added for debugging to provide a way to see what's happening in the loop
                if (itemRoadName == "james")
                {
                    int i = 0;
                    int j = i;
                }
                //if (!string.IsNullOrEmpty(AsRoadName) 
                //    && !string.IsNullOrEmpty(item.RoadName) 
                //    && item.RoadName.ToLower() == AsRoadName
                //    && AlRtId > 0 
                //    && item.RtId == AlRtId)
                if ((AsRoadName == "" || itemRoadName == AsRoadName)
                    && al_rt_id >= 0
                    && item.RtId == al_rt_id)
                {
                    // Add the rs_id to the rsIdList unless it's already there
                    bool lb_found = false;
                    int? this_RsId = item.RsId;

                    // Scan the list of found rs_id's 
                    foreach (int? filtered_RsId in rsIdList)
                    {
                        //! avoid repetitions
                        // If this rs_id matches one already in the list, exit this loop
                        // with the ib_found flag set.
                        if (filtered_RsId == this_RsId)
                        {
                            lb_found = true;
                            break;
                        }
                    }
                    // If we didn't find the rs_id already in the list, add it now.
                    if (!lb_found)
                    {
                        rsIdList_count++;
                        if (this_RsId.HasValue)
                        {
                            rsIdList.Add(this_RsId);
                            if (ls_filter == "")
                                ls_filter = this_RsId.ToString();
                            else
                                ls_filter = ls_filter + "," + this_RsId.ToString();
                        }
                        else
                            ls_filter_null_clause = "isNull(rs_id)";
                    }
                }
            }

            // If no road with that name and type, return FALSE
            if (rsIdList_count <= 0)
                return false;

            // Finalise the filter string.
            if (ls_filter == "")
                ls_filter = ls_filter_null_clause;
            else
            {
                ls_filter = " in (" + ls_filter + ")";
                if (ls_filter_null_clause != "")
                    ls_filter = ls_filter + " or " + ls_filter_null_clause;
            }

            // Add the filter to the rs_id dropdown list
            adwc_data.FilterString = ls_filter;
            // Apply the filter to the rs_id dropdown list
            if (adwc_data is DDddwRoadSuffix)
                adwc_data.FilterOnce<DddwRoadSuffix>(FilterRoadSuffix1);

            return true;
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual string of_getsuburblist1(string as_roadname, int? al_rtid, int? al_rsid, int? al_tcid)
        {
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

            // TJB  RD7_0042 Jan-2010: ls_search fragment purged

            // TJB  RD7_0042 Jan-2010: ids_road_listListFiltered no longer used
            //List<RoadList> ids_road_listListFiltered = new List<RoadList>();
            string ls_filter1 = "";
            bool empty_address;
            empty_address = (string.IsNullOrEmpty(AsRoadname) 
                             && (!AlRtid.HasValue || AlRtid <= 0) 
                             && (!AlRsid.HasValue || AlRsid <= 0) 
                             && (!AlTcid.HasValue || AlTcid <= 0));

            // Filter the road_list            
            foreach (RoadList item in ids_road_listList)
            {
                if (empty_address)
                {
                    //ids_road_listListFiltered.Add(item);
                    add_distinct_filter_item(item.SlName, ref ls_filter1);
                }

                if (!string.IsNullOrEmpty(AsRoadname))
                {
                    if (item.RoadName != AsRoadname)
                        continue;
                }
                if (AlRtid > 0)
                {
                    if (item.RtId != AlRtid)
                        continue;
                }
                if (AlRsid > 0)
                {
                    if (item.RsId != AlRsid)
                        continue;
                }
                if (AlTcid > 0)
                {
                    if (item.TcId != AlTcid)
                        continue;
                }
                //ids_road_listListFiltered.Add(item);
                add_distinct_filter_item(item.SlName, ref ls_filter1);
            }
            // TJB  RD7_0042  Jan2010: section removed
            // Removed this section: ls_filter replaced with ls_filter1
            // Also removes need for ids_road_listListFiltered
            // NOTE: this produced incorrect results.  Some suburbs were not added to list
            //       because a previous suburb included the same name (see IndexOf condition)
            //       eg Mahia left out because Mahia Beach was already in the list.

/*
            // Build a list of the suburbs found
            // If none, ll_rows will be 0 and ls_filter will be ''
            int ll_row;
            int ll_rows;
            string ls_filter;
            string ls_temp;

            ls_filter = "";

            //!ll_rows = ids_road_list.RowCount;
            ll_rows = ids_road_listListFiltered.Count;

            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //!ls_temp = ids_road_list.GetItem<RoadList>(ll_row).SlName;
                //.GetItemString(ll_row, "sl_name");
                ls_temp = ids_road_listListFiltered[ll_row].SlName;
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
            if (ls_filter == "")
            {
                ls_filter = "\"xxxxxx\"";
            }
            return ls_filter;
*/
            if (ls_filter1 == "")
                ls_filter1 = "\"xxxxxx\"";

            return ls_filter1;
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        // TJB  RD7_0042  Jan-2010: added
        private void add_distinct_filter_item(string as_item, ref string as_filter)
        {
            // TJB  Jan 2010: added
            // Check to see if the item is already in the filter list as_filter
            // If not, add it

            // If the item passed is empty, don't add it
            if (as_item == null || as_item == "")
                return;

            // If the filter list is empty, add as_item to the list
            if (as_filter == "")
            {
                as_filter = as_item;
                return;
            }
            // Step through the filter list checking for matchine values
            // If a match is found, exit
            string[] filter_items = as_filter.Split(new char[] { ',' });
            foreach (string this_item in filter_items)
            {
                if (this_item.Equals(as_item))
                    return;
            }
            // If no match is found, add the item to the list
            as_filter = as_filter + "," + as_item;
            return;
        }

        // TJB  RD7:0042  Jan-2010: Modified
        // Changed construction of ls_filter to be done during scan of ids_road_listList
        // using the new function add_distinct_filter_item (above).
        public virtual string of_gettownlist1(string as_roadname, int? al_rtid, int? al_rsid, string as_slname)
        {
            int ll_row;
            int ll_rows;
            string ls_filter;
            string ls_temp;

            AsRoadName = as_roadname;
            AlRtid = al_rtid;
            AlRsid = al_rsid;
            AsSlName = as_slname;

            if ((as_roadname == null   || as_roadname == "") 
                 && (al_rtid == null   || al_rtid <= 0) 
                 && (al_rsid == null   || al_rsid <= 0) 
                 && (as_slname == null || as_slname == "")
               )
            {
                return "";
            }

            string ls_filter1 = "";
            string this_tcid;
            int found = 0;
            bool empty_address;
            //List<RoadList> ids_road_listFilteredList = new List<RoadList>();

            empty_address = (string.IsNullOrEmpty(AsRoadName) 
                              && (AlRtid <= 0) 
                              && (AlRsid <= 0) 
                              && string.IsNullOrEmpty(AsSlName) );

            foreach (RoadList item in ids_road_listList)
            {
                found = 0;
                if (empty_address) 
                {
                    //ids_road_listFilteredList.Add(item);
                    this_tcid = item.TcId.ToString();
                    add_distinct_filter_item(this_tcid, ref ls_filter1);
                }

                if (!string.IsNullOrEmpty(AsRoadName))
                {
                    if (item.RoadName != AsRoadName)
                        continue;
                    else
                        found++;
                }
                if (AlRtid > 0)
                {
                    if (item.RtId != AlRtid)
                        continue;
                    else
                        found++;
                }
                if (AlRsid > 0)
                {
                    if (item.RsId != AlRsid)
                        continue;
                    else
                        found++;
                }
                if (!string.IsNullOrEmpty(AsSlName) && !(AsSlName == " "))
                {
                    if (item.SlName != AsSlName)
                        continue;
                    else
                        found++;
                }

                if (found > 0)//! in case of match accept the recod
                {
                    found = 0;
                    //ids_road_listFilteredList.Add(item);
                    this_tcid = item.TcId.ToString();
                    add_distinct_filter_item(this_tcid, ref ls_filter1);
                }
            }
/*
            // Build the filter list
            ll_rows = ids_road_listFilteredList.Count;
            ls_filter = "";
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //!ls_temp = ids_road_list.GetItem<RoadList>(ll_row).TcId.ToString();
                ls_temp = ids_road_listFilteredList[ll_row].TcId.ToString();
                if (!((ls_temp == null)))
                {
                    if (ls_filter == "")
                        ls_filter = ls_temp;
                    else
                        ls_filter += ", " + ls_temp;
                }
            }
            if (ls_filter == "")
            {
                ls_filter = "-1";
            }
            return ls_filter;
*/
            if (ls_filter1 == "")
                ls_filter1 = "-1";

            return ls_filter1;
        }

        //! WSearchAddress - added trying to replace data windows with BEntity lists, as they are retrieving very slowly
        public virtual Dictionary<int, int> of_gettownlist_asdict1(string as_roadname, int? al_rtid, int? al_rsid, string as_slname)
        {
            int ll_row;
            int ll_rows;
            Dictionary<int, int> ls_filter = new Dictionary<int, int>();
            int? li_temp;
            string ls_search;
            if (((as_roadname == null) || as_roadname == "") 
                 && ((al_rtid == null) || al_rtid <= 0) 
                 && ((al_rsid == null) || al_rsid <= 0) 
                 && ((as_slname == null) || as_slname == ""))
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
                    ls_search = "rt_id=" + al_rtid.ToString();
                else
                    ls_search += " and rt_id=" + al_rtid.ToString();
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                    ls_search = "rs_id=" + al_rsid.ToString();
                else
                    ls_search += " and rs_id=" + al_rsid.ToString();
            }
            if (!((as_slname == null) || as_slname == "" || as_slname == " "))
            {
                if (ls_search == "")
                    ls_search = "sl_name=\"" + as_slname + '\"';
                else
                    ls_search += " and sl_name=\"" + as_slname + '\"';
            }

//!            ids_road_list.FilterString = ls_search;//ids_road_list.SetFilter(ls_search);
//!            ids_road_list.Filter<RoadList>();//ids_road_list.Filter();

            ll_rows = ids_road_listList.Count;
            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //!li_temp = ids_road_list.GetItem<RoadList>(ll_row).TcId;
                //ls_temp = String(ids_road_list.GetItemNumber(ll_row, "tc_id"));
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
                ls_filter.Add(-1, 0);

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
                    ls_search = "rt_id=" + al_rtid.ToString();
                else
                    ls_search += " and rt_id=" + al_rtid.ToString();
            }
            if (!((al_rsid == null) || al_rsid <= 0))
            {
                if (ls_search == "")
                    ls_search = "rs_id=" + al_rsid.ToString();
                else
                    ls_search += " and rs_id=" + al_rsid.ToString();
            }
            if (!((al_tcid == null) || al_tcid <= 0))
            {
                if (ls_search == "")
                    ls_search = "tc_id=" + al_tcid.ToString();
                else
                    ls_search += " and tc_id=" + al_tcid.ToString();
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
            //!ids_road_list.FilterString = ls_search;
            //ids_road_list.SetFilter(ls_search);
            //!ids_road_list.FilterOnce<RoadList>(FilterTown);
            //ids_road_list.Filter();
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
                        continue;
                    else
                        found++;
                }
                if (AlRtid > 0)
                {
                    if (item.RtId != AlRtid)
                        continue;
                    else
                        found++;
                }
                if (AlRsid > 0)
                {
                    if (item.RsId != AlRsid)
                        continue;
                    else
                        found++;
                }
                if (AlRsid > 0)
                {
                    if (item.TcId != AlTcid)
                        continue;
                    else
                        found++;
                }

                if (found > 0)//! in case of match accept the recod
                {
                    found = 0;
                    ids_road_listFilteredList.Add(item);
                }
                else
                    continue;
            }

            ll_rows = ids_road_listFilteredList.Count;

            for (ll_row = 0; ll_row < ll_rows; ll_row++)
            {
                //.GetItemString(ll_row, "sl_name");
                ls_temp = ids_road_listFilteredList[ll_row].SlName;
                if (!((ls_temp == null)))
                {
                    if (!ls_filter.ContainsKey(ls_temp))
                        ls_filter.Add(ls_temp, 0);
                }
            }
//!            ids_road_list.FilterString = "";
//!            ids_road_list.Filter<RoadList>();
            //ids_road_list.Filter();
            if (ls_filter.Count == 0)
                ls_filter.Add("xxxxxx", 0);

            return ls_filter;
        }
        //!########################################################################################################################
    }
}

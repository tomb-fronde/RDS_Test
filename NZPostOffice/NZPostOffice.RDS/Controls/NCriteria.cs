using System;
using System.Collections.Generic;
using NZPostOffice.RDS.Windows.Ruralwin;
using NZPostOffice.RDS.Windows.Ruralwin2;

namespace NZPostOffice.RDS.Controls
{


    // Contains criteria values for me parameter passing
    public class NCriteria
    {

        public Dictionary<int, object> iany_args = new Dictionary<int, object>();//public Cl_anyArray iany_args = new Cl_anyArray();

        public Dictionary<int, object> iany_argnames = new Dictionary<int, object>();// public Cl_anyArray iany_argnames = new Cl_anyArray();

        public NCriteria()
        {
        }

        public virtual int of_findcriteria(string astr_criterianame)
        {
            int ll_Ctr;
            for (ll_Ctr = 1; ll_Ctr <= iany_args.Count; ll_Ctr++) //for (ll_Ctr = 1; ll_Ctr <= iany_args.UpperBound; ll_Ctr++)
            {
                if (iany_argnames[ll_Ctr] == astr_criterianame)
                {
                    return ll_Ctr;
                }
            }
            return 0;
        }

        public virtual object of_getcriteria(string astr_criterianame)
        {
            int ll_CriteriaSubscript;
            object lany_Any=null;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript > 0)
            {
                return iany_args[ll_CriteriaSubscript];
            }
            return lany_Any;
        }

        public virtual int of_addcriteria(string astr_criterianame, int? a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame; //iany_argnames[iany_argnames.UpperBound + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value; //iany_args[iany_args.UpperBound + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        public virtual int of_addcriteria(string astr_criterianame, string a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame; //iany_argnames[iany_argnames.UpperBound + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value; //iany_args[iany_args.UpperBound + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value; //iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        public virtual int of_addcriteria(string astr_criterianame, DateTime? a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        public virtual int of_addcriteria(string astr_criterianame, WBenchmarkRates2001 a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        //public virtual int of_addcriteria(string astr_criterianame, int[] a_value)
        //{
        //    int ll_CriteriaSubscript;
        //    ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
        //    if (ll_CriteriaSubscript == 0)
        //    {
        //        iany_argnames[iany_argnames.UpperBound + 1] = astr_criterianame;
        //        iany_args[iany_args.UpperBound + 1] = a_value;
        //    }
        //    else
        //    {
        //        iany_args[ll_CriteriaSubscript] = a_value;
        //    }
        //    return 0;
        //}

        public virtual int of_addcriteria(string astr_criterianame, WWhatifCalc2001 a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        public virtual int of_addcriteria(string astr_criterianame, URdsDw a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        public virtual int of_addcriteria(string astr_criterianame, System.Decimal? a_value)
        {
            int ll_CriteriaSubscript;
            ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
            if (ll_CriteriaSubscript == 0)
            {
                iany_argnames[iany_argnames.Count + 1] = astr_criterianame;
                iany_args[iany_args.Count + 1] = a_value;
            }
            else
            {
                iany_args[ll_CriteriaSubscript] = a_value;
            }
            return 0;
        }

        //public virtual int of_addcriteria(string astr_criterianame, double a_value)
        //{
        //    int ll_CriteriaSubscript;
        //    ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
        //    if (ll_CriteriaSubscript == 0)
        //    {
        //        iany_argnames[iany_argnames.UpperBound + 1] = astr_criterianame;
        //        iany_args[iany_args.UpperBound + 1] = a_value;
        //    }
        //    else
        //    {
        //        iany_args[ll_CriteriaSubscript] = a_value;
        //    }
        //    return 0;
        //}

        //public virtual int of_addcriteria(string astr_criterianame, int a_value)
        //{
        //    int ll_CriteriaSubscript;
        //    ll_CriteriaSubscript = this.of_findcriteria(astr_criterianame);
        //    if (ll_CriteriaSubscript == 0)
        //    {
        //        iany_argnames[iany_argnames.UpperBound + 1] = astr_criterianame;
        //        iany_args[iany_args.UpperBound + 1] = a_value;
        //    }
        //    else
        //    {
        //        iany_args[ll_CriteriaSubscript] = a_value;
        //    }
        //    return 0;
        //}
    }
}

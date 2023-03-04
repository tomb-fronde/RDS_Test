using System;
using System.Collections.Generic;
using System.Text;
using Metex.Core;

namespace NZPostOffice.RDS.DataControls.DropDownList
{
    public class DropDownList : Entity<DropDownList>
    {
        [DBField()]
        private string _displayvalue;
        public string DisplayValue
        {
            get
            {
                CanReadProperty(true);
                return _displayvalue;
            }
            set
            {
                _displayvalue = value;
                PropertyHasChanged();
            }
        }

        [DBField()]
        private string _datavalue;
        public string DataValue
        {
            get
            {
                CanReadProperty(true);
                return _datavalue;
            }
            set
            {
                _datavalue = value;
                PropertyHasChanged();
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }

    }

    public class DropDownList<T> : Entity<DropDownList>
    {
        [DBField()]
        private string _displayvalue;
        public string DisplayValue
        {
            get
            {
                CanReadProperty(true);
                return _displayvalue;
            }
            set
            {
                _displayvalue = value;
                PropertyHasChanged();
            }
        }

        [DBField()]
        private T _datavalue;
        public T DataValue
        {
            get
            {
                CanReadProperty(true);
                return _datavalue;
            }
            set
            {
                _datavalue = value;
                PropertyHasChanged();
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
    }
}

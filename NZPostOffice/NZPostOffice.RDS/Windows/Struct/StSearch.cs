using System;
using System.Collections.Generic;
using System.Text;
using Metex.Windows;
using System.Data.SqlClient;
using NZPostOffice.RDS.Controls;

namespace NZPostOffice.RDS.Struct
{
    [Serializable()]
    public class StSearch //?: structure
    {
        public URdsDw query_datawindow;

        public SqlConnection query_transaction;

        //public StringArray query_columns = new StringArray();
        public Dictionary<int, string> query_columns = new Dictionary<int, string>();
    }
}

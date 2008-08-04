using System;
using System.Data;
using System.Data.Common;
using Metex.Core.Security;
using System.Collections.Generic;
using System.Text;
using Metex.Core;

namespace NZPostOffice.Entity
{
    [System.Serializable()]
    public abstract class RDSEntityBase<T> :
        Entity<T> where T : RDSEntityBase<T>
    {
        [ServerMethod()]
        protected int GetNextSequence(DbCommand cm, string sequenceName)
        {
            int sequence = 0;
            ParameterCollection pList = new ParameterCollection();
            cm.CommandText = "select next_value from id_codes where sequence_name = @sequenceName";
            pList.Add(cm, "sequenceName", sequenceName);
            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
            {
                if (dr.Read())
                {
                    sequence = dr.GetInt32(0);
                }
            }
            if (sequence == 0)
            {
                cm.CommandText = "insert into id_codes (sequence_name, next_value) values (@sequenceName, 2)";
                DBHelper.ExecuteNonQuery(cm, pList);
                sequence = 1;
            }
            else
            {
                cm.CommandText = "update id_codes set next_value = @next_value  where sequence_name = @sequenceName";
                pList.Add(cm, "next_value", (sequence + 1));
                DBHelper.ExecuteNonQuery(cm, pList);
            }
            return sequence;
        }
    }
}

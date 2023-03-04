using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Metex.Core;
using Metex.Core.Security;

namespace NZPostOffice.RDS.Entity.Ruraldw
{
    // Mapping info for object fields to DB
    // Mapping fieldname, entity fieldname, database table name, form name
    // Application Form Name : BE
    [MapInfo("column1", "_column1", "")]
    [NZPostOffice.Shared.LogicUnits.MapInfoIndex(new string[] { "column1" })]
    [System.Serializable()]

    public class ContractAdjustmentsImport : Entity<ContractAdjustmentsImport>
    {
        #region Business Methods
        [DBField()]
        private string _column1;

        public virtual string Column1
        {
            get
            {
                CanReadProperty("Column1", true);
                return _column1;
            }
            set
            {
                CanWriteProperty("Column1", true);
                if (_column1 != value)
                {
                    _column1 = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return "";
        }
        #endregion

        #region Factory Methods
        public static ContractAdjustmentsImport NewContractAdjustmentsImport()
        {
            return Create();
        }

        public static ContractAdjustmentsImport[] GetAllContractAdjustmentsImport()
        {
            return Fetch().list;
        }
        #endregion

        #region Data Access
        //Exterior Data
        //[ServerMethod]
        //private void FetchEntity(  )
        //{
        //    using ( DbConnection cn= DbConnectionFactory.RequestNextAvaliableSessionDbConnection( ))
        //    {
        //        using (DbCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.Text;
        //            ParameterCollection pList = new ParameterCollection();

        //            List<ContractAdjustmentsImport> _list = new List<ContractAdjustmentsImport>();
        //            using (MDbDataReader dr = DBHelper.ExecuteReader(cm, pList))
        //            {
        //                while (dr.Read())
        //                {
        //                    ContractAdjustmentsImport instance = new ContractAdjustmentsImport();
        //                    instance.MarkOld();
        //                    _list.Add(instance);
        //                }
        //                list = _list.ToArray();
        //            }
        //        }
        //    }
        //}

        #endregion

        [ServerMethod()]
        private void CreateEntity()
        {
        }
    }
}

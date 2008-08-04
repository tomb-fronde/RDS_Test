using System;

namespace NZPostOffice.RDS.Controls
{


    public class NRdsMsg
    {

        public NCriteria inv_LightningCriteria;

        public NRdsMsg()
        {
        }

        public virtual bool of_addcriteria(NCriteria anv_criteria)
        {
            inv_LightningCriteria = new NCriteria();
            inv_LightningCriteria = anv_criteria;
            return inv_LightningCriteria == anv_criteria;
        }

        public virtual NCriteria of_getcriteria()
        {
            if (inv_LightningCriteria == null ) //(!(IsValid(inv_LightningCriteria)))
            {
                inv_LightningCriteria = new NCriteria();
            }
            return inv_LightningCriteria;
        }
    }
}

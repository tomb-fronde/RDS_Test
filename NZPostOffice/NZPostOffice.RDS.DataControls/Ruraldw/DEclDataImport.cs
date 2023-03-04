using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Metex.Core;
using NZPostOffice.RDS.Entity.Ruraldw;

namespace NZPostOffice.RDS.DataControls.Ruraldw
{
	public partial class DEclDataImport : Metex.Windows.DataUserControl
	{
		public DEclDataImport()
		{
			InitializeComponent();
		}

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

		public override int Retrieve( )
		{
			return RetrieveCore<EclDataImport>(new List<EclDataImport>
				(EclDataImport.GetAllEclDataImport( )));
		}

        public int Retrieve(Metex.Core.EntityBindingList<EclDataImport> dw_1_List)
        {
            return RetrieveCore<EclDataImport>(dw_1_List);
        }

    }
}

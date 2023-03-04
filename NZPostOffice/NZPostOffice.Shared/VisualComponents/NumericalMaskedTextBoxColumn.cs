using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NZPostOffice.Shared.VisualComponents
{
    //references to http://msdn2.microsoft.com/en-us/library/ms180996.aspx
    public class NumericalMaskedTextBoxColumn : DataGridViewColumn
    {
        private string mask;
        private char promptChar;
        private bool includePrompt;
        private bool includeLiterals;
        private Type validatingType;

        public NumericalMaskedTextBoxColumn()
            : base(new NumericalMaskedTextBoxCell())
        {
        }

        private static DataGridViewTriState TriBool(bool value)
        {
            return value ? DataGridViewTriState.True
                         : DataGridViewTriState.False;
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }

            set
            {
                //  Only cell types that derive from MaskedTextBoxCell are supported as the cell template.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericalMaskedTextBoxCell)))
                {
                    string s = "Cell type is not based upon the MaskedTextBoxCell.";//CustomColumnMain.GetResourceManager().GetString("excNotMaskedTextBox");
                    throw new InvalidCastException(s);
                }

                base.CellTemplate = value;
            }
        }

        public virtual string Mask
        {
            get
            {
                return this.mask;
            }
            set
            {
                NumericalMaskedTextBoxCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.mask != value)
                {
                    this.mask = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (NumericalMaskedTextBoxCell)this.CellTemplate;
                    mtbc.Mask = value;

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is NumericalMaskedTextBoxCell)
                            {
                                mtbc = (NumericalMaskedTextBoxCell)dgvc;
                                mtbc.Mask = value;
                            }
                        }
                    }
                }
            }
        }

        public virtual char PromptChar
        {
            get
            {
                return this.promptChar;
            }
            set
            {
                NumericalMaskedTextBoxCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.promptChar != value)
                {
                    this.promptChar = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (NumericalMaskedTextBoxCell)this.CellTemplate;
                    mtbc.PromptChar = value;

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is NumericalMaskedTextBoxCell)
                            {
                                mtbc = (NumericalMaskedTextBoxCell)dgvc;
                                mtbc.PromptChar = value;
                            }
                        }
                    }
                }
            }
        }

        public virtual bool IncludePrompt
        {
            get
            {
                return this.includePrompt;
            }
            set
            {
                NumericalMaskedTextBoxCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.includePrompt != value)
                {
                    this.includePrompt = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (NumericalMaskedTextBoxCell)this.CellTemplate;
                    mtbc.IncludePrompt = TriBool(value);

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is NumericalMaskedTextBoxCell)
                            {
                                mtbc = (NumericalMaskedTextBoxCell)dgvc;
                                mtbc.IncludePrompt = TriBool(value);
                            }
                        }
                    }
                }
            }
        }

        public virtual bool IncludeLiterals
        {
            get
            {
                return this.includeLiterals;
            }
            set
            {
                NumericalMaskedTextBoxCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.includeLiterals != value)
                {
                    this.includeLiterals = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (NumericalMaskedTextBoxCell)this.CellTemplate;
                    mtbc.IncludeLiterals = TriBool(value);

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {

                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is NumericalMaskedTextBoxCell)
                            {
                                mtbc = (NumericalMaskedTextBoxCell)dgvc;
                                mtbc.IncludeLiterals = TriBool(value);
                            }
                        }
                    }
                }
            }
        }

        public virtual Type ValidatingType
        {
            get
            {
                return this.validatingType;
            }
            set
            {
                NumericalMaskedTextBoxCell mtbc;
                DataGridViewCell dgvc;
                int rowCount;

                if (this.validatingType != value)
                {
                    this.validatingType = value;

                    //
                    // first, update the value on the template cell.
                    //
                    mtbc = (NumericalMaskedTextBoxCell)this.CellTemplate;
                    mtbc.ValidatingType = value;

                    //
                    // now set it on all cells in other rows as well.
                    //
                    if (this.DataGridView != null && this.DataGridView.Rows != null)
                    {
                        rowCount = this.DataGridView.Rows.Count;
                        for (int x = 0; x < rowCount; x++)
                        {
                            dgvc = this.DataGridView.Rows.SharedRow(x).Cells[x];
                            if (dgvc is NumericalMaskedTextBoxCell)
                            {
                                mtbc = (NumericalMaskedTextBoxCell)dgvc;
                                mtbc.ValidatingType = value;
                            }
                        }
                    }
                }
            }
        }


    }
}

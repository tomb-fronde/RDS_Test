using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.Shared.VisualComponents
{
    public class NumericalMaskedTextBoxCell : DataGridViewTextBoxCell
    {
        private string mask;
        private char promptChar;
        private DataGridViewTriState includePrompt;
        private DataGridViewTriState includeLiterals;
        private Type validatingType;

        public NumericalMaskedTextBoxCell()
            : base()
        {
            this.mask = "";
            this.promptChar = ' ';
            this.includePrompt = DataGridViewTriState.NotSet;
            this.includeLiterals = DataGridViewTriState.NotSet;
            this.validatingType = typeof(string);
        }

        public override void InitializeEditingControl(int rowIndex,
                                                      object initialFormattedValue,
                                                      DataGridViewCellStyle dataGridViewCellStyle)
        {
            NumericalMaskedTextBoxEditingControl mtbec;
            NumericalMaskedTextBoxColumn mtbcol;
            DataGridViewColumn dgvc;

            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                          dataGridViewCellStyle);

            mtbec = DataGridView.EditingControl as NumericalMaskedTextBoxEditingControl;

            dgvc = this.OwningColumn;
            if (dgvc is NumericalMaskedTextBoxColumn)
            {
                mtbcol = dgvc as NumericalMaskedTextBoxColumn;

                if (string.IsNullOrEmpty(this.mask))
                {
                    mtbec.EditMask = mtbcol.Mask;
                }
                else
                {
                    mtbec.EditMask = this.mask;
                }

                mtbec.PromptChar = this.PromptChar;

                if (this.includePrompt == DataGridViewTriState.NotSet)
                {
                    //mtbec.IncludePrompt = mtbcol.IncludePrompt;
                }
                else
                {
                    //mtbec.IncludePrompt = BoolFromTri(this.includePrompt);
                }

                if (this.includeLiterals == DataGridViewTriState.NotSet)
                {
                    //mtbec.IncludeLiterals = mtbcol.IncludeLiterals;
                }
                else
                {
                    //mtbec.IncludeLiterals = BoolFromTri(this.includeLiterals);
                }

                if (this.ValidatingType == null)
                {
                    mtbec.ValidatingType = mtbcol.ValidatingType;
                }
                else
                {
                    mtbec.ValidatingType = this.ValidatingType;
                }

                //mtbec.Text = (string)this.Value;
                mtbec.Value = initialFormattedValue.ToString();
            }
        }

        public override Type EditType
        {
            get
            {
                return typeof(NumericalMaskedTextBoxEditingControl);
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
                this.mask = value;
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
                this.promptChar = value;
            }
        }

        public virtual DataGridViewTriState IncludePrompt
        {
            get
            {
                return this.includePrompt;
            }
            set
            {
                this.includePrompt = value;
            }
        }

        public virtual DataGridViewTriState IncludeLiterals
        {
            get
            {
                return this.includeLiterals;
            }
            set
            {
                this.includeLiterals = value;
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
                this.validatingType = value;
            }
        }

        protected static bool BoolFromTri(DataGridViewTriState tri)
        {
            return (tri == DataGridViewTriState.True) ? true : false;
        }
    }
}

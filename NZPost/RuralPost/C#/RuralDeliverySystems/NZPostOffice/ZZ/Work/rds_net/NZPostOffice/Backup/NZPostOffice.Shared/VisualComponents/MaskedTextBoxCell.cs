//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace NZPostOffice.Shared.VisualComponents
{
    class MaskedTextBoxCell : DataGridViewTextBoxCell
    {
        private string mask;
        private char promptChar;
        private DataGridViewTriState includePrompt;
        private DataGridViewTriState includeLiterals;
        private Type validatingType;

        //=------------------------------------------------------------------=
        // MaskedTextBoxCell
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initializes a new instance of this class.  Fortunately, there's
        ///   not much to do here except make sure that our base class is 
        ///   also initialized properly.
        /// </summary>
        /// 
        public MaskedTextBoxCell() : base()
        {
            this.mask = "";
            this.promptChar = '_';
            this.includePrompt = DataGridViewTriState.NotSet;
            this.includeLiterals = DataGridViewTriState.NotSet;
            this.validatingType = typeof(string);
        }

        ///   Whenever the user is to begin editing a cell of this type, the editing
        ///   control must be created, which in this column type's
        ///   case is a subclass of the MaskedTextBox control.
        /// 
        ///   This routine sets up all the properties and values
        ///   on this control before the editing begins.
        public override void InitializeEditingControl(int rowIndex,
                                                      object initialFormattedValue,
                                                      DataGridViewCellStyle dataGridViewCellStyle)
        {
            MaskedTextBoxEditingControl mtbec;
            MaskedTextBoxColumn mtbcol;
            DataGridViewColumn dgvc;

            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                          dataGridViewCellStyle);

            mtbec = DataGridView.EditingControl as MaskedTextBoxEditingControl;

            //
            // set up props that are specific to the MaskedTextBox
            //

            dgvc = this.OwningColumn;   // this.DataGridView.Columns[this.ColumnIndex];
            if (dgvc is MaskedTextBoxColumn)
            {
                mtbcol = dgvc as MaskedTextBoxColumn;

                //
                // get the mask from this instance or the parent column.
                //
                mtbec.Mask = mtbcol.Mask;
                //
                // prompt char.
                //
                mtbec.PromptChar = mtbcol.PromptChar;// this.PromptChar;
                //
                // IncludePrompt
                //

                //
                // IncludeLiterals
                //

                //
                // Finally, the validating type ...
                //
                mtbec.ValidatingType = mtbcol.ValidatingType;
                mtbec.Text = initialFormattedValue.ToString();//(mtbcol.)this.Value;
            }
        }

        //  Returns the type of the control that will be used for editing
        //  cells of this type.  This control must be a valid Windows Forms
        //  control and must implement IDataGridViewEditingControl.
        public override Type EditType
        {
            get
            {
                return typeof(MaskedTextBoxEditingControl);
            }
        }

        //   A string value containing the Mask against input for cells of
        //   this type will be verified.
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

        //  The character to use for prompting for new input.
        // 
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


        //  A boolean indicating whether to include prompt characters in
        //  the Text property's value.
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

        //  A boolean value indicating whether to include literal characters
        //  in the Text property's output value.
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

        //  A Type object for the validating type.
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

        //   Quick routine to convert from DataGridViewTriState to boolean.
        //   True goes to true while False and NotSet go to false.
        protected static bool BoolFromTri(DataGridViewTriState tri)
        {
            return (tri == DataGridViewTriState.True) ? true : false;
        }
    }
}

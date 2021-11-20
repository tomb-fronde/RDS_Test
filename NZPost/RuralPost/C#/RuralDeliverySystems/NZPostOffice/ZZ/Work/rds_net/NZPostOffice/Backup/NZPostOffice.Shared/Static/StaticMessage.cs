using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.Shared
{
    // TJB Frequencies Nov-2020 
    // Added ContractNoParm

    /// <summary>
	/// Summary description for StaticMessage.
	/// </summary>
	public class StaticMessage
	{
		/// <summary>
		/// The handle of the window or control.
		/// </summary>
		public static object Sender;
		
		/// <summary>
		/// The number that identifies the event (this number comes from Windows).
		/// </summary>
		public static uint Number;

		/// <summary>
		/// The word parameter for the event (this parameter comes from Windows). The parameter's value and meaning are determined by the event.
		/// </summary>
		public static long WordParm;

		/// <summary>
		/// The long parameter for the event (this number comes from Windows). The parameter's value and meaning are determined by the event.
		/// </summary>
		public static long LongParm;

		/// <summary>
		/// An object of type PowerObject containing information about the class definition of the object or control. 
		/// </summary>
		public static object PowerObject;

		private static string _LastSetVariable = "";
		internal static string LastSetVariable
		{
			get 
			{
				return _LastSetVariable;
			}
		}

		private static double _doubleParam = 0;
		/// <summary>
		/// A numeric or a numeric variable.
		/// </summary>
		public static double DoubleParm
		{
			get
			{
				return _doubleParam;
			}
			set
			{
				_doubleParam = value;
//				_stringParam = string.Empty;
//				_powerObjectParm = null;
				_LastSetVariable = "DoubleParm";
			}
		}

		private static string _stringParam = string.Empty;
		/// <summary>
		/// A string or a string variable.
		/// </summary>
		public static string StringParm
		{
			get
			{
				return _stringParam;
			}
			set
			{
				_stringParam = value;
//				_doubleParam = 0;
//				_powerObjectParm = null;
				_LastSetVariable = "StringParm";
			}
		}

		private static object _powerObjectParm = null;
		/// <summary>
		/// Any PowerBuilder object type including structures.
		/// </summary>
		public static object PowerObjectParm
		{
			get
			{
				return _powerObjectParm;
			}
			set
			{
				_powerObjectParm = value;
//				_stringParam = string.Empty;
//				_doubleParam = 0;
				_LastSetVariable = "PowerObjectParm";
			}
		}

        private static bool _BooleanParm = false;
        public static bool BooleanParm
        {
            get
            {
                return _BooleanParm;
            }
            set
            {
                _BooleanParm = value;
                //				_stringParam = string.Empty;
                //				_doubleParam = 0;
                _LastSetVariable = "BooleanParm";
            }
        }

        private static int _IntegerParm = 0;
        public static int IntegerParm
        {
            get
            {
                return _IntegerParm;
            }
            set
            {
                _IntegerParm = value;
                _LastSetVariable = "IntegerParm";
            }
        }

        // TJB Frequencies Nov-2020 Added
        // Created specific variable to avoid possible conflict
        // with other uses (eg of IntegerParm). Used by 
        // Frequencies (version 2) to pass the contract number
        // to the retreival for the vehicle number dropdown
        private static int _contract_no_parm = 0;
        public static int ContractNoParm
        {
            get
            {
                return _contract_no_parm;
            }
            set
            {
                _contract_no_parm = value;
                _LastSetVariable = "ContractNoParm";
            }
        }

        private static System.Windows.Forms.Form _window = null;
        public static System.Windows.Forms.Form window
        {
            get
            {
                return _window;
            }
            set
            {
                _window = value;
            }
        }
		
		/// <summary>
		/// A boolean value set in the script for the user-defined event or the Other event. Values are:TRUE - The script processed the event; do not call the default window process (DefWindowProc) after the event has been processed.FALSE - (Default) Call DefWindowProc after the event has been processed.
		/// </summary>
		public static bool Processed;

		/// <summary>
		/// When Message.Processed is TRUE, specifies the value you want returned to Windows. This property is ignored when Message.Processed is FALSE.
		/// </summary>
		public static long? ReturnValue;

        public static string stringTitle;           //added by ygu
	}
}

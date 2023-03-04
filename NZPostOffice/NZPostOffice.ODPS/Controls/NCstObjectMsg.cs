using System;
using System.Collections.Generic;
using System.Text;

namespace NZPostOffice.ODPS.Controls
{
    public class NCstObjectMsg
    {
        public static int ii_MaxIndex = 0;

        public static ostr_msgsrvc[] istr_msgsrvc = new ostr_msgsrvc[100];

        public static int of_removeallforobject(string asv_object)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_RemoveAllForObject
            //  Description:	remove all from queue for specified object
            //  Arguments:	asv_Object - object that shall receive the message
            // 	Returns:			0 if no messages removed, 1 if messages found and removed
            int li_Index;
            int li_Return = 0;
            //asv_object = Upper(asv_object);
            asv_object = asv_object.ToUpper();
            // 	walk through all the messages that have been loaded, if we found a match, remove it!
            for (li_Index = 1; li_Index <= ii_MaxIndex; li_Index++)
            {
                // 	we only want to remove messages that are automatic or manually added, DO NOT remove
                // 	permanent messages
                if (istr_msgsrvc[li_Index].s_Object == asv_object && (istr_msgsrvc[li_Index].s_Remove == "A" || istr_msgsrvc[li_Index].s_Remove == "M"))
                {
                    of_clearmsg(li_Index);
                    li_Return = 1;
                }
            }
            return li_Return;
        }

        public static int of_addmsg(string asv_object, string asv_msg, object aanyv_value)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_AddMsg
            //  Description:	This function is OVERLOADED - 
            // 						place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that shall receive the message
            // 						asv_Msg - name of the message
            // 						aanyv_Value = value for the message
            // 	Returns:			integer containing the placement in the array containing the message
            return of_addmsg(asv_object, asv_msg, aanyv_value, "A", 0);
        }

        public static bool of_getmsg(string asv_object, string asv_msg, ref object aanyr_value)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_GetMsg
            // 	Description:	this function is OVERLOADED,
            // 						find the message for the specified object from the queue
            // 	Arguments:		asv_Object - object that shall receive the message
            // 						asv_Msg - name of the message
            // 						aanyr_Value - value for the message, passed by reference
            //  Returns:		boolean - TRUE if the message was found, FALSE is not
            return of_getmsg(asv_object, asv_msg, ref aanyr_value, "Y");
        }

        public static int of_addmsg(string asv_object, string asv_msg, object aanyv_value, string asv_remove)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method: 		of_AddMsg
            //  Description:	this function is OVERLOADED,
            // 						place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            // 						aanyv_Value - value for the message
            // 						asv_Remove - remove after retrieval indicator
            //  Returns:		integer containing the placement in the array containing the message
            return of_addmsg(asv_object, asv_msg, aanyv_value, asv_remove, 0);
        }

        public static bool of_getmsg(string asv_object, string asv_msg, ref object aanyr_value, string asv_remove)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_GetMsg
            // 	Description:	find the message for the specified object from the queue
            // 	Arguments:		asv_Object - object that shall receive the message
            // 						asv_Msg - name of the message
            // 						aanyr_Value - value for the message, passed by reference
            // 						asv_Remove - delete from queue indicator
            //  Returns:		boolean - TRUE if the message was found, FALSE is not
            int li_index;
            //?         Cl_anyArray lany_Null = new Cl_anyArray();
            //  walk through the message queue, looking for the message
            //  if found, return the value by reference and
            // 	if the remove indicator is true, empty the array slot
            for (li_index = 1; li_index <= ii_MaxIndex; li_index++)
            {
                if (istr_msgsrvc[li_index].s_Object == asv_object.ToUpper() && istr_msgsrvc[li_index].s_Msg == asv_msg.ToUpper())
                {
                    aanyr_value = istr_msgsrvc[li_index].any_Value;
                    if (asv_remove == "Y" && istr_msgsrvc[li_index].s_Remove == "A")
                    {
                        of_clearmsg(li_index);
                    }
                    return true;
                }
            }
            //  the message was not found
            //?         aanyr_value = lany_null;
            return false;
        }

        public static int of_addarraymsg(string asv_object, string asv_msg, object[] aanyv_value)
        {
            //  Object:			cs_n_ObjectMsg
            //  Method: 		of_AddArrayMsg
            //  Description:	this function is OVERLOADED,
            // 						place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            // 						aanyv_Value - value array for the message
            //  Returns:		integer containing the placement in the array containing the message
            return of_addarraymsg(asv_object, asv_msg, aanyv_value, "A", 0);
        }

        public static int of_addarraymsg(string asv_object, string asv_msg, object[] aanyv_value, double adblv_session)
        {
            //  Object:			cs_n_ObjectMsg
            //  Method: 		of_AddArrayMsg
            //  Description:	this function is OVERLOADED,
            // 						place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            // 						aanyv_Value - value array for the message
            // 						adblv_session - session number
            //  Returns:		integer containing the placement in the array containing the message
            return of_addarraymsg(asv_object, asv_msg, aanyv_value, "A", adblv_session);
        }

        public static int of_addarraymsg(string asv_object, string asv_msg, object[] aanyv_value, string asv_remove)
        {
            //  Object:			cs_n_ObjectMsg
            //  Method: 		of_AddArrayMsg
            //  Description:	this function is OVERLOADED,
            // 						place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            // 						aanyv_Value - value array for the message
            // 						asv_Remove - remove upon retrieval indicator
            //  Returns:		integer containing the placement in the array containing the message
            return of_addarraymsg(asv_object, asv_msg, aanyv_value, asv_remove, 0);
        }

        public static int of_addarraymsg(string asv_object, string asv_msg, object[] aanyv_value, string asv_remove, double adblv_session)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method: 		of_AddMsg
            //  Description:	place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            // 						aanyv_Value - value array for the message
            // 						asv_Remove - remove indicator
            // 						adv_Session - session number
            //  Returns:		integer containing the placement in the array containing the message
            int li_index;
            int li_nextindex;
            //  convert the object and message to uppercase for consistency
            asv_object = asv_object.ToUpper();
            asv_msg = asv_msg.ToUpper();
            //  walk through the parm queue, looking for an empty slot
            for (li_index = 1; li_index <= ii_MaxIndex; li_index++)
            {
                if (istr_msgsrvc[li_index].s_Object == null || istr_msgsrvc[li_index].s_Object == "")
                {
                    istr_msgsrvc[li_index].s_Object = asv_object;
                    istr_msgsrvc[li_index].s_Msg = asv_msg;
                    istr_msgsrvc[li_index].any_ValueArray = aanyv_value;
                    istr_msgsrvc[li_index].s_Remove = asv_remove;
                    istr_msgsrvc[li_index].dbl_Session = adblv_session;
                    return li_index;
                }
            }
            //  save the last message index which should be one greater than the current max
            li_nextindex = li_index;
            //  no empty slot was found, we must bump the message array
            ii_MaxIndex = Convert.ToInt32((ii_MaxIndex / 10) + 1) * 10;
            istr_msgsrvc[ii_MaxIndex].s_Object = "";
            istr_msgsrvc[ii_MaxIndex].s_Msg = "";
            istr_msgsrvc[ii_MaxIndex].any_ValueArray[1] = "";
            istr_msgsrvc[ii_MaxIndex].s_Remove = "";
            istr_msgsrvc[ii_MaxIndex].dbl_Session = 0;
            //  now load the object
            istr_msgsrvc[li_nextindex].s_Object = asv_object;
            istr_msgsrvc[li_nextindex].s_Msg = asv_msg;
            istr_msgsrvc[li_nextindex].any_ValueArray = aanyv_value;
            istr_msgsrvc[li_nextindex].s_Remove = asv_remove;
            istr_msgsrvc[li_nextindex].dbl_Session = adblv_session;
            return li_nextindex;
        }

        public static int of_addmsg(string asv_object, string asv_msg, object aanyv_value, double adblv_session)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_AddMsg
            //  Description:	This function has been OVERLOADED - 
            // 						place a new message for the 	specified object onto the queue
            //  Arguments:	asv_Object - object that shall receive the message
            // 						asv_Msg - name of the message message
            // 						aanyv_Value - value for the message
            // 						adblv_Session - session number
            // 	Returns:			integer containing the placement in the array containing the message
            return of_addmsg(asv_object, asv_msg, aanyv_value, "A", adblv_session);
        }

        public static int of_addmsg(string asv_object, string asv_msg, object aanyv_value, string asv_remove, double adblv_session)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method: 		of_AddMsg
            //  Description:	place a new message for the specified object onto the queue
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            // 						aanyv_Value - value for the message
            // 						asv_Remove - remove indicator
            // 						adblv_Session - session number
            //  Returns:		integer containing the placement in the array containing the message
            int li_index;
            int li_nextindex;
            //  convert the object and message to uppercase for consistency
            asv_object = asv_object.ToUpper();
            asv_msg = asv_msg.ToUpper();
            //  walk through the parm queue, looking for an empty slot
            for (li_index = 1; li_index <= ii_MaxIndex; li_index++)
            {
                if (istr_msgsrvc[li_index].s_Object == null || istr_msgsrvc[li_index].s_Object == "")
                {
                    istr_msgsrvc[li_index].s_Object = asv_object;
                    istr_msgsrvc[li_index].s_Msg = asv_msg;
                    istr_msgsrvc[li_index].any_Value = aanyv_value;
                    istr_msgsrvc[li_index].s_Remove = asv_remove;
                    istr_msgsrvc[li_index].dbl_Session = adblv_session;
                    return li_index;
                }
            }
            //  save the last message which should be one greater than the current max
            li_nextindex = li_index;
            //  no empty slot was found, we must bump the message array
            ii_MaxIndex = (Convert.ToInt32(ii_MaxIndex / 10) + 1) * 10;
            istr_msgsrvc[ii_MaxIndex].s_Object = "";
            istr_msgsrvc[ii_MaxIndex].s_Msg = "";
            istr_msgsrvc[ii_MaxIndex].any_Value = "";
            istr_msgsrvc[ii_MaxIndex].s_Remove = "";
            istr_msgsrvc[ii_MaxIndex].dbl_Session = 0;
            //  now load the object
            istr_msgsrvc[li_nextindex].s_Object = asv_object;
            istr_msgsrvc[li_nextindex].s_Msg = asv_msg;
            istr_msgsrvc[li_nextindex].any_Value = aanyv_value;
            istr_msgsrvc[li_nextindex].s_Remove = asv_remove;
            istr_msgsrvc[li_nextindex].dbl_Session = adblv_session;
            return li_nextindex;
        }

        public static bool of_getarraymsg(string asv_object, string asv_msg, ref object[] aanyr_value, string asv_remove)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_GetMsg
            // 	Description:	find the message array for the specified object from the queue
            // 	Arguments:		asv_Object - object that shall receive the message
            // 						asv_Msg - name of the message
            // 						aanyr_Value - value array for the message, passed by reference
            // 						asv_Remove - delete from queue indicator
            //  Returns:		boolean - TRUE if the message was found, FALSE is not
            int li_Index;
            //?         Cl_anyArray lany_Null = new Cl_anyArray();
            //  walk through the message queue, looking for the message
            //  if found, return the value by reference and
            // 	if the remove indicator is true, empty the array slot
            for (li_Index = 1; li_Index <= ii_MaxIndex; li_Index++)
            {
                if (istr_msgsrvc[li_Index].s_Object == asv_object.ToUpper() && istr_msgsrvc[li_Index].s_Msg == asv_msg.ToUpper())
                {
                    aanyr_value = istr_msgsrvc[li_Index].any_ValueArray;
                    if (asv_remove == "Y" && istr_msgsrvc[li_Index].s_Remove == "A")
                    {
                        of_clearmsg(li_Index);
                    }
                    return true;
                }
            }
            //  the message was not found
            //?         aanyr_value = lany_Null;
            return false;
        }

        public static int of_removesession(double adblv_session)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_RemoveSession
            //  Description:	remove all from queue for specified session
            //  Arguments:	adv_Session - session number
            // 	Returns:			-1 if an error occurred, 0 if no messages found to remove, 1 if messages
            // 						found and removed
            int li_Index;
            int li_Return = -1;
            if (adblv_session != 0)
            {
                for (li_Index = 1; li_Index <= ii_MaxIndex; li_Index++)
                {
                    if (istr_msgsrvc[li_Index].dbl_Session == adblv_session)
                    {
                        of_clearmsg(li_Index);
                        li_Return = 1;
                    }
                }
            }
            else
            {
                li_Return = -1;
            }
            return li_Return;
        }

        public static double of_getsession()
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_GetSession
            //  Description:	obtain a session number for adding elements to the queue
            //  Arguments:	none
            // 	Returns:			double containing the session number
            //return Double(String(System.Convert.ToDateTime.Now, "yymmddhhmmssfff"));
            return Convert.ToDouble(DateTime.Now.ToString("yyMMddhhmmssfff"));
        }

        public static bool of_getarraymsg(string asv_object, string asv_msg, ref object[] aanyr_value)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_GetMsg
            // 	Description:	function is OVERLOADED - 
            // 						find the message array for the specified object from the queue
            // 	Arguments:		asv_Object - object that shall receive the message
            // 						asv_Msg - name of the message
            // 						aanyr_Value - value array for the message, passed by reference
            //  Returns:		boolean - TRUE if the message was found, FALSE is not
            return of_getarraymsg(asv_object, asv_msg, ref aanyr_value, "Y");
        }

        public static bool of_getmsgpickedup(string asv_object, string asv_msg)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method: 		of_GetMsgPickedUp
            //  Description:	determine is a message has been picked up or not
            //  Arguments:	asv_Object - object that will receive the message
            //  					asv_Msg - name of message
            //  Returns:		TRUE if the message has been picked up, FALSE if not
            int li_Index;
            //  convert the object and message to uppercase for consistency
            asv_object = asv_object.ToUpper();
            asv_msg = asv_msg.ToUpper();
            //  walk through the parm queue, looking for an empty slot
            for (li_Index = 1; li_Index <= ii_MaxIndex; li_Index++)
            {
                if (istr_msgsrvc[li_Index].s_Object == asv_object && istr_msgsrvc[li_Index].s_Msg == asv_msg)
                {
                    return true;
                }
            }
            //  if we got this far, there is not message for the object specified
            return false;
        }

        public static int of_cleararray(int aiv_index)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method: 		of_ClearArray
            //  Description:	clear the values in the specified value array of the MsgSrvc structure
            //  Arguments:	aiv_Index - Index location of the array
            //  Returns:		0
            //?         Cl_anyArray lany_Null = new Cl_anyArray();
            istr_msgsrvc[aiv_index].any_ValueArray = null;//lany_Null;
            return 0;
        }

        public static int of_clearmsg(int aiv_index)
        {
            //  Object:			cs_n_ObjectMsg_Srvc
            //  Method:			of_ClearMsg
            // 	Description:	removes specified array location
            // 	Arguments:		aiv_Index - array location index
            //  Returns:			0
            ((ostr_msgsrvc)istr_msgsrvc[aiv_index]).s_Object = "";
            ((ostr_msgsrvc)istr_msgsrvc[aiv_index]).s_Msg = "";
            ((ostr_msgsrvc)istr_msgsrvc[aiv_index]).any_Value = "";
            of_cleararray(aiv_index);
            ((ostr_msgsrvc)istr_msgsrvc[aiv_index]).s_Remove = "";
            ((ostr_msgsrvc)istr_msgsrvc[aiv_index]).dbl_Session = 0;
            return 0;
        }
    }

    public struct ostr_msgsrvc
    {
        public double dbl_Session;
        public string s_Remove;
        public object[] any_ValueArray;
        public object any_Value;
        public string s_Msg;
        public string s_Object;
    }
}

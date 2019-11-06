using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeProjesi
{
    public static class SessionManagement
    {
        

        public static bool isUserLegitRequest(int currentUserid, int RequestingUserid)
        {
            
                if (currentUserid == RequestingUserid)
                {
                    return true;
                }

                else
                {
                    return false;
                }

            
        }

    }
}
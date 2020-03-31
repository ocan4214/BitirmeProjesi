using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;


namespace BitirmeProjesi
{
    public static class SessionManagement
    {

        public static bool isGroupManager(int currentUserId,int groupId)
        {
            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                var user = db.Users.Find(currentUserId);
                var group = db.Groups.Find(groupId);
                if (user != null && group != null)
                {
                    var groupMember = group.GroupMembers.Where(a => a.UserId == currentUserId).First();
                    if (groupMember != null && groupMember.IsAdmin)
                    {
                        return true;
                    }
                    else
                        return false;

                }
                else
                    return false;
            
            }


        }

        public static bool isCurrentUser(int currentUserid, int requestingUserid)
        {

            if (currentUserid == requestingUserid)
            {
                return true;
            }

            else
            {
                return false;
            }


        }


        public static bool isUserOwnTheMessage(int id, string username)
        {

            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {

                if (username == db.Users.Find(id).UserName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public static string getUserName(int id)
        {
            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                return db.Users.Find(id).UserName;



            }


        }
    }



}
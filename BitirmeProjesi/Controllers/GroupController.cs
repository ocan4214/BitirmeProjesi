using BitirmeProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class GroupController : Controller
    {


        LogRegDBEntities1 db = new LogRegDBEntities1();


        [Authorize]
        public ActionResult CreateGroup()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateGroup([Bind(Exclude = "CreateDate,MemberCount,UpdateDate,OwnerId")]Group group, int id)
        {

            if (!db.Groups.Any(a => a.GroupName == group.GroupName))
            {
                if (ModelState.IsValid)
                {
                    if (SessionManagement.isCurrentUser(Convert.ToInt32(User.Identity.Name), id))
                    {
                        using (var innerContext = new LogRegDBEntities1())
                        {
                            var user = innerContext.Users.Find(id);
                            group.User = user;
                            user.Groups.Add(group);
                            group.CreateDate = System.DateTime.Now;
                            group.UpdateDate = System.DateTime.Now;
                            group.MemberCount = 0;
                            group.OwnerId = id;



                            innerContext.Groups.Add(group);
                            innerContext.SaveChanges();
                            innerContext.Dispose();
                        }
                        var res = CreateGroupMember(group.GroupId, id);


                        if (res == true)
                            ViewBag.ResultofGroupMember1 = "Succesfully Added";
                        else
                            ViewBag.ResultofGroupMember1 = "Error Happened";

                    }
                    return View();
                }
                else
                {
                    ViewBag.Error = "ModelState Hatalı";
                    return View(group);
                }


            }
            else
            {
                ViewBag.Error = "Grup Ismi Alınmış";
                return View(group);
            }

        }

        [Authorize]
        [HttpPost]
        public ActionResult JoinGroup(int groupid, int uid)
        {

            var res = CreateGroupMember(groupid, uid);

            if (res == true)
                ViewBag.ResultofGroupMember = "Succesfully Added";
            else
                ViewBag.ResultofGroupMember = "Error Happened";

            return RedirectToAction("ProfilePage", "Profile", new { id = db.Users.Find(uid).Profile.ProfileId });
        }

        [Authorize]
        [HttpGet]
        public ActionResult GroupPage(int groupid)
        {

            //Grup Public mi grup üyesi mi bunları düşün

            
        }



        [NonAction]
        public bool CreateGroupMember(int groupid, int userid)
        {


            using (LogRegDBEntities1 innerContext = new LogRegDBEntities1())
            {
                var group = innerContext.Groups.Find(groupid);
                var user = innerContext.Users.Find(userid);
                if (group != null && user != null)
                {
                    if (!group.GroupMembers.Where(a => a.UserId == user.UserId).Any())
                    {
                        group.MemberCount++;
                        var groupMember = new GroupMember { CreateDate = System.DateTime.Now.ToLongDateString(), User = user, Group = group, GroupId = group.GroupId, UserId = user.UserId };
                        group.GroupMembers.Add(groupMember);
                        user.GroupMembers.Add(groupMember);

                        innerContext.GroupMembers.Add(groupMember);
                        innerContext.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }
    }
}
using BitirmeProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models.ViewModel;

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
                            group.GroupChats.Add(new GroupChat() { GroupChatName = group.GroupName + "ChatRoom", IsPublic = true, GroupId = group.GroupId });
                            //Database te groupChat için kayıt oluşuyor mu bak
                            innerContext.Groups.Add(group);
                            innerContext.SaveChanges();
                            innerContext.Dispose();
                        }
                        var res = CreateGroupMember(group.GroupId, id, true);
                        if (res == true)
                            ViewBag.ResultofGroupMember1 = "Succesfully Added";
                        else
                            ViewBag.ResultofGroupMember1 = "Error Happened";
                    }
                    return RedirectToAction("GroupPage", "Group", new { groupid = group.GroupId });
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
            var res = CreateGroupMember(groupid, uid, false);
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
            Group group = db.Groups.Find(groupid);
            int userID = Convert.ToInt32(User.Identity.Name);
            GroupMember groupMember = group.GroupMembers.Where(a => a.UserId == userID).FirstOrDefault();
            //gruba üye olmadan bir gruba katılmayı dene
            if (group != null)
            {
                if (CanAccessGroup(group, groupMember))
                {
                    GroupPageViewModel groupPageViewModel = new GroupPageViewModel() { groupMemberView = groupMember, groupView = group };
                    //BAk
                    var g = groupPageViewModel.groupView.GroupChats;
                    return View(groupPageViewModel);
                }
                else
                {
                    ViewBag.groupError = " you are not in the group or not approved";
                    //Sayfaya katılma  linkine döndürsün
                    return RedirectToAction("ProfilePage", "Profile", new { id = db.Users.Find(userID).Profile.ProfileId });
                }
            }
            else
            {
                ViewBag.groupError = "group not exist";
                return RedirectToAction("ProfilePage", "Profile", new { id = db.Users.Find(userID).Profile.ProfileId });
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetProfileAvatarForChat(string username)
        {
            var userprofile = db.Users.Where(a => a.UserName == username).FirstOrDefault().Profile;
            if (userprofile.Avatar == null)
            {
                return File("C:\\Users\\ocan4214\\Desktop\\KENDİM\\Wallpapers\\9s_by_wlop-dax8mou.jpg", "image/jpg");
            }
            return File(userprofile.Avatar, "image/jpg");
        }

        [NonAction]
        public static bool CanAccessGroup(Group group, GroupMember groupMember)
        {
            return group.IsPublic || (groupMember != null && groupMember.IsApproved == true);
        }

        [NonAction]
        public static bool CreateGroupMember(int groupid, int userid, bool isAdmin)
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
                        var groupMember = new GroupMember { CreateDate = System.DateTime.Now.ToLongDateString(), User = user, Group = group, GroupId = group.GroupId, UserId = user.UserId, IsAdmin = false, IsApproved = false };
                        if (isAdmin == true)
                        {
                            groupMember.IsAdmin = true;
                            groupMember.IsApproved = true;
                        }
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
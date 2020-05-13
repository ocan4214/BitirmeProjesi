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
using BitirmeProjesi.Models.ViewModel;

namespace BitirmeProjesi.Controllers
{
    public class ProfileController : Controller
    {
        private LogRegDBEntities1 db = new LogRegDBEntities1();


        // GET: Profile/Details/5
        [Authorize(Roles = "Admin,Member")]
        public ActionResult ProfilePage(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userprofile = db.Users.Find(id).Profile;
            
            ProfilePageViewModel ViewModel = new ProfilePageViewModel { profileM = userprofile };
            if (userprofile == null)
            {

                return HttpNotFound();
            }
            return View(ViewModel);
        }
        [Authorize(Roles = "Admin,Member")]
        [HttpPost]
        public ActionResult UploadAvatar(int id, HttpPostedFileBase Avatar)
        {
            var uProfile = db.Profiles.Where(a => a.ProfileId == id).FirstOrDefault();
            if (SessionManagement.isCurrentUser(Convert.ToInt32(User.Identity.Name), uProfile.User.UserId))
            {
                if (ModelState.IsValid)
                {
                    if (uProfile != null)
                    {
                        if (Avatar != null && Avatar.ContentLength > 0)
                        {
                            using (var reader = new System.IO.BinaryReader(Avatar.InputStream))
                            {
                                var path = Path.Combine(Server.MapPath("~/App_Data/Avatars"), Avatar.FileName);
                                Avatar.SaveAs(path);
                                uProfile.Avatar = reader.ReadBytes(Avatar.ContentLength);
                                uProfile.AvatarLocation = path;
                            }
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Profile id is not legit";
                        return RedirectToAction("ProfilePage", "Profile", new { id = id });
                    }
                }
                return RedirectToAction("ProfilePage", "Profile", new { id = id });
            }
            else
            {
                ViewBag.Message = "Unauthorized";
                return RedirectToAction("ProfilePage", "Profile", new { id = id });
            }
        }

        


        public ActionResult GetAvatar(int id)
        {
            var avatar = db.Users.Where(a => a.Profile.ProfileId == id).FirstOrDefault().Profile.Avatar;
            if (avatar == null)
            {
                return File("C:\\Users\\ocan4214\\Desktop\\KENDİM\\Wallpapers\\9s_by_wlop-dax8mou.jpg", "image/jpg");
            }
            return File(avatar, "image/jpg");
        }


        // GET: Profile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileId,CreateDate,LastUpdateDate,Avatar")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

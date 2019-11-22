using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjesi.Controllers
{
    public class PostController : Controller
    {

        LogRegDBEntities1 db = new LogRegDBEntities1();

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostProfile(int id, ProfilePageViewModel post, HttpPostedFileBase[] UploadedFile)
        {
            var currentUserRequesting = db.Users.Where(a => a.Email == User.Identity.Name).FirstOrDefault();
            if (SessionManagement.isUserLegitRequest(id,currentUserRequesting.UserId))
            {

                if (ModelState.IsValid)
                {

                    post.postM.UploadFiles = new List<UploadFile>();

                    foreach (HttpPostedFileBase file in UploadedFile)
                    {
                        if (file != null && file.ContentLength > 0)
                        {

                            var ToDbFile = new UploadFile
                            {
                                UploadFileType = file.ContentType,
                                Post = post.postM

                            };

                            using (var reader = new BinaryReader(file.InputStream))
                            {
                                ToDbFile.UploadContent = reader.ReadBytes(file.ContentLength);

                            }
                            db.UploadFiles.Add(ToDbFile);
                        }



                    }
                    post.postM.DateofPost = DateTime.Now;
                    post.postM.UserId = id;

                    db.Posts.Add(post.postM);
                    db.SaveChanges();
                    return RedirectToAction("ProfilePage", "Profile", new { id = id });

                }
                else
                {
                    ViewBag.Message3 = "Posting Failed";
                    return RedirectToAction("ProfilePage", "Profile", new { id = id });
                }

            }
            else
            {
                ViewBag.Message3 = "You are not the current user of this account";
                return RedirectToAction("ProfilePage", "Profile", new { id = id });

            }
        }

        public ActionResult getPostImage(int id)
        {


            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                var image = db.UploadFiles.Find(id);



                return File(image.UploadContent, "image/jpg");

            }
        }




    }
}
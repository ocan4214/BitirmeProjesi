using BitirmeProjesi.Models;
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
        public ActionResult PostProfile(int id,[Bind(Include = "UserMentions,ContentofPost,Likes,Dislikes")] Post post, HttpPostedFileBase[] UploadedFile)
        {

            if (ModelState.IsValid)
            {

                post.UploadFiles = new List<UploadFile>();

                foreach (HttpPostedFileBase file in UploadedFile)
                {
                    if (file != null && file.ContentLength > 0)
                    {

                        var ToDbFile = new UploadFile
                        {
                            UploadFileType = file.ContentType,
                            Post = post
                            
                        };

                        using (var reader = new BinaryReader(file.InputStream))
                        {
                            ToDbFile.UploadContent = reader.ReadBytes(file.ContentLength);

                        }
                        db.UploadFiles.Add(ToDbFile);
                    }



                }
                post.DateofPost = DateTime.Today;
                post.UserId = id;
                
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("ProfilePage", "Profile", new { id = id });

            }
            else
            {
                ViewBag.Message3 = "Posting Failed";
                return RedirectToAction("ProfilePage", "Profile", new { id = id });
            }


        }
    }
}
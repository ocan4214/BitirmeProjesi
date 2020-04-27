using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;
using BitirmeProjesi.Models.ViewModel;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        [HttpGet]
        public ActionResult EventCreate(int groupid)
        {
            ViewBag.groupid = groupid;
            return View();
        }


        [HttpPost]
        public ActionResult EventCreate(int groupid, [Bind(Exclude = "EventGroup,EventCreateDate,EventUpdateDate,EventId")]Event viewModel, HttpPostedFileBase ThumbnailImage)
        {
            LogRegDBEntities1 db = new LogRegDBEntities1();
            if (ModelState.IsValid)
            {
                if (ThumbnailImage != null && ThumbnailImage.ContentLength > 0)
                {
                    using (var reader = new BinaryReader(ThumbnailImage.InputStream))
                    {
                        viewModel.EventThumbnail = reader.ReadBytes(ThumbnailImage.ContentLength);
                    }
                }
            }
            viewModel.EventUpdateDate = DateTime.Now;
            viewModel.EventCreateDate = DateTime.Now;
            viewModel.EventGroup = groupid;

            db.Events.Add(viewModel);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult EventPage(int eventid)
        {
            LogRegDBEntities1 db = new LogRegDBEntities1();

            EventPageViewModel model = new EventPageViewModel();

            model.eventPageModel = db.Events.Where(a => a.EventId == eventid).FirstOrDefault();
            model.eventNewsModel = db.EventNews.Where(a => a.EventId == eventid).FirstOrDefault();
            
            

            return View(model);
        }

        public ActionResult PostEventNews(int eventid,EventPageViewModel eventPageViewModel, HttpPostedFileBase[] UploadedFile)
        {
            LogRegDBEntities1 db = new LogRegDBEntities1();

            return RedirectToAction("EventPage", "Event", new { eventid = eventid });
        }


        public ActionResult getEventThumbnail(int id)
        {
            using (LogRegDBEntities1 db = new LogRegDBEntities1())
            {
                var image = db.Events.Find(id);
                if (image == null)
                {
                    return File("C:\\Users\\ocan4214\\Desktop\\KENDİM\\Wallpapers\\9s_by_wlop-dax8mou.jpg", "image/jpg");
                }
                return File(image.EventThumbnail, "image/jpg");
            }
        }




    }
}

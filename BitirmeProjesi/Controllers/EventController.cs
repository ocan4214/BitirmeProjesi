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
        public ActionResult EventCreate(int groupid,[Bind(Exclude= "EventGroup,EventCreateDate,EventUpdateDate,EventId")]Event viewModel,HttpPostedFileBase ThumbnailImage)
        {
            LogRegDBEntities1 db = new LogRegDBEntities1();
            if(ModelState.IsValid)
            {
                if(ThumbnailImage!=null && ThumbnailImage.ContentLength>0)
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





        

    }
}

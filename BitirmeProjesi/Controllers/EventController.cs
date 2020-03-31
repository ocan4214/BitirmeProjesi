using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitirmeProjesi.Models;

namespace BitirmeProjesi.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        [HttpGet]
        public ActionResult EventCreate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EventCreate([Bind(Exclude= "EventCreateDate,EventUpdateDate,EventId")]Event eventM,HttpPostedFileBase ThumbnailImage)
        {




            return View();
        }





        

    }
}

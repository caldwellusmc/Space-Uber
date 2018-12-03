using SpaceUber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceUber.WebMVC.Controllers
{
    [Authorize]
    public class RiderController : Controller
    {
        // GET: Rider
        public ActionResult Index()
        {
            var model = new RiderListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RiderCreate model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
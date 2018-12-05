using Microsoft.AspNet.Identity;
using SpaceUber.Models;
using SpaceUber.Services;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RiderService(userId);
            var model = service.GetRiders();

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
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RiderService(userId);

            service.CreateRider(model);

            return RedirectToAction("Index");
        }
    }
}
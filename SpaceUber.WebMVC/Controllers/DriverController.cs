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
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DriverService(userId);
            var model = service.GetDrivers();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DriverCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDriverService();

            if (service.CreateDriver(model))
            {
                TempData["SaveResult"] = "You have been registered!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Info could not be registered.");

            return View(model);
        }

        private DriverService CreateDriverService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DriverService(userId);
            return service;
        }
    }
}
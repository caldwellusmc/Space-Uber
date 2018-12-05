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

        public ActionResult Details(int id)
        {
            var svc = CreateDriverService();
            var model = svc.GetDriverById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDriverService();
            var detail = service.GetDriverById(id);
            var model =
                new DriverEdit
                {
                    DriverId = detail.DriverId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Age = detail.Age,
                    LicenseNumber = detail.LicenseNumber,
                    SpaceshipMake = detail.SpaceshipMake
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DriverEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.DriverId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDriverService();

            if (service.UpdateDriver(model))
            {
                TempData["SaveResult"] = "Your info has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your info could not be changed.");
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
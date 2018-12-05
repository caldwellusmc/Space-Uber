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
            if (!ModelState.IsValid) return View(model);

            var service = CreateRiderService();

            if (service.CreateRider(model))
            {
                TempData["SaveResult"] = "Your ride has been requested!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your ride could not be requested.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRiderService();
            var model = svc.GetRiderById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRiderService();
            var detail = service.GetRiderById(id);
            var model =
                new RiderEdit
                {
                    RiderId = detail.RiderId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Destination = detail.Destination
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RiderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RiderId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRiderService();

            if(service.UpdateRider(model))
            {
                TempData["SaveResult"] = "Your ride request has been updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your request could not be updated.");
            return View(model);
        }

        private RiderService CreateRiderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RiderService(userId);
            return service;
        }
    }
}
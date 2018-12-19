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
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReviews();

            return View(model);
        }

        public ActionResult Create()
        {
            var svc = CreateReviewService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var driverList = new SelectList(svc.Drivers(), "DriverId", "FullName");
            ViewBag.DriverId = driverList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReviewService();

            if(service.CreateReview(model))
            {
                TempData["SaveResult"] = "Thanks for the review!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Review was not created.");
            ViewBag.DriverId = new SelectList(service.Drivers(), "DriverId", "FullName");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewById(id);
            var driverList = new SelectList(service.Drivers(), "DriverId", "FullName", detail.DriverId);
            ViewBag.DriverId = driverList;
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    //FirstName = detail.FirstName,
                    //LastName = detail.LastName,
                    Description = detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ReviewId !=id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReviewService();

            if(service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your review has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your review could not be updated.");
            var driverList = new SelectList(service.Drivers(), "DriverId", "FullName", model.Driver.DriverId);
            ViewBag.DriverId = driverList;
            
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "Your review has been deleted.";

            return RedirectToAction("Index");
        }

        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            return service;
        }
    }
}
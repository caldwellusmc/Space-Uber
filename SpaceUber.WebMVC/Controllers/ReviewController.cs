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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);

            service.CreateReview(model);

            return RedirectToAction("Index");
        }
    }
}
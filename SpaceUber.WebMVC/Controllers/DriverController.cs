using SpaceUber.Models;
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
            var model = new DriverListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Beskrivelse";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt";

            return View();
        }
    }
}
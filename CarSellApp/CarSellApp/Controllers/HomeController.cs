﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarSellApp.Controllers
{
    public class HomeController : Controller
    {
	    // GET: Home
        public ActionResult Index()
        {
			return View();
        }
	}
}
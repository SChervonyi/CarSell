using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;

namespace CarSellApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
	        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			var repository = new Repository(new EFDbContext(connectionString));
	        var manufactures = repository.GetManufacturers();

			return View(manufactures);
        }
    }
}
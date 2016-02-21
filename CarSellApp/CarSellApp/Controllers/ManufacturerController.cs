using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSellApp.Helpers;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class ManufacturerController : Controller
    {
	    private readonly IManufacturerRepository repository;

	    public ManufacturerController(IManufacturerRepository repository)
	    {
		    this.repository = repository;
	    }

        // GET: Manufacturer
        public ActionResult Index()
        {
	        var manufacturers = VMBuilder.BuildManufacturersVM(repository.GetAll());
            return View(manufacturers);
        }
    }
}
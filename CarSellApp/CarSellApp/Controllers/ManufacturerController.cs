using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSellApp.Helpers;
using CarSellApp.Models;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class ManufacturerController : Controller
    {
	    private readonly IManufacturerRepository manufacturerRepository;

	    public ManufacturerController(IManufacturerRepository manufacturerRepository)
	    {
		    this.manufacturerRepository = manufacturerRepository;
	    }

        // GET: Manufacturer
        public ActionResult Index()
        {
	        var manufacturers = manufacturerRepository.GetAll();
			return View(VMBuilder.BuildManufacturersVM(manufacturers));
        }
    }
}
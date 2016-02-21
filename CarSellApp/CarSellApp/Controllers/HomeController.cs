using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSellApp.Helpers;
using Domain.Concrete;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class HomeController : Controller
    {
	    private readonly ICarRepository carRepository;

	    public HomeController(ICarRepository carRepository)
	    {
		    this.carRepository = carRepository;
	    }

        // GET: Home
        public ActionResult Index()
        {
			var cars = VMBuilder.BuildCarsVM(carRepository.GetAll());
			return View(cars);
        }
    }
}
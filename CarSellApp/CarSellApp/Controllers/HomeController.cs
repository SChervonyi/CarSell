using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarSellApp.Helpers;
using CarSellApp.Models;
using Domain.Concrete;
using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace CarSellApp.Controllers
{
    public class HomeController : Controller
    {
	    private readonly ICarRepository carRepository;

	    private ICollection<CarViewModel> cars; 

	    public HomeController(ICarRepository carRepository)
	    {
		    this.carRepository = carRepository;	
		}

	    protected override void Initialize(RequestContext requestContext)
	    {
			cars = VMBuilder.BuildCarsVM(carRepository.GetAll()).ToList();
			base.Initialize(requestContext);
	    }

	    // GET: Home
        public ActionResult Index()
        {
			return View(cars);
        }

	    public ActionResult Delete(Car car)
	    {
		    cars.Remove(cars.Single(x => x.DomainCar.Id == car.Id));
			carRepository.Remove(car.Id);

			return View("Index", cars);
	    }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarSellApp.Helpers;
using CarSellApp.Models;
using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace CarSellApp.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IUnitOfWork unitOfWork;

	    private ICollection<CarViewModel> cars; 

	    public HomeController(IUnitOfWork unitOfWork)
	    {
		    this.unitOfWork = unitOfWork;	
		}

	    protected override void Initialize(RequestContext requestContext)
	    {
			base.Initialize(requestContext);
			cars = VMBuilder.BuildCarsVM(unitOfWork.CarRepository.GetAll()).ToList();
	    }

	    // GET: Home
        public ActionResult Index()
        {
			return View(cars);
        }

	    public ActionResult Delete(Car car)
	    {
		    cars.Remove(cars.Single(x => x.DomainCar.Id == car.Id));
			unitOfWork.CarRepository.Remove(car.Id);
		    unitOfWork.CompleteAsync();
			return View("Index", cars);
	    }
	}
}
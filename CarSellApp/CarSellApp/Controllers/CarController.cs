using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarSellApp.Helpers;
using CarSellApp.Models;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class CarController : Controller
    {
		private readonly IUnitOfWork unitOfWork;

		private ICollection<CarViewModel> cars;

		public CarController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			cars = VMBuilder.BuildCarsVM(unitOfWork.CarRepository.GetAll()).ToList();
		}

		// GET: Car
		public ActionResult Index()
		{
			return View(cars);
		}

		[HttpPost]
		public ActionResult Delete(long carId)
		{
			cars.Remove(cars.Single(x => x.DomainCar.Id == carId));
			unitOfWork.CarRepository.Remove(carId);
			unitOfWork.CompleteAsync();
			return View("Index", cars);
		}
	}
}
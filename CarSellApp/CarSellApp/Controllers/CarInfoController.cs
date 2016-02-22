using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CarSellApp.Models;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class CarInfoController : Controller
    {
		#region Pirvate Fiels.

		private readonly IUnitOfWork unitOfWork;

		private IEnumerable<CarInfoViewModel> carsInfo;

		#endregion



		#region Constructor, Initializer.

		public CarInfoController(IUnitOfWork unitOfWork)
	    {
		    this.unitOfWork = unitOfWork;
	    }

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

			var cars = unitOfWork.CarRepository.GetAll();
			var equipments = unitOfWork.EquipmentRepository.GetAll();

			var crossApply = from car in cars
							 from equipment in equipments
							 select new CarInfoViewModel
							 {
								 CarName = car.Name,
								 ManufacturerName = car.Manufacturer.Name,
								 Equipment = equipment.Name,
								 Price = car.Price * (decimal)equipment.Rate
							 };

			carsInfo = crossApply;
		}

		#endregion



		#region Actions

		// GET: CarInfo
		public ActionResult Index()
        {
			return View(carsInfo);
        }

		#endregion
	}
}
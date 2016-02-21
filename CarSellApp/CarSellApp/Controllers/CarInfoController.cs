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
    public class CarInfoController : Controller
    {
	    private readonly ICarRepository carRepository;

	    private readonly IEquipmentRepository equipmentRepository;

	    private IEnumerable<CarInfoViewModel> carsInfo;

	    public CarInfoController(ICarRepository carRepository, IEquipmentRepository equipmentRepository)
	    {
		    this.carRepository = carRepository;
		    this.equipmentRepository = equipmentRepository;
	    }

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

			var cars = carRepository.GetAll();
			var equipments = equipmentRepository.GetAll();

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

		// GET: CarInfo
		public ActionResult Index()
        {
			return View(carsInfo);
        }
    }
}
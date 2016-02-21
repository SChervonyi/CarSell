using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSellApp.Models;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class CarInfoController : Controller
    {
	    private ICarRepository carRepository;

	    private IEquipmentRepository equipmentRepository;

	    public CarInfoController(ICarRepository carRepository, IEquipmentRepository equipmentRepository)
	    {
		    this.carRepository = carRepository;
		    this.equipmentRepository = equipmentRepository;
	    }

        // GET: CarInfo
        public ActionResult Index()
        {
	        var cars = carRepository.GetAll();
	        var equipments = equipmentRepository.GetAll();

	        var crossApply = from car in cars
		        from equipment in equipments
		        select new CarInfoViewModel
		        {
			        CarName = car.Name,
			        ManufacturerName = car.Manufacturer.Name,
			        Equipment = equipment.Name,
			        Price = car.Price*(decimal)equipment.Rate
		        };

			return View(crossApply);
        }
    }
}
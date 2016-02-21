using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarSellApp.Models;
using Domain.Concrete.Interfaces;

namespace CarSellApp.Controllers
{
    public class ManufacturerInfoController : Controller
    {
		private readonly IManufacturerRepository manufacturerRepository;

		private readonly ICarRepository carRepository;

		public ManufacturerInfoController(IManufacturerRepository manufacturerRepository, ICarRepository carRepository)
		{
			this.manufacturerRepository = manufacturerRepository;
			this.carRepository = carRepository;
		}

		// GET: ManufacturerInfo
		public ActionResult Index()
        {
			var manufacturers = manufacturerRepository.GetAll();
			var cars = carRepository.GetAll();

			var leftJoinQuery = from manufacturer in manufacturers
				join car in cars on manufacturer.Id equals car.ManufacturerId into gj
				from subcar in gj.DefaultIfEmpty()
				select new {manufacturer.Code, manufacturer.Name, Car = subcar};

			var groupByQuery = from manufacturer in leftJoinQuery
				where manufacturer.Car != null
				group manufacturer by new {manufacturer.Code, manufacturer.Name}
				into g
				select new ManufacturerInfoViewModel
				{
					Code = g.Key.Code,
					Name = g.Key.Name,
					MinPrice = g.Min(x => x.Car.Price),
					MaxPricde = g.Max(x => x.Car.Price),
					ModelsCout = g.Count()
				};

			return View(groupByQuery);
        }
    }
}
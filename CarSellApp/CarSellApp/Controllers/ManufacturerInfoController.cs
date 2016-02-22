using System;
using System.Collections.Generic;
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
    public class ManufacturerInfoController : Controller
    {
		#region Pirvate Fiels.

		private readonly IUnitOfWork unitOfWork;

		private IEnumerable<Manufacturer> manufacturers;

		private IEnumerable<Car> cars;

		#endregion



		#region Constructor, Initializer.

		public ManufacturerInfoController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

			manufacturers = unitOfWork.ManufacturerRepository.GetAll();
			cars = unitOfWork.CarRepository.GetAll();
		}

		#endregion



		#region Actions.

		// GET: ManufacturerInfo
		public ActionResult Index()
        {
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

	    public ActionResult ShowCheap()
	    {
			// I don't save and reuse previuse result just to show one more LINQ to Entities
			var havingQuery = from manufacturer in manufacturers
			    join car in cars on manufacturer.Id equals car.ManufacturerId
			    group car by new { manufacturer.Code, manufacturer.Name }
				into g
				where g.Average(x => x.Price) < 45000
			    select new ManufacturerInfoViewModel
				{
					Code = g.Key.Code,
					Name = g.Key.Name,
					MinPrice = g.Min(x => x.Price),
					MaxPricde = g.Max(x => x.Price),
					ModelsCout = g.Count()
				};

			return View("Index", havingQuery);
	    }

		#endregion
	}
}
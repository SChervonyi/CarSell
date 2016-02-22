using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		#region Pirvate Fiels.

		private readonly IUnitOfWork unitOfWork;

		private ICollection<CarViewModel> cars;

		#endregion



		#region Constructor, Initializer.

		public CarController(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			cars = unitOfWork.CarRepository.GetAll().ToViewModels().ToList();
		}

		#endregion



		#region Actions.

		// GET: Car
		public ActionResult Index()
		{
			return View(cars);
		}

		[HttpPost]
		public async Task<ActionResult> Delete(long carId)
		{
			cars.Remove(cars.First(x => x.DomainCar.Id == carId));
			unitOfWork.CarRepository.Remove(carId);
			await unitOfWork.CompleteAsync();
			return View("Index", cars);
		}

		#endregion
	}
}
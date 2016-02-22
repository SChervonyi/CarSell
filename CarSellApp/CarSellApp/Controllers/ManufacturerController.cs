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
    public class ManufacturerController : Controller
    {
		#region Pirvate Fiels.

		private readonly IUnitOfWork unitOfWork;

	    private IEnumerable<ManufacturerViewModel> manufacturers;

		#endregion



		#region Constructor, Initializer.

		public ManufacturerController(IUnitOfWork unitOfWork)
	    {
		    this.unitOfWork = unitOfWork;
	    }

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			manufacturers = unitOfWork.ManufacturerRepository.GetAll().ToViewModels();
		}

		#endregion



		#region Actions.

		// GET: Manufacturer
		public ActionResult Index()
        {
			return View(manufacturers);
        }

		public ActionResult AddNew()
		{
			return View("Edit", new ManufacturerViewModel());
		}

		public ActionResult Edit(ManufacturerViewModel manufacturer)
		{
			return View(manufacturer);
		}

		[HttpPost]
		public async Task<ActionResult> Submit(ManufacturerViewModel manufacturer)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.ManufacturerRepository.Save(manufacturer.DomainManufacturer);
				await unitOfWork.CompleteAsync();
				return RedirectToAction("Index");
			}

			return View("Edit", manufacturer);
		}

		#endregion
	}
}
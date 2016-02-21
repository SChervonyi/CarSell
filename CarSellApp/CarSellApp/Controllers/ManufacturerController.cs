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
    public class ManufacturerController : Controller
    {
	    private readonly IUnitOfWork unitOfWork;

	    private IEnumerable<ManufacturerViewModel> manufacturers;

		public ManufacturerController(IUnitOfWork unitOfWork)
	    {
		    this.unitOfWork = unitOfWork;
	    }

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			manufacturers = VMBuilder.BuildManufacturersVM(unitOfWork.ManufacturerRepository.GetAll());
		}

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
		public ActionResult Submit(ManufacturerViewModel manufacturer)
		{
			if (ModelState.IsValid)
			{
				unitOfWork.ManufacturerRepository.Save(manufacturer.DomainManufacturer);
				return RedirectToAction("Index");
			}

			return View("Edit", manufacturer);
		}
	}
}
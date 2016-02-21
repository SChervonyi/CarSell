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
	    private readonly IManufacturerRepository manufacturerRepository;

	    private IEnumerable<ManufacturerViewModel> manufacturers;

		public ManufacturerController(IManufacturerRepository manufacturerRepository)
	    {
		    this.manufacturerRepository = manufacturerRepository;
	    }

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			manufacturers = VMBuilder.BuildManufacturersVM(manufacturerRepository.GetAll());
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
				manufacturerRepository.Save(manufacturer.DomainManufacturer);
				return RedirectToAction("Index");
			}

			return View("Edit", manufacturer);
		}
	}
}
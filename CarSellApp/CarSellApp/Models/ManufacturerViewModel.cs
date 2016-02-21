using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Entities;

namespace CarSellApp.Models
{
	public class ManufacturerViewModel
	{
		private readonly Manufacturer domainManufacturer;

		public ManufacturerViewModel()
		{
			this.domainManufacturer = new Manufacturer();
		}

		public ManufacturerViewModel(Manufacturer domainManufacturer)
		{
			this.domainManufacturer = domainManufacturer;
		}

		[HiddenInput(DisplayValue = false)]
		public Manufacturer DomainManufacturer
		{
			get { return domainManufacturer; }
		}

		[HiddenInput(DisplayValue = false)]
		public long Id
		{
			get { return domainManufacturer.Id; }
			set { domainManufacturer.Id = value; }
		}

		[Required(ErrorMessage = "Please enter a Manufacturer code")]
		public string Code
		{
			get { return domainManufacturer.Code; }
			set { domainManufacturer.Code = value; }
		}

		[Required(ErrorMessage = "Please enter a Manufacturer name")]
		public string Name
		{
			get { return domainManufacturer.Name; }
			set { domainManufacturer.Name = value; }
		}
	}
}
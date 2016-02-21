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

		public Manufacturer DomainManufacturer
		{
			get { return domainManufacturer; }
		}

		public string Code
		{
			get { return domainManufacturer.Code; }
			set { domainManufacturer.Code = value; }
		}

		public string Name
		{
			get { return domainManufacturer.Name; }
			set { domainManufacturer.Name = value; }
		}
	}
}
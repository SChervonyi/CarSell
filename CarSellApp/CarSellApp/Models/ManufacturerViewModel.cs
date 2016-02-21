using Domain.Entities;

namespace CarSellApp.Models
{
	public class ManufacturerViewModel
	{
		private readonly Manufacturer domainManufacturer;

		public ManufacturerViewModel(Manufacturer domainManufacturer)
		{
			this.domainManufacturer = domainManufacturer;
		}

		public string Name
		{
			get { return domainManufacturer.Name; }
		}
	}
}
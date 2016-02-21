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

		public string Code
		{
			get { return domainManufacturer.Code; }
		}

		public string Name
		{
			get { return domainManufacturer.Name; }
		}

		public int ModelsCout { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPricde { get; set; }
	}
}
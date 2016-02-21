using Domain.Entities;

namespace CarSellApp.Models
{
	public class CarViewModel
	{
		private readonly Car domainCar;

		public CarViewModel(Car domainCar)
		{
			this.domainCar = domainCar;
			Manufacturer = new ManufacturerViewModel(domainCar.Manufacturer);
		}

		public Car DomainCar
		{
			get { return domainCar; }
		}

		public string Name
		{
			get { return domainCar.Name; }
		}

		public decimal Price
		{
			get { return domainCar.Price; }
			set { domainCar.Price = value; }
		}

		public ManufacturerViewModel Manufacturer { get; set; }
	}
}
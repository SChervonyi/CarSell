using Domain.Entities;

namespace CarSellApp.Models
{
	public class CarViewModel
	{
		private readonly Car domainCar;

		public CarViewModel()
		{
			this.domainCar = new Car();
		}

		public CarViewModel(Car domainCar)
		{
			this.domainCar = domainCar;
			Manufacturer = new ManufacturerViewModel(domainCar.Manufacturer);
		}

		public Car DomainCar
		{
			get { return domainCar; }
		}

		public long Id
		{
			get { return domainCar.Id; }
		}

		public string Code
		{
			get { return domainCar.Code; }
			set { domainCar.Code = value; }
		}

		public string Name
		{
			get { return domainCar.Name; }
			set { domainCar.Name = value; }
		}

		public decimal Price
		{
			get { return domainCar.Price; }
			set { domainCar.Price = value; }
		}

		public ManufacturerViewModel Manufacturer { get; set; }
	}
}
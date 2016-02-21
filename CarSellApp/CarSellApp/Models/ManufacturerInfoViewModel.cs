using Domain.Entities;

namespace CarSellApp.Models
{
	public class ManufacturerInfoViewModel
	{
		public string Code { get; set; }

		public string Name { get; set; }

		public int ModelsCout { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPricde { get; set; }
	}
}
using System.Collections.Generic;

namespace Domain.Entities
{
	public class Car
	{
		public long Id { get; set; }

		public long ManufacturerId { get; set; }

		public string Code { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		//public virtual ICollection<Accessory> Accessories { get; set; } = new HashSet<Accessory>();

		public virtual Manufacturer Manufacturer { get; set; }
	}
}
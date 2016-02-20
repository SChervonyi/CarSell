using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Concrete
{
	public class Repository
	{
		private EFDbContext context;

		public Repository(EFDbContext context)
		{
			this.context = context;
		}

		public ICollection<Manufacturer> GetManufacturers()
		{
			return context.Manufacturers.ToList();
		} 
	}
}
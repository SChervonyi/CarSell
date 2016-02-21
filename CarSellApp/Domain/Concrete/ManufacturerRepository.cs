using System.Collections.Generic;
using System.Linq;
using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace Domain.Concrete
{
	public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
	{
		public ManufacturerRepository(EFDbContext context) : base(context)
		{
		}

		public override void Remove(Manufacturer entity)
		{
			var varToDelete = EFContext.Cars.Where(x => x.ManufacturerId == entity.Id);
			EFContext.Cars.RemoveRange(varToDelete);
			EFContext.Manufacturers.Remove(entity);
		}

		public override void RemoveRange(IEnumerable<Manufacturer> entities)
		{
			foreach (var entity in entities)
				Remove(entity);
		}

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
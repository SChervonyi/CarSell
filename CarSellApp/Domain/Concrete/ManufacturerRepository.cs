using System;
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

		public void Remove(long entityId)
		{
			var carsToDelete = EFContext.Cars.Where(x => x.ManufacturerId == entityId);
			EFContext.Cars.RemoveRange(carsToDelete);

			var manufacturerToDelete = EFContext.Manufacturers.Find(entityId);
			EFContext.Manufacturers.Remove(manufacturerToDelete);
		}

		public void RemoveRange(IEnumerable<long> entityIds)
		{
			foreach (var entityId in entityIds)
				Remove(entityId);
		}

		public void Save(Manufacturer entity)
		{
			if (entity.Id == 0)
			{
				EFContext.Manufacturers.Add(entity);
			}
			else
			{
				var manufacturer = EFContext.Manufacturers.Find(entity.Id);
				manufacturer.Name = entity.Name;
				manufacturer.Code = entity.Code;
			}
		}

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
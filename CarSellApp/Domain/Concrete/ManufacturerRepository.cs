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

		public void Remove(Manufacturer entity)
		{
			var varToDelete = EFContext.Cars.Where(x => x.ManufacturerId == entity.Id);
			EFContext.Cars.RemoveRange(varToDelete);
			EFContext.Manufacturers.Remove(entity);
		}

		public void RemoveRange(IEnumerable<Manufacturer> entities)
		{
			foreach (var entity in entities)
				Remove(entity);
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
			EFContext.SaveChanges();
		}

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
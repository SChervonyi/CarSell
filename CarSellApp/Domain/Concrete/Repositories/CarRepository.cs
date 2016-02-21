using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace Domain.Concrete.Repositories
{
	public class CarRepository : Repository<Car>, ICarRepository
	{
		public CarRepository(EFDbContext context) : base(context)
		{
		}

		public IEnumerable<Car> GetCarsByManufacturer(long manufacturerId)
		{
			return EFContext.Cars.Where(x => x.ManufacturerId == manufacturerId);
		}

		public void Remove(long entityId)
		{
			//var carToDelete = new Car {Id = entityId};
			//EFContext.Cars.Attach(carToDelete);

			var carToDelete = EFContext.Cars.Find(entityId);
			EFContext.Cars.Remove(carToDelete);
		}

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
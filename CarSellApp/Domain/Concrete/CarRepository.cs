using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace Domain.Concrete
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

		public void Remove(long carId)
		{
			var carToDelete = EFContext.Cars.Single(x => x.Id == carId);
			EFContext.Cars.Remove(carToDelete);
			EFContext.SaveChanges();
		}

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
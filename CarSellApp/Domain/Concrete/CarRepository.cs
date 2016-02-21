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

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
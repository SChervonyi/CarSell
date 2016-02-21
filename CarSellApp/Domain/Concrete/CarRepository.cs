using System;
using System.Collections.Generic;
using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace Domain.Concrete
{
	public class CarRepository : Repository<Car>, ICarRepository
	{
		public CarRepository(EFDbContext context) : base(context)
		{
		}

		public IEnumerable<Car> GetCarsByManufacturer(int manufacturerId)
		{
			return null;
		}

		public EFDbContext EFContext
		{
			get { return Context as EFDbContext; }
		}
	}
}
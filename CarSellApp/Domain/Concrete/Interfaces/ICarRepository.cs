using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Concrete.Interfaces
{
	public interface ICarRepository : IRepository<Car>
	{
		IEnumerable<Car> GetCarsByManufacturer(long manufacturerId);
	}
}
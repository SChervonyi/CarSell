using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Concrete.Interfaces
{
	public interface IManufacturerRepository : IRepository<Manufacturer>
	{
		void Remove(Manufacturer entity);

		void Save(Manufacturer entity);
	}
}
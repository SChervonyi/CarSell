using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Concrete.Interfaces
{
	public interface IManufacturerRepository : IRepository<Manufacturer>
	{
		void Remove(long entityId);

		void RemoveRange(IEnumerable<long> entityIds);

		void Save(Manufacturer entity);
	}
}
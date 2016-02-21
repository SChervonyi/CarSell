using System;
using System.Threading.Tasks;

namespace Domain.Concrete.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IEquipmentRepository EquipmentRepository { get; }

		IManufacturerRepository ManufacturerRepository { get; }

		ICarRepository CarRepository { get; }

		int Complete();

		Task<int> CompleteAsync();
	}
}
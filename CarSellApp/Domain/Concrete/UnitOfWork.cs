using System;
using System.Threading.Tasks;
using Domain.Concrete.Interfaces;

namespace Domain.Concrete
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly EFDbContext context;

		private bool disposed;

		public UnitOfWork(ICarRepository carRepository, 
			IEquipmentRepository equipmentRepository,
			IManufacturerRepository manufacturerRepository,
			EFDbContext context)
		{
			CarRepository = carRepository;
			EquipmentRepository = equipmentRepository;
			ManufacturerRepository = manufacturerRepository;
			this.context = context;
		}

		public ICarRepository CarRepository { get; }

		public IEquipmentRepository EquipmentRepository { get; }

		public IManufacturerRepository ManufacturerRepository { get; }

		public Task<int> CompleteAsync()
		{
			return context.SaveChangesAsync();
		}

		public int Complete()
		{
			return context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
				context.Dispose();

			disposed = true;
		}
	}
}
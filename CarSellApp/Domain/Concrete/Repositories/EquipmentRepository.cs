using Domain.Concrete.Interfaces;
using Domain.Entities;

namespace Domain.Concrete.Repositories
{
	public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
	{
		public EquipmentRepository(EFDbContext context) : base(context)
		{
		}
	}
}
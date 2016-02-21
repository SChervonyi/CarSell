using System.Data.Entity;
using Domain.Entities;

namespace Domain.Concrete
{
	public class EFDbContext : DbContext
	{
		public EFDbContext(string connectionString)
		{
			Database.Connection.ConnectionString = connectionString;
		}

		public DbSet<Manufacturer> Manufacturers { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<Equipment> Equipments { get; set; }
	}
}

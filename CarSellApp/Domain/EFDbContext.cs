using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	class EFDbContext : DbContext
	{
		public EFDbContext(string connectionString)
		{
			Database.Connection.ConnectionString = connectionString;
		}
	}
}

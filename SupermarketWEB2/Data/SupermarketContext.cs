using Microsoft.EntityFrameworkCore;
using SupermarketWEB2.Models;

namespace SupermarketWEB2.Data
{
	public class SupermarketContext : DbContext
	{
		public DbSet<Products> Product { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<PayMode> PayModes { get; set; }
		public DbSet<Customer> Customers { get; set; }

		public SumpermarketContext(DbContextOptions options) : base(options)
		{
		}
	}
}

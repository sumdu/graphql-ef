using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Database
{
	public partial class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public MyDbContext() { }
		public MyDbContext(DbContextOptions<DbContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("data source=SqlServer;initial catalog=DbName;uid=user;pwd=pass;");
			}
		}
	}
}

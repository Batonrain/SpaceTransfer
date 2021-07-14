using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceTransfer.Db.Entities;

namespace SpaceTransfer.Db
{
	public sealed class ApplicationContext : DbContext
	{
		private readonly IConfiguration _configuration;
		public DbSet<User> Users { get; set; }
		public DbSet<Festival> Festivals { get; set; }
		public DbSet<Transfer> Transfers { get; set; }
		public ApplicationContext(
			DbContextOptions<ApplicationContext> options,
			IConfiguration configuration)
			: base(options)
		{
			_configuration = configuration;
			// Database.EnsureDeleted();
			// Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(_configuration.GetConnectionString("WebApiDatabase"));
		}
	}
}
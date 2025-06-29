using Microsoft.EntityFrameworkCore;

namespace ApplicationApi.Infrastructure.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<PopulationRecord> PopulationRecords { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PopulationRecord>().ToTable("PopulationRecords");
		}
	}
}

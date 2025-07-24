using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Infrastructure.Database
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<PopulationRecord> PopulationRecords { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PopulationRecord>().ToTable("PopulationRecords");
		}
	}
}

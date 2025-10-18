using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Infrastructure.Context
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<PopulationRecord> PopulationRecords { get; set; }
		public DbSet<Population> Populations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PopulationRecord>(entity =>
			{
				entity.ToTable("PopulationRecords");
				entity.HasKey(populationRecord => populationRecord.Id);

				entity.Property(populationRecord => populationRecord.CreatedAt)
					.HasColumnName("Created at")
					.HasColumnType("INTEGER")
					.HasConversion(
						createdAt =>
							createdAt.HasValue ? new DateTimeOffset(createdAt.Value).ToUnixTimeSeconds() : (long?)null,
						createdAt =>
							createdAt.HasValue ? DateTimeOffset.FromUnixTimeSeconds(createdAt.Value).UtcDateTime : null);
			});

			modelBuilder.Entity<Population>(entity =>
			{
				entity.ToTable("Populations");
				entity.HasKey(population => population.Id);

				entity.Property(population => population.CreatedAt)
					.HasColumnName("Created at")
					.HasColumnType("INTEGER")
					.HasConversion(
						createdAt =>
							createdAt.HasValue ? new DateTimeOffset(createdAt.Value).ToUnixTimeSeconds() : (long?)null,
						createdAt =>
							createdAt.HasValue ? DateTimeOffset.FromUnixTimeSeconds(createdAt.Value).UtcDateTime : null);

				entity.HasMany(population => population.PopulationRecords)
					.WithOne()
					.HasForeignKey(populationRecord => populationRecord.PopulationId)
					.OnDelete(DeleteBehavior.Cascade);
			});
		}
	}
}

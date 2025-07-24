using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Infrastructure.Repositories
{
	public class PopulationRecordRepository(AppDbContext appDbContext) : IPopulationRecordRepository
	{
		public async Task AddPopulationAsync(PopulationRecord populationRecord,
			CancellationToken cancellationToken = default)
		{
			appDbContext.PopulationRecords.Add(populationRecord);

			await appDbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task<List<PopulationRecord>> GetAllPopulationRecordsAsync(
			CancellationToken cancellationToken = default)

		{
			return await appDbContext.PopulationRecords.ToListAsync(cancellationToken);
		}
	}
}

using ApplicationApi.Infrastructure.Database;

namespace ApplicationApi.Infrastructure.Repositories
{
	public class PopulationRecordRepository(AppDbContext appDbContext) : IPopulationRecordRepository
	{
		public async Task AddPopulationAsync(PopulationRecord populationRecord,
			CancellationToken cancellationToken = default)
		{
			appDbContext.PopulationRecords.Add(populationRecord);
			await appDbContext.SaveChangesAsync(cancellationToken);
		}
	}
}

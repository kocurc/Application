using ApplicationApi.Infrastructure.Database;

namespace ApplicationApi.Infrastructure.Repositories
{
	public class PopulationRecordRepository : IPopulationRecordRepository
	{
		private readonly AppDbContext _appDbContext;

		public PopulationRecordRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task AddPopulationAsync(PopulationRecord populationRecord,
			CancellationToken cancellationToken = default)
		{
			_appDbContext.PopulationRecords.Add(populationRecord);
			await _appDbContext.SaveChangesAsync(cancellationToken);
		}
	}
}

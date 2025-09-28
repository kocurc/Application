using Domain.Entities;

namespace Application.Interfaces
{
	public interface IPopulationRecordRepository
	{
		Task AddPopulationAsync(PopulationRecord populationRecord, CancellationToken cancellationToken = default);
		Task<List<PopulationRecord>> GetAllPopulationRecordsAsync(CancellationToken cancellationToken = default);
	}
}

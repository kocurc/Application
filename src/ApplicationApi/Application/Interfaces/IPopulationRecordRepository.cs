namespace ApplicationApi.Application.Interfaces
{
	public interface IPopulationRecordRepository
	{
		Task AddPopulationAsync(PopulationRecord populationRecord, CancellationToken cancellationToken = default);
	}
}

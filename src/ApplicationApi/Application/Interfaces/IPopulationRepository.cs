namespace ApplicationApi.Application.Interfaces
{
	public interface IPopulationRepository
	{
		Task SavePopulationRecordAsync(PopulationRecord populationRecord,
			CancellationToken cancellationToken = default);
	}
}

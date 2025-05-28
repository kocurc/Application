using ApplicationApi.Application.DTOs.InputDTOs;
using ApplicationApi.Domain.Entities;

namespace ApplicationApi.Application.UseCases
{
	public interface IRunPopulationSimulation
	{
		Task<List<PopulationRecord>> ExecuteAsync(SimulationRequest simulationRequest,
			CancellationToken cancellationToken = default);
	}
}

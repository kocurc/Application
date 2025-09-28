using Application.DTOs.InputDTOs;
using Domain.Entities;

namespace Application.UseCases
{
	public interface IRunPopulationSimulation
	{
		Task<List<PopulationRecord>> ExecuteAsync(SimulationRequest simulationRequest,
			CancellationToken cancellationToken = default);
	}
}

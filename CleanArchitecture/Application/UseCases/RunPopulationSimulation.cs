using Application.DTOs.InputDTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Services;
using FluentValidation;

namespace Application.UseCases
{
	public class RunPopulationSimulation(
		IPopulationRecordRepository populationRecordRepository,
		IPopulationSimulationService populationSimulationService,
		IValidator<SimulationRequest> simulationRequestValidator) : IRunPopulationSimulation
	{
		public async Task<List<PopulationRecord>> ExecuteAsync(SimulationRequest simulationRequest,
			CancellationToken cancellationToken = default)

		{
			ArgumentNullException.ThrowIfNull(simulationRequest);

			var simulationRequestValidationResult =
				simulationRequestValidator.ValidateAsync(simulationRequest, cancellationToken);

			if (!simulationRequestValidationResult.IsCompletedSuccessfully)
			{
				throw new ValidationException(simulationRequestValidationResult.Result.Errors);
			}

			var results = new List<PopulationRecord>();
			var currentPopulation = simulationRequest.InitialPopulation;
			var simulationYears = simulationRequest.Years;

			for (var simulationYear = 0; simulationYear < simulationYears; simulationYear++)
			{
				cancellationToken.ThrowIfCancellationRequested();

				var populationRecord = populationSimulationService.CalculateNextYear(
					year: simulationYear,
					initialPopulation: currentPopulation,
					seasonalAmplitude: simulationRequest.Amplitude,
					baseGrowthRate: simulationRequest.BaseGrowthRate,
					environmentCapacity: simulationRequest.Capacity,
					migrationPerYear: simulationRequest.Migration,
					seasonalLength: simulationRequest.Seasonality,
					disasterChance: simulationRequest.DisasterChance,
					disasterMinLoss: simulationRequest.DisasterMinLoss,
					disasterMaxLoss: simulationRequest.DisasterMaxLoss
				);

				currentPopulation = populationRecord.Population;

				await populationRecordRepository.AddPopulationAsync(populationRecord, cancellationToken);
				results.Add(populationRecord);
			}

			return results;
		}
	}
}
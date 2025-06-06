using ApplicationApi.Application.Enums;
using ApplicationApi.Domain.Entities;

namespace ApplicationApi.Application.ServicesInterfaces
{
	public interface IPopulationSimulationService
	{
		PopulationRecord CalculateNextYear(
			int year,
			int initialPopulation,
			double seasonalAmplitude,
			double baseGrowthRate,
			int environmentCapacity,
			int migrationPerYear,
			Seasonality seasonalLength,
			double disasterChance,
			int disasterMinLoss,
			int disasterMaxLoss
		);
	}
}

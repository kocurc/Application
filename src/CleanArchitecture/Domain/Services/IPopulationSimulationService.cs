using Domain.Entities;
using Domain.Enums;

namespace Domain.Services
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

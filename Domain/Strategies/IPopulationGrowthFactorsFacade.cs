using Domain.Enums;

namespace Domain.Strategies
{
	public interface IPopulationGrowthFactorsFacade
	{
		int ApplyAll(int year, int initialPopulation, double seasonalAmplitude, double baseGrowthRate,
			int environmentCapacity, int migrationPerYear, Seasonality seasonalLength, double disasterChance,
			int disasterMinLoss, int disasterMaxLoss);
	}
}

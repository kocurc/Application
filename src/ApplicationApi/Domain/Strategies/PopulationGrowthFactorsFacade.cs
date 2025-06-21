namespace ApplicationApi.Domain.Strategies
{
	public class PopulationGrowthFactorsFacade(IDisasterStrategy disasterStrategy, IMigrationStrategy migrationStrategy)
		: IPopulationGrowthFactorsFacade
	{
		public int ApplyAll(int year, int initialPopulation, double seasonalAmplitude, double baseGrowthRate,
			int environmentCapacity, int migrationPerYear, Seasonality seasonalLength, double disasterChance,
			int disasterMinLoss, int disasterMaxLoss)
		{
			var seasonalGrowthRate =
				CalculateSeasonalGrowthRate(year, seasonalLength, baseGrowthRate, seasonalAmplitude);
			var logisticGrowthRate =
				CalculateLogisticGrowthRate(seasonalGrowthRate, environmentCapacity, initialPopulation, year);
			var populationAfterMigration =
				migrationStrategy.ApplyMigration(logisticGrowthRate, migrationPerYear, environmentCapacity);
			var endYearPopulation =
				disasterStrategy.ApplyDisaster(populationAfterMigration, disasterMinLoss, disasterMaxLoss,
					disasterChance);

			return endYearPopulation;
		}

		private static double CalculateSeasonalGrowthRate(int year,
			Seasonality seasonalLength,
			double baseGrowthRate,
			double seasonalAmplitude)
		{
			var sinusValue = Math.Sin(2 * Math.PI * year / (int)seasonalLength);

			return baseGrowthRate * (1 + (seasonalAmplitude * sinusValue));
		}

		private static int CalculateLogisticGrowthRate(double seasonalGrowthRate,
			int environmentCapacity,
			int initialPopulation,
			int year)
		{
			var relativeValue = (environmentCapacity - initialPopulation) / (double)initialPopulation;
			var eulerFactor = Math.Pow(Math.E, seasonalGrowthRate * year);

			return (int)(environmentCapacity / (1 + (relativeValue * eulerFactor)));
		}
	}
}

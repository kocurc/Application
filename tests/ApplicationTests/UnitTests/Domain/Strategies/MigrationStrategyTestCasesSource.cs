namespace ApplicationTests.UnitTests.Domain.Strategies
{
	public class MigrationStrategyTestCasesSource
	{
		public static IEnumerable<IMigrationStrategy> GetAllStrategies()
		{
			yield return new BasicMigrationStrategy();
		}
	}
}

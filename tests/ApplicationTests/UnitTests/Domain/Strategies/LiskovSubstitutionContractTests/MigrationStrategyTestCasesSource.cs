namespace ApplicationTests.UnitTests.Domain.Strategies.LiskovSubstitutionContractTests
{
	public class MigrationStrategyTestCasesSource
	{
		public static IEnumerable<IMigrationStrategy> GetAllStrategies()
		{
			yield return new BasicMigrationStrategy();
		}
	}
}

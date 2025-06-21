namespace ApplicationTests.UnitTests.Domain.Strategies
{
	[TestFixture]
	public class MigrationStrategyContractLspTests
	{

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void ApplyMigration_ShouldThrowInvalidMigrationException_WhenMigrationIsGreaterThan100k(
			IMigrationStrategy migrationStrategy)
		{

		}

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void
			ApplyMigration_ShouldThrowInvalidMigrationException_WhenResultSumIsGreaterThanEnvironmentCapacity(
				IMigrationStrategy migrationStrategy)
		{

		}

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void ApplyMigration_ShouldThrowInvalidMigrationException_WhenResultSumIsNegative(
			IMigrationStrategy migrationStrategy)
		{

		}

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void ApplyMigration_ReturnsDeterministicResultForSameInput(IMigrationStrategy migrationStrategy)
		{

		}
	}
}

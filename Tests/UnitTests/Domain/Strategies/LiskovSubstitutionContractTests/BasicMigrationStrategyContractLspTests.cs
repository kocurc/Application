namespace Tests.UnitTests.Domain.Strategies.LiskovSubstitutionContractTests
{
	[TestFixture]
	public class BasicMigrationStrategyContractLspTests
	{
		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void ApplyMigration_ShouldThrowInvalidMigrationException_WhenMigrationIsGreaterThan100k(
			IMigrationStrategy migrationStrategy)
		{
			// Arrange
			// Act
			var act = () => migrationStrategy.ApplyMigration(100_000, 100_001, 300_000);

			// Assert
			act.Should().Throw<InvalidMigrationException>();
		}

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void
			ApplyMigration_ShouldThrowInvalidMigrationException_WhenResultSumIsGreaterThanEnvironmentCapacity(
				IMigrationStrategy migrationStrategy)
		{
			// Arrange
			// Act
			var act = () => migrationStrategy.ApplyMigration(100_000, 50_000, 140_000);

			// Assert
			act.Should().Throw<InvalidMigrationException>();
		}

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void ApplyMigration_ShouldThrowInvalidMigrationException_WhenResultSumIsNegative(
			IMigrationStrategy migrationStrategy)
		{
			// Arrange
			// Act
			var act = () => migrationStrategy.ApplyMigration(100_000, -110_000, 200_000);

			// Assert
			act.Should().Throw<InvalidMigrationException>();
		}

		[Theory]
		[TestCaseSource(typeof(MigrationStrategyTestCasesSource),
			nameof(MigrationStrategyTestCasesSource.GetAllStrategies))]
		public void ApplyMigration_ReturnsDeterministicResultForSameInput(IMigrationStrategy migrationStrategy)
		{
			// Arrange
			// Act
			var population = migrationStrategy.ApplyMigration(100_000, 10_000, 200_000);

			// Assert
			population.Should().Be(110_000);
		}
	}
}

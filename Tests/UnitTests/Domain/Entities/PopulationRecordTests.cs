namespace Tests.UnitTests.Domain.Entities
{
	[TestFixture]
	public class PopulationRecordTests
	{
		[TestCase(-1, 1)]
		[TestCase(0, -1)]
		// Method name: GivenWhat_WhenAction_ThenResult
		public void Constructor_ShouldThrowInvalidPopulationException_WhenParameterIsBelowZero(int year, int population)
		{
			// Arrange
			// Act
			var act = () => new PopulationRecord(year, population);

			// Assert
			act.Should().ThrowExactly<InvalidPopulationException>();
		}

		[TestCase]
		public void UpdatePopulation_ShouldThrowInvalidPopulationException_WhenParameterIsBelowZero()
		{
			// Arrange
			var populationRecord = new PopulationRecord(0, 0);

			// Act
			var act = () => populationRecord.UpdatePopulation(-1);

			// Assert
			act.Should().ThrowExactly<InvalidPopulationException>();
		}

		[TestCase]
		public void UpdatePopulation_ShouldUpdatePopulationValue_WhenArgumentIsValid()
		{
			// Arrange
			const int newPopulationValue = 100;

			var populationRecord = new PopulationRecord(0, 0);

			// Act
			populationRecord.UpdatePopulation(newPopulationValue);

			// Assert
			populationRecord.PopulationSize.Should().Be(newPopulationValue);
		}
	}
}

using Domain.Services;

namespace Tests.UnitTests.Application.UseCases
{
	[TestFixture]
	public class RunPopulationSimulationTests
	{
		private readonly IPopulationRecordRepository _populationRecordRepository = Substitute.For<IPopulationRecordRepository>();
		private readonly IPopulationSimulationService _populationSimulationService =
			Substitute.For<IPopulationSimulationService>();
		private readonly IValidator<SimulationRequest> _simulationRequestValidator =
			Substitute.For<IValidator<SimulationRequest>>();

		[Test]
		public void ExecuteAsync_ThrowsArgumentNullException_WhenSimulationRequestIsNull()
		{
			// Arrange
			var populationSimulationUseCase = new RunPopulationSimulation(_populationRecordRepository,
				_populationSimulationService, _simulationRequestValidator);

			// Act
			var act = async () => await populationSimulationUseCase.ExecuteAsync(null!);

			// Assert
			act.Should().ThrowAsync<ArgumentNullException>();
		}
	}
}

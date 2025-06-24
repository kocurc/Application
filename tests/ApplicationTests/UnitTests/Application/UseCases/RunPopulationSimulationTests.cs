namespace ApplicationTests.UnitTests.Application.UseCases
{
	[TestFixture]
	public class RunPopulationSimulationTests
	{
		private readonly IPopulationRepository _populationRepository = Substitute.For<IPopulationRepository>();
		private readonly IPopulationSimulationService _populationSimulationService =
			Substitute.For<IPopulationSimulationService>();
		private readonly IValidator<SimulationRequest> _simulationRequestValidator =
			Substitute.For<IValidator<SimulationRequest>>();

		[Test]
		public void ExecuteAsync_ThrowsArgumentNullException_WhenSimulationRequestIsNull()
		{
			// Arrange
			var populationSimulationUseCase = new RunPopulationSimulation(_populationRepository,
				_populationSimulationService, _simulationRequestValidator);

			// Act
			var act = async () => await populationSimulationUseCase.ExecuteAsync(null!);

			// Assert
			act.Should().ThrowAsync<ArgumentNullException>();
		}
	}
}

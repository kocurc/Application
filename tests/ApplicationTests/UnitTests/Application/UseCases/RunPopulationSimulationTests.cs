using ApplicationApi.Application.DTOs.InputDTOs;
using ApplicationApi.Application.Interfaces;
using ApplicationApi.Application.ServicesInterfaces;
using ApplicationApi.Application.UseCases;
using FluentAssertions;
using FluentValidation;
using NSubstitute;

// Validate platform compatibility
#pragma warning disable CA1416

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
			// Act
			var populationSimulationUseCase = new RunPopulationSimulation(_populationRepository,
				_populationSimulationService, _simulationRequestValidator);

			// Arrange
			var act = async () => await populationSimulationUseCase.ExecuteAsync(null!);

			// Assert
			act.Should().ThrowAsync<ArgumentNullException>();
		}
	}
}

using FluentValidation.TestHelper;

namespace Tests.UnitTests.Application.Validation.SimulationRequestValidatorTests;

public class BaseGrowthRatePropertyRequestValidatorTests
{
	private readonly SimulationRequestValidator _simulationRequestValidator = new();

	// Given_Then_When
	[Test(Description = "SimulationRequestValidator_GeneratesError_WhenBaseGrowthRateValueIsBelowMinThreshold")]
	// Arrange Act Assert
	public void SimulationRequestValidator_GeneratesError_WhenBaseGrowthRateValueIsBelowMinThreshold()
	{
		// Arrange
		var simulationRequestModel = new SimulationRequestBuilder()
			.WithYears(1).WithInitialPopulation(2).WithAmplitude(0.02)
			.WithCapacity(20).WithSeasonality(Seasonality.Yearly)
			.WithDisasterChance(0.01).WithDisasterMinLoss(0).WithDisasterMaxLoss(5).WithBaseGrowthRate(0.00).Build();

		// Act
		var validationResult = _simulationRequestValidator.TestValidate(simulationRequestModel);

		// Assert
		validationResult.ShouldHaveValidationErrorFor("BaseGrowthRate")
			.WithErrorMessage("Base growth rate should be between 0.01 and 1.00.");
	}
}

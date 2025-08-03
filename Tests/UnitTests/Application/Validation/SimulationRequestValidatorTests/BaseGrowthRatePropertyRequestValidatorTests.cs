using FluentValidation.TestHelper;

namespace Tests.UnitTests.Application.Validation.SimulationRequestValidatorTests;

public class BaseGrowthRatePropertyRequestValidatorTests
{
	private readonly SimulationRequestValidator _simulationRequestValidator = new();

	[Test]
	public void SimulationRequestValidator_GeneratesError_WhenBaseGrowthRateValueIsBelowMinThreshold()
	{
		// Arrange
		var simulationRequestModel = new SimulationRequest(
			year: 0,
			years: 1,
			initialPopulation: 2,
			amplitude: 0.02,
			capacity: 20,
			migration: 0,
			seasonality: Seasonality.Yearly,
			disasterChance: 0.01,
			disasterMinLoss: 0,
			disasterMaxLoss: 5,
			baseGrowthRate: 0.00
		);

		// Act
		var validationResult = _simulationRequestValidator.TestValidate(simulationRequestModel);

		// Assert
		validationResult.ShouldHaveValidationErrorFor("BaseGrowthRate")
			.WithErrorMessage("Base growth rate should be between 0.01 and 1.00.");
	}
}

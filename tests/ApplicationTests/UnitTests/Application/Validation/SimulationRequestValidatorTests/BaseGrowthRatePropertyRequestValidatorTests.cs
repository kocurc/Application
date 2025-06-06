using ApplicationApi.Application.DTOs.InputDTOs;
using ApplicationApi.Application.Enums;
using ApplicationApi.Application.Validation;
using FluentValidation.TestHelper;

// Validate platform compatibility
#pragma warning disable CA1416

namespace ApplicationTests.UnitTests.Application.Validation.SimulationRequestValidatorTests;

public class BaseGrowthRatePropertyRequestValidatorTests
{
	private readonly SimulationRequestValidator _simulationRequestValidator = new();

	[Test]
	public void SimulationRequestValidator_GeneratesError_WhenBaseGrowthRateValueIsBelowMinThreshold()
	{
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

		var validationResult = _simulationRequestValidator.TestValidate(simulationRequestModel);

		validationResult.ShouldHaveValidationErrorFor("BaseGrowthRate")
			.WithErrorMessage("Base growth rate should be between 0.01 and 1.00.");
	}
}
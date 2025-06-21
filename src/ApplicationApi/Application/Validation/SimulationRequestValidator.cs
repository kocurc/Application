namespace ApplicationApi.Application.Validation
{
	public class SimulationRequestValidator : AbstractValidator<SimulationRequest>
	{
		public SimulationRequestValidator()
		{
			// Base growth rate
			_ = RuleFor(simulationRequest => simulationRequest.BaseGrowthRate).InclusiveBetween(0.01, 1.00)
				.WithMessage("Base growth rate should be between 0.01 and 1.00.");

			// Amplitude
			_ = RuleFor(simulationRequest => simulationRequest.Amplitude).InclusiveBetween(0.00, 1.00)
				.WithMessage("Amplitude should be between 0.00 and 1.00.");

			// Seasonality
			_ = RuleFor(simulationRequest => simulationRequest.Seasonality)
				.Must(seasonality => seasonality is Seasonality.Monthly or Seasonality.Yearly)
				.WithMessage("Seasonality should be enumeration value: Yearly or Monthly.");

			// Simulation year
			_ = RuleFor(simulationRequest => simulationRequest.Year).GreaterThanOrEqualTo(0)
				.WithMessage("Year simulation value should be greater than or equal to 0.");

			// Initial population
			_ = RuleFor(simulationRequest => simulationRequest.InitialPopulation).GreaterThan(0)
				.WithMessage("Initial population must be greater than 0.");

			// Environment capacity
			_ = RuleFor(simulationRequest => simulationRequest.Capacity).Must((simulationRequest, _) =>
			{
				return simulationRequest.Capacity > simulationRequest.InitialPopulation;
			});

			_ = RuleFor(x => x.Capacity).Must((simulationRequest, _) =>
			{
				// Avoid validation of Environment capacity when Initial population is incorrect
				// Convert to conditional expression
#pragma warning disable IDE0046
				if (simulationRequest.InitialPopulation <= 0)
				{
					return true;
				}

				return simulationRequest.Capacity >= Math.Ceiling(1.5 * simulationRequest.InitialPopulation) &&
				       simulationRequest.Capacity <= 10 * simulationRequest.InitialPopulation;
			}).WithMessage("Environment capacity value should be between 1.5x - 10x of Initial population value");

			// Migration
			_ = RuleFor(simulationRequest => simulationRequest.Migration).LessThanOrEqualTo(100_000)
				.WithMessage("Migration should be less than or equal 100 000.");

			// Disaster min loss
			_ = RuleFor(simulationRequest => simulationRequest.DisasterMinLoss).GreaterThanOrEqualTo(0)
				.WithMessage("Minimal disaster loss should be greater or equal to 0.");

			// Disaster max loss
			_ = RuleFor(simulationRequest => simulationRequest.DisasterMaxLoss).Must((simulationRequest, _) =>
			{
				return simulationRequest.DisasterMinLoss >= simulationRequest.DisasterMaxLoss;
			}).WithMessage("Maximal disaster loss should be greater than or equal to minimal disaster loss.");

			// Other dependencies
			_ = RuleFor(simulationRequest => simulationRequest.Seasonality).Must(seasonality =>
					seasonality == Seasonality.Monthly)
				.When(x => x.Amplitude > 0)
				.WithMessage("When Amplitude is greater than zero, then Seasonality must be Monthly.");
		}
	}
}

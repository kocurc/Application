using ApplicationApi.Application.DTOs.InputDTOs;
using FluentValidation;

namespace ApplicationApi.Application.Validation
{
	public class SimulationRequestValidator : AbstractValidator<SimulationRequest>
	{
		public SimulationRequestValidator()
		{
			RuleFor(x => x.BaseGrowthRate).InclusiveBetween(0.01, 1.00)
				.WithMessage("Base growth rate should be between 0.01 and 1.00.");
		}
	}
}

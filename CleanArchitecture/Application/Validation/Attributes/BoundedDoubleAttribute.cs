using System.ComponentModel.DataAnnotations;

namespace Application.Validation.Attributes
{
	public sealed class BoundedDoubleAttribute : ValidationAttribute
	{
		public double Minimum { get; }
		public double Maximum { get; }

		public BoundedDoubleAttribute(double minimum, double maximum)
		{
			if (minimum > maximum)
			{
				throw new ArgumentException("Minimum cannot be greater than Maximum");
			}

			Minimum = minimum;
			Maximum = maximum;
			ErrorMessage = $"Value should be between {Minimum:#.00} and {Maximum:#.00}";
		}

		public bool IsValid(double? value)
		{
			if (value is { } doubleValue)
			{
				return doubleValue >= Minimum && doubleValue <= Maximum;

			}

			return false;
		}

		// Method used automatically by DataAnnotationsValidator in Blazor
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			return IsValid(value as double?)
				? ValidationResult.Success
				: new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
		}
	}
}

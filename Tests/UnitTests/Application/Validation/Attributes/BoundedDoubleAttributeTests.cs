using Application.Validation.Attributes;

namespace Tests.UnitTests.Application.Validation.Attributes
{
	public class BoundedDoubleAttributeTests
	{
		private BoundedDoubleAttribute? _boundedDoubleAttribute;

		// Given_Then_When
		[Test(Description = "BoundedDoubleAttribute_ThrowsArgumentException_WhenMinimumIsGreaterThanMaximum")]
		// Arrange Act Assert
		public void BoundedDoubleAttribute_ThrowsArgumentException_WhenMinimumIsGreaterThanMaximum()
		{
			// Arrange
			const double minimum = 1.0;
			const double maximum = 0.9;

			// Act
			var act = () =>
			{
				_boundedDoubleAttribute = new BoundedDoubleAttribute(minimum, maximum);
			};

			// Assert
			act.Should().ThrowExactly<ArgumentException>();
		}

		// Given_Then_When
		[Test(Description = "IsValid_ReturnsTrue_WhenValueIsInTheRange")]
		// Arrange Act Assert
		public void IsValid_ReturnsTrue_WhenValueIsInRange()
		{
			// Arrange
			const double minimum = 0.90;
			const double maximum = 0.99;
			const double boundedValue = 0.95;

			_boundedDoubleAttribute = new BoundedDoubleAttribute(minimum, maximum);

			// Act & Assert
			_boundedDoubleAttribute.IsValid(boundedValue).Should().BeTrue();
		}

		// Given_Then_When
		[Test(Description = "IsValid_ReturnsFalse_WhenValueIsBelowTheRange")]
		// Arrange Act Assert
		public void IsValid_ReturnsFalse_WhenValueIsOutOfRange()
		{
			// Arrange
			const double minimum = 0.9;
			const double maximum = 0.99;
			const double boundedValue = 0.89;

			_boundedDoubleAttribute = new BoundedDoubleAttribute(minimum, maximum);

			// Act & Assert
			_boundedDoubleAttribute.IsValid(boundedValue).Should().BeFalse();
		}

		// Given_Then_When
		[Test(Description = "IsValid_ReturnsFalse_WhenValueIsNull")]
		// Arrange Act Assert
		public void IsValid_ReturnsFalse_WhenValueIsNull()
		{
			// Arrange
			const double minimum = 0.9;
			const double maximum = 0.99;
			double? boundedValue = null;

			_boundedDoubleAttribute = new BoundedDoubleAttribute(minimum, maximum);

			// Act & Assert
			_boundedDoubleAttribute.IsValid(boundedValue).Should().BeFalse();
		}
	}
}

namespace Domain.Enums
{
	/// <summary>
	/// Represents the time-based seasonality that is used in calculations.
	/// </summary>
	public enum Seasonality
	{
		/// <summary>
		/// One period per year seasonality
		/// </summary>
		Yearly = 1,

		/// <summary>
		/// Twelve periods per year seasonality
		/// </summary>
		Monthly = 12,
	}
}

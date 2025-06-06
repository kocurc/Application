namespace ApplicationApi.Domain.Enums
{
	/// <summary>
	/// Represents time-based seasonality used in calculations.
	/// </summary>
	public enum Seasonality
	{
		/// <summary>
		/// One period per year.
		/// </summary>
		Yearly = 1,

		/// <summary>
		/// Twelve periods per year.
		/// </summary>
		Monthly = 12,
	}
}

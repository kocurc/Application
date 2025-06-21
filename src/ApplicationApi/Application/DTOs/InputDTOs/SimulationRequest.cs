namespace ApplicationApi.Application.DTOs.InputDTOs
{
    public class SimulationRequest(
	    int year,
	    int years,
	    int initialPopulation,
	    double amplitude,
	    int capacity,
	    int migration,
	    Seasonality seasonality,
	    double disasterChance,
	    int disasterMinLoss,
	    int disasterMaxLoss,
	    double baseGrowthRate)
    {
	    /// <summary>
        /// A simulation start year.
        /// </summary>
        /// <value>
        /// 0 means a first year of a simulation.
        /// </value>
        public int Year { get; init; } = year;

        /// <summary>
        /// A number of simulation years.
        /// </summary>
        public int Years { get; init; } = years;

        /// <summary>
        /// An initial population.
        /// </summary>
        /// <remarks>
        /// A population start point for a first year of a simulation.
        /// </remarks>
        /// <value>
        /// Value must be greater than 0.
        /// </value>
        public int InitialPopulation { get; init; } = initialPopulation;

        /// <summary>
        /// A seasonal amplitude.
        /// </summary>
        /// <remarks>
        /// It describes how much a growth rate depends on a season. 0.3 means 30% of variability.
        /// </remarks>
        /// <value>
        /// It takes values from a range: 0.00 - 1.00.
        /// </value>
        public double Amplitude { get; init; } = amplitude;

        /// <summary>
        /// Environment capacity.
        /// </summary>
        /// <remarks>
        ///	A maximum number of individuals that environment can handle.
        /// </remarks>
        /// <value>
        /// Value should greater than initial population.
        /// </value>
        public int Capacity { get; init; } = capacity;

        /// <summary>
        /// A migration per year.
        /// </summary>
        /// <value>
        ///	A maximum migration should less or equal to 100 000.
        /// <para>
        /// A minimum migration should greater or equal to a negative value of the InitialPopulation Growth result.
        /// </para>
        /// </value>
        public int Migration { get; init; } = migration;

        /// <summary>
        /// A season length.
        /// </summary>
        /// <value>
        ///	12 (default) means a monthly seasonality.
        /// <para>
        /// 1 means an annual seasonality
        /// </para>
        /// </value>
        public Seasonality Seasonality { get; init; } = seasonality;

        /// <summary>
        /// A disaster percentage chance.
        /// </summary>
        /// <remarks>
        /// 0.3 means a 30% chance for a disaster.
        /// </remarks>
        /// <value>
        /// It takes values from a range: 0.00 - 1.00.
        /// </value>
        public double DisasterChance { get; init; } = disasterChance;

        /// <summary>
        ///	A minimal number of disaster casualties.
        /// </summary>
        /// <value>
        ///	A minimal value should greater or equal to 0 and less than a maximum value.
        /// </value>
        public int DisasterMinLoss { get; init; } = disasterMinLoss;

        /// <summary>
        /// A maximum number of catastrophe casualties.
        /// </summary>
        /// <value>
        ///	A maximum value should be greater or equal to a minimum value and less than or equal to
        /// InitialPopulation Growth result after Migration.
        /// </value>
        public int DisasterMaxLoss { get; init; } = disasterMaxLoss;

        /// <summary>
        /// A base growth rate.
        /// </summary>
        /// <value>
        /// It takes values from a range: 0.00 - 1.00.
        /// </value>
        public double BaseGrowthRate { get; init; } = baseGrowthRate;
    }
}

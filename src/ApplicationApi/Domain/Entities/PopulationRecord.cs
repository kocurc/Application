using System.Diagnostics.CodeAnalysis;
using ApplicationApi.Domain.Exceptions;

namespace ApplicationApi.Domain.Entities
{
    /*
	 * Reprezentują rzeczy w systemie, które mają unikalną tożsamość (np. użytkownik, zamówienie, rekord populacji)
	 */
    public class PopulationRecord
    {

        public int Id { get; private set; }
        public int Year { get; private set; }
        public int Population { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public PopulationRecord(int year, int population)
        {
            if (year < 0)
            {
                throw new InvalidPopulationException("Year cannot be less than zero.");
            }

            if (population < 0)
            {
                throw new InvalidPopulationException("Population cannot be less than zero.");
            }

            Year = year;
            Population = population;
        }

        [ExcludeFromCodeCoverage]
        // Dla Entity Framework Core

        protected PopulationRecord()
        { }

        public void UpdatePopulation(int newPopulation)
        {
            if (newPopulation < 0)
            {
                throw new InvalidPopulationException("New population cannot be less than zero.");
            }

            Population = newPopulation;
        }
    }
}

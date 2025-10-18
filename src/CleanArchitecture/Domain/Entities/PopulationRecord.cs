using System.Diagnostics.CodeAnalysis;
using Domain.Exceptions;

namespace Domain.Entities
{
    // Entities are objects reflecting a small scope of business rules + business data.
    public class PopulationRecord
    {
		public Guid Id { get; private set; }
        public int Year { get; private set; }
        public int PopulationSize { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public Guid PopulationId { get; set; }

		public PopulationRecord(int year, int populationSize, DateTime? createdAt = null)
        {
            if (year < 0)
            {
                throw new InvalidPopulationException("Year cannot be less than zero.");
            }

            if (populationSize < 0)
            {
                throw new InvalidPopulationException("InitialPopulation cannot be less than zero.");
            }

            Id = Guid.NewGuid();
            Year = year;
            PopulationSize = populationSize;

			if (createdAt.HasValue)
            {
	            CreatedAt = createdAt;
            }
		}

		public void UpdatePopulation(int newPopulation)
        {
            if (newPopulation < 0)
            {
                throw new InvalidPopulationException("New population cannot be less than zero.");
            }

            PopulationSize = newPopulation;
        }
    }
}

namespace ApplicationApi.Domain.Entities
{
    // Entities are objects reflecting a small scope of business rules + business data.
    public class PopulationRecord
    {

        public Guid Id { get; private set; }
        public int Year { get; private set; }
        public int Population { get; private set; }
        public DateTime CreatedAt { get; private set; }

		public PopulationRecord(int year, int population)
        {
            if (year < 0)
            {
                throw new InvalidPopulationException("Year cannot be less than zero.");
            }

            if (population < 0)
            {
                throw new InvalidPopulationException("InitialPopulation cannot be less than zero.");
            }

            Id = Guid.NewGuid();
            Year = year;
            Population = population;
            CreatedAt = DateTime.UtcNow;
        }

        [ExcludeFromCodeCoverage] // Dla Entity Framework Core
		protected PopulationRecord() { }

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

namespace ApplicationApi.Domain.Strategies
{
    public class BasicMigrationStrategy : IMigrationStrategy
    {
	    public int ApplyMigration(int population, int migrationPerYear, int environmentCapacity)
	    {
		    var sum = population + migrationPerYear;

		    if (migrationPerYear > 100_000)
		    {
			    throw new InvalidMigrationException("The migration cannot be greater than 100k.");
		    }

		    if (sum > environmentCapacity)
		    {
			    throw new InvalidMigrationException(
				    "The sum of the migration and the population cannot be greater the environment capacity.");
		    }

#pragma warning disable IDE0046 // Convert to conditional expression
			if (sum < 0)
		    {
			    throw new InvalidMigrationException("The migration cannot be greater than the population.");
		    }

			return population + migrationPerYear;
		}
    }
}

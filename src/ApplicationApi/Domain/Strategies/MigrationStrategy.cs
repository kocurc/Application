namespace ApplicationApi.Domain.Strategies
{
    public class BasicMigrationStrategy : IMigrationStrategy
    {
	    public int ApplyMigration(int population, int migrationPerYear)
	    {
			return population + migrationPerYear;
		}
    }
}

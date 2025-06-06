namespace ApplicationApi.Domain.Strategies
{
	public interface IMigrationStrategy
	{
		int ApplyMigration(int population, int migrationPerYear);
	}
}
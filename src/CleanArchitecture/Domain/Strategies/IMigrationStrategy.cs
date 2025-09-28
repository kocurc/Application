namespace Domain.Strategies
{
	public interface IMigrationStrategy
	{
		int ApplyMigration(int population, int migrationPerYear, int environmentCapacity);
	}
}

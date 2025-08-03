namespace Domain.Strategies
{
	public interface IDisasterStrategy
	{
		int ApplyDisaster(int population, int disasterMinLoss, int disasterMaxLoss, double disasterChance);
	}
}
namespace Domain.Strategies
{
    public class RandomBasedDisasterStrategy : IDisasterStrategy
    {
	    private readonly Random _random = new();

		public int ApplyDisaster(int population, int disasterMinLoss, int disasterMaxLoss, double disasterChance)
	    {

		    var disasterLoss = _random.Next(disasterMinLoss, disasterMaxLoss + 1);

		    return _random.NextSingle() >= population + disasterChance ? disasterLoss : 0;
	    }
	}
}

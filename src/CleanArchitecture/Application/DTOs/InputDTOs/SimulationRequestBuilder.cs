using Domain.Enums;

namespace Application.DTOs.InputDTOs
{
	public class SimulationRequestBuilder
	{
		private readonly SimulationRequest _simulationRequest = new();

		public SimulationRequestBuilder WithYear(int year)
		{
			_simulationRequest.Year = year;

			return this;
		}

		public SimulationRequestBuilder WithYears(int years)
		{
			_simulationRequest.Years = years;

			return this;
		}

		public SimulationRequestBuilder WithInitialPopulation(int initialPopulation)
		{
			_simulationRequest.InitialPopulation = initialPopulation;

			return this;
		}

		public SimulationRequestBuilder WithAmplitude(double amplitude)
		{
			_simulationRequest.Amplitude = amplitude;

			return this;
		}

		public SimulationRequestBuilder WithCapacity(int capacity)
		{
			_simulationRequest.Capacity = capacity;

			return this;
		}

		public SimulationRequestBuilder WithMigration(int migration)
		{
			_simulationRequest.Migration = migration;

			return this;
		}

		public SimulationRequestBuilder WithSeasonality(Seasonality seasonality)
		{
			_simulationRequest.Seasonality = seasonality;

			return this;
		}

		public SimulationRequestBuilder WithDisasterChance(double disasterChance)
		{
			_simulationRequest.DisasterChance = disasterChance;

			return this;
		}

		public SimulationRequestBuilder WithDisasterMinLoss(int disasterMinLoss)
		{
			_simulationRequest.DisasterMinLoss = disasterMinLoss;

			return this;
		}

		public SimulationRequestBuilder WithDisasterMaxLoss(int disasterMaxLoss)
		{
			_simulationRequest.DisasterMaxLoss = disasterMaxLoss;

			return this;
		}

		public SimulationRequestBuilder WithBaseGrowthRate(double baseGrowthRate)
		{
			_simulationRequest.BaseGrowthRate = baseGrowthRate;

			return this;
		}

		public SimulationRequest Build()
		{
			return _simulationRequest;
		}
	}
}

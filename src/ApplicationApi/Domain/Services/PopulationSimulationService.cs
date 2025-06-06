using ApplicationApi.Application.ServicesInterfaces;
using ApplicationApi.Domain.Entities;
using ApplicationApi.Domain.Enums;
using ApplicationApi.Domain.Strategies;

namespace ApplicationApi.Domain.Services
{
    public class PopulationSimulationService(IPopulationGrowthFactorsFacade populationGrowthFactorsFacade)
	    : IPopulationSimulationService
    {
	    public PopulationRecord CalculateNextYear(int year, int initialPopulation, double seasonalAmplitude,
		    double baseGrowthRate, int environmentCapacity, int migrationPerYear, Seasonality seasonalLength,
		    double disasterChance, int disasterMinLoss, int disasterMaxLoss)
	    {
		    var endYearPopulation =
			    populationGrowthFactorsFacade.ApplyAll(year, initialPopulation, seasonalAmplitude, baseGrowthRate,
			    environmentCapacity, migrationPerYear, seasonalLength, disasterChance, disasterMinLoss,
			    disasterMaxLoss);

			return new PopulationRecord(year, endYearPopulation);
		}
    }
}

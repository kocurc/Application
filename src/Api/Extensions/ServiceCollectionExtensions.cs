using Infrastructure.Infrastructure.Repositories;

namespace Api.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddSingletonServices(this IServiceCollection serviceCollection)
		{
			// Add singleton services (one stateless instance for all HTTP requests)
			_ = serviceCollection.AddSingleton<IMigrationStrategy, BasicMigrationStrategy>();
			_ = serviceCollection.AddSingleton<IDisasterStrategy, RandomBasedDisasterStrategy>();
		}

		public static void AddScopedServices(this IServiceCollection serviceCollection)
		{
			// Add scoped services (for each new HTTP request a new instance is created)
			_ = serviceCollection.AddScoped<IRunPopulationSimulation, RunPopulationSimulation>();
			_ = serviceCollection.AddScoped<IPopulationSimulationService, PopulationSimulationService>();
			_ = serviceCollection.AddScoped<IPopulationGrowthFactorsFacade, PopulationGrowthFactorsFacade>();
			_ = serviceCollection.AddScoped<IPopulationRecordRepository, PopulationRecordRepository>();
		}

		public static void AddBuiltInServices(this IServiceCollection serviceCollection)
		{
			// Add services to the container.
			serviceCollection.AddControllers();

			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			serviceCollection.AddOpenApi();

			// Add FluentValidation validators
			serviceCollection.AddValidatorsFromAssemblyContaining<SimulationRequestValidator>();
		}
	}
}

namespace ApplicationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add singleton services (one stateless instance for all HTTP requests)
            _ = builder.Services.AddSingleton<IMigrationStrategy, BasicMigrationStrategy>();
            _ = builder.Services.AddSingleton<IDisasterStrategy, RandomBasedDisasterStrategy>();

			// Add scoped services (for each new HTTP request a new instance is created)
			_ = builder.Services.AddScoped<IRunPopulationSimulation, RunPopulationSimulation>();
            _ = builder.Services.AddScoped<IPopulationSimulationService, PopulationSimulationService>();

            // Add services to the container.
            _ = builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            _ = builder.Services.AddOpenApi();

            // Add FluentValidation validators
            _ = builder.Services.AddValidatorsFromAssemblyContaining<SimulationRequestValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.MapOpenApi();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseAuthorization();
            _ = app.MapControllers();

            app.Run();
        }
    }
}

using Domain.Entities;
using Infrastructure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
	public static class WebApplicationExtensions
	{
		public static void ConfigureHttpRequestPipeline(this WebApplication webApplication)
		{
			// Configure the HTTP request pipeline.
			if (webApplication.Environment.IsDevelopment())
			{
				_ = webApplication.MapOpenApi();
			}

			_ = webApplication.UseHttpsRedirection();
			_ = webApplication.UseAuthorization();
			_ = webApplication.MapControllers();
		}

		public static void SeedDatabase(this WebApplication webApplication)
		{
			using var servicesScope = webApplication.Services.CreateScope();
			var databaseContext = servicesScope.ServiceProvider.GetRequiredService<AppDbContext>();

			databaseContext.Database.Migrate();

			if (!databaseContext.Populations.Any()) // SELECT EXISTS(SELECT 1 FROM Populations)
			{
				var population = new Population("Test");

				databaseContext.Populations.Add(population);
				databaseContext.PopulationRecords.AddRange(
					new PopulationRecord(1, 200) { PopulationId = population.Id },
					new PopulationRecord(2, 300) { PopulationId = population.Id }
				);

				_ = databaseContext.SaveChanges();
			}
		}
	}
}

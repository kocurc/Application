using ApplicationApi.Application.Validation;
using FluentValidation;

namespace ApplicationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            _ = builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            _ = builder.Services.AddOpenApi();

            // Add FluentValidation validators
            builder.Services.AddValidatorsFromAssemblyContaining<SimulationRequestValidator>();

            WebApplication app = builder.Build();

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

using Api.Extensions;
using Infrastructure.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureCustomKestrel();
            builder.Services.AddSingletonServices();
            builder.Services.AddScopedServices();
            builder.Services.AddBuiltInServices();
			builder.ConfigureDbContext();

            var app = builder.Build();

            app.ConfigureHttpRequestPipeline();
            app.SeedDatabase();
            app.Run();
        }
    }
}

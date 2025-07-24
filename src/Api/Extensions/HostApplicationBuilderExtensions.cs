using Infrastructure.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
	public static class HostApplicationBuilderExtensions
	{
		public static void ConfigureDbContext(this IHostApplicationBuilder hostApplicationBuilder)
		{
			var connectionString = hostApplicationBuilder.Configuration.GetConnectionString("DefaultConnection");

			_ = hostApplicationBuilder.Services.AddDbContext<AppDbContext>(dbContextOptionsBuilder =>
				dbContextOptionsBuilder.UseSqlite(connectionString));
		}
	}
}

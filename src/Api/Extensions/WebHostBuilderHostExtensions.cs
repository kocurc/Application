namespace Api.Extensions
{
	public static class WebHostBuilderHostExtensions
	{
		public static void ConfigureCustomKestrel(this IWebHostBuilder webHostBuilder)
		{
			webHostBuilder.ConfigureKestrel(kestrelServerOptions =>
			{
				kestrelServerOptions.ListenAnyIP(5000);
				kestrelServerOptions.ListenAnyIP(5001, kestrelListenOptions =>
				{
					_ = kestrelListenOptions.UseHttps();
				});
			});
		}
	}
}

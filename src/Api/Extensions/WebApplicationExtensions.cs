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
	}
}

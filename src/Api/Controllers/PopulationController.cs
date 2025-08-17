using Infrastructure.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopulationController(
		PopulationRecordRepository populationRecordRepository,
		ILogger<PopulationController> logger)
		: ControllerBase

	{
		private readonly ILogger<PopulationController> _logger = logger;

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var records = await populationRecordRepository.GetAllPopulationRecordsAsync();

			if (records.Count != 0)
			{
				return Ok(records);
			}

			_logger.LogError("No population records were found.");

			return NotFound("No population records were found.");
		}
	}
}

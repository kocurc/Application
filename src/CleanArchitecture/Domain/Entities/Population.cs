using System.Diagnostics.CodeAnalysis;
using Domain.Entities;

namespace Domain.Entities
{
	public class Population
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public DateTime? CreatedAt { get; private set; }
		public virtual List<PopulationRecord> PopulationRecords { get; set; } = [];

		public Population(string name, DateTime? createdAt = null)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

			Name = name;

			if (createdAt.HasValue)
			{
				CreatedAt = createdAt;
			}
		}
	}
}

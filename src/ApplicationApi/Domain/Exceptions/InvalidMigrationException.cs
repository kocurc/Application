namespace ApplicationApi.Domain.Exceptions
{
	[ExcludeFromCodeCoverage]
	public class InvalidMigrationException : Exception
	{
		public InvalidMigrationException() { }

		public InvalidMigrationException(string message) : base(message) { }

		public InvalidMigrationException(string message, Exception innerException) : base(message, innerException) { }
	}
}

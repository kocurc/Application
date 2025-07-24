using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidPopulationException : Exception
    {
        public InvalidPopulationException() { }

        public InvalidPopulationException(string? message) : base(message) { }

        public InvalidPopulationException(string? message, Exception? innerException) : base(message, innerException)
        { }
    }
}
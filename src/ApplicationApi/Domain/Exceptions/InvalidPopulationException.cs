namespace ApplicationApi.Domain.Exceptions
{
    /*
	 * Służą do zgłaszania błędów specyficznych dla logiki biznesowej
	 */
    public class InvalidPopulationException : Exception
    {
        public InvalidPopulationException()
        {
        }

        public InvalidPopulationException(string? message) : base(message)
        {
        }

        public InvalidPopulationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
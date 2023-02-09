namespace Api.Intuit.Infrastructure.Exceptions
{
    public class ForbiddenProjectException : ProjectException
    {
        public ForbiddenProjectException()
        {
        }

        public ForbiddenProjectException(string message) : base(message)
        {
        }

        public ForbiddenProjectException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

using Api.Intuit.Infrastructure.Bootstrappers;
using Api.Intuit.Infrastructure.Models.Errors;

namespace Api.Intuit.Infrastructure.Exceptions
{
    public class ProjectException : ApplicationException
    {
        protected ErrorModel? ErrorModel { get; set; }

        public ProjectException()
        {
        }

        public ProjectException(string message) : base(message)
        {
        }

        public ProjectException(string message, Exception inner) : base(message, inner)
        {
        }

        public bool WithLogError { get; set; } = false;

        public IList<ValidationError>? ValidationError { get; set; }

        public string? Module { get; set; }

        public string? Detail { get; set; }
    }
}

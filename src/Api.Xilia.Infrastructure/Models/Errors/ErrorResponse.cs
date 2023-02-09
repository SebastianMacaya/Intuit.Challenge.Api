namespace Api.Intuit.Infrastructure.Models.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse() { }
        public ErrorResponse(ErrorModelValidation error)
        {
            Errors.Add(error);
        }

        public List<ErrorModelValidation> Errors { get; set; } = new List<ErrorModelValidation>();
    }
}

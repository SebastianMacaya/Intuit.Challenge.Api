using MediatR;

namespace Api.Intuit.Infrastructure.Models.Generics
{
    public class GenericHandlerRequest<TRequest, TResponse> : IRequest<GenericHandlerResponse<TResponse>> where TResponse : class
    {
        public GenericHandlerRequest(TRequest values)
        {
            Value = values;
        }

        public TRequest? Value { get; set; }
    }
}

namespace Api.Intuit.Infrastructure.Models.Generics
{
    public class GenericHandlerResponse<TResponse>
    {
        public GenericHandlerResponse(TResponse values)
        {
            Values = values;
        }

        public TResponse Values { get; set; }
    }
}

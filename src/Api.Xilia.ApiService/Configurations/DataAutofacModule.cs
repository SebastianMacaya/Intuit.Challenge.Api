using Api.Intuit.Infrastructure.Data;
using Api.Intuit.Infrastructure.Data.Contracts;
using Autofac;

namespace Api.Intuit.ApiService.Configurations
{
    public class DataAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(UnitOfWork<,>))
                            .As(typeof(IUnitOfWork<,>))
                            .InstancePerLifetimeScope()
                            .WithParameter("traking", false);
        }
    }
}

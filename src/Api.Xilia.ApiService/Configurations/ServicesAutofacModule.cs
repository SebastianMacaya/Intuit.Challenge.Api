using Api.Intuit.Application;
using Api.Intuit.Infrastructure;
using Api.Intuit.Infrastructure.Services;
using Autofac;
using System.Reflection;

namespace Api.Intuit.ApiService.Configurations
{
    public class ServicesAutofacModule : Autofac.Module
    {
        private static Assembly[] ApplicationAssemblies
            => new[] { typeof(DummyApplication), typeof(DummyInfrastructure) }
            .Select(assembly => assembly.Assembly).ToArray();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ApplicationAssemblies)
                .Where(reference => typeof(IService).IsAssignableFrom(reference) && !reference.IsInterface && !reference.IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}

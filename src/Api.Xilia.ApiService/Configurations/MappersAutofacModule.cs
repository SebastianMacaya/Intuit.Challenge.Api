using Api.Intuit.Application;
using Api.Intuit.Infrastructure;
using Autofac;
using MediatR;
using System.Reflection;

namespace Api.Intuit.ApiService.Configurations
{
    public class MappersAutofacModule : Autofac.Module
    {
        private static Assembly[] ApplicationAssemblies
            => new[] { typeof(DummyApplication), typeof(DummyInfrastructure) }.Select(type => type.Assembly).ToArray();

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            ////builder
            ////    .RegisterAssemblyTypes(ApplicationAssemblies)
            ////    .AsClosedTypesOf(typeof(IMapperEntityModel<,>))
            ////    .AsImplementedInterfaces()
            ////    .InstancePerLifetimeScope();
        }
    }
}

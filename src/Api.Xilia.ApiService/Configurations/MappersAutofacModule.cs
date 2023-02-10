using Api.Intuit.Application;
using Api.Intuit.Application.Profiles;
using Api.Intuit.Infrastructure;
using Autofac;
using AutoMapper;
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

             builder.Register(context =>new MapperConfiguration(cfg =>
             {
                 //Register Mapper Profile
                 cfg.AddProfile<ClientProfile>();
                
             }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
        .As<IMapper>()
        .InstancePerLifetimeScope();



        }
    }
}

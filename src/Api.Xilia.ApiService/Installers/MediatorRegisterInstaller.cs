using Api.Intuit.ApiService.Installers.Contracts;
using Api.Intuit.Application;
using Api.Intuit.Domain;
using Api.Intuit.Infrastructure;
using MediatR;
using System.Reflection;

namespace Api.Intuit.ApiService.Installers
{
    public class MediatorRegisterInstaller : IInstallerServiceCollection
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            Assembly[] applicationAssembliesMediator = new[] { typeof(DummyApplication), typeof(DummyInfrastructure) }.Select(type => type.Assembly).ToArray();
            Assembly[] domainAssembliesMediator = new[] { typeof(DummyInfrastructure), typeof(DummyDomain) }.Select(type => type.Assembly).ToArray();

            services.AddMediatR(applicationAssembliesMediator);
            services.AddMediatR(domainAssembliesMediator);
        }
    }
}

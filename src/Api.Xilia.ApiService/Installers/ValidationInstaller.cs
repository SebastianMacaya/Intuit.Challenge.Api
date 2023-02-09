using Api.Intuit.ApiService.Filters;
using Api.Intuit.ApiService.Installers.Contracts;
using Api.Intuit.Application;
using FluentValidation.AspNetCore;

namespace Api.Intuit.ApiService.Installers
{
    public class ValidationInstaller : IInstallerServiceCollection
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            });

            services.AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<DummyApplication>());
        }
    }
}

using Api.Intuit.ApiService.Installers.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Intuit.ApiService.Installers
{
    public class VersionApiInstaller : IInstallerServiceCollection
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(int.Parse(configuration.GetSection("Api:Version").Value), 0);
            });
        }
    }
}

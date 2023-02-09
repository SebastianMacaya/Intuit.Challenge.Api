using Api.Intuit.ApiService.Installers.Contracts;
using Api.Intuit.Domain;
using Api.Intuit.Domain.BdIntuitClientes;
using Microsoft.EntityFrameworkCore;

namespace Api.Intuit.ApiService.Installers
{
    public class DbInstaller : IInstallerServiceCollection
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<ClientesDbContex>(build =>
                build.UseNpgsql(configuration.GetConnectionString("BaseDbContextConnectionString")));
        }
    }
}

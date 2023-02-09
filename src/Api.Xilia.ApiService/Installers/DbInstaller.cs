using Api.Intuit.ApiService.Installers.Contracts;
using Api.Intuit.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Intuit.ApiService.Installers
{
    public class DbInstaller : IInstallerServiceCollection
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<GestionDbContext>(build =>
                build.UseNpgsql(configuration.GetConnectionString("BaseDbContextConnectionString")));
        }
    }
}

using Api.Intuit.ApiService.Installers.Contracts;

namespace Api.Intuit.ApiService.Installers.Extensions
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(installerServiceCollection =>
                typeof(IInstallerServiceCollection).IsAssignableFrom(installerServiceCollection) && !installerServiceCollection.IsInterface && !installerServiceCollection.IsAbstract).Select(Activator.CreateInstance).Cast<IInstallerServiceCollection>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }

        public static void InstallApplicationInAssembly(this IApplicationBuilder app, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(installerApplicationBuilder =>
                typeof(IInstallerApplicationBuilder).IsAssignableFrom(installerApplicationBuilder) && !installerApplicationBuilder.IsInterface && !installerApplicationBuilder.IsAbstract).Select(Activator.CreateInstance).Cast<IInstallerApplicationBuilder>().ToList();

            installers.ForEach(installer => installer.InstallApplication(app, configuration));
        }
    }
}
